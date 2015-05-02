<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddTime
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtMinute = New System.Windows.Forms.TextBox()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblComputer = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.lblWordCall = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(400, 5)
        Me.Label6.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(0, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(400, 5)
        Me.Label1.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(395, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(5, 200)
        Me.Label4.TabIndex = 90
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(5, 200)
        Me.Label2.TabIndex = 91
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(100, 28)
        Me.lblTitle.TabIndex = 92
        Me.lblTitle.Text = "Add Time"
        '
        'txtMinute
        '
        Me.txtMinute.Location = New System.Drawing.Point(24, 103)
        Me.txtMinute.Name = "txtMinute"
        Me.txtMinute.Size = New System.Drawing.Size(216, 25)
        Me.txtMinute.TabIndex = 0
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(246, 103)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(130, 25)
        Me.lblContinue.TabIndex = 1
        Me.lblContinue.Text = "Continue"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(243, 21)
        Me.lblDescription.TabIndex = 93
        Me.lblDescription.Text = "Set the number of minutes to add"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(23, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 21)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Enter minute(s)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(22, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 21)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Selected Computer :"
        '
        'lblComputer
        '
        Me.lblComputer.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblComputer.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblComputer.Location = New System.Drawing.Point(188, 150)
        Me.lblComputer.Name = "lblComputer"
        Me.lblComputer.Size = New System.Drawing.Size(188, 21)
        Me.lblComputer.TabIndex = 96
        Me.lblComputer.Text = "All Computer"
        Me.lblComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblCancel.Location = New System.Drawing.Point(319, 20)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(57, 25)
        Me.lblCancel.TabIndex = 97
        Me.lblCancel.Text = "Close"
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'lblWordCall
        '
        Me.lblWordCall.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblWordCall.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblWordCall.Location = New System.Drawing.Point(188, 150)
        Me.lblWordCall.Name = "lblWordCall"
        Me.lblWordCall.Size = New System.Drawing.Size(188, 21)
        Me.lblWordCall.TabIndex = 98
        Me.lblWordCall.Text = "All Computer"
        Me.lblWordCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblWordCall.Visible = False
        '
        'frmAddTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 200)
        Me.Controls.Add(Me.lblWordCall)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.lblComputer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblContinue)
        Me.Controls.Add(Me.txtMinute)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAddTime"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtMinute As System.Windows.Forms.TextBox
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblComputer As System.Windows.Forms.Label
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents lblWordCall As System.Windows.Forms.Label
End Class
