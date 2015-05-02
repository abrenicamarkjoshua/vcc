<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetTimer
    Inherits VCC.template1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_minutes = New System.Windows.Forms.TextBox()
        Me.lbl_section = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(300, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SET TIMER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(53, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NUMBER OF MINUTES:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(152, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(335, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "All clients will logout after the timer counts down to 0"
        '
        'txt_minutes
        '
        Me.txt_minutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_minutes.Location = New System.Drawing.Point(217, 117)
        Me.txt_minutes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_minutes.Name = "txt_minutes"
        Me.txt_minutes.Size = New System.Drawing.Size(226, 23)
        Me.txt_minutes.TabIndex = 3
        '
        'lbl_section
        '
        Me.lbl_section.AutoSize = True
        Me.lbl_section.BackColor = System.Drawing.Color.Transparent
        Me.lbl_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_section.ForeColor = System.Drawing.Color.White
        Me.lbl_section.Location = New System.Drawing.Point(300, 48)
        Me.lbl_section.Name = "lbl_section"
        Me.lbl_section.Size = New System.Drawing.Size(75, 17)
        Me.lbl_section.TabIndex = 10
        Me.lbl_section.Text = "SECTION"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(183, 213)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(251, 37)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_ok
        '
        Me.btn_ok.ForeColor = System.Drawing.Color.Black
        Me.btn_ok.Location = New System.Drawing.Point(183, 172)
        Me.btn_ok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(251, 37)
        Me.btn_ok.TabIndex = 12
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(661, 401)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl_section)
        Me.Controls.Add(Me.txt_minutes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "btn_close"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SET TIMER"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_section As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Public WithEvents txt_minutes As System.Windows.Forms.TextBox

End Class
