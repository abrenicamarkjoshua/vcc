Imports System.Speech.Synthesis
Public Class frmControl
    Public sock As Integer
    Public f As frmMain

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        f.S.Send(sock, "OpenCD")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        f.S.Send(sock, "CloseCD")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        f.S.Send(sock, "DisableKM")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        f.S.Send(sock, "EnableKM")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        f.S.Send(sock, "TurnOnMonitor")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        f.S.Send(sock, "TurnOffMonitor")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        f.S.Send(sock, "NormalMouse")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        f.S.Send(sock, "ReverseMouse")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        f.S.Send(sock, "HideTaskBar")
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        f.S.Send(sock, "ShowTaskBar")
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        f.S.Send(sock, "DisableRestore")
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        f.S.Send(sock, "EnableRestore")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        f.S.Send(sock, "DisableCMD")
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        f.S.Send(sock, "EnableCMD")
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        f.S.Send(sock, "DisableRegistry")
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        f.S.Send(sock, "EnableRegistry")
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        f.S.Send(sock, "DisableTaskManager")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        f.S.Send(sock, "EnableTaskManager")
    End Sub
    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer
    Public isTutorial As String
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
                    builder.AppendText("That you can easily control of Student PC's.")
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

    Private Sub frmControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class