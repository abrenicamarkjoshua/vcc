Imports MySql.Data.MySqlClient

Public Class frmSetServer
    Public whatform As String

    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click
        ChangeIP()
    End Sub

    Sub ChangeIP()
        If txtServer.Text = "" Then
            MsgBox("Please enter the Server IP of the New Server", MsgBoxStyle.Information, "Server IP")
            txtServer.Focus()

            Exit Sub
        End If

        If txtServer.Text = "voice.command" Then
            My.Settings.ServerIP = v4()
            My.Settings.Save()

            isServer = True

            GoTo anim
        End If

        My.Settings.ServerIP = txtServer.Text
        My.Settings.isServer = True
        My.Settings.Save()

        isServer = False

anim:
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Public isServer As Boolean = False

    Sub CreateDatabase()
        Try
            con.ConnectionString = "Server=localhost;Database=mysql;Uid=root;Pwd=qwerty;"

            '~~> Create the Database
            sql = "CREATE DATABASE dod"
            Dim createdatabase As New MySqlCommand(sql, con)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            createdatabase.ExecuteNonQuery()

            '~~> Change the Database to 'dod'
            con.ChangeDatabase("dod")

            '~~> Create all the tables
            CreateTable("tbl_account", "accountuser VARCHAR(20), accountpass VARCHAR(255),lastname VARCHAR(100), firstname VARCHAR(100), middlename VARCHAR(100), isTutorial VARCHAR(5), gender VARCHAR(10)")
            CreateTable("tbl_application", "wordcall VARCHAR(100), defpath VARCHAR(500), conpath VARCHAR(500), accountuser VARCHAR(100), apptype VARCHAR(500)")
            CreateTable("tbl_apptype", "appname VARCHAR(255), pathname VARCHAR(500), isServer VARCHAR(500), conpath VARCHAR(500)")
            CreateTable("tbl_attendance", "studentid VARCHAR(50), loginfo VARCHAR(100), computername VARCHAR(255), major VARCHAR(50), year VARCHAR(50), section VARCHAR(50), subject VARCHAR(100), accountuser VARCHAR(50)")
            CreateTable("tbl_commandpc", "computername VARCHAR(100), ipaddress VARCHAR(255), commandpc VARCHAR(1000), concommand VARCHAR(1000)")
            CreateTable("tbl_computer", "wordcall VARCHAR(100), computername VARCHAR(100), ipaddress VARCHAR(255), actdone VARCHAR(50)")
            CreateTable("tbl_keyword", "keywordcall VARCHAR(100), toprint VARCHAR(500), accountuser VARCHAR(100), isSystem VARCHAR(50)")
            CreateTable("tbl_login", "studentid VARCHAR(100), pcname VARCHAR(100)")
            CreateTable("tbl_oncreate", "onCreate VARCHAR(5)")
            CreateTable("tbl_schedule", "accountuser VARCHAR(100), major VARCHAR(50), year VARCHAR(50), section VARCHAR(50), subject VARCHAR(100), daysched VARCHAR(50), dayin VARCHAR(50), dayout VARCHAR(50), status VARCHAR(10)")
            CreateTable("tbl_setting", "username VARCHAR(100)")
            CreateTable("tbl_student", "studentid VARCHAR(100), studentlname VARCHAR(255), studentfname VARCHAR(255), studentmname VARCHAR(255), major VARCHAR(50), year VARCHAR(50), section VARCHAR(50), subject VARCHAR(50), studentpass VARCHAR(100), accountuser VARCHAR(100), status VARCHAR(10)")
            CreateTable("tbl_timer", "computername VARCHAR(100), ipaddress VARCHAR(100), pcin VARCHAR(255), pcsec VARCHAR(50), status VARCHAR(50)")
            CreateTable("tbl_word", "wordcall VARCHAR(100), toprint VARCHAR(500), avail VARCHAR(10), accountuser VARCHAR(100)")

            '~~> Add the Defaults (Outdated)
            sql = "INSERT INTO tbl_oncreate VALUES('No')"
            Dim addoncreate As New MySqlCommand(sql, con)

            addoncreate.ExecuteNonQuery()

            con.Close()
        Catch ex As Exception
            MsgBox("Error on creating a database" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Database Error")
        End Try
    End Sub

    Sub CreateTable(ByVal TableName As String, ByVal TableInformation As String)
        sql = "CREATE TABLE IF NOT EXISTS " & TableName & "(" & TableInformation & ")"
        Dim createtable As New MySqlCommand(sql, con)

        createtable.ExecuteNonQuery()
    End Sub

    Private Sub lblSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSave.MouseLeave
        lblSave.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblSave_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblSave.MouseMove
        lblSave.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 0.95 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                txtServer.Text = My.Settings.ServerIP.ToString
                txtServer.Focus()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                If isServer = True Then
                    Dim serverproc As New Process
                    serverproc.StartInfo.FileName = Application.StartupPath & "\" & "CreateServer.exe"
                    serverproc.Start()
                Else
                    Dim newproc As New Process
                    newproc.StartInfo.FileName = Application.StartupPath & "\" & "RestartDOD.exe"
                    newproc.Start()
                End If

                Application.Exit()

                End

                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmSetServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Private Sub txtServer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServer.GotFocus
        txtServer.SelectAll()
    End Sub

    Private Sub txtServer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtServer.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChangeIP()
        End If
    End Sub

    Private Sub txtServer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServer.KeyPress

    End Sub

    Private Sub txtServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServer.TextChanged

    End Sub
End Class