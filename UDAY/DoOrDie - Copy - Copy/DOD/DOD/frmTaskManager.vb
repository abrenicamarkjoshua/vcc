Imports System.Speech.Synthesis
Public Class frmTaskManager
    Public sock As Integer

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        ListView1.Items.Clear()
        frmMain.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub KillProcesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillProcesToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        frmMain.S.Send(sock, "KillProcess" & frmMain.Yy & allprocess)
        RefreshToolStripMenuItem.PerformClick()
    End Sub
    Public isTutorial As String

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
                    builder.AppendText("In Remote Access Control, that you can easily manipulate Student PC's if ever the system was hang.")
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
End Class