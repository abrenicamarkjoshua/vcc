Imports System.Speech.Synthesis

Public Class speaker
    Private _message As String

    Public Property Message As String
        Get
            Return Me._message
        End Get
        Set(ByVal value As String)
            Me._message = value
            thread_speak(value)
        End Set
    End Property
    Public Sub thread_speak(ByVal message As String)
        Dim builder As PromptBuilder = New PromptBuilder()
        builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
        builder.AppendText(message)

        builder.EndVoice()
        Dim synthesizer As SpeechSynthesizer = New SpeechSynthesizer()
        synthesizer.Speak(builder)
        synthesizer.Dispose()
    End Sub

    Private Sub speaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class