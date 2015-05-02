<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWord
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
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.txtWordCall = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEdit = New System.Windows.Forms.Label()
        Me.lblDelete = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblBot = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPrint = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.lblManage = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvType = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lblAdd
        '
        Me.lblAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAdd.Location = New System.Drawing.Point(425, 117)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(150, 25)
        Me.lblAdd.TabIndex = 85
        Me.lblAdd.Text = "Add"
        Me.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtWordCall
        '
        Me.txtWordCall.Enabled = False
        Me.txtWordCall.Location = New System.Drawing.Point(210, 147)
        Me.txtWordCall.Name = "txtWordCall"
        Me.txtWordCall.Size = New System.Drawing.Size(194, 25)
        Me.txtWordCall.TabIndex = 84
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(50, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 21)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Text to Print"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(50, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 21)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Word Call"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(23, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Information"
        '
        'lblEdit
        '
        Me.lblEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblEdit.Location = New System.Drawing.Point(425, 147)
        Me.lblEdit.Name = "lblEdit"
        Me.lblEdit.Size = New System.Drawing.Size(150, 25)
        Me.lblEdit.TabIndex = 80
        Me.lblEdit.Text = "Edit"
        Me.lblEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDelete
        '
        Me.lblDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDelete.Location = New System.Drawing.Point(425, 177)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(150, 25)
        Me.lblDelete.TabIndex = 79
        Me.lblDelete.Text = "Delete"
        Me.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(518, 17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 78
        Me.lblClose.Text = "Close"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(346, 21)
        Me.lblDescription.TabIndex = 77
        Me.lblDescription.Text = "Manage words that can be print using command"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 600)
        Me.lblLeft.TabIndex = 75
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 595)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(600, 5)
        Me.lblBot.TabIndex = 74
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(595, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 600)
        Me.lblRight.TabIndex = 73
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(133, 28)
        Me.lblTitle.TabIndex = 76
        Me.lblTitle.Text = "Word Setting"
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(600, 5)
        Me.lblTop.TabIndex = 72
        '
        'lvList
        '
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvList.Location = New System.Drawing.Point(330, 250)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(245, 325)
        Me.lvList.TabIndex = 87
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Word Call"
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Text to Print"
        Me.ColumnHeader4.Width = 120
        '
        'txtPrint
        '
        Me.txtPrint.Enabled = False
        Me.txtPrint.Location = New System.Drawing.Point(210, 177)
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.Size = New System.Drawing.Size(194, 25)
        Me.txtPrint.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(330, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 21)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Words List"
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
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
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(450, 17)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 95
        Me.lblHelp.Text = "Help"
        '
        'lblManage
        '
        Me.lblManage.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblManage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblManage.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblManage.Location = New System.Drawing.Point(29, 550)
        Me.lblManage.Name = "lblManage"
        Me.lblManage.Size = New System.Drawing.Size(245, 25)
        Me.lblManage.TabIndex = 99
        Me.lblManage.Text = "Manage Word Type"
        Me.lblManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(25, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 21)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Selected Word Type"
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelected.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblSelected.Location = New System.Drawing.Point(25, 485)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(0, 19)
        Me.lblSelected.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(25, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 21)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Word Type"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Word Type"
        Me.ColumnHeader1.Width = 210
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "User"
        Me.ColumnHeader2.Width = 0
        '
        'lvType
        '
        Me.lvType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvType.FullRowSelect = True
        Me.lvType.GridLines = True
        Me.lvType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvType.Location = New System.Drawing.Point(29, 250)
        Me.lvType.Name = "lvType"
        Me.lvType.Size = New System.Drawing.Size(245, 200)
        Me.lvType.TabIndex = 96
        Me.lvType.UseCompatibleStateImageBehavior = False
        Me.lvType.View = System.Windows.Forms.View.Details
        '
        'frmWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 600)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblManage)
        Me.Controls.Add(Me.lvType)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPrint)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.lblAdd)
        Me.Controls.Add(Me.txtWordCall)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblEdit)
        Me.Controls.Add(Me.lblDelete)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblBot)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmWord"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAdd As System.Windows.Forms.Label
    Friend WithEvents txtWordCall As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEdit As System.Windows.Forms.Label
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPrint As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblManage As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvType As System.Windows.Forms.ListView
End Class
