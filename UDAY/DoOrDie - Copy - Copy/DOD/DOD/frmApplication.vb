Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Imports System.IO

Public Class frmApplication
    Public isTutorial As String = "No"

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        message = "Closing"
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarapp)
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

    Sub LoadApps()
        lvApp.Items.Clear()
        txtWordCall.Text = ""
        txtWordCall.Tag = ""
        txtPath.Text = ""
        cmbType.Text = ""

        sql = "SELECT * FROM tbl_application WHERE accountuser=?user OR accountuser=''"
        Dim app As New MySqlCommand(sql, con)
        app.Parameters.AddWithValue("?user", frmMenu.username)
        da = New MySqlDataAdapter(app)
        ds.Clear()
        da.Fill(ds, "app")

        If ds.Tables("app").Rows.Count > 0 Then
            For a = 1 To ds.Tables("app").Rows.Count
                Dim lv As ListViewItem = lvApp.Items.Add(ds.Tables("app").Rows(a - 1).Item("wordcall").ToString)
                lv.SubItems.Add(ds.Tables("app").Rows(a - 1).Item("defpath").ToString)
                lv.SubItems.Add(ds.Tables("app").Rows(a - 1).Item("conpath").ToString)
                lv.SubItems.Add(ds.Tables("app").Rows(a - 1).Item("apptype").ToString)

                If ds.Tables("app").Rows(a - 1).Item("accountuser").ToString = "" Then
                    lv.SubItems.Add("Yes")
                Else
                    lv.SubItems.Add("No")
                End If
            Next
        End If
    End Sub

    Dim loadcount As Integer = 0
    Dim addcount As Integer = 0
    Dim apptypepath() As String

    Sub LoadAppType()
        cmbType.Items.Clear()
        cmbType.Text = ""
        cmbType.Tag = ""

        sql = "SELECT * FROM tbl_apptype"
        da = New MySqlDataAdapter(sql, con)
        ds.Clear()
        da.Fill(ds, "apptype")

        If ds.Tables("apptype").Rows.Count > 0 Then
            Array.Resize(apptypepath, ds.Tables("apptype").Rows.Count)

            For a = 1 To ds.Tables("apptype").Rows.Count
                cmbType.Items.Add(ds.Tables("apptype").Rows(a - 1).Item("appname").ToString)
                apptypepath(a - 1) = ds.Tables("apptype").Rows(a - 1).Item("pathname").ToString & "/" & ds.Tables("apptype").Rows(a - 1).Item("conpath").ToString
            Next
        End If
    End Sub

    Public wordcall, defpath, conpath As String

    Private Sub frmApplication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isTutorial = "Yes" Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If

        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Dim builder As PromptBuilder
    Dim synthesizer As SpeechSynthesizer

    Public WithEvents rec As New System.Speech.Recognition.SpeechRecognitionEngine

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                If isTutorial = "Yes" Then
                    message = "In Application Setting, you manage application that can be open and close when commanded."
                End If

                LoadApps()
                LoadAppType()

                Try
                    rec.LoadGrammar(grammarapp)
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
                    rec.UnloadGrammar(grammarapp)
                Catch ex As Exception

                End Try

                If isTutorial = "No" Then
                    frmMenu.isActivate = True
                    frmMenu.Show()
                ElseIf isTutorial = "Skip" Then
                Else
                    frmTutorial.MoveIndicator.Tag = "Word"
                    frmTutorial.MoveIndicator.Start()
                End If

                Me.Close()
            End If
        End If
    End Sub

    Private Sub lblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAdd.Click
        lblEdit.Text = "Save"
        lblDelete.Text = "Cancel"

        lvApp.Enabled = False
        lblAdd.Enabled = False
        lblConfigure.Enabled = False
        lblManage.Enabled = False

        txtWordCall.Enabled = True
        lblBrowse.Enabled = True
        cmbType.Enabled = True

        txtWordCall.Text = ""
        txtPath.Text = ""
        cmbType.Text = ""
        cmbType.Tag = ""

        txtWordCall.Focus()
    End Sub

    Dim isAdd As Boolean = False

    Private Sub lblAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAdd.MouseLeave
        lblAdd.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblAdd_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblAdd.MouseMove
        lblAdd.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBrowse.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarapp)
        Catch : End Try

        If ofdApplication.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPath.Text = ofdApplication.FileName
        End If

        Try
            rec.LoadGrammar(grammarapp)
            rec.SetInputToDefaultAudioDevice()
            rec.RecognizeAsync(1)
        Catch : End Try
    End Sub

    Dim isBrowse As Boolean = False

    Private Sub lblBrowse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblBrowse.MouseLeave
        lblBrowse.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblBrowse_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBrowse.MouseMove
        lblBrowse.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEdit.Click
        If lblEdit.Text = "Edit" Then
            If txtWordCall.Text = "" Then
                message = "Please select an Application that you want to Edit"
                MsgBox("Please select an Application that you want to Edit", MsgBoxStyle.Information, "Application")

                Exit Sub
            End If

            If isSystem = True Then
                message = "Unable to Edit a System's Default Application"
                MsgBox("Unable to Edit a System's Defauly Application", MsgBoxStyle.Information, "Application")

                Exit Sub
            End If

            lblEdit.Text = "Update"
            lblDelete.Text = "Cancel"

            lvApp.Enabled = False
            lblAdd.Enabled = False
            lblConfigure.Enabled = False
            lblManage.Enabled = False

            txtWordCall.Enabled = True
            lblBrowse.Enabled = True
            cmbType.Enabled = True

            txtWordCall.Focus()
        Else
            SaveUpdate()
        End If
    End Sub

    Dim filename As String
    Dim isFile As Boolean = False

    Public Sub CopyFile(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                Dim fileinfo() As String = fileSystemInfo.FullName.Split("\")

                If isFile = True Then
                    If fileinfo(fileinfo.Length - 1) = filename Then
                        System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)

                        Exit Sub
                    End If
                Else
                    System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                End If
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyFile(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Sub SaveUpdate()
        '~~> Check if the fields are empty
        If txtWordCall.Text = "" Then
            message = "Please enter the Word call for the File"
            MsgBox("Please enter the Word call for the File", MsgBoxStyle.Information, "Application")

            txtWordCall.Focus()
            Exit Sub
        End If

        If txtPath.Text = "" Then
            message = "Please browse for the file to be open"
            MsgBox("Please browse for the file to be open", MsgBoxStyle.Information, "Application")

            Exit Sub
        End If

        If cmbType.Text = "" Then
            message = "Please select the Application to use for opening this file"
            MsgBox("Please select the Application to use for opening this file", MsgBoxStyle.Information, "Application")

            cmbType.Focus()
            cmbType.DroppedDown = True
            Exit Sub
        End If

        If lblEdit.Text = "Save" Then
            '~~> Check if the wordcall does exist
            sql = "SELECT * FROM tbl_application WHERE LCASE(wordcall)=?word AND accountuser=?user"
            Dim exapp As New MySqlCommand(sql, con)
            exapp.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            exapp.Parameters.AddWithValue("?user", frmMenu.username)
            da = New MySqlDataAdapter(exapp)
            ds.Clear()
            da.Fill(ds, "exapp")

            If ds.Tables("exapp").Rows.Count > 0 Then
                message = "The word call that you're trying to use Already exist"
                MsgBox("The word call that you're trying to use already exist", MsgBoxStyle.Information, "Application")

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> Copy the File on My Documents\SendFiles
            Dim appinfo() As String = txtPath.Text.Split("\")
            filename = appinfo(appinfo.Length - 1)
            isFile = True

            Dim destinationFileName As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "SendFiles", filename)

            sql = "SELECT * FROM tbl_computer WHERE NOT (computername=?name AND ipaddress=?ip)"
            Dim complist As New MySqlCommand(sql, con)
            complist.Parameters.AddWithValue("?name", My.Computer.Name)
            complist.Parameters.AddWithValue("?ip", v4())
            da = New MySqlDataAdapter(complist)
            da.Fill(ds, "complist")

            If ds.Tables("complist").Rows.Count > 0 Then
                For a = 1 To ds.Tables("complist").Rows.Count
                    System.IO.File.Copy(txtPath.Text, destinationFileName, True)
                Next
            End If

            sql = "INSERT INTO tbl_application VALUES(?word,?path,?con,?user,?type)"
            Dim addapp As New MySqlCommand(sql, con)
            addapp.Parameters.AddWithValue("?word", txtWordCall.Text)
            addapp.Parameters.AddWithValue("?path", txtPath.Text)
            addapp.Parameters.AddWithValue("?con", txtPath.Text)
            addapp.Parameters.AddWithValue("?user", frmMenu.username)

            If txtPath.Text.ToString = cmbType.Tag.ToString Then
                addapp.Parameters.AddWithValue("?type", "")
            Else
                addapp.Parameters.AddWithValue("?type", cmbType.Tag.ToString)
            End If

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            addapp.ExecuteNonQuery()
            con.Close()

            message = "Successfully registered an Application"
            MsgBox("Successfully registered an Application", MsgBoxStyle.Information, "Application")

            LoadApps()

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lvApp.Enabled = True
            lblAdd.Enabled = True
            lblConfigure.Enabled = True
            lblManage.Enabled = True

            txtWordCall.Enabled = False
            lblBrowse.Enabled = False
            cmbType.Enabled = False
        Else
            '~~> Check if the wordcall does exist
            sql = "SELECT * FROM tbl_application WHERE LCASE(wordcall)=?word AND accountuser=?user AND (NOT LCASE(wordcall)=?call)"
            Dim exapp As New MySqlCommand(sql, con)
            exapp.Parameters.AddWithValue("?word", LCase(txtWordCall.Text))
            exapp.Parameters.AddWithValue("?user", frmMenu.username)
            exapp.Parameters.AddWithValue("?call", LCase(txtWordCall.Tag))
            da = New MySqlDataAdapter(exapp)
            ds.Clear()
            da.Fill(ds, "exapp")

            If ds.Tables("exapp").Rows.Count > 0 Then
                message = "The word call that you're trying to use already exist"
                MsgBox("The word call that you're trying to use already exist", MsgBoxStyle.Information, "Application")

                txtWordCall.Focus()
                Exit Sub
            End If

            '~~> Update the Database
            If Not defpath = conpath Then
                sql = "UPDATE tbl_application SET wordcall=?word, defpath=?path, apptype=?type WHERE wordcall=?call AND accountuser=?user"
                Dim upapp As New MySqlCommand(sql, con)
                upapp.Parameters.AddWithValue("?word", txtWordCall.Text)
                upapp.Parameters.AddWithValue("?path", txtPath.Text)

                If txtPath.Text.ToString = cmbType.Tag.ToString Then
                    upapp.Parameters.AddWithValue("?type", "")
                Else
                    upapp.Parameters.AddWithValue("?type", cmbType.Tag.ToString)
                End If

                upapp.Parameters.AddWithValue("?call", txtWordCall.Tag)
                upapp.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upapp.ExecuteNonQuery()
                con.Close()
            Else
                sql = "UPDATE tbl_application SET wordcall=?word, defpath=?path, conpath=?con, apptype=?type WHERE wordcall=?call AND accountuser=?user"
                Dim upapp As New MySqlCommand(sql, con)
                upapp.Parameters.AddWithValue("?word", txtWordCall.Text)
                upapp.Parameters.AddWithValue("?path", txtPath.Text)
                upapp.Parameters.AddWithValue("?con", txtPath.Text)

                If txtPath.Text.ToString = cmbType.Tag.ToString Then
                    upapp.Parameters.AddWithValue("?type", "")
                Else
                    upapp.Parameters.AddWithValue("?type", cmbType.Tag.ToString)
                End If

                upapp.Parameters.AddWithValue("?call", txtWordCall.Tag)
                upapp.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                upapp.ExecuteNonQuery()
                con.Close()
            End If

            LoadApps()

            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lvApp.Enabled = True
            lblAdd.Enabled = True
            lblConfigure.Enabled = True
            lblManage.Enabled = True

            txtWordCall.Enabled = False
            lblBrowse.Enabled = False
            cmbType.Enabled = False

            message = "Successfully Updated an Application Setting"
            MsgBox("Successfully Updated an Application Setting", MsgBoxStyle.Information, "Application")
        End If
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click
        If lblDelete.Text = "Delete" Then
            If txtWordCall.Text = "" Then
                message = "Please select a File that you want to Delete"
                MsgBox("Please select a File that you want to Delete", MsgBoxStyle.Information, "Application")

                Exit Sub
            End If

            If isSystem = True Then
                message = "Unable to Delete a System's Default Application"
                MsgBox("Unable to Delete a System's Default Application", MsgBoxStyle.Information, "Application")

                Exit Sub
            End If

            Dim pathinfo() As String = txtPath.Text.ToString.Split("\")

            message = "Press 'Yes' to delete the Application.. and 'No' to cancel"

            If MsgBox("Are you sure you want to Delete " & pathinfo(pathinfo.Length - 1) & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Application Setting") = MsgBoxResult.Yes Then
                sql = "DELETE FROM tbl_application WHERE wordcall=?word AND accountuser=?user"
                Dim delapp As New MySqlCommand(sql, con)
                delapp.Parameters.AddWithValue("?word", txtWordCall.Tag)
                delapp.Parameters.AddWithValue("?user", frmMenu.username)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                delapp.ExecuteNonQuery()
                con.Close()

                LoadApps()

                message = "Successfully Deleted an Application"
                MsgBox("Successfully Deleted an Application", MsgBoxStyle.Information, "Application")
            End If
        Else
            lblAdd.Text = "Add"
            lblEdit.Text = "Edit"
            lblDelete.Text = "Delete"

            lblAdd.Enabled = True
            lblEdit.Enabled = True
            lblDelete.Enabled = True
            lblManage.Enabled = True
            lvApp.Enabled = True

            txtWordCall.Enabled = False
            lblBrowse.Enabled = False
            cmbType.Enabled = False
        End If
    End Sub

    Dim lvcount As Integer = 0
    Dim isSystem As Boolean = False

    Private Sub lvApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvApp.Click
        If lvApp.Items.Count > 0 Then
            txtWordCall.Text = lvApp.FocusedItem.Text
            txtWordCall.Tag = lvApp.FocusedItem.Text
            txtPath.Text = lvApp.FocusedItem.SubItems(1).Text

            wordcall = lvApp.FocusedItem.Text
            defpath = lvApp.FocusedItem.SubItems(1).Text
            conpath = lvApp.FocusedItem.SubItems(2).Text

            If lvApp.FocusedItem.SubItems(3).Text = "" Then
                sql = "SELECT * FROM tbl_apptype WHERE pathname=?path"
                Dim apptype As New MySqlCommand(sql, con)
                apptype.Parameters.AddWithValue("?path", lvApp.FocusedItem.SubItems(1).Text)
                da = New MySqlDataAdapter(apptype)
                ds.Clear()
                da.Fill(ds, "selapp")

                If ds.Tables("selapp").Rows.Count > 0 Then
                    cmbType.Tag = ds.Tables("selapp").Rows(0).Item("pathname").ToString
                    cmbType.Text = ds.Tables("selapp").Rows(0).Item("appname").ToString
                Else
                    txtWordCall.Text = ""
                    txtWordCall.Tag = ""
                    txtPath.Text = ""

                    wordcall = ""
                    defpath = ""
                    conpath = ""

                    cmbType.Text = ""
                    cmbType.Tag = ""

                    message = "The Application Type is not registered"
                    MsgBox("The Application Type is not registered", MsgBoxStyle.Information, "Application")

                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarapp)

                    frmManage.ShowDialog()
                End If
            Else
                Dim appinfo() As String = lvApp.FocusedItem.SubItems(3).Text.Split("/")

                sql = "SELECT * FROM tbl_apptype WHERE pathname=?path"
                Dim apptype As New MySqlCommand(sql, con)
                apptype.Parameters.AddWithValue("?path", appinfo(0))
                da = New MySqlDataAdapter(apptype)
                ds.Clear()
                da.Fill(ds, "selapp")

                If ds.Tables("selapp").Rows.Count > 0 Then
                    cmbType.Tag = ds.Tables("selapp").Rows(0).Item("pathname").ToString
                    cmbType.Text = ds.Tables("selapp").Rows(0).Item("appname").ToString
                Else
                    txtWordCall.Text = ""
                    txtWordCall.Tag = ""
                    txtPath.Text = ""

                    wordcall = ""
                    defpath = ""
                    conpath = ""

                    cmbType.Text = ""
                    cmbType.Tag = ""

                    message = "The Application Type is not registered"
                    MsgBox("The Application Type is not registered", MsgBoxStyle.Information, "Application")

                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarapp)

                    frmManage.ShowDialog()
                End If
            End If

            If lvApp.FocusedItem.SubItems(4).Text = "Yes" Then
                isSystem = True
            Else
                isSystem = False
            End If
        End If
    End Sub

    Private Sub lvApp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvApp.SelectedIndexChanged

    End Sub

    Private Sub lblEdit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEdit.MouseLeave
        lblEdit.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblEdit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEdit.MouseMove
        lblEdit.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub lblDelete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDelete.MouseLeave
        lblDelete.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblDelete_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDelete.MouseMove
        lblDelete.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Dim concount As Integer = 0

    Private Sub lblConfigure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblConfigure.Click
        If txtWordCall.Text = "" Then
            message = "Please select a File that you want to Configure the Path"
            MsgBox("Please select a File that you want to Configure the Path", MsgBoxStyle.Information, "Application")

            Exit Sub
        End If

        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarapp)
        Catch : End Try

        frmConfigure.prevform = "application"
        frmConfigure.txtPath.Text = conpath
        frmConfigure.ShowDialog()
    End Sub

    Private Sub lblConfigure_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblConfigure.MouseLeave
        lblConfigure.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblConfigure_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblConfigure.MouseMove
        lblConfigure.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub lblManage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblManage.Click
        Try
            rec.RecognizeAsyncStop()
            rec.UnloadGrammar(grammarapp)
        Catch : End Try

        frmManage.ShowDialog()
    End Sub

    Private Sub lblManage_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblManage.MouseLeave
        lblManage.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblManage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblManage.MouseMove
        lblManage.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub cmbType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.Items.Count > 0 Then
            cmbType.Tag = apptypepath(cmbType.SelectedIndex)
        End If
    End Sub

    Public isHelp As Boolean = False

    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        If lblEdit.Text = "Edit" Then
            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ToolTip3.Show("Click 'Manage Application' to configure the type to Open Application", Me.lblManage, 5000)

            ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
            ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
            ToolTip3.Show("Click 'Manage Application' to configure the type to Open Application", Me.lblManage, 5000)
        ElseIf lblEdit.Text = "Save" Then
            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
        ElseIf lblEdit.Text = "Update" Then
            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
            ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

            ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
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

    Private Sub txtWordCall_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWordCall.KeyPress
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

    Private Sub txtWordCall_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWordCall.TextChanged

    End Sub

    Private Sub rec_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles rec.SpeechRecognized
        If e.Result.Text = "close" Then
            message = "Closing"
            Try
                rec.RecognizeAsyncStop()
                rec.UnloadGrammar(grammarapp)
            Catch : End Try
            Animation.Tag = "Hide"
            Animation.Start()
        ElseIf e.Result.Text = "help" Then
            If lblEdit.Text = "Edit" Then
                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
                ToolTip3.Show("Click 'Manage Application' to configure the type to Open Application", Me.lblManage, 5000)

                ToolTip1.Show("Select an Application from the List that you want to Edi/Delete", Me.lvApp, 5000)
                ToolTip2.Show("Click 'Add' to add a new Application", Me.lblAdd, 5000)
                ToolTip3.Show("Click 'Manage Application' to configure the type to Open Application", Me.lblManage, 5000)
            ElseIf lblEdit.Text = "Save" Then
                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Save' to save the new Application", Me.lblEdit, 5000)
            ElseIf lblEdit.Text = "Update" Then
                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)

                ToolTip1.Show("Fill up the Form", Me.txtWordCall, 5000)
                ToolTip2.Show("Click 'Update' to save the changes for Application", Me.lblEdit, 5000)
            End If
        ElseIf e.Result.Text = "add" Then
            If lblAdd.Enabled = True Then
                lblEdit.Text = "Save"
                lblDelete.Text = "Cancel"

                lvApp.Enabled = False
                lblAdd.Enabled = False
                lblConfigure.Enabled = False
                lblManage.Enabled = False

                txtWordCall.Enabled = True
                lblBrowse.Enabled = True
                cmbType.Enabled = True

                txtWordCall.Text = ""
                txtPath.Text = ""
                cmbType.Text = ""
                cmbType.Tag = ""

                txtWordCall.Focus()
            End If
        ElseIf e.Result.Text = "edit" Then
            If lblEdit.Text = "Edit" Then
                If txtWordCall.Text = "" Then
                    message = "Please select an Application that you want to Edit"
                    MsgBox("Please select an Application that you want to Edit", MsgBoxStyle.Information, "Application")

                    Exit Sub
                End If

                If isSystem = True Then
                    message = "Unable to Edit a System's Default Application"
                    MsgBox("Unable to Edit a System's Default Application", MsgBoxStyle.Information, "Application")

                    Exit Sub
                End If

                lblEdit.Text = "Update"
                lblDelete.Text = "Cancel"

                lvApp.Enabled = False
                lblAdd.Enabled = False
                lblConfigure.Enabled = False
                lblManage.Enabled = False

                txtWordCall.Enabled = True
                lblBrowse.Enabled = True
                cmbType.Enabled = True

                txtWordCall.Focus()
            End If
        ElseIf e.Result.Text = "update" Then
            If lblEdit.Text = "Update" Then
                SaveUpdate()
            End If
        ElseIf e.Result.Text = "save" Then
            If lblEdit.Text = "Save" Then
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
                lblManage.Enabled = True
                lvApp.Enabled = True

                txtWordCall.Enabled = False
                lblBrowse.Enabled = False
                cmbType.Enabled = False
            End If
        ElseIf e.Result.Text = "delete" Then
            If lblDelete.Text = "Delete" Then
                If txtWordCall.Text = "" Then
                    message = "Please select a File that you want to Delete"
                    MsgBox("Please select a File that you want to Delete", MsgBoxStyle.Information, "Application")

                    Exit Sub
                End If

                If isSystem = True Then
                    message = "Unable to Delete a System's Default Application"
                    MsgBox("Unable to Delete a System's Default Application", MsgBoxStyle.Information, "Application")

                    Exit Sub
                End If

                Dim pathinfo() As String = txtPath.Text.ToString.Split("\")

                message = "Press 'Yes' to Delete an Application.. and 'No' to cancel"

                If MsgBox("Are you sure you want to Delete " & pathinfo(pathinfo.Length - 1) & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Application Setting") = MsgBoxResult.Yes Then
                    sql = "DELETE FROM tbl_application WHERE wordcall=?word AND accountuser=?user"
                    Dim delapp As New MySqlCommand(sql, con)
                    delapp.Parameters.AddWithValue("?word", txtWordCall.Tag)
                    delapp.Parameters.AddWithValue("?user", frmMenu.username)

                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If

                    delapp.ExecuteNonQuery()
                    con.Close()

                    LoadApps()

                    message = "Successfully Deleted an Application"
                    MsgBox("Successfully Deleted an Application", MsgBoxStyle.Information, "Application")
                End If
            End If
        ElseIf e.Result.Text = "manage" Then
            If lblManage.Enabled = True Then
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarapp)
                Catch : End Try

                frmManage.ShowDialog()
            End If
        ElseIf e.Result.Text = "configure" Then
            If lblConfigure.Enabled = True Then
                If txtWordCall.Text = "" Then
                    message = "Please select a File that you want to Configure the Path"
                    MsgBox("Please select a File that you want to Configure the Path", MsgBoxStyle.Information, "Application")

                    Exit Sub
                End If

                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarapp)
                Catch : End Try

                frmConfigure.txtPath.Text = conpath
                frmConfigure.ShowDialog()
            End If
        ElseIf e.Result.Text = "browse" Then
            If lblBrowse.Enabled = True Then
                Try
                    rec.RecognizeAsyncStop()
                    rec.UnloadGrammar(grammarapp)
                Catch : End Try

                If ofdApplication.ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtPath.Text = ofdApplication.FileName
                End If

                Try
                    rec.LoadGrammar(grammarapp)
                    rec.SetInputToDefaultAudioDevice()
                    rec.RecognizeAsync(1)
                Catch : End Try
            End If
        End If

        Exit Sub
    End Sub

End Class