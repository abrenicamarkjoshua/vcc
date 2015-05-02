<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudentRegistration
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
        Me.txtRetype = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblBot = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMiddlename = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.lblClear = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSchedule = New System.Windows.Forms.Label()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.lblShowPassword = New System.Windows.Forms.Label()
        Me.lblShowRetype = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.CheckServer = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtStudentid = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFullname = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtRetype
        '
        Me.txtRetype.Location = New System.Drawing.Point(167, 425)
        Me.txtRetype.MaxLength = 50
        Me.txtRetype.Name = "txtRetype"
        Me.txtRetype.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetype.Size = New System.Drawing.Size(212, 25)
        Me.txtRetype.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(71, 425)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 21)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Retype"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(71, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 21)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Student ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(23, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 21)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Student Information"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(368, 17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 81
        Me.lblClose.Text = "Close"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(347, 21)
        Me.lblDescription.TabIndex = 80
        Me.lblDescription.Text = "Allows the Student to Register their own account"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(197, 28)
        Me.lblTitle.TabIndex = 79
        Me.lblTitle.Text = "Student Registration"
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(445, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 550)
        Me.lblRight.TabIndex = 78
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 550)
        Me.lblLeft.TabIndex = 77
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 545)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(450, 5)
        Me.lblBot.TabIndex = 76
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(450, 5)
        Me.lblTop.TabIndex = 75
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(71, 394)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 21)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Password"
        '
        'txtMiddlename
        '
        Me.txtMiddlename.Location = New System.Drawing.Point(167, 350)
        Me.txtMiddlename.MaxLength = 100
        Me.txtMiddlename.Name = "txtMiddlename"
        Me.txtMiddlename.Size = New System.Drawing.Size(212, 25)
        Me.txtMiddlename.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(71, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 21)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Middlename"
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(167, 319)
        Me.txtFirstname.MaxLength = 100
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(212, 25)
        Me.txtFirstname.TabIndex = 2
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(167, 394)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(212, 25)
        Me.txtPassword.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(71, 319)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 21)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Firstname"
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(167, 288)
        Me.txtLastname.MaxLength = 100
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(212, 25)
        Me.txtLastname.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(71, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 21)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Lastname"
        '
        'lblSave
        '
        Me.lblSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSave.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSave.Location = New System.Drawing.Point(75, 465)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(304, 30)
        Me.lblSave.TabIndex = 95
        Me.lblSave.Text = "Save New Student"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClear
        '
        Me.lblClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClear.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblClear.Location = New System.Drawing.Point(75, 500)
        Me.lblClear.Name = "lblClear"
        Me.lblClear.Size = New System.Drawing.Size(304, 30)
        Me.lblClear.TabIndex = 96
        Me.lblClear.Text = "Clear "
        Me.lblClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(23, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 21)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Current Professor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(87, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 21)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Section"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label11.Location = New System.Drawing.Point(77, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 21)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Schedule"
        '
        'lblSchedule
        '
        Me.lblSchedule.AutoSize = True
        Me.lblSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblSchedule.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblSchedule.Location = New System.Drawing.Point(163, 140)
        Me.lblSchedule.Name = "lblSchedule"
        Me.lblSchedule.Size = New System.Drawing.Size(77, 21)
        Me.lblSchedule.TabIndex = 100
        Me.lblSchedule.Text = "Schedule"
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblSection.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblSection.Location = New System.Drawing.Point(163, 110)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(77, 21)
        Me.lblSection.TabIndex = 101
        Me.lblSection.Text = "Schedule"
        '
        'lblShowPassword
        '
        Me.lblShowPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowPassword.ForeColor = System.Drawing.Color.White
        Me.lblShowPassword.Location = New System.Drawing.Point(327, 396)
        Me.lblShowPassword.Name = "lblShowPassword"
        Me.lblShowPassword.Size = New System.Drawing.Size(50, 21)
        Me.lblShowPassword.TabIndex = 102
        Me.lblShowPassword.Text = "show"
        Me.lblShowPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblShowRetype
        '
        Me.lblShowRetype.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowRetype.ForeColor = System.Drawing.Color.White
        Me.lblShowRetype.Location = New System.Drawing.Point(327, 427)
        Me.lblShowRetype.Name = "lblShowRetype"
        Me.lblShowRetype.Size = New System.Drawing.Size(50, 21)
        Me.lblShowRetype.TabIndex = 103
        Me.lblShowRetype.Text = "show"
        Me.lblShowRetype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblUser.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblUser.Location = New System.Drawing.Point(163, 80)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(77, 21)
        Me.lblUser.TabIndex = 105
        Me.lblUser.Text = "Schedule"
        '
        'CheckServer
        '
        Me.CheckServer.Interval = 10
        Me.CheckServer.Tag = ""
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(516, 203)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(118, 23)
        Me.CheckBox2.TabIndex = 107
        Me.CheckBox2.Text = "Add to startup"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CheckBox3.Location = New System.Drawing.Point(516, 228)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(50, 19)
        Me.CheckBox3.TabIndex = 108
        Me.CheckBox3.Text = "Melt"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(516, 245)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 23)
        Me.CheckBox1.TabIndex = 106
        Me.CheckBox1.Text = "Copy"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtStudentid
        '
        Me.txtStudentid.Location = New System.Drawing.Point(167, 257)
        Me.txtStudentid.Mask = "00-0000"
        Me.txtStudentid.Name = "txtStudentid"
        Me.txtStudentid.Size = New System.Drawing.Size(212, 25)
        Me.txtStudentid.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkGray
        Me.Label12.Location = New System.Drawing.Point(118, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 21)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "( Student ID will be your Username )"
        '
        'lblFullname
        '
        Me.lblFullname.AutoSize = True
        Me.lblFullname.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblFullname.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblFullname.Location = New System.Drawing.Point(163, 80)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(77, 21)
        Me.lblFullname.TabIndex = 110
        Me.lblFullname.Text = "Schedule"
        '
        'frmStudentRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(450, 550)
        Me.Controls.Add(Me.lblFullname)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtStudentid)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblShowRetype)
        Me.Controls.Add(Me.lblShowPassword)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.lblSchedule)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClear)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.txtRetype)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblBot)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMiddlename)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFirstname)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtLastname)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmStudentRegistration"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRetype As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMiddlename As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFirstname As System.Windows.Forms.TextBox
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLastname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents lblClear As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSchedule As System.Windows.Forms.Label
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents lblShowPassword As System.Windows.Forms.Label
    Friend WithEvents lblShowRetype As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents CheckServer As System.Windows.Forms.Timer
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtStudentid As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFullname As System.Windows.Forms.Label
End Class
