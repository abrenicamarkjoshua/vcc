<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeechRecognition
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.lblTyping = New System.Windows.Forms.Label()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvCommands = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Commands = New System.Windows.Forms.Timer(Me.components)
        Me.ScreenSharing = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(495, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(5, 80)
        Me.Label4.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(0, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(500, 5)
        Me.Label3.TabIndex = 88
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(5, 80)
        Me.Label5.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(500, 5)
        Me.Label6.TabIndex = 86
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblFeedback.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblFeedback.Location = New System.Drawing.Point(80, 40)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(0, 21)
        Me.lblFeedback.TabIndex = 83
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTitle.Location = New System.Drawing.Point(70, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(94, 21)
        Me.lblTitle.TabIndex = 81
        Me.lblTitle.Text = "Listening . . ."
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblClose.Location = New System.Drawing.Point(435, 12)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(50, 21)
        Me.lblClose.TabIndex = 90
        Me.lblClose.Text = "Close"
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'lblTyping
        '
        Me.lblTyping.AutoSize = True
        Me.lblTyping.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTyping.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTyping.Location = New System.Drawing.Point(170, 12)
        Me.lblTyping.Name = "lblTyping"
        Me.lblTyping.Size = New System.Drawing.Size(119, 21)
        Me.lblTyping.TabIndex = 91
        Me.lblTyping.Text = "( Typing Mode )"
        Me.lblTyping.Visible = False
        '
        'lblShow
        '
        Me.lblShow.AutoSize = True
        Me.lblShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShow.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblShow.Location = New System.Drawing.Point(293, 12)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(136, 21)
        Me.lblShow.TabIndex = 92
        Me.lblShow.Text = "Show Commands"
        Me.lblShow.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblShow)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblTyping)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblClose)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblFeedback)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 80)
        Me.Panel1.TabIndex = 93
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.PictureBox1.Image = Global.DOD.My.Resources.Resources.unnamed
        Me.PictureBox1.Location = New System.Drawing.Point(15, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 80
        Me.PictureBox1.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "** computer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "** application"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label7.Location = New System.Drawing.Point(170, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(247, 20)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "The computer to give the command"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(170, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(311, 20)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "The Application / File to Open, Close or Share"
        '
        'lvCommands
        '
        Me.lvCommands.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvCommands.FullRowSelect = True
        Me.lvCommands.GridLines = True
        Me.lvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvCommands.Location = New System.Drawing.Point(20, 80)
        Me.lvCommands.Name = "lvCommands"
        Me.lvCommands.Size = New System.Drawing.Size(460, 200)
        Me.lvCommands.TabIndex = 99
        Me.lvCommands.UseCompatibleStateImageBehavior = False
        Me.lvCommands.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Computer"
        Me.ColumnHeader1.Width = 140
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Action"
        Me.ColumnHeader2.Width = 140
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Variable"
        Me.ColumnHeader3.Width = 140
        '
        'Commands
        '
        Me.Commands.Interval = 10
        Me.Commands.Tag = "Show"
        '
        'ScreenSharing
        '
        Me.ScreenSharing.Interval = 10
        Me.ScreenSharing.Tag = "Show"
        '
        'frmSpeechRecognition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 80)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lvCommands)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSpeechRecognition"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents lblTyping As System.Windows.Forms.Label
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvCommands As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Commands As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ScreenSharing As System.Windows.Forms.Timer
End Class
