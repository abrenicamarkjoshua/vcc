Imports System.Speech.Synthesis

Public Class BACKEND

    Private Sub BACKEND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'controllers_and_functions.add_enter_events(Me)
        txt_username.Focus()
    End Sub
  
    Private Sub btn_register_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register_user.Click
        'check for blanks
        If has_blanks("all", New List(Of Control) From {txt_username, txt_password, txt_password2}) Then
            Exit Sub
        End If
        'Check if username already exist
        If exist("SELECT COUNT(username) FROM users WHERE username = ?", New ArrayList() From {sanitize(txt_username.Text)}) Then
            MessageBox.Show("Username already exist. Please enter a different name")
            Exit Sub
        End If
        'check if password matches
        If txt_password.Text <> txt_password2.Text Then
            MessageBox.Show("Passwords does not match")
            Exit Sub
        End If

        'ELSE, REGISTER
        LOGIN.database.query2("INSERT INTO users(username, password, user_type) VALUES (?,LEFT(sha1(?),20),'professor')", New ArrayList() From {sanitize(txt_username.Text), sanitize(txt_password.Text)})
        Dim message As String = "User successfully registered. Please relog in to continue"
        LOGIN.message = message
        MessageBox.Show(message)
        LOGIN.Show()
        Me.Close()



    End Sub

    Private Sub btn_save_server_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Me.enable_prompt = False

        My.Settings.Save()
        Me.Close()
        LOGIN.database = New database


    End Sub

    Private Sub txt_username_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_username.KeyPress
        'If Convert.ToInt16(e.KeyChar) = 13 Then
        '    txt_password.Focus()
        'End If
    End Sub

    Private Sub txt_username_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_username.TextChanged

    End Sub

    Private Sub txt_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_password.KeyPress
        'If Convert.ToInt16(e.KeyChar) = 13 Then
        '    txt_password2.Focus()
        'End If

    End Sub

    Private Sub txt_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password.TextChanged

    End Sub

    Private Sub txt_password2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_password2.KeyPress
        'If Convert.ToInt16(e.KeyChar) = 13 Then
        '    btn_register_user.Focus()

        'End If

    End Sub

    Private Sub txt_password2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password2.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        strategy_window.closeWindowReturnLogin(Me)
    End Sub
End Class