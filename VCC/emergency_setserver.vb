Public Class emergency_setserver
    Public emergency_exit_allow As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.server = txt_setserver.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub emergency_setserver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_setserver.Text = My.Settings.server
        txt_password.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If My.Settings.default_password = hash(txt_password.Text, 10) And txt_username.Text = "default" Then
            emergency_exit_allow = True
            Me.Close()

        Else
            MessageBox.Show("EMERGENCY EXIT DENIED.")
        End If
       
    End Sub

    Private Sub emergency_setserver_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txt_password.Text = ""
        txt_username.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox1.Visible = True

    End Sub
End Class