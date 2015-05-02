Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.Speech.Recognition

Public Class frmVoice
    Public isTutorial As String
    Private gr As New GrammarBuilder

    Public computerdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public defaultdic As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public actiondic As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private worddic As New Dictionary(Of String, String)

    Public Declare Function BringWindowToTop Lib "user32" (ByVal HWnd As IntPtr) As Boolean
    Public WithEvents rec As New System.Speech.Recognition.SpeechRecognitionEngine

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If Me.Tag = "Mode 1" Then
            If computerdic.ContainsKey(e.Result.Words(0).Text) Then
                If e.Result.Words(1).Text = "Open" Then
                    If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                        sql = "INSERT INTO tbl_commandpc VALUES(?ip,?command)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?ip", computerdic(e.Result.Words(0).Text))
                        addcomm.Parameters.AddWithValue("?command", actiondic(e.Result.Words(2).Text))

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()

                        lblFeedback.Text = "Open " & e.Result.Words(2).Text
                        lblCommand.Text = e.Result.Text

                        builder = New PromptBuilder()
                        builder.StartVoice(VoiceGender.Male)
                        builder.AppendText("Now to close a program, you'll just say '" & My.Computer.Name & "' 'Close' '" & e.Result.Words(2).Text & "'")
                        builder.EndVoice()
                        synthesizer = New SpeechSynthesizer()
                        synthesizer.Speak(builder)
                        synthesizer.Dispose()
                        Exit Sub
                    End If
                ElseIf e.Result.Words(1).Text = "Close" Then
                    If actiondic.ContainsKey(e.Result.Words(2).Text) Then
                        Dim appname As String() = actiondic(e.Result.Words(2).Text).Split("\")

                        sql = "INSERT INTO tbl_commandpc VALUES(?ip,?command)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?ip", computerdic(e.Result.Words(0).Text))
                        addcomm.Parameters.AddWithValue("?command", "close|" & appname(appname.Count - 1))

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()

                        lblFeedback.Text = "Close " & e.Result.Words(2).Text
                        lblCommand.Text = e.Result.Text

                        builder = New PromptBuilder()
                        builder.StartVoice(VoiceGender.Male)
                        builder.AppendText("Now that is the basic of voice command. To know all the commands check the 'Help' button on the User Account Panel.")
                        builder.EndVoice()
                        synthesizer = New SpeechSynthesizer()
                        synthesizer.Speak(builder)
                        synthesizer.Dispose()

                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub frmVoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isTutorial = "Yes" Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer

    Sub Loadmode1()
        Me.Tag = "Mode 1"
        rec.RecognizeAsyncStop()
        rec.UnloadAllGrammars()

        Dim computerschoice As New Choices()
        computerdic = New Dictionary(Of String, String)

        computerschoice.Add(My.Computer.Name)

        defaultdic = New Dictionary(Of String, String)
        Dim defaultschoice As New Choices()

        '~~> List all the Default Keywords for PC Commands
        Dim defstr() As String = {"Open", "Close"}

        For Each def In defstr
            defaultschoice.Add(def)
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
        End If

        gr = New GrammarBuilder

        gr.Append(computerschoice)
        gr.Append(defaultschoice)
        gr.Append(actionschoice)

        Dim mygram As New Grammar(gr)

        rec.LoadGrammar(mygram)
        rec.SetInputToDefaultAudioDevice()
        rec.RecognizeAsync(1)

        builder = New PromptBuilder()
        builder.StartVoice(VoiceGender.Male)
        builder.AppendText("Listening")
        lblTitle.Text = "Listening . . ."
        builder.EndVoice()
        synthesizer = New SpeechSynthesizer()
        synthesizer.Speak(builder)
        synthesizer.Dispose()

        builder = New PromptBuilder()
        builder.StartVoice(VoiceGender.Male)
        builder.AppendText("To open a registered application, you'll just say '" & My.Computer.Name & "' 'Open' '" & ds.Tables("app").Rows(0).Item("wordcall").ToString & "'")
        builder.EndVoice()
        synthesizer = New SpeechSynthesizer()
        synthesizer.Speak(builder)
        synthesizer.Dispose()
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                If isTutorial = "Yes" Then
                    builder = New PromptBuilder()
                    builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
                    builder.AppendText("Now let's try to use the voice command. Let's try to Open an Application you first registered.")
                    builder.EndVoice()
                    synthesizer = New SpeechSynthesizer()
                    synthesizer.Speak(builder)
                    synthesizer.Dispose()
                End If

                Loadmode1()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                If isTutorial = "No" Then
                    frmMenu.Show()
                Else
                    frmTutorial.msg = "Tutorial complete!"
                    frmTutorial.MoveIndicator.Tag = "Finish"
                    frmTutorial.MoveIndicator.Start()
                End If

                Me.Close()
            End If
        End If
    End Sub

End Class