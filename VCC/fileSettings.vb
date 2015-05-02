
Public Class fileSettings
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click

        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lbl_parameter.Text = ofd.FileName
        End If
        If ofd.FileName.Contains(".docx") Then
            select_applicationType.Text = "C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.EXE"
        ElseIf ofd.FileName.Contains(".pptx") Then
            select_applicationType.Text = "C:\Program Files (x86)\Microsoft Office\Office12\POWERPNT.EXE"
        ElseIf ofd.FileName.Contains(".sln") Then
            select_applicationType.Text = "F:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"
        ElseIf ofd.FileName.Contains(".html") Then
            select_applicationType.Text = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        Else
            select_applicationType.Text = ""
        End If
    End Sub


    Private Sub wordsDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_words_to_list()
        load_select_application_type()

    End Sub
    Private Sub load_select_application_type()
        Dim result As DataTable = LOGIN.database.query("SELECT DISTINCT application_type FROM words")
        For i = 0 To result.Rows.Count - 1
            select_applicationType.Items.Add(result.Rows(i)(0).ToString())

        Next
    End Sub
  
    Public Sub load_words_to_list(ByVal query As String, ByVal parameters As ArrayList)
        list_words.Items.Clear()
        LOGIN.database.query2(query, parameters)

        For i = 0 To LOGIN.database.dt.Rows.Count - 1
            With list_words.Items.Add(LOGIN.database.dt.Rows(i)("word").ToString())
                .SubItems.Add(LOGIN.database.dt.Rows(i)("parameter").ToString())
                .SubItems.Add(LOGIN.database.dt.Rows(i)("application_type").ToString())
            End With


        Next


    End Sub
    Public Sub load_words_to_list()
        list_words.Items.Clear()
        LOGIN.database.query("SELECT * FROM words")

        For i = 0 To LOGIN.database.dt.Rows.Count - 1
            With list_words.Items.Add(LOGIN.database.dt.Rows(i)("word").ToString())
                .SubItems.Add(LOGIN.database.dt.Rows(i)("parameter").ToString())
                .SubItems.Add(LOGIN.database.dt.Rows(i)("application_type").ToString())
            End With
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If list_words.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word from the list to delete")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to delete this word '" + list_words.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        'delete
        LOGIN.database.query2("DELETE FROM words WHERE word = ?", New ArrayList() From {list_words.SelectedItems(0).SubItems(0).Text})


        load_words_to_list("SELECT * FROM words WHERE word like ?", New ArrayList() From {"%%"})
        MessageBox.Show("Word successfully deleted")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If exist("SELECT COUNT(word) FROM words WHERE word = ?", New ArrayList() From {txt_word.Text}) Then
            MessageBox.Show("That word is already registered")
            Exit Sub
        End If
        Dim application_path As String = select_applicationType.Text
        'LOGIN.database.query("SELECT * FROM application_settings")
        'For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
        '    If select_applicationType.Text = LOGIN.database.dt.Rows(i)("application_name").ToString() Then
        '        application_path = LOGIN.database.dt.Rows(i)("application_path").ToString()
        '        If String.IsNullOrEmpty(application_path) Then
        '            application_path = lbl_parameter.Text
        '        End If
        '    End If
        'Next

        register_open_close_command(New ArrayList() From {txt_word.Text, "Yes", "open", lbl_parameter.Text, application_path, select_applicationType.Text})
        MessageBox.Show("Word successfully registered")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub register_open_close_command(ByVal parameters_values As ArrayList)

        LOGIN.database.query2("INSERT INTO words(`word`,`active`,`action`,`parameter`,`application_path`,`application_type`) VALUES (?,?,?,?,?,?)", parameters_values)
        load_words_to_list()

    End Sub
    Private Sub update_open_close_command(ByVal parameters_values As ArrayList)

        LOGIN.database.query2("UPDATE words SET `word` = ?,`active` = ?,`action` = ?,`parameter` = ?,`application_path` = ?,`application_type` = ? WHERE word = '" + list_words.SelectedItems.Item(0).SubItems(0).Text + "'", parameters_values)
        load_words_to_list()

    End Sub

    Private Sub list_words_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_words.SelectedIndexChanged
        If list_words.SelectedItems.Count > 0 Then
            txt_word.Text = list_words.SelectedItems.Item(0).SubItems(0).Text
            lbl_parameter.Text = list_words.SelectedItems.Item(0).SubItems(1).Text
            select_applicationType.Text = list_words.SelectedItems.Item(0).SubItems(2).Text
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If list_words.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word from the list to update")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to update this word? '" + list_words.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        Dim application_path As String = ""
        Select Case select_applicationType.Text
            Case "WORD"
                LOGIN.database.query("SELECT application_path FROM application_settings WHERE word = 'WORD'")

                application_path = LOGIN.database.dt.Rows(0)("application_path").ToString()
            Case "application"
                application_path = lbl_parameter.Text
                'continue to add this. return here
            Case "VISUAL STUDIO"
                LOGIN.database.query("SELECT application_path FROM application_settings WHERE application_name = 'VISUAL STUDIO'")

                application_path = LOGIN.database.dt.Rows(0)("application_path").ToString()
            Case "notepad"
                LOGIN.database.query("SELECT application_path FROM application_settings WHERE application_name = 'NOTEPAD'")
                application_path = LOGIN.database.dt.Rows(0)("application_path").ToString()

        End Select
        update_open_close_command(New ArrayList() From {txt_word.Text, "Yes", "open", lbl_parameter.Text, application_path, select_applicationType.Text})
        MessageBox.Show("Word successfully updated")
        btn_clear_Click(sender, e)

    End Sub


    Private Sub open_close_command_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'select_applicationType.Items.Clear()
        'LOGIN.database.query("SELECT * FROM application_settings")
        'For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
        '    select_applicationType.Items.Add(LOGIN.database.dt.Rows(i)("application_name").ToString())

        'Next

    End Sub

    Private Sub lbl_parameter_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_parameter.MouseHover

        ToolTip1.Show(lbl_parameter.Text, Me)


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If ofd2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            select_applicationType.Text = ofd2.FileName
        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        lbl_parameter.Text = ""
        select_applicationType.Text = ""
        txt_word.Text = ""

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        strategy_window.closeWindowReturnDashboard(Me)
    End Sub
End Class