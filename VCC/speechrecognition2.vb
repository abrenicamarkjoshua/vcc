Imports System.Speech.Recognition

Public Class speechrecognition2
    Public WithEvents _recognizer As New System.Speech.Recognition.SpeechRecognitionEngine

    Private Sub speechrecognition2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim recognizer As SpeechRecognitionEngine = New SpeechRecognitionEngine(New System.Globalization.CultureInfo("en-US"))


        'Create and load a dictation grammar.
        recognizer.LoadGrammar(New DictationGrammar())

        'Add a handler for the speech recognized event.
        AddHandler recognizer.SpeechRecognized, AddressOf recognizer_SpeechRecognized

        'Configure input to the speech recognizer.
        recognizer.SetInputToDefaultAudioDevice()

        'Start asynchronous, continuous speech recognition.
        recognizer.RecognizeAsync(RecognizeMode.Multiple)

        'Keep the console window open.
    End Sub
    Public Sub recognizer_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        MessageBox.Show("TEXT IS: " + e.Result.Text)
        If e.Result.Text.Contains("testing") Then
            MessageBox.Show("correct. testing")
        End If
    End Sub



End Class