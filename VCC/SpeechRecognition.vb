Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Runtime.Serialization.Formatters.Binary

Public Class SpeechRecognition
    Public has_error As Boolean = False
    Public typing_mode As Boolean = False
    Private settime_mode As Boolean = False



    Private Sub SpeechRecognition_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        For Each Form As Form In Application.OpenForms
            If Form.Name = "DASHBOARD" Then
                Form.Show()

            End If

        Next
        _recognizer.RecognizeAsyncStop()
        start = False
    


    End Sub
    Dim my_splitter As String = "@"
    Private my_grammar As Grammar
    Private gr As New GrammarBuilder
    Private my_application As String = ""
    Private my_process As New Process()
    Private wordBank_open_close_command As DataTable
    Private wordbank_custom_words As DataTable
    Private computers As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Private dt As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Private dt2 As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Public WithEvents _recognizer As New System.Speech.Recognition.SpeechRecognitionEngine
    Public WithEvents _recognizer2 As New System.Speech.Recognition.SpeechRecognitionEngine
    Public WithEvents _recognizer3 As New System.Speech.Recognition.SpeechRecognitionEngine

    Public keywords_dictionary As Dictionary(Of String, Dictionary(Of String, String))
    Dim client As New TcpClient
    Dim clients As List(Of TcpClient) = New List(Of TcpClient)


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
    Dim bf As New BinaryFormatter
    Private Sub SendImage()
        Try
            For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers
                Try

                    Dim mclient As TcpClient = New TcpClient()


                    mclient.Connect(computer.Value("ipaddress"), 8085)

                    nstream = mclient.GetStream
                    bf.Serialize(nstream, Desktop())
                    mclient.Close()


                Catch ex As Exception
                    ' MessageBox.Show(computer.Value("ipaddress") & " connection lost")
                End Try
                

            Next

        Catch ex As Exception

        End Try
        clients.Clear()

    End Sub

    Private Sub SpeechRecognition_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LOGIN.database.query2("UPDATE users SET enable_tutorial_voice = 'no' WHERE ID = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("ID").ToString()})
        stop_listening()

    End Sub
    Public Sub stop_listening()
        _recognizer.RecognizeAsyncStop()
        _recognizer2.RecognizeAsyncStop()

        _recognizer3.RecognizeAsyncStop()
    End Sub
    Public Sub start_listening()
        _recognizer.SetInputToDefaultAudioDevice()
        _recognizer.RecognizeAsync(RecognizeMode.Multiple)
        _recognizer2.SetInputToDefaultAudioDevice()
        _recognizer2.RecognizeAsync(RecognizeMode.Multiple)
        _recognizer3.SetInputToDefaultAudioDevice()
        _recognizer3.RecognizeAsync(RecognizeMode.Multiple)
    End Sub
    Public Sub SpeechRecognition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stop_listening()
        builder = New PromptBuilder()
        'if tutorial mode
        'If LOGIN.user_info.Rows(0)("enable_tutorial_voice").ToString() = "yes" Then
        '    builder.AppendText("Welcome first time user. I will now teach you the basics of voice commands. To get started, please say 'Server open notepad.'")
        '    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
        '    builder.EndVoice()

        'End If
        ' Me.SetDesktopLocation(600, 700)


        Me.TopMost = True
        dt = New Dictionary(Of String, Dictionary(Of String, String))
        Me.Text = ""
        lbl_mode.Text = ""
        Dim words_choice As Choices = New Choices()
        LOGIN.database.query("SELECT * FROM words WHERE active = 'Yes'")
        Me.wordBank_open_close_command = LOGIN.database.dt

        For i As Integer = 0 To wordBank_open_close_command.Rows.Count - 1
            words_choice.Add(wordBank_open_close_command.Rows(i)("word").ToString())
            dt.Add(wordBank_open_close_command.Rows(i)("word").ToString(), New Dictionary(Of String, String) From {{"parameter", wordBank_open_close_command.Rows(i)("parameter").ToString()}, {"application_path", wordBank_open_close_command.Rows(i)("application_type").ToString()}})

        Next

        Dim computers As Choices = New Choices()
        Me.computers = New Dictionary(Of String, Dictionary(Of String, String))

        LOGIN.database.query("SELECT * FROM computers")
        For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
            Try
                computers.Add(LOGIN.database.dt.Rows(i)("word").ToString())
                Me.computers.Add(LOGIN.database.dt.Rows(i)("word").ToString, New Dictionary(Of String, String) From {{"computername", LOGIN.database.dt.Rows(i)("computername").ToString()}, {"ipaddress", LOGIN.database.dt.Rows(i)("ipaddress").ToString()}})

            Catch ex As Exception
                MessageBox.Show("Network error. Please resolve duplication of computer client's word-call and try again.")
                has_error = True
                network_setup.ShowDialog()
                network_setup.Dispose()
                Me.Close()
                Exit Sub
            End Try
            
        Next

        gr = New GrammarBuilder
        LOGIN.database.query("SELECT * FROM keyword")
        Dim keywords As DataTable = LOGIN.database.result()
        keywords_dictionary = New Dictionary(Of String, Dictionary(Of String, String))
        For i As Integer = 0 To keywords.Rows.Count - 1
            keywords_dictionary.Add(keywords(i)("keyword").ToString(), New Dictionary(Of String, String) From {{"word", keywords(i)("word").ToString()}, {"shortcut", keywords(i)("shortcut").ToString()}})
            words_choice.Add(keywords(i)("word").ToString())
        Next
        computers.Add(keywords_dictionary("computer")("word"))
        computers.Add("All")
        gr.Append(computers) 'initation call
        'SECOND SYNTAX
        gr.Append(New Choices(keywords_dictionary("open")("word"), keywords_dictionary("close")("word"), keywords_dictionary("start")("word"), keywords_dictionary("press")("word"), "stop", "standby", "connect", "disconnect", "unlock", "setup", "tell"))

        'action call
        words_choice.Add(keywords_dictionary("typing")("word"))
        words_choice.Add("program") 'used for computer close program
        words_choice.Add("listening") 'for stop listening
        words_choice.Add("unit") 'for stop listening
        words_choice.Add("visual-studio")
        words_choice.Add("time")

        'THIRD SYNTAX
        gr.Append(words_choice) 'user-defined words for opening and closing of applications
        Dim my_grammar As New Grammar(gr)
        my_grammar.Name = "main grammar"
        'load the grammar
        _recognizer.LoadGrammar(my_grammar)
        _recognizer.SetInputToDefaultAudioDevice()
        _recognizer.RecognizeAsync(RecognizeMode.Multiple)

      
        lbl_feedback2.Text = ""
        synthesizer = New SpeechSynthesizer()
        synthesizer.Speak(builder)
        synthesizer.Dispose()
        switch_grammar()

        listCommands()
    End Sub
    Private Sub listCommands()
        'list_commands.Items.Clear()

    End Sub

    Dim hWnd As IntPtr
    Private Sub _recognizer_SpeechRecognized3(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles _recognizer3.SpeechRecognized
        'For Each grammar As Grammar In _recognizer.Grammars
        '    If (grammar.Name = "main grammar" Or e.Result.Text = "computer start typing" Or e.Result.Words(0).Text = keywords_dictionary("computer")("word")) Then

        '        Exit Sub
        '    End If
        'Next
        If settime_mode = False Then
            Exit Sub

        End If
        Select Case e.Result.Text
            Case "ok"
                ''ok
                ''invoke the settimer's ok button
                'settime_mode = False
                'btn_close.Close()
                'builder = New PromptBuilder()
                'builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                'builder.AppendText("timer set successfully!")
                'builder.EndVoice()
                'synthesizer = New SpeechSynthesizer()
                'synthesizer.Speak(builder)
                'synthesizer.Dispose()
                settime_mode = False
                SetTimer.btn_ok_Click(sender, e)

            Case "cancel"
                'cancel
                settime_mode = False
                SetTimer.Close()
            Case "delete"
                SendKeys.Send("^(a)")
                SendKeys.Send("{BS}")
                builder = New PromptBuilder()
                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                builder.AppendText("timer cleared")
                builder.EndVoice()
                synthesizer = New SpeechSynthesizer()
                synthesizer.Speak(builder)
                synthesizer.Dispose()


            Case Else
                SendKeys.Send(e.Result.Words(0).Text)
                builder = New PromptBuilder()
                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                Dim s As String = ""
                If e.Result.Words(0).Text <> "1" Then
                    s = "s"
                End If
                builder.AppendText("time set to " & e.Result.Words(0).Text & " minute" & s)
                builder.EndVoice()
                synthesizer = New SpeechSynthesizer()
                synthesizer.Speak(builder)
                synthesizer.Dispose()

        End Select
    End Sub

    Private Sub _recognizer_SpeechRecognized2(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles _recognizer2.SpeechRecognized
        'For Each grammar As Grammar In _recognizer.Grammars
        '    If (grammar.Name = "main grammar" Or e.Result.Text = "computer start typing" Or e.Result.Words(0).Text = keywords_dictionary("computer")("word")) Then

        '        Exit Sub
        '    End If
        'Next
        If typing_mode = False Then
            Exit Sub

        End If
        Select Case e.Result.Words(0).Text


            'Case keywords_dictionary("switch")("word")
            '    _recognizer.RecognizeAsyncStop()
            '    _recognizer.UnloadAllGrammars()
            '    SpeechRecognition_Load(sender, e)

            '    Exit Sub
            Case keywords_dictionary("run")("word")
                builder = New PromptBuilder()
                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                builder.AppendText("got it")
                builder.EndVoice()
                synthesizer = New SpeechSynthesizer()
                synthesizer.Speak(builder)
                synthesizer.Dispose()

                'SendKeys.Send("{f5}")
                SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())

            Case keywords_dictionary("escape")("word")
                builder = New PromptBuilder()
                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                builder.AppendText("escaping")
                builder.EndVoice()
                synthesizer = New SpeechSynthesizer()
                synthesizer.Speak(builder)
                synthesizer.Dispose()

                'SendKeys.Send("{ESC}")
                SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())


            Case keywords_dictionary("space")("word")
                lbl_type.Text = "space"
                SendKeys.Send(" ")
            Case Else
                Try
                    If dt2.ContainsKey(e.Result.Words(0).Text) Then

                        If typing_mode = False Then
                            Exit Sub

                        End If
                        lbl_type.Text = dt2(e.Result.Words(0).Text)("print")

                        ' Copy the text in the datafield to Clipboard
                        'Clipboard.SetText(lbl_type.Text)

                        ' Get the Notepad Handle


                        ' Activate the Notepad Window
                        BringWindowToTop(hWnd)

                        ' Use SendKeys to Paste
                        Try
                            If typing_mode = False Then
                                Exit Sub

                            End If
                            SendKeys.Send(lbl_type.Text)
                            'SendKeys.Send("{(}{)}")
                            'If LOGIN.user_info.Rows(0)("enable_tutorial_voice").ToString() = "yes" And e.Result.Words(0).Text = "html" Then
                            '    stop_listening()

                            '    'Dim builder As PromptBuilder = New PromptBuilder()
                            '    'builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                            '    'builder.AppendText("Now say 'ENTER' to go to the next line... Now say 'begin' 'head'.")
                            '    'builder.EndVoice()
                            '    Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                            '    synthesizer.Speak(builder)

                            '    While synthesizer.State = SynthesizerState.Speaking

                            '    End While
                            '    synthesizer.Dispose()
                            '    start_listening()
                            'End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try

                        'SendKeys.Send("{RIGHT}")

                        'builder = New PromptBuilder()
                        'builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        'builder.Appendt2ext("got it")
                        'builder.EndVoice()
                        'synthesizer = New SpeechSynthesizer()
                        'synthesizer.Speak(builder)
                        'synthesizer.Dispose()
                    Else
                        If typing_mode Then
                            lbl_type.Text = e.Result.Words(0).Text

                        End If
                        'BringWindowToTop(hWnd)
                        SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())
                    End If

                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    'builder = New PromptBuilder()
                    'builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                    'builder.Appendt2ext("huh?")
                    'builder.EndVoice()
                    'synthesizer = New SpeechSynthesizer()
                    'synthesizer.Speak(builder)
                    'synthesizer.Dispose()
                End Try

        End Select
    End Sub

    Public Declare Function BringWindowToTop Lib "user32" (ByVal HWnd As IntPtr) As Boolean
    Private builder As PromptBuilder = New PromptBuilder()
    Private synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
    Dim start_sending As Thread = New Thread(AddressOf Thread_startSending)
    Private Sub Thread_startSending()
        While start

            SendImage()

        End While
        client.Close()

    End Sub
    Private Sub _recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles _recognizer.SpeechRecognized
        For Each grammar As Grammar In _recognizer.Grammars
            If (grammar.Name = "typing") Then

                Exit Sub
            End If
        Next

        If e.Result.Text = "exit typing" Then
            lbl_feedback2.Text = "listening mode"
            Exit Sub
        End If
        Select Case e.Result.Words(0).Text
            Case "All"
                Select Case e.Result.Words(1).Text
                    Case "open"
                        Select Case e.Result.Words(2).Text
                            Case "visual-studio"
                                lbl_feedback2.Text = e.Result.Text
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(lbl_feedback2.Text)
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)
                                synthesizer.Dispose()

                                For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers
                                    sender_class.send_message("open visual studio", computer.Value("ipaddress"))
                                Next
                            Case "notepad"
                                lbl_feedback2.Text = e.Result.Text
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(lbl_feedback2.Text)
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)
                                synthesizer.Dispose()
                                For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers

                                    sender_class.send_message("open notepad", computer.Value("ipaddress"))


                                Next
                        End Select
                    Case "unlock"
                        Select Case e.Result.Words(2).Text
                            Case "unit"
                                ' SetTimer.lbl_seconds_left.Text = ""
                                lbl_feedback2.Text = e.Result.Text
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(lbl_feedback2.Text)
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)
                                synthesizer.Dispose()
                                For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers

                                    sender_class.send_message("close lecture", computer.Value("ipaddress"))


                                Next
                                'SetTimer.lbl_seconds_left.Text = ""
                                lbl_feedback2.Text = e.Result.Text
                                start = False

                                clients.Clear()
                                start = False
                                start_sending.Abort()





                        End Select
                    Case "connect"
                        Select Case e.Result.Words(2).Text
                            Case keywords_dictionary("computer")("word")
                                'w(Thread(New ThreadStart(AddressOf WaitForRequest)))

                                lbl_feedback2.Text = e.Result.Text
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(lbl_feedback2.Text)
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)
                                synthesizer.Dispose()
                                Dim my_command As String = "shared desktop"
                                ' Go back here

                                'sender_class.send_message(my_command, "Main-PC")
                                ' sender_class.send_message(my_command, "Main-PC")
                                client = New TcpClient
                                Dim client2 = New TcpClient

                                Try
                                    'client2.Connect("judie", 8085)
                                    'client.Connect("Main-PC", 8085)
                                    ''client.Connect("Main-PC", 8085)

                                    'clients.Add(client)
                                    'clients.Add(client2)
                                    'For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers
                                    '    Dim mclient As TcpClient = New TcpClient()
                                    '    Try
                                    '        sender_class.send_message(my_command, computer.Value("ipaddress"))
                                    '        mclient.Connect(computer.Value("ipaddress"), 8085)
                                    '        clients.Add(mclient)
                                    '    Catch ex As Exception

                                    '    End Try

                                    'Next
                                    LOGIN.database.query("SELECT * FROM computers")
                                    computers.Clear()
                                    For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1

                                        Me.computers.Add(LOGIN.database.dt.Rows(i)("word").ToString, New Dictionary(Of String, String) From {{"computername", LOGIN.database.dt.Rows(i)("computername").ToString()}, {"ipaddress", LOGIN.database.dt.Rows(i)("ipaddress").ToString()}})

                                    Next
                                    For Each computer As KeyValuePair(Of String, Dictionary(Of String, String)) In computers
                                        'Dim mclient As TcpClient = New TcpClient()
                                        Try
                                            sender_class.send_message(my_command, computer.Value("ipaddress"))
                                            'mclient.Connect(computer.Value("ipaddress"), 8085)
                                            'clients.Add(mclient)
                                        Catch ex As Exception

                                        End Try

                                    Next
                                    start_sending.Abort()

                                    start = True
                                    start_sending = New Thread(AddressOf Thread_startSending)

                                    start_sending.Start()
                                    'If start_sending.IsBackground Then
                                    '    start_sending.Resume()

                                    'End If


                                Catch ex As Exception

                                    lbl_feedback2.Text = "error connecting to client"
                                    builder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText(lbl_feedback2.Text)
                                    builder.EndVoice()
                                    synthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)
                                    synthesizer.Dispose()

                                    MessageBox.Show("could not connect")
                                    Exit Sub
                                End Try



                        End Select
                End Select

            Case keywords_dictionary("computer")("word")

                Select Case e.Result.Words(1).Text
                    Case "tell"
                        Select Case e.Result.Words(2).Text
                            Case "time"
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(DASHBOARD.timeleft.ToString() & " remaining")
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)

                        End Select
                        'Case "start"
                        '    Select Case e.Result.Words(2).Text
                        '        Case "time"

                        '            If DASHBOARD.timeleft.ToString() = "00:00:00" Then
                        '                builder = New PromptBuilder()
                        '                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        '                builder.AppendText("please set timer first")
                        '                builder.EndVoice()
                        '                synthesizer = New SpeechSynthesizer()
                        '                synthesizer.Speak(builder)

                        '            Else
                        '                builder = New PromptBuilder()
                        '                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        '                builder.AppendText("timer started")
                        '                builder.EndVoice()
                        '                synthesizer = New SpeechSynthesizer()
                        '                synthesizer.Speak(builder)

                        '                DASHBOARD.Timer1.Start()
                        '                LOGIN.database.query2("UPDATE student_section SET timer_initiated = 'yes' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})

                        '            End If


                        '    End Select

                    Case "setup"
                        Select Case e.Result.Words(2).Text
                            Case "time"
                                'enable set time mode

                                'set time

                                'upon hearing "ok" disable set time mode

                                'close set timer
                                settime_mode = True
                                SetTimer.ShowDialog()
                                SetTimer.Dispose()

                                settime_mode = False

                        End Select
                    Case "stop"
                        Select Case e.Result.Words(2).Text
                            Case "listening"
                                Me.Close()
                            Case "typing"
                                stop_listening()
                                lbl_feedback2.Text = ""
                                lbl_mode.Text = ""
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText("typing mode stopped")
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)

                                While synthesizer.State = SynthesizerState.Speaking

                                End While
                                start_listening()
                                synthesizer.Dispose()
                                typing_mode = False
                                lbl_type.Text = ""
                        End Select
                    Case keywords_dictionary("open")("word")

                        Try
                            lbl_feedback2.Text = e.Result.Words(1).Text + "ing " + e.Result.Words(2).Text

                            Dim builder As PromptBuilder = New PromptBuilder()
                            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()

                            builder = New PromptBuilder()
                            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                            builder.AppendText(lbl_feedback2.Text)
                            builder.EndVoice()
                            synthesizer = New SpeechSynthesizer()
                            stop_listening()
                            synthesizer.Speak(builder)
                            synthesizer.Dispose()

                            If String.IsNullOrEmpty(dt(e.Result.Words(2).Text)("parameter")) = False Then
                                Me.my_process.StartInfo.Arguments = """" + dt(e.Result.Words(2).Text)("parameter") + """"

                            End If

                            'Me.my_process.StartInfo.FileName = """" + dt(e.Result.Words(2).Text)("parameter") + """"


                            Me.my_process.StartInfo.FileName = """" + dt(e.Result.Words(2).Text)("application_path") + """"


                            Me.my_process.Start()
                            Me.my_process.StartInfo.Arguments = ""
                            Me.my_process.StartInfo.FileName = ""


                            'if tutorial mode
                            stop_listening()

                            If LOGIN.user_info.Rows(0)("enable_tutorial_voice").ToString() = "yes" And e.Result.Words(2).Text = "notepad" Then
                                Dim builder2 As PromptBuilder = New PromptBuilder()
                                builder2.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                Dim synthesizer2 As SpeechSynthesizer = New SpeechSynthesizer()

                                builder2.AppendText("Now say 'server start typing' to enable typing mode.")
                                builder2.EndVoice()

                                synthesizer2.Speak(builder2)
                                While synthesizer2.State = SynthesizerState.Speaking

                                End While
                                synthesizer2.Dispose()
                                start_listening()

                            Else
                                start_listening()

                            End If

                        Catch ex As Exception
                            lbl_feedback2.Text = "listening"
                            Dim builder As PromptBuilder = New PromptBuilder()
                            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                            builder.AppendText("listening")
                            builder.EndVoice()
                            Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                            synthesizer.Speak(builder)
                            synthesizer.Dispose()
                            start_listening()

                            Exit Sub
                        End Try
                        Try
                            hWnd = my_process.Handle
                        Catch ex As Exception

                        End Try
                    Case "press"
                        Select Case e.Result.Words(2).Text
                            Case "left"
                                SendKeys.Send("{LEFT}")
                            Case "right"
                                SendKeys.Send("{right}")
                            Case "up"
                                SendKeys.Send("{UP}")
                            Case "down"
                                SendKeys.Send("{DOWN}")
                            Case "enter"
                                SendKeys.Send("{ENTER}")
                        End Select
                    Case keywords_dictionary("start")("word")

                        Select Case (e.Result.Words(2).Text)
                            Case "time"

                                If DASHBOARD.timeleft.ToString() = "00:00:00" Then
                                    builder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText("please set timer first")
                                    builder.EndVoice()
                                    synthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)

                                Else
                                    builder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText("timer started")
                                    builder.EndVoice()
                                    synthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)

                                    DASHBOARD.Timer1.Start()
                                    LOGIN.database.query2("UPDATE student_section SET timer_initiated = 'yes' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {LOGIN.section, LOGIN.subj, LOGIN.professor.username, LOGIN.sched_timein, LOGIN.sched_timeout, LOGIN.sched_day})

                                End If

                            Case keywords_dictionary("typing")("word")
                                stop_listening()

                                lbl_mode.Text = "typing: "
                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText("typing mode initiated")
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)

                                While synthesizer.State = SynthesizerState.Speaking

                                End While
                                synthesizer.Dispose()
                                start_listening()
                                typing_mode = True

                                'if tutorial mode
                                If LOGIN.user_info.Rows(0)("enable_tutorial_voice").ToString() = "yes" And e.Result.Words(2).Text = "typing" Then
                                    stop_listening()

                                    Dim builder As PromptBuilder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText("Now say 'begin' 'html'.")
                                    builder.EndVoice()
                                    Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)

                                    While synthesizer.State = SynthesizerState.Speaking

                                    End While
                                    synthesizer.Dispose()
                                    start_listening()

                                End If

                                Exit Sub
                        End Select


                        'Case "say"
                        '    Dim builder As PromptBuilder = New PromptBuilder()
                        '    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        '    builder.AppendText(e.Result.Words(2).Text)
                        '    builder.EndVoice()
                        '    Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                        '    synthesizer.Speak(builder)
                        '    synthesizer.Dispose()
                        'Case "print"

                    Case keywords_dictionary("close")("word")
                        Select Case e.Result.Words(2).Text
                            Case "program"
                                lbl_feedback2.Text = "closing " + e.Result.Words(2).Text


                                builder = New PromptBuilder()
                                builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                builder.AppendText(lbl_feedback2.Text)
                                builder.EndVoice()
                                synthesizer = New SpeechSynthesizer()
                                synthesizer.Speak(builder)
                                synthesizer.Dispose()
                                SendKeys.Send("%{F4}")
                            Case "this"
                                Me.Close()
                        End Select


                        'Try
                        '    Dim process_name As String = dt(e.Result.Words(2).Text)("application_path").ToString().Split("\").Last().Replace(".EXE", "").Replace(".exe", "")
                        'Catch ex As Exception
                        '    lbl_feedback2.Text = "please try again"
                        '    Dim builder As PromptBuilder = New PromptBuilder()
                        '    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        '    builder.AppendText("please try again")
                        '    builder.EndVoice()
                        '    Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
                        '    synthesizer.Speak(builder)
                        '    synthesizer.Dispose()
                        '    Exit Sub
                        'End Try
                End Select

            Case keywords_dictionary("press")("word")
                Select Case e.Result.Words(2).Text

                    Case keywords_dictionary("switch")("word")
                        _recognizer.RecognizeAsyncStop()
                        _recognizer.UnloadAllGrammars()
                        SpeechRecognition_Load(sender, e)

                        Exit Sub
                    Case keywords_dictionary("run")("word")
                        builder = New PromptBuilder()
                        builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        builder.AppendText("got it")
                        builder.EndVoice()
                        synthesizer = New SpeechSynthesizer()
                        synthesizer.Speak(builder)
                        synthesizer.Dispose()

                        'SendKeys.Send("{f5}")
                        SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())

                    Case keywords_dictionary("escape")("word")
                        builder = New PromptBuilder()
                        builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                        builder.AppendText("escaping")
                        builder.EndVoice()
                        synthesizer = New SpeechSynthesizer()
                        synthesizer.Speak(builder)
                        synthesizer.Dispose()

                        'SendKeys.Send("{ESC}")
                        SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())


                    Case keywords_dictionary("space")("word")
                        lbl_feedback2.Text = "space"

                        SendKeys.Send(" ")

                    Case keywords_dictionary(e.Result.Words(0).Text)("word")
                        lbl_feedback2.Text = e.Result.Words(0).Text
                        BringWindowToTop(hWnd)
                        SendKeys.Send(keywords_dictionary(e.Result.Words(0).Text)("shortcut").ToString())


                    Case keywords_dictionary(e.Result.Words(2).Text)("word")
                        lbl_feedback2.Text = e.Result.Words(2).Text
                        Try
                            SendKeys.Send(keywords_dictionary(e.Result.Words(2).Text)("shortcut").ToString())

                        Catch ex As Exception
                        End Try

                End Select






            Case Else
                Try
                    Dim my_command As String = ""
                    Select Case e.Result.Words(1).Text
                        Case "open"
                            my_command += "open" + my_splitter
                            my_command += dt(e.Result.Words(2).Text)("parameter") + my_splitter
                            my_command += dt(e.Result.Words(2).Text)("application_path").ToString()

                        Case "close"
                            my_command += "close" + my_splitter
                            my_command += dt(e.Result.Words(2).Text)("parameter") + my_splitter
                            my_command += dt(e.Result.Words(2).Text)("application_path").ToString()
                        Case "standby"
                            Select Case e.Result.Words(2).Text
                                Case "unit"
                                    my_command += "command" + my_splitter
                                    my_command += "standby" + my_splitter
                                    my_command += "unit"
                                    lbl_feedback2.Text = e.Result.Text
                                    builder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText(lbl_feedback2.Text)
                                    builder.EndVoice()
                                    synthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)
                                    synthesizer.Dispose()
                            End Select

                        Case "connect"

                            'Creates a Thread To Listen 4 the Request of the Receiver 

                            Select Case e.Result.Words(2).Text
                                Case keywords_dictionary("computer")("word")
                                    Try

                                        Dim myClient As New TcpClient
                                        'ServerIp = Dns.GetHostByName("main-pc").AddressList(0).ToString()
                                        'myClient.Connect(ServerIp, 6789)
                                        'myClient.Close()

                                        'Look4Request = New Thread(New ThreadStart(AddressOf WaitForRequest))

                                        lbl_feedback2.Text = e.Result.Text
                                        builder = New PromptBuilder()
                                        builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                        builder.AppendText(lbl_feedback2.Text)
                                        builder.EndVoice()
                                        synthesizer = New SpeechSynthesizer()
                                        synthesizer.Speak(builder)
                                        synthesizer.Dispose()
                                        my_command = "shared desktop"
                                        Dim computer_name2 As String = computers(e.Result.Words(0).Text)("ipaddress")
                                        sender_class.send_message(my_command, computer_name2)
                                        client = New TcpClient
                                        Try

                                            client.Connect(computer_name2, 8085)
                                            clients.Add(client)

                                        Catch ex As Exception
                                            lbl_feedback2.Text = "error connecting to client"
                                            builder = New PromptBuilder()
                                            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                            builder.AppendText(lbl_feedback2.Text)
                                            builder.EndVoice()
                                            synthesizer = New SpeechSynthesizer()
                                            synthesizer.Speak(builder)
                                            synthesizer.Dispose()

                                            MessageBox.Show("could not connect")
                                            Exit Sub
                                        End Try

                                        start = True
                                        start_sending = New Thread(AddressOf Thread_startSending)
                                        start_sending.Start()
                                        'Look4Request.Start()
                                    Catch ex As Exception

                                    End Try

                                    Exit Sub
                            End Select

                        Case "disconnect"
                            Select Case e.Result.Words(2).Text
                                Case keywords_dictionary("computer")("word")
                                    my_command = "stop desktop"
                                    start = False

                                    start_sending.Abort()


                                    client.Close()
                                    my_command = "stop desktop"
                                    Dim computer_name2 As String = computers(e.Result.Words(0).Text)("computername")
                                    sender_class.send_message(my_command, computer_name2)
                                    lbl_feedback2.Text = e.Result.Text
                                    builder = New PromptBuilder()
                                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                                    builder.AppendText(lbl_feedback2.Text)
                                    builder.EndVoice()
                                    synthesizer = New SpeechSynthesizer()
                                    synthesizer.Speak(builder)
                                    synthesizer.Dispose()
                            End Select

                    End Select
                    Dim computer_name As String = computers(e.Result.Words(0).Text)("computername")
                    sender_class.send_message(my_command, computer_name)

                Catch ex As Exception
                    'lbl_feedback2.Text = "please try again"
                    'builder = New PromptBuilder()
                    'builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                    'builder.AppendText("please try again")
                    'builder.EndVoice()
                    'synthesizer = New SpeechSynthesizer()
                    'synthesizer.Speak(builder)
                    'synthesizer.Dispose()
                    Exit Sub
                End Try
        End Select

        'Threading.Thread.Sleep(2000)
        lbl_feedback2.Text = ""
        lbl_type.Text = ""

    End Sub
    Dim start As Boolean = True

    Sub WaitForRequest()
        'Gets the Receiver Address
        ' Dim ServerAddress As String = Dns.GetHostByName("main-pc").AddressList(0).ToString()


        Try
            While (start)
                Try
                    Dim myListener As New TcpListener(RequestPort)
                    'Dim myListener As New TcpListener(ServerAddress, RequestPort)
                    myListener.Start()
                    'If Connected Gets the Client Stream
                    Dim myClient As TcpClient = myListener.AcceptTcpClient
                    NetStream = myClient.GetStream
                    Try
                        Send_Screen_Shot() 'Sends the Screen Shot of the Desktop

                    Catch ex As Exception

                    End Try
                    'myClient.Close()
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    Exit While
                End Try

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Try
                myReader.Close()
                NetStream.Close()
            Catch ex As Exception

            End Try

        End Try

    End Sub
    Const ConnectionPort As Int16 = 9876 'Connection Port Number
    Const RequestPort As Int16 = 6789 'Request Port Number
    Dim ServerIp As String
    Dim NetStream As NetworkStream
    Dim myReader As BinaryReader
    Dim myWriter As BinaryWriter
    Dim Look4Request As Thread = Nothing
    Dim mReader As BinaryReader
    Dim mWriter As BinaryWriter = Nothing
    Const ListenPort As Int16 = 9876
    Shared NoofClients As Int16 = 0 'Stores the Number of Image Sender Connected
    Sub Send_Screen_Shot()
        Try
            Dim FileName As String = Environment.CurrentDirectory & "\Mohiudeen_Screen.jpg"
            ScreenCapture.CurrentScreen() 'Capture the Current Screen
            'If File.Exists(FileName) Then
            '    File.Delete(FileName)
            'End If
            ScreenCapture.oBitMap.Save(FileName) 'Saves it to a File
            ScreenCapture.oBitMap = Nothing
            'Then,Sends the File to the Image Receiver
            Using FStreams As New FileStream(FileName, FileMode.Open)
                Dim buffer(1024 - 1) As Byte
                Do While True
                    Dim bytesRead As Integer = FStreams.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then Exit Do
                    Me.NetStream.Write(buffer, 0, bytesRead)
                    NetStream.Flush()
                Loop
                FStreams.Close()
                NetStream.Close()
            End Using
            'Finally Closes
        Catch ex As Exception
        End Try
    End Sub


    Private Sub switch_grammar()

        '_recognizer.RecognizeAsyncStop()
        '_recognizer.UnloadAllGrammars()
        dt2 = New Dictionary(Of String, Dictionary(Of String, String))
        ' Add any initialization after the InitializeComponent() call.

        'load default grammar and open/close command grammar

        Dim words_choice1 As Choices = New Choices()
        LOGIN.database.query("SELECT * FROM type WHERE enabled = 'yes'")
        Me.wordbank_custom_words = LOGIN.database.dt

        For i As Integer = 0 To Me.wordbank_custom_words.Rows.Count - 1
            words_choice1.Add(wordbank_custom_words.Rows(i)("word").ToString())
            dt2.Add(wordbank_custom_words.Rows(i)("word").ToString(), New Dictionary(Of String, String) From {{"print", wordbank_custom_words.Rows(i)("print").ToString()}})

        Next
        LOGIN.database.query("SELECT * FROM keyword")


        For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
            words_choice1.Add(LOGIN.database.dt.Rows(i)("word").ToString())

        Next

        'words_choice1.Add("typing", "program", "undo", "backspace", "delete", "this")

        gr = New GrammarBuilder
        'gr.Append(New Choices("type", "exit", "run"))
        gr.Append(words_choice1) 'user-defined words for opening and closing of applications

        Dim my_grammar1 As New Grammar(gr)
        my_grammar1.Name = "typing"
        'load the grammar


        _recognizer2.LoadGrammar(my_grammar1)
        _recognizer2.SetInputToDefaultAudioDevice()
        _recognizer2.RecognizeAsync(RecognizeMode.Multiple)
        Me.Text = "typing mode with single-word commands"
        lbl_mode.Text = ""


        '''''''''''''load set-time typing mode''''''''''''''''''''''''
        Dim words_choice2 As Choices = New Choices()
        'set minutes grammar, maximum of 320 minutes
        For i As Integer = 0 To 320
            words_choice2.Add(i.ToString())

        Next
        words_choice2.Add("delete")
        words_choice2.Add("ok")
        words_choice2.Add("cancel")


        'words_choice1.Add("typing", "program", "undo", "backspace", "delete", "this")

        Dim gr2 As GrammarBuilder = New GrammarBuilder
        'gr.Append(New Choices("type", "exit", "run"))
        gr2.Append(words_choice2) 'user-defined words for opening and closing of applications

        Dim my_grammar2 As New Grammar(gr2)
        my_grammar2.Name = "set-time"
        'load the grammar


        _recognizer3.LoadGrammar(my_grammar2)
        _recognizer3.SetInputToDefaultAudioDevice()
        _recognizer3.RecognizeAsync(RecognizeMode.Multiple)
       
        '//rebuild_engine();
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        InitializeComponent()

    End Sub
    Private draggable As Boolean = False
    Private mousex As Integer
    Private mousey As Integer
    Private Sub SpeechRecognition_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.draggable = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top

    End Sub

    Private Sub SpeechRecognition_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If draggable = True Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub SpeechRecognition_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        draggable = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' SendImage()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        strategy_window.closeWindowReturnDashboard(Me)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If False = list_commands.Visible Then
            list_commands.Visible = True
        Else
            list_commands.Visible = False
        End If

    End Sub
End Class