Imports MySql.Data.MySqlClient
Imports System.Net.Sockets
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.IO

Public Class frmAlternative

    Private Sub frmAlternative_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public compwordcall, compipaddress, compname, action, variable, defpath, conpath, apptype As String
    Public studentid, studentname, isDone As String

    Sub LoadComputers()
        lvComputer.Items.Clear()
        lvAction.Items.Clear()
        lvVariable.Items.Clear()
        lblCommand.Text = ""
        compwordcall = ""

        sql = "SELECT * FROM tbl_computer"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "pclist")
        'joshua
        da.Fill(dtComputers)
        '/joshua
        If ds.Tables("pclist").Rows.Count > 0 Then
            lvComputer.Items.Add("All")
            lvComputer.Items(0).SubItems.Add("")
            lvComputer.Items(0).SubItems.Add("")
            lvComputer.Items(0).SubItems.Add("")

            For a = 1 To ds.Tables("pclist").Rows.Count
                Dim lv As ListViewItem = lvComputer.Items.Add(ds.Tables("pclist").Rows(a - 1).Item("wordcall").ToString)
                lv.SubItems.Add(ds.Tables("pclist").Rows(a - 1).Item("ipaddress").ToString)
                lv.SubItems.Add(ds.Tables("pclist").Rows(a - 1).Item("computername").ToString)
                lv.SubItems.Add(ds.Tables("pclist").Rows(a - 1).Item("actDone").ToString)
            Next
        End If
    End Sub

    Dim clientcommand As String() = {"Unlock", "Lock", "Open", "Close", "Shutdown", "Restart", "Open-Shared", "Copy", "Send", "Start", "Stop", "Resume", "Reset", "Logout", "Receive"}
    Dim servercommand As String() = {"Open", "Close"}

    Sub LoadActions()
        lvAction.Items.Clear()
        action = ""

        Try
            If compwordcall = "All" Then
                For Each value In clientcommand
                    lvAction.Items.Add(value)
                Next
            Else
                If compipaddress = v4() Then
                    For Each value In servercommand
                        lvAction.Items.Add(value)
                    Next
                Else
                    For Each value In clientcommand
                        lvAction.Items.Add(value)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Action")
        End Try
    End Sub

    Sub LoadVariables()
        lvVariable.Items.Clear()
        variable = ""

        Try
            If LCase(action) = "open" Or LCase(action) = "close" Then
                If compname = My.Computer.Name Or compname = "" Then
                    sql = "SELECT * FROM tbl_application WHERE accountuser=?username OR accountuser=?user"
                    Dim applist As New MySqlCommand(sql, con)
                    applist.Parameters.AddWithValue("?username", frmMenu.username)
                    applist.Parameters.AddWithValue("?user", "")

                    da = New MySqlDataAdapter(applist)
                    ds.Clear()
                    da.Fill(ds, "apps")

                    If ds.Tables("apps").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("apps").Rows.Count
                            Dim lv As ListViewItem = lvVariable.Items.Add(ds.Tables("apps").Rows(a - 1).Item("wordcall").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("defpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("conpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("apptype").ToString)
                        Next
                    End If

                    sql = "SELECT * FROM tbl_apptype"
                    Dim apptypelist As New MySqlCommand(sql, con)
                    apptypelist.Parameters.AddWithValue("?user", "")

                    da = New MySqlDataAdapter(apptypelist)
                    ds.Clear()
                    da.Fill(ds, "apptype")

                    If ds.Tables("apptype").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("apptype").Rows.Count
                            Dim lv As ListViewItem = lvVariable.Items.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString)
                            lv.SubItems.Add(ds.Tables("apptype").Rows(a - 1).Item("pathname").ToString)
                            lv.SubItems.Add(ds.Tables("apptype").Rows(a - 1).Item("conpath").ToString)
                            lv.SubItems.Add("")
                        Next
                    End If
                Else
                    sql = "SELECT * FROM tbl_application WHERE accountuser=?user"
                    Dim applist As New MySqlCommand(sql, con)
                    applist.Parameters.AddWithValue("?user", "")

                    da = New MySqlDataAdapter(applist)
                    ds.Clear()
                    da.Fill(ds, "apps")

                    If ds.Tables("apps").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("apps").Rows.Count
                            Dim lv As ListViewItem = lvVariable.Items.Add(ds.Tables("apps").Rows(a - 1).Item("wordcall").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("defpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("conpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("apptype").ToString)
                        Next
                    End If

                    sql = "SELECT * FROM tbl_apptype"
                    Dim apptypelist As New MySqlCommand(sql, con)
                    apptypelist.Parameters.AddWithValue("?user", "")

                    da = New MySqlDataAdapter(apptypelist)
                    ds.Clear()
                    da.Fill(ds, "apptype")

                    If ds.Tables("apptype").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("apptype").Rows.Count
                            Dim lv As ListViewItem = lvVariable.Items.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString)
                            lv.SubItems.Add(ds.Tables("apptype").Rows(a - 1).Item("pathname").ToString)
                            lv.SubItems.Add(ds.Tables("apptype").Rows(a - 1).Item("conpath").ToString)
                            lv.SubItems.Add("")
                        Next
                    End If
                End If
            ElseIf LCase(action) = "copy" Or LCase(action) = "open-shared" Then
                If Not compname = My.Computer.Name Then
                    sql = "SELECT * FROM tbl_application WHERE accountuser=?user"
                    Dim applist As New MySqlCommand(sql, con)
                    applist.Parameters.AddWithValue("?user", frmMenu.username)

                    da = New MySqlDataAdapter(applist)
                    ds.Clear()
                    da.Fill(ds, "apps")

                    If ds.Tables("apps").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("apps").Rows.Count
                            Dim lv As ListViewItem = lvVariable.Items.Add(ds.Tables("apps").Rows(a - 1).Item("wordcall").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("defpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("conpath").ToString)
                            lv.SubItems.Add(ds.Tables("apps").Rows(a - 1).Item("apptype").ToString)
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Variable")
        End Try
    End Sub

    Dim isFile As Boolean = False

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
                Dim fileinfo() As String = fileSystemInfo.FullName.Split("\")

                If isFile = True Then
                    If fileinfo(fileinfo.Length - 1) = filename Then
                        System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                    End If
                Else
                    System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                End If
            Else
                ' Recursively call the mothod to copy all the nested folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Dim filename As String

    Private Sub lblExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExecute.Click
        If compwordcall = "" Then
            message = "Unable to execute an Incomplete Command"

            Exit Sub
        End If

        If action = "" Then
            message = "Unable to execute an Incomplete Command"

            Exit Sub
        End If

        If variable = "" Then
            message = "Unable to execute an Incomplete Command"

            Exit Sub
        End If

        If compwordcall = "All" Then
            For a = 1 To lvComputer.Items.Count - 1
                If Not lvComputer.Items(a).SubItems(1).Text = v4() Then
                    If action = "Shutdown" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "shutdown")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Restart" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "restart")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Stop" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "stop-time")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Reset" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "reset-time")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Resume" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "resume-time")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Start" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "start-time")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Send" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "resend")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Lock" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Lock")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Logout" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "log-out")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Unlock" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Unlock")
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf LCase(action) = "close" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "close|" & defpath & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf action = "Copy" Then
                        Dim appinfo() As String = defpath.Split("\")
                        filename = appinfo(appinfo.Length - 1)
                        isFile = True

                        Try
                            CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles"), "\\" & lvComputer.Items(a).SubItems(1).Text & "\SendFiles")
                        Catch : End Try

                        message = "File has been copied to all clients"
                    ElseIf action = "Open" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", conpath)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf LCase(action) = "open-shared" Then
                        Dim filename() As String = defpath.Split("\")

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Open|\\" & lvComputer.Items(a).SubItems(1).Text & "\SendFiles\" & filename(filename.Length - 1) & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()

                        message = "Opening Shared " & variable
                    ElseIf LCase(action) = "receive" Then
                        gbReceive.Visible = True
                        lblComputerName.Text = "All Computer"
                        lblWordCall.Visible = False

                        lvComputer.Enabled = False
                        lvAction.Enabled = False
                        lvVariable.Enabled = False

                        Exit Sub
                    End If
                Else
                    If action = "Open" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", conpath)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    ElseIf LCase(action) = "open-shared" Then
                        Dim filename() As String = defpath.Split("\")

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", conpath)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()

                        message = "Opening Shared " & variable
                    ElseIf LCase(action) = "close" Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", lvComputer.Items(a).SubItems(2).Text)
                        addcomm.Parameters.AddWithValue("?ip", lvComputer.Items(a).SubItems(1).Text)
                        addcomm.Parameters.AddWithValue("?command", "close|" & defpath & "|" & apptype)
                        addcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    End If
                End If
            Next
        Else
            If Not compipaddress = v4() Then
                If action = "Shutdown" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "shutdown")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf action = "Send" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "resend")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf action = "Restart" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "restart")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf LCase(action) = "receive" Then
                    gbReceive.Visible = True
                    lblWordCall.Text = compwordcall
                    lblWordCall.Visible = True
                    lblComputerName.Text = compname
                    lblComputerName.Tag = compipaddress

                    lvComputer.Enabled = False
                    lvAction.Enabled = False
                    lvVariable.Enabled = False

                    Exit Sub
                ElseIf action = "Lock" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "lock")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf action = "Copy" Then
                    Dim appinfo() As String = defpath.Split("\")
                    filename = appinfo(appinfo.Length - 1)
                    isFile = True

                    CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles"), "\\" & compipaddress & "\SendFiles")

                    message = "File has been copied to " & compwordcall
                ElseIf LCase(action) = "open-shared" Then
                    Dim filename() As String = defpath.Split("\")

                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "Open|\\" & compipaddress & "\SendFiles\" & filename(filename.Length - 1) & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()

                    message = "Opening Shared " & variable
                ElseIf action = "Unlock" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "unlock")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf action = "Open" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", conpath)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf LCase(action) = "close" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "close|" & defpath & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                End If
            Else
                If action = "Open" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", conpath)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                ElseIf LCase(action) = "open-shared" Then
                    Dim filename() As String = defpath.Split("\")

                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "Open|" & defpath & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", conpath)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()

                    message = "Opening Shared " & variable
                ElseIf LCase(action) = "close" Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", compname)
                    addcomm.Parameters.AddWithValue("?ip", compipaddress)
                    addcomm.Parameters.AddWithValue("?command", "close|" & defpath & "|" & apptype)
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        End If

        LoadComputers()
    End Sub

    Public isCompDone As Boolean = False

    Sub ReceiveActivity()
        If lblComputerName.Text = "All Computer" Then
            For a = 1 To lvComputer.Items.Count
                If Not lvComputer.Items(a).SubItems(1).Text = v4() Then
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", My.Computer.Name)
                    addcomm.Parameters.AddWithValue("?ip", v4())
                    addcomm.Parameters.AddWithValue("?comm", "return")
                    addcomm.Parameters.AddWithValue("?con", "")

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                End If
            Next
        Else
            If Not compipaddress = v4() Then
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", compname)
                addcomm.Parameters.AddWithValue("?ip", compipaddress)
                addcomm.Parameters.AddWithValue("?comm", "return")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub lvComputer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvComputer.Click
        If lvComputer.Items.Count > 0 Then
            compwordcall = lvComputer.FocusedItem.Text
            compipaddress = lvComputer.FocusedItem.SubItems(1).Text
            compname = lvComputer.FocusedItem.SubItems(2).Text

            If lvComputer.FocusedItem.SubItems(3).Text = "Yes" Then
                isCompDone = True
            Else
                isCompDone = False
            End If

            LoadActions()

            lblCommand.Text = compwordcall
            lblDesc.Text = ""
        End If
    End Sub

    Private Sub lvAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAction.Click
        If lvAction.Items.Count > 0 Then
            action = lvAction.FocusedItem.Text

            LoadVariables()

            lvVariable.Height = 220

            If LCase(action) = "open" Or LCase(action) = "close" Then
                lvVariable.Enabled = True
                variable = ""

                lblCommand.Text = compwordcall & " - " & action
                lblDesc.Text = action & " the Selected Application or File from the Server"
            ElseIf LCase(action) = "copy" Or LCase(action) = "open-shared" Then
                lvVariable.Enabled = True
                variable = ""

                lblCommand.Text = compwordcall & " - " & action

                If LCase(action) = "copy" Then
                    lblDesc.Text = "Copy the File from the server to the Student"
                Else
                    lblDesc.Text = "Open the File Shared by the server"
                End If
            ElseIf LCase(action) = "send" Then
                lvVariable.Enabled = False
                variable = "Activity"

                lblCommand.Text = compwordcall & " - " & action & " - " & variable
                lblDesc.Text = "Resend the Activity made by the Student to the Server"
            ElseIf LCase(action) = "receive" Then
                lvVariable.Enabled = False
                variable = "Activity"

                lblCommand.Text = compwordcall & " - " & action & " - " & variable
                lblDesc.Text = "Return the Activity of the Student"
            ElseIf LCase(action) = "start" Or LCase(action) = "stop" Or LCase(action) = "resume" Or LCase(action) = "reset" Then
                lvVariable.Enabled = False
                variable = "Time"

                lblCommand.Text = compwordcall & " - " & action & " - " & variable
                lblDesc.Text = action & " the time of student"
            ElseIf LCase(action) = "logout" Then
                lvVariable.Enabled = False
                variable = "Student"

                lblCommand.Text = compwordcall & " - " & action & " - " & variable
                lblDesc.Text = "Force the Student to Logout and Stop the Activity"
            Else
                lvVariable.Enabled = False
                variable = "Unit"

                lblCommand.Text = compwordcall & " - " & action & " - " & variable
                lblDesc.Text = action & " the computer of the Student"
            End If
        End If
    End Sub

    Private Sub lvAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAction.SelectedIndexChanged

    End Sub

    Private Sub lvVariable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVariable.Click
        If lvVariable.Items.Count > 0 Then
            variable = lvVariable.FocusedItem.Text
            defpath = lvVariable.FocusedItem.SubItems(1).Text
            conpath = lvVariable.FocusedItem.SubItems(2).Text
            apptype = lvVariable.FocusedItem.SubItems(3).Text

            lblCommand.Text = compwordcall & " - " & action & " - " & variable
        End If
    End Sub

    Private Sub lvVariable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvVariable.SelectedIndexChanged

    End Sub

    Dim isSharing As Boolean = False
    'joshua
    Public dtComputers As DataTable = New DataTable()

    '/joshua
    Private Sub lblSSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSSS.Click
        If lblSSS.Text = "Start Screen Sharing" Then
            lblSSS.Text = "Stop Screen Sharing"
            isSharing = True

            frmMenu.isSharing = True

            lblExecute.Enabled = False
            lvAction.Enabled = False
            lvComputer.Enabled = False
            lvVariable.Enabled = False

            For a = 2 To lvComputer.Items.Count
                If lvComputer.Items(a - 1).SubItems(2).Text = My.Computer.Name Then
                    Continue For
                End If

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addsss As New MySqlCommand(sql, con)
                addsss.Parameters.AddWithValue("?name", lvComputer.Items(a - 1).SubItems(2).Text)
                addsss.Parameters.AddWithValue("?ip", lvComputer.Items(a - 1).SubItems(1).Text)
                addsss.Parameters.AddWithValue("?command", "start")
                addsss.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addsss.ExecuteNonQuery()
                con.Close()
            Next

            ScreenSharing.Start()

            message = "Screen Sharing has been enabled. All client computers can now see your current desktop."
        Else
            lblSSS.Text = "Start Screen Sharing"
            isSharing = False

            frmMenu.isSharing = False

            lblExecute.Enabled = True
            lvAction.Enabled = True
            lvComputer.Enabled = True
            lvVariable.Enabled = True

            For a = 2 To lvComputer.Items.Count
                If lvComputer.Items(a - 1).SubItems(2).Text = My.Computer.Name Then
                    Continue For
                End If

                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                Dim addsss As New MySqlCommand(sql, con)
                addsss.Parameters.AddWithValue("?name", lvComputer.Items(a - 1).SubItems(2).Text)
                addsss.Parameters.AddWithValue("?ip", lvComputer.Items(a - 1).SubItems(1).Text)
                addsss.Parameters.AddWithValue("?command", "stop")
                addsss.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addsss.ExecuteNonQuery()
                con.Close()
            Next

            sql = "DELETE FROM tbl_screensharing"
            Dim delss As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            delss.ExecuteNonQuery()
            con.Close()

            ScreenSharing.Stop()

            message = "Screen Sharing has been disabled."
        End If
    End Sub

    Dim start_sending As Thread = New Thread(AddressOf Thread_startSending)

    Dim start As Boolean = True
    Dim client As New TcpClient
    Dim clients As List(Of TcpClient) = New List(Of TcpClient)
    Dim bf As New BinaryFormatter
    Dim nstream As NetworkStream

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

    Private Sub SendImage()
        Try
            ' For a = 2 To lvComputer.Items.Count
            For a = 0 To dtComputers.Rows.Count() - 1

                'If lvComputer.Items(a - 1).SubItems(2).Text = My.Computer.Name Then
                '    Continue For
                'End If
                If dtComputers.Rows(a)("computername").ToString() = My.Computer.Name Then
                    Continue For
                End If

                Dim mclient As TcpClient = New TcpClient()
                Dim image As Image = Desktop()

                Dim nstream As NetworkStream
                mclient.Connect(dtComputers.Rows(a)("ipaddress").ToString(), 8085)
                nstream = mclient.GetStream
                bf.Serialize(nstream, Desktop())
                mclient.Close()
                image.Dispose()
            Next
        Catch ex As Exception
        End Try

        clients.Clear()
    End Sub

    Private Sub Thread_startSending()
        While start

            SendImage()

        End While

        client.Close()
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "closing"
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Private Sub lblExecute_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExecute.MouseLeave
        lblExecute.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblExecute_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblExecute.MouseMove
        lblExecute.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblSSS_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSSS.MouseLeave
        lblSSS.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSSS_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSSS.MouseMove
        lblSSS.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadComputers()

                If frmMenu.isSharing = False Then
                    lblSSS.Text = "Start Screen Sharing"
                Else
                    lblSSS.Text = "Stop Screen Sharing"
                End If
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                frmMenu.isActivate = True
                frmMenu.isTutorial = "No"

                Try
                    frmMenu.menurec.LoadGrammar(grammar2)
                Catch : End Try
                Try
                    frmMenu.menurec.SetInputToDefaultAudioDevice()
                Catch : End Try
                Try
                    frmMenu.menurec.RecognizeAsync(1)
                Catch : End Try

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDescription.Click

    End Sub

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        ReceiveActivity()
    End Sub

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.ForeColor = Color.White
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.ForeColor = Color.LawnGreen
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        gbReceive.Visible = False
        lvComputer.Enabled = True
        lvAction.Enabled = True
        lvVariable.Enabled = True

        Exit Sub
    End Sub

    Private Sub lblCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.MouseLeave
        lblCancel.ForeColor = Color.White
        lblCancel.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblCancel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCancel.MouseMove
        lblCancel.ForeColor = Color.LawnGreen
        lblCancel.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Private Sub ScreenSharing_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenSharing.Tick
        Try
            Dim image As Image = Desktop()
            Dim imageConverter As New ImageConverter()
            Dim imageByte As Byte() = DirectCast(imageConverter.ConvertTo(image, GetType(Byte())), Byte())

            sql = "SELECT * FROM tbl_screensharing"
            da = New MySqlDataAdapter(sql, con)
            ds.Clear()
            da.Fill(ds, "screen")

            If ds.Tables("screen").Rows.Count > 0 Then
                sql = "UPDATE tbl_screensharing SET image=?ss"
                Dim ss As New MySqlCommand(sql, con)
                ss.Parameters.AddWithValue("?ss", imageByte)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                ss.ExecuteNonQuery()
                con.Close()
            Else
                sql = "INSERT INTO tbl_screensharing VALUES(?ss)"
                Dim ss As New MySqlCommand(sql, con)
                ss.Parameters.AddWithValue("?ss", imageByte)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                ss.ExecuteNonQuery()
                con.Close()
            End If
        Catch : End Try
    End Sub

End Class