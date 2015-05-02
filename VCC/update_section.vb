Public Class update_section

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'check blanks

        'update
        ' LOGIN.database.query2("UPDATE sections SET section = ?, SUBJECT =?, schedule_day = ?, schedule_time =? WHERE id = ?", New ArrayList() From {sanitize(txt_section.Text), sanitize(txt_subject.Text), ComboBox1.Text, sanitize(txt_time.Text), lbl_id.Text})
        'prompt
        Dim id As String = lbl_id.Text

        Dim timein As String = datetime_timein.Value.ToString("HH:mm:ss")
        Dim timeout As String = datetime_timeout.Value.ToString("HH:mm:ss")
        Dim accessCode As String = txt_accesscode.Text
        LOGIN.database.query2("UPDATE schedule SET day = ?, timein = ?, timeout = ? WHERE id = ?", New ArrayList() From {ComboBox1.Text, timein, timeout, id})
        LOGIN.database.query2("UPDATE sections SET section = ?, subject = ?, access_code = ? WHERE schedule_id = ?", New ArrayList() From {txt_section.Text, txt_subject.Text, accessCode, id})

        MessageBox.Show("Section successfully updated!")

        Me.Close()

    End Sub
End Class