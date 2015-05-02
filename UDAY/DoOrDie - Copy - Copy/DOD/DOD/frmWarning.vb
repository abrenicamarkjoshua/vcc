Imports MySql.Data.MySqlClient

Public Class frmWarning

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Private Sub frmWarning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 10
        Me.Top = My.Computer.Screen.Bounds.Height - 260

        GetTime.Start()

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
            Else
                Animation.Stop()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
            Else
                Animation.Stop()
                GetTime.Stop()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub GetTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetTime.Tick
        lblTime.Text = frmLock.lblTime.Text
    End Sub

End Class