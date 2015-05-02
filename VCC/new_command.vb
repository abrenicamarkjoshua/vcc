Public Class new_command

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Select Case cmb_command_type.Text
            Case "closing window"

            Case "entering dictation mode"
            Case "lock pc"
            Case "openning of files remotely"
            Case "openning of files"
                Dim openning_of_files As openning_of_files = New openning_of_files("register", txt_command_phrase.Text)
                openning_of_files.ShowDialog(Me)

            Case "share desktop"
            Case "tell date"
            Case "tell reamining time"
            Case "tell time"
            Case "unlock pc"
            Case "word to text"

        End Select
    End Sub

    Private Sub new_command_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_all_command_type()
    End Sub
    Private Sub load_all_command_type()
        LOGIN.database.query("SELECT command FROM command_type")
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            cmb_command_type.Items.Add(LOGIN.database.result.Rows(i)("command").ToString())
        Next

    End Sub

    Private Sub cmb_command_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_command_type.SelectedIndexChanged

    End Sub
End Class