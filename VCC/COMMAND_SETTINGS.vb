Public Class COMMAND_SETTINGS

    Private Sub COMMAND_SETTINGS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load datagridview to show all voice commands
        load_all_registered_commands()

    End Sub

    Private Sub load_all_registered_commands()
        LOGIN.database.query2("SELECT Phrase, command_type as 'command type' FROM voice_commands WHERE user = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("id").ToString()})
        dg1.DataSource = LOGIN.database.result

    End Sub
    Private Sub COMMAND_SETTINGS_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DASHBOARD2.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        new_command.ShowDialog(Me)

    End Sub

    Private Sub cmb_command_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class