<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DASHBOARD2
    Inherits VCC.template1


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
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_main_close
        '
        Me.btn_main_close.Location = New System.Drawing.Point(805, 12)
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(618, 272)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(131, 70)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "START VOICE COMMAND"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(481, 272)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(131, 70)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "LOGOUT"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(344, 272)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 70)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "SYSTEM CONFIGURATION"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(207, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 70)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "NETWORK SETUP"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(70, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 70)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "COMMAND SETTINGS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(153, 140)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(131, 70)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "MY ACCOUNT"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(290, 140)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(131, 70)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "MY SCHEDULE"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(427, 140)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(131, 70)
        Me.Button8.TabIndex = 14
        Me.Button8.Text = "SYSTEM SETTINGS"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'DASHBOARD2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(902, 600)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DASHBOARD2"
        Me.Text = "DASHBOARD2"
        Me.Controls.SetChildIndex(Me.btn_main_close, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.Button3, 0)
        Me.Controls.SetChildIndex(Me.Button4, 0)
        Me.Controls.SetChildIndex(Me.Button5, 0)
        Me.Controls.SetChildIndex(Me.Button6, 0)
        Me.Controls.SetChildIndex(Me.Button7, 0)
        Me.Controls.SetChildIndex(Me.Button8, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
