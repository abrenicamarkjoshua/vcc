Public Class student_add_section

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'check for blanks
        If has_blanks("all", New List(Of Control) From {cmb_professor, cmb_section, cmb_subject}) Then
            Exit Sub
        End If
        'check if already registered
        Dim student_id As String = LOGIN.user_info.Rows(0)("student_id").ToString()
        Dim section As String = cmb_section.Text
        Dim subject As String = cmb_subject.Text
        Dim professor As String = cmb_professor.Text
        If exist("SELECT COUNT(id) FROM student_section WHERE student_id = ? AND section = ? AND subject = ?  AND professor_name = ?", New ArrayList() From {student_id, section, subject, professor}) Then
            MessageBox.Show("Section/subject already registered in your account")
            Exit Sub
        End If
        'else, register.
        LOGIN.database.query2("INSERT INTO student_section(student_id, section, subject, professor_name) VALUES (?,?,?,?)", New ArrayList() From {student_id, section, subject, professor})
        MessageBox.Show("Subject successfully registered in your account!")

    End Sub

    Private Sub student_add_section_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clear other combo box. this function serve also as refresh
        cmb_professor.Items.Clear()
        cmb_section.Items.Clear()
        cmb_subject.Items.Clear()

        'load cmb_subjects and cmb_sections
        LOGIN.database.query("SELECT DISTINCT(section) FROM sections")
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            cmb_section.Items.Add(LOGIN.database.result.Rows(i)("section"))

        Next
       

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        student_add_section_Load(sender, e)

    End Sub

    Private Sub cmb_section_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_section.SelectedIndexChanged
        Dim section As String = cmb_section.Text
        cmb_subject.Items.Clear()
        LOGIN.database.query("SELECT DISTINCT subject FROM sections WHERE section = '" + section + "'")
        Dim result As DataTable = LOGIN.database.result


        For i As Integer = 0 To result.Rows.Count - 1
            cmb_subject.Items.Add(result.Rows(i)("subject").ToString())
        Next
    End Sub

    Private Sub cmb_subject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_subject.SelectedIndexChanged
        Dim section As String = cmb_section.Text
        Dim subject As String = cmb_subject.Text
        cmb_professor.Items.Clear()
        LOGIN.database.query("SELECT DISTINCT professor_name FROM sections WHERE section = '" + section + "' AND subject = '" + subject + "'")
        For i As Integer = 0 To LOGIN.database.result.Rows.Count - 1
            cmb_professor.Items.Add(LOGIN.database.result.Rows(i)("professor_name").ToString())
        Next
    End Sub
End Class