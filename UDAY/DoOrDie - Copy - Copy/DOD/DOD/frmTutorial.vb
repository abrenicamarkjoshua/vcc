Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.Speech.Recognition

Public Class frmTutorial
    Public nextform As String
    Public exited As Boolean = False
    Public isFirst As Boolean = True

    Private gr As New GrammarBuilder

    Public computerdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public defaultdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public actiondic As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private worddic As New Dictionary(Of String, String)

    Public Declare Function BringWindowToTop Lib "user32" (ByVal HWnd As IntPtr) As Boolean
    Public WithEvents rec As New System.Speech.Recognition.SpeechRecognitionEngine
    Public WithEvents rec1 As New System.Speech.Recognition.SpeechRecognitionEngine

    Private Sub frmTutorial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTop.Width = Me.Width
        lblLeft.Height = Me.Height
        lblBot.Width = Me.Width
        lblBot.Top = Me.Height - 5
        lblRight.Height = Me.Height
        lblRight.Left = Me.Width - 5
        lblSkip.Left = Me.Width - 155

        FinishPanel.Left = (Me.Width / 2) - (FinishPanel.Width / 2)
        FinishPanel.Top = (Me.Height / 2) - (FinishPanel.Height / 2)
        Panel2.Left = (Me.Width / 2) - (Panel2.Width / 2)
        Panel2.Top = (Me.Height / 2) - (Panel2.Height / 2)

        nextform = "Train"

        If isFirst = True Then
            lblSkip.Visible = False
        Else
            lblSkip.Visible = True
        End If

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Dim process As Process = New Process()
    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer
    Public msg As String

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()

                message = "First timers requires training the speech recognition to better recognize the user's voice commands"

                Try
                    process.StartInfo.FileName = "C:\Windows\sysnative\Speech\speechUX\SpeechUXWiz.exe"
                    process.StartInfo.Arguments = "UserTraining"
                    process.Start()
                Catch ex As Exception
                    Try
                        process.StartInfo.FileName = "C:\Windows\System32\Speech\speechUX\SpeechUXWiz.exe"
                        process.StartInfo.Arguments = "UserTraining"
                        process.Start()
                    Catch exs As Exception
                        message = "Unable to locate the Speech Recognition Training Wizard"
                        MsgBox("Unable to locate the Speech Recognition Training Wizard", MsgBoxStyle.Information, "Training Wizard")
                    End Try
                End Try

                While exited = False
                    If process.HasExited = True Then
                        StopSpeaking()

                        MoveIndicator.Tag = "Network"
                        MoveIndicator.Start()

                        exited = True
                    End If
                End While
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

    Public wordcall, pathname, conpath As String
    Public compwordcall As String
    Public isOpen As Boolean = False
    Public isMode2 As Boolean = False
    Dim isBegin As Boolean = False
    Dim isFHTML As Boolean = False
    Dim isFEnter As Boolean = False
    Dim isSBegin As Boolean = False
    Dim isHead As Boolean = False
    Dim isStop As Boolean = False
    Dim isStart As Boolean = False
    Dim isEnd As Boolean = False
    Dim isSelectAll As Boolean = False
    Dim isBackSpace As Boolean = False
    Dim errcount As Integer = 0

    Private Sub rec1_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles rec1.SpeechRecognized
        If isBackSpace = True Then
            If e.Result.Text = compwordcall & "-Stop-Typing" Then
                Loadmode1()

                message = "Now to close the 'Notepad'.. Say.. '" & compwordcall & "', 'Close', 'Notepad'"

                isClose = True

                Exit Sub
            End If
        End If

        If isHead = True Then
            If isStop = False Then
                If e.Result.Text = compwordcall & "-Stop-Listening" Then
                    lblFeedback.Text = e.Result.Text

                    message = "To start the Recognition of the System.. Say.. " & compwordcall & " Start Listening"

                    errcount = 1

                    isStop = True
                End If
            End If
        End If

        If isStop = True Then
            If isStart = False Then
                If e.Result.Text = compwordcall & "-Start-Listening" Then
                    lblFeedback.Text = e.Result.Text

                    message = "Now say.. Select All"

                    errcount = 1

                    isStart = True
                End If
            End If
        End If

        If worddic.ContainsKey(e.Result.Words(0).Text) Then
            If isBegin = False Then
                If LCase(e.Result.Words(0).Text) = "begin" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "HTML"

                    errcount = 1

                    isBegin = True
                Else
                    If errcount = 2 Then

                        message = "Begin"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo html
            End If

            Exit Sub

html:
            If isFHTML = False Then
                If LCase(e.Result.Words(0).Text) = "html" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "Enter"

                    errcount = 1

                    isFHTML = True
                Else
                    If errcount = 2 Then

                        message = "HTML"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo enter
            End If

            Exit Sub
enter:
            If isFEnter = False Then
                If LCase(e.Result.Words(0).Text) = "enter" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "Begin"

                    errcount = 1

                    isFEnter = True
                Else
                    If errcount = 2 Then

                        message = "Enter"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo sbegin
            End If

            Exit Sub

sbegin:
            If isSBegin = False Then
                If LCase(e.Result.Words(0).Text) = "begin" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "Head"

                    errcount = 1

                    isSBegin = True
                Else
                    If errcount = 2 Then

                        message = "Begin"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo fhead
            End If

            Exit Sub
fhead:
            If isHead = False Then
                If LCase(e.Result.Words(0).Text) = "head" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "To stop the System from listening.. Say.. " & compwordcall & " Stop Listening"

                    errcount = 1

                    isHead = True
                Else
                    If errcount = 2 Then

                        message = "Head"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo sstop
            End If

            Exit Sub
sstop:
            If isStop = True Then
                GoTo sstart
            End If

            Exit Sub
sstart:
            If isStart = True Then
                GoTo sselect
            End If

            Exit Sub
sselect:
            If isSelectAll = False Then
                If LCase(e.Result.Words(0).Text) = "select-all" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "Delete or Backspace"

                    errcount = 1

                    isSelectAll = True
                Else
                    If errcount = 2 Then

                        message = "Select All"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                GoTo sdel
            End If

            Exit Sub
sdel:
            If isBackSpace = False Then
                If LCase(e.Result.Words(0).Text) = "backspace" Or LCase(e.Result.Words(0).Text) = "delete" Then
                    SendKeys.Send("" & worddic(e.Result.Words(0).Text) & "")

                    lblFeedback.Text = e.Result.Words(0).Text

                    message = "Say.. '" & compwordcall & "' 'Stop' 'Typing'"

                    errcount = 1

                    isBackSpace = True
                Else
                    If errcount = 2 Then

                        message = "Delete or Backspace"

                        errcount = 1
                    Else
                        errcount += 1
                    End If
                End If
            Else
                If errcount = 2 Then

                    message = "Say.. '" & compwordcall & "' 'Stop' 'Typing'"

                    errcount = 1
                Else
                    errcount += 1
                End If
            End If
        Else
            lblCommand.Text = ""
            lblFeedback.Text = ""
        End If

    End Sub

    Public isExit As Boolean = False
    Public isClose As Boolean = false
    Public isLoading As Boolean = True

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If isOpen = True Then
            If LCase(e.Result.Text) = LCase(compwordcall) & " start typing" Then
                LoadMode2()

                message = "Typing Mode Initiated.. Now Say 'Begin'"

                Exit Sub
            End If
        End If

        If computerdic.ContainsKey(e.Result.Words(0).Text) Then
            If computerdic(e.Result.Words(0).Text) = My.Computer.Name Then
                If LCase(e.Result.Words(1).Text) = "open" Then
                    If LCase(e.Result.Words(2).Text) = "notepad" Then
                        If isOpen = True Then
                            Exit Sub
                        End If

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim upcomm As New MySqlCommand(sql, con)
                        upcomm.Parameters.AddWithValue("?name", My.Computer.Name)
                        upcomm.Parameters.AddWithValue("?ip", ipaddress)
                        upcomm.Parameters.AddWithValue("?comm", "Open|C:\Windows\notepad.exe|")
                        upcomm.Parameters.AddWithValue("?con", "C:\Windows\notepad.exe")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcomm.ExecuteNonQuery()
                        con.Close()

                        lblFeedback.Text = "Opening " & e.Result.Words(2).Text
                        lblCommand.Text = e.Result.Text

                        lblInstruction.Text = "Now to start typing, you'll just say.. '" & compwordcall & "' 'Start' 'Typing'"

                        message = "Now to start typing, you'll just say.. '" & compwordcall & "'.. 'Start'.. 'Typing'"

                        isOpen = True

                        Exit Sub
                    End If
                ElseIf LCase(e.Result.Words(1).Text) = "close" Then
                    If LCase(e.Result.Words(2).Text) = "notepad" Then
                        If isClose = False Then
                            Exit Sub
                        End If

                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim upcomm As New MySqlCommand(sql, con)
                        upcomm.Parameters.AddWithValue("?name", My.Computer.Name)
                        upcomm.Parameters.AddWithValue("?ip", ipaddress)
                        upcomm.Parameters.AddWithValue("?comm", "close|C:\Windows\notepad.exe|")
                        upcomm.Parameters.AddWithValue("?con", "")

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcomm.ExecuteNonQuery()
                        con.Close()

                        lblFeedback.Text = "Close " & e.Result.Words(2).Text
                        lblCommand.Text = e.Result.Text

                        rec.RecognizeAsyncStop()
                        rec1.RecognizeAsyncStop()

                        lblInstruction.Text = "Now that is the basic of voice command."

                        msg = "Now that is the basic of voice command.. Tutorial Complete!"
                        MoveIndicator.Tag = "Finish"
                        MoveIndicator.Start()

                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Sub LoadMode2()
        'Try
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadAllGrammars()
        Catch : End Try

        Dim wordchoice As New Choices()
        worddic = New Dictionary(Of String, String)

        wordchoice.Add("begin")
        wordchoice.Add("end")
        wordchoice.Add("html")
        wordchoice.Add("head")

        worddic.Add("begin", "<")
        worddic.Add("end", "</")
        worddic.Add("html", "html>")
        worddic.Add("head", "head>")

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

        wordchoice.Add(compwordcall & "-Stop-Typing")
        wordchoice.Add(compwordcall & "-Stop-Listening")
        wordchoice.Add(compwordcall & "-Start-Listening")

        For a = 1 To voicecommand.Length
            Dim commandinfo() As String = LCase(voicecommand(a - 1)).ToString.Split(" ")
            Try
                wordchoice.Add(commandinfo(0))
            Catch : End Try
            Try
                wordchoice.Add(commandinfo(1))
            Catch : End Try
        Next
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
            rec1.LoadGrammar(gram)
            rec1.SetInputToDefaultAudioDevice()
            rec1.RecognizeAsync(1)
        Catch : End Try

        lblTyping.Visible = True
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub MoveIndicator_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveIndicator.Tick
        If MoveIndicator.Tag = "Network" Then
            If lblIndicator.Left < 145 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 175 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                frmNetwork.isTutorial = "Yes"
                frmNetwork.Show()

                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.LawnGreen
            End If
        ElseIf MoveIndicator.Tag = "Application" Then
            If lblIndicator.Left < 295 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 325 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                frmApplication.isTutorial = "Yes"
                frmApplication.Show()

                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.DarkGray
                lblApplication.ForeColor = Color.LawnGreen
            End If
        ElseIf MoveIndicator.Tag = "Word" Then
            If lblIndicator.Left < 445 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 475 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                frmWord.isTutorial = "Yes"
                frmWord.Show()

                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.DarkGray
                lblApplication.ForeColor = Color.DarkGray
                lblWord.ForeColor = Color.LawnGreen
            End If
        ElseIf MoveIndicator.Tag = "Keyword" Then
            If lblIndicator.Left < 595 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 625 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                frmKeyword.isTutorial = "Yes"
                frmKeyword.Show()

                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.DarkGray
                lblApplication.ForeColor = Color.DarkGray
                lblWord.ForeColor = Color.DarkGray
                lblKeyword.ForeColor = Color.LawnGreen
            End If
        ElseIf MoveIndicator.Tag = "Voice" Then
            If lblIndicator.Left < 745 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 775 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()

                Panel2.Visible = True

                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.DarkGray
                lblApplication.ForeColor = Color.DarkGray
                lblWord.ForeColor = Color.DarkGray
                lblKeyword.ForeColor = Color.DarkGray
                lblVoice.ForeColor = Color.LawnGreen

                lblSkip.Visible = True
            End If
        ElseIf MoveIndicator.Tag = "Finish" Then
            If lblIndicator.Left < 895 Then
                lblIndicator.Left += 10
            ElseIf lblIndicator.Left < 925 Then
                lblIndicator.Left += 3
            Else
                MoveIndicator.Stop()
                lblTrain.ForeColor = Color.DarkGray
                lblNetwork.ForeColor = Color.DarkGray
                lblApplication.ForeColor = Color.DarkGray
                lblWord.ForeColor = Color.DarkGray
                lblKeyword.ForeColor = Color.DarkGray
                lblVoice.ForeColor = Color.DarkGray
                lblFinish.ForeColor = Color.LawnGreen

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadAllGrammars()
                Catch : End Try

                Panel2.Visible = False

                message = msg & ".. Press 'Continue' to return to the User Account Panel"
                Label1.Text = msg

                FinishPanel.Visible = True
                lblContinue.Visible = True
            End If
        End If
    End Sub

    Public apptype As String
    Public ipaddress As String

    Sub Loadmode1()
        Try
            rec1.RecognizeAsyncStop()
            rec1.UnloadAllGrammars()
        Catch : End Try

        Dim computerschoice As New Choices()
        computerdic = New Dictionary(Of String, String)

        sql = "SELECT * FROM tbl_computer WHERE computername=?name AND ipaddress=?ip"
        Dim compname As New MySqlCommand(sql, con)
        compname.Parameters.AddWithValue("?name", My.Computer.Name)
        compname.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(compname)
        ds.Clear()
        da.Fill(ds, "compname")

        compwordcall = ds.Tables("compname").Rows(0).Item("wordcall").ToString
        ipaddress = ds.Tables("compname").Rows(0).Item("ipaddress").ToString
        computerdic.Add(ds.Tables("compname").Rows(0).Item("wordcall").ToString, ds.Tables("compname").Rows(0).Item("computername").ToString)
        computerschoice.Add(ds.Tables("compname").Rows(0).Item("wordcall").ToString)

        For a = 1 To voicecommand.Length
            Dim commandinfo() As String = LCase(voicecommand(a - 1)).ToString.Split(" ")
            Try
                computerschoice.Add(commandinfo(0))
            Catch : End Try
            Try
                computerschoice.Add(commandinfo(1))
            Catch : End Try
        Next
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
        Dim defstr() As String = {"Open", "Close", "Start", "Stop"}

        For Each def In defstr
            defaultschoice.Add(def)
        Next

        For a = 1 To voicecommand.Length
            Dim commandinfo() As String = LCase(voicecommand(a - 1)).ToString.Split(" ")
            Try
                defaultschoice.Add(commandinfo(0))
            Catch : End Try
            Try
                defaultschoice.Add(commandinfo(1))
            Catch : End Try
        Next
        For a = 1 To setalphabet.Length
            Try
                defaultschoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                defaultschoice.Add(setalphabet(a - 1))
            Catch : End Try
        Next

        actiondic = New Dictionary(Of String, String)
        Dim actionschoice As New Choices()

        '~~> List all the Actions available including in File Setting
        sql = "SELECT * FROM tbl_application WHERE accountuser=?user"
        Dim app As New MySqlCommand(sql, con)
        app.Parameters.AddWithValue("?user", frmMenu.username)

        da = New MySqlDataAdapter(app)
        ds.Clear()
        da.Fill(ds, "app")

        If ds.Tables("app").Rows.Count > 0 Then
            actionschoice.Add(ds.Tables("app").Rows(0).Item("wordcall").ToString)
            actiondic.Add(ds.Tables("app").Rows(0).Item("wordcall").ToString, ds.Tables("app").Rows(0).Item("defpath").ToString)
            wordcall = ds.Tables("app").Rows(0).Item("wordcall").ToString
            pathname = ds.Tables("app").Rows(0).Item("defpath").ToString
            apptype = ds.Tables("app").Rows(0).Item("apptype").ToString
            conpath = ds.Tables("app").Rows(0).Item("conpath").ToString
        End If

        actionschoice.Add("Typing")
        actionschoice.Add("Notepad")

        For a = 1 To voicecommand.Length
            Dim commandinfo() As String = LCase(voicecommand(a - 1)).ToString.Split(" ")
            Try
                actionschoice.Add(commandinfo(0))
            Catch : End Try
            Try
                actionschoice.Add(commandinfo(1))
            Catch : End Try
        Next
        For a = 1 To setalphabet.Length
            Try
                actionschoice.Add(setalphabet(a - 1))
            Catch : End Try
            Try
                actionschoice.Add(setalphabet(a - 1))
            Catch : End Try
        Next

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
    End Sub

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        StopSpeaking()

        sql = "UPDATE tbl_account SET isTutorial='No' WHERE accountuser=?user"
        Dim upacc As New MySqlCommand(sql, con)
        upacc.Parameters.AddWithValue("?user", frmMenu.username)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        upacc.ExecuteNonQuery()
        con.Close()

        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblSkip_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSkip.MouseMove
        If Not MoveIndicator.Tag = "Finish" Then
            lblSkip.ForeColor = Color.LawnGreen
            lblSkip.Font = New Font("Segoe UI Semibold", 10, FontStyle.Underline)
        End If
    End Sub

    Private Sub lblSkip_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSkip.MouseLeave
        lblSkip.ForeColor = Color.White
        lblSkip.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
    End Sub

    Private Sub lblSkip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSkip.Click
        If Not MoveIndicator.Tag = "Finish" Then
            StopSpeaking()

            Try
                rec.RecognizeAsyncStop()
            Catch : End Try

            lblSkip.Visible = False

            If frmNetwork.Visible = True Then
                frmNetwork.isTutorial = "Skip"
                frmNetwork.Animation.Tag = "Hide"
                frmNetwork.Animation.Start()
            End If

            If frmApplication.Visible = True Then
                frmApplication.isTutorial = "Skip"
                frmApplication.Animation.Tag = "Hide"
                frmApplication.Animation.Start()
            End If

            If frmKeyword.Visible = True Then
                frmKeyword.isTutorial = "Skip"
                frmKeyword.Animation.Tag = "Hide"
                frmKeyword.Animation.Start()
            End If

            If frmWord.Visible = True Then
                frmWord.isTutorial = "Skip"
                frmWord.Animation.Tag = "Hide"
                frmWord.Animation.Start()
            End If

            msg = "You have skip the tutorial!"
            MoveIndicator.Tag = "Finish"
            MoveIndicator.Start()
        End If
    End Sub

    Private Sub Panel2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.VisibleChanged
        If Panel2.Visible = True Then
            message = "Now let's try to use the Voice Command.. Please say.. '" & compwordcall & "' 'Open' 'Notepad'"
            lblInstruction.Text = "Now let's try to use the Voice Command.. Please say.. '" & compwordcall & "' 'Open' 'Notepad'"

            Loadmode1()
        End If
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class