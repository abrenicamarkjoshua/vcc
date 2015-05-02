<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceive
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
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContinue = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblComputer = New System.Windows.Forms.Label()
        Me.lblWordcall = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblCancel.Location = New System.Drawing.Point(319, 20)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(57, 25)
        Me.lblCancel.TabIndex = 102
        Me.lblCancel.Text = "Close"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(272, 21)
        Me.lblDescription.TabIndex = 101
        Me.lblDescription.Text = "Specify the Date to Return the Activity"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(144, 28)
        Me.lblTitle.TabIndex = 100
        Me.lblTitle.Text = "Return Activity"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(5, 250)
        Me.Label2.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(400, 5)
        Me.Label6.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(395, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 250)
        Me.Label1.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(0, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(400, 5)
        Me.Label3.TabIndex = 104
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtpDate.Location = New System.Drawing.Point(26, 110)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(350, 29)
        Me.dtpDate.TabIndex = 105
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(27, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 21)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Select a Date"
        '
        'lblContinue
        '
        Me.lblContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblContinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblContinue.Location = New System.Drawing.Point(26, 145)
        Me.lblContinue.Name = "lblContinue"
        Me.lblContinue.Size = New System.Drawing.Size(349, 25)
        Me.lblContinue.TabIndex = 107
        Me.lblContinue.Text = "Continue"
        Me.lblContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(24, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 21)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Selected Computer"
        '
        'lblComputer
        '
        Me.lblComputer.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblComputer.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblComputer.Location = New System.Drawing.Point(172, 200)
        Me.lblComputer.Name = "lblComputer"
        Me.lblComputer.Size = New System.Drawing.Size(204, 28)
        Me.lblComputer.TabIndex = 109
        Me.lblComputer.Text = "All Computer"
        Me.lblComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWordcall
        '
        Me.lblWordcall.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblWordcall.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblWordcall.Location = New System.Drawing.Point(172, 200)
        Me.lblWordcall.Name = "lblWordcall"
        Me.lblWordcall.Size = New System.Drawing.Size(204, 28)
        Me.lblWordcall.TabIndex = 110
        Me.lblWordcall.Text = "All Computer"
        Me.lblWordcall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblWordcall.Visible = False
        '
        'frmReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 250)
        Me.Controls.Add(Me.lblWordcall)
        Me.Controls.Add(Me.lblComputer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblContinue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmReceive"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblContinue As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblComputer As System.Windows.Forms.Label
    Friend WithEvents lblWordcall As System.Windows.Forms.Label
End Class
