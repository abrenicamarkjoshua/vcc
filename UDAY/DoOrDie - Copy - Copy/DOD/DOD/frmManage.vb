Imports MySql.Data.MySqlClient

Public Class frmManage

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarmanage)
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

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadApps()

                Try
                    rec.LoadGrammar(grammarmanage)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarmanage)
                Catch ex As Exception

                End Try

                If frmApplication.Visible = True Then
                    frmApplication.LoadAppType()

                    Try
                        frmApplication.rec.LoadGrammar(grammarapp)
                        frmApplication.rec.SetInputToDefaultAudioDevice()
                        frmApplication.rec.RecognizeAsync(1)
                    Catch : End Try
                End If

                Me.Close()
            End If
        End If
    End Sub

    Sub LoadApps()
        lvApp.Items.Clear()
        txtName.Text = ""
        txtName.Tag = ""
        txtPath.Text = ""
        conpath = ""

        sql = "SELECT * FROM tbl_apptype"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "app")

        If ds.Tables("app").Rows.Count > 0 Then
            For a = 1 To ds.Tables("app").Rows.Count
                Dim lv As ListViewItem = lvApp.Items.Add(ds.Tables("app").Rows(a - 1).Item("appname").ToString)
                lv.SubItems.Add(ds.Tables("app").Rows(a - 1).Item("pathname").ToString)
                lv.SubItems.Add(ds.Tables("app").Rows(a - 1).Item("conpath").ToString)
            Next
        End If
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"

        lblAdd.Enabled = False
        lvApp.Enabled = False
        lblConfigure.Enabled = False

        txtName.Enabled = True
        lblBrowse.Enabled = True
    End Sub

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        If lblEdit.Text = "Edit" Then
            If txtName.Text = "" Then
                message = "Please select an Application Type that you want to Edit"
                MsgBox("Please select an Application Type that you want to Edit", MsgBoxStyle.Information, "Application Type")

                Exit Sub
            End If

            lblEdit.Text = "Update"
            lblDelete.Text = "Cancel"

            lblAdd.Enabled = False
            lvApp.Enabled = False
            lblConfigure.Enabled = False

            txtName.Enabled = True
            lblBrowse.Enabled = True
        Else
            SaveUpdate()
        End If
    End Sub

    Sub SaveUpdate()
        If txtName.Text = "" Then
            message = "Please enter the Name of the Application"
            MsgBox("Please enter the Name of the Application", MsgBoxStyle.Information, "Application Type")

            txtName.Focus()
            Exit Sub
        End If

        If txtPath.Text = "" Then
            message = "Please browse for the path of the Application"
            MsgBox("Please browse for the Path of the Application", MsgBoxStyle.Information, "Application Type")

            txtPath.Focus()
        End If

        If lblEdit.Text = "Save" Then
            sql = "SELECT * FROM tbl_apptype WHERE LCASE(appname)=?name"
            Dim exapp As New MySqlCommand(sql, con)
            exapp.Parameters.AddWithValue("?name", LCase(txtName.Text))
            da = New MySqlDataAdapter(exapp)
            ds.Clear()
            da.Fill(ds, "app")

            If ds.Tables("app").Rows.Count > 0 Then
                message = "The Application Name that you're trying to use already exist"
                MsgBox("The Application Name that you're trying to use already exist", MsgBoxStyle.Information, "Application Type")

                txtName.Focus()
                Exit Sub
            End If

            sql = "INSERT INTO tbl_apptype VALUES(?name,?path,?is,?con)"
            Dim addapp As New MySqlCommand(sql, con)
            addapp.Parameters.AddWithValue("?name", txtName.Text)
            addapp.Parameters.AddWithValue("?path", txtPath.Text)

            '~~> Change it to No Later
            addapp.Parameters.AddWithValue("?is", "Yes")
            addapp.Parameters.AddWithValue("?con", txtPath.Text)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addapp.ExecuteNonQuery()
            con.Close()

            message = "Successfully registered a New Application Type"
            MsgBox("Successfully registered a New Application Type", MsgBoxStyle.Information, "Application Type")

            LoadApps()

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lvApp.Enabled = True
            lblConfigure.Enabled = True

            txtName.Enabled = False
            lblBrowse.Enabled = False
        Else
            sql = "SELECT * FROM tbl_apptype WHERE appname=?name AND (NOT appname=?app)"
            Dim exapp As New MySqlCommand(sql, con)
            exapp.Parameters.AddWithValue("?name", txtName.Text)
            exapp.Parameters.AddWithValue("?app", txtName.Tag)
            da = New MySqlDataAdapter(exapp)
            ds.Clear()
            da.Fill(ds, "app")

            If ds.Tables("app").Rows.Count > 0 Then
                message = "The Application that you're trying to use already exist"
                MsgBox("The Application that you're trying to use already exist", MsgBoxStyle.Information, "Application Type")

                txtName.Focus()
                Exit Sub
            End If

            sql = "UPDATE tbl_apptype SET appname=?name, pathname=?path, conpath=?con WHERE appname=?app"
            Dim upapp As New MySqlCommand(sql, con)
            upapp.Parameters.AddWithValue("?name", txtName.Text)
            upapp.Parameters.AddWithValue("?path", txtPath.Text)
            upapp.Parameters.AddWithValue("?app", txtName.Tag)
            upapp.Parameters.AddWithValue("?con", txtPath.Text)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            upapp.ExecuteNonQuery()
            con.Close()

            message = "Successfully Updated an Application Type"
            MsgBox("Successfully Updated an Application Type", MsgBoxStyle.Information, "Application Type")

            LoadApps()

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lvApp.Enabled = True
            lblConfigure.Enabled = True

            txtName.Enabled = False
            lblBrowse.Enabled = False
        End If
    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lblDelete.Text = "Delete" Then
            If txtName.Text = "" Then
                message = "Please select an Application Type that you want to Delete"
                MsgBox("Please select an Application Type that you want to Delete", MsgBoxStyle.Information, "Application Type")

                Exit Sub
            End If

            sql = "DELETE FROM tbl_apptype WHERE appname=?name"
            Dim delapp As New MySqlCommand(sql, con)
            delapp.Parameters.AddWithValue("?name", txtName.Text)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            delapp.ExecuteNonQuery()
            con.Close()

            message = "Successfully Deleted an Application Type"
            MsgBox("Successfully Deleted an Application Type", MsgBoxStyle.Information, "Application Type")

            LoadApps()
        Else
            lblAdd.Text = "Add"
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lblEdit.Enabled = True
            lblDelete.Enabled = True
            lblConfigure.Enabled = True

            lblBrowse.Enabled = False
            txtName.Enabled = False
            txtPath.Enabled = False
            lvApp.Enabled = True
        End If
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowse.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarmanage)
        Catch : End Try

        If ofdApplication.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPath.Text = ofdApplication.FileName
        End If

        Try
            rec.LoadGrammar(grammarmanage)
            rec.SetInputToDefaultAudioDevice()
            rec.RecognizeAsync(1)
        Catch : End Try
    End Sub

    Private Sub lblBrowse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblBrowse.MouseLeave
        lblBrowse.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblBrowse_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBrowse.MouseMove
        lblBrowse.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub frmManage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public WithEvents rec As New Speech.Recognition.SpeechRecognitionEngine

    Private Sub lvApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvApp.Click
        If lvApp.Items.Count > 0 Then
            txtName.Text = lvApp.FocusedItem.Text
            txtName.Tag = lvApp.FocusedItem.Text
            txtPath.Text = lvApp.FocusedItem.SubItems(1).Text
            conpath = lvApp.FocusedItem.SubItems(2).Text
        End If
    End Sub

    Private Sub lvApp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvApp.SelectedIndexChanged

    End Sub

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If lblEdit.Text = "Edit" Then
            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)

            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
        ElseIf lblEdit.Text = "Save" Then
            ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
        ElseIf lblEdit.Text = "Update" Then
            ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
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

    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        Select Case e.KeyChar
            Case ChrW(8)
            Case ChrW(48) To ChrW(57)
            Case ChrW(65) To ChrW(90)
            Case ChrW(97) To ChrW(122)
            Case ChrW(45)
            Case ChrW(95)
            Case ChrW(46)
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarmanage)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "help" Then
            If lblEdit.Text = "Edit" Then
                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)

                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ElseIf lblEdit.Text = "Save" Then
                ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
            ElseIf lblEdit.Text = "Update" Then
                ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtName, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
            End If
        ElseIf e.Result.Text = "browse" Then
            If lblBrowse.Enabled = True Then
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarmanage)
                Catch : End Try

                If ofdApplication.ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtPath.Text = ofdApplication.FileName
                End If

                Try
                    rec.LoadGrammar(grammarmanage)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try
            End If
        ElseIf e.Result.Text = "add" Then
            If lblAdd.Enabled = True Then
                lblEdit.Text = "Save"
                lblDelete.Text = "Cancel"

                lblAdd.Enabled = False
                lvApp.Enabled = False

                txtName.Enabled = True
                lblBrowse.Enabled = True
            End If
        ElseIf e.Result.Text = "edit" Then
            If lblEdit.Text = "Edit" Then
                If txtName.Text = "" Then
                    message = "Please select an Application Type that you want to Edit"

                    Exit Sub
                End If

                lblEdit.Text = "Update"
                lblDelete.Text = "Cancel"

                lblAdd.Enabled = False
                lvApp.Enabled = False

                txtName.Enabled = True
                lblBrowse.Enabled = True
            End If
        ElseIf e.Result.Text = "save" Then
            If lblEdit.Text = "Save" Then
                SaveUpdate()
            End If
        ElseIf e.Result.Text = "update" Then
            If lblEdit.Text = "Update" Then
                SaveUpdate()
            End If
        ElseIf e.Result.Text = "cancel" Then
            If lblDelete.Text = "Cancel" Then
                lblAdd.Text = "Add"
                lblEdit.Text = "Edit"
                lblDelete.Text = "Delete"

                lblAdd.Enabled = True
                lblEdit.Enabled = True
                lblDelete.Enabled = True

                lblBrowse.Enabled = False
                txtName.Enabled = False
                txtPath.Enabled = False
                lvApp.Enabled = False
            End If
        ElseIf e.Result.Text = "delete" Then
            If lblDelete.Text = "Delete" Then
                If txtName.Text = "" Then
                    message = "Please select an Application that you want to Delete"

                    Exit Sub
                End If

                sql = "DELETE FROM tbl_apptype WHERE appname=?name"
                Dim delapp As New MySqlCommand(sql, con)
                delapp.Parameters.AddWithValue("?name", txtName.Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delapp.ExecuteNonQuery()
                con.Close()

                message = "Successfully Deleted an Application Type"

                LoadApps()
            End If
        ElseIf e.Result.Text = "configure" Then
            If txtName.Text = "" Then
                message = "Please select an Application that you want to Configure the Path"
                MsgBox("Please select an Application that you want to Configure the Path", MsgBoxStyle.Information, "Configure Path")

                Exit Sub
            End If

            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarmanage)
            Catch : End Try

            frmConfigure.prevform = "manage"
            frmConfigure.txtPath.Text = conpath
            frmConfigure.ShowDialog()
        End If
    End Sub

    Private Sub lblConfigure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblConfigure.Click
        If txtName.Text = "" Then
            message = "Please select an Application that you want to Configure the Path"
            MsgBox("Please select an Application that you want to Configure the Path", MsgBoxStyle.Information, "Configure Path")

            Exit Sub
        End If

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarmanage)
        Catch : End Try

        frmConfigure.prevform = "manage"
        frmConfigure.txtPath.Text = conpath
        frmConfigure.ShowDialog()
    End Sub

    Public conpath As String = ""

    Private Sub lblConfigure_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblConfigure.MouseLeave
        lblConfigure.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblConfigure_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblConfigure.MouseMove
        lblConfigure.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

End Class