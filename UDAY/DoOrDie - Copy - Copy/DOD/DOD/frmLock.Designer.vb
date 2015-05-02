<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblBot = New System.Windows.Forms.Label()
        Me.StudentPanel = New System.Windows.Forms.Panel()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblChangePassword = New System.Windows.Forms.Label()
        Me.lblLogout = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LoginPanel = New System.Windows.Forms.Panel()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.pbLogin = New System.Windows.Forms.PictureBox()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.ChangePasswordPanel = New System.Windows.Forms.Panel()
        Me.lblShowRetype = New System.Windows.Forms.Label()
        Me.txtRetype = New System.Windows.Forms.TextBox()
        Me.lblShowNew = New System.Windows.Forms.Label()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.lblShowOld = New System.Windows.Forms.Label()
        Me.txtOld = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ShowMessage = New System.Windows.Forms.Timer(Me.components)
        Me.CheckCommand = New System.Windows.Forms.Timer(Me.components)
        Me.CheckTime = New System.Windows.Forms.Timer(Me.components)
        Me.CheckInfo = New System.Windows.Forms.Timer(Me.components)
        Me.Disable = New System.Windows.Forms.Timer(Me.components)
        Me.CheckName = New System.Windows.Forms.Timer(Me.components)
        Me.Instruction = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPCName = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ReminderPanel = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.StudentPanel.SuspendLayout()
        Me.LoginPanel.SuspendLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChangePasswordPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ReminderPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 330)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(550, 15)
        Me.Label1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 340)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(518, 15)
        Me.Label2.TabIndex = 4
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.lblTop)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.lblRight)
        Me.Panel1.Controls.Add(Me.lblLeft)
        Me.Panel1.Controls.Add(Me.lblBot)
        Me.Panel1.Controls.Add(Me.StudentPanel)
        Me.Panel1.Controls.Add(Me.LoginPanel)
        Me.Panel1.Controls.Add(Me.ChangePasswordPanel)
        Me.Panel1.Location = New System.Drawing.Point(762, 411)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 250)
        Me.Panel1.TabIndex = 5
        Me.Panel1.Tag = "Login"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(528, 90)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(118, 23)
        Me.CheckBox2.TabIndex = 48
        Me.CheckBox2.Text = "Add to startup"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CheckBox3.Location = New System.Drawing.Point(528, 115)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(50, 19)
        Me.CheckBox3.TabIndex = 49
        Me.CheckBox3.Text = "Melt"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(528, 140)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 23)
        Me.CheckBox1.TabIndex = 47
        Me.CheckBox1.Text = "Copy"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(500, 5)
        Me.lblTop.TabIndex = 35
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 40)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(380, 21)
        Me.lblDescription.TabIndex = 40
        Me.lblDescription.Text = "Enter your username and/or Password to continue . . ."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(143, 28)
        Me.lblTitle.TabIndex = 39
        Me.lblTitle.Text = "Account Login"
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(495, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 250)
        Me.lblRight.TabIndex = 38
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 250)
        Me.lblLeft.TabIndex = 37
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 245)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(500, 5)
        Me.lblBot.TabIndex = 36
        '
        'StudentPanel
        '
        Me.StudentPanel.Controls.Add(Me.lblID)
        Me.StudentPanel.Controls.Add(Me.lblName)
        Me.StudentPanel.Controls.Add(Me.Label9)
        Me.StudentPanel.Controls.Add(Me.lblTime)
        Me.StudentPanel.Controls.Add(Me.lblChangePassword)
        Me.StudentPanel.Controls.Add(Me.lblLogout)
        Me.StudentPanel.Controls.Add(Me.Label3)
        Me.StudentPanel.Controls.Add(Me.Label4)
        Me.StudentPanel.Location = New System.Drawing.Point(27, 90)
        Me.StudentPanel.Name = "StudentPanel"
        Me.StudentPanel.Size = New System.Drawing.Size(445, 134)
        Me.StudentPanel.TabIndex = 42
        Me.StudentPanel.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblID.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblID.Location = New System.Drawing.Point(151, 5)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(61, 21)
        Me.lblID.TabIndex = 25
        Me.lblID.Text = "10-1126"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblName.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblName.Location = New System.Drawing.Point(151, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(213, 21)
        Me.lblName.TabIndex = 24
        Me.lblName.Text = "Morandarte, Ray Mart Tatad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(25, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 21)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Time left :"
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI Semibold", 22.0!)
        Me.lblTime.Location = New System.Drawing.Point(143, 73)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(141, 54)
        Me.lblTime.TabIndex = 22
        Me.lblTime.Text = "00:00:00"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChangePassword
        '
        Me.lblChangePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblChangePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblChangePassword.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblChangePassword.Location = New System.Drawing.Point(290, 73)
        Me.lblChangePassword.Name = "lblChangePassword"
        Me.lblChangePassword.Size = New System.Drawing.Size(150, 25)
        Me.lblChangePassword.TabIndex = 21
        Me.lblChangePassword.Text = "Change Password"
        Me.lblChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLogout
        '
        Me.lblLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLogout.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblLogout.Location = New System.Drawing.Point(290, 102)
        Me.lblLogout.Name = "lblLogout"
        Me.lblLogout.Size = New System.Drawing.Size(150, 25)
        Me.lblLogout.TabIndex = 20
        Me.lblLogout.Text = "Logout"
        Me.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(25, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Student Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(25, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Student No. :"
        '
        'LoginPanel
        '
        Me.LoginPanel.Controls.Add(Me.lblShow)
        Me.LoginPanel.Controls.Add(Me.pbLogin)
        Me.LoginPanel.Controls.Add(Me.lblLogin)
        Me.LoginPanel.Controls.Add(Me.Label6)
        Me.LoginPanel.Controls.Add(Me.txtPassword)
        Me.LoginPanel.Controls.Add(Me.txtUsername)
        Me.LoginPanel.Controls.Add(Me.Label8)
        Me.LoginPanel.Controls.Add(Me.Label11)
        Me.LoginPanel.Controls.Add(Me.lblMessage)
        Me.LoginPanel.Location = New System.Drawing.Point(27, 90)
        Me.LoginPanel.Name = "LoginPanel"
        Me.LoginPanel.Size = New System.Drawing.Size(445, 134)
        Me.LoginPanel.TabIndex = 41
        '
        'lblShow
        '
        Me.lblShow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShow.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShow.Location = New System.Drawing.Point(391, 75)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(53, 23)
        Me.lblShow.TabIndex = 23
        Me.lblShow.Text = "show"
        Me.lblShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbLogin
        '
        Me.pbLogin.Image = Global.DOD.My.Resources.Resources._4
        Me.pbLogin.Location = New System.Drawing.Point(0, 0)
        Me.pbLogin.Name = "pbLogin"
        Me.pbLogin.Size = New System.Drawing.Size(130, 134)
        Me.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogin.TabIndex = 21
        Me.pbLogin.TabStop = False
        '
        'lblLogin
        '
        Me.lblLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLogin.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblLogin.Location = New System.Drawing.Point(165, 109)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(280, 25)
        Me.lblLogin.TabIndex = 19
        Me.lblLogin.Text = "Login"
        Me.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(161, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(245, 74)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(200, 25)
        Me.txtPassword.TabIndex = 17
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(245, 39)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(200, 25)
        Me.txtUsername.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(161, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 21)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Username"
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.LightCoral
        Me.Label11.Location = New System.Drawing.Point(165, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(280, 60)
        Me.Label11.TabIndex = 22
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage
        '
        Me.lblMessage.ForeColor = System.Drawing.Color.LightCoral
        Me.lblMessage.Location = New System.Drawing.Point(165, 50)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(280, 19)
        Me.lblMessage.TabIndex = 20
        Me.lblMessage.Text = "Your account is already online"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChangePasswordPanel
        '
        Me.ChangePasswordPanel.Controls.Add(Me.lblShowRetype)
        Me.ChangePasswordPanel.Controls.Add(Me.txtRetype)
        Me.ChangePasswordPanel.Controls.Add(Me.lblShowNew)
        Me.ChangePasswordPanel.Controls.Add(Me.txtNew)
        Me.ChangePasswordPanel.Controls.Add(Me.lblShowOld)
        Me.ChangePasswordPanel.Controls.Add(Me.txtOld)
        Me.ChangePasswordPanel.Controls.Add(Me.Label10)
        Me.ChangePasswordPanel.Controls.Add(Me.lblSave)
        Me.ChangePasswordPanel.Controls.Add(Me.lblCancel)
        Me.ChangePasswordPanel.Controls.Add(Me.Label14)
        Me.ChangePasswordPanel.Controls.Add(Me.Label15)
        Me.ChangePasswordPanel.Location = New System.Drawing.Point(27, 90)
        Me.ChangePasswordPanel.Name = "ChangePasswordPanel"
        Me.ChangePasswordPanel.Size = New System.Drawing.Size(445, 134)
        Me.ChangePasswordPanel.TabIndex = 43
        Me.ChangePasswordPanel.Visible = False
        '
        'lblShowRetype
        '
        Me.lblShowRetype.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowRetype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowRetype.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowRetype.Location = New System.Drawing.Point(388, 70)
        Me.lblShowRetype.Name = "lblShowRetype"
        Me.lblShowRetype.Size = New System.Drawing.Size(50, 23)
        Me.lblShowRetype.TabIndex = 29
        Me.lblShowRetype.Text = "show"
        Me.lblShowRetype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRetype
        '
        Me.txtRetype.Location = New System.Drawing.Point(169, 69)
        Me.txtRetype.Name = "txtRetype"
        Me.txtRetype.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetype.Size = New System.Drawing.Size(270, 25)
        Me.txtRetype.TabIndex = 28
        '
        'lblShowNew
        '
        Me.lblShowNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowNew.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowNew.Location = New System.Drawing.Point(388, 39)
        Me.lblShowNew.Name = "lblShowNew"
        Me.lblShowNew.Size = New System.Drawing.Size(50, 23)
        Me.lblShowNew.TabIndex = 27
        Me.lblShowNew.Text = "show"
        Me.lblShowNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNew
        '
        Me.txtNew.Location = New System.Drawing.Point(169, 38)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNew.Size = New System.Drawing.Size(270, 25)
        Me.txtNew.TabIndex = 26
        '
        'lblShowOld
        '
        Me.lblShowOld.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowOld.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowOld.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowOld.Location = New System.Drawing.Point(388, 8)
        Me.lblShowOld.Name = "lblShowOld"
        Me.lblShowOld.Size = New System.Drawing.Size(50, 23)
        Me.lblShowOld.TabIndex = 25
        Me.lblShowOld.Text = "show"
        Me.lblShowOld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOld
        '
        Me.txtOld.Location = New System.Drawing.Point(169, 7)
        Me.txtOld.Name = "txtOld"
        Me.txtOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOld.Size = New System.Drawing.Size(270, 25)
        Me.txtOld.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(25, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 21)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Retype Password :"
        '
        'lblSave
        '
        Me.lblSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSave.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSave.Location = New System.Drawing.Point(26, 102)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(258, 25)
        Me.lblSave.TabIndex = 21
        Me.lblSave.Text = "Save Changes"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCancel
        '
        Me.lblCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblCancel.Location = New System.Drawing.Point(289, 102)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(150, 25)
        Me.lblCancel.TabIndex = 20
        Me.lblCancel.Text = "Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label14.Location = New System.Drawing.Point(25, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 21)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "New Password :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label15.Location = New System.Drawing.Point(25, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 21)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Old Password :"
        '
        'ShowMessage
        '
        Me.ShowMessage.Interval = 10
        Me.ShowMessage.Tag = "Show"
        '
        'CheckCommand
        '
        Me.CheckCommand.Tag = "Show"
        '
        'CheckTime
        '
        Me.CheckTime.Interval = 10
        Me.CheckTime.Tag = "Show"
        '
        'CheckInfo
        '
        Me.CheckInfo.Tag = "Show"
        '
        'Disable
        '
        Me.Disable.Interval = 10
        Me.Disable.Tag = ""
        '
        'CheckName
        '
        Me.CheckName.Interval = 10
        Me.CheckName.Tag = ""
        '
        'Instruction
        '
        Me.Instruction.Tag = "Show"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.DOD.My.Resources.Resources.LockBG
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblPCName)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1354, 733)
        Me.Panel2.TabIndex = 6
        '
        'lblPCName
        '
        Me.lblPCName.Font = New System.Drawing.Font("Segoe UI Semibold", 30.0!)
        Me.lblPCName.Location = New System.Drawing.Point(1040, 15)
        Me.lblPCName.Name = "lblPCName"
        Me.lblPCName.Size = New System.Drawing.Size(300, 100)
        Me.lblPCName.TabIndex = 0
        Me.lblPCName.Text = "SERVER"
        Me.lblPCName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.DOD.My.Resources.Resources.LockBG
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.ReminderPanel)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1354, 733)
        Me.Panel3.TabIndex = 7
        '
        'ReminderPanel
        '
        Me.ReminderPanel.Controls.Add(Me.Label7)
        Me.ReminderPanel.Controls.Add(Me.lblInstruction)
        Me.ReminderPanel.Location = New System.Drawing.Point(21, 526)
        Me.ReminderPanel.Name = "ReminderPanel"
        Me.ReminderPanel.Size = New System.Drawing.Size(440, 130)
        Me.ReminderPanel.TabIndex = 43
        Me.ReminderPanel.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.Label7.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label7.Location = New System.Drawing.Point(10, -1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 28)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "** Reminder **"
        '
        'lblInstruction
        '
        Me.lblInstruction.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblInstruction.ForeColor = System.Drawing.Color.White
        Me.lblInstruction.Location = New System.Drawing.Point(10, 27)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(420, 83)
        Me.lblInstruction.TabIndex = 40
        Me.lblInstruction.Text = "- Save your Activity in . . . "" My Documents / Activity """ & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Activity won't be sa" & _
            "ve when the time runs out"
        Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(-616, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(616, 484)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'frmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLock"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "7"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StudentPanel.ResumeLayout(False)
        Me.StudentPanel.PerformLayout()
        Me.LoginPanel.ResumeLayout(False)
        Me.LoginPanel.PerformLayout()
        CType(Me.pbLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChangePasswordPanel.ResumeLayout(False)
        Me.ChangePasswordPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ReminderPanel.ResumeLayout(False)
        Me.ReminderPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents ChangePasswordPanel As System.Windows.Forms.Panel
    Friend WithEvents lblShowRetype As System.Windows.Forms.Label
    Friend WithEvents txtRetype As System.Windows.Forms.TextBox
    Friend WithEvents lblShowNew As System.Windows.Forms.Label
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblShowOld As System.Windows.Forms.Label
    Friend WithEvents txtOld As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents StudentPanel As System.Windows.Forms.Panel
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblChangePassword As System.Windows.Forms.Label
    Friend WithEvents lblLogout As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents LoginPanel As System.Windows.Forms.Panel
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents pbLogin As System.Windows.Forms.PictureBox
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ShowMessage As System.Windows.Forms.Timer
    Friend WithEvents CheckCommand As System.Windows.Forms.Timer
    Friend WithEvents CheckTime As System.Windows.Forms.Timer
    Friend WithEvents CheckInfo As System.Windows.Forms.Timer
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Disable As System.Windows.Forms.Timer
    Friend WithEvents lblPCName As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CheckName As System.Windows.Forms.Timer
    Friend WithEvents Instruction As System.Windows.Forms.Timer
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents ReminderPanel As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
