<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimer
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
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.LoadComp = New System.Windows.Forms.Timer(Me.components)
        Me.lvDetected = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.rdbSpecific = New System.Windows.Forms.RadioButton()
        Me.cmbCom = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblReset = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(305, 21)
        Me.lblDescription.TabIndex = 19
        Me.lblDescription.Text = "Add and/or Stop Time for Client Computer"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(122, 28)
        Me.lblTitle.TabIndex = 18
        Me.lblTitle.Text = "Client Timer"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 550)
        Me.lblLeft.TabIndex = 17
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(800, 5)
        Me.lblTop.TabIndex = 16
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(357, 17)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 54
        Me.lblHelp.Text = "Help"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(425, 17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 53
        Me.lblClose.Text = "Close"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(495, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 550)
        Me.Label1.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 545)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(800, 5)
        Me.Label2.TabIndex = 56
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'LoadComp
        '
        Me.LoadComp.Interval = 10
        Me.LoadComp.Tag = "Show"
        '
        'lvDetected
        '
        Me.lvDetected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvDetected.Enabled = False
        Me.lvDetected.FullRowSelect = True
        Me.lvDetected.GridLines = True
        Me.lvDetected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvDetected.Location = New System.Drawing.Point(25, 213)
        Me.lvDetected.Name = "lvDetected"
        Me.lvDetected.Size = New System.Drawing.Size(450, 286)
        Me.lvDetected.TabIndex = 57
        Me.lvDetected.UseCompatibleStateImageBehavior = False
        Me.lvDetected.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "IP Address"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Computer Name"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Done"
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Checked = True
        Me.rdbAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbAll.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdbAll.ForeColor = System.Drawing.Color.LawnGreen
        Me.rdbAll.Location = New System.Drawing.Point(25, 155)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(90, 25)
        Me.rdbAll.TabIndex = 58
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "All Client"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'rdbSpecific
        '
        Me.rdbSpecific.AutoSize = True
        Me.rdbSpecific.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbSpecific.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rdbSpecific.Location = New System.Drawing.Point(25, 184)
        Me.rdbSpecific.Name = "rdbSpecific"
        Me.rdbSpecific.Size = New System.Drawing.Size(125, 25)
        Me.rdbSpecific.TabIndex = 59
        Me.rdbSpecific.Text = "Specific Client"
        Me.rdbSpecific.UseVisualStyleBackColor = True
        '
        'cmbCom
        '
        Me.cmbCom.FormattingEnabled = True
        Me.cmbCom.Items.AddRange(New Object() {"Add Time", "Stop Time", "Resume Time", "Reset Time"})
        Me.cmbCom.Location = New System.Drawing.Point(25, 115)
        Me.cmbCom.Name = "cmbCom"
        Me.cmbCom.Size = New System.Drawing.Size(150, 25)
        Me.cmbCom.TabIndex = 60
        Me.cmbCom.Text = "Add Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(21, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 21)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Select a command"
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(181, 115)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(150, 25)
        Me.txtMin.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(177, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 21)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Number of Minutes"
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(337, 115)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(138, 25)
        Me.lblContinue.TabIndex = 64
        Me.lblContinue.Text = "Continue"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'ToolTip3
        '
        Me.ToolTip3.AutomaticDelay = 300
        Me.ToolTip3.IsBalloon = True
        Me.ToolTip3.OwnerDraw = True
        Me.ToolTip3.ShowAlways = True
        '
        'ToolTip4
        '
        Me.ToolTip4.AutomaticDelay = 300
        Me.ToolTip4.IsBalloon = True
        Me.ToolTip4.OwnerDraw = True
        Me.ToolTip4.ShowAlways = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.LightCoral
        Me.Label5.Location = New System.Drawing.Point(167, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(308, 52)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Client computers whose done with activity can't add time until 'Reset Activity'"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReset
        '
        Me.lblReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblReset.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblReset.Location = New System.Drawing.Point(25, 505)
        Me.lblReset.Name = "lblReset"
        Me.lblReset.Size = New System.Drawing.Size(450, 25)
        Me.lblReset.TabIndex = 66
        Me.lblReset.Text = "Reset"
        Me.lblReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStart
        '
        Me.lblStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblStart.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStart.Location = New System.Drawing.Point(25, 474)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(450, 25)
        Me.lblStart.TabIndex = 71
        Me.lblStart.Text = "Start Time"
        Me.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblStart.Visible = False
        '
        'frmTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 550)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblReset)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblContinue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCom)
        Me.Controls.Add(Me.rdbSpecific)
        Me.Controls.Add(Me.rdbAll)
        Me.Controls.Add(Me.lvDetected)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTimer"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents LoadComp As System.Windows.Forms.Timer
    Friend WithEvents lvDetected As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCom As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblReset As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
End Class
