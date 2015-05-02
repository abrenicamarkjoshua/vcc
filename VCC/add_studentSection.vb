Public Class add_studentSection

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strategy_window.closeWindowNoPrompt(Me)
    End Sub
    Private Sub refresh_lists()
        'load all professor's sections
        listview_sections.Items.Clear()

        LOGIN.database.query("SELECT sections.*, sections.id as TblSections_id, schedule.*, schedule.id as TblSchedule_id FROM sections, schedule WHERE sections.schedule_id = schedule.id")
        Dim dt_section As DataTable

        dt_section = LOGIN.database.result
        For i As Integer = 0 To dt_section.Rows.Count - 1
            listview_sections.Items.Add(dt_section.Rows(i)("section").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("subject").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("day").ToString())
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timein").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timeout").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("professor_name").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("TblSections_id").ToString())
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        refresh_lists()

    End Sub

    Private Sub add_studentSection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refresh_lists()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If listview_sections.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a subject schedule from the list")
            Exit Sub
        End If
        Dim checktimein As String = datetime_timein.Value.AddSeconds(1).ToString("HH:mm:ss")
        Dim checktimeout As String = datetime_timeout.Value.AddSeconds(-1).ToString("HH:mm:ss")
        LOGIN.database.query2("SELECT * from student_section  WHERE student_id = ? AND day = ? AND time(?) BETWEEN timein and timeout",
                              New ArrayList() From {LOGIN.student.id, listview_sections.SelectedItems(0).SubItems(2).Text, checktimein})
        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt") & " under section: " & LOGIN.database.result(0)("section").ToString())
            Exit Sub
        End If

        LOGIN.database.query2("SELECT * from student_section WHERE student_id = ? AND day = ? AND time(?) BETWEEN timein and timeout",
                              New ArrayList() From {LOGIN.student.id, listview_sections.SelectedItems(0).SubItems(2).Text, checktimeout})
        If (LOGIN.database.result.Rows.Count > 0) Then
            MessageBox.Show("Schedule conflict in the same day with subject: " & LOGIN.database.result(0)("subject").ToString() & " with timein of : " & DateTime.Parse(LOGIN.database.result(0)("timein").ToString()).ToString("hh:mm tt") & " and timeout of " & DateTime.Parse(LOGIN.database.result(0)("timeout").ToString()).ToString("hh:mm tt"))
            Exit Sub
        End If
        Dim addsection As add_section_with_access_code = New add_section_with_access_code()
        LOGIN.database.query2("SELECT access_code FROM sections WHERE id = ?", New ArrayList() From {listview_sections.SelectedItems(0).SubItems(6).Text})

        addsection.accesscode = LOGIN.database.result().Rows(0)("access_code").ToString()
        addsection.ShowDialog()
        If addsection.result = True Then
            LOGIN.database.query2("INSERT INTO student_section(`student_id`,`section`,`subject`,`day`,`timein`,`timeout`,`professor_name`) VALUES (?,?,?,?,time(?),time(?),?)", New ArrayList() From {LOGIN.student.id, listview_sections.SelectedItems(0).SubItems(0).Text, listview_sections.SelectedItems(0).SubItems(1).Text, listview_sections.SelectedItems(0).SubItems(2).Text, listview_sections.SelectedItems(0).SubItems(3).Text, listview_sections.SelectedItems(0).SubItems(4).Text, listview_sections.SelectedItems(0).SubItems(5).Text})
            prompt.message("Section with schedule successfully added!")
        End If
        addsection.Dispose()

    End Sub

    Private Sub listview_sections_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_sections.Click
        datetime_timein.Text = listview_sections.SelectedItems(0).SubItems(3).Text
        datetime_timeout.Text = listview_sections.SelectedItems(0).SubItems(4).Text

    End Sub

    Private Sub listview_sections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_sections.SelectedIndexChanged

    End Sub
End Class