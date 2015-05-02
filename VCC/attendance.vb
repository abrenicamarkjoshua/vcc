Public Class attendance

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim datasource As DataTable
        LOGIN.database.query2("SELECT * FROM attendance WHERE student_name in (SELECT student_name FROM student_section  WHERE professor_name = ? AND section = ? AND subject = ?) AND date = ?", New ArrayList() From {LOGIN.user_info.Rows(0)("username").ToString(), LOGIN.section, LOGIN.subj, DateTimePicker1.Value.ToString("yyyy-MM-dd")})
        datasource = LOGIN.database.result
        DataGridView1.DataSource = datasource
        DataGridView1.Refresh()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select record from the attendance list")
            Exit Sub
        End If

        Dim datefolder As String = (CDate(DataGridView1.SelectedRows.Item(0).Cells(1).Value).ToString("yyyy-MM-dd"))
        'Student Activity\BSIT CT 4A-PROGRAMMING 2\2015-02-09\14-0002
        Dim studentnumberfolder As String = DataGridView1.SelectedRows.Item(0).Cells(3).Value
        Dim sectionfolder As String = DataGridView1.SelectedRows.Item(0).Cells(6).Value
        Dim subjectfolder As String = DataGridView1.SelectedRows.Item(0).Cells(7).Value

        If DataGridView1.SelectedRows.Item(0).Cells(5).Value = "yes" Then
            Dim directory As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & sectionfolder & "-" & subjectfolder & "\" & datefolder & "\" & studentnumberfolder
            Process.Start("explorer.exe", directory)
        Else
            MessageBox.Show("Student has no activity.")
        End If
    End Sub

    Private Sub attendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class