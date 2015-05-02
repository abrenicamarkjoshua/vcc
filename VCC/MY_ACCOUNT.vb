
Imports System.IO

Public Class MY_ACCOUNT
    Private user_info As DataTable = New DataTable
    Private dt_section As DataTable = New DataTable
    Private dt_subject As DataTable = New DataTable
    Private dt_students As DataTable = New DataTable
    Public selsubject, selsection As String
    Public openedInDashboard As Boolean = False

    
    'Protected Overrides Sub template1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
    '    If enable_prompt = True Then
    '        'Do not exit until you select a section-subject
    '        If String.IsNullOrEmpty(LOGIN.setsection) Then
    '            MsgBox("Please select a section and subject that you want to set as your section for today", MsgBoxStyle.Critical, "Select Subject/Section")
    '            e.Cancel = True
    '            Exit Sub

    '        End If
    '        If (MessageBox.Show("Are you sure you want to close?. Please click 'yes' to confirm", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
    '            e.Cancel = True
    '            Exit Sub
    '        End If
    '    End If

    '    'fadeout
    '    If enable_fadein = True Then
    '        Dim position As Integer = Me.Top + 20
    '        For i As Decimal = 1 To 0 Step -0.05
    '            Me.Opacity = i
    '            Threading.Thread.Sleep(1)
    '            position = position - 1
    '            Me.Top = position
    '            Application.DoEvents()
    '        Next

    '    End If
    '    'For Each frm As Form In Application.OpenForms
    '    '    If frm.Name = "DASHBOARD" Then
    '    '        frm.Show()
    '    '    End If

    '    'Next




    'End Sub
    Private Sub tutorial()
        'LOGIN.message = "In the 'my account' settings, you add sections and their subjects. Here you set what section and subject is active to create the folders"

        ToolTip1.Show("STEP1. ADD A SECTION AND SUBJECT", Me.Button1, 3600000)
        ToolTip2.Show("STEP2. SELECT THE SECTION FROM THE LIST", Me.listview_sections, 3600000)
        ToolTip4.Show("FINAL STEP. CLICK SET SECTION. AFTER THIS, YOU MAY NOW CLOSE THIS WINDOW", Me.Button2, 3600000)

        ToolTip1.Show("STEP1. ADD A SECTION AND SUBJECT", Me.Button1, 3600000)
        ToolTip2.Show("STEP2. SELECT THE SECTION FROM THE LIST", Me.listview_sections, 3600000)
       ToolTip4.Show("FINAL STEP. CLICK SET SECTION. AFTER THIS, YOU MAY NOW CLOSE THIS WINDOW", Me.Button2, 3600000)


        LOGIN.message = "Here, you add sections and their subjects. You also set what section and subject is active to create the folders"

    End Sub
    Public Sub MY_ACCOUNT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_section.Text = LOGIN.setsection
        draggable = False

        Me.user_info = LOGIN.user_info
        LBL_USERNAME.Text = user_info.Rows(0)("username").ToString()
        'load all professor's sections
        'listview_sections.Items.Clear()


        'LOGIN.database.query2("SELECT * FROM sections WHERE professor = ?", New ArrayList() From {user_info.Rows(0)("id").ToString()})
        'dt_section = LOGIN.database.result
        'For i As Integer = 0 To dt_section.Rows.Count - 1
        '    listview_sections.Items.Add(dt_section.Rows(i)("section").ToString())
        '    listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("subject").ToString())
        '    listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("schedule_day").ToString())
        '    listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("schedule_time").ToString())
        '    listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("id").ToString())
        'Next
        If user_info.Rows(0)("enable_tutorial").ToString() = "yes" Then
            Button3_Click(sender, e)

        End If
        If String.IsNullOrEmpty(LOGIN.setsection) Then
            btn_closeSection.Visible = False
        End If
        Dim dt As DataTable = LOGIN.database.query("SELECT * FROM sections RIGHT JOIN schedule ON (schedule.id = sections.schedule_id) WHERE professor = '" & LOGIN.professor.id & "' and schedule.status = 'Online'")
        If dt.Rows.Count > 0 Then
            LOGIN.setsection = dt.Rows(0)("section").ToString()
            Me.selsection = dt.Rows(0)("section").ToString()
            Me.selsubject = dt.Rows(0)("subject").ToString()

            LOGIN.section = dt.Rows(0)("section").ToString()
            LOGIN.subj = dt.Rows(0)("subject").ToString()
            LOGIN.sched_timein = dt.Rows(0)("timein").ToString()
            LOGIN.sched_timeout = dt.Rows(0)("timeout").ToString()
            LOGIN.sched_day = dt.Rows(0)("day").ToString()
            lbl_section.Text = selsection & "-" & selsubject
            If openedInDashboard = True Then

            Else
                Me.Close()
                DASHBOARD.Show()

            End If
            refresh_lists()
            Exit Sub
        Else

        End If
        

        refresh_lists()

    End Sub
   
    Private Sub listview_sections_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listview_sections.Click
        'SET
        selsection = listview_sections.SelectedItems(0).SubItems(0).Text
        selsubject = listview_sections.SelectedItems(0).SubItems(1).Text
        lbl_section.Text = listview_sections.SelectedItems(0).SubItems(0).Text + "-" + listview_sections.SelectedItems(0).SubItems(1).Text
        Button2.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub listview_sections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listview_sections.SelectedIndexChanged

    End Sub
    Private Sub showtooltip()

        ToolTip1.Show("STEP1. ADD A SECTION AND SUBJECT", Me.Button1, 3600000)
        ToolTip2.Show("STEP2. SELECT THE SECTION FROM THE LIST", Me.listview_sections, 3600000)
       ToolTip4.Show("FINAL STEP. CLICK SET SECTION. AFTER THIS, YOU MAY NOW CLOSE THIS WINDOW", Me.Button2, 3600000)

        ToolTip1.Show("STEP1. ADD A SECTION AND SUBJECT", Me.Button1, 3600000)
        ToolTip2.Show("STEP2. SELECT THE SECTION FROM THE LIST", Me.listview_sections, 3600000)
        ToolTip4.Show("FINAL STEP. CLICK SET SECTION. AFTER THIS, YOU MAY NOW CLOSE THIS WINDOW", Me.Button2, 3600000)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        add_section.ShowDialog(Me)
        add_section.Dispose()
        refresh_lists()

    End Sub

   

  

    Private Sub listview_subjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub refresh_lists()
        'load all professor's sections
        listview_sections.Items.Clear()
     
        LOGIN.database.query2("SELECT sections.*, sections.id as TblSections_id, schedule.*, schedule.id as TblSchedule_id FROM sections, schedule WHERE professor = ? AND sections.schedule_id = schedule.id", New ArrayList() From {user_info.Rows(0)("id").ToString()})

        dt_section = LOGIN.database.result
        For i As Integer = 0 To dt_section.Rows.Count - 1
            listview_sections.Items.Add(dt_section.Rows(i)("section").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("subject").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("day").ToString())
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timein").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(DateTime.Parse(dt_section.Rows(i)("timeout").ToString()).ToString("hh:mm tt"))
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("access_code").ToString())
            listview_sections.Items(i).SubItems.Add(dt_section.Rows(i)("schedule_id").ToString())
        Next
    End Sub
   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (listview_sections.SelectedItems.Count = 0) Then
            MsgBox("Please select a section and subject", MsgBoxStyle.Critical, "Select Subject/Section")

            Exit Sub
        End If

        Try
            Dim prompt As prompt = New prompt()
            If prompt.promptAndClose("Are you sure you want to set " & lbl_section.Text & " as section for today and proceed to main menu?") = VCC.prompt.resultEnum.yes Then
                ''Set all sections OFFLINE
                'Try

                '    sql = "UPDATE sections SET status='Offline'"
                '    Dim ups As New MySqlCommand(sql, con)

                '    If con.State = ConnectionState.Closed Then
                '        con.Open()
                '    End If

                '    ups.ExecuteNonQuery()
                '    con.Close()

                '    'Set selected section ONLINE
                '    sql = "UPDATE sections SET status='Online' WHERE section=?sec AND subject=?subj AND professor=?prof"
                '    Dim upsec As New MySqlCommand(sql, con)
                '    upsec.Parameters.AddWithValue("?sec", selsection)
                '    upsec.Parameters.AddWithValue("?subj", selsubject)
                '    upsec.Parameters.AddWithValue("?prof", user_info.Rows(0)("ID").ToString())

                '    If con.State = ConnectionState.Closed Then
                '        con.Open()
                '    End If

                '    upsec.ExecuteNonQuery()
                '    con.Close()
                'Catch ex As Exception

                'End Try

                LOGIN.database.query2("UPDATE student_section SET active = 'yes' WHERE section = ? AND subject = ? AND professor_name = ? AND timein = time(?) AND  timeout = time(?) AND day = ?", New ArrayList() From {selsection, selsubject, LOGIN.professor.username, listview_sections.SelectedItems(0).SubItems(3).Text, listview_sections.SelectedItems(0).SubItems(4).Text, listview_sections.SelectedItems(0).SubItems(2).Text})
                MsgBox("Selected section and subject is: " & selsection & "-" & selsubject + ". redirecting to main menu", MsgBoxStyle.Information, "Completed setting section")
                Dim datetoday As String = Date.Now.Date.ToString("yyyy-MM-dd")
                LOGIN.database.query("UPDATE sections SET status = 'Online' WHERE section = '" & selsection & "'  AND subject = '" & selsubject & "' AND professor = '" & LOGIN.professor.id & "'")
                LOGIN.database.query("UPDATE schedule SET status = 'Online' WHERE professor_id = '" & LOGIN.professor.id & "' AND id in (SELECT schedule_id as id FROM sections WHERE status = 'Online')")
                lbl_section.Text = selsection & "-" & selsubject
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & selsection & "-" & selsubject & "\" & datetoday) Then
                    Try
                        System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Student Activity\" & selsection & "-" & selsubject & "\" & datetoday)

                    Catch ex As Exception

                    End Try
                    End If


                LOGIN.setsection = lbl_section.Text
                LOGIN.section = listview_sections.SelectedItems(0).Text
                LOGIN.subj = listview_sections.SelectedItems(0).SubItems(1).Text
                LOGIN.sched_timein = listview_sections.SelectedItems(0).SubItems(3).Text
                LOGIN.sched_timeout = listview_sections.SelectedItems(0).SubItems(4).Text
                LOGIN.sched_day = listview_sections.SelectedItems(0).SubItems(2).Text
                strategy_window.closeWindowNoPrompt(Me)
                DASHBOARD.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Public Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tutorial()
    End Sub
    Private Sub refreshthis()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If listview_sections.SelectedItems.Count > 0 Then
            update_section.ComboBox1.Items.Clear()
            update_section.ComboBox1.Items.Add("Mondays")
            update_section.ComboBox1.Items.Add("Tuesdays")
            update_section.ComboBox1.Items.Add("Wednesdays")
            update_section.ComboBox1.Items.Add("Thursdays")
            update_section.ComboBox1.Items.Add("Fridays")
            update_section.ComboBox1.Items.Add("Saturdays")
            update_section.ComboBox1.Items.Add("Sundays")

            update_section.lbl_id.Text = listview_sections.SelectedItems(0).SubItems(6).Text
            update_section.txt_accesscode.Text = listview_sections.SelectedItems(0).SubItems(5).Text
            update_section.txt_section.Text = listview_sections.SelectedItems(0).SubItems(0).Text
            update_section.txt_subject.Text = listview_sections.SelectedItems(0).SubItems(1).Text
            update_section.datetime_timein.Text = listview_sections.SelectedItems(0).SubItems(3).Text
            update_section.datetime_timeout.Text = listview_sections.SelectedItems(0).SubItems(4).Text
            update_section.ComboBox1.Text = listview_sections.SelectedItems(0).SubItems(2).Text
            update_section.ShowDialog()
            update_section.Dispose()
            refresh_lists()
            MessageBox.Show("Please click 'set section' for the changes to take effect")
        Else
            MessageBox.Show("Please select a section from the list")
        End If

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_closeSection.Click
        strategy_window.closeWindowNoPrompt(Me)
    End Sub
End Class