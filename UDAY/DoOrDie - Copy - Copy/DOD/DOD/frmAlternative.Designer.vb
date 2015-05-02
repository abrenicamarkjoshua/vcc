<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlternative
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCommand = New System.Windows.Forms.Label()
        Me.lblExecute = New System.Windows.Forms.Label()
        Me.lvComputer = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAction = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvVariable = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSSS = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.gbReceive = New System.Windows.Forms.GroupBox()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lblWordCall = New System.Windows.Forms.Label()
        Me.lblComputerName = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.ScreenSharing = New System.Windows.Forms.Timer(Me.components)
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.gbReceive.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(382, 21)
        Me.lblDescription.TabIndex = 77
        Me.lblDescription.Text = "Another way to command a computer on the network"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(210, 28)
        Me.lblTitle.TabIndex = 76
        Me.lblTitle.Text = "Alternative Command"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 500)
        Me.lblLeft.TabIndex = 75
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(600, 5)
        Me.lblTop.TabIndex = 74
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(595, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 500)
        Me.Label1.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 495)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(600, 5)
        Me.Label2.TabIndex = 79
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(525, 17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 84
        Me.lblClose.Text = "Close"
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(462, 17)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 83
        Me.lblHelp.Text = "Help"
        Me.lblHelp.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(22, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Command :"
        '
        'lblCommand
        '
        Me.lblCommand.AutoSize = True
        Me.lblCommand.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCommand.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.lblCommand.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblCommand.Location = New System.Drawing.Point(130, 115)
        Me.lblCommand.Name = "lblCommand"
        Me.lblCommand.Size = New System.Drawing.Size(0, 20)
        Me.lblCommand.TabIndex = 86
        '
        'lblExecute
        '
        Me.lblExecute.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblExecute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExecute.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblExecute.Location = New System.Drawing.Point(467, 110)
        Me.lblExecute.Name = "lblExecute"
        Me.lblExecute.Size = New System.Drawing.Size(108, 30)
        Me.lblExecute.TabIndex = 87
        Me.lblExecute.Text = "Execute"
        Me.lblExecute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvComputer
        '
        Me.lvComputer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader9})
        Me.lvComputer.FullRowSelect = True
        Me.lvComputer.GridLines = True
        Me.lvComputer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvComputer.Location = New System.Drawing.Point(25, 228)
        Me.lvComputer.Name = "lvComputer"
        Me.lvComputer.Size = New System.Drawing.Size(150, 220)
        Me.lvComputer.TabIndex = 88
        Me.lvComputer.UseCompatibleStateImageBehavior = False
        Me.lvComputer.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Word Call"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "IPAddress"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Name"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "isDone"
        Me.ColumnHeader9.Width = 0
        '
        'lvAction
        '
        Me.lvAction.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvAction.FullRowSelect = True
        Me.lvAction.GridLines = True
        Me.lvAction.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvAction.Location = New System.Drawing.Point(180, 228)
        Me.lvAction.Name = "lvAction"
        Me.lvAction.Size = New System.Drawing.Size(200, 220)
        Me.lvAction.TabIndex = 89
        Me.lvAction.UseCompatibleStateImageBehavior = False
        Me.lvAction.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Action"
        Me.ColumnHeader2.Width = 170
        '
        'lvVariable
        '
        Me.lvVariable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvVariable.FullRowSelect = True
        Me.lvVariable.GridLines = True
        Me.lvVariable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvVariable.Location = New System.Drawing.Point(385, 228)
        Me.lvVariable.Name = "lvVariable"
        Me.lvVariable.Size = New System.Drawing.Size(190, 220)
        Me.lvVariable.TabIndex = 90
        Me.lvVariable.UseCompatibleStateImageBehavior = False
        Me.lvVariable.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Word Call"
        Me.ColumnHeader3.Width = 160
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "path"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "conpath"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "apptype"
        Me.ColumnHeader8.Width = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(23, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 21)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Computer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(176, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 21)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Action"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(381, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 21)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Variable"
        '
        'lblSSS
        '
        Me.lblSSS.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSSS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSSS.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSSS.Location = New System.Drawing.Point(25, 455)
        Me.lblSSS.Name = "lblSSS"
        Me.lblSSS.Size = New System.Drawing.Size(550, 30)
        Me.lblSSS.TabIndex = 94
        Me.lblSSS.Text = "Start Screen Sharing"
        Me.lblSSS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'gbReceive
        '
        Me.gbReceive.Controls.Add(Me.lblCancel)
        Me.gbReceive.Controls.Add(Me.lblWordCall)
        Me.gbReceive.Controls.Add(Me.lblComputerName)
        Me.gbReceive.Controls.Add(Me.Label9)
        Me.gbReceive.Controls.Add(Me.Label8)
        Me.gbReceive.Controls.Add(Me.dtpDate)
        Me.gbReceive.Controls.Add(Me.lblContinue)
        Me.gbReceive.Location = New System.Drawing.Point(25, 73)
        Me.gbReceive.Name = "gbReceive"
        Me.gbReceive.Size = New System.Drawing.Size(550, 375)
        Me.gbReceive.TabIndex = 95
        Me.gbReceive.TabStop = False
        Me.gbReceive.Visible = False
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblCancel.ForeColor = System.Drawing.Color.White
        Me.lblCancel.Location = New System.Drawing.Point(464, 40)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(66, 25)
        Me.lblCancel.TabIndex = 101
        Me.lblCancel.Text = "Cancel"
        '
        'lblWordCall
        '
        Me.lblWordCall.AutoSize = True
        Me.lblWordCall.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblWordCall.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblWordCall.Location = New System.Drawing.Point(15, 40)
        Me.lblWordCall.Name = "lblWordCall"
        Me.lblWordCall.Size = New System.Drawing.Size(132, 28)
        Me.lblWordCall.TabIndex = 100
        Me.lblWordCall.Text = "All Computer"
        Me.lblWordCall.Visible = False
        '
        'lblComputerName
        '
        Me.lblComputerName.AutoSize = True
        Me.lblComputerName.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblComputerName.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblComputerName.Location = New System.Drawing.Point(15, 40)
        Me.lblComputerName.Name = "lblComputerName"
        Me.lblComputerName.Size = New System.Drawing.Size(132, 28)
        Me.lblComputerName.TabIndex = 99
        Me.lblComputerName.Text = "All Computer"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(16, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(277, 21)
        Me.Label9.TabIndex = 98
        Me.Label9.Text = "Specify the Date to Return the Activtity"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(16, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 21)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Select the Date"
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtpDate.Location = New System.Drawing.Point(20, 178)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(304, 29)
        Me.dtpDate.TabIndex = 96
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(330, 178)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(200, 30)
        Me.lblContinue.TabIndex = 95
        Me.lblContinue.Text = "Continue"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScreenSharing
        '
        Me.ScreenSharing.Interval = 10
        Me.ScreenSharing.Tag = "Show"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.lblDesc.ForeColor = System.Drawing.Color.White
        Me.lblDesc.Location = New System.Drawing.Point(115, 150)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(0, 20)
        Me.lblDesc.TabIndex = 96
        '
        'frmAlternative
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.Controls.Add(Me.gbReceive)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.lvVariable)
        Me.Controls.Add(Me.lblSSS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvAction)
        Me.Controls.Add(Me.lvComputer)
        Me.Controls.Add(Me.lblExecute)
        Me.Controls.Add(Me.lblCommand)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAlternative"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbReceive.ResumeLayout(False)
        Me.gbReceive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCommand As System.Windows.Forms.Label
    Friend WithEvents lblExecute As System.Windows.Forms.Label
    Friend WithEvents lvComputer As System.Windows.Forms.ListView
    Friend WithEvents lvAction As System.Windows.Forms.ListView
    Friend WithEvents lvVariable As System.Windows.Forms.ListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSSS As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents gbReceive As System.Windows.Forms.GroupBox
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblComputerName As System.Windows.Forms.Label
    Friend WithEvents lblWordCall As System.Windows.Forms.Label
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents ScreenSharing As System.Windows.Forms.Timer
    Friend WithEvents lblDesc As System.Windows.Forms.Label
End Class
