<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class openning_of_files
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
        Me.btn_register_phrase = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lbl_file_location = New System.Windows.Forms.Label()
        Me.lbl_application_location = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.ofd2 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'btn_register_phrase
        '
        Me.btn_register_phrase.Location = New System.Drawing.Point(551, 82)
        Me.btn_register_phrase.Name = "btn_register_phrase"
        Me.btn_register_phrase.Size = New System.Drawing.Size(152, 90)
        Me.btn_register_phrase.TabIndex = 0
        Me.btn_register_phrase.Text = "REGISTER COMMAND PHRASE"
        Me.btn_register_phrase.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(551, 178)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 90)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "TARGET FILE LOCATION:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(236, 74)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 28)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "BROWSE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lbl_file_location
        '
        Me.lbl_file_location.AutoSize = True
        Me.lbl_file_location.Location = New System.Drawing.Point(46, 108)
        Me.lbl_file_location.Name = "lbl_file_location"
        Me.lbl_file_location.Size = New System.Drawing.Size(75, 13)
        Me.lbl_file_location.TabIndex = 4
        Me.lbl_file_location.Text = "<File location>"
        '
        'lbl_application_location
        '
        Me.lbl_application_location.AutoSize = True
        Me.lbl_application_location.Location = New System.Drawing.Point(46, 185)
        Me.lbl_application_location.Name = "lbl_application_location"
        Me.lbl_application_location.Size = New System.Drawing.Size(110, 13)
        Me.lbl_application_location.TabIndex = 7
        Me.lbl_application_location.Text = "<application location>"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(236, 151)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(70, 28)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "BROWSE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TARGET APPLICATION LOCATION:"
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'ofd2
        '
        Me.ofd2.FileName = "OpenFileDialog1"
        '
        'openning_of_files
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 309)
        Me.Controls.Add(Me.lbl_application_location)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_file_location)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_register_phrase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "openning_of_files"
        Me.Text = "Openning of files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_register_phrase As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lbl_file_location As System.Windows.Forms.Label
    Friend WithEvents lbl_application_location As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ofd2 As System.Windows.Forms.OpenFileDialog
End Class
