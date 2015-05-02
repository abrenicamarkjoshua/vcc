<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTutorial
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
        Me.lblBot = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblWord = New System.Windows.Forms.Label()
        Me.lblFinish = New System.Windows.Forms.Label()
        Me.lblVoice = New System.Windows.Forms.Label()
        Me.lblIndicator = New System.Windows.Forms.Label()
        Me.lblKeyword = New System.Windows.Forms.Label()
        Me.lblApplication = New System.Windows.Forms.Label()
        Me.lblNetwork = New System.Windows.Forms.Label()
        Me.lblTrain = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.MoveIndicator = New System.Windows.Forms.Timer(Me.components)
        Me.FinishPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.lblSkip = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTyping = New System.Windows.Forms.Label()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.lblCommand = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.FinishPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.BackColor = System.Drawing.Color.Green
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(5, 40)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(447, 21)
        Me.lblDescription.TabIndex = 21
        Me.lblDescription.Text = "               Follow the simple steps on how to Operate the System"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Green
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(5, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(141, 28)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.Text = "          Tutorial"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 500)
        Me.lblLeft.TabIndex = 19
        '
        'lblBot
        '
        Me.lblBot.BackColor = System.Drawing.Color.Green
        Me.lblBot.Location = New System.Drawing.Point(0, 495)
        Me.lblBot.Name = "lblBot"
        Me.lblBot.Size = New System.Drawing.Size(800, 5)
        Me.lblBot.TabIndex = 18
        '
        'lblRight
        '
        Me.lblRight.BackColor = System.Drawing.Color.Green
        Me.lblRight.Location = New System.Drawing.Point(795, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(5, 500)
        Me.lblRight.TabIndex = 17
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(800, 5)
        Me.lblTop.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblWord)
        Me.Panel1.Controls.Add(Me.lblFinish)
        Me.Panel1.Controls.Add(Me.lblVoice)
        Me.Panel1.Controls.Add(Me.lblIndicator)
        Me.Panel1.Controls.Add(Me.lblKeyword)
        Me.Panel1.Controls.Add(Me.lblApplication)
        Me.Panel1.Controls.Add(Me.lblNetwork)
        Me.Panel1.Controls.Add(Me.lblTrain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 430)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 70)
        Me.Panel1.TabIndex = 22
        '
        'lblWord
        '
        Me.lblWord.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblWord.Location = New System.Drawing.Point(475, 15)
        Me.lblWord.Name = "lblWord"
        Me.lblWord.Size = New System.Drawing.Size(150, 30)
        Me.lblWord.TabIndex = 7
        Me.lblWord.Text = "Word Setting"
        Me.lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFinish
        '
        Me.lblFinish.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblFinish.Location = New System.Drawing.Point(925, 15)
        Me.lblFinish.Name = "lblFinish"
        Me.lblFinish.Size = New System.Drawing.Size(150, 30)
        Me.lblFinish.TabIndex = 6
        Me.lblFinish.Text = "Finish Tutorial"
        Me.lblFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVoice
        '
        Me.lblVoice.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblVoice.Location = New System.Drawing.Point(775, 15)
        Me.lblVoice.Name = "lblVoice"
        Me.lblVoice.Size = New System.Drawing.Size(150, 30)
        Me.lblVoice.TabIndex = 5
        Me.lblVoice.Text = "Voice Command"
        Me.lblVoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIndicator
        '
        Me.lblIndicator.BackColor = System.Drawing.Color.LawnGreen
        Me.lblIndicator.Location = New System.Drawing.Point(25, 5)
        Me.lblIndicator.Name = "lblIndicator"
        Me.lblIndicator.Size = New System.Drawing.Size(150, 3)
        Me.lblIndicator.TabIndex = 4
        '
        'lblKeyword
        '
        Me.lblKeyword.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblKeyword.Location = New System.Drawing.Point(625, 15)
        Me.lblKeyword.Name = "lblKeyword"
        Me.lblKeyword.Size = New System.Drawing.Size(150, 30)
        Me.lblKeyword.TabIndex = 3
        Me.lblKeyword.Text = "Keyword Setting"
        Me.lblKeyword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblApplication
        '
        Me.lblApplication.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblApplication.Location = New System.Drawing.Point(325, 15)
        Me.lblApplication.Name = "lblApplication"
        Me.lblApplication.Size = New System.Drawing.Size(150, 30)
        Me.lblApplication.TabIndex = 2
        Me.lblApplication.Text = "Application Setting"
        Me.lblApplication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetwork
        '
        Me.lblNetwork.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblNetwork.Location = New System.Drawing.Point(175, 15)
        Me.lblNetwork.Name = "lblNetwork"
        Me.lblNetwork.Size = New System.Drawing.Size(150, 30)
        Me.lblNetwork.TabIndex = 1
        Me.lblNetwork.Text = "Network Setting"
        Me.lblNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTrain
        '
        Me.lblTrain.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTrain.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTrain.Location = New System.Drawing.Point(25, 15)
        Me.lblTrain.Name = "lblTrain"
        Me.lblTrain.Size = New System.Drawing.Size(150, 30)
        Me.lblTrain.TabIndex = 0
        Me.lblTrain.Text = "Train Speech Engine"
        Me.lblTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'MoveIndicator
        '
        Me.MoveIndicator.Interval = 10
        Me.MoveIndicator.Tag = ""
        '
        'FinishPanel
        '
        Me.FinishPanel.Controls.Add(Me.Label2)
        Me.FinishPanel.Controls.Add(Me.Label1)
        Me.FinishPanel.Controls.Add(Me.lblContinue)
        Me.FinishPanel.Location = New System.Drawing.Point(290, 200)
        Me.FinishPanel.Name = "FinishPanel"
        Me.FinishPanel.Size = New System.Drawing.Size(400, 100)
        Me.FinishPanel.TabIndex = 23
        Me.FinishPanel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(20, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(369, 21)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Press 'Continue' to return to the User Account Panel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 21)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Tutorial Complete !"
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(20, 65)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(360, 25)
        Me.lblContinue.TabIndex = 39
        Me.lblContinue.Text = "Continue"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblContinue.Visible = False
        '
        'lblSkip
        '
        Me.lblSkip.BackColor = System.Drawing.Color.Green
        Me.lblSkip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSkip.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblSkip.Location = New System.Drawing.Point(645, 25)
        Me.lblSkip.Name = "lblSkip"
        Me.lblSkip.Size = New System.Drawing.Size(150, 30)
        Me.lblSkip.TabIndex = 4
        Me.lblSkip.Text = "Skip Tutorial >>"
        Me.lblSkip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTyping)
        Me.Panel2.Controls.Add(Me.lblInstruction)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblFeedback)
        Me.Panel2.Controls.Add(Me.lblCommand)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(268, 161)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(600, 129)
        Me.Panel2.TabIndex = 24
        Me.Panel2.Visible = False
        '
        'lblTyping
        '
        Me.lblTyping.AutoSize = True
        Me.lblTyping.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTyping.Location = New System.Drawing.Point(317, 12)
        Me.lblTyping.Name = "lblTyping"
        Me.lblTyping.Size = New System.Drawing.Size(119, 21)
        Me.lblTyping.TabIndex = 81
        Me.lblTyping.Text = "( Typing Mode )"
        Me.lblTyping.Visible = False
        '
        'lblInstruction
        '
        Me.lblInstruction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInstruction.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblInstruction.Location = New System.Drawing.Point(0, 109)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(600, 20)
        Me.lblInstruction.TabIndex = 80
        Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(545, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(5, 100)
        Me.Label4.TabIndex = 79
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(50, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(500, 5)
        Me.Label3.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(50, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(5, 100)
        Me.Label5.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(50, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(500, 5)
        Me.Label6.TabIndex = 76
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(175, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 21)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "Feedback :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(175, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 21)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Command :"
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblFeedback.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblFeedback.Location = New System.Drawing.Point(261, 40)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(0, 21)
        Me.lblFeedback.TabIndex = 73
        '
        'lblCommand
        '
        Me.lblCommand.AutoSize = True
        Me.lblCommand.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblCommand.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblCommand.Location = New System.Drawing.Point(261, 70)
        Me.lblCommand.Name = "lblCommand"
        Me.lblCommand.Size = New System.Drawing.Size(0, 21)
        Me.lblCommand.TabIndex = 72
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(175, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 21)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Listening . . ."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.PictureBox1.Image = Global.DOD.My.Resources.Resources.unnamed
        Me.PictureBox1.Location = New System.Drawing.Point(62, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 76)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.DOD.My.Resources.Resources.MenuBG
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(892, 500)
        Me.Panel3.TabIndex = 25
        '
        'frmTutorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(892, 500)
        Me.Controls.Add(Me.FinishPanel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblSkip)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblBot)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTutorial"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.FinishPanel.ResumeLayout(False)
        Me.FinishPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblBot As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTrain As System.Windows.Forms.Label
    Friend WithEvents lblNetwork As System.Windows.Forms.Label
    Friend WithEvents lblApplication As System.Windows.Forms.Label
    Friend WithEvents lblKeyword As System.Windows.Forms.Label
    Friend WithEvents lblIndicator As System.Windows.Forms.Label
    Friend WithEvents lblVoice As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents MoveIndicator As System.Windows.Forms.Timer
    Friend WithEvents lblFinish As System.Windows.Forms.Label
    Friend WithEvents FinishPanel As System.Windows.Forms.Panel
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSkip As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents lblCommand As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents lblWord As System.Windows.Forms.Label
    Friend WithEvents lblTyping As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
