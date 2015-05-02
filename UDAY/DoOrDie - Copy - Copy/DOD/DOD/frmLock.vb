Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Input
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.Threading
Imports System.Net.Sockets
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Net

Public Class frmLock
    Dim nextform As String
    Public tbl_section As New DataTable
    Public tbl_account As New DataTable
    Public pro As New Process '~~> For open,close application
    Public isInitial As Boolean = True
    Public isError As Boolean = False

    Private Sub BlockAll()
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\StorageDevicePolicies", "WriteProtect", "1", Microsoft.Win32.RegistryValueKind.DWord)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord)

        Dim process As System.Diagnostics.Process = Nothing
        Dim psi As New ProcessStartInfo
        psi.UseShellExecute = True
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.FileName = "taskkill.exe"
        psi.Arguments = "/F /IM explorer.exe"
        process = System.Diagnostics.Process.Start(psi)
    End Sub

    Private Sub UnblockAll()
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\StorageDevicePolicies", "WriteProtect", "0", Microsoft.Win32.RegistryValueKind.DWord)

        Dim OskProcesss = New Process()
        OskProcesss.StartInfo.UseShellExecute = True
        OskProcesss.StartInfo.CreateNoWindow = True
        OskProcesss.StartInfo.FileName = "C:\Windows\explorer.exe"
        OskProcesss.StartInfo.WorkingDirectory = Application.StartupPath
        OskProcesss.Start()

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord)
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                If isInitial = True Then
                    '~~> Disable the explorer.exe
                    BlockAll()

                    If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity")) Then
                        System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
                    End If

                    If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile")) Then
                        System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile"))
                    End If

                    If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles")) Then
                        System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles"))
                    End If

                    Dim isDone As Boolean = False
                    isStart = False

                    '~~> Delete the Record for tbl_computer, tbl_commandpc and tbl_timer
                    sql = "SELECT * FROM tbl_computer WHERE computername=?name"
                    Dim selcomp As New MySqlCommand(sql, con)
                    selcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                    da = New MySqlDataAdapter(selcomp)
                    ds.Clear()
                    da.Fill(ds, "comp")

                    If ds.Tables("comp").Rows.Count > 0 Then
                        If ds.Tables("comp").Rows(0).Item("actdone").ToString = "Yes" Then
                            isDone = True
                        Else
                            isDone = False
                        End If

                        If ds.Tables("comp").Rows(0).Item("computername").ToString = My.Computer.Name Then
                            If ds.Tables("comp").Rows(0).Item("ipaddress").ToString = v4() Then
                                myport = ds.Tables("comp").Rows(0).Item("imageport").ToString

                                sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                                Dim seltimer As New MySqlCommand(sql, con)
                                seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                                seltimer.Parameters.AddWithValue("?ip", v4())
                                da = New MySqlDataAdapter(seltimer)
                                da.Fill(ds, "seltimer")

                                If ds.Tables("seltimer").Rows.Count > 0 Then
                                    CountDownFrom = TimeSpan.FromSeconds(CInt(ds.Tables("seltimer").Rows(0).Item("pcsec").ToString))

                                    TargetDT = CDate(ds.Tables("seltimer").Rows(0).Item("pcin").ToString).Add(CountDownFrom)
                                    ts = TargetDT.Subtract(DateTime.Now)

                                    If Not ts.Seconds > 0 Then
                                        sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                                        Dim deltimer As New MySqlCommand(sql, con)
                                        deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                                        deltimer.Parameters.AddWithValue("?ip", v4())

                                        sql = "DELETE FROM tbl_login WHERE pcname=?name"
                                        Dim dellogins As New MySqlCommand(sql, con)
                                        dellogins.Parameters.AddWithValue("?name", My.Computer.Name)

                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If

                                        deltimer.ExecuteNonQuery()
                                        dellogins.ExecuteNonQuery()
                                        con.Close()
                                    End If
                                End If

                                ds.Tables("seltimer").Clear()

                                txtUsername.Text = ""
                                txtPassword.Text = ""

                                Try
                                    start_sending.Start()
                                Catch : End Try

                                CheckCommand.Start()
                                CheckTime.Start()
                                CheckName.Start()

                                Exit Sub
                            Else
                                GoTo renew
                            End If
                        End If
                    End If

renew:
                    sql = "DELETE FROM tbl_commandpc WHERE computername=?name OR ipaddress=?ip"
                    Dim delcomm As New MySqlCommand(sql, con)
                    delcomm.Parameters.AddWithValue("?name", My.Computer.Name)
                    delcomm.Parameters.AddWithValue("?ip", v4())

                    sql = "DELETE FROM tbl_timer WHERE computername=?name OR ipaddress=?ip"
                    Dim deltim As New MySqlCommand(sql, con)
                    deltim.Parameters.AddWithValue("?name", My.Computer.Name)
                    deltim.Parameters.AddWithValue("?ip", v4())

                    sql = "DELETE FROM tbl_login WHERE pcname=?name"
                    Dim dellogin As New MySqlCommand(sql, con)
                    dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    delcomm.ExecuteNonQuery()
                    deltim.ExecuteNonQuery()
                    dellogin.ExecuteNonQuery()
                    con.Close()

                    sql = "DELETE FROM tbl_computer WHERE computername=?name OR ipaddress=?ip"
                    Dim delcomp As New MySqlCommand(sql, con)
                    delcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                    delcomp.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    delcomp.ExecuteNonQuery()
                    con.Close()

                    '~~> Add the Record for tbl_computer, tbl_commandpc and tbl_timer for remote access
                    sql = "INSERT INTO tbl_computer(wordcall,computername,ipaddress,actDone) VALUES(?word,?name,?ip,?done)"
                    Dim addcomp As New MySqlCommand(sql, con)
                    addcomp.Parameters.AddWithValue("?word", My.Computer.Name)
                    addcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                    addcomp.Parameters.AddWithValue("?ip", v4())

                    If isDone = True Then
                        addcomp.Parameters.AddWithValue("?done", "Yes")
                    Else
                        addcomp.Parameters.AddWithValue("?done", "No")
                    End If

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomp.ExecuteNonQuery()
                    con.Close()

test:
                    Randomize()

                    Dim generated_port As String = CInt(Math.Ceiling(Rnd() * 1023)) + 1

                    If generated_port = "8099" Or generated_port = "8085" Or generated_port = "82" Or generated_port = "0" Then
                        GoTo test
                    End If

                    sql = "SELECT * FROM tbl_computer WHERE imageport=?port"
                    Dim compport As New MySqlCommand(sql, con)
                    compport.Parameters.AddWithValue("?port", generated_port)
                    da = New MySqlDataAdapter(compport)
                    da.Fill(ds, "compport")

                    If ds.Tables("compport").Rows.Count > 0 Then
                        ds.Tables("compport").Clear()

                        GoTo test
                    End If

                    ds.Tables("compport").Clear()

                    sql = "UPDATE tbl_computer SET imageport=?port WHERE computername=?name AND ipaddress=?ip"
                    Dim upport As New MySqlCommand(sql, con)
                    upport.Parameters.AddWithValue("?port", generated_port)
                    upport.Parameters.AddWithValue("?name", My.Computer.Name)
                    upport.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upport.ExecuteNonQuery()
                    con.Close()

                    myport = generated_port

                    txtUsername.Text = ""
                    txtPassword.Text = ""

                    start_sending.Start()

                    CheckCommand.Start()
                    CheckTime.Start()
                    CheckName.Start()
                Else
                    txtUsername.Text = ""
                    txtPassword.Text = ""

                    CheckCommand.Start()
                    CheckTime.Start()
                    CheckName.Start()
                End If
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
            Else
                Animation.Stop()

                If nextform = "Create" Then
                    sql = "UPDATE tbl_oncreate SET onCreate='Yes'"
                    Dim uponcreate As New MySqlCommand(sql, con)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    uponcreate.ExecuteNonQuery()
                    con.Close()

                    frmCreateUser.Show()
                ElseIf nextform = "Menu" Then
                    frmMenu.Show()
                ElseIf nextform = "Student" Then
                    frmStudentRegistration.Show()
                End If
            End If
        End If
    End Sub

    Public isLogout As Boolean = False
    Public WithEvents recfirst As New System.Speech.Recognition.SpeechRecognitionEngine
    Public WithEvents recsecond As New System.Speech.Recognition.SpeechRecognitionEngine

    Public start_sending As Thread = New Thread(AddressOf sendimagetoserver)
    Public bool_startsending As Boolean = True
    Public bool_startrecieving As Boolean = True
    Private bf As BinaryFormatter = New BinaryFormatter

    Private Sub recieveimagefromserver()
        While bool_startrecieving

        End While
    End Sub

    Private myport As String

    Private Sub sendimagetoserver()
        While bool_startsending
            'don't send to self
            If My.Settings.ServerIP = v4() Then
                bool_startsending = False
            Else
                Try
                    'MessageBox.Show("start")
                    Dim mclient As TcpClient = New TcpClient()

                    Dim nstream As NetworkStream
                    mclient.Connect(My.Settings.ServerIP, myport)
                    'MessageBox.Show("connected")
                    nstream = mclient.GetStream
                    'MessageBox.Show("getstream")
                    bf.Serialize(nstream, Desktop())
                    'MessageBox.Show("serializing")
                    mclient.Close()
                    'MessageBox.Show("close mclient")
                Catch ex As Exception
                    'continue to send
                    'mclient.Close()
                    'Continue While
                    'MessageBox.Show(ex.Message)

                    Continue While
                End Try
            End If
        End While
    End Sub

    Private Sub frmLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not e.CloseReason = CloseReason.WindowsShutDown Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Left = My.Computer.Screen.Bounds.Width - 560
        Panel1.Top = My.Computer.Screen.Bounds.Height - 280
        Panel1.Tag = "Login"
        ReminderPanel.Left = 20
        ReminderPanel.Top = Panel1.Top + 100

        message = "Welcome to Voice Command Controller for IT Laboratory"

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Sub SectionSelection()
        tbl_section.Clear()
        tbl_account.Clear()

        sql = "SELECT * FROM tbl_schedule WHERE accountuser=?user"
        Dim sch As New MySqlCommand(sql, con)
        sch.Parameters.AddWithValue("?user", txtUsername.Text)
        da = New MySqlDataAdapter(sch)
        da.Fill(tbl_section)

        sql = "SELECT * FROM tbl_account WHERE accountuser=?user"
        Dim acc As New MySqlCommand(sql, con)
        acc.Parameters.AddWithValue("?user", txtUsername.Text)
        da = New MySqlDataAdapter(acc)
        da.Fill(tbl_account)

        Dim daytoday As String = CDate(Today).DayOfWeek.ToString
        Dim timetoday As String = CDate(TimeOfDay).ToShortTimeString

        '~~> Check if there's a schedule for the day today
        Dim selrec() As DataRow = tbl_section.Select("daysched='" & daytoday & "'")
        If selrec.Length = 1 Then
            With frmMenu
                .username = selrec(0).Item("accountuser").ToString
                .password = tbl_account.Rows(0).Item("accountpass").ToString
                .lastname = tbl_account.Rows(0).Item("lastname").ToString
                .firstname = tbl_account.Rows(0).Item("firstname").ToString
                .middlename = tbl_account.Rows(0).Item("middlename").ToString
                .gender = tbl_account.Rows(0).Item("gender").ToString
                .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                .major = selrec(0).Item("major").ToString
                .year = selrec(0).Item("year").ToString
                .section = selrec(0).Item("section").ToString
                .subject = selrec(0).Item("subject").ToString
                .daysched = selrec(0).Item("daysched").ToString
                .dayin = selrec(0).Item("dayin").ToString
                .dayout = selrec(0).Item("dayout").ToString
                .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                usermajor = .major
                useryear = .year
                usersection = .section
                usersubject = .subject
                userday = .daysched
                userin = .dayin
                userout = .dayout
            End With

            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
            Dim upsch As New MySqlCommand(sql, con)
            upsch.Parameters.AddWithValue("?user", selrec(0).Item("accountuser").ToString)
            upsch.Parameters.AddWithValue("?day", selrec(0).Item("daysched").ToString)
            upsch.Parameters.AddWithValue("?in", selrec(0).Item("dayin").ToString)
            upsch.Parameters.AddWithValue("?out", selrec(0).Item("dayout").ToString)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            con.Close()

            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf selrec.Length > 1 Then
            For a = 1 To selrec.Length
                Dim hin As Integer = CDate(selrec(a - 1).Item("dayin").ToString).Hour
                Dim hout As Integer = CDate(selrec(a - 1).Item("dayout").ToString).Hour
                Dim min As Integer = CDate(selrec(a - 1).Item("dayin").ToString).Minute
                Dim mout As Integer = CDate(selrec(a - 1).Item("dayout").ToString).Minute

                If CDate(timetoday).Hour > hin Then
                    If CDate(timetoday).Hour < hout Then
                        '~~> Open Main Menu (Update variables first)
                        With frmMenu
                            .username = selrec(a - 1).Item("accountuser").ToString
                            .password = tbl_account.Rows(0).Item("accountpass").ToString
                            .lastname = tbl_account.Rows(0).Item("lastname").ToString
                            .firstname = tbl_account.Rows(0).Item("firstname").ToString
                            .middlename = tbl_account.Rows(0).Item("middlename").ToString
                            .gender = tbl_account.Rows(0).Item("gender").ToString
                            .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                            .major = selrec(a - 1).Item("major").ToString
                            .year = selrec(a - 1).Item("year").ToString
                            .section = selrec(a - 1).Item("section").ToString
                            .subject = selrec(a - 1).Item("subject").ToString
                            .daysched = selrec(a - 1).Item("daysched").ToString
                            .dayin = selrec(a - 1).Item("dayin").ToString
                            .dayout = selrec(a - 1).Item("dayout").ToString
                            .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                            usermajor = .major
                            useryear = .year
                            usersection = .section
                            usersubject = .subject
                            userday = .daysched
                            userin = .dayin
                            userout = .dayout

                            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                            Dim upsch As New MySqlCommand(sql, con)
                            upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                            upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                            upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                            upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            upsch.ExecuteNonQuery()
                            con.Close()

                            GoTo skip
                        End With
                    ElseIf CDate(timetoday).Hour = hout Then
                        If CDate(TimeOfDay).Minute <= mout Then
                            '~~> Open Main Menu
                            With frmMenu
                                .username = selrec(a - 1).Item("accountuser").ToString
                                .password = tbl_account.Rows(0).Item("accountpass").ToString
                                .lastname = tbl_account.Rows(0).Item("lastname").ToString
                                .firstname = tbl_account.Rows(0).Item("firstname").ToString
                                .middlename = tbl_account.Rows(0).Item("middlename").ToString
                                .gender = tbl_account.Rows(0).Item("gender").ToString
                                .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                                .major = selrec(a - 1).Item("major").ToString
                                .year = selrec(a - 1).Item("year").ToString
                                .section = selrec(a - 1).Item("section").ToString
                                .subject = selrec(a - 1).Item("subject").ToString
                                .daysched = selrec(a - 1).Item("daysched").ToString
                                .dayin = selrec(a - 1).Item("dayin").ToString
                                .dayout = selrec(a - 1).Item("dayout").ToString
                                .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                                usermajor = .major
                                useryear = .year
                                usersection = .section
                                usersubject = .subject
                                userday = .daysched
                                userin = .dayin
                                userout = .dayout

                                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                                Dim upsch As New MySqlCommand(sql, con)
                                upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                                upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                                upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                                upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                upsch.ExecuteNonQuery()
                                con.Close()

                                GoTo skip
                            End With
                        End If
                    End If
                ElseIf CDate(TimeOfDay).Hour = hin Then
                    If CDate(timetoday).Hour < hout Then
                        '~~> Open Main Menu
                        With frmMenu
                            .username = selrec(a - 1).Item("accountuser").ToString
                            .password = tbl_account.Rows(0).Item("accountpass").ToString
                            .lastname = tbl_account.Rows(0).Item("lastname").ToString
                            .firstname = tbl_account.Rows(0).Item("firstname").ToString
                            .middlename = tbl_account.Rows(0).Item("middlename").ToString
                            .gender = tbl_account.Rows(0).Item("gender").ToString
                            .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                            .major = selrec(a - 1).Item("major").ToString
                            .year = selrec(a - 1).Item("year").ToString
                            .section = selrec(a - 1).Item("section").ToString
                            .subject = selrec(a - 1).Item("subject").ToString
                            .daysched = selrec(a - 1).Item("daysched").ToString
                            .dayin = selrec(a - 1).Item("dayin").ToString
                            .dayout = selrec(a - 1).Item("dayout").ToString
                            .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                            usermajor = .major
                            useryear = .year
                            usersection = .section
                            usersubject = .subject
                            userday = .daysched
                            userin = .dayin
                            userout = .dayout

                            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                            Dim upsch As New MySqlCommand(sql, con)
                            upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                            upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                            upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                            upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            upsch.ExecuteNonQuery()
                            con.Close()

                            GoTo skip
                        End With
                    ElseIf CDate(timetoday).Hour = hout Then
                        If CDate(TimeOfDay).Minute <= mout Then
                            '~~> Open Main Menu
                            With frmMenu
                                .username = selrec(a - 1).Item("accountuser").ToString
                                .password = tbl_account.Rows(0).Item("accountpass").ToString
                                .lastname = tbl_account.Rows(0).Item("lastname").ToString
                                .firstname = tbl_account.Rows(0).Item("firstname").ToString
                                .middlename = tbl_account.Rows(0).Item("middlename").ToString
                                .gender = tbl_account.Rows(0).Item("gender").ToString
                                .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                                .major = selrec(a - 1).Item("major").ToString
                                .year = selrec(a - 1).Item("year").ToString
                                .section = selrec(a - 1).Item("section").ToString
                                .subject = selrec(a - 1).Item("subject").ToString
                                .daysched = selrec(a - 1).Item("daysched").ToString
                                .dayin = selrec(a - 1).Item("dayin").ToString
                                .dayout = selrec(a - 1).Item("dayout").ToString
                                .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                                usermajor = .major
                                useryear = .year
                                usersection = .section
                                usersubject = .subject
                                userday = .daysched
                                userin = .dayin
                                userout = .dayout

                                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                                Dim upsch As New MySqlCommand(sql, con)
                                upsch.Parameters.AddWithValue("?user", selrec(a - 1).Item("accountuser").ToString)
                                upsch.Parameters.AddWithValue("?day", selrec(a - 1).Item("daysched").ToString)
                                upsch.Parameters.AddWithValue("?in", selrec(a - 1).Item("dayin").ToString)
                                upsch.Parameters.AddWithValue("?out", selrec(a - 1).Item("dayout").ToString)

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                upsch.ExecuteNonQuery()
                                con.Close()

                                GoTo skip
                            End With
                        End If
                    End If
                End If
            Next

            '~~> No schedule match for the Time
            With frmMenu
                .username = selrec(0).Item("accountuser").ToString
                .password = tbl_account.Rows(0).Item("accountpass").ToString
                .lastname = tbl_account.Rows(0).Item("lastname").ToString
                .firstname = tbl_account.Rows(0).Item("firstname").ToString
                .middlename = tbl_account.Rows(0).Item("middlename").ToString
                .gender = tbl_account.Rows(0).Item("gender").ToString
                .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                .major = selrec(0).Item("major").ToString
                .year = selrec(0).Item("year").ToString
                .section = selrec(0).Item("section").ToString
                .subject = selrec(0).Item("subject").ToString
                .daysched = selrec(0).Item("daysched").ToString
                .dayin = selrec(0).Item("dayin").ToString
                .dayout = selrec(0).Item("dayout").ToString
                .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                usermajor = .major
                useryear = .year
                usersection = .section
                usersubject = .subject
                userday = .daysched
                userin = .dayin
                userout = .dayout

                sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
                Dim upsch As New MySqlCommand(sql, con)
                upsch.Parameters.AddWithValue("?user", selrec(0).Item("accountuser").ToString)
                upsch.Parameters.AddWithValue("?day", selrec(0).Item("daysched").ToString)
                upsch.Parameters.AddWithValue("?in", selrec(0).Item("dayin").ToString)
                upsch.Parameters.AddWithValue("?out", selrec(0).Item("dayout").ToString)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upsch.ExecuteNonQuery()
                con.Close()

                GoTo skip
            End With

            Exit Sub
skip:
            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        Else
            '~~> No schedule match for the day
            With frmMenu
                .username = tbl_section.Rows(0).Item("accountuser").ToString
                .password = tbl_account.Rows(0).Item("accountpass").ToString
                .lastname = tbl_account.Rows(0).Item("lastname").ToString
                .firstname = tbl_account.Rows(0).Item("firstname").ToString
                .middlename = tbl_account.Rows(0).Item("middlename").ToString
                .gender = tbl_account.Rows(0).Item("gender").ToString
                .wordtype = tbl_account.Rows(0).Item("wordtype").ToString
                .major = tbl_section.Rows(0).Item("major").ToString
                .year = tbl_section.Rows(0).Item("year").ToString
                .section = tbl_section.Rows(0).Item("section").ToString
                .subject = tbl_section.Rows(0).Item("subject").ToString
                .daysched = tbl_section.Rows(0).Item("daysched").ToString
                .dayin = tbl_section.Rows(0).Item("dayin").ToString
                .dayout = tbl_section.Rows(0).Item("dayout").ToString
                .isTutorial = tbl_account.Rows(0).Item("isTutorial").ToString

                usermajor = .major
                useryear = .year
                usersection = .section
                usersubject = .subject
                userday = .daysched
                userin = .dayin
                userout = .dayout
            End With

            sql = "UPDATE tbl_schedule SET status='Online' WHERE accountuser=?user AND daysched=?day AND dayin=?in AND dayout=?out"
            Dim upsch As New MySqlCommand(sql, con)
            upsch.Parameters.AddWithValue("?user", tbl_section.Rows(0).Item("accountuser").ToString)
            upsch.Parameters.AddWithValue("?day", tbl_section.Rows(0).Item("daysched").ToString)
            upsch.Parameters.AddWithValue("?in", tbl_section.Rows(0).Item("dayin").ToString)
            upsch.Parameters.AddWithValue("?out", tbl_section.Rows(0).Item("dayout").ToString)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upsch.ExecuteNonQuery()
            con.Close()

            nextform = "Menu"
            Animation.Tag = "Hide"
            Animation.Start()
        End If
    End Sub

    Dim msgshowcount As Integer = 0

    Private Sub ShowMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMessage.Tick
        If ShowMessage.Tag = "Show" Then
            If lblMessage.Top > 10 Then
                lblMessage.Top -= 4
            ElseIf lblMessage.Top > 0 Then
                lblMessage.Top -= 1
            Else
                ShowMessage.Interval = 1000
                ShowMessage.Tag = "Count"
            End If
        ElseIf ShowMessage.Tag = "Count" Then
            If msgshowcount = 2 Then
                ShowMessage.Interval = 10
                ShowMessage.Tag = "Hide"
                msgshowcount = 0
            Else
                msgshowcount += 1
            End If
        Else
            If lblMessage.Top < 40 Then
                lblMessage.Top += 4
            ElseIf lblMessage.Top < 50 Then
                lblMessage.Top += 1
            Else
                ShowMessage.Stop()
            End If
        End If
    End Sub

    Private Sub lblShow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShow.MouseDown
        txtPassword.PasswordChar = ""
    End Sub

    Private Sub lblShow_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShow.MouseLeave
        lblShow.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShow_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShow.MouseMove
        lblShow.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblShow_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShow.MouseUp
        txtPassword.PasswordChar = "*"
    End Sub

    Public studentid, studentlname, studentfname, studentmname, studentpass, major, year, section, subject, accountuser As String

    Public lastUsername, lastmajor, lastyear, lastsection, lastsubject, lastgender As String
    Public isOnline As Boolean = False

    Sub CheckForOnline()
        '~~> Check if a User is already online
        sql = "SELECT * FROM tbl_schedule WHERE `status`='Online'"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "usercount")

        If ds.Tables("usercount").Rows.Count > 0 Then
            lastUsername = ds.Tables("usercount").Rows(0).Item("accountuser").ToString
            lastmajor = ds.Tables("usercount").Rows(0).Item("major").ToString
            lastyear = ds.Tables("usercount").Rows(0).Item("year").ToString
            lastsection = ds.Tables("usercount").Rows(0).Item("section").ToString
            lastsubject = ds.Tables("usercount").Rows(0).Item("subject").ToString

            isOnline = True
        Else
            lastUsername = ""
            isOnline = False
        End If
    End Sub

    Sub StudentLogin()
        If txtUsername.Text.ToString = My.Settings.studuser.ToString Then
            If txtPassword.Text.ToString = My.Settings.studpass.ToString Then

                If isOnline = False Then
                    '~~> No server is online, therefore cannot login

                    message = "Unable to process your login request.. No server detected"
                    MsgBox("Unable to process your login request.. No server detected", MsgBoxStyle.Information, "Login Account")

                    Exit Sub
                End If

                nextform = "Student"
                Animation.Tag = "Hide"
                Animation.Start()

                Exit Sub
            End If
        End If

        If isOnline = True Then
            Dim loggedid As String

            '~~> Check for logged in account
            sql = "SELECT * FROM tbl_login WHERE pcname=?name"
            Dim login As New MySqlCommand(sql, con)
            login.Parameters.AddWithValue("?name", My.Computer.Name)
            da = New MySqlDataAdapter(login)
            da.Fill(ds, "login")

            If ds.Tables("login").Rows.Count > 0 Then
                loggedid = ds.Tables("login").Rows(0).Item("studentid").ToString
            Else
                loggedid = ""
            End If

            '~~> Check if the account is a student account
            sql = "SELECT * FROM tbl_student WHERE studentid=?id AND studentpass=?pass AND accountuser=?user AND major=?major AND year=?year AND section=?section AND subject=?subject"
            Dim studlog As New MySqlCommand(sql, con)
            studlog.Parameters.AddWithValue("?id", txtUsername.Text)
            studlog.Parameters.AddWithValue("?pass", txtPassword.Text)
            studlog.Parameters.AddWithValue("?user", lastUsername)
            studlog.Parameters.AddWithValue("?major", lastmajor)
            studlog.Parameters.AddWithValue("?year", lastyear)
            studlog.Parameters.AddWithValue("?section", lastsection)
            studlog.Parameters.AddWithValue("?subject", lastsubject)
            da = New MySqlDataAdapter(studlog)
            da.Fill(ds, "stud")

            If ds.Tables("stud").Rows.Count > 0 Then
                If ds.Tables("stud").Rows(0).Item("status").ToString = "Online" Then
                    If Not loggedid = "" Then
                        If ds.Tables("stud").Rows(0).Item("studentid").ToString = loggedid Then
                            GoTo skip
                        End If
                    End If

                    message = "You are already logged in to another terminal"
                    MsgBox("You are already logged in to another terminal", MsgBoxStyle.Information, "Login Account")

                    Exit Sub
                Else
                    If Not loggedid = "" Then
                        If Not ds.Tables("stud").Rows(0).Item("studentid").ToString = loggedid Then
                            message = "You cannot login yet.. there is an ongoing Activity"

                            MsgBox("Cannot Login with other Account.. There is an ongoing Activity", MsgBoxStyle.Information, "Login Account")

                            Exit Sub
                        End If
                    End If
skip:
                    Panel1.Tag = "Student"
                    LoginPanel.Visible = False
                    StudentPanel.Visible = True

                    studentid = ds.Tables("stud").Rows(0).Item("studentid").ToString
                    studentlname = ds.Tables("stud").Rows(0).Item("studentlname").ToString
                    studentfname = ds.Tables("stud").Rows(0).Item("studentfname").ToString
                    studentmname = ds.Tables("stud").Rows(0).Item("studentmname").ToString
                    studentpass = ds.Tables("stud").Rows(0).Item("studentpass").ToString
                    major = ds.Tables("stud").Rows(0).Item("major").ToString
                    year = ds.Tables("stud").Rows(0).Item("year").ToString
                    section = ds.Tables("stud").Rows(0).Item("section").ToString
                    subject = ds.Tables("stud").Rows(0).Item("subject").ToString
                    accountuser = ds.Tables("stud").Rows(0).Item("accountuser").ToString

                    If Not Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity")) Then
                        Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
                    End If

                    lblID.Text = studentid
                    lblName.Text = studentlname & ", " & studentfname & " " & studentmname

                    isLogin = True

                    If loggedid = "" Then
                        sql = "INSERT INTO tbl_login VALUES(?id,?name)"
                        Dim addlogin As New MySqlCommand(sql, con)
                        addlogin.Parameters.AddWithValue("?id", studentid)
                        addlogin.Parameters.AddWithValue("?name", My.Computer.Name)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addlogin.ExecuteNonQuery()
                        con.Close()
                    Else
                        sql = "UPDATE tbl_login SET studentid=?id, pcname=?name WHERE pcname=?compname"
                        Dim uplogin As New MySqlCommand(sql, con)
                        uplogin.Parameters.AddWithValue("?id", studentid)
                        uplogin.Parameters.AddWithValue("?name", My.Computer.Name)
                        uplogin.Parameters.AddWithValue("?compname", My.Computer.Name)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        uplogin.ExecuteNonQuery()
                        con.Close()
                    End If

                    sql = "UPDATE tbl_student SET status='Online' WHERE studentid=?id AND accountuser=?user"
                    Dim upstud As New MySqlCommand(sql, con)
                    upstud.Parameters.AddWithValue("?id", studentid)
                    upstud.Parameters.AddWithValue("?user", accountuser)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upstud.ExecuteNonQuery()
                    con.Close()

                    message = "Welcome student.. Please wait for command from the server"

                    ReminderPanel.Visible = True

                    isStart = False

                    Exit Sub
                End If
            End If
        End If

        UserLogin()
    End Sub

    Dim usergender As String
    Dim usermajor, useryear, usersection, usersubject, userday, userin, userout As String
    Dim isTutorial As String = ""

    Sub CreateDatabase()

    End Sub

    Private socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Private client As Socket
    Dim messages As String

    Private ctThread As Threading.Thread = New Threading.Thread(AddressOf listen)
    Private serverThread As Threading.Thread = New Threading.Thread(AddressOf setserver)

    Private Sub listen()
        While True
            Try
                socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                socket.Bind(New IPEndPoint(IPAddress.Any, 123))
                socket.Listen(3)
                Dim received As Integer = 0
                client = socket.Accept()
                Dim buffers(5120) As Byte
                received = client.Receive(buffers)

                If (received > 0) Then
                    messages = Encoding.ASCII.GetString(buffers, 0, received)

                    If My.Settings.ServerIP = messages Then
                        Exit Sub
                    End If

                    CheckTime.Stop()
                    CheckCommand.Stop()

                    My.Settings.ServerIP = messages
                    My.Settings.Save()

                    For a = 1 To applist.Count
                        Dim appname() As String = applist(a - 1).Split("\")

                        Dim process As System.Diagnostics.Process = Nothing
                        Dim psi As New ProcessStartInfo
                        psi.UseShellExecute = True
                        psi.WindowStyle = ProcessWindowStyle.Hidden
                        psi.FileName = "taskkill.exe"
                        psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                        process = System.Diagnostics.Process.Start(psi)
                    Next

                    applist.Clear()

                    Try
                        con.ConnectionString = "Server=" & My.Settings.ServerIP & ";Database=dod;Uid=username;Pwd=nunaoppa;"
                        con.Open()
                        con.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Set Server")
                    End Try

                    If frmWarning.Visible = True Then
                        frmWarning.GetTime.Stop()
                        frmWarning.Animation.Tag = "Hide"
                        frmWarning.Animation.Start()
                    End If

                    sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                    Dim deltimer As New MySqlCommand(sql, con)
                    deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                    deltimer.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    deltimer.ExecuteNonQuery()
                    con.Close()

                    sql = "UPDATE tbl_computer SET actdone='Yes' WHERE computername=?name AND ipaddress=?ip"
                    Dim upcomp As New MySqlCommand(sql, con)
                    upcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                    upcomp.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upcomp.ExecuteNonQuery()
                    con.Close()

                    '~~> Delete from tbl_login
                    sql = "DELETE FROM tbl_login WHERE pcname=?name"
                    Dim dellogin As New MySqlCommand(sql, con)
                    dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    dellogin.ExecuteNonQuery()
                    con.Close()

                    studentid = ""
                    studentlname = ""
                    studentfname = ""
                    studentmname = ""
                    major = ""
                    year = ""
                    section = ""
                    subject = ""
                    accountuser = ""

                    resetLogin()

                    isLogout = False

                    isLogin = False

                    isStart = False

                    CheckTime.Start()
                    CheckCommand.Start()
                End If

                socket.Close()
                client.Close()
            Catch ex As System.Net.Sockets.SocketException

                socket.Close()
                client.Close()
            End Try
        End While

    End Sub

    Sub resetLogin()
        Try
            StudentPanel.Visible = False
            LoginPanel.Visible = True

            txtUsername.Text = ""
            txtPassword.Text = ""
        Catch : End Try
    End Sub

    Sub setserver()
        While My.Settings.ServerIP = v4()
            Try
                '~~> Set this Computer as the Server and notify all Client Computer
                Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim buffer() As Byte = Encoding.ASCII.GetBytes(v4())

                sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
                Dim complist As New MySqlCommand(sql, con)
                complist.Parameters.AddWithValue("?name", My.Computer.Name)
                complist.Parameters.AddWithValue("?ip", v4())
                da = New MySqlDataAdapter(complist)
                ds.Clear()
                da.Fill(ds, "complist")

                If ds.Tables("complist").Rows.Count > 0 Then
                    For a = 1 To ds.Tables("complist").Rows.Count
                        Try
                            sock.Connect(ds.Tables("complist").Rows(a - 1).Item("ipaddress").ToString, 123)
                        Catch ex As System.Net.Sockets.SocketException
                        End Try

                        Try
                            sock.Send(buffer)
                        Catch ex As System.Net.Sockets.SocketException
                        End Try
                    Next
                End If
            Catch : End Try
        End While
    End Sub

    Sub UserLogin()
        If txtUsername.Text.ToString = "voicecommand" Then
            If txtPassword.Text.ToString = "voicecommand" Then
                CheckTime.Stop()
                CheckCommand.Stop()

                sql = "DELETE FROM tbl_commandpc"
                Dim delcommand As New MySqlCommand(sql, con)

                sql = "DELETE FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
                Dim delcomp As New MySqlCommand(sql, con)
                delcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                delcomp.Parameters.AddWithValue("?ip", v4())

                sql = "DELETE FROM tbl_timer"
                Dim deltimer As New MySqlCommand(sql, con)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delcommand.ExecuteNonQuery()
                delcomp.ExecuteNonQuery()
                deltimer.ExecuteNonQuery()

                con.Close()

                My.Settings.ServerIP = v4()
                My.Settings.Save()

                Try
                    con.ConnectionString = "Server=" & My.Settings.ServerIP & ";Database=dod;Uid=username;Pwd=nunaoppa;"
                    con.Open()
                    con.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Set Server")
                End Try

                '~~> Add the Record for tbl_computer, tbl_commandpc and tbl_timer for remote access
                sql = "INSERT INTO tbl_computer(wordcall,computername,ipaddress,actDone) VALUES(?word,?name,?ip,?done)"
                Dim addcomp As New MySqlCommand(sql, con)
                addcomp.Parameters.AddWithValue("?word", My.Computer.Name)
                addcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                addcomp.Parameters.AddWithValue("?ip", v4())
                addcomp.Parameters.AddWithValue("?done", "No")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomp.ExecuteNonQuery()
                con.Close()

test:
                Randomize()

                Dim generated_port As String = CInt(Math.Ceiling(Rnd() * 1023)) + 1

                If generated_port = "8099" Or generated_port = "8085" Or generated_port = "82" Or generated_port = "0" Then
                    GoTo test
                End If

                sql = "SELECT * FROM tbl_computer WHERE imageport=?port"
                Dim compport As New MySqlCommand(sql, con)
                compport.Parameters.AddWithValue("?port", generated_port)
                da = New MySqlDataAdapter(compport)
                da.Fill(ds, "compport")

                If ds.Tables("compport").Rows.Count > 0 Then
                    ds.Tables("compport").Clear()

                    GoTo test
                End If

                ds.Tables("compport").Clear()

                sql = "UPDATE tbl_computer SET imageport=?port WHERE computername=?name AND ipaddress=?ip"
                Dim upport As New MySqlCommand(sql, con)
                upport.Parameters.AddWithValue("?port", generated_port)
                upport.Parameters.AddWithValue("?name", My.Computer.Name)
                upport.Parameters.AddWithValue("?ip", v4())

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upport.ExecuteNonQuery()
                con.Close()

                myport = generated_port

                Try
                    serverThread.Start()
                Catch : End Try

                txtUsername.Text = ""
                txtPassword.Text = ""

                CheckTime.Start()
                CheckCommand.Start()

                Exit Sub
            End If
        End If

        If txtUsername.Text.ToString = My.Settings.defuser.ToString Then
            If txtPassword.Text.ToString = My.Settings.defpass.ToString Then

                '~~> Check if someone is already creating an account
                sql = "SELECT * FROM tbl_oncreate"
                da = New MySqlDataAdapter(sql, con)
                da.Fill(ds, "oncreate")

                If ds.Tables("oncreate").Rows(0).Item("onCreate") = "Yes" Then
                    '~~> Someone is creating an account
                    ds.Tables("oncreate").Clear()

                    If My.Settings.lastip = v4() Then
                        GoTo def
                    End If

                    message = "Someone is already creating an account.. Please wait while it's done"
                    MsgBox("Someone is already creating an account.. Please wait while it's done", MsgBoxStyle.Information, "Login Account")

                    Exit Sub
                End If

                If isOnline = True Then
                    '~~> Someone is online

                    If My.Settings.lastip = v4() Then
                        GoTo def
                    End If

                    message = "There was already a server on the Network"
                    MsgBox("There was already a server on the Network", MsgBoxStyle.Information, "Login Account")

                    Exit Sub
                End If

def:
                My.Settings.lastip = v4()
                My.Settings.Save()

                DefaultAccLogin()

                Exit Sub
            End If
        End If

        sql = "SELECT * FROM tbl_account WHERE accountuser=?user AND accountpass=?pass"
        Dim acclog As New MySqlCommand(sql, con)
        acclog.Parameters.AddWithValue("?user", txtUsername.Text)
        acclog.Parameters.AddWithValue("?pass", txtPassword.Text)
        da = New MySqlDataAdapter(acclog)
        da.Fill(ds, "acc")

        If ds.Tables("acc").Rows.Count > 0 Then
            usergender = ds.Tables("acc").Rows(0).Item("gender").ToString
            isTutorial = ds.Tables("acc").Rows(0).Item("isTutorial").ToString

            If isOnline = True Then
                If My.Settings.lastip = v4() Then
                    GoTo skip
                End If

                If lastUsername = txtUsername.Text Then
                    If MsgBox("Your account is already online in different terminal." & vbNewLine & "Do you want to Relogin your Account?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Relogin Account") = MsgBoxResult.Yes Then
skip:
                        sql = "UPDATE tbl_schedule SET status=?sta WHERE accountuser=?user"
                        Dim upsch As New MySqlCommand(sql, con)
                        upsch.Parameters.AddWithValue("?sta", "Offline")
                        upsch.Parameters.AddWithValue("?user", txtUsername.Text)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upsch.ExecuteNonQuery()
                        con.Close()

                        UnblockAll()

                        My.Settings.lastip = v4()
                        My.Settings.Save()

                        SectionSelection()

                        sql = "UPDATE tbl_computer SET wordcall=computername WHERE wordcall='server'"
                        Dim upcoms As New MySqlCommand(sql, con)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcoms.ExecuteNonQuery()
                        con.Close()

                        sql = "UPDATE tbl_computer SET wordcall='server' WHERE computername=?name AND ipaddress=?ip"
                        Dim upservers As New MySqlCommand(sql, con)
                        upservers.Parameters.AddWithValue("?name", My.Computer.Name)
                        upservers.Parameters.AddWithValue("?ip", v4())

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upservers.ExecuteNonQuery()
                        con.Close()

                        isLogin = True

                        If isTutorial = "No" Then
                            If usergender = "Male" Then
                                message = "Welcome Sir... your current section is " & lastmajor & lastyear & lastsection & "... " & lastsubject & "... every " & userday & " from " & userin & " to " & userout
                            Else
                                message = "Welcome Ma'am... your current section is " & lastmajor & lastyear & lastsection & "... " & lastsubject & "... every " & userday & " from " & userin & " to " & userout
                            End If
                        Else
                            If usergender = "Male" Then
                                message = "Welcome Sir"
                            Else
                                message = "Welcome Ma'am"
                            End If
                        End If

                        ds.Tables("acc").Clear()
                    End If

                    Exit Sub
                End If

                message = "Unable to Login your Account.. There was already a server"
                MsgBox("Unable to Login your Account.. There was already a server", MsgBoxStyle.Information, "Login Account")

                Exit Sub
            End If

            UnblockAll()

            My.Settings.lastip = v4()
            My.Settings.Save()

            SectionSelection()

            sql = "UPDATE tbl_computer SET wordcall=computername WHERE wordcall='server'"
            Dim upcom As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcom.ExecuteNonQuery()
            con.Close()

            sql = "UPDATE tbl_computer SET wordcall='server' WHERE computername=?name AND ipaddress=?ip"
            Dim upserver As New MySqlCommand(sql, con)
            upserver.Parameters.AddWithValue("?name", My.Computer.Name)
            upserver.Parameters.AddWithValue("?ip", v4())

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upserver.ExecuteNonQuery()
            con.Close()

            isLogin = True

            If isTutorial = "No" Then
                If ds.Tables("acc").Rows(0).Item("gender").ToString = "Male" Then
                    message = "Welcome Sir... your current section is " & usermajor & useryear & usersection & "... " & usersubject & "... every " & userday & " from " & userin & " to " & userout
                Else
                    message = "Welcome Ma'am... your current section is " & usermajor & useryear & usersection & "... " & usersubject & "... every " & userday & " from " & userin & " to " & userout
                End If
            Else
                If ds.Tables("acc").Rows(0).Item("gender").ToString = "Male" Then
                    message = "Welcome Sir"
                Else
                    message = "Welcome Ma'am"
                End If
            End If

            ds.Tables("acc").Clear()

            Exit Sub
        End If

        '~~> Account is Invalid
        If isOnline = True Then
            message = "Your account is invalid"
            MsgBox("Your account is invalid", MsgBoxStyle.Information, "Login Account")
        Else
            message = "No server detected"
            MsgBox("Unable to Login your Account" & vbNewLine & vbNewLine & "No server detected", MsgBoxStyle.Information, "Login Account")
        End If
    End Sub

    Sub doLogin()
        '~~> Check if the fields are not empty
        If txtUsername.Text = "" Then

            message = "Please enter your Username or Student ID"
            MsgBox("Please enter your Username or Student ID", MsgBoxStyle.Information, "Login Account")

            Exit Sub
        End If

        If txtPassword.Text = "" Then

            message = "Please enter your Password"
            MsgBox("Please enter your Password", MsgBoxStyle.Information, "Login Account")

            Exit Sub
        End If

        CheckForOnline()

        StudentLogin()

        Exit Sub
    End Sub

    Sub DefaultAccLogin()
        If ds.Tables("usercount").Rows.Count = 0 Then
            '~~> No user is online
            '~~> Force to create a user
            nextform = "Create"
            Animation.Tag = "Hide"
            Animation.Start()
        Else
            message = "There was already a server"
        End If
    End Sub

    Private Sub lblLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogin.Click
        If Animation.Enabled = False Then
            doLogin()
        End If
    End Sub

    Private Sub lblLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogin.MouseLeave
        lblLogin.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblLogin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLogin.MouseMove
        lblLogin.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChangePassword.Click
        ChangePasswordPanel.Visible = True
        StudentPanel.Visible = False
    End Sub

    Private Sub lblChangePassword_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblChangePassword.MouseLeave
        lblChangePassword.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblChangePassword_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblChangePassword.MouseMove
        lblChangePassword.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogout.Click
        If MsgBox("Are you sure you want to Logout your Account?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Logout Account") = MsgBoxResult.Yes Then
            CheckTime.Stop()

            If lblTime.Text = "00:00:00" Then
                sql = "DELETE FROM tbl_login WHERE pcname=?name"
                Dim dellogin As New MySqlCommand(sql, con)
                dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                dellogin.ExecuteNonQuery()
                con.Close()

                GoTo logout
            End If

            lblTime.Text = "00:00:00"

            For a = 1 To applist.Count
                Dim appname() As String = applist(a - 1).Split("\")

                Dim process As System.Diagnostics.Process = Nothing
                Dim psi As New ProcessStartInfo
                psi.UseShellExecute = True
                psi.WindowStyle = ProcessWindowStyle.Hidden
                psi.FileName = "taskkill.exe"
                psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                process = System.Diagnostics.Process.Start(psi)
            Next

            applist.Clear()

            Try
                CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
                CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid))

                DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
            Catch ex As Exception
                message = "An error occured while copying the activity"
            End Try

logout:
            sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id"
            Dim upstudent As New MySqlCommand(sql, con)
            upstudent.Parameters.AddWithValue("?id", studentid)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upstudent.ExecuteNonQuery()
            con.Close()

            studentid = ""
            studentlname = ""
            studentfname = ""
            studentmname = ""
            major = ""
            year = ""
            section = ""
            subject = ""
            accountuser = ""

            StudentPanel.Visible = False
            LoginPanel.Visible = True
            ReminderPanel.Visible = False

            txtUsername.Text = ""
            txtPassword.Text = ""

            isLogout = False

            isLogin = False

            isStart = False
            CheckTime.Start()
        End If
    End Sub

    Private Sub lblLogout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogout.MouseLeave
        lblLogout.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblLogout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLogout.MouseMove
        lblLogout.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblShowOld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowOld.Click

    End Sub

    Private Sub lblShowOld_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowOld.MouseDown
        txtOld.PasswordChar = ""
    End Sub

    Private Sub lblShowOld_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowOld.MouseLeave
        lblShowOld.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowOld_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowOld.MouseMove
        lblShowOld.BackColor = Color.FromArgb(0, 64, 102)
    End Sub

    Private Sub lblShowOld_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowOld.MouseUp
        txtOld.PasswordChar = "*"
    End Sub

    Private Sub lblShowNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowNew.Click

    End Sub

    Private Sub lblShowRetype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShowRetype.Click

    End Sub

    Private Sub lblShowNew_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowNew.MouseDown
        txtNew.PasswordChar = ""
    End Sub

    Private Sub lblShowNew_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowNew.MouseLeave
        lblShowNew.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowNew_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowNew.MouseMove
        lblShowNew.BackColor = Color.FromArgb(0, 64, 102)
    End Sub

    Private Sub lblShowNew_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowNew.MouseUp
        txtNew.PasswordChar = "*"
    End Sub

    Private Sub lblShowRetype_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseDown
        txtRetype.PasswordChar = ""
    End Sub

    Private Sub lblShowRetype_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblShowRetype.MouseLeave
        lblShowRetype.BackColor = Color.FromArgb(0, 64, 80)
    End Sub

    Private Sub lblShowRetype_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseMove
        lblShowRetype.BackColor = Color.FromArgb(0, 64, 102)
    End Sub

    Private Sub lblShowRetype_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShowRetype.MouseUp
        txtRetype.PasswordChar = "*"
    End Sub

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        txtOld.Text = ""
        txtNew.Text = ""
        txtRetype.Text = ""
        ChangePasswordPanel.Visible = False
        StudentPanel.Visible = True
    End Sub

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click
        ChangePassword()
    End Sub

    Sub ChangePassword()
        If txtOld.Text = studentpass Then
            If txtNew.Text = txtRetype.Text Then
                studentpass = txtNew.Text
                sql = "UPDATE tbl_student SET studentpass=?pass WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subj AND accountuser=?user"
                Dim uppass As New MySqlCommand(sql, con)
                uppass.Parameters.AddWithValue("?pass", txtNew.Text)
                uppass.Parameters.AddWithValue("?id", studentid)
                uppass.Parameters.AddWithValue("?major", major)
                uppass.Parameters.AddWithValue("?year", year)
                uppass.Parameters.AddWithValue("?section", section)
                uppass.Parameters.AddWithValue("?subj", subject)
                uppass.Parameters.AddWithValue("?user", accountuser)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                uppass.ExecuteNonQuery()
                con.Close()

                message = "Successfully Updated your Password"
                MsgBox("Successfully Updated your Password", MsgBoxStyle.Information, "Save Password")

                txtOld.Text = ""
                txtNew.Text = ""
                txtRetype.Text = ""
                ChangePasswordPanel.Visible = False
                StudentPanel.Visible = True
            Else
                message = "Passwords do not match"
                MsgBox("Passwords do not match", MsgBoxStyle.Information, "Save Password")
                txtNew.Focus()
            End If
        Else
            message = "Old password is incorrect"
            MsgBox("Old password is incorrect", MsgBoxStyle.Information, "Save Password")
            txtOld.Focus()
        End If
    End Sub

    Private Sub lblSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSave.MouseLeave
        lblSave.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSave.MouseMove
        lblSave.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Dim isExecuted As Boolean = False

    Dim isRunning As Boolean = False

    Public sock As New Integer
    Public f As New frmMain
    Public WithEvents S As SocketServer
    Public Yy As String = "|BawaneH|"
    Public Sz As Size
    Public pw As String = "jordan"
    Private Declare Function BlockInput Lib "User32" (ByVal fBlockIt As Boolean) As Boolean
    Public secs As Integer = 0

    Public Function BlockInput() As Long
        BlockInput(True) '~~> Do not allow input when locked
        Return 0
    End Function

    Public Function UnblockInput() As Long
        BlockInput(False) '~~> Allow input when unlocked
        Return 0
    End Function

    Private Sub CheckCommand_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCommand.Tick
        Try
            Dim commandpc As String
            Dim concomm As String

            sql = "SELECT * FROM tbl_commandpc WHERE computername=?name AND ipaddress=?ip"
            Dim comm As New MySqlCommand(sql, con)
            comm.Parameters.AddWithValue("?name", My.Computer.Name)
            comm.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(comm)
            ds.Clear()
            da.Fill(ds, "comm")

            If ds.Tables("comm").Rows.Count > 0 Then
                commandpc = ds.Tables("comm").Rows(0).Item("commandpc").ToString
                concomm = ds.Tables("comm").Rows(0).Item("concommand").ToString

                sql = "DELETE FROM tbl_commandpc WHERE computername=?name AND ipaddress=?ip"
                Dim delcom As New MySqlCommand(sql, con)
                delcom.Parameters.AddWithValue("?name", My.Computer.Name)
                delcom.Parameters.AddWithValue("?ip", v4())

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delcom.ExecuteNonQuery()
                con.Close()

                If isLogin = True Then
                    If LCase(commandpc) = "shutdown" Then
                        System.Diagnostics.Process.Start("shutdown", "-s -f -t 00")
                    ElseIf LCase(commandpc) = "restart" Then
                        System.Diagnostics.Process.Start("shutdown", "-r -f -t 00")
                    ElseIf LCase(commandpc) = "lock" Then
                        Disable.Start()
                    ElseIf LCase(commandpc) = "unlock" Then
                        Disable.Stop()
                        UnblockInput()
                    ElseIf LCase(commandpc) = "start" Then
                        Disable.Start()

                        If frmStudentRegistration.Visible = True Then
                            frmStudentRegistration.Enabled = False

                            GoTo skip
                        End If

                        If StudentPanel.Visible = True Then
                            StudentPanel.Enabled = False
                        ElseIf ChangePasswordPanel.Visible = True Then
                            ChangePasswordPanel.Enabled = False
                        ElseIf LoginPanel.Visible = True Then
                            LoginPanel.Enabled = False
                        End If
skip:
                        CheckTime.Stop()
                        frmStart.Show()
                    ElseIf LCase(commandpc) = "stop" Then
                        Disable.Stop()
                        UnblockInput()

                        frmStart.Animation.Tag = "Hide"
                        frmStart.Animation.Start()

                        If frmStudentRegistration.Visible = True Then
                            frmStudentRegistration.Enabled = True

                            GoTo skips
                        End If

                        If StudentPanel.Visible = True Then
                            StudentPanel.Enabled = True
                        ElseIf ChangePasswordPanel.Visible = True Then
                            ChangePasswordPanel.Enabled = True
                        ElseIf LoginPanel.Visible = True Then
                            LoginPanel.Enabled = True
                        End If
skips:
                        CheckTime.Start()
                    ElseIf LCase(commandpc) = "log-out" Then
                        Instruction.Stop()

                        CheckCommand.Stop()

                        CheckTime.Stop()

                        lblTime.Text = "00:00:00"

                        For a = 1 To applist.Count
                            Dim appname() As String = applist(a - 1).Split("\")

                            Dim process As System.Diagnostics.Process = Nothing
                            Dim psi As New ProcessStartInfo
                            psi.UseShellExecute = True
                            psi.WindowStyle = ProcessWindowStyle.Hidden
                            psi.FileName = "taskkill.exe"
                            psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                            process = System.Diagnostics.Process.Start(psi)
                        Next

                        applist.Clear()

                        Try
                            CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
                            CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid))

                            DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
                        Catch ex As Exception
                            message = "An error occured while copying the activity"
                        End Try

                        If frmWarning.Visible = True Then
                            frmWarning.GetTime.Stop()
                            frmWarning.Animation.Tag = "Hide"
                            frmWarning.Animation.Start()
                        End If

                        sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim deltimer As New MySqlCommand(sql, con)
                        deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        deltimer.Parameters.AddWithValue("?ip", v4())

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        deltimer.ExecuteNonQuery()
                        con.Close()

                        sql = "UPDATE tbl_computer SET actdone='Yes' WHERE computername=?name AND ipaddress=?ip"
                        Dim upcomp As New MySqlCommand(sql, con)
                        upcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                        upcomp.Parameters.AddWithValue("?ip", v4())

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcomp.ExecuteNonQuery()
                        con.Close()

                        sql = "INSERT INTO tbl_attendance VALUES(?studid,?logtime,?pcname,?major,?year,?section,?subject,?user)"
                        Dim addatt As New MySqlCommand(sql, con)
                        addatt.Parameters.AddWithValue("?studid", studentid)
                        addatt.Parameters.AddWithValue("?logtime", Date.Now.ToShortDateString)
                        addatt.Parameters.AddWithValue("?pcname", My.Computer.Name)
                        addatt.Parameters.AddWithValue("?major", major)
                        addatt.Parameters.AddWithValue("?year", year)
                        addatt.Parameters.AddWithValue("?section", section)
                        addatt.Parameters.AddWithValue("?subject", subject)
                        addatt.Parameters.AddWithValue("?user", accountuser)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addatt.ExecuteNonQuery()
                        con.Close()

                        '~~> Delete from tbl_login
                        sql = "DELETE FROM tbl_login WHERE studentid=?id AND pcname=?name"
                        Dim dellogin As New MySqlCommand(sql, con)
                        dellogin.Parameters.AddWithValue("?id", studentid)
                        dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        dellogin.ExecuteNonQuery()
                        con.Close()

                        sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id"
                        Dim upstudent As New MySqlCommand(sql, con)
                        upstudent.Parameters.AddWithValue("?id", studentid)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upstudent.ExecuteNonQuery()
                        con.Close()

                        studentid = ""
                        studentlname = ""
                        studentfname = ""
                        studentmname = ""
                        major = ""
                        year = ""
                        section = ""
                        subject = ""
                        accountuser = ""

                        StudentPanel.Visible = False
                        LoginPanel.Visible = True
                        ReminderPanel.Visible = False

                        txtUsername.Text = ""
                        txtPassword.Text = ""

                        isLogout = False

                        isLogin = False

                        isStart = False
                        CheckTime.Start()

                        CheckCommand.Start()
                    ElseIf LCase(commandpc) = "resend" Then
                        CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
                    ElseIf LCase(commandpc) = "return" Then
                        CopyDirectory("\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid, Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
                    ElseIf LCase(commandpc) = "add" Then
                        Disable.Start()

                        sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim seltimer As New MySqlCommand(sql, con)
                        seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        seltimer.Parameters.AddWithValue("?ip", v4())
                        da = New MySqlDataAdapter(seltimer)
                        ds.Clear()
                        da.Fill(ds, "seltimer")

                        If ds.Tables("seltimer").Rows.Count > 0 Then
                            Exit Sub
                        End If

                        CheckTime.Stop()

                        secs = CInt(concomm)
                        CountDownFrom = TimeSpan.FromSeconds(CInt(concomm))

                        TargetDT = CDate(Date.Now).Add(CountDownFrom)
                        ts = TargetDT.Subtract(DateTime.Now)

                        lblTime.Text = ts.ToString("hh\:mm\:ss")
                    ElseIf LCase(commandpc) = "reset-time" Then
                        CheckTime.Stop()

                        lblTime.Text = "00:00:00"

                        sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim deltimer As New MySqlCommand(sql, con)
                        deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        deltimer.Parameters.AddWithValue("?ip", v4())

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        deltimer.ExecuteNonQuery()
                        con.Close()

                        CheckTime.Start()
                    ElseIf LCase(commandpc) = "start-time" Then
                        Disable.Stop()
                        UnblockInput()

                        sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim seltimer As New MySqlCommand(sql, con)
                        seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        seltimer.Parameters.AddWithValue("?ip", v4())
                        da = New MySqlDataAdapter(seltimer)
                        ds.Clear()
                        da.Fill(ds, "seltimer")

                        If ds.Tables("seltimer").Rows.Count > 0 Then
                            Exit Sub
                        End If

                        If lblTime.Text = "00:00:00" Then
                            Exit Sub
                        End If

                        sql = "INSERT INTO tbl_timer VALUES(?name,?ip,?pcin,?secs,?status)"
                        Dim addtimer As New MySqlCommand(sql, con)
                        addtimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        addtimer.Parameters.AddWithValue("?ip", v4())
                        addtimer.Parameters.AddWithValue("?pcin", Date.Now)
                        addtimer.Parameters.AddWithValue("?secs", secs)
                        addtimer.Parameters.AddWithValue("?status", "Start")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addtimer.ExecuteNonQuery()
                        con.Close()

                        CheckTime.Start()
                    ElseIf LCase(commandpc) = "resume-time" Then
                        Disable.Stop()
                        UnblockInput()

                        sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim seltimer As New MySqlCommand(sql, con)
                        seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        seltimer.Parameters.AddWithValue("?ip", v4())
                        da = New MySqlDataAdapter(seltimer)
                        ds.Clear()
                        da.Fill(ds, "seltimer")

                        If ds.Tables("seltimer").Rows.Count > 0 Then
                            If ds.Tables("seltimer").Rows(0).Item("status") = "Stop" Then
                                sql = "UPDATE tbl_timer SET pcin=?in, status='Start' WHERE computername=?name AND ipaddress=?ip"
                                Dim uptimer As New MySqlCommand(sql, con)
                                uptimer.Parameters.AddWithValue("?in", Date.Now)
                                uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                                uptimer.Parameters.AddWithValue("?ip", v4())

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                uptimer.ExecuteNonQuery()
                                con.Close()
                            End If
                        End If
                    ElseIf LCase(commandpc) = "extend-time" Then
                        sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim seltimer As New MySqlCommand(sql, con)
                        seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        seltimer.Parameters.AddWithValue("?ip", v4())
                        da = New MySqlDataAdapter(seltimer)
                        ds.Clear()
                        da.Fill(ds, "seltimer")

                        If ds.Tables("seltimer").Rows.Count > 0 Then
                            sql = "UPDATE tbl_timer SET pcsec=(pcsec+?extend) WHERE computername=?name AND ipaddress=?ip"
                            Dim uptimer As New MySqlCommand(sql, con)
                            uptimer.Parameters.AddWithValue("?extend", CInt(concomm))
                            uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                            uptimer.Parameters.AddWithValue("?ip", v4())

                            If con.State = ConnectionState.Closed Then
                                con.Open()
                            End If

                            uptimer.ExecuteNonQuery()
                            con.Close()
                        End If
                    ElseIf LCase(commandpc) = "stop-time" Then
                        Disable.Start()

                        sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                        Dim seltimer As New MySqlCommand(sql, con)
                        seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                        seltimer.Parameters.AddWithValue("?ip", v4())
                        da = New MySqlDataAdapter(seltimer)
                        ds.Clear()
                        da.Fill(ds, "seltimer")

                        If ds.Tables("seltimer").Rows.Count > 0 Then
                            If ds.Tables("seltimer").Rows(0).Item("status") = "Start" Then
                                sql = "UPDATE tbl_timer SET pcsec=pcsec-?time, status='Stop' WHERE computername=?name AND ipaddress=?ip"
                                Dim uptimer As New MySqlCommand(sql, con)
                                uptimer.Parameters.AddWithValue("?time", CInt(DateDiff(DateInterval.Second, CDate(ds.Tables("seltimer").Rows(0).Item("pcin").ToString), CDate(Date.Now))))
                                uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                                uptimer.Parameters.AddWithValue("?ip", v4())

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                uptimer.ExecuteNonQuery()
                                con.Close()
                            End If
                        End If
                    ElseIf LCase(commandpc) = "change" Then
                        ChangeSection()
                    Else
                        '~~> Default Path then Configured Path

                        Dim prog As String() = commandpc.Split("|")
                        Dim appinfo As String() = prog(prog.Length - 1).Split("/")

                        If LCase(prog(0)) = "close" Then
                            If prog(2) = "" Then
                                Dim appname() As String = prog(1).Split("\")

                                Dim process As System.Diagnostics.Process = Nothing
                                Dim psi As New ProcessStartInfo
                                psi.UseShellExecute = True
                                psi.WindowStyle = ProcessWindowStyle.Hidden
                                psi.FileName = "taskkill.exe"
                                psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                                process = System.Diagnostics.Process.Start(psi)
                            Else
                                Dim appname() As String = appinfo(0).Split("\")

                                Dim process As System.Diagnostics.Process = Nothing
                                Dim psi As New ProcessStartInfo
                                psi.UseShellExecute = True
                                psi.WindowStyle = ProcessWindowStyle.Hidden
                                psi.FileName = "taskkill.exe"
                                psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                                process = System.Diagnostics.Process.Start(psi)
                            End If
                        Else
                            If lblTime.Text = "00:00:00" Then
                                If frmMenu.Visible = False Then
                                    If frmSpeechRecognition.Visible = False Then
                                        'Exit Sub
                                    End If
                                End If
                            End If

                            Dim sDrive As String, sDrives() As String
                            sDrives = ListAllDrives()

                            Dim appname() As String = prog(1).Split("\")

                            Try
                                If prog(2) = "" Then
                                    Dim apps As String
                                    Dim newpath As String
                                    Dim drive As String
                                    Dim newprog As String

                                    '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                    For a = 1 To sDrives.Length
                                        drive = sDrives(a - 1).ToString

                                        Try
                                            proc.StartInfo.Arguments = Nothing
                                            proc.StartInfo.FileName = drive & prog(1).Substring(3)
                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                            proc.Start()

                                            applist.Add(drive & prog(1).Substring(3))

                                            Exit Sub
                                        Catch : End Try

                                        If InStr("x86", prog(1)) Then
                                            newpath = drive & "Program Files" & prog(1).Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = newpath
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        Else
                                            newpath = drive & prog(1).Substring(3, 13) & prog(1).Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = newpath
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        End If
                                    Next
                                Else
                                    Try
                                        Dim apps As String
                                        Dim newpath As String
                                        Dim drive As String
                                        Dim newprog As String

                                        '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                        For a = 1 To sDrives.Length
                                            drive = sDrives(a - 1).ToString

                                            If InStr("\\", prog(1)) Then
                                                newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                            Else
                                                newprog = prog(1)
                                            End If

                                            Try
                                                proc.StartInfo.Arguments = """" + newprog + """"
                                                proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(drive & appinfo(0).Substring(3))

                                                Exit Sub
                                            Catch : End Try

                                            If InStr("x86", appinfo(0)) Then
                                                newpath = drive & "Program Files" & appinfo(0).Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            Else
                                                newpath = drive & appinfo(0).Substring(3, 13) & appinfo(0).Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            End If
                                        Next
                                    Catch ex As Exception
                                        Try
                                            Dim apps As String
                                            Dim newpath As String
                                            Dim drive As String
                                            Dim newprog As String

                                            '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                            For a = 1 To sDrives.Length
                                                drive = sDrives(a - 1).ToString

                                                If InStr("\\", prog(1)) Then
                                                    newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                Else
                                                    newprog = prog(1)
                                                End If

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(drive & appinfo(1).Substring(3))

                                                    Exit Sub
                                                Catch : End Try

                                                If InStr("x86", appinfo(1)) Then
                                                    newpath = drive & "Program Files" & appinfo(1).Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                Else
                                                    newpath = drive & appinfo(1).Substring(3, 13) & appinfo(1).Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                End If
                                            Next
                                        Catch exs As Exception
                                            message = "The file that you're trying to open doesn't not exist"
                                        End Try
                                    End Try
                                End If
                            Catch ex As Exception
                                Try
                                    If prog(2) = "" Then
                                        Dim apps As String
                                        Dim newpath As String
                                        Dim drive As String

                                        '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                        For a = 1 To sDrives.Length
                                            drive = sDrives(a - 1).ToString

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(drive & concomm.Substring(3))

                                                Exit Sub
                                            Catch : End Try

                                            If InStr("x86", concomm) Then
                                                newpath = drive & "Program Files" & concomm.Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = Nothing
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            Else
                                                newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = Nothing
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            End If
                                        Next
                                    Else
                                        Try
                                            Dim apps As String
                                            Dim newpath As String
                                            Dim drive As String
                                            Dim newprog As String

                                            '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                            For a = 1 To sDrives.Length
                                                drive = sDrives(a - 1).ToString

                                                If InStr("\\", prog(1)) Then
                                                    newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                Else
                                                    newprog = prog(1)
                                                End If

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(drive & concomm.Substring(3))

                                                    Exit Sub
                                                Catch : End Try

                                                If InStr("x86", concomm) Then
                                                    newpath = drive & "Program Files" & concomm.Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                Else
                                                    newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                End If
                                            Next
                                        Catch exs As Exception
                                            Try
                                                Dim apps As String
                                                Dim newpath As String
                                                Dim drive As String
                                                Dim newprog As String

                                                '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                                For a = 1 To sDrives.Length
                                                    drive = sDrives(a - 1).ToString

                                                    If InStr("\\", prog(1)) Then
                                                        newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                    Else
                                                        newprog = drive & prog(1).Substring(3)
                                                    End If

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(drive & concomm.Substring(3))

                                                        Exit Sub
                                                    Catch : End Try

                                                    If InStr("x86", concomm) Then
                                                        newpath = drive & "Program Files" & concomm.Substring(22)

                                                        Try
                                                            proc.StartInfo.Arguments = """" + newprog + """"
                                                            proc.StartInfo.FileName = newpath
                                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                            proc.Start()

                                                            applist.Add(newpath)

                                                            Exit Sub
                                                        Catch : End Try
                                                    Else
                                                        newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                        Try
                                                            proc.StartInfo.Arguments = """" + newprog + """"
                                                            proc.StartInfo.FileName = newpath
                                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                            proc.Start()

                                                            applist.Add(newpath)

                                                            Exit Sub
                                                        Catch : End Try
                                                    End If
                                                Next
                                            Catch : End Try
                                        End Try
                                    End If
                                Catch exs As Exception
                                    message = "The File that you're trying to Open does not exist"
                                End Try
                            End Try
                        End If
                    End If
                Else
                    '~~> List all pending Commands
                    If Not My.Settings.ServerIP = v4() Then
                        If LCase(commandpc) = "start" Then
                            Disable.Start()

                            If StudentPanel.Visible = True Then
                                StudentPanel.Enabled = False
                            ElseIf ChangePasswordPanel.Visible = True Then
                                ChangePasswordPanel.Enabled = False
                            Else
                                LoginPanel.Enabled = False
                            End If

                            CheckTime.Stop()
                            frmStart.Show()
                        ElseIf LCase(commandpc) = "stop" Then
                            Disable.Stop()
                            UnblockInput()

                            frmStart.Animation.Tag = "Hide"
                            frmStart.Animation.Start()

                            If StudentPanel.Visible = True Then
                                StudentPanel.Enabled = True
                            ElseIf ChangePasswordPanel.Visible = True Then
                                ChangePasswordPanel.Enabled = True
                            Else
                                LoginPanel.Enabled = True
                            End If

                            CheckTime.Start()
                        ElseIf LCase(commandpc) = "shutdown" Then
                            System.Diagnostics.Process.Start("shutdown", "-s -f -t 00")
                        ElseIf LCase(commandpc) = "restart" Then
                            System.Diagnostics.Process.Start("shutdown", "-r -f -t 00")
                        ElseIf LCase(commandpc) = "lock" Then
                            Disable.Start()
                        ElseIf LCase(commandpc) = "unlock" Then
                            Disable.Stop()
                            UnblockInput()
                        ElseIf InStr("Open|\\", LCase(commandpc)) Then
                            Dim prog As String() = commandpc.Split("|")
                            Dim appinfo As String() = prog(prog.Length - 1).Split("/")

                            Dim sDrive As String, sDrives() As String
                            sDrives = ListAllDrives()

                            Dim appname() As String = prog(1).Split("\")

                            Try
                                If prog(2) = "" Then
                                    Dim apps As String
                                    Dim newpath As String
                                    Dim drive As String
                                    Dim newprog As String

                                    '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                    For a = 1 To sDrives.Length
                                        drive = sDrives(a - 1).ToString

                                        Try
                                            proc.StartInfo.Arguments = Nothing
                                            proc.StartInfo.FileName = drive & prog(1).Substring(3)
                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                            proc.Start()

                                            applist.Add(drive & prog(1).Substring(3))

                                            Exit Sub
                                        Catch : End Try

                                        If InStr("x86", prog(1)) Then
                                            newpath = drive & "Program Files" & prog(1).Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = newpath
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        Else
                                            newpath = drive & prog(1).Substring(3, 13) & prog(1).Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = newpath
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        End If
                                    Next
                                Else
                                    Try
                                        Dim apps As String
                                        Dim newpath As String
                                        Dim drive As String
                                        Dim newprog As String

                                        '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                        For a = 1 To sDrives.Length
                                            drive = sDrives(a - 1).ToString

                                            If InStr("\\", prog(1)) Then
                                                newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                            Else
                                                newprog = prog(1)
                                            End If

                                            Try
                                                proc.StartInfo.Arguments = """" + newprog + """"
                                                proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(drive & appinfo(0).Substring(3))

                                                Exit Sub
                                            Catch : End Try

                                            If InStr("x86", appinfo(0)) Then
                                                newpath = drive & "Program Files" & appinfo(0).Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            Else
                                                newpath = drive & appinfo(0).Substring(3, 13) & appinfo(0).Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            End If
                                        Next
                                    Catch ex As Exception
                                        Try
                                            Dim apps As String
                                            Dim newpath As String
                                            Dim drive As String
                                            Dim newprog As String

                                            '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                            For a = 1 To sDrives.Length
                                                drive = sDrives(a - 1).ToString

                                                If InStr("\\", prog(1)) Then
                                                    newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                Else
                                                    newprog = prog(1)
                                                End If

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(drive & appinfo(1).Substring(3))

                                                    Exit Sub
                                                Catch : End Try

                                                If InStr("x86", appinfo(1)) Then
                                                    newpath = drive & "Program Files" & appinfo(1).Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                Else
                                                    newpath = drive & appinfo(1).Substring(3, 13) & appinfo(1).Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                End If
                                            Next
                                        Catch exs As Exception
                                            message = "The file that you're trying to open doesn't not exist"
                                        End Try
                                    End Try
                                End If
                            Catch ex As Exception
                                Try
                                    If prog(2) = "" Then
                                        Dim apps As String
                                        Dim newpath As String
                                        Dim drive As String

                                        '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                        For a = 1 To sDrives.Length
                                            drive = sDrives(a - 1).ToString

                                            Try
                                                proc.StartInfo.Arguments = Nothing
                                                proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                proc.Start()

                                                applist.Add(drive & concomm.Substring(3))

                                                Exit Sub
                                            Catch : End Try

                                            If InStr("x86", concomm) Then
                                                newpath = drive & "Program Files" & concomm.Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = Nothing
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            Else
                                                newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                Try
                                                    proc.StartInfo.Arguments = Nothing
                                                    proc.StartInfo.FileName = newpath
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(newpath)

                                                    Exit Sub
                                                Catch : End Try
                                            End If
                                        Next
                                    Else
                                        Try
                                            Dim apps As String
                                            Dim newpath As String
                                            Dim drive As String
                                            Dim newprog As String

                                            '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                            For a = 1 To sDrives.Length
                                                drive = sDrives(a - 1).ToString

                                                If InStr("\\", prog(1)) Then
                                                    newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                Else
                                                    newprog = prog(1)
                                                End If

                                                Try
                                                    proc.StartInfo.Arguments = """" + newprog + """"
                                                    proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                    proc.Start()

                                                    applist.Add(drive & concomm.Substring(3))

                                                    Exit Sub
                                                Catch : End Try

                                                If InStr("x86", concomm) Then
                                                    newpath = drive & "Program Files" & concomm.Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                Else
                                                    newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = newpath
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(newpath)

                                                        Exit Sub
                                                    Catch : End Try
                                                End If
                                            Next
                                        Catch exs As Exception
                                            Try
                                                Dim apps As String
                                                Dim newpath As String
                                                Dim drive As String
                                                Dim newprog As String

                                                '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                                For a = 1 To sDrives.Length
                                                    drive = sDrives(a - 1).ToString

                                                    If InStr("\\", prog(1)) Then
                                                        newprog = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles") & "\" & appname(appname.Length - 1)
                                                    Else
                                                        newprog = drive & prog(1).Substring(3)
                                                    End If

                                                    Try
                                                        proc.StartInfo.Arguments = """" + newprog + """"
                                                        proc.StartInfo.FileName = drive & concomm.Substring(3)
                                                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                        proc.Start()

                                                        applist.Add(drive & concomm.Substring(3))

                                                        Exit Sub
                                                    Catch : End Try

                                                    If InStr("x86", concomm) Then
                                                        newpath = drive & "Program Files" & concomm.Substring(22)

                                                        Try
                                                            proc.StartInfo.Arguments = """" + newprog + """"
                                                            proc.StartInfo.FileName = newpath
                                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                            proc.Start()

                                                            applist.Add(newpath)

                                                            Exit Sub
                                                        Catch : End Try
                                                    Else
                                                        newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                                        Try
                                                            proc.StartInfo.Arguments = """" + newprog + """"
                                                            proc.StartInfo.FileName = newpath
                                                            proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                                                            proc.Start()

                                                            applist.Add(newpath)

                                                            Exit Sub
                                                        Catch : End Try
                                                    End If
                                                Next
                                            Catch : End Try
                                        End Try
                                    End If
                                Catch exs As Exception
                                    message = "The File that you're trying to Open does not exist"
                                End Try
                            End Try
                        Else
                            pendingcommands.Add(commandpc & "%" & concomm)
                        End If
                    End If
                End If
            Else
                If isLogin = True Then
                    If pendingcommands.Count > 0 Then
                        CheckCommand.Stop()

                        For a = 1 To pendingcommands.Count
                            Dim cominfo() As String = pendingcommands(a - 1).ToString.Split("%")

                            DoCommands(cominfo(0), cominfo(1))
                        Next

                        pendingcommands.Clear()
                        CheckCommand.Start()
                    End If
                End If
            End If
        Catch ex As Exception
            CheckCommand.Stop()
            CheckTime.Stop()
            CheckName.Stop()

            message = "Unable to connect to the server"
            MsgBox("Unable to connect to the server", MsgBoxStyle.Information, "Server Connection")

            frmSetServer.ShowDialog()
        End Try
    End Sub

    Dim pendingcommands As New List(Of String)

    Public Function ListAllDrives() As String()
        Dim Drivesarr() As String
        Drivesarr = Directory.GetLogicalDrives()

        Return Drivesarr
    End Function

    Sub ChangeSection()
        sql = "SELECT * FROM tbl_student WHERE studentid=?id AND accountuser=?user"
        Dim selstud As New MySqlCommand(sql, con)
        selstud.Parameters.AddWithValue("?id", studentid)
        selstud.Parameters.AddWithValue("?user", accountuser)
        da = New MySqlDataAdapter(selstud)
        ds.Clear()
        da.Fill(ds, "selstud")

        If ds.Tables("selstud").Rows.Count > 0 Then
            major = ds.Tables("selstud").Rows(0).Item("major").ToString
            year = ds.Tables("selstud").Rows(0).Item("year").ToString
            section = ds.Tables("selstud").Rows(0).Item("section").ToString
            subject = ds.Tables("selstud").Rows(0).Item("subject").ToString
        End If
    End Sub

    Dim proc As Process = New Process
    Dim ts As TimeSpan
    Public TargetDT As DateTime

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo

        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos

            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the method to copy all the nested folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Sub DoCommands(ByVal commandpc As String, ByVal concomm As String)

        If LCase(commandpc) = "shutdown" Then
            System.Diagnostics.Process.Start("shutdown", "-s -f -t 00")
        ElseIf LCase(commandpc) = "restart" Then
            System.Diagnostics.Process.Start("shutdown", "-r -f -t 00")
        ElseIf LCase(commandpc) = "lock" Then
            Disable.Start()
        ElseIf LCase(commandpc) = "unlock" Then
            Disable.Stop()
            UnblockInput()
        ElseIf LCase(commandpc) = "start" Then
            Disable.Start()

            If frmStudentRegistration.Visible = True Then
                frmStudentRegistration.Enabled = False

                GoTo skip
            End If

            If StudentPanel.Visible = True Then
                StudentPanel.Enabled = False
            ElseIf ChangePasswordPanel.Visible = True Then
                ChangePasswordPanel.Enabled = False
            Else
                LoginPanel.Enabled = False
            End If
skip:
            CheckTime.Stop()
            frmStart.Show()
        ElseIf LCase(commandpc) = "stop" Then
            Disable.Stop()
            UnblockInput()

            frmStart.Animation.Tag = "Hide"
            frmStart.Animation.Start()

            If frmStudentRegistration.Visible = True Then
                frmStudentRegistration.Enabled = True

                GoTo skips
            End If

            If StudentPanel.Visible = True Then
                StudentPanel.Enabled = True
            ElseIf ChangePasswordPanel.Visible = True Then
                ChangePasswordPanel.Enabled = True
            Else
                LoginPanel.Enabled = True
            End If
skips:
            CheckTime.Start()
        ElseIf LCase(commandpc) = "log-out" Then
            CheckCommand.Stop()

            CheckTime.Stop()

            lblTime.Text = "00:00:00"

            For a = 1 To applist.Count
                Dim appname() As String = applist(a - 1).Split("\")

                Dim process As System.Diagnostics.Process = Nothing
                Dim psi As New ProcessStartInfo
                psi.UseShellExecute = True
                psi.WindowStyle = ProcessWindowStyle.Hidden
                psi.FileName = "taskkill.exe"
                psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                process = System.Diagnostics.Process.Start(psi)
            Next

            applist.Clear()

            Try
                CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
                CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid))

                DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
            Catch ex As Exception
                message = "An error occured while copying the activity"
            End Try

            If frmWarning.Visible = True Then
                frmWarning.GetTime.Stop()
                frmWarning.Animation.Tag = "Hide"
                frmWarning.Animation.Start()
            End If

            sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim deltimer As New MySqlCommand(sql, con)
            deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            deltimer.Parameters.AddWithValue("?ip", v4())

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            deltimer.ExecuteNonQuery()
            con.Close()

            sql = "UPDATE tbl_computer SET actdone='Yes' WHERE computername=?name AND ipaddress=?ip"
            Dim upcomp As New MySqlCommand(sql, con)
            upcomp.Parameters.AddWithValue("?name", My.Computer.Name)
            upcomp.Parameters.AddWithValue("?ip", v4())

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upcomp.ExecuteNonQuery()
            con.Close()

            sql = "INSERT INTO tbl_attendance VALUES(?studid,?logtime,?pcname,?major,?year,?section,?subject,?user)"
            Dim addatt As New MySqlCommand(sql, con)
            addatt.Parameters.AddWithValue("?studid", studentid)
            addatt.Parameters.AddWithValue("?logtime", Date.Now.ToShortDateString)
            addatt.Parameters.AddWithValue("?pcname", My.Computer.Name)
            addatt.Parameters.AddWithValue("?major", major)
            addatt.Parameters.AddWithValue("?year", year)
            addatt.Parameters.AddWithValue("?section", section)
            addatt.Parameters.AddWithValue("?subject", subject)
            addatt.Parameters.AddWithValue("?user", accountuser)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addatt.ExecuteNonQuery()
            con.Close()

            '~~> Delete from tbl_login
            sql = "DELETE FROM tbl_login WHERE studentid=?id AND pcname=?name"
            Dim dellogin As New MySqlCommand(sql, con)
            dellogin.Parameters.AddWithValue("?id", studentid)
            dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            dellogin.ExecuteNonQuery()
            con.Close()

            sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id"
            Dim upstudent As New MySqlCommand(sql, con)
            upstudent.Parameters.AddWithValue("?id", studentid)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upstudent.ExecuteNonQuery()
            con.Close()

            studentid = ""
            studentlname = ""
            studentfname = ""
            studentmname = ""
            major = ""
            year = ""
            section = ""
            subject = ""
            accountuser = ""

            StudentPanel.Visible = False
            LoginPanel.Visible = True
            ReminderPanel.Visible = False

            txtUsername.Text = ""
            txtPassword.Text = ""

            isLogout = False

            isStart = False
            CheckTime.Start()

            CheckCommand.Start()
        ElseIf LCase(commandpc) = "resend" Then
            CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
        ElseIf LCase(commandpc) = "return" Then
            CopyDirectory("\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid, Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
        ElseIf LCase(commandpc) = "add" Then
            Disable.Start()

            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim seltimer As New MySqlCommand(sql, con)
            seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            seltimer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(seltimer)
            ds.Clear()
            da.Fill(ds, "seltimer")

            If ds.Tables("seltimer").Rows.Count > 0 Then
                Exit Sub
            End If

            CheckTime.Stop()

            secs = CInt(concomm)
            CountDownFrom = TimeSpan.FromSeconds(CInt(concomm))

            TargetDT = CDate(Date.Now).Add(CountDownFrom)
            ts = TargetDT.Subtract(DateTime.Now)

            lblTime.Text = ts.ToString("hh\:mm\:ss")
        ElseIf LCase(commandpc) = "reset-time" Then
            CheckTime.Stop()

            lblTime.Text = "00:00:00"

            sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim deltimer As New MySqlCommand(sql, con)
            deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            deltimer.Parameters.AddWithValue("?ip", v4())

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            deltimer.ExecuteNonQuery()
            con.Close()

            CheckTime.Start()
        ElseIf LCase(commandpc) = "start-time" Then
            Disable.Stop()
            UnblockInput()

            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim seltimer As New MySqlCommand(sql, con)
            seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            seltimer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(seltimer)
            ds.Clear()
            da.Fill(ds, "seltimer")

            If ds.Tables("seltimer").Rows.Count > 0 Then
                Exit Sub
            End If

            sql = "INSERT INTO tbl_timer VALUES(?name,?ip,?pcin,?secs,?status)"
            Dim addtimer As New MySqlCommand(sql, con)
            addtimer.Parameters.AddWithValue("?name", My.Computer.Name)
            addtimer.Parameters.AddWithValue("?ip", v4())
            addtimer.Parameters.AddWithValue("?pcin", Date.Now)
            addtimer.Parameters.AddWithValue("?secs", secs)
            addtimer.Parameters.AddWithValue("?status", "Start")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addtimer.ExecuteNonQuery()
            con.Close()

            CheckTime.Start()
        ElseIf LCase(commandpc) = "resume-time" Then
            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim seltimer As New MySqlCommand(sql, con)
            seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            seltimer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(seltimer)
            ds.Clear()
            da.Fill(ds, "seltimer")

            If ds.Tables("seltimer").Rows.Count > 0 Then
                If ds.Tables("seltimer").Rows(0).Item("status") = "Stop" Then
                    sql = "UPDATE tbl_timer SET pcin=?in, status='Start' WHERE computername=?name AND ipaddress=?ip"
                    Dim uptimer As New MySqlCommand(sql, con)
                    uptimer.Parameters.AddWithValue("?in", Date.Now)
                    uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                    uptimer.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    uptimer.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        ElseIf LCase(commandpc) = "extend-time" Then
            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim seltimer As New MySqlCommand(sql, con)
            seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            seltimer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(seltimer)
            ds.Clear()
            da.Fill(ds, "seltimer")

            If ds.Tables("seltimer").Rows.Count > 0 Then
                sql = "UPDATE tbl_timer SET pcsec=(pcsec+?extend) WHERE computername=?name AND ipaddress=?ip"
                Dim uptimer As New MySqlCommand(sql, con)
                uptimer.Parameters.AddWithValue("?extend", CInt(concomm))
                uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                uptimer.Parameters.AddWithValue("?ip", v4())

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                uptimer.ExecuteNonQuery()
                con.Close()
            End If
        ElseIf LCase(commandpc) = "stop-time" Then
            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim seltimer As New MySqlCommand(sql, con)
            seltimer.Parameters.AddWithValue("?name", My.Computer.Name)
            seltimer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(seltimer)
            ds.Clear()
            da.Fill(ds, "seltimer")

            If ds.Tables("seltimer").Rows.Count > 0 Then
                If ds.Tables("seltimer").Rows(0).Item("status") = "Start" Then
                    sql = "UPDATE tbl_timer SET pcsec=pcsec-?time, status='Stop' WHERE computername=?name AND ipaddress=?ip"
                    Dim uptimer As New MySqlCommand(sql, con)
                    uptimer.Parameters.AddWithValue("?time", CInt(DateDiff(DateInterval.Second, CDate(ds.Tables("seltimer").Rows(0).Item("pcin").ToString), CDate(Date.Now))))
                    uptimer.Parameters.AddWithValue("?name", My.Computer.Name)
                    uptimer.Parameters.AddWithValue("?ip", v4())

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    uptimer.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        ElseIf LCase(commandpc) = "change" Then
            ChangeSection()
        Else
            '~~> Default Path then Configured Path

            Dim prog As String() = commandpc.Split("|")
            Dim appinfo As String() = prog(prog.Length - 1).Split("/")

            If LCase(prog(0)) = "close" Then
                If prog(2) = "" Then
                    Dim appname() As String = concomm.Split("\")

                    Dim process As System.Diagnostics.Process = Nothing
                    Dim psi As New ProcessStartInfo
                    psi.UseShellExecute = True
                    psi.WindowStyle = ProcessWindowStyle.Hidden
                    psi.FileName = "taskkill.exe"
                    psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                    process = System.Diagnostics.Process.Start(psi)
                Else
                    Dim appname() As String = appinfo(0).Split("\")

                    Dim process As System.Diagnostics.Process = Nothing
                    Dim psi As New ProcessStartInfo
                    psi.UseShellExecute = True
                    psi.WindowStyle = ProcessWindowStyle.Hidden
                    psi.FileName = "taskkill.exe"
                    psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                    process = System.Diagnostics.Process.Start(psi)
                End If
            Else
                If lblTime.Text = "00:00:00" Then
                    If frmMenu.Visible = False Then
                        If frmSpeechRecognition.Visible = False Then
                            'Exit Sub
                        End If
                    End If
                End If

                Dim sDrive As String, sDrives() As String
                sDrives = ListAllDrives()

                Try
                    If prog(2) = "" Then
                        Dim apps As String
                        Dim newpath As String
                        Dim drive As String

                        '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                        For a = 1 To sDrives.Length
                            drive = sDrives(a - 1).ToString

                            Try
                                proc.StartInfo.Arguments = Nothing
                                proc.StartInfo.FileName = drive & prog(1).Substring(3)
                                proc.Start()

                                applist.Add(drive & prog(1).Substring(3))

                                Exit Sub
                            Catch : End Try

                            If InStr("x86", prog(1)) Then
                                newpath = drive & "Program Files" & prog(1).Substring(22)

                                Try
                                    proc.StartInfo.Arguments = Nothing
                                    proc.StartInfo.FileName = newpath
                                    proc.Start()

                                    applist.Add(newpath)

                                    Exit Sub
                                Catch : End Try
                            Else
                                newpath = drive & prog(1).Substring(3, 13) & prog(1).Substring(22)

                                Try
                                    proc.StartInfo.Arguments = Nothing
                                    proc.StartInfo.FileName = newpath
                                    proc.Start()

                                    applist.Add(newpath)

                                    Exit Sub
                                Catch : End Try
                            End If
                        Next
                    Else
                        Try
                            Dim apps As String
                            Dim newpath As String
                            Dim drive As String

                            '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                            For a = 1 To sDrives.Length
                                drive = sDrives(a - 1).ToString

                                Try
                                    proc.StartInfo.Arguments = """" + drive & prog(1).Substring(3) + """"
                                    proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                    proc.Start()

                                    applist.Add(drive & prog(1).Substring(3))

                                    Exit Sub
                                Catch : End Try

                                If InStr("x86", prog(1)) Then
                                    newpath = drive & "Program Files" & prog(1).Substring(22)

                                    Try
                                        proc.StartInfo.Arguments = """" + newpath + """"
                                        proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                        proc.Start()

                                        applist.Add(newpath)

                                        Exit Sub
                                    Catch : End Try
                                Else
                                    newpath = drive & prog(1).Substring(3, 13) & prog(1).Substring(22)

                                    Try
                                        proc.StartInfo.Arguments = """" + newpath + """"
                                        proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                        proc.Start()

                                        applist.Add(newpath)

                                        Exit Sub
                                    Catch : End Try
                                End If
                            Next
                        Catch ex As Exception
                            Try
                                Dim apps As String
                                Dim newpath As String
                                Dim drive As String

                                '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                For a = 1 To sDrives.Length
                                    drive = sDrives(a - 1).ToString

                                    Try
                                        proc.StartInfo.Arguments = """" + drive & prog(1).Substring(3) + """"
                                        proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                        proc.Start()

                                        applist.Add(drive & prog(1).Substring(3))

                                        Exit Sub
                                    Catch : End Try

                                    If InStr("x86", prog(1)) Then
                                        newpath = drive & "Program Files" & prog(1).Substring(22)

                                        Try
                                            proc.StartInfo.Arguments = """" + newpath + """"
                                            proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                            proc.Start()

                                            applist.Add(newpath)

                                            Exit Sub
                                        Catch : End Try
                                    Else
                                        newpath = drive & prog(1).Substring(3, 13) & prog(1).Substring(22)

                                        Try
                                            proc.StartInfo.Arguments = """" + newpath + """"
                                            proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                            proc.Start()

                                            applist.Add(newpath)

                                            Exit Sub
                                        Catch : End Try
                                    End If
                                Next
                            Catch exs As Exception
                                message = "The file that you're trying to open doesn't not exist"
                            End Try
                        End Try
                    End If
                Catch ex As Exception
                    Try
                        If prog(2) = "" Then
                            Dim apps As String
                            Dim newpath As String
                            Dim drive As String

                            '~~> Try replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                            For a = 1 To sDrives.Length
                                drive = sDrives(a - 1).ToString

                                Try
                                    proc.StartInfo.Arguments = Nothing
                                    proc.StartInfo.FileName = drive & concomm.Substring(3)
                                    proc.Start()

                                    applist.Add(drive & concomm.Substring(3))

                                    Exit Sub
                                Catch : End Try

                                If InStr("x86", concomm) Then
                                    newpath = drive & "Program Files" & concomm.Substring(22)

                                    Try
                                        proc.StartInfo.Arguments = Nothing
                                        proc.StartInfo.FileName = newpath
                                        proc.Start()

                                        applist.Add(newpath)

                                        Exit Sub
                                    Catch : End Try
                                Else
                                    newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                    Try
                                        proc.StartInfo.Arguments = Nothing
                                        proc.StartInfo.FileName = newpath
                                        proc.Start()

                                        applist.Add(newpath)

                                        Exit Sub
                                    Catch : End Try
                                End If
                            Next
                        Else
                            Try
                                Dim apps As String
                                Dim newpath As String
                                Dim drive As String

                                '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                For a = 1 To sDrives.Length
                                    drive = sDrives(a - 1).ToString

                                    Try
                                        proc.StartInfo.Arguments = """" + drive & concomm.Substring(3) + """"
                                        proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                        proc.Start()

                                        applist.Add(drive & concomm.Substring(3))

                                        Exit Sub
                                    Catch : End Try

                                    If InStr("x86", concomm) Then
                                        newpath = drive & "Program Files" & concomm.Substring(22)

                                        Try
                                            proc.StartInfo.Arguments = """" + newpath + """"
                                            proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                            proc.Start()

                                            applist.Add(newpath)

                                            Exit Sub
                                        Catch : End Try
                                    Else
                                        newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                        Try
                                            proc.StartInfo.Arguments = """" + newpath + """"
                                            proc.StartInfo.FileName = drive & appinfo(0).Substring(3)
                                            proc.Start()

                                            applist.Add(newpath)

                                            Exit Sub
                                        Catch : End Try
                                    End If
                                Next
                            Catch exs As Exception
                                Try
                                    Dim apps As String
                                    Dim newpath As String
                                    Dim drive As String

                                    '~~> Try Replacing "Program Files = Program Files (x86)" and vice-versa.. also the drive(s)
                                    For a = 1 To sDrives.Length
                                        drive = sDrives(a - 1).ToString

                                        Try
                                            proc.StartInfo.Arguments = """" + drive & concomm.Substring(3) + """"
                                            proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                            proc.Start()

                                            applist.Add(drive & concomm.Substring(3))

                                            Exit Sub
                                        Catch : End Try

                                        If InStr("x86", concomm) Then
                                            newpath = drive & "Program Files" & concomm.Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = """" + newpath + """"
                                                proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        Else
                                            newpath = drive & concomm.Substring(3, 13) & concomm.Substring(22)

                                            Try
                                                proc.StartInfo.Arguments = """" + newpath + """"
                                                proc.StartInfo.FileName = drive & appinfo(1).Substring(3)
                                                proc.Start()

                                                applist.Add(newpath)

                                                Exit Sub
                                            Catch : End Try
                                        End If
                                    Next
                                Catch : End Try
                            End Try
                        End If
                    Catch exs As Exception
                        message = "The File that you're trying to Open does not exist"
                    End Try
                End Try
            End If
        End If
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        Try
            If Directory.Exists(path) Then
                'Delete all files from the Directory
                For Each filepath As String In Directory.GetFiles(path)
                    File.Delete(filepath)
                Next
                'Delete all child Directories
                For Each dir As String In Directory.GetDirectories(path)
                    DeleteDirectory(dir)
                Next

                If isDeletePath = True Then
                    Directory.Delete(path)
                End If

                isDeletePath = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Dim isDeletePath As Boolean = True
    Dim isStart As Boolean = False
    Dim CountDownFrom As TimeSpan
    Dim isFirst As Boolean = True
    Dim isStop As Boolean = False
    Dim newsec As Integer
    Dim pcin As String
    Dim pcsec As Integer = 0

    Dim applist As New List(Of String)

    Private Sub CheckTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTime.Tick
        Try
            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim timer As New MySqlCommand(sql, con)
            timer.Parameters.AddWithValue("?name", My.Computer.Name)
            timer.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(timer)
            ds.Clear()
            da.Fill(ds, "timer")

            If ds.Tables("timer").Rows.Count > 0 Then
                If ds.Tables("timer").Rows(0).Item("status").ToString = "Stop" Then
                    If Not pcsec = CInt(ds.Tables("timer").Rows(0).Item("pcsec").ToString) Then
                        pcsec = CInt(ds.Tables("timer").Rows(0).Item("pcsec").ToString)

                        CountDownFrom = TimeSpan.FromSeconds(CInt(ds.Tables("timer").Rows(0).Item("pcsec").ToString))

                        TargetDT = CDate(DateTime.Now).Add(CountDownFrom)
                        ts = TargetDT.Subtract(DateTime.Now)

                        lblTime.Text = ts.ToString("hh\:mm\:ss")
                    End If

                    Exit Sub
                Else
                    pcsec = CInt(ds.Tables("timer").Rows(0).Item("pcsec").ToString)

                    CountDownFrom = TimeSpan.FromSeconds(CInt(ds.Tables("timer").Rows(0).Item("pcsec").ToString))

                    TargetDT = CDate(ds.Tables("timer").Rows(0).Item("pcin").ToString).Add(CountDownFrom)
                    ts = TargetDT.Subtract(DateTime.Now)

                    lblTime.Text = ts.ToString("hh\:mm\:ss")
                End If
            Else
                Exit Sub
            End If

            If ts.TotalSeconds > 0 Then
                lblTime.Text = ts.ToString("hh\:mm\:ss")

                If lblTime.Text = "00:05:00" Then
                    message = "You only have 5 minutes left to finish the Activity.. Please make sure to save your work"

                    frmWarning.Show()
                End If
            Else
                Instruction.Stop()

                CheckTime.Stop()

                lblTime.Text = "00:00:00"

                For a = 1 To applist.Count
                    Dim appname() As String = applist(a - 1).Split("\")

                    Dim process As System.Diagnostics.Process = Nothing
                    Dim psi As New ProcessStartInfo
                    psi.UseShellExecute = True
                    psi.WindowStyle = ProcessWindowStyle.Hidden
                    psi.FileName = "taskkill.exe"
                    psi.Arguments = "/F /IM " & appname(appname.Length - 1)
                    process = System.Diagnostics.Process.Start(psi)
                Next

                applist.Clear()

                Try
                    CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), "\\" & My.Settings.ServerIP & "\Activity\" & Today.Month & "-" & Today.Day & "-" & Today.Year & "\" & studentid)
                    CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShareFile", Today.Month & "-" & Today.Day & "-" & Today.Year, studentid))

                    DeleteDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
                Catch ex As Exception
                    message = "An error occured while copying the activity"
                End Try

                If frmWarning.Visible = True Then
                    frmWarning.GetTime.Stop()
                    frmWarning.Animation.Tag = "Hide"
                    frmWarning.Animation.Start()
                End If

                sql = "DELETE FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                Dim deltimer As New MySqlCommand(sql, con)
                deltimer.Parameters.AddWithValue("?name", My.Computer.Name)
                deltimer.Parameters.AddWithValue("?ip", v4())

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                deltimer.ExecuteNonQuery()
                con.Close()

                sql = "UPDATE tbl_computer SET actdone='Yes' WHERE computername=?name AND ipaddress=?ip"
                Dim upcomp As New MySqlCommand(sql, con)
                upcomp.Parameters.AddWithValue("?name", My.Computer.Name)
                upcomp.Parameters.AddWithValue("?ip", v4())

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upcomp.ExecuteNonQuery()
                con.Close()

                Dim loggedid As String

                '~~> Check for logged in account
                sql = "SELECT * FROM tbl_login WHERE pcname=?name"
                Dim login As New MySqlCommand(sql, con)
                login.Parameters.AddWithValue("?name", My.Computer.Name)
                da = New MySqlDataAdapter(login)
                da.Fill(ds, "login")

                If ds.Tables("login").Rows.Count > 0 Then
                    loggedid = ds.Tables("login").Rows(0).Item("studentid").ToString
                Else
                    loggedid = ""
                End If

                sql = "SELECT * FROM tbl_student WHERE studentid=?id AND accountuser=?user AND major=?major AND year=?year AND section=?section AND subject=?subject"
                Dim studlog As New MySqlCommand(sql, con)
                studlog.Parameters.AddWithValue("?id", loggedid)
                studlog.Parameters.AddWithValue("?user", lastUsername)
                studlog.Parameters.AddWithValue("?major", lastmajor)
                studlog.Parameters.AddWithValue("?year", lastyear)
                studlog.Parameters.AddWithValue("?section", lastsection)
                studlog.Parameters.AddWithValue("?subject", lastsubject)
                da = New MySqlDataAdapter(studlog)
                ds.Clear()
                da.Fill(ds, "studs")

                sql = "INSERT INTO tbl_attendance VALUES(?studid,?logtime,?pcname,?major,?year,?section,?subject,?user)"
                Dim addatt As New MySqlCommand(sql, con)
                addatt.Parameters.AddWithValue("?studid", ds.Tables("studs").Rows(0).Item("studentid").ToString)
                addatt.Parameters.AddWithValue("?logtime", Date.Now.ToShortDateString)
                addatt.Parameters.AddWithValue("?pcname", My.Computer.Name)
                addatt.Parameters.AddWithValue("?major", ds.Tables("studs").Rows(0).Item("major").ToString)
                addatt.Parameters.AddWithValue("?year", ds.Tables("studs").Rows(0).Item("year").ToString)
                addatt.Parameters.AddWithValue("?section", ds.Tables("studs").Rows(0).Item("section").ToString)
                addatt.Parameters.AddWithValue("?subject", ds.Tables("studs").Rows(0).Item("subject").ToString)
                addatt.Parameters.AddWithValue("?user", ds.Tables("studs").Rows(0).Item("accountuser").ToString)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addatt.ExecuteNonQuery()
                con.Close()

                '~~> Delete from tbl_login
                sql = "DELETE FROM tbl_login WHERE studentid=?id AND pcname=?name"
                Dim dellogin As New MySqlCommand(sql, con)
                dellogin.Parameters.AddWithValue("?id", ds.Tables("studs").Rows(0).Item("studentid").ToString)
                dellogin.Parameters.AddWithValue("?name", My.Computer.Name)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                dellogin.ExecuteNonQuery()
                con.Close()

                sql = "UPDATE tbl_student SET status='Offline' WHERE studentid=?id"
                Dim upstudent As New MySqlCommand(sql, con)
                upstudent.Parameters.AddWithValue("?id", ds.Tables("studs").Rows(0).Item("studentid").ToString)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upstudent.ExecuteNonQuery()
                con.Close()

                studentid = ""
                studentlname = ""
                studentfname = ""
                studentmname = ""
                major = ""
                year = ""
                section = ""
                subject = ""
                accountuser = ""

                StudentPanel.Visible = False
                LoginPanel.Visible = True
                ReminderPanel.Visible = False

                txtUsername.Text = ""
                txtPassword.Text = ""

                isLogout = False

                isLogin = False

                isStart = False
                CheckTime.Start()
            End If
        Catch ex As Exception
            CheckTime.Stop()
            CheckCommand.Stop()
            CheckName.Stop()

            message = "Unable to connect to the server"
            MsgBox("Unable to connect to the server", MsgBoxStyle.Information, "Server Connection")

            frmSetServer.ShowDialog()
        End Try
    End Sub

    Private Sub lblShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShow.Click

    End Sub

    Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text = "" Then
                txtPassword.Focus()
            Else
                doLogin()
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            doLogin()
        End If
    End Sub

    Public isLogin As Boolean = False

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub lblTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitle.Click

    End Sub

    Private Sub lblTitle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            StopSpeaking()
        Else
            message = "Do you need my Help?"
        End If
    End Sub

    Private Sub txtOld_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOld.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNew.Text = "" Then
                txtNew.Focus()
            Else
                If txtRetype.Text = "" Then
                    txtRetype.Focus()
                Else
                    ChangePassword()
                End If
            End If
        End If
    End Sub

    Private Sub txtOld_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOld.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtOld_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOld.TextChanged

    End Sub

    Private Sub txtNew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNew.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtRetype.Text = "" Then
                txtRetype.Focus()
            Else
                If txtOld.Text = "" Then
                    txtOld.Focus()
                Else
                    ChangePassword()
                End If
            End If
        End If
    End Sub

    Private Sub txtNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNew.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtNew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNew.TextChanged

    End Sub

    Private Sub txtRetype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetype.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtOld.Text = "" Then
                txtOld.Focus()
            Else
                If txtNew.Text = "" Then
                    txtNew.Focus()
                Else
                    ChangePassword()
                End If
            End If
        End If
    End Sub

    Private Sub txtRetype_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetype.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtRetype_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetype.TextChanged

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Public Function Desktop() As Image
        Dim bounds As Rectangle = Nothing
        Dim screenshot As System.Drawing.Bitmap = Nothing
        Dim graph As Graphics = Nothing
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Return screenshot
    End Function

    Sub Bytes2Image(ByVal ImageData As Byte())
        Dim ms As New IO.MemoryStream

        ms.Write(ImageData, 0, ImageData.Length)
        PictureBox1.Image = System.Drawing.Image.FromStream(ms)

        ms.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Instruction.Start()

        'Dim ms = New MemoryStream()
        '// Save to memory using the Jpeg format
        'bmp.Save (ms, ImageFormat.Jpeg);

        '// read to end
        'byte[] bmpBytes = ms.GetBuffer();
        'bmp.Dispose();
        'ms.Close();

        Exit Sub

        Dim bmp As Bitmap = Desktop()
        Dim pf As Drawing.Imaging.PixelFormat = bmp.PixelFormat
        Dim sz As Size = bmp.Size
        Dim rct As New Rectangle(New Point(0, 0), sz)
        Dim bmd As Imaging.BitmapData = bmp.LockBits(rct, Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat)
        Dim stride As Integer = bmd.Stride
        Dim totalbytes As Integer = stride * sz.Height
        Dim bytes(totalbytes - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(bmd.Scan0, bytes, 0, totalbytes)
        bmp.UnlockBits(bmd)
        bmp.Dispose()

        Dim bmp2 As New Bitmap(sz.Width, sz.Height, pf)
        bmd = bmp2.LockBits(rct, Imaging.ImageLockMode.WriteOnly, pf)
        System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bmd.Scan0, bytes.Length)
        bmp2.UnlockBits(bmd)

        'look at the result
        PictureBox1.Image = bmp2

        Exit Sub

        sql = "INSERT INTO tbl_screensharing VALUES(?image)"
        Dim addimage As New MySqlCommand(sql, con)
        addimage.Parameters.AddWithValue("?image", Desktop())

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        addimage.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Dim disablecount As Integer = 0

    Private Sub Disable_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Disable.Tick
        BlockInput()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        frmStart.Show()

        Exit Sub

        sql = "SELECT * FROM tbl_screensharing"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "ss")

        If ds.Tables("ss").Rows.Count > 0 Then
            Dim image As Byte() = DirectCast(ds.Tables("ss").Rows(0).Item("image"), Byte())

            Bytes2Image(image)
        End If
    End Sub

    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()

tryagain:

        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            GoTo tryagain
        End Try

        Return Stream.ToArray()
    End Function

    Private Sub StudentPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StudentPanel.Paint

    End Sub

    Private Sub LoginPanel_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginPanel.VisibleChanged
        If LoginPanel.Visible = True Then
            lblTitle.Text = "Account Login"
            lblDescription.Text = "Enter your username and/or Password to continue . . ."
        ElseIf LoginPanel.Visible = False Then
            lblTitle.Text = "Student Account"
            lblDescription.Text = "You are currently Logged In as Student"
        End If
    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        sql = "SELECT * FROM tbl_login WHERE pcname=?name"
        Dim sellogin As New MySqlCommand(sql, con)
        sellogin.Parameters.AddWithValue("?name", My.Computer.Name)
        da = New MySqlDataAdapter(sellogin)
        ds.Clear()
        da.Fill(ds, "login")

        If ds.Tables("login").Rows.Count > 0 Then
            MsgBox(ds.Tables("login").Rows(0).Item("studentid").ToString)
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CheckName_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckName.Tick
        Try
            sql = "SELECT * FROM tbl_computer WHERE computername=?name AND ipaddress=?ip"
            Dim selcompname As New MySqlCommand(sql, con)
            selcompname.Parameters.AddWithValue("?name", My.Computer.Name)
            selcompname.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(selcompname)
            da.Fill(ds, "selcompname")

            If ds.Tables("selcompname").Rows.Count > 0 Then
                lblPCName.Text = UCase(ds.Tables("selcompname").Rows(0).Item("wordcall").ToString)

                ds.Tables("selcompname").Clear()
            End If
        Catch ex As Exception
            CheckCommand.Stop()
            CheckTime.Stop()
            CheckName.Stop()

            message = "Unable to connect to the server"
            MsgBox("Unable to connect to the server", MsgBoxStyle.Information, "Server Connection")

            frmSetServer.ShowDialog()
        End Try
    End Sub

    Dim lockcount As Integer = 10000
    Dim isCtrlAltDelete As Boolean = False

    Private Sub Instruction_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Instruction.Tick
        
    End Sub

End Class