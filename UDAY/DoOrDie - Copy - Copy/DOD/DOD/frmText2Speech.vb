Imports System.Speech.Synthesis
Public Class frmText2Speech

    Public sock As Integer
    Public isTutorial As String

    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmMain.S.Send(sock, "TextToSpeech" & frmMain.Yy & TextBox1.Text)
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
                    builder.AppendText("that covert to text to speech .")
                    builder.EndVoice()
                    synthesizer = New SpeechSynthesizer()
                    synthesizer.Speak(builder)
                    synthesizer.Dispose()
                End If

                'LoadApps()
                'LoadAppType()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                If isTutorial = "No" Then
                    frmMenu.Show()
                ElseIf isTutorial = "Skip" Then
                Else
                    frmTutorial.MoveIndicator.Tag = "Keyword"
                    frmTutorial.MoveIndicator.Start()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
    End Sub

End Class