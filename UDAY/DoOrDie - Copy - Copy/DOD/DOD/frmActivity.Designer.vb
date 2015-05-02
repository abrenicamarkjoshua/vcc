<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivity
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
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvAttendance = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblView = New System.Windows.Forms.Label()
        Me.lblClear = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip5 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblSection = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(450, 20)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 85
        Me.lblHelp.Text = "Help"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(518, 20)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 84
        Me.lblClose.Text = "Close"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(186, 21)
        Me.lblDescription.TabIndex = 83
        Me.lblDescription.Text = "Manage Students Activity"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(78, 28)
        Me.lblTitle.TabIndex = 82
        Me.lblTitle.Text = "Activity"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 500)
        Me.lblLeft.TabIndex = 81
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(600, 5)
        Me.lblTop.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(595, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 500)
        Me.Label1.TabIndex = 86
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 495)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(600, 5)
        Me.Label2.TabIndex = 87
        '
        'lvAttendance
        '
        Me.lvAttendance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvAttendance.FullRowSelect = True
        Me.lvAttendance.GridLines = True
        Me.lvAttendance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvAttendance.Location = New System.Drawing.Point(25, 120)
        Me.lvAttendance.Name = "lvAttendance"
        Me.lvAttendance.Size = New System.Drawing.Size(550, 300)
        Me.lvAttendance.TabIndex = 88
        Me.lvAttendance.UseCompatibleStateImageBehavior = False
        Me.lvAttendance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Student ID"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Student Name"
        Me.ColumnHeader2.Width = 370
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Lastname"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Firstname"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Middlename"
        Me.ColumnHeader5.Width = 0
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(340, 85)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(235, 25)
        Me.dtpDate.TabIndex = 90
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(238, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 21)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Specify Date"
        '
        'lblView
        '
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblView.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblView.Location = New System.Drawing.Point(239, 460)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(336, 25)
        Me.lblView.TabIndex = 91
        Me.lblView.Text = "View Activity"
        Me.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClear
        '
        Me.lblClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClear.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblClear.Location = New System.Drawing.Point(25, 460)
        Me.lblClear.Name = "lblClear"
        Me.lblClear.Size = New System.Drawing.Size(208, 25)
        Me.lblClear.TabIndex = 92
        Me.lblClear.Text = "Clear Activity"
        Me.lblClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(100, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 21)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Selected Student :"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblName.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblName.Location = New System.Drawing.Point(239, 430)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(336, 19)
        Me.lblName.TabIndex = 94
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'ToolTip5
        '
        Me.ToolTip5.AutomaticDelay = 300
        Me.ToolTip5.IsBalloon = True
        Me.ToolTip5.OwnerDraw = True
        Me.ToolTip5.ShowAlways = True
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.lblSection.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblSection.Location = New System.Drawing.Point(23, 85)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(0, 20)
        Me.lblSection.TabIndex = 95
        '
        'frmActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblClear)
        Me.Controls.Add(Me.lblView)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lvAttendance)
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
        Me.Name = "frmActivity"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvAttendance As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents lblClear As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip5 As System.Windows.Forms.ToolTip
    Friend WithEvents lblSection As System.Windows.Forms.Label
End Class
