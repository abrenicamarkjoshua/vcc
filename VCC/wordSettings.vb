Public Class WordSettings
    Private Sub wordSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        list_inactivewords()
        list_activewords()

    End Sub
    Private Sub list_inactivewords()
        listview_inactivewords.Items.Clear()
        LOGIN.database.query("SELECT * FROM type WHERE enabled = 'no'")
        For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
            Dim word As String = LOGIN.database.dt.Rows(i)("word").ToString()
            listview_inactivewords.Items.Add(word)
            Dim printword As String = LOGIN.database.dt.Rows(i)("print").ToString()
            listview_inactivewords.Items(i).SubItems.Add(printword)
        Next
    End Sub
    Private Sub list_activewords()

        listview_activewords.Items.Clear()
        LOGIN.database.query("SELECT * FROM type WHERE enabled = 'yes'")
        For i As Integer = 0 To LOGIN.database.dt.Rows.Count - 1
            listview_activewords.Items.Add(LOGIN.database.dt.Rows(i)("word").ToString())
            listview_activewords.Items(i).SubItems.Add(LOGIN.database.dt.Rows(i)("print").ToString())
        Next

    End Sub

    Private Sub btn_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register.Click
        If exist("SELECT COUNT(word) FROM type WHERE word = ?", New ArrayList() From {txt_word.Text}) Then
            MessageBox.Show("That word is already registered")
            Exit Sub
        End If
        LOGIN.database.query2("INSERT INTO type(`word`,`print`,`enabled`) VALUES (?,?,?)", New ArrayList() From {txt_word.Text, txt_wordtoprint.Text, "Yes"})
        list_activewords()

        list_inactivewords()
        MessageBox.Show("word added successfully")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_activate.Click
        If listview_inactivewords.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word you wish to enable from the lists")
            Exit Sub
        End If
        LOGIN.database.query2("UPDATE type SET enabled = 'Yes' WHERE word = ?", New ArrayList() From {listview_inactivewords.SelectedItems(0).SubItems(0).Text})
        list_activewords()
        list_inactivewords()
        btn_activate.Enabled = False
        btn_deactivate.Enabled = False
        MessageBox.Show("word activated successfully")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deactivate.Click
        If listview_activewords.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word you wish to disable from the active words list")
            Exit Sub
        End If
        LOGIN.database.query2("UPDATE type SET enabled = 'No' WHERE word = ?", New ArrayList() From {listview_activewords.SelectedItems(0).SubItems(0).Text})
        list_activewords()
        list_inactivewords()
        btn_activate.Enabled = False
        btn_deactivate.Enabled = False
        MessageBox.Show("word deactivated successfully")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_word.Text = ""
        txt_wordtoprint.Text = ""
        list_activewords()
        list_inactivewords()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (listview_activewords.SelectedItems.Count = 0 And listview_inactivewords.SelectedItems.Count = 0) Then
            MessageBox.Show("Please select word from the lists to update")
            Exit Sub
        End If
        If (listview_activewords.SelectedItems.Count > 0) Then
            LOGIN.database.query2("UPDATE type SET word = ?, print = ? WHERE word = ? ", New ArrayList() From {txt_word.Text, txt_wordtoprint.Text, listview_activewords.SelectedItems(0).SubItems(0).Text})
        ElseIf (listview_inactivewords.SelectedItems.Count > 0) Then
            LOGIN.database.query2("UPDATE type SET word = ?, print = ? WHERE word = ? ", New ArrayList() From {txt_word.Text, txt_wordtoprint.Text, listview_inactivewords.SelectedItems(0).SubItems(0).Text})


        End If

        list_activewords()
        list_inactivewords()
        MessageBox.Show("Update successful!")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If (listview_activewords.SelectedItems.Count = 0 And listview_inactivewords.SelectedItems.Count = 0) Then
            MessageBox.Show("Please select word from the lists to delete")
            Exit Sub
        End If
        If (listview_activewords.SelectedItems.Count > 0) Then
            LOGIN.database.query2("DELETE FROM type WHERE word = ?", New ArrayList() From {listview_activewords.SelectedItems(0).SubItems(0).Text})
        ElseIf (listview_inactivewords.SelectedItems.Count > 0) Then
            LOGIN.database.query2("DELETE FROM type WHERE word = ?", New ArrayList() From {listview_inactivewords.SelectedItems(0).SubItems(0).Text})

        End If
        list_activewords()
        list_inactivewords()
        MessageBox.Show("Deletion successful")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub listview_activewords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_activewords.Click
        txt_word.Text = listview_activewords.SelectedItems(0).SubItems(0).Text
        txt_wordtoprint.Text = listview_activewords.SelectedItems(0).SubItems(1).Text
        If (listview_inactivewords.SelectedItems.Count > 0) Then
            listview_inactivewords.SelectedItems(0).Selected = False
        End If
        lbl_word.Text = txt_word.Text
        btn_deactivate.Enabled = True
        btn_activate.Enabled = False
    End Sub

    Private Sub listview_activewords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_activewords.SelectedIndexChanged

    End Sub

    Private Sub listview_inactivewords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_inactivewords.Click
        txt_word.Text = listview_inactivewords.SelectedItems(0).SubItems(0).Text
        txt_wordtoprint.Text = listview_inactivewords.SelectedItems(0).SubItems(1).Text
        If (listview_activewords.SelectedItems.Count > 0) Then
            listview_activewords.SelectedItems(0).Selected = False
        End If
        lbl_word.Text = txt_word.Text
        btn_deactivate.Enabled = False
        btn_activate.Enabled = True
    End Sub

    Private Sub listview_inactivewords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_inactivewords.SelectedIndexChanged

    End Sub

    Private Sub btn_delete_all_active_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_all_active.Click
        If (MessageBox.Show("Are you sure you want to delete all active words?. Please click 'yes' to confirm", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query("DELETE FROM type  WHERE enabled = 'Yes'")
        list_activewords()
        btn_activate.Enabled = False
        btn_deactivate.Enabled = False
        MessageBox.Show("All active words deleted successfully")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub btn_delete_all_inactive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_all_inactive.Click
        If (MessageBox.Show("Are you sure you want to delete all inactive words?. Please click 'yes' to confirm", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query("DELETE FROM type  WHERE enabled = 'No'")
        list_inactivewords()
        btn_activate.Enabled = False
        btn_deactivate.Enabled = False
        MessageBox.Show("All inactive words deleted successfully")
        btn_clear_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        strategy_window.closeWindowReturnDashboard(Me)
    End Sub
End Class