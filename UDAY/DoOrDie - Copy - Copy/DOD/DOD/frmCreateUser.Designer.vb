<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateUser
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
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblBot = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.PersonalPanel = New System.Windows.Forms.Panel()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblMiddlename = New System.Windows.Forms.Label()
        Me.lblFirstname = New System.Windows.Forms.Label()
        Me.lblLastname = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMiddlename = New System.Windows.Forms.TextBox()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblShowRetype = New System.Windows.Forms.Label()
        Me.txtRetype = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblShowPass = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.lblSectionSchedule = New System.Windows.Forms.Label()
        Me.lblIndicator = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.SchedulePanel = New System.Windows.Forms.Panel()
        Me.txtMajor = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.ComboBox()
        Me.txtOUT = New System.Windows.Forms.TextBox()
        Me.txtIN = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbOUT = New System.Windows.Forms.ComboBox()
        Me.cmbIN = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbDay = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvSections = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblAECancel = New System.Windows.Forms.Label()
        Me.lblEdit = New System.Windows.Forms.Label()
        Me.lblDelete = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.MoveIndicator = New System.Windows.Forms.Timer(Me.components)
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.ShowMessage = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PersonalPanel.SuspendLayout()
        Me.SchedulePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(423, 21)
        Me.lblDescription.TabIndex = 11
        Me.lblDescription.Text = "Provide the following information to create your account . . ."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(150, 28)
        Me.lblTitle.TabIndex = 10
        Me.lblTitle.Text = "Create Account"
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(895, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 500)
        Me.lblRight.TabIndex = 9
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 500)
        Me.lblLeft.TabIndex = 8
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 495)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(900, 5)
        Me.lblBot.TabIndex = 7
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(900, 5)
        Me.lblTop.TabIndex = 6
        '
        'PersonalPanel
        '
        Me.PersonalPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.PersonalPanel.Controls.Add(Me.lblGender)
        Me.PersonalPanel.Controls.Add(Me.lblMiddlename)
        Me.PersonalPanel.Controls.Add(Me.lblFirstname)
        Me.PersonalPanel.Controls.Add(Me.lblLastname)
        Me.PersonalPanel.Controls.Add(Me.lblPassword)
        Me.PersonalPanel.Controls.Add(Me.lblUsername)
        Me.PersonalPanel.Controls.Add(Me.Label17)
        Me.PersonalPanel.Controls.Add(Me.Label16)
        Me.PersonalPanel.Controls.Add(Me.cmbGender)
        Me.PersonalPanel.Controls.Add(Me.Label15)
        Me.PersonalPanel.Controls.Add(Me.Label5)
        Me.PersonalPanel.Controls.Add(Me.txtMiddlename)
        Me.PersonalPanel.Controls.Add(Me.txtLastname)
        Me.PersonalPanel.Controls.Add(Me.Label6)
        Me.PersonalPanel.Controls.Add(Me.Label7)
        Me.PersonalPanel.Controls.Add(Me.txtFirstname)
        Me.PersonalPanel.Controls.Add(Me.Label3)
        Me.PersonalPanel.Controls.Add(Me.lblShowRetype)
        Me.PersonalPanel.Controls.Add(Me.txtRetype)
        Me.PersonalPanel.Controls.Add(Me.txtUsername)
        Me.PersonalPanel.Controls.Add(Me.Label2)
        Me.PersonalPanel.Controls.Add(Me.Label1)
        Me.PersonalPanel.Controls.Add(Me.lblShowPass)
        Me.PersonalPanel.Controls.Add(Me.txtPassword)
        Me.PersonalPanel.Location = New System.Drawing.Point(27, 115)
        Me.PersonalPanel.Name = "PersonalPanel"
        Me.PersonalPanel.Size = New System.Drawing.Size(844, 300)
        Me.PersonalPanel.TabIndex = 27
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(574, 242)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(0, 19)
        Me.lblGender.TabIndex = 50
        '
        'lblMiddlename
        '
        Me.lblMiddlename.AutoSize = True
        Me.lblMiddlename.Location = New System.Drawing.Point(574, 192)
        Me.lblMiddlename.Name = "lblMiddlename"
        Me.lblMiddlename.Size = New System.Drawing.Size(0, 19)
        Me.lblMiddlename.TabIndex = 49
        '
        'lblFirstname
        '
        Me.lblFirstname.AutoSize = True
        Me.lblFirstname.Location = New System.Drawing.Point(574, 142)
        Me.lblFirstname.Name = "lblFirstname"
        Me.lblFirstname.Size = New System.Drawing.Size(0, 19)
        Me.lblFirstname.TabIndex = 48
        '
        'lblLastname
        '
        Me.lblLastname.AutoSize = True
        Me.lblLastname.Location = New System.Drawing.Point(574, 92)
        Me.lblLastname.Name = "lblLastname"
        Me.lblLastname.Size = New System.Drawing.Size(0, 19)
        Me.lblLastname.TabIndex = 47
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(215, 142)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(0, 19)
        Me.lblPassword.TabIndex = 46
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(215, 92)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(0, 19)
        Me.lblUsername.TabIndex = 45
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label17.Location = New System.Drawing.Point(565, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 21)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Personal Information"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label16.Location = New System.Drawing.Point(206, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(152, 21)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Account Information"
        '
        'cmbGender
        '
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(569, 239)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(190, 25)
        Me.cmbGender.TabIndex = 42
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label15.Location = New System.Drawing.Point(502, 239)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 21)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Gender"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(459, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 21)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Middle Name"
        '
        'txtMiddlename
        '
        Me.txtMiddlename.Location = New System.Drawing.Point(569, 189)
        Me.txtMiddlename.Name = "txtMiddlename"
        Me.txtMiddlename.Size = New System.Drawing.Size(190, 25)
        Me.txtMiddlename.TabIndex = 5
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(569, 89)
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(190, 25)
        Me.txtLastname.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(479, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 21)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Last Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(477, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 21)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "First Name"
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(569, 139)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(190, 25)
        Me.txtFirstname.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(74, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 21)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Retype Password"
        '
        'lblShowRetype
        '
        Me.lblShowRetype.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowRetype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowRetype.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowRetype.Location = New System.Drawing.Point(380, 190)
        Me.lblShowRetype.Name = "lblShowRetype"
        Me.lblShowRetype.Size = New System.Drawing.Size(50, 23)
        Me.lblShowRetype.TabIndex = 32
        Me.lblShowRetype.Text = "show"
        Me.lblShowRetype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRetype
        '
        Me.txtRetype.Location = New System.Drawing.Point(210, 189)
        Me.txtRetype.Name = "txtRetype"
        Me.txtRetype.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetype.Size = New System.Drawing.Size(221, 25)
        Me.txtRetype.TabIndex = 2
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(210, 89)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(221, 25)
        Me.txtUsername.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(122, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 21)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(126, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 21)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Password"
        '
        'lblShowPass
        '
        Me.lblShowPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblShowPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShowPass.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblShowPass.Location = New System.Drawing.Point(380, 140)
        Me.lblShowPass.Name = "lblShowPass"
        Me.lblShowPass.Size = New System.Drawing.Size(50, 23)
        Me.lblShowPass.TabIndex = 27
        Me.lblShowPass.Text = "show"
        Me.lblShowPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(210, 139)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(221, 25)
        Me.txtPassword.TabIndex = 1
        '
        'lblPersonal
        '
        Me.lblPersonal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPersonal.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblPersonal.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblPersonal.Location = New System.Drawing.Point(25, 460)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(150, 25)
        Me.lblPersonal.TabIndex = 28
        Me.lblPersonal.Text = "Personal Information"
        Me.lblPersonal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSectionSchedule
        '
        Me.lblSectionSchedule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSectionSchedule.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSectionSchedule.Location = New System.Drawing.Point(175, 460)
        Me.lblSectionSchedule.Name = "lblSectionSchedule"
        Me.lblSectionSchedule.Size = New System.Drawing.Size(150, 25)
        Me.lblSectionSchedule.TabIndex = 29
        Me.lblSectionSchedule.Text = "Section / Schedule"
        Me.lblSectionSchedule.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblIndicator
        '
        Me.lblIndicator.BackColor = System.Drawing.Color.LawnGreen
        Me.lblIndicator.Location = New System.Drawing.Point(25, 450)
        Me.lblIndicator.Name = "lblIndicator"
        Me.lblIndicator.Size = New System.Drawing.Size(150, 3)
        Me.lblIndicator.TabIndex = 30
        '
        'lblCancel
        '
        Me.lblCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblCancel.Location = New System.Drawing.Point(712, 450)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(150, 30)
        Me.lblCancel.TabIndex = 31
        Me.lblCancel.Text = "Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(506, 450)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(200, 30)
        Me.lblContinue.TabIndex = 32
        Me.lblContinue.Text = "Next"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SchedulePanel
        '
        Me.SchedulePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SchedulePanel.Controls.Add(Me.txtMajor)
        Me.SchedulePanel.Controls.Add(Me.txtYear)
        Me.SchedulePanel.Controls.Add(Me.txtOUT)
        Me.SchedulePanel.Controls.Add(Me.txtIN)
        Me.SchedulePanel.Controls.Add(Me.Label18)
        Me.SchedulePanel.Controls.Add(Me.cmbOUT)
        Me.SchedulePanel.Controls.Add(Me.cmbIN)
        Me.SchedulePanel.Controls.Add(Me.Label4)
        Me.SchedulePanel.Controls.Add(Me.txtSubject)
        Me.SchedulePanel.Controls.Add(Me.lblAdd)
        Me.SchedulePanel.Controls.Add(Me.Label14)
        Me.SchedulePanel.Controls.Add(Me.txtSection)
        Me.SchedulePanel.Controls.Add(Me.Label13)
        Me.SchedulePanel.Controls.Add(Me.Label12)
        Me.SchedulePanel.Controls.Add(Me.Label11)
        Me.SchedulePanel.Controls.Add(Me.Label10)
        Me.SchedulePanel.Controls.Add(Me.Label9)
        Me.SchedulePanel.Controls.Add(Me.cmbDay)
        Me.SchedulePanel.Controls.Add(Me.Label8)
        Me.SchedulePanel.Controls.Add(Me.lvSections)
        Me.SchedulePanel.Controls.Add(Me.lblAECancel)
        Me.SchedulePanel.Controls.Add(Me.lblEdit)
        Me.SchedulePanel.Controls.Add(Me.lblDelete)
        Me.SchedulePanel.Location = New System.Drawing.Point(27, 115)
        Me.SchedulePanel.Name = "SchedulePanel"
        Me.SchedulePanel.Size = New System.Drawing.Size(844, 300)
        Me.SchedulePanel.TabIndex = 33
        Me.SchedulePanel.Visible = False
        '
        'txtMajor
        '
        Me.txtMajor.Enabled = False
        Me.txtMajor.FormattingEnabled = True
        Me.txtMajor.Items.AddRange(New Object() {"IS", "CS", "CT"})
        Me.txtMajor.Location = New System.Drawing.Point(90, 178)
        Me.txtMajor.Name = "txtMajor"
        Me.txtMajor.Size = New System.Drawing.Size(72, 25)
        Me.txtMajor.TabIndex = 47
        '
        'txtYear
        '
        Me.txtYear.Enabled = False
        Me.txtYear.FormattingEnabled = True
        Me.txtYear.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.txtYear.Location = New System.Drawing.Point(90, 209)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(72, 25)
        Me.txtYear.TabIndex = 46
        '
        'txtOUT
        '
        Me.txtOUT.Enabled = False
        Me.txtOUT.Location = New System.Drawing.Point(90, 127)
        Me.txtOUT.Name = "txtOUT"
        Me.txtOUT.Size = New System.Drawing.Size(100, 25)
        Me.txtOUT.TabIndex = 45
        '
        'txtIN
        '
        Me.txtIN.Enabled = False
        Me.txtIN.Location = New System.Drawing.Point(90, 97)
        Me.txtIN.Name = "txtIN"
        Me.txtIN.Size = New System.Drawing.Size(100, 25)
        Me.txtIN.TabIndex = 44
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label18.Location = New System.Drawing.Point(85, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 21)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "Sectioning Form"
        '
        'cmbOUT
        '
        Me.cmbOUT.Enabled = False
        Me.cmbOUT.FormattingEnabled = True
        Me.cmbOUT.Items.AddRange(New Object() {"AM", "PM"})
        Me.cmbOUT.Location = New System.Drawing.Point(195, 127)
        Me.cmbOUT.Name = "cmbOUT"
        Me.cmbOUT.Size = New System.Drawing.Size(43, 25)
        Me.cmbOUT.TabIndex = 40
        Me.cmbOUT.Text = "AM"
        '
        'cmbIN
        '
        Me.cmbIN.Enabled = False
        Me.cmbIN.FormattingEnabled = True
        Me.cmbIN.Items.AddRange(New Object() {"AM", "PM"})
        Me.cmbIN.Location = New System.Drawing.Point(195, 97)
        Me.cmbIN.Name = "cmbIN"
        Me.cmbIN.Size = New System.Drawing.Size(43, 25)
        Me.cmbIN.TabIndex = 39
        Me.cmbIN.Text = "AM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label4.Location = New System.Drawing.Point(29, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Subject"
        '
        'txtSubject
        '
        Me.txtSubject.Enabled = False
        Me.txtSubject.Location = New System.Drawing.Point(90, 271)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(148, 25)
        Me.txtSubject.TabIndex = 12
        '
        'lblAdd
        '
        Me.lblAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAdd.Location = New System.Drawing.Point(250, 243)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(585, 25)
        Me.lblAdd.TabIndex = 33
        Me.lblAdd.Text = "Add"
        Me.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label14.Location = New System.Drawing.Point(29, 240)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 20)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Section"
        '
        'txtSection
        '
        Me.txtSection.Enabled = False
        Me.txtSection.Location = New System.Drawing.Point(90, 240)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(72, 25)
        Me.txtSection.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(10, 212)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Year Level"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkGray
        Me.Label12.Location = New System.Drawing.Point(168, 181)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 21)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "(Optional)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(36, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 20)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Major"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label10.Location = New System.Drawing.Point(16, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Time Out"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(28, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Time In"
        '
        'cmbDay
        '
        Me.cmbDay.Enabled = False
        Me.cmbDay.FormattingEnabled = True
        Me.cmbDay.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.cmbDay.Location = New System.Drawing.Point(90, 66)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(148, 25)
        Me.cmbDay.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(49, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Day"
        '
        'lvSections
        '
        Me.lvSections.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvSections.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lvSections.FullRowSelect = True
        Me.lvSections.GridLines = True
        Me.lvSections.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvSections.Location = New System.Drawing.Point(250, 10)
        Me.lvSections.Name = "lvSections"
        Me.lvSections.Size = New System.Drawing.Size(585, 230)
        Me.lvSections.TabIndex = 13
        Me.lvSections.UseCompatibleStateImageBehavior = False
        Me.lvSections.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Day"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Year"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Section"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Subject"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Major"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 50
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Time IN"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Time OUT"
        Me.ColumnHeader7.Width = 100
        '
        'lblAECancel
        '
        Me.lblAECancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAECancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAECancel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAECancel.Location = New System.Drawing.Point(250, 271)
        Me.lblAECancel.Name = "lblAECancel"
        Me.lblAECancel.Size = New System.Drawing.Size(585, 25)
        Me.lblAECancel.TabIndex = 38
        Me.lblAECancel.Text = "Cancel"
        Me.lblAECancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAECancel.Visible = False
        '
        'lblEdit
        '
        Me.lblEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblEdit.Location = New System.Drawing.Point(250, 271)
        Me.lblEdit.Name = "lblEdit"
        Me.lblEdit.Size = New System.Drawing.Size(291, 25)
        Me.lblEdit.TabIndex = 34
        Me.lblEdit.Text = "Edit"
        Me.lblEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDelete
        '
        Me.lblDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDelete.Location = New System.Drawing.Point(544, 271)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(291, 25)
        Me.lblDelete.TabIndex = 35
        Me.lblDelete.Text = "Delete"
        Me.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'MoveIndicator
        '
        Me.MoveIndicator.Interval = 10
        Me.MoveIndicator.Tag = "Personal"
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(820, 17)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 67
        Me.lblHelp.Text = "Help"
        '
        'ShowMessage
        '
        Me.ShowMessage.Interval = 10
        Me.ShowMessage.Tag = "Show"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ShowAlways = True
        '
        'ToolTip2
        '
        Me.ToolTip2.AutomaticDelay = 300
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip2.OwnerDraw = True
        Me.ToolTip2.ShowAlways = True
        '
        'frmCreateUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(900, 500)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.lblContinue)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.lblIndicator)
        Me.Controls.Add(Me.lblSectionSchedule)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblBot)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.SchedulePanel)
        Me.Controls.Add(Me.PersonalPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCreateUser"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PersonalPanel.ResumeLayout(False)
        Me.PersonalPanel.PerformLayout()
        Me.SchedulePanel.ResumeLayout(False)
        Me.SchedulePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents PersonalPanel As System.Windows.Forms.Panel
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents lblSectionSchedule As System.Windows.Forms.Label
    Friend WithEvents lblShowPass As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblIndicator As System.Windows.Forms.Label
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblShowRetype As System.Windows.Forms.Label
    Friend WithEvents txtRetype As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMiddlename As System.Windows.Forms.TextBox
    Friend WithEvents txtLastname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFirstname As System.Windows.Forms.TextBox
    Friend WithEvents SchedulePanel As System.Windows.Forms.Panel
    Friend WithEvents lvSections As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbDay As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
    Friend WithEvents lblAdd As System.Windows.Forms.Label
    Friend WithEvents lblEdit As System.Windows.Forms.Label
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents MoveIndicator As System.Windows.Forms.Timer
    Friend WithEvents lblAECancel As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents ShowMessage As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIN As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOUT As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOUT As System.Windows.Forms.TextBox
    Friend WithEvents txtIN As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.ComboBox
    Friend WithEvents txtMajor As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblLastname As System.Windows.Forms.Label
    Friend WithEvents lblFirstname As System.Windows.Forms.Label
    Friend WithEvents lblMiddlename As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
End Class
