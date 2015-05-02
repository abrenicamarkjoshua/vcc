Public Class wordsettings2

    Private Sub wordsettings2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DASHBOARD.Show()
    End Sub

    Private Sub wordsettings2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub wordsettings2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_programminglanguage()

    End Sub
    Private Sub load_programminglanguage()
        Dim dt_programminglanguage As DataTable = LOGIN.database.query("SELECT DISTINCT(category) FROM type")
        listview_category.Items.Clear()
        cmb_category.Items.Clear()
        For i As Integer = 0 To dt_programminglanguage.Rows.Count - 1
            listview_category.Items.Add(dt_programminglanguage.Rows(i)("category").ToString())
            cmb_category.Items.Add(dt_programminglanguage.Rows(i)("category").ToString())
        Next
    End Sub
    Private Sub refresh_lists()
        load_programminglanguage()
        txt_word.Text = ""
        txt_wordtoprint.Text = ""
        cmb_category.Text = ""
        ListView1.Items.Clear()
    End Sub
    Private Sub load_programminglanguage_words(ByVal category As String)
        'refresh list
        ListView1.Items.Clear()
        'load listview1
        Dim dt_programmingWords As DataTable = LOGIN.database.query("SELECT * FROM type WHERE category = '" & category & "'")
        For i As Integer = 0 To dt_programmingWords.Rows.Count - 1
            ListView1.Items.Add(dt_programmingWords.Rows(i)("word").ToString())
            ListView1.Items(i).SubItems.Add(dt_programmingWords.Rows(i)("print").ToString())
            ListView1.Items(i).SubItems.Add(dt_programmingWords.Rows(i)("enabled").ToString())
            ListView1.Items(i).SubItems.Add(dt_programmingWords.Rows(i)("id").ToString())


        Next
    End Sub

    Private Sub listview_category_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_category.Click
        If listview_category.SelectedItems.Count > 0 Then
            load_programminglanguage_words(listview_category.SelectedItems(0).SubItems(0).Text)

        End If

    End Sub

    Private Sub listview_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_category.SelectedIndexChanged

    End Sub


    Private Sub btn_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register.Click
        'validation of blank fields

        'validation of duplication or already registered in the same category
        If exist("SELECT COUNT(word) FROM type WHERE word = ? AND category = ?", New ArrayList() From {txt_word.Text, cmb_category.Text}) Then
            MessageBox.Show("Word already registered")
            Exit Sub
        End If

        'register
        Dim word As String = txt_word.Text
        Dim toprint As String = txt_wordtoprint.Text
        Dim category As String = cmb_category.Text

        LOGIN.database.query("insert into type(word, print, user_id, enabled, category) VALUES ('" & word & "','" & toprint & "','" & LOGIN.professor.id & "','Yes','" & category & "')")
        MessageBox.Show("Word successfully registered")

        refresh_lists()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If ListView1.SelectedItems.Count > 0 Then
            'prompt
            Try
                Dim prompt As prompt = New prompt()
                If prompt.promptAndClose("Are you sure you want to delete this word?") = VCC.prompt.resultEnum.yes Then
                    'delete
                    LOGIN.database.query("DELETE FROM type WHERE id = '" & ListView1.SelectedItems(0).SubItems(3).Text & "'")
                    MessageBox.Show("Word successfully deleted")
                End If

            Catch ex As Exception

            End Try

        Else
            MessageBox.Show("Please select a word from the word list")
        End If
        refresh_lists()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'throw error if no word is selected
        If listview_category.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a category or programming language from the list")
            Exit Sub
        End If

        'set other programming language as inactive
        LOGIN.database.query("UPDATE type SET enabled = 'no'")
        'set selected category as active
        LOGIN.database.query("UPDATE type SET enabled = 'Yes' WHERE category = '" & listview_category.SelectedItems(0).SubItems(0).Text & "'")
        MessageBox.Show("Selected category has been enabled. other category has been disabled.")
    End Sub
End Class