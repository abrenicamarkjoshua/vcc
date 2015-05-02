Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.IO
Imports System.Security.AccessControl
Imports System.Speech.Recognition

Module Connection

    Public con As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As New DataSet
    Public sql As String

    Public thread_speaker As Threading.Thread = New Threading.Thread(AddressOf t_speaker)
    Public thread_speaker_active As Boolean = True
    Public message As String = ""
    Public isCancel As Boolean = False
    Public isVoice As Boolean = False

    Public setalphabet() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "", "p", "q", "", "s", "t", "u", "v", "w", "x", "y"}
    Public voicecommand() As String = {"Voice Alternative", "Network Setting", "Log Out", "Logout Account", "Application Setting", "Keyword Setting", "Word Setting", "My Class", "View Attendance", "View Activity", "Student Monitoring", "Client Timer", "Reset Activity", "My Account", "Change Section", "Start Tutorial", "Logout Account", "Account Setting", "Section Setting", "Timer Setting", "Exit Program"}
    Public members() As String = {"Ray Mart Morandarte", "Joan Kristel Lachica", "Kristine Tolentino", "Lorielyn Pelones", "Ma. Joy Yumang", "Mark Joshua Abrenica", "Jeanel Masbang", "Ma. Judie Balladares", "Carlo Jay Barca", "Jayjay Guiang", "Cynthia Ann Stephanie Bucalan", "Sonnyboy Camacho", "Darwin Duyag", "Regine Emanel", "Junar Frias", "Rhey-an Gilbert Lescano", "Miguel Luis Magat", "Jessica Mae Sotto", "Melmar Usacdin", "Mary Grace Yap"}

    Public builder1 As New GrammarBuilder
    Public builder2 As New GrammarBuilder

    Public firstcommand As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public secondcommand As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Public Function generateImagePort() As String
        'Dim generated_port As String = CInt(Math.Ceiling(Rnd() * 1023)) + 1

        'If generated_port = "8099" Or generated_port = "8085" Or generated_port = "82" Or generated_port = "0" Then
        '    generated_port = CInt(Math.Ceiling(Rnd() * 1023)) + 1
        'End If

        'database.query("UPDATE computers SET imageport = '" & generated_port & "' WHERE ipaddress = '" & getIpAddress() & "'")

        'Do Until database.exist("SELECT COUNT(id) FROM computers WHERE imageport = ? AND ipaddress != '" & getIpAddress() & "'", New ArrayList() From {generated_port}) = False
        '    generated_port = CInt(Math.Ceiling(Rnd() * 1023)) + 1
        '    database.query("UPDATE computers SET imageport = '" & generated_port & "' WHERE ipaddress = '" & getIpAddress() & "'")
        'Loop

        'Return generated_port
    End Function

    Sub CreateDatabase()

    End Sub

    Sub Loadcommands2()
        Dim firstchoice As New Choices()
        Dim secondchoice As New Choices()

        For a = 1 To voicecommand.Length
            Dim commandinfo() As String = LCase(voicecommand(a - 1)).ToString.Split(" ")
            Try
                firstchoice.Add(commandinfo(0))
            Catch : End Try
            Try
                secondchoice.Add(commandinfo(1))
            Catch : End Try
        Next
        For a = 1 To setalphabet.Length
            Try
                firstchoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                secondchoice.Add(setalphabet(a - 1))
            Catch : End Try
        Next

        Try
            firstchoice.Add("all")
        Catch : End Try
        Try
            secondchoice.Add("start-time")
        Catch : End Try
        Try
            secondchoice.Add("stop-time")
        Catch : End Try
        Try
            secondchoice.Add("resume-time")
        Catch : End Try
        Try
            firstchoice.Add("total")
        Catch : End Try
        Try
            secondchoice.Add("total")
        Catch : End Try
        Try
            firstchoice.Add("voice")
        Catch : End Try
        Try
            secondchoice.Add("command")
        Catch : End Try
        Try
            firstchoice.Add("start-voice")
        Catch : End Try
        Try
            secondchoice.Add("voice-command")
        Catch : End Try
        Try
            firstchoice.Add("train")
        Catch : End Try
        Try
            secondchoice.Add("speech")
        Catch : End Try
        Try
            firstchoice.Add("train-speech")
        Catch : End Try
        Try
            secondchoice.Add("speech-engine")
        Catch : End Try
        Try
            secondchoice.Add("engine")
        Catch : End Try

        Try
            firstchoice.Add("students")
        Catch : End Try
        Try
            secondchoice.Add("students")
        Catch : End Try

        Try
            firstchoice.Add("good")
        Catch : End Try
        Try
            secondchoice.Add("morning")
        Catch : End Try
        Try
            secondchoice.Add("afternoon")
        Catch : End Try
        Try
            secondchoice.Add("night")
        Catch : End Try

        Try
            firstchoice.Add("date")
        Catch : End Try
        Try
            secondchoice.Add("date")
        Catch : End Try

        Try
            firstchoice.Add("today")
        Catch : End Try
        Try
            secondchoice.Add("today")
        Catch : End Try
        Try
            firstchoice.Add("tell")
        Catch : End Try
        Try
            secondchoice.Add("time")
        Catch : End Try
        Try
            firstchoice.Add("time")
        Catch : End Try
        Try
            secondchoice.Add("date")
        Catch : End Try
        Try
            secondchoice.Add("up")
        Catch : End Try

        builder2 = New GrammarBuilder
        builder2.Append(firstchoice)
        builder2.Append(secondchoice)

        grammar2 = New Grammar(builder2)
    End Sub

    Public grammarmain As Grammar

    Dim panggulo() As String = {"Health", "Belt", "Chose", "Pose", "Hose", "Had", "Bad", "Dad", "Debit", "Credit", "Eat", "Heat", "Teeth", "Cave", "Behave", "Crave", "State", "Hate", "Plate", "Hansel", "Castle", "Whistle", "Mouse", "House", "Blouse", "Gesture", "Lecture", "Cleavage", "Damage", "Cottage", "Acute", "Parachutte", "Queue", "Chew", "Few", "Tear", "Beer", "Cheer", "Strange", "Orange", "Range", "Session", "Petition", "Education", "Anti", "Anytime", "Everytime", "Ball", "Hall", "Goal", "Traffic", "Pacific", "Aerobic", "Avenue", "New", "Venue", "Text", "Sex", "NLEX", "Hack", "Lock", "Crack", "Headset", "Upset", "Chipset", "Flesh", "Mesh", "Arrange", "Blow-out", "About", "Hand-out", "Fable", "Liable", "Table", "Chewable", "Pebble", "Temple", "Hyper", "Viber", "Lighter", "Material", "Imperial", "Chart", "Mart", "Smart"}

    Sub LoadCommands1()
        Dim firstchoice As New Choices()

        For a = 1 To setalphabet.Length
            Try
                firstchoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-restart-unit")
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-shutdown-unit")
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-lock-unit")
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-unlock-unit")
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-logout-student")
            Catch : End Try
            Try
                firstchoice.Add(setalphabet(a - 1) & "-logout-students")
            Catch : End Try
        Next
        For a = 1 To members.Length
            Dim names() As String = LCase(members(a - 1)).Split(" ")

            For b = 1 To names.Length
                Try
                    firstchoice.Add(names(b - 1))
                Catch : End Try
            Next
        Next
        For a = 1 To panggulo.Length
            Try
                firstchoice.Add(LCase(panggulo(a - 1)))
            Catch : End Try
        Next
        Try
            firstchoice.Add("all-restart-unit")
        Catch : End Try
        Try
            firstchoice.Add("all-shutdown-unit")
        Catch : End Try
        Try
            firstchoice.Add("all-lock-unit")
        Catch : End Try
        Try
            firstchoice.Add("all-unlock-unit")
        Catch : End Try
        Try
            firstchoice.Add("all-logout-students")
        Catch : End Try
        Try
            firstchoice.Add("all-logout-student")
        Catch : End Try
        Try
            firstchoice.Add("add")
        Catch : End Try
        Try
            firstchoice.Add("lock-unit")
        Catch : End Try
        Try
            firstchoice.Add("unlock-unit")
        Catch : End Try
        Try
            firstchoice.Add("shutdown-unit")
        Catch : End Try
        Try
            firstchoice.Add("restart-unit")
        Catch : End Try
        Try
            firstchoice.Add("lock")
        Catch : End Try
        Try
            firstchoice.Add("unlock")
        Catch : End Try
        Try
            firstchoice.Add("shutdown")
        Catch : End Try
        Try
            firstchoice.Add("restart")
        Catch : End Try
        Try
            firstchoice.Add("start")
        Catch : End Try
        Try
            firstchoice.Add("stop")
        Catch : End Try
        Try
            firstchoice.Add("no")
        Catch : End Try
        Try
            firstchoice.Add("help")
        Catch : End Try
        Try
            firstchoice.Add("change")
        Catch : End Try
        Try
            firstchoice.Add("my-sections")
        Catch : End Try
        Try
            firstchoice.Add("sections")
        Catch : End Try
        Try
            firstchoice.Add("my-information")
        Catch : End Try
        Try
            firstchoice.Add("information")
        Catch : End Try
        Try
            firstchoice.Add("yesterday")
        Catch : End Try
        Try
            firstchoice.Add("logout-student")
        Catch : End Try
        Try
            firstchoice.Add("up")
        Catch : End Try
        Try
            firstchoice.Add("export-attendance-and-activity")
        Catch : End Try
        Try
            firstchoice.Add("export")
        Catch : End Try
        Try
            firstchoice.Add("import")
        Catch : End Try
        Try
            firstchoice.Add("down")
        Catch : End Try
        Try
            firstchoice.Add("change")
        Catch : End Try
        Try
            firstchoice.Add("student-activity")
        Catch : End Try
        Try
            firstchoice.Add("clear-activity")
        Catch : End Try
        Try
            firstchoice.Add("activity")
        Catch : End Try
        Try
            firstchoice.Add("total-students")
        Catch : End Try
        Try
            firstchoice.Add("total")
        Catch : End Try
        Try
            firstchoice.Add("manage-application-type")
        Catch : End Try
        Try
            firstchoice.Add("configure-path")
        Catch : End Try
        Try
            firstchoice.Add("down")
        Catch : End Try
        Try
            firstchoice.Add("close")
        Catch : End Try
        Try
            firstchoice.Add("edit")
        Catch : End Try
        Try
            firstchoice.Add("update")
        Catch : End Try
        Try
            firstchoice.Add("delete")
        Catch : End Try
        Try
            firstchoice.Add("cancel")
        Catch : End Try
        Try
            firstchoice.Add("refresh")
        Catch : End Try
        Try
            firstchoice.Add("manage")
        Catch : End Try
        Try
            firstchoice.Add("configure")
        Catch : End Try
        Try
            firstchoice.Add("view")
        Catch : End Try
        Try
            firstchoice.Add("browse")
        Catch : End Try
        Try
            firstchoice.Add("save")
        Catch : End Try
        Try
            firstchoice.Add("section")
        Catch : End Try
        Try
            firstchoice.Add("browse")
        Catch : End Try
        Try
            firstchoice.Add("execute")
        Catch : End Try
        Try
            firstchoice.Add("view-activity")
        Catch : End Try
        Try
            firstchoice.Add("start-screen-sharing")
        Catch : End Try
        Try
            firstchoice.Add("change-section")
        Catch : End Try
        Try
            firstchoice.Add("back")
        Catch : End Try
        Try
            firstchoice.Add("next")
        Catch : End Try
        Try
            firstchoice.Add("continue")
        Catch : End Try
        Try
            firstchoice.Add("attendance")
        Catch : End Try
        Try
            firstchoice.Add("all-client")
        Catch : End Try
        Try
            firstchoice.Add("specific-client")
        Catch : End Try
        Try
            firstchoice.Add("reset")
        Catch : End Try
        Try
            firstchoice.Add("reset-activity")
        Catch : End Try
        Try
            firstchoice.Add("skip")
        Catch : End Try
        Try
            firstchoice.Add("enable")
        Catch : End Try
        Try
            firstchoice.Add("enable-all")
        Catch : End Try
        Try
            firstchoice.Add("disable")
        Catch : End Try
        Try
            firstchoice.Add("disable-all")
        Catch : End Try
        Try
            firstchoice.Add("stop-time")
        Catch : End Try
        Try
            firstchoice.Add("add-time")
        Catch : End Try
        Try
            firstchoice.Add("today")
        Catch : End Try

        builder1 = New GrammarBuilder
        builder1.Append(firstchoice)

        grammar1 = New Grammar(builder1)
        grammaracc = New Grammar(builder1)
        grammaract = New Grammar(builder1)
        grammaralt = New Grammar(builder1)
        grammarapp = New Grammar(builder1)
        grammaratt = New Grammar(builder1)
        grammarsec = New Grammar(builder1)
        grammarconf = New Grammar(builder1)
        grammarcont = New Grammar(builder1)
        grammarnew = New Grammar(builder1)
        grammarkey = New Grammar(builder1)
        grammarmanage = New Grammar(builder1)
        grammarclass = New Grammar(builder1)
        grammarnet = New Grammar(builder1)
        grammarreg = New Grammar(builder1)
        grammartimer = New Grammar(builder1)
        grammartutorial = New Grammar(builder1)
        grammarword = New Grammar(builder1)
        grammarmain = New Grammar(builder1)
        grammarmonitor = New Grammar(builder1)
        grammartype = New Grammar(builder1)
        grammartime = New Grammar(builder1)
        grammarreceive = New Grammar(builder1)
    End Sub

    Public grammartype, grammartime, grammarreceive, grammarmonitor, grammar1, grammar2, grammaracc, grammaract, grammaralt, grammarapp, grammaratt, grammarsec, grammarconf, grammarcont, grammarnew, grammarkey, grammarmanage, grammarclass, grammarnet, grammarreg, grammartimer, grammartutorial, grammarword As Grammar

    Sub CreateStudentActivity()
        If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity")) Then
            System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"))
        End If

        Try
            Dim PermissionsList As New List(Of SharePermissionEntry)

            'Create a new permission entry for the Everyone group and specify that we want to allow them Read access
            Dim PermEveryone As New SharePermissionEntry(String.Empty, "Everyone", SharedFolder.SharePermissions.FullControl, True)
            Dim PermUser As New SharePermissionEntry("", "Everyone", SharedFolder.SharePermissions.FullControl, True)

            'Add the two entries declared above to our list
            PermissionsList.Add(PermUser)
            PermissionsList.Add(PermEveryone)

            'Share the folder as "Test Share" and pass in the desired permissions list
            Dim Result As SharedFolder.NET_API_STATUS = _
            SharedFolder.ShareExistingFolder("Activity", "This holds the Activity of the Students", Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity"), PermissionsList)

            Dim FolderPath As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity") 'Specify the folder here
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
    End Sub

    Sub New()
        thread_speaker.Start()

        Try
test:

            con.ConnectionString = "Server=" & My.Settings.ServerIP & ";Database=dod;Uid=username;Pwd=nunaoppa;"
            con.Open()
            con.Close()

            LoadCommands1()
            Loadcommands2()

        Catch ex As Exception
            MsgBox("Unable to connect to the Server" & vbNewLine & vbNewLine & "- Please check your Network Connection", MsgBoxStyle.Critical, "Voice Command Controller for IT Laboratory")

            frmSetServer.ShowDialog()

            GoTo test
            Exit Sub
        End Try
    End Sub

    Sub CreateFolder(ByVal foldername As String, ByVal folderdesc As String)
        If Not System.IO.Directory.Exists(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, foldername)) Then
            System.IO.Directory.CreateDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, foldername))
        End If
    End Sub

    Public builder As PromptBuilder
    Public synthesizer As New SpeechSynthesizer
    Public lastmessage As String
    Public isLoading As Boolean = False

    Private Sub t_speaker()
        While thread_speaker_active = True
            If message <> "" Then
                '~~> Speak
                If synthesizer.State = SynthesizerState.Speaking Then
                    If Not lastmessage = message Then
                        synthesizer.SpeakAsyncCancel(synthesizer.GetCurrentlySpokenPrompt)
                    Else
                        message = ""
                        Continue While
                    End If
                End If

                synthesizer.SpeakAsync("... " & message)
                lastmessage = message
                message = ""
            End If
        End While
    End Sub

    Public Sub StopSpeaking()
        If synthesizer.State = SynthesizerState.Speaking Then
            synthesizer.SpeakAsyncCancel(synthesizer.GetCurrentlySpokenPrompt)
        End If
    End Sub

    Public Function v4() As String
        v4 = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                v4 = ipheal.ToString()
            End If
        Next
    End Function

End Module
