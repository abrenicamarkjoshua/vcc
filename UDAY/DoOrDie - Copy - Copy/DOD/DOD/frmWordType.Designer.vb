<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWordType
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
        Me.lblEdit = New System.Windows.Forms.Label()
        Me.lblDelete = New System.Windows.Forms.Label()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.ofdApplication = New System.Windows.Forms.OpenFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvType = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblClose = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblBot = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblEdit
        '
        Me.lblEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEdit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblEdit.Location = New System.Drawing.Point(325, 151)
        Me.lblEdit.Name = "lblEdit"
        Me.lblEdit.Size = New System.Drawing.Size(150, 25)
        Me.lblEdit.TabIndex = 98
        Me.lblEdit.Text = "Edit"
        Me.lblEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDelete
        '
        Me.lblDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelete.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDelete.Location = New System.Drawing.Point(325, 180)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(150, 25)
        Me.lblDelete.TabIndex = 97
        Me.lblDelete.Text = "Delete"
        Me.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAdd
        '
        Me.lblAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblAdd.Location = New System.Drawing.Point(325, 122)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(150, 25)
        Me.lblAdd.TabIndex = 94
        Me.lblAdd.Text = "Add"
        Me.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(54, 180)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(265, 25)
        Me.txtName.TabIndex = 93
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'ToolTip3
        '
        Me.ToolTip3.AutomaticDelay = 300
        Me.ToolTip3.IsBalloon = True
        Me.ToolTip3.OwnerDraw = True
        Me.ToolTip3.ShowAlways = True
        '
        'ToolTip2
        '
        Me.ToolTip2.AutomaticDelay = 300
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip2.OwnerDraw = True
        Me.ToolTip2.ShowAlways = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ShowAlways = True
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(361, 17)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 100
        Me.lblHelp.Text = "Help"
        '
        'ofdApplication
        '
        Me.ofdApplication.Filter = "All files | *.*"
        Me.ofdApplication.InitialDirectory = "C:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(50, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 21)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Word Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(23, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Information"
        '
        'lvType
        '
        Me.lvType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvType.FullRowSelect = True
        Me.lvType.GridLines = True
        Me.lvType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvType.Location = New System.Drawing.Point(25, 245)
        Me.lvType.Name = "lvType"
        Me.lvType.Size = New System.Drawing.Size(450, 230)
        Me.lvType.TabIndex = 90
        Me.lvType.UseCompatibleStateImageBehavior = False
        Me.lvType.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Word Type"
        Me.ColumnHeader1.Width = 400
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "User"
        Me.ColumnHeader2.Width = 0
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(418, 17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 89
        Me.lblClose.Text = "Close"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(335, 21)
        Me.lblDescription.TabIndex = 88
        Me.lblDescription.Text = "Manage application type for application setting"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 500)
        Me.lblLeft.TabIndex = 86
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 495)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(500, 5)
        Me.lblBot.TabIndex = 85
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(495, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 500)
        Me.lblRight.TabIndex = 84
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(112, 28)
        Me.lblTitle.TabIndex = 87
        Me.lblTitle.Text = "Word Type"
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(500, 5)
        Me.lblTop.TabIndex = 83
        '
        'frmWordType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 500)
        Me.Controls.Add(Me.lblEdit)
        Me.Controls.Add(Me.lblDelete)
        Me.Controls.Add(Me.lblAdd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvType)
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
        Me.Name = "frmWordType"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEdit As System.Windows.Forms.Label
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents lblAdd As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents ofdApplication As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvType As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
