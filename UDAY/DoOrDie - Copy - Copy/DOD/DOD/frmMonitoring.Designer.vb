<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitoring
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
        Me.lblSection = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MonitorPanel = New System.Windows.Forms.Panel()
        Me.pbScreen = New System.Windows.Forms.PictureBox()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.LoadMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.lblRestart = New System.Windows.Forms.Label()
        Me.lblShutdown = New System.Windows.Forms.Label()
        Me.lblLock = New System.Windows.Forms.Label()
        Me.lblUnlock = New System.Windows.Forms.Label()
        Me.lblLogout = New System.Windows.Forms.Label()
        Me.FullScreenPanel = New System.Windows.Forms.Panel()
        Me.lblScreen = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.FullScreen = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAllLogout = New System.Windows.Forms.Label()
        Me.lblAllUnlock = New System.Windows.Forms.Label()
        Me.lblAllLock = New System.Windows.Forms.Label()
        Me.lblAllShutdown = New System.Windows.Forms.Label()
        Me.lblAllRestart = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FullScreenPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblSection.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblSection.Location = New System.Drawing.Point(22, 64)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(0, 21)
        Me.lblSection.TabIndex = 86
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(305, 21)
        Me.lblDescription.TabIndex = 85
        Me.lblDescription.Text = "Display the Current Screen of each student"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(201, 28)
        Me.lblTitle.TabIndex = 84
        Me.lblTitle.Text = "Students Monitoring"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 600)
        Me.lblLeft.TabIndex = 83
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(1000, 5)
        Me.lblTop.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(995, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 600)
        Me.Label1.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 595)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1000, 5)
        Me.Label2.TabIndex = 88
        '
        'MonitorPanel
        '
        Me.MonitorPanel.AutoScroll = True
        Me.MonitorPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.MonitorPanel.Location = New System.Drawing.Point(20, 77)
        Me.MonitorPanel.Name = "MonitorPanel"
        Me.MonitorPanel.Size = New System.Drawing.Size(960, 470)
        Me.MonitorPanel.TabIndex = 89
        '
        'pbScreen
        '
        Me.pbScreen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbScreen.Location = New System.Drawing.Point(0, 0)
        Me.pbScreen.Name = "pbScreen"
        Me.pbScreen.Size = New System.Drawing.Size(960, 470)
        Me.pbScreen.TabIndex = 1
        Me.pbScreen.TabStop = False
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelp.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(855, 20)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(51, 25)
        Me.lblHelp.TabIndex = 91
        Me.lblHelp.Text = "Help"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(923, 20)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(57, 25)
        Me.lblClose.TabIndex = 90
        Me.lblClose.Text = "Close"
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'LoadMonitor
        '
        Me.LoadMonitor.Interval = 10
        Me.LoadMonitor.Tag = "Show"
        '
        'lblRestart
        '
        Me.lblRestart.AutoSize = True
        Me.lblRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRestart.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblRestart.ForeColor = System.Drawing.Color.White
        Me.lblRestart.Location = New System.Drawing.Point(884, 556)
        Me.lblRestart.Name = "lblRestart"
        Me.lblRestart.Size = New System.Drawing.Size(96, 21)
        Me.lblRestart.TabIndex = 93
        Me.lblRestart.Text = "Restart Unit"
        Me.lblRestart.Visible = False
        '
        'lblShutdown
        '
        Me.lblShutdown.AutoSize = True
        Me.lblShutdown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblShutdown.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblShutdown.ForeColor = System.Drawing.Color.White
        Me.lblShutdown.Location = New System.Drawing.Point(740, 556)
        Me.lblShutdown.Name = "lblShutdown"
        Me.lblShutdown.Size = New System.Drawing.Size(118, 21)
        Me.lblShutdown.TabIndex = 94
        Me.lblShutdown.Text = "Shutdown Unit"
        Me.lblShutdown.Visible = False
        '
        'lblLock
        '
        Me.lblLock.AutoSize = True
        Me.lblLock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLock.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblLock.ForeColor = System.Drawing.Color.White
        Me.lblLock.Location = New System.Drawing.Point(636, 556)
        Me.lblLock.Name = "lblLock"
        Me.lblLock.Size = New System.Drawing.Size(78, 21)
        Me.lblLock.TabIndex = 95
        Me.lblLock.Text = "Lock Unit"
        Me.lblLock.Visible = False
        '
        'lblUnlock
        '
        Me.lblUnlock.AutoSize = True
        Me.lblUnlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUnlock.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblUnlock.ForeColor = System.Drawing.Color.White
        Me.lblUnlock.Location = New System.Drawing.Point(516, 556)
        Me.lblUnlock.Name = "lblUnlock"
        Me.lblUnlock.Size = New System.Drawing.Size(94, 21)
        Me.lblUnlock.TabIndex = 96
        Me.lblUnlock.Text = "Unlock Unit"
        Me.lblUnlock.Visible = False
        '
        'lblLogout
        '
        Me.lblLogout.AutoSize = True
        Me.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblLogout.ForeColor = System.Drawing.Color.White
        Me.lblLogout.Location = New System.Drawing.Point(365, 556)
        Me.lblLogout.Name = "lblLogout"
        Me.lblLogout.Size = New System.Drawing.Size(125, 21)
        Me.lblLogout.TabIndex = 97
        Me.lblLogout.Text = "Logout Student"
        Me.lblLogout.Visible = False
        '
        'FullScreenPanel
        '
        Me.FullScreenPanel.AutoScroll = True
        Me.FullScreenPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.FullScreenPanel.Controls.Add(Me.lblScreen)
        Me.FullScreenPanel.Controls.Add(Me.pbScreen)
        Me.FullScreenPanel.Location = New System.Drawing.Point(20, 77)
        Me.FullScreenPanel.Name = "FullScreenPanel"
        Me.FullScreenPanel.Size = New System.Drawing.Size(960, 470)
        Me.FullScreenPanel.TabIndex = 98
        Me.FullScreenPanel.Visible = False
        '
        'lblScreen
        '
        Me.lblScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblScreen.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblScreen.Location = New System.Drawing.Point(0, 0)
        Me.lblScreen.Name = "lblScreen"
        Me.lblScreen.Size = New System.Drawing.Size(960, 19)
        Me.lblScreen.TabIndex = 3
        Me.lblScreen.Text = "Label4"
        Me.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 556)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Computer :"
        Me.Label3.Visible = False
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSelected.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblSelected.ForeColor = System.Drawing.Color.White
        Me.lblSelected.Location = New System.Drawing.Point(114, 556)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(0, 21)
        Me.lblSelected.TabIndex = 100
        Me.lblSelected.Visible = False
        '
        'FullScreen
        '
        Me.FullScreen.Interval = 10
        Me.FullScreen.Tag = "Show"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(864, 556)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 21)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "|"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(720, 556)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 21)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "|"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(616, 556)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 21)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "|"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(496, 556)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 21)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "|"
        Me.Label7.Visible = False
        '
        'lblAllLogout
        '
        Me.lblAllLogout.AutoSize = True
        Me.lblAllLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblAllLogout.ForeColor = System.Drawing.Color.White
        Me.lblAllLogout.Location = New System.Drawing.Point(250, 556)
        Me.lblAllLogout.Name = "lblAllLogout"
        Me.lblAllLogout.Size = New System.Drawing.Size(148, 21)
        Me.lblAllLogout.TabIndex = 122
        Me.lblAllLogout.Text = "All Logout Student"
        Me.lblAllLogout.Visible = False
        '
        'lblAllUnlock
        '
        Me.lblAllUnlock.AutoSize = True
        Me.lblAllUnlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllUnlock.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblAllUnlock.ForeColor = System.Drawing.Color.White
        Me.lblAllUnlock.Location = New System.Drawing.Point(424, 556)
        Me.lblAllUnlock.Name = "lblAllUnlock"
        Me.lblAllUnlock.Size = New System.Drawing.Size(117, 21)
        Me.lblAllUnlock.TabIndex = 121
        Me.lblAllUnlock.Text = "All Unlock Unit"
        Me.lblAllUnlock.Visible = False
        '
        'lblAllLock
        '
        Me.lblAllLock.AutoSize = True
        Me.lblAllLock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllLock.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblAllLock.ForeColor = System.Drawing.Color.White
        Me.lblAllLock.Location = New System.Drawing.Point(567, 556)
        Me.lblAllLock.Name = "lblAllLock"
        Me.lblAllLock.Size = New System.Drawing.Size(101, 21)
        Me.lblAllLock.TabIndex = 120
        Me.lblAllLock.Text = "All Lock Unit"
        Me.lblAllLock.Visible = False
        '
        'lblAllShutdown
        '
        Me.lblAllShutdown.AutoSize = True
        Me.lblAllShutdown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllShutdown.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblAllShutdown.ForeColor = System.Drawing.Color.White
        Me.lblAllShutdown.Location = New System.Drawing.Point(694, 556)
        Me.lblAllShutdown.Name = "lblAllShutdown"
        Me.lblAllShutdown.Size = New System.Drawing.Size(141, 21)
        Me.lblAllShutdown.TabIndex = 119
        Me.lblAllShutdown.Text = "All Shutdown Unit"
        Me.lblAllShutdown.Visible = False
        '
        'lblAllRestart
        '
        Me.lblAllRestart.AutoSize = True
        Me.lblAllRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAllRestart.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblAllRestart.ForeColor = System.Drawing.Color.White
        Me.lblAllRestart.Location = New System.Drawing.Point(861, 556)
        Me.lblAllRestart.Name = "lblAllRestart"
        Me.lblAllRestart.Size = New System.Drawing.Size(119, 21)
        Me.lblAllRestart.TabIndex = 118
        Me.lblAllRestart.Text = "All Restart Unit"
        Me.lblAllRestart.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(404, 556)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 21)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "|"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(547, 556)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 21)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "|"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(674, 556)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 21)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "|"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(841, 556)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 21)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "|"
        Me.Label11.Visible = False
        '
        'frmMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.lblAllLogout)
        Me.Controls.Add(Me.lblAllUnlock)
        Me.Controls.Add(Me.lblAllLock)
        Me.Controls.Add(Me.lblAllShutdown)
        Me.Controls.Add(Me.lblAllRestart)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLogout)
        Me.Controls.Add(Me.lblUnlock)
        Me.Controls.Add(Me.lblLock)
        Me.Controls.Add(Me.lblShutdown)
        Me.Controls.Add(Me.lblRestart)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.MonitorPanel)
        Me.Controls.Add(Me.FullScreenPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMonitoring"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FullScreenPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MonitorPanel As System.Windows.Forms.Panel
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents LoadMonitor As System.Windows.Forms.Timer
    Friend WithEvents lblRestart As System.Windows.Forms.Label
    Friend WithEvents lblShutdown As System.Windows.Forms.Label
    Friend WithEvents lblLock As System.Windows.Forms.Label
    Friend WithEvents lblUnlock As System.Windows.Forms.Label
    Friend WithEvents lblLogout As System.Windows.Forms.Label
    Friend WithEvents FullScreenPanel As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents pbScreen As System.Windows.Forms.PictureBox
    Friend WithEvents FullScreen As System.Windows.Forms.Timer
    Friend WithEvents lblScreen As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblAllLogout As System.Windows.Forms.Label
    Friend WithEvents lblAllUnlock As System.Windows.Forms.Label
    Friend WithEvents lblAllLock As System.Windows.Forms.Label
    Friend WithEvents lblAllShutdown As System.Windows.Forms.Label
    Friend WithEvents lblAllRestart As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
