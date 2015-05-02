
Imports System.Speech.Synthesis

Public Class SetTimer


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Public Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Try
            DASHBOARD.timeleft = New TimeSpan(0, txt_minutes.Text, 0)
            DASHBOARD.lbl_timeleft.Text = DASHBOARD.timeleft.ToString()
            Dim builder As PromptBuilder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("timer set")
            builder.EndVoice()
            Dim synthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)

            Me.Close()
        Catch ex As Exception
            Dim builder As PromptBuilder = New PromptBuilder()
            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("Please enter correct number of minutes")
            builder.EndVoice()
            Dim synthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)
            Exit Sub
        End Try
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btn_close_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
