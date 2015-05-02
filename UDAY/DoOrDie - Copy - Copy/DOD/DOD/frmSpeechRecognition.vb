Imports MySql.Data.MySqlClient
Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.Net.Sockets
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.IO

Public Class frmSpeechRecognition
    Dim computername, computerip, defword, actword, actpath As String

    Public compip() As String
    Public clientip() As String
    Public conpath() As String
    Public computerlist As String()
    Public clientlist As String()
    Public computerdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public defaultdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public actiondic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public condic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public typedic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public conpip As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public userapp As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public userpath As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public clientactiondic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public clientcondic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public clienttypedic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public clientconpip As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private worddic As New Dictionary(Of String, String)

    Private gr As New GrammarBuilder
    Public Declare Function BringWindowToTop Lib "user32" (ByVal HWnd As IntPtr) As Boolean
    Private builder As PromptBuilder = New PromptBuilder()
    Private synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
    Public WithEvents rec As New System.Speech.Recognition.SpeechRecognitionEngine
    
    Private Sub frmSpeechRecognition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = My.Computer.Screen.Bounds.Height - 150
        Me.TopMost = True

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Dim CommandsList As New List(Of String)
    Dim WordsList As New List(Of String)

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
            For a = 1 To clientip.Length
                Dim mclient As TcpClient = New TcpClient()
                Dim image As Image = Desktop()

                mclient.Connect(clientip(a - 1), 8085)

                nstream = mclient.GetStream
                bf.Serialize(nstream, image)
                mclient.Close()
                image.Dispose()
            Next
        Catch ex As Exception
        End Try

        clients.Clear()
    End Sub

    Private Sub Thread_startSending()
        SendImage()

        Exit Sub

        While start


        End While

        client.Close()
    End Sub

    Public isMode2 As Boolean
    Public compwordcall As String
    Public compcount As Integer

    Sub LoadCommands()
        lvCommands.Items.Clear()

        With lvCommands.Items
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Open")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Open")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Close")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Close")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Copy")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Copy")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Open-Shared")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Open-Shared")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("*application*")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Add")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Add")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Start")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Start")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Resume")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Resume")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Reset")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Reset")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Time")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Reset")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Reset")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Receive")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Receive")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Send")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Send")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Activity")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unlock")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unlock")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Lock")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Lock")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Shutdown")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Shutdown")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Restart")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Restart")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Unit")
            .Add("All")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Logout")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Student")
            .Add("*computer*")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Logout")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Student")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Start")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Typing")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Typing")
            .Add("Start")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Screen")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Sharing")
            .Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Screen")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Sharing")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Listening")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Start")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Listening")
            .Add("Stop")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Voice")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Command")
            .Add("Open")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Student")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Monitoring")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Show")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Commands")
            .Add("Server")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Hide")
            lvCommands.Items(lvCommands.Items.Count - 1).SubItems.Add("Commands")
        End With
    End Sub

    Sub Loadmode1()
        'Try
        isMode2 = False

        LoadCommands()

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadAllGrammars()
        Catch : End Try

        'frmMenu.checknetwork()

        Dim computerschoice As New Choices()
        computerdic = New Dictionary(Of String, String)
        conpip = New Dictionary(Of String, String)

        '~~> Get all the Connected Computers
        sql = "SELECT * FROM tbl_computer"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "pclist")

        If ds.Tables("pclist").Rows.Count > 0 Then
            Array.Resize(computerlist, ds.Tables("pclist").Rows.Count)
            Array.Resize(clientlist, ds.Tables("pclist").Rows.Count - 1)
            Array.Resize(compip, ds.Tables("pclist").Rows.Count)
            Array.Resize(clientip, ds.Tables("pclist").Rows.Count - 1)

            '~~> Get only the already configured computer
            compcount = 0
            For a = 1 To ds.Tables("pclist").Rows.Count
                Try
                    computerschoice.Add(ds.Tables("pclist").Rows(a - 1).Item("wordcall").ToString)
                    computerdic.Add(ds.Tables("pclist").Rows(a - 1).Item("wordcall").ToString, ds.Tables("pclist").Rows(a - 1).Item("computername").ToString)
                    conpip.Add(ds.Tables("pclist").Rows(a - 1).Item("wordcall").ToString, ds.Tables("pclist").Rows(a - 1).Item("ipaddress").ToString)
                    computerlist(a - 1) = ds.Tables("pclist").Rows(a - 1).Item("computername").ToString
                    compip(a - 1) = ds.Tables("pclist").Rows(a - 1).Item("ipaddress").ToString

                    If Not ds.Tables("pclist").Rows(a - 1).Item("computername").ToString = My.Computer.Name Then
                        clientlist(compcount) = ds.Tables("pclist").Rows(a - 1).Item("computername").ToString
                        clientip(compcount) = ds.Tables("pclist").Rows(a - 1).Item("ipaddress").ToString
                        compcount += 1
                    Else
                        compwordcall = ds.Tables("pclist").Rows(a - 1).Item("wordcall").ToString
                    End If
                Catch : End Try
            Next
        End If

        computerschoice.Add("All")
        computerschoice.Add("Open")
        computerdic.Add("All", "")
        computerschoice.Add("Start")
        computerschoice.Add("Stop")
        computerschoice.Add("Server", v4())

        For a = 1 To setalphabet.Length
            Try
                computerschoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                computerschoice.Add(setalphabet(a - 1))
            Catch : End Try
        Next

        defaultdic = New Dictionary(Of String, String)
        Dim defaultschoice As New Choices()

        '~~> List all the Default Keywords for PC Commands
        Dim defstr() As String = {"Open", "Open-Shared", "Send", "Add", "Close", "Shutdown", "Restart", "Lock", "Unlock", "Screen", "Start", "Copy", "Shared", "Stop", "Resume", "Logout", "Reset", "Time", "Receive", "Voice", "Student", "Show", "Hide"}

        For Each def In defstr
            Try
                defaultschoice.Add(def)
            Catch : End Try
        Next

        actiondic = New Dictionary(Of String, String)
        condic = New Dictionary(Of String, String)
        typedic = New Dictionary(Of String, String)
        userapp = New Dictionary(Of String, String)
        userpath = New Dictionary(Of String, String)
        clientactiondic = New Dictionary(Of String, String)
        clientcondic = New Dictionary(Of String, String)
        clienttypedic = New Dictionary(Of String, String)

        Dim actionschoice As New Choices()

        '~~> List all the Actions available including in File Setting
        sql = "SELECT * FROM tbl_application WHERE accountuser=?user OR accountuser=''"
        Dim app As New MySqlCommand(sql, con)
        app.Parameters.AddWithValue("?user", frmMenu.username)

        da = New MySqlDataAdapter(app)
        ds.Clear()
        da.Fill(ds, "app")

        If ds.Tables("app").Rows.Count > 0 Then
            For a = 1 To ds.Tables("app").Rows.Count
                Try
                    actionschoice.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString)
                    actiondic.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString, ds.Tables("app").Rows(a - 1).Item("defpath").ToString)
                    condic.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString, ds.Tables("app").Rows(a - 1).Item("conpath").ToString)
                    typedic.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString, ds.Tables("app").Rows(a - 1).Item("apptype").ToString)

                    If ds.Tables("app").Rows(a - 1).Item("accountuser").ToString = frmMenu.username Then
                        userapp.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString, ds.Tables("app").Rows(a - 1).Item("defpath").ToString)
                        userpath.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString, ds.Tables("app").Rows(a - 1).Item("conpath").ToString)
                    End If
                Catch : End Try
            Next
        End If

        sql = "SELECT * FROM tbl_apptype"
        Dim apptype As New MySqlCommand(sql, con)
        da = New MySqlDataAdapter(apptype)
        ds.Clear()
        da.Fill(ds, "apptype")

        If ds.Tables("apptype").Rows.Count > 0 Then
            For a = 1 To ds.Tables("apptype").Rows.Count
                Try
                    actionschoice.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString)
                    clientactiondic.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString, ds.Tables("apptype").Rows(a - 1).Item("pathname").ToString)
                    clientcondic.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString, ds.Tables("apptype").Rows(a - 1).Item("conpath").ToString)
                    clienttypedic.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString, "")
                Catch : End Try
            Next
        End If

        actionschoice.Add("Unit")
        actionschoice.Add("Sharing")
        actionschoice.Add("Typing")
        actionschoice.Add("Time")
        actionschoice.Add("Activity")
        actionschoice.Add("Student")
        actionschoice.Add("Reset")
        actionschoice.Add("Listening")
        actionschoice.Add("Command")
        actionschoice.Add("Monitoring")
        actionschoice.Add("Commands")

        gr = New GrammarBuilder

        gr.Append(computerschoice)
        gr.Append(defaultschoice)
        gr.Append(actionschoice)

        Dim mygram As New Grammar(gr)

        Try
            rec.LoadGrammar(mygram)
            rec.SetInputToDefaultAudioDevice()
            rec.RecognizeAsync(1)
        Catch : End Try

        lblTyping.Visible = False
        lblFeedback.Text = ""
    End Sub

    Dim wordchoice As New Choices()

    Sub LoadMode2()
        'Try
        isMode2 = True

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadAllGrammars()
        Catch : End Try

        worddic = New Dictionary(Of String, String)

        '~~> Get all the registered (Enabled) Words
        sql = "SELECT * FROM tbl_word WHERE (accountuser=?user OR accountuser='System') AND avail=?type"
        Dim wordlist As New MySqlCommand(sql, con)
        wordlist.Parameters.AddWithValue("?user", frmMenu.username)
        wordlist.Parameters.AddWithValue("?type", frmMenu.wordtype)

        da = New MySqlDataAdapter(wordlist)
        ds.Clear()
        da.Fill(ds, "wordlist")

        If ds.Tables("wordlist").Rows.Count > 0 Then
            For a = 1 To ds.Tables("wordlist").Rows.Count
                Try
                    wordchoice.Add(ds.Tables("wordlist").Rows(a - 1).Item("wordcall").ToString)
                    worddic.Add(ds.Tables("wordlist").Rows(a - 1).Item("wordcall").ToString, ds.Tables("wordlist").Rows(a - 1).Item("toprint").ToString)
                Catch : End Try
            Next
        End If

        '~~> Get all the registered Keyword And Defauly Keyword
        sql = "SELECT * FROM tbl_keyword WHERE accountuser=?users OR isSystem=?usystem"
        Dim keyswords As New MySqlCommand(sql, con)
        keyswords.Parameters.AddWithValue("?users", frmMenu.username)
        keyswords.Parameters.AddWithValue("?usystem", "Yes")

        da = New MySqlDataAdapter(keyswords)
        ds.Clear()
        da.Fill(ds, "keyswords")

        If ds.Tables("keyswords").Rows.Count > 0 Then
            For a = 1 To ds.Tables("keyswords").Rows.Count
                Try
                    wordchoice.Add(ds.Tables("keyswords").Rows(a - 1).Item("keywordcall").ToString)
                    worddic.Add(ds.Tables("keyswords").Rows(a - 1).Item("keywordcall").ToString, ds.Tables("keyswords").Rows(a - 1).Item("toprint").ToString)
                Catch : End Try
            Next
        End If

        Try
            wordchoice.Add(compwordcall & "-Stop-Typing")
            wordchoice.Add(compwordcall & "-Stop-Listening")
            wordchoice.Add(compwordcall & "-Start-Listening")
            wordchoice.Add(compwordcall & "-Show-Commands")
            wordchoice.Add(compwordcall & "-Hide-Commands")
            wordchoice.Add("Stop-Voice-Command")

            wordchoice.Add("Server-Stop-Typing")
            wordchoice.Add("Server-Stop-Listening")
            wordchoice.Add("Server-Start-Listening")
            wordchoice.Add("Server-Show-Commands")
            wordchoice.Add("Server-Hide-Commands")
        Catch : End Try

        For a = 1 To setalphabet.Length
            Try
                wordchoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                wordchoice.Add(setalphabet(a - 1))
            Catch : End Try
        Next

        Dim gr As New GrammarBuilder

        gr.Append(wordchoice)

        Dim gram As New Grammar(gr)

        Try
            rec.LoadGrammar(gram)
            rec.SetInputToDefaultAudioDevice()
            rec.RecognizeAsync(1)
        Catch : End Try

        lblTyping.Visible = True

        message = "Typing Mode Initiated"

        lblFeedback.Text = ""
        'Catch ex As Exception
        'End Try
    End Sub

    Public start_sending As Thread = New Thread(AddressOf Thread_startSending)
    Dim filename As String
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
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Public isStop As Boolean = False
    Public isMonitor As Boolean = False

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If isStop = False Then
            If isMode2 = False Then
                If e.Result.Text = compwordcall & " Start Typing" Or LCase(e.Result.Text) = "server start typing" Then
                    LoadMode2()

                    Exit Sub
                End If

                If e.Result.Text = compwordcall & " Show Commands" Or LCase(e.Result.Text) = "server show commands" Then
                    message = "Showing"

                    Me.Top = Me.Top - 300
                    Me.Height = 380

                    Exit Sub
                End If

                If e.Result.Text = compwordcall & " Hide Commands" Or LCase(e.Result.Text) = "server hide commands" Then
                    message = "Hiding"

                    Me.Top = Me.Top + 300
                    Me.Height = 80

                    Exit Sub
                End If

                If e.Result.Text = "Stop Voice Command" Then
                    message = "Closing"

                    Try
                        rec.RecognizeAsyncStop()
                        rec.UnloadAllGrammars()
                    Catch : End Try

                    Animation.Tag = "Hide"
                    Animation.Start()

                    Exit Sub
                End If

                If e.Result.Text = compwordcall & " Stop Listening" Or LCase(e.Result.Text) = "server stop listening" Then
                    isStop = True

                    message = "I will wait for your command"

                    Exit Sub
                End If

                If e.Result.Text = "Open Student Monitoring" Then
                    Try
                        rec.RecognizeAsyncStop()
                    Catch : End Try

                    frmMonitoring.nextform = "Speech"
                    frmMonitoring.ShowDialog()
                End If

                If e.Result.Text = "Start Screen Sharing" Then
                    lblFeedback.Text = "Start Screen Sharing"

                    For a = 1 To clientlist.Count
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addsss As New MySqlCommand(sql, con)
                        addsss.Parameters.AddWithValue("?name", clientlist(a - 1))
                        addsss.Parameters.AddWithValue("?ip", clientip(a - 1))
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

                    Exit Sub
                ElseIf e.Result.Text = "Stop Screen Sharing" Then
                    lblFeedback.Text = "Stop Screen Sharing"

                    For a = 1 To clientlist.Count
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                        Dim addsss As New MySqlCommand(sql, con)
                        addsss.Parameters.AddWithValue("?name", clientlist(a - 1))
                        addsss.Parameters.AddWithValue("?ip", clientip(a - 1))
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

                    Exit Sub
                End If

                If computerdic.ContainsKey(e.Result.Words(0).Text) Then
                    If e.Result.Words(0).Text = "All" Then
                        If e.Result.Words(1).Text = "Shutdown" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "shutdown")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Shutting down All Unit"

                                message = "Shutting down All Unit"
                            End If
                        ElseIf e.Result.Words(1).Text = "Add" Then
                            If e.Result.Words(2).Text = "Time" Then
                                Try
                                    rec.RecognizeAsyncStop()
                                Catch : End Try

                                frmAddTime.lblComputer.Text = "All Computer"
                                frmAddTime.lblWordCall.Visible = False
                                frmAddTime.ShowDialog()
                            End If
                        ElseIf e.Result.Words(1).Text = "Logout" Then
                            If e.Result.Words(2).Text = "Student" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "log-out")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Logging Out All Student"

                                message = "Logging Out All Student"
                            End If
                        ElseIf e.Result.Words(1).Text = "Send" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "resend")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Resend Activity"

                                message = "Resending all client's activity"
                            End If
                        ElseIf e.Result.Words(1).Text = "Copy" Then
                            If userapp.ContainsKey(e.Result.Words(2).Text) Then
                                message = "Copying..."

                                Dim appinfo() As String = userapp(e.Result.Words(2).Text).Split("\")
                                filename = appinfo(appinfo.Length - 1)
                                isFile = True

                                For a = 1 To clientlist.Count
                                    Try
                                        CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles"), "\\" & clientip(a - 1) & "\SendFiles")
                                    Catch ex As Exception
                                        Continue For
                                    End Try
                                Next

                                message = "File has been copied to all clients"
                            End If
                        ElseIf e.Result.Words(1).Text = "Receive" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                Try
                                    rec.RecognizeAsyncStop()
                                Catch : End Try

                                frmReceive.lblWordcall.Visible = False
                                frmReceive.lblComputer.Text = "All Computer"
                                frmReceive.ShowDialog()
                            End If
                        ElseIf e.Result.Words(1).Text = "Restart" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "restart")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Restarting All Unit"

                                message = "Restarting All Unit"

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Lock" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "lock")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Locking All Unit"

                                message = "Locking All Unit"

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Unlock" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "unlock")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Unlocking All Unit"

                                message = "Unlocking All Unit"

                                Exit Sub
                            End If
                        ElseIf LCase(e.Result.Words(1).Text) = "start" Then
                            If LCase(e.Result.Words(2).Text) = "time" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "start-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Start Time"

                                message = "Starting All Client's Time"

                                Exit Sub
                            End If
                        ElseIf LCase(e.Result.Words(1).Text) = "reset" Then
                            If LCase(e.Result.Words(2).Text) = "time" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "reset-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Reset Time"

                                message = "Resetting All Client's Time"

                                Exit Sub
                            End If
                        ElseIf LCase(e.Result.Words(1).Text) = "time" Then
                            If LCase(e.Result.Words(2).Text) = "reset" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "reset-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Reset Time"

                                message = "Resetting All Client's Time"

                                Exit Sub
                            End If
                        ElseIf LCase(e.Result.Words(1).Text) = "stop" Then
                            If LCase(e.Result.Words(2).Text) = "time" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "stop-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Stop Time"

                                message = "Stoping All Client's Time"

                                Exit Sub
                            End If
                        ElseIf LCase(e.Result.Words(1).Text) = "resume" Then
                            If LCase(e.Result.Words(2).Text) = "time" Then
                                For a = 1 To clientlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", clientip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "resume-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "All Resume Time"

                                message = "Resuming All Client's Time"

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Open" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                For a = 1 To computerlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "Open|" & actiondic(e.Result.Words(2).Text) & "|" & typedic(e.Result.Words(2).Text))
                                    addcomm.Parameters.AddWithValue("?con", condic(e.Result.Words(2).Text))

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Opening " & e.Result.Words(2).Text

                                message = "Opening " & e.Result.Words(2).Text

                                Exit Sub
                            End If

                            If clientactiondic.ContainsKey(e.Result.Words(2).Text) Then
                                For a = 1 To computerlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "Open|" & clientactiondic(e.Result.Words(2).Text) & "|")
                                    addcomm.Parameters.AddWithValue("?con", clientcondic(e.Result.Words(2).Text))

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Opening " & e.Result.Words(2).Text

                                message = "Opening " & e.Result.Words(2).Text

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Reset" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                For a = 1 To clientlist.Length
                                    sql = "UPDATE tbl_computer SET actdone='No' WHERE computername=?name AND ipaddress=?ip"
                                    Dim updone As New MySqlCommand(sql, con)
                                    updone.Parameters.AddWithValue("?name", clientlist(a - 1))
                                    updone.Parameters.AddWithValue("?ip", clientip(a - 1))

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    updone.ExecuteNonQuery()
                                    con.Close()
                                Next

                                message = "All Activity has been reset"

                                If isVoice = False Then
                                    MsgBox("Reset Activity for All Clients was successful", MsgBoxStyle.Information, "Reset Activity")
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Open-Shared" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                Dim filename() As String = actiondic(e.Result.Words(2).Text).Split("\")

                                For a = 1 To computerlist.Count
                                    If compip(a - 1) = v4() Then
                                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                        Dim addcomm As New MySqlCommand(sql, con)
                                        addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                        addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                        addcomm.Parameters.AddWithValue("?command", "Open|" & actiondic(e.Result.Words(2).Text) & "|" & typedic(e.Result.Words(2).Text))
                                        addcomm.Parameters.AddWithValue("?con", condic(e.Result.Words(2).Text))

                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If

                                        addcomm.ExecuteNonQuery()
                                        con.Close()
                                    Else
                                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                        Dim addcomm As New MySqlCommand(sql, con)
                                        addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                        addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                        addcomm.Parameters.AddWithValue("?command", "Open|\\" & compip(a - 1) & "\SendFiles\" & filename(filename.Length - 1) & "|" & typedic(e.Result.Words(2).Text))
                                        addcomm.Parameters.AddWithValue("?con", "")

                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If

                                        addcomm.ExecuteNonQuery()
                                        con.Close()
                                    End If
                                Next

                                lblFeedback.Text = "Opening Shared " & e.Result.Words(2).Text

                                message = "Opening Shared " & e.Result.Words(2).Text

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Close" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                For a = 1 To computerlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "close|" & actiondic(e.Result.Words(2).Text) & "|" & typedic(e.Result.Words(2).Text))
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Closing " & e.Result.Words(2).Text

                                message = "Closing " & e.Result.Words(2).Text

                                Exit Sub
                            End If

                            If clientactiondic.ContainsKey(e.Result.Words(2).Text) Then
                                For a = 1 To computerlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerlist(a - 1))
                                    addcomm.Parameters.AddWithValue("?ip", compip(a - 1))
                                    addcomm.Parameters.AddWithValue("?command", "close|" & clientactiondic(e.Result.Words(2).Text) & "|" & clienttypedic(e.Result.Words(2).Text))
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Closing " & e.Result.Words(2).Text

                                message = "Closing " & e.Result.Words(2).Text

                                Exit Sub
                            End If
                        End If
                    Else
                        If e.Result.Words(1).Text = "Shutdown" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "shutdown")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    lblFeedback.Text = "Shutting down " & e.Result.Words(0).Text

                                    message = "Shutting down " & e.Result.Words(0).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Add" Then
                            If e.Result.Words(2).Text = "Time" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    Try
                                        rec.RecognizeAsyncStop()
                                    Catch : End Try

                                    frmAddTime.lblComputer.Text = computerdic(e.Result.Words(0).Text)
                                    frmAddTime.lblComputer.Tag = conpip(e.Result.Words(0).Text)
                                    frmAddTime.ShowDialog()
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Copy" Then
                            If userapp.ContainsKey(e.Result.Words(2).Text) Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    message = "Copying..."

                                    Dim appinfo() As String = userapp(e.Result.Words(2).Text).Split("\")
                                    filename = appinfo(appinfo.Length - 1)
                                    isFile = True

                                    CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles"), "\\" & conpip(e.Result.Words(0).Text) & "\SendFiles")

                                    message = "File has been copied to " & e.Result.Words(0).Text
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Open-Shared" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    Dim filename() As String = actiondic(e.Result.Words(2).Text).Split("\")

                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "Open|\\" & conpip(e.Result.Words(0).Text) & "\SendFiles\" & filename(filename.Length - 1) & "|" & typedic(e.Result.Words(2).Text))
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    lblFeedback.Text = "Opening Shared " & e.Result.Words(2).Text

                                    message = "Opening Shared " & e.Result.Words(2).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Send" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "resend")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Resending " & e.Result.Words(0).Text & "'s Activity"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Resending " & e.Result.Words(0).Text & "'s Activity"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Restart" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "restart")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Restarting " & e.Result.Words(0).Text

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Restarting " & e.Result.Words(0).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Receive" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    Try
                                        rec.RecognizeAsyncStop()
                                    Catch : End Try

                                    frmReceive.lblWordcall.Visible = True
                                    frmReceive.lblWordcall.Text = e.Result.Words(0).Text
                                    frmReceive.lblComputer.Text = computerdic(e.Result.Words(0).Text)
                                    frmReceive.lblComputer.Tag = conpip(e.Result.Words(0).Text)
                                    frmReceive.ShowDialog()
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Logout" Then
                            If e.Result.Words(2).Text = "Student" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "log-out")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Logging Out student in " & e.Result.Words(0).Text

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Logging Out student in " & e.Result.Words(0).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Reset" Then
                            If e.Result.Words(2).Text = "Time" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "reset-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Reset " & e.Result.Words(0).Text & "'s Time"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Reset Client's Time"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Time" Then
                            If e.Result.Words(2).Text = "Reset" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "reset-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Reset " & e.Result.Words(0).Text & "'s Time"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Reset Client's Time"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Start" Then
                            If e.Result.Words(2).Text = "Time" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "start-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Starting " & e.Result.Words(0).Text & "'s Time"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Starting Client's Time"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Reset" Then
                            If e.Result.Words(2).Text = "Activity" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "UPDATE tbl_computer SET actDone='No' WHERE computername=?name AND ipaddress=?ip"
                                    Dim updone As New MySqlCommand(sql, con)
                                    updone.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    updone.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    updone.ExecuteNonQuery()
                                    con.Close()

                                    message = "Activity for " & e.Result.Words(0).Text & " has been reset"

                                    lblFeedback.Text = e.Result.Words(0).Text & " Reset Activity"
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Stop" Then
                            If e.Result.Words(2).Text = "Time" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "stop-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Stopping " & e.Result.Words(0).Text & "'s Time"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Stopping Client's Time"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Resume" Then
                            If e.Result.Words(2).Text = "Time" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "resume-time")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    lblFeedback.Text = "Resuming " & e.Result.Words(0).Text & "'s Time"

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    message = "Resuming Client's Time"

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Lock" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "lock")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    lblFeedback.Text = "Locking " & e.Result.Words(0).Text

                                    message = "Locking " & e.Result.Words(0).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Unlock" Then
                            If e.Result.Words(2).Text = "Unit" Then
                                If Not computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "unlock")
                                    addcomm.Parameters.AddWithValue("?con", "")

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()

                                    lblFeedback.Text = "Unlocking " & e.Result.Words(0).Text

                                    message = "Unlocking " & e.Result.Words(0).Text

                                    Exit Sub
                                End If
                            End If
                        ElseIf e.Result.Words(1).Text = "Open" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                Dim addcomm As New MySqlCommand(sql, con)
                                addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?command", "Open|" & actiondic(e.Result.Words(2).Text) & "|" & typedic(e.Result.Words(2).Text))
                                addcomm.Parameters.AddWithValue("?con", condic(e.Result.Words(2).Text))

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                addcomm.ExecuteNonQuery()
                                con.Close()

                                lblFeedback.Text = "Opening " & e.Result.Words(2).Text

                                message = "Opening " & e.Result.Words(2).Text

                                Exit Sub
                            End If

                            If clientactiondic.ContainsKey(e.Result.Words(2).Text) Then
                                For a = 1 To computerlist.Count
                                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                    Dim addcomm As New MySqlCommand(sql, con)
                                    addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                    addcomm.Parameters.AddWithValue("?command", "Open|" & clientactiondic(e.Result.Words(2).Text) & "|")
                                    addcomm.Parameters.AddWithValue("?con", clientcondic(e.Result.Words(2).Text))

                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If

                                    addcomm.ExecuteNonQuery()
                                    con.Close()
                                Next

                                lblFeedback.Text = "Opening " & e.Result.Words(2).Text

                                message = "Opening " & e.Result.Words(2).Text

                                Exit Sub
                            End If
                        ElseIf e.Result.Words(1).Text = "Close" Then
                            If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                Dim addcomm As New MySqlCommand(sql, con)
                                addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?command", "close|" & actiondic(e.Result.Words(2).Text) & "|" & typedic(e.Result.Words(2).Text))
                                addcomm.Parameters.AddWithValue("?con", "")

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                addcomm.ExecuteNonQuery()
                                con.Close()

                                lblFeedback.Text = "Closing " & e.Result.Words(2).Text

                                message = "Closing " & e.Result.Words(2).Text

                                Exit Sub
                            End If

                            If clientactiondic.ContainsKey(e.Result.Words(2).Text) Then
                                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?command,?con)"
                                Dim addcomm As New MySqlCommand(sql, con)
                                addcomm.Parameters.AddWithValue("?name", computerdic(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?ip", conpip(e.Result.Words(0).Text))
                                addcomm.Parameters.AddWithValue("?command", "close|" & clientactiondic(e.Result.Words(2).Text) & "|" & clienttypedic(e.Result.Words(2).Text))
                                addcomm.Parameters.AddWithValue("?con", "")

                                If con.State = ConnectionState.Closed Then
                                    con.Open()
                                End If

                                addcomm.ExecuteNonQuery()
                                con.Close()

                                lblFeedback.Text = "Closing " & e.Result.Words(2).Text

                                message = "Closing " & e.Result.Words(2).Text

                                Exit Sub
                            End If
                        End If
                        End If
                End If
            Else
                If e.Result.Text = compwordcall & "-Stop-Typing" Or LCase(e.Result.Text) = "server-stop-typing" Then
                    Loadmode1()

                    message = "Listening"

                    Exit Sub
                End If

                If e.Result.Text = "Stop-Voice-Command" Then
                    message = "Closing"

                    Try
                        rec.RecognizeAsyncStop()
                        rec.UnloadAllGrammars()
                    Catch : End Try

                    Animation.Tag = "Hide"
                    Animation.Start()

                    Exit Sub
                End If

                If e.Result.Text = compwordcall & "-Stop-Listening" Or LCase(e.Result.Text) = "server-stop-listening" Then
                    isStop = True

                    message = "I will wait for your command"

                    Exit Sub
                End If

                If worddic.ContainsKey(e.Result.Words(0).Text) Then
                    Try
                        SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                        lblFeedback.Text = e.Result.Words(0).Text

                        message = e.Result.Words(0).Text.ToString
                    Catch ex As Exception
                    End Try
                End If
            End If
        Else
            If isMode2 = False Then
                If e.Result.Text = compwordcall & " Start Listening" Or LCase(e.Result.Text) = "server start listening" Then
                    isStop = False

                    message = "Command Mode Initiated"
                ElseIf e.Result.Text = "Stop Voice Command" Then
                    message = "Closing"

                    Try
                        rec.RecognizeAsyncStop()
                        rec.UnloadAllGrammars()
                    Catch : End Try

                    Animation.Tag = "Hide"
                    Animation.Start()

                    Exit Sub
                Else
                    If stopcount = 3 Then
                        message = "I am not listening for any command"

                        lblFeedback.Text = "I am not listening for any command"

                        stopcount = 0
                    Else
                        stopcount += 1
                    End If
                End If
            Else
                If e.Result.Text = compwordcall & "-Start-Listening" Or LCase(e.Result.Text) = "server-start-listening" Then
                    isStop = False

                    message = "Typing Mode Initiated"
                ElseIf e.Result.Text = "Stop-Voice-Command" Then
                    message = "Closing"

                    Try
                        rec.RecognizeAsyncStop()
                        rec.UnloadAllGrammars()
                    Catch : End Try

                    Animation.Tag = "Hide"
                    Animation.Start()

                    Exit Sub
                Else
                    If stopcount = 3 Then
                        message = "I am not listening for any command"

                        lblFeedback.Text = "I am not listening for any command"

                        stopcount = 0
                    Else
                        stopcount += 1
                    End If
                End If
            End If
        End If
    End Sub

    Dim stopcount As Integer = 0

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadAllGrammars()
        Catch : End Try

        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 12, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 12, FontStyle.Underline)
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                Loadmode1()

                message = "Listening"
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
            Else
                Animation.Stop()

                frmMenu.isActivate = True
                frmMenu.isTutorial = "No"
                frmMenu.Show()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lblShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShow.Click

    End Sub

    Private Sub Commands_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Commands.Tick
        If Commands.Tag = "Show" Then
            If Me.Height < 330 Then
                Me.Height += 10
                Me.Top -= 10
            ElseIf Me.Height < 380 Then
                Me.Height += 2
                Me.Top -= 2
            Else
                Commands.Stop()

                lblShow.Text = "Hide Commands"
            End If
        Else
            If Me.Height > 130 Then
                Me.Height -= 10
                Me.Top += 10
            ElseIf Me.Height > 80 Then
                Me.Height -= 2
                Me.Top += 2
            Else
                Commands.Stop()

                lblShow.Text = "Show Commands"
            End If
        End If
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