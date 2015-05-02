<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WordSettings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.listview_inactivewords = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txt_wordtoprint = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.txt_word = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_deactivate = New System.Windows.Forms.Button()
        Me.btn_activate = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.listview_activewords = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_register = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_word = New System.Windows.Forms.Label()
        Me.btn_delete_all_active = New System.Windows.Forms.Button()
        Me.btn_delete_all_inactive = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.listview_inactivewords)
        Me.GroupBox1.Location = New System.Drawing.Point(657, 144)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(259, 404)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INACTIVE WORDS"
        '
        'listview_inactivewords
        '
        Me.listview_inactivewords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.listview_inactivewords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listview_inactivewords.FullRowSelect = True
        Me.listview_inactivewords.GridLines = True
        Me.listview_inactivewords.HideSelection = False
        Me.listview_inactivewords.Location = New System.Drawing.Point(4, 20)
        Me.listview_inactivewords.Margin = New System.Windows.Forms.Padding(4)
        Me.listview_inactivewords.Name = "listview_inactivewords"
        Me.listview_inactivewords.Size = New System.Drawing.Size(251, 380)
        Me.listview_inactivewords.TabIndex = 3
        Me.listview_inactivewords.UseCompatibleStateImageBehavior = False
        Me.listview_inactivewords.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "WORD"
        Me.ColumnHeader1.Width = 97
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "TEXT TO PRINT"
        Me.ColumnHeader2.Width = 130
        '
        'txt_wordtoprint
        '
        Me.txt_wordtoprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_wordtoprint.Location = New System.Drawing.Point(16, 213)
        Me.txt_wordtoprint.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_wordtoprint.Multiline = True
        Me.txt_wordtoprint.Name = "txt_wordtoprint"
        Me.txt_wordtoprint.Size = New System.Drawing.Size(217, 107)
        Me.txt_wordtoprint.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 190)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "TEXT TO PRINT:"
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderSize = 0
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_clear.ForeColor = System.Drawing.Color.Black
        Me.btn_clear.Location = New System.Drawing.Point(16, 368)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(217, 28)
        Me.btn_clear.TabIndex = 26
        Me.btn_clear.Text = "CLEAR"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'txt_word
        '
        Me.txt_word.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_word.Location = New System.Drawing.Point(16, 165)
        Me.txt_word.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_word.Name = "txt_word"
        Me.txt_word.Size = New System.Drawing.Size(217, 23)
        Me.txt_word.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 144)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "WORD:"
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.Teal
        Me.btn_delete.FlatAppearance.BorderSize = 0
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_delete.ForeColor = System.Drawing.Color.Black
        Me.btn_delete.Location = New System.Drawing.Point(16, 439)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(217, 28)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "DELETE"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(16, 403)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(217, 28)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "UPDATE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_deactivate
        '
        Me.btn_deactivate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_deactivate.Enabled = False
        Me.btn_deactivate.FlatAppearance.BorderSize = 0
        Me.btn_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_deactivate.ForeColor = System.Drawing.Color.Black
        Me.btn_deactivate.Location = New System.Drawing.Point(547, 327)
        Me.btn_deactivate.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_deactivate.Name = "btn_deactivate"
        Me.btn_deactivate.Size = New System.Drawing.Size(101, 32)
        Me.btn_deactivate.TabIndex = 19
        Me.btn_deactivate.Text = "DEACTIVATE"
        Me.btn_deactivate.UseVisualStyleBackColor = False
        '
        'btn_activate
        '
        Me.btn_activate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_activate.Enabled = False
        Me.btn_activate.FlatAppearance.BorderSize = 0
        Me.btn_activate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_activate.ForeColor = System.Drawing.Color.Black
        Me.btn_activate.Location = New System.Drawing.Point(547, 286)
        Me.btn_activate.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_activate.Name = "btn_activate"
        Me.btn_activate.Size = New System.Drawing.Size(101, 32)
        Me.btn_activate.TabIndex = 18
        Me.btn_activate.Text = "ACTIVATE"
        Me.btn_activate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.listview_activewords)
        Me.GroupBox2.Location = New System.Drawing.Point(253, 144)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(289, 404)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ACTIVE WORDS"
        '
        'listview_activewords
        '
        Me.listview_activewords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listview_activewords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listview_activewords.FullRowSelect = True
        Me.listview_activewords.GridLines = True
        Me.listview_activewords.HideSelection = False
        Me.listview_activewords.Location = New System.Drawing.Point(4, 20)
        Me.listview_activewords.Margin = New System.Windows.Forms.Padding(4)
        Me.listview_activewords.Name = "listview_activewords"
        Me.listview_activewords.Size = New System.Drawing.Size(281, 380)
        Me.listview_activewords.TabIndex = 4
        Me.listview_activewords.UseCompatibleStateImageBehavior = False
        Me.listview_activewords.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "WORD"
        Me.ColumnHeader3.Width = 122
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "TEXT TO PRINT"
        Me.ColumnHeader4.Width = 145
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 40)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "REGISTER"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_register
        '
        Me.btn_register.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_register.FlatAppearance.BorderSize = 0
        Me.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_register.ForeColor = System.Drawing.Color.Black
        Me.btn_register.Location = New System.Drawing.Point(16, 331)
        Me.btn_register.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_register.Name = "btn_register"
        Me.btn_register.Size = New System.Drawing.Size(217, 28)
        Me.btn_register.TabIndex = 29
        Me.btn_register.Text = "REGISTER"
        Me.btn_register.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(389, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 17)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "WORD SETTINGS"
        '
        'lbl_word
        '
        Me.lbl_word.AutoSize = True
        Me.lbl_word.BackColor = System.Drawing.Color.Transparent
        Me.lbl_word.ForeColor = System.Drawing.Color.White
        Me.lbl_word.Location = New System.Drawing.Point(489, 85)
        Me.lbl_word.Name = "lbl_word"
        Me.lbl_word.Size = New System.Drawing.Size(38, 17)
        Me.lbl_word.TabIndex = 31
        Me.lbl_word.Text = "word"
        Me.lbl_word.Visible = False
        '
        'btn_delete_all_active
        '
        Me.btn_delete_all_active.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_delete_all_active.FlatAppearance.BorderSize = 0
        Me.btn_delete_all_active.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_delete_all_active.ForeColor = System.Drawing.Color.Black
        Me.btn_delete_all_active.Location = New System.Drawing.Point(547, 368)
        Me.btn_delete_all_active.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_delete_all_active.Name = "btn_delete_all_active"
        Me.btn_delete_all_active.Size = New System.Drawing.Size(101, 53)
        Me.btn_delete_all_active.TabIndex = 33
        Me.btn_delete_all_active.Text = "DELETE ALL ACTIVE"
        Me.btn_delete_all_active.UseVisualStyleBackColor = False
        '
        'btn_delete_all_inactive
        '
        Me.btn_delete_all_inactive.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_delete_all_inactive.FlatAppearance.BorderSize = 0
        Me.btn_delete_all_inactive.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_delete_all_inactive.ForeColor = System.Drawing.Color.Black
        Me.btn_delete_all_inactive.Location = New System.Drawing.Point(547, 427)
        Me.btn_delete_all_inactive.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_delete_all_inactive.Name = "btn_delete_all_inactive"
        Me.btn_delete_all_inactive.Size = New System.Drawing.Size(101, 53)
        Me.btn_delete_all_inactive.TabIndex = 34
        Me.btn_delete_all_inactive.Text = "DELETE ALL INACTIVE"
        Me.btn_delete_all_inactive.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(38, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(591, 34)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Word settings allows you to type programming languages. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You start typing mode b" & _
            "y saying 'server start typing' and stop it by saying 'server stop typing'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(788, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 49)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'WordSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(931, 573)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_delete_all_inactive)
        Me.Controls.Add(Me.btn_delete_all_active)
        Me.Controls.Add(Me.btn_activate)
        Me.Controls.Add(Me.btn_deactivate)
        Me.Controls.Add(Me.lbl_word)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_register)
        Me.Controls.Add(Me.txt_wordtoprint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_word)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "WordSettings"
        Me.Text = "MY CUSTOMIZED WORDS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents listview_inactivewords As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txt_wordtoprint As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents txt_word As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents listview_activewords As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_deactivate As System.Windows.Forms.Button
    Friend WithEvents btn_activate As System.Windows.Forms.Button
    Friend WithEvents btn_register As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_word As System.Windows.Forms.Label
    Friend WithEvents btn_delete_all_active As System.Windows.Forms.Button
    Friend WithEvents btn_delete_all_inactive As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
