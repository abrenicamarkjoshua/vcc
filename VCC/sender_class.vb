
Imports System.Text
Imports System.Net.Sockets
Imports System.Net
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Speech.Synthesis

Public Class sender_class


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        send_message("close server", "vmpc1")

        'MessageBox.Show("Sent.")

    End Sub
    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal hMsg As Integer, ByVal wparam As Integer, ByVal lparam As Integer) As Integer
    End Function

    Public Sub send_message(ByVal message As String, ByVal address As String)
        Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Dim buffer() As Byte = Encoding.ASCII.GetBytes(message)

        Try
            sock.Connect(address, 82)
        Catch ex As System.Net.Sockets.SocketException
            ' Handle failed connect
            Dim builder As PromptBuilder = New PromptBuilder

            builder.StartVoice(VoiceGender.Female, VoiceAge.Child)
            builder.AppendText("Warning. Computer not detected")
            MessageBox.Show(address & " is disconnected!")
            builder.EndVoice()
            Dim synthesizer = New SpeechSynthesizer()
            synthesizer.Speak(builder)
            synthesizer.Dispose()
            Exit Sub
        End Try
        Try
            sock.Send(buffer)

        Catch ex As System.Net.Sockets.SocketException
            ' Handle failed send
            MessageBox.Show("failed")
            Exit Sub


        End Try
    End Sub
    Private Sub client_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
End Class
