Imports System.Speech.Synthesis
Imports System.Net.Dns
Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Imports System.Management
Imports System.Management.Instrumentation
Imports System.Security.AccessControl
Imports System
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading

Public Class LOGIN
    'there are two types of users
    Private _student As student
    Private _professor As professor
    Public ReadOnly Property professor() As professor
        Get
            Return Me._professor
        End Get
    End Property
    Public ReadOnly Property student() As student
        Get
            Return Me._student
        End Get
    End Property
    'attributes of the Login form
    Private closeable As Boolean = False
    Private alttabable As Boolean = False
    'needs refactoring
    Public database As database = New database
    Public user_info As DataTable = New DataTable
    Public daysched, timesched, section, subj, username As String
    Public isOnline As Integer = 0
    Public tutorialmode = False
    Private mclient As TcpClient = New TcpClient()
    Private nstream As NetworkStream


    Private bf As BinaryFormatter = New BinaryFormatter

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
    Private start_sending As Thread = New Thread(AddressOf sendimagetoserver)
    Public bool_startsending As Boolean = True
    Public bool_startrecieving As Boolean = True
    Private Sub recieveimagefromserver()
        While bool_startrecieving

        End While
    End Sub
    Private Sub sendimagetoserver()
        While bool_startsending
            'don't send to self
            If My.Settings.server = strategy_localComputer.getIpAddress() Then
                bool_startsending = False
            Else
                Try
                    'MessageBox.Show("start")
                    Dim mclient As TcpClient = New TcpClient()

                    Dim nstream As NetworkStream
                    mclient.Connect(My.Settings.server, myport)
                    'MessageBox.Show("connected")
                    nstream = mclient.GetStream
                    ' MessageBox.Show("getstream")
                    bf.Serialize(nstream, Desktop())
                    ' MessageBox.Show("serializing")
                    mclient.Close()
                    ' MessageBox.Show("close mclient")
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

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click


        Dim username As String = strategy_input.sanitize(txt_username.Text)
        Dim password As String = strategy_input.sanitize(txt_password.Text)
        Dim currentIpAddress As String = strategy_localComputer.getIpAddress()

        'Default login for admin' username: DEFAULT, password: COMMAND
        If My.Settings.default_password = hash(txt_password.Text, 10) And txt_username.Text = "default" Then

            'enable start button
            'Dim OskProcess = New Process()
            'OskProcess.StartInfo.UseShellExecute = True
            'OskProcess.StartInfo.CreateNoWindow = True
            'OskProcess.StartInfo.FileName = "C:\Windows\explorer.exe"
            'OskProcess.StartInfo.WorkingDirectory = Application.StartupPath
            'OskProcess.Start()
            'show Backend for registering new users
            BACKEND.Show()
            Me.Hide()
            txt_password.Text = ""
            txt_username.Text = ""
            Exit Sub
        End If

        'Default login for student' USERNAME student, PASSWORD student
        If txt_password.Text = "student" And txt_username.Text = "student" Then

            'show Default_studet for registering themselves
            DEFAULT_STUDENT.ShowDialog()
            DEFAULT_STUDENT.Dispose()

            txt_password.Text = ""
            txt_username.Text = ""
            Exit Sub
        End If

        'PROFESSOR LOGIN / STUDENT LOGIN version 2 by mark joshua abrenica
        Dim user = New user(username, password)
        If (user.exist) Then
            'get what usertype is user
            Select Case user.UserType
                'student login
                Case user.userTypeEnum.student
                    Me._student = user.getAsStudent()
                    'check if already logged in
                    If (student.IsLoggedIn) Then
                        Dim prompt As prompt = New prompt()
                        prompt.logoutExistingLogin()
                        If (prompt.result = prompt.resultEnum.yes) Then
                            prompt.message("Please wait while system logs you out from previous login")
                            student.logout(student.getLastIpAddress)
                        Else
                            Exit Sub
                        End If

                    End If
                    Me.user_info = student.detailsTable
                    Me.student.login()


                Case user.userTypeEnum.professor
                    Me._professor = user.getAsProfessor()
                    'professor login
                    If (_professor.IsLoggedIn) Then
                        Dim prompt As prompt = New prompt()
                        prompt.logoutExistingLogin()

                        If (prompt.result = prompt.resultEnum.yes) Then
                            prompt.message("Please wait while system logs you out from previous login")
                            _professor.logout(_professor.getLastIpAddress)
                        Else
                            Exit Sub
                        End If

                    End If
                    Me.user_info = professor.detailsTable

                    Me.professor.login()
                    'check the network if each record in there is present, if failed connection, delete that record

            End Select
            ' else if user not found...
        Else

            output.message("Access denied")

        End If
        Dim list_of_textbox As List(Of Control) = New List(Of Control) From {txt_username, txt_password}
        strategy_input.clear(list_of_textbox)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If My.Settings.default_password = hash(txt_password.Text, 10) And txt_username.Text = "default" Then


            closeable = True
            Me.Close()
        Else
            MessageBox.Show("System unlock denied. Wrong default username and password")
        End If

    End Sub

    Private Sub LOGIN_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If closeable = False Then
            e.Cancel = True
            Exit Sub
        End If
        bool_startsending = False
        thread_speaker_active = False
        start_sending.Abort()
        If emergency_setserver.emergency_exit_allow = False Then
            sender_class.send_message("close server", "127.0.0.1")

        End If

        
    End Sub
    Dim thread_speaker As Threading.Thread = New Threading.Thread(AddressOf t_speaker)
    Public thread_speaker_active As Boolean = True
    Public message As String = ""
    Private Sub t_speaker()
        While Me.thread_speaker_active = True
            If message <> "" Then
                'speak
                Dim builder As PromptBuilder = New PromptBuilder()
                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                builder.AppendText(message)
                builder.EndVoice()
                Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                synthesizer.Speak(builder)
                synthesizer.Dispose()
                message = ""
            End If
        End While

    End Sub
    Public listener As listener = New listener
    Public setsection As String = ""
    Public Sub logout()
        Me._student = Nothing
        Me._professor = Nothing

    End Sub
    Public sched_timein As String
    Public sched_day As String
    Public sched_timeout As String
    Private myport As String


    Private Sub LOGIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        'add enter/tab events
        controllers_and_functions.add_enter_events(Me)
        'emergency exit
        If emergency_setserver.emergency_exit_allow = True Then
            Me.Close()
            Exit Sub
        End If
        'shared folder. Raymart's module

        If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Student Activity")) Then
            System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Student Activity"))
        End If

        Try
            Dim PermissionsList As New List(Of SharePermissionEntry)

            'Create a new permission entry for the Everyone group and specify that we want to allow them Read access
            Dim PermEveryone As New SharePermissionEntry(String.Empty, "Everyone", SharedFolder.SharePermissions.Read, True)
            Dim PermUser As New SharePermissionEntry("", "Everyone", SharedFolder.SharePermissions.FullControl, True)

            'Add the two entries declared above to our list
            PermissionsList.Add(PermUser)
            PermissionsList.Add(PermEveryone)

            'Share the folder as "Test Share" and pass in the desired permissions list
            Dim Result As SharedFolder.NET_API_STATUS = _
            SharedFolder.ShareExistingFolder("Student Activity", "This holds the Activity of the Students", Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Student Activity"), PermissionsList)

            Dim FolderPath As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Student Activity") 'Specify the folder here
            Dim UserAccount As String = "Everyone" 'Specify the user here

            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderAcl.RemoveAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderAcl.RemoveAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Delete, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderInfo.SetAccessControl(FolderAcl)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sharing Folder")
        End Try

        'listener thread. mejo mahirap iexplain with just one comment. hehe
        listener.Show()
        Timer1.Start()

        'Disable taskmanager and desktop icons and windows key
        'Dim process As System.Diagnostics.Process = Nothing
        'Dim psi As New ProcessStartInfo
        'psi.UseShellExecute = True
        'psi.FileName = "taskkill.exe"
        'psi.Arguments = "/F /IM explorer.exe"
        'process = System.Diagnostics.Process.Start(psi)

        'set panel to center
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height) / 2

        'enable speaker mode. disable is not yet developed.
        thread_speaker.Start()


        'Send message to system/database that this pc is online. if this pc is server, no need to update system.
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim strIPAddress As String = GetHostByName(strHostName).AddressList(0).ToString()
        Dim my_command As String = "computer_name@" + strHostName + "@" & strIPAddress
        If strIPAddress = My.Settings.server Then
            ' Exit Sub

        End If
        'if this is server, don't send image to server
        If My.Settings.server = strategy_localComputer.getIpAddress() Then
            'recieve images

        Else
            'if this is client, send images to server
        End If

        'if it is already registered, no need to register
        If exist("SELECT COUNT(ID) FROM computers WHERE computername = ? and ipaddress = ?", New ArrayList() From {strHostName, strIPAddress}) Then
            myport = strategy_localComputer.generateImagePort()
            start_sending.Start()

            Exit Sub
        End If
        'Register/update this client to the system if..

        If exist("SELECT COUNT(`computername`) FROM computers WHERE computername = ?", New ArrayList() From {strHostName}) Then
            'update

            database.query2("UPDATE computers SET connected = 'true', ipaddress = ? WHERE computername = ?", New ArrayList() From {strIPAddress, strHostName})
        Else
            'insert
            'if not server

            database.query2("INSERT INTO computers(`computername`,`ipaddress`,`connected`,`word`) VALUES (?,?,?,?)", New ArrayList() From {strHostName, strIPAddress, "yes", strHostName})
            myport = strategy_localComputer.generateImagePort()
            start_sending.Start()

        End If
        Me.setsection = ""
        

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Select Case listener.message1
            Case "time"
                'ending operation for student's activities
                STUDENT_MODULE.endActivity()
                listener.message1 = ""
            Case "open notepad"
                Shell("notepad")
                listener.message1 = ""
            Case "shared desktop"
                lecture.Show()

                listener.message1 = ""
            Case "close lecture"
                lecture.Close()
                listener.message1 = ""
            Case "lock_desktop"
                STUDENT_MODULE.Hide()
                Me.Show()
                STUDENT_MODULE.Close()
                lecture.Close()
                'SEND TO SERVER
                Dim name As String = user_info.Rows(0)("student_name").ToString()
                listener.message1 = ""
            Case "open visual studio"
                For Each drive As String In Directory.GetLogicalDrives()
                    Try
                        Process.Start(drive & "Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe")
                        Exit For
                    Catch ex As Exception

                    End Try
                    Try
                        Process.Start(drive & "Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe")

                        Exit For

                    Catch ex As Exception

                    End Try
                Next
                listener.message1 = ""
            Case "logout professor"
                If IsNothing(_professor) = False Then
                    If Application.OpenForms().OfType(Of DASHBOARD).Any Then
                        DASHBOARD.Close()
                    End If
                    If Application.OpenForms().OfType(Of MY_ACCOUNT).Any Then
                        MY_ACCOUNT.Close()
                    End If

                End If
                'continue here

                _professor = Nothing
                _student = Nothing

                Me.Show()
                listener.message1 = ""
            Case "logout student"

                If IsNothing(_student) = False Then
                    If Application.OpenForms().OfType(Of STUDENT_MODULE).Any Then
                        STUDENT_MODULE.Close()
                    End If
                End If
                'continue here

                _professor = Nothing
                _student = Nothing

                Me.Show()
                listener.message1 = ""
        End Select
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LOGIN_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub txt_password_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_password.KeyDown
        If (e.KeyCode = 15) Then
            btn_login_Click(sender, e)

        End If
    End Sub

    Private Sub txt_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_password.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btn_login_Click(sender, e)

        End If
    End Sub

    Private Sub txt_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password.TextChanged

    End Sub
End Class