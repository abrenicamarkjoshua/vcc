Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmBackupdb

    Private Sub btn_backup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_backup.Click
        If txt_mysqldump.Text = vbNullString Then
            MessageBox.Show("Please locate your mysqldump.", "Voice Command Controller for I.T Laboratory", MessageBoxButtons.OK)
        ElseIf txtPath.Text = vbNullString Then
            MessageBox.Show("Please select path you want to save your backup Database", "Voice Commnad Controller for I.T Laboratory", MessageBoxButtons.OK)
        Else
            Try
                Process.Start(txt_mysqldump.Text, "-u username -pnunaoppa dod -r """ & txtPath.Text & "DOD.sql")
                message = "Successfully created a backup sql file of your database"
                MessageBox.Show("Successfully created a backup sql file of your database", "Voice Commnad Controller For I.T Laboratory", MessageBoxButtons.OK)

                txt_mysqldump.Text = ""
                txtPath.Text = vbNullString
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_restore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restore.Click
        Try
            Dim myProcess As New Process()
            myProcess.StartInfo.FileName = "cmd.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.Start()
            Dim myStreamWriter As StreamWriter = myProcess.StandardInput
            Dim mystreamreader As StreamReader = myProcess.StandardOutput
            myStreamWriter.WriteLine("mysql -u username -pnunaoppa DOD < " & txtPath.Text & "DOD.sql")

            myStreamWriter.Close()
            myProcess.WaitForExit()
            myProcess.Close()

            message = "Database was successfully restored"
            MsgBox("Database was successfully restored", MsgBoxStyle.Information, "Restore Database")
        Catch ex As Exception
            message = "Unable to locate your SQL file"
            MsgBox("Unable to locate your SQL file", MsgBoxStyle.Information, "Restore Database")
        End Try
    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        If ofdApplication.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_mysqldump.Text = ofdApplication.FileName
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub frmBackupdb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Sub LoadDrives()
        cmb_Path.Items.Clear()

        Dim sDrive As String, sDrives() As String
        sDrives = ListAllDrives()

        For Each sDrive In sDrives
            cmb_Path.Items.Add(sDrive.ToString)
        Next
    End Sub

    Public Function ListAllDrives() As String()
        Dim Drivesarr() As String
        Drivesarr = Directory.GetLogicalDrives()

        Return Drivesarr
    End Function

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadDrives()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Me.Close()
            End If
        End If
    End Sub

    Private Sub ofdApplication_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdApplication.FileOk

    End Sub

    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        If fbdPath.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtPath.Text = fbdPath.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

End Class