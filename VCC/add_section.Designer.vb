<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_section
    Inherits VCC.modal1


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
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_day = New System.Windows.Forms.ComboBox()
        Me.datetime_timein = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.datetime_timeout = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_accessCode = New System.Windows.Forms.TextBox()
        Me.txt_timein = New System.Windows.Forms.TextBox()
        Me.txt_timeout = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(47, 288)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(79, 61)
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.Text = "SECTION:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(157, 58)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(157, 87)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(263, 23)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "SUBJECT:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "SCHEDULE DAY:"
        '
        'cmb_day
        '
        Me.cmb_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_day.FormattingEnabled = True
        Me.cmb_day.Items.AddRange(New Object() {"Mondays", "Tuesdays", "Wednesdays", "Thursdays", "Fridays", "Saturdays", "Sundays"})
        Me.cmb_day.Location = New System.Drawing.Point(157, 116)
        Me.cmb_day.Name = "cmb_day"
        Me.cmb_day.Size = New System.Drawing.Size(263, 24)
        Me.cmb_day.TabIndex = 10
        '
        'datetime_timein
        '
        Me.datetime_timein.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.datetime_timein.Location = New System.Drawing.Point(290, 164)
        Me.datetime_timein.Name = "datetime_timein"
        Me.datetime_timein.Size = New System.Drawing.Size(130, 23)
        Me.datetime_timein.TabIndex = 11
        Me.datetime_timein.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "TIMEIN:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(79, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "TIMEOUT:"
        '
        'datetime_timeout
        '
        Me.datetime_timeout.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.datetime_timeout.Location = New System.Drawing.Point(290, 196)
        Me.datetime_timeout.Name = "datetime_timeout"
        Me.datetime_timeout.Size = New System.Drawing.Size(130, 23)
        Me.datetime_timeout.TabIndex = 14
        Me.datetime_timeout.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(251, 288)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 34)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "ACCESS CODE:"
        '
        'txt_accessCode
        '
        Me.txt_accessCode.Location = New System.Drawing.Point(157, 233)
        Me.txt_accessCode.Name = "txt_accessCode"
        Me.txt_accessCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_accessCode.Size = New System.Drawing.Size(263, 23)
        Me.txt_accessCode.TabIndex = 17
        '
        'txt_timein
        '
        Me.txt_timein.Location = New System.Drawing.Point(157, 164)
        Me.txt_timein.Name = "txt_timein"
        Me.txt_timein.Size = New System.Drawing.Size(127, 23)
        Me.txt_timein.TabIndex = 18
        '
        'txt_timeout
        '
        Me.txt_timeout.Location = New System.Drawing.Point(157, 196)
        Me.txt_timeout.Name = "txt_timeout"
        Me.txt_timeout.Size = New System.Drawing.Size(127, 23)
        Me.txt_timeout.TabIndex = 19
        '
        'add_section
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 350)
        Me.Controls.Add(Me.txt_timeout)
        Me.Controls.Add(Me.txt_timein)
        Me.Controls.Add(Me.txt_accessCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.datetime_timeout)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.datetime_timein)
        Me.Controls.Add(Me.cmb_day)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Name = "add_section"
        Me.Text = "ADD SECTION"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.TextBox2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmb_day, 0)
        Me.Controls.SetChildIndex(Me.datetime_timein, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.datetime_timeout, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_accessCode, 0)
        Me.Controls.SetChildIndex(Me.txt_timein, 0)
        Me.Controls.SetChildIndex(Me.txt_timeout, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_day As System.Windows.Forms.ComboBox
    Friend WithEvents datetime_timein As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents datetime_timeout As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_accessCode As System.Windows.Forms.TextBox
    Friend WithEvents txt_timein As System.Windows.Forms.TextBox
    Friend WithEvents txt_timeout As System.Windows.Forms.TextBox
End Class
