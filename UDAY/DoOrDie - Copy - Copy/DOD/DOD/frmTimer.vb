Imports MySql.Data.MySqlClient

Public Class frmTimer

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammartimer)
        Catch : End Try
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.ForeColor = Color.White
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.ForeColor = Color.LawnGreen
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Sub LoadComputers()
        sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
        Dim complist As New MySqlCommand(sql, con)
        complist.Parameters.AddWithValue("?name", My.Computer.Name)
        complist.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(complist)
        ds.Clear()
        da.Fill(ds, "comp")

        If ds.Tables("comp").Rows.Count > 0 Then
            lvDetected.Items.Clear()

            For a = 1 To ds.Tables("comp").Rows.Count
                Dim lv As ListViewItem = lvDetected.Items.Add(ds.Tables("comp").Rows(a - 1).Item("ipaddress").ToString)
                lv.SubItems.Add(ds.Tables("comp").Rows(a - 1).Item("computername").ToString)
                lv.SubItems.Add(ds.Tables("comp").Rows(a - 1).Item("actdone").ToString)
            Next
        Else
            lvDetected.Items.Clear()
        End If
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                Try
                    rec.LoadGrammar(grammartimer)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try

                LoadComputers()

                txtMin.Focus()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammartimer)
                Catch : End Try
                Try
                    frmMenu.menurec.LoadGrammar(grammar2)
                Catch : End Try
                Try
                    frmMenu.menurec.SetInputToDefaultAudioDevice()
                Catch : End Try
                Try
                    frmMenu.menurec.RecognizeAsync(1)
                Catch : End Try

                Me.Close()
            End If
        End If
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub frmTimer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'frmMenu.checknetwork()

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub LoadComp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadComp.Tick
        LoadComputers()
    End Sub

    Private Sub rdbSpecific_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSpecific.Click
        isAll = False
        lvDetected.Enabled = True
        rdbSpecific.ForeColor = Color.LawnGreen
        rdbAll.ForeColor = Color.White
    End Sub

    Private Sub rdbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.CheckedChanged
        isAll = True
        lvDetected.Enabled = False
        lvDetected.Tag = ""
        rdbSpecific.ForeColor = Color.White
        rdbAll.ForeColor = Color.LawnGreen
    End Sub

    Private Sub cmbCom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCom.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMin.Focus()
        End If
    End Sub

    Private Sub cmbCom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCom.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCom.SelectedIndexChanged
        If cmbCom.Text = "Add Time" Then
            txtMin.Enabled = True
            txtMin.Focus()
        Else
            txtMin.Enabled = False
            txtMin.Text = ""
        End If
    End Sub

    Sub AddTime()

        If txtMin.Text = "" Then
            message = "Please set the number of minutes to be added"

            If isVoice = False Then
                MsgBox("Please set the number of minutes to be added", MsgBoxStyle.Information, "Client Timer")
            End If

            Exit Sub
        End If

        If isAll = True Then
            For a = 1 To lvDetected.Items.Count
                If lvDetected.Items(a - 1).SubItems(2).Text = "Yes" Then
                    Continue For
                End If

                sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                Dim seltimer As New MySqlCommand(sql, con)
                seltimer.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                seltimer.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                da = New MySqlDataAdapter(seltimer)
                ds.Clear()
                da.Fill(ds, "seltimer")

                If ds.Tables("seltimer").Rows.Count > 0 Then
                    '~~> Update their Time in tbl_commandpc
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                    Dim upcomm As New MySqlCommand(sql, con)
                    upcomm.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                    upcomm.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                    upcomm.Parameters.AddWithValue("?comm", "extend-time")
                    upcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    upcomm.ExecuteNonQuery()
                    con.Close()
                Else
                    '~~> Add their Time in tbl_commandpc
                    sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                    Dim addcomm As New MySqlCommand(sql, con)
                    addcomm.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                    addcomm.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                    addcomm.Parameters.AddWithValue("?comm", "add")
                    addcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    addcomm.ExecuteNonQuery()
                    con.Close()
                End If
            Next
        Else
            If compname = "" Then
                message = "Please select a Client that you want to Add Time"

                If isVoice = False Then
                    MsgBox("Please select a Client that you want to Add Time", MsgBoxStyle.Information, "Client Timer")
                End If

                Exit Sub
            End If

            If isVoice = True Then
                GoTo skip
            End If

            If isDone = True Then
                If MsgBox("The System has detected that it is already done with the Activity" & vbNewLine & vbNewLine & "Is this a new batch of Activity?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Time") = MsgBoxResult.Yes Then
skip:
                    sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
                    Dim extime As New MySqlCommand(sql, con)
                    extime.Parameters.AddWithValue("?name", compname)
                    extime.Parameters.AddWithValue("?ip", ipaddress)
                    da = New MySqlDataAdapter(extime)
                    ds.Clear()
                    da.Fill(ds, "timers")

                    If ds.Tables("timers").Rows.Count > 0 Then
                        '~~> Update their Time in tbl_commandpc
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim upcomm As New MySqlCommand(sql, con)
                        upcomm.Parameters.AddWithValue("?name", compname)
                        upcomm.Parameters.AddWithValue("?ip", ipaddress)
                        upcomm.Parameters.AddWithValue("?comm", "extend-time")
                        upcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        upcomm.ExecuteNonQuery()
                        con.Close()
                    Else
                        '~~> Add their Time in tbl_commandpc
                        sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                        Dim addcomm As New MySqlCommand(sql, con)
                        addcomm.Parameters.AddWithValue("?name", compname)
                        addcomm.Parameters.AddWithValue("?ip", ipaddress)
                        addcomm.Parameters.AddWithValue("?comm", "add")
                        addcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If

                        addcomm.ExecuteNonQuery()
                        con.Close()
                    End If

                    ds.Tables("timers").Clear()

                    If txtMin.Text = 1 Then
                        message = txtMin.Text & " minute was added to " & compname

                        If isVoice = False Then
                            MsgBox(txtMin.Text & " minute was added to " & compname, MsgBoxStyle.Information, "Add Time")
                        End If
                    Else
                        message = txtMin.Text & " minutes was added to " & compname

                        If isVoice = False Then
                            MsgBox(txtMin.Text & " minutes was added to " & compname, MsgBoxStyle.Information, "Add Time")
                        End If
                    End If

                    txtMin.Text = ""
                    txtMin.Focus()
                End If

                Exit Sub
            End If

            sql = "SELECT * FROM tbl_timer WHERE computername=?name AND ipaddress=?ip"
            Dim extimer As New MySqlCommand(sql, con)
            extimer.Parameters.AddWithValue("?name", compname)
            extimer.Parameters.AddWithValue("?ip", ipaddress)
            da = New MySqlDataAdapter(extimer)
            da.Fill(ds, "timer")

            If ds.Tables("timer").Rows.Count > 0 Then
                '~~> Update their Time in tbl_commandpc
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim upcomm As New MySqlCommand(sql, con)
                upcomm.Parameters.AddWithValue("?name", compname)
                upcomm.Parameters.AddWithValue("?ip", ipaddress)
                upcomm.Parameters.AddWithValue("?comm", "extend-time")
                upcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upcomm.ExecuteNonQuery()
                con.Close()
            Else
                '~~> Add their Time in tbl_commandpc
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", compname)
                addcomm.Parameters.AddWithValue("?ip", ipaddress)
                addcomm.Parameters.AddWithValue("?comm", "add")
                addcomm.Parameters.AddWithValue("?con", CInt(txtMin.Text) * 60)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            End If

            ds.Tables("timer").Clear()

            If txtMin.Text = 1 Then
                message = txtMin.Text & " minute was added to " & compname

                If isVoice = False Then
                    MsgBox(txtMin.Text & " minute was added to " & compname, MsgBoxStyle.Information, "Client Timer")
                End If
            Else
                message = txtMin.Text & " minutes was added to " & compname

                If isVoice = False Then
                    MsgBox(txtMin.Text & " minutes was added to " & compname, MsgBoxStyle.Information, "Client Timer")
                End If
            End If

            txtMin.Text = ""
            txtMin.Focus()
        End If
    End Sub

    Sub StopTime()
        If isAll = True Then
            For a = 1 To lvDetected.Items.Count
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                addcomm.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                addcomm.Parameters.AddWithValue("?comm", "stop-time")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            Next

            message = "All Client's time has been stopped"

            If isVoice = False Then
                MsgBox("All Client's time has been stopped", MsgBoxStyle.Information, "Timer Setting")
            End If

            txtMin.Focus()
        Else
            If compname = "" Then
                message = "Please select a client that you want to Stop Time"

                If isVoice = False Then
                    MsgBox("Please select a client that you want to Stop Time", MsgBoxStyle.Information, "Stop Time")
                End If

                Exit Sub
            End If

            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", compname)
            addcomm.Parameters.AddWithValue("?ip", ipaddress)
            addcomm.Parameters.AddWithValue("?comm", "stop-time")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "A client's time has been stopped"

            If isVoice = False Then
                MsgBox("A client's time has been stopped", MsgBoxStyle.Information, "Timer Setting")
            End If

            txtMin.Focus()
        End If
    End Sub

    Public compname, ipaddress As String
    Public isAll As Boolean = True
    Public isDone As Boolean = False

    Private Sub lblContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContinue.Click
        If cmbCom.Text = "Add Time" Then
            isVoice = False
            AddTime()
        ElseIf cmbCom.Text = "Stop Time" Then
            isVoice = False
            StopTime()
        ElseIf cmbCom.Text = "Resume Time" Then
            isVoice = False
            ResumeTime()
        ElseIf cmbCom.Text = "Reset Time" Then
            isVoice = False
            resettime()
        End If
    End Sub

    Sub ResumeTime()
        If isAll = True Then
            For a = 1 To lvDetected.Items.Count
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                addcomm.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                addcomm.Parameters.AddWithValue("?comm", "resume-time")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            Next

            message = "All Client's time has been resumed"

            If isVoice = False Then
                MsgBox("All Client's time has been resumed", MsgBoxStyle.Information, "Timer Setting")
            End If

            txtMin.Focus()
        Else
            If compname = "" Then
                message = "Please select a client that you want to Resume Time"

                If isVoice = False Then
                    MsgBox("Please select a client that you want to Resume Time", MsgBoxStyle.Information, "Timer Setting")
                End If

                Exit Sub
            End If

            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", compname)
            addcomm.Parameters.AddWithValue("?ip", ipaddress)
            addcomm.Parameters.AddWithValue("?comm", "resume-time")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "A client's time has been resumed"

            If isVoice = False Then
                MsgBox("A client's time has been resumed", MsgBoxStyle.Information, "Timer Setting")
            End If

            txtMin.Focus()
        End If
    End Sub

    Private Sub lblContinue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblContinue.MouseLeave
        lblContinue.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblContinue_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContinue.MouseMove
        lblContinue.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Public isActivity As Boolean = False
    Public studid, studname As String

    Private Sub lvDetected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetected.Click
        If lvDetected.Items.Count > 0 Then
            ipaddress = lvDetected.FocusedItem.Text
            compname = lvDetected.FocusedItem.SubItems(1).Text

            If lvDetected.FocusedItem.SubItems(2).Text = "Yes" Then
                isDone = True
            Else
                isDone = False
            End If
        End If
    End Sub

    Public studentid, studentname, activity As String
    Public isStudDone As Boolean

    Private Sub lvDetected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDetected.SelectedIndexChanged

    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If isAll = True Then
            ToolTip1.RemoveAll()
            ToolTip2.RemoveAll()
            ToolTip3.RemoveAll()

            ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
            ToolTip2.Show("Step 2: Enter number of minutes to be Added (If Add Time)", Me.txtMin, 10, -30, 5000)

            ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
        Else
            ToolTip1.RemoveAll()
            ToolTip2.RemoveAll()
            ToolTip3.RemoveAll()
            ToolTip4.RemoveAll()

            ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
            ToolTip2.Show("Step 2: Enter number of minutes to be Added (If Add Time)", Me.txtMin, 10, -30, 5000)
            ToolTip4.Show("Step 1: Select a client to Add / Stop Time", Me.lvDetected, 5000)

            ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
            ToolTip4.Show("Step 1: Select a client to Add / Stop Time", Me.lvDetected, 5000)
        End If
    End Sub

    Private Sub lblHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHelp.MouseLeave
        lblHelp.ForeColor = Color.White
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
    End Sub

    Private Sub lblHelp_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblHelp.MouseMove
        lblHelp.ForeColor = Color.LawnGreen
        lblHelp.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
    End Sub

    Dim isVoice As Boolean = False

    Private Sub lblReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblReset.Click
        isVoice = False

        If isAll = True Then
            For a = 1 To lvDetected.Items.Count
                sql = "UPDATE tbl_computer SET actdone='No' WHERE computername=?name AND ipaddress=?ip"
                Dim updone As New MySqlCommand(sql, con)
                updone.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                updone.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                updone.ExecuteNonQuery()
                con.Close()
            Next

            LoadComputers()
            message = "Reset Activity for All Clients was successful"

            If isVoice = False Then
                MsgBox("Reset Activity for All Clients was successful", MsgBoxStyle.Information, "Reset Activity")
            End If
        Else
            If compname = "" Then
                message = "Please select a client computer that you want to reset activity"

                If isVoice = False Then
                    MsgBox("Please select a Client Computer that you want to Reset Activity", MsgBoxStyle.Information, "Reset Activity")
                End If

                Exit Sub
            End If

            If isDone = False Then
                message = compname & " is not yet done with the activity.. reset activity was cancelled"

                If isVoice = False Then
                    MsgBox(compname & " is not yet done with the Activity.. Reset Activity was Cancelled", MsgBoxStyle.Information, "Reset Activity")
                End If

                Exit Sub
            End If

            If isVoice = True Then
                GoTo skip
            End If

            If MsgBox("Are you sure you want to Reset the Activity on " & compname & " to enable another student to take an Activity?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Reset Activity") = MsgBoxResult.Yes Then
skip:
                sql = "UPDATE tbl_computer SET actDone='No' WHERE computername=?name AND ipaddress=?ip"
                Dim updone As New MySqlCommand(sql, con)
                updone.Parameters.AddWithValue("?name", compname)
                updone.Parameters.AddWithValue("?ip", ipaddress)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                updone.ExecuteNonQuery()
                con.Close()

                message = "Reset Activity of " & compname & " was successful"

                If isVoice = False Then
                    MsgBox("Reset Activity of " & compname & "(" & ipaddress & ") was successful", MsgBoxStyle.Information, "Reset Activity")
                End If

                LoadComputers()
            End If
        End If
    End Sub

    Private Sub lblReset_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblReset.MouseLeave
        lblReset.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblReset_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblReset.MouseMove
        lblReset.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadComputers()
    End Sub

    Private Sub txtMin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMin.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmbCom.Text = "Add Time" Then
                AddTime()
            ElseIf cmbCom.Text = "Stop Time" Then
                StopTime()
            ElseIf cmbCom.Text = "Resume Time" Then
                ResumeTime()
            ElseIf cmbCom.Text = "Reset Time" Then
                resettime()
            End If
        End If
    End Sub

    Sub ResetTime()
        If isAll = True Then
            For a = 1 To lvDetected.Items.Count
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                addcomm.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)
                addcomm.Parameters.AddWithValue("?comm", "reset-time")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            Next

            message = "All Client's time has been reset"

            If isVoice = False Then
                MsgBox("All Client's time has been reset", MsgBoxStyle.Information, "Timer Setting")
            End If

            txtMin.Focus()
        Else
            If compname = "" Then
                message = "Please select a client that you want to Reset Time"

                If isVoice = False Then
                    MsgBox("Please select a client that you want to Reset Time", MsgBoxStyle.Information, "Timer Setting")
                End If

                Exit Sub
            End If

            sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
            Dim addcomm As New MySqlCommand(sql, con)
            addcomm.Parameters.AddWithValue("?name", compname)
            addcomm.Parameters.AddWithValue("?ip", ipaddress)
            addcomm.Parameters.AddWithValue("?comm", "reset-time")
            addcomm.Parameters.AddWithValue("?con", "")

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addcomm.ExecuteNonQuery()
            con.Close()

            message = "A client's time has been reset"

            If isVoice = False Then
                MsgBox("A client's time has been reset", MsgBoxStyle.Information, "Timer Setting")
            End If
        End If
    End Sub
    Private Sub txtMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "all-client" Then
            message = "All Client"
            rdbAll.PerformClick()
        ElseIf e.Result.Text = "specific-client" Then
            message = "Specific Client"
            rdbSpecific.PerformClick()
        ElseIf e.Result.Text = "add-time" Then
            message = "Add Time"
            cmbCom.SelectedIndex = 0
            cmbCom.Text = "Add Time"
        ElseIf e.Result.Text = "stop-time" Then
            message = "Stop Time"
            cmbCom.SelectedIndex = 1
            cmbCom.Text = "Stop Time"
        ElseIf e.Result.Text = "resume-time" Then
            message = "Resume Time"
            cmbCom.SelectedIndex = 2
            cmbCom.Text = "Resume Time"
        ElseIf e.Result.Text = "reset-time" Then
            message = "Reset Time"
            cmbCom.SelectedIndex = 3
            cmbCom.Text = "Reset Time"
        ElseIf e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammartimer)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "help" Then
            If isAll = True Then
                ToolTip1.RemoveAll()
                ToolTip2.RemoveAll()
                ToolTip3.RemoveAll()

                ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
                ToolTip2.Show("Step 2: Enter number of minutes to be Added (If Add Time)", Me.txtMin, 10, -30, 5000)

                ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
            Else
                ToolTip1.RemoveAll()
                ToolTip2.RemoveAll()
                ToolTip3.RemoveAll()
                ToolTip4.RemoveAll()

                ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
                ToolTip2.Show("Step 2: Enter number of minutes to be Added (If Add Time)", Me.txtMin, 10, -30, 5000)
                ToolTip4.Show("Step 1: Select a client to Add / Stop Time", Me.lvDetected, 5000)

                ToolTip1.Show("Step 1: Select a command (Add Time / Stop Time)", Me.cmbCom, 5000)
                ToolTip4.Show("Step 1: Select a client to Add / Stop Time", Me.lvDetected, 5000)
            End If
        ElseIf e.Result.Text = "reset-activity" Then
            GoTo samp
        ElseIf e.Result.Text = "reset" Then
samp:
            isVoice = True

            If isAll = True Then
                For a = 1 To lvDetected.Items.Count
                    sql = "UPDATE tbl_computer SET actdone='No' WHERE computername=?name AND ipaddress=?ip"
                    Dim updone As New MySqlCommand(sql, con)
                    updone.Parameters.AddWithValue("?name", lvDetected.Items(a - 1).SubItems(1).Text)
                    updone.Parameters.AddWithValue("?ip", lvDetected.Items(a - 1).Text)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    updone.ExecuteNonQuery()
                    con.Close()
                Next

                message = "All client's activity has been reset"

                LoadComputers()
            Else
                If compname = "" Then
                    message = "Please select a client computer that you want to Reset Activity"

                    Exit Sub
                End If

                If isDone = False Then
                    message = "Reseting Activity has been canceled"

                    Exit Sub
                End If

                sql = "UPDATE tbl_computer SET actDone='No' WHERE computername=?name AND ipaddress=?ip"
                Dim updone As New MySqlCommand(sql, con)
                updone.Parameters.AddWithValue("?name", compname)
                updone.Parameters.AddWithValue("?ip", ipaddress)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                updone.ExecuteNonQuery()
                con.Close()

                message = "A client's activity has been reset"

                LoadComputers()
            End If
        ElseIf e.Result.Text = "continue" Then
            If cmbCom.Text = "Add Time" Then
                isVoice = True
                AddTime()
            ElseIf cmbCom.Text = "Stop Time" Then
                isVoice = True
                StopTime()
            ElseIf cmbCom.Text = "Resume Time" Then
                isVoice = True
                ResumeTime()
            ElseIf cmbCom.Text = "Reset Time" Then
                isVoice = True
                ResetTime()
            End If
        ElseIf e.Result.Text = "refresh" Then
            message = "Refreshing the List"
            LoadComputers()
        End If
    End Sub

    Private Sub lblStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStart.Click
        sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
        Dim selcomp As New MySqlCommand(sql, con)
        selcomp.Parameters.AddWithValue("?name", My.Computer.Name)
        selcomp.Parameters.AddWithValue("?ip", v4())
        da = New MySqlDataAdapter(selcomp)
        da.Fill(ds, "complist")

        If ds.Tables("complist").Rows.Count > 0 Then
            For a = 1 To ds.Tables("complist").Rows.Count
                sql = "INSERT INTO tbl_commandpc VALUES(?name,?ip,?comm,?con)"
                Dim addcomm As New MySqlCommand(sql, con)
                addcomm.Parameters.AddWithValue("?name", ds.Tables("complist").Rows(a - 1).Item("computername").ToString)
                addcomm.Parameters.AddWithValue("?ip", ds.Tables("complist").Rows(a - 1).Item("ipaddress").ToString)
                addcomm.Parameters.AddWithValue("?comm", "start-time")
                addcomm.Parameters.AddWithValue("?con", "")

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                addcomm.ExecuteNonQuery()
                con.Close()
            Next

            message = "All client's time has been enabled"
        Else
            message = "No Client Computers detected"
        End If

        ds.Tables("complist").Clear()
    End Sub

    Private Sub lblStart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStart.MouseLeave
        lblStart.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblStart_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblStart.MouseMove
        lblStart.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

End Class