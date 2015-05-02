Public Class studentslist

    Private Sub studentslist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOGIN.database.query2("SELECT section,subject FROM student_section WHERE professor_name = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("username").ToString()})
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            Dim section As String = LOGIN.database.result.Rows(i)(0).ToString()
            Dim subject As String = LOGIN.database.result.Rows(i)(1).ToString()
            If ComboBox1.Items.Contains(section + "-" + subject) = False Then
                ComboBox1.Items.Add(section + "-" + subject)

            End If

        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(ComboBox1.Text) Then
            MessageBox.Show("Please select a section from the drop down menu to view it's registered students")
            Exit Sub
        End If
        Dim sectionsubject As Array = ComboBox1.Text.Split("-")
        Dim section As String = sectionsubject(0)
        Dim subject As String = sectionsubject(1)
        LOGIN.database.query2("SELECT student_name  FROM student_section, students  WHERE professor_name = ? AND section = ? AND subject = ? AND student_section.student_id = students.student_id", New ArrayList() From {LOGIN.user_info.Rows(0)("username").ToString(), section, subject})
        DataGridView1.DataSource = LOGIN.database.result
        DataGridView1.Refresh()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class