Imports System.IO
Imports System.Data.OleDb
Imports System.Data

Public Class keywordsSettings
    Private dt_keywords As DataTable
    Private Sub keywords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOGIN.message = "Keywords allow you to give keyboard commands like up, down, enter, escape, and other keypress. It also enables you to define your own keyboard shortcuts to be executed when called"
        list_keywords()
    End Sub

    Private Sub btn_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register.Click
        If String.IsNullOrEmpty(txt_keyboardpress.Text) And String.IsNullOrEmpty(txt_word.Text) Then
            MessageBox.Show("Blank fields are not allowed")
            Exit Sub
        End If
        'validation if exist
        If exist("SELECT COUNT(keyword) FROM keyword WHERE keyword = ?", New ArrayList() From {sanitize(txt_word.Text)}) Then

            MessageBox.Show("Word already exist")
            Exit Sub
        End If
        'register
        LOGIN.database.query2("INSERT INTO keyword(`keyword`, `word`,`shortcut`, `internal`) VALUES (?,?,?,?)", New ArrayList() From {sanitize(txt_word.Text), sanitize(txt_word.Text), sanitize(txt_keyboardpress.Text), "no"})
        list_keywords()

        'If listview_computers.SelectedItems.Count = 0 Then
        '    MessageBox.Show("Please select computer from the list you wish to remove")
        '    Exit Sub
        'End If
        'If (MessageBox.Show("Are you sure you want to remove this computer? '" + listview_computers.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
        '    Exit Sub
        'End If
        'LOGIN.database.query("DELETE FROM computers WHERE word = '" + listview_computers.SelectedItems(0).SubItems(0).Text + "'")
        'list_computers()

    End Sub
    Private Sub list_keywords()
        LOGIN.database.query("SELECT * FROM keyword WHERE internal = 'no' ORDER BY keyword ASC")
        dt_keywords = New DataTable()
        dt_keywords = LOGIN.database.result

        listview_keywords.Items.Clear()
        For i As Integer = 0 To dt_keywords.Rows.Count - 1
            listview_keywords.Items.Add(dt_keywords.Rows(i)("keyword").ToString())
            listview_keywords.Items(i).SubItems.Add(dt_keywords.Rows(i)("shortcut").ToString())

        Next
    End Sub

    Private Sub listview_keywords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_keywords.Click
        txt_word.Text = listview_keywords.SelectedItems(0).SubItems(0).Text
        txt_keyboardpress.Text = listview_keywords.SelectedItems(0).SubItems(1).Text
    End Sub

    Private Sub listview_keywords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_keywords.SelectedIndexChanged

    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click

        If listview_keywords.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word from the list you wish to remove")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to remove this word? '" + listview_keywords.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query("DELETE FROM keyword WHERE word = '" + listview_keywords.SelectedItems(0).SubItems(0).Text + "'")
        list_keywords()
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click

        If listview_keywords.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select word from the list you wish to update")
            Exit Sub
        End If
        If (MessageBox.Show("Are you sure you want to update this word? '" + listview_keywords.SelectedItems(0).SubItems(0).Text + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        LOGIN.database.query2("UPDATE keyword SET word = ? AND shortcut = ? WHERE word = '" + listview_keywords.SelectedItems(0).SubItems(0).Text + "'", New ArrayList() From {sanitize(txt_word.Text), sanitize(txt_word.Text), sanitize(txt_keyboardpress.Text)})
        list_keywords()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_keyboardpress.Text = ""
        txt_word.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strategy_window.closeWindowReturnDashboard(Me)

    End Sub
End Class