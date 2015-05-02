<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class student_add_section
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_section = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmb_subject = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_professor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(119, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 58)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "REGISTER"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(238, 227)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 58)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SECTION:"
        '
        'cmb_section
        '
        Me.cmb_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_section.FormattingEnabled = True
        Me.cmb_section.Location = New System.Drawing.Point(143, 36)
        Me.cmb_section.Name = "cmb_section"
        Me.cmb_section.Size = New System.Drawing.Size(327, 24)
        Me.cmb_section.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(357, 227)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 58)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "REFRESH"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmb_subject
        '
        Me.cmb_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_subject.FormattingEnabled = True
        Me.cmb_subject.Location = New System.Drawing.Point(143, 66)
        Me.cmb_subject.Name = "cmb_subject"
        Me.cmb_subject.Size = New System.Drawing.Size(327, 24)
        Me.cmb_subject.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "SUBJECT:"
        '
        'cmb_professor
        '
        Me.cmb_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_professor.FormattingEnabled = True
        Me.cmb_professor.Location = New System.Drawing.Point(143, 96)
        Me.cmb_professor.Name = "cmb_professor"
        Me.cmb_professor.Size = New System.Drawing.Size(327, 24)
        Me.cmb_professor.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PROFESSOR:"
        '
        'student_add_section
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 328)
        Me.Controls.Add(Me.cmb_professor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb_subject)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cmb_section)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "student_add_section"
        Me.Text = "ADD SECTION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_section As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmb_subject As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_professor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
