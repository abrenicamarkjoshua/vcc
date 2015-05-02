<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fileSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fileSettings))
        Me.lbl_parameter = New System.Windows.Forms.Label()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.select_applicationType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_word = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.list_words = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ofd2 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_parameter
        '
        Me.lbl_parameter.AutoSize = True
        Me.lbl_parameter.BackColor = System.Drawing.Color.Transparent
        Me.lbl_parameter.ForeColor = System.Drawing.Color.White
        Me.lbl_parameter.Location = New System.Drawing.Point(19, 212)
        Me.lbl_parameter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_parameter.Name = "lbl_parameter"
        Me.lbl_parameter.Size = New System.Drawing.Size(0, 17)
        Me.lbl_parameter.TabIndex = 16
        '
        'btn_browse
        '
        Me.btn_browse.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btn_browse.FlatAppearance.BorderSize = 0
        Me.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_browse.Location = New System.Drawing.Point(14, 171)
        Me.btn_browse.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(333, 28)
        Me.btn_browse.TabIndex = 13
        Me.btn_browse.Text = "BROWSE TARGET FILE:"
        Me.btn_browse.UseVisualStyleBackColor = False
        '
        'select_applicationType
        '
        Me.select_applicationType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.select_applicationType.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.select_applicationType.FormattingEnabled = True
        Me.select_applicationType.Location = New System.Drawing.Point(13, 264)
        Me.select_applicationType.Margin = New System.Windows.Forms.Padding(4)
        Me.select_applicationType.Name = "select_applicationType"
        Me.select_applicationType.Size = New System.Drawing.Size(352, 24)
        Me.select_applicationType.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(19, 244)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "APPLICATION TYPE:"
        '
        'txt_word
        '
        Me.txt_word.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_word.Location = New System.Drawing.Point(15, 140)
        Me.txt_word.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_word.Name = "txt_word"
        Me.txt_word.Size = New System.Drawing.Size(333, 23)
        Me.txt_word.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 119)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "WORD:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(17, 468)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(333, 38)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "DELETE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Teal
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(17, 422)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(333, 38)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "UPDATE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(17, 376)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(333, 38)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "REGISTER"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'list_words
        '
        Me.list_words.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.list_words.FullRowSelect = True
        Me.list_words.GridLines = True
        Me.list_words.HideSelection = False
        Me.list_words.Location = New System.Drawing.Point(375, 140)
        Me.list_words.Margin = New System.Windows.Forms.Padding(4)
        Me.list_words.Name = "list_words"
        Me.list_words.Size = New System.Drawing.Size(516, 406)
        Me.list_words.TabIndex = 1
        Me.list_words.UseCompatibleStateImageBehavior = False
        Me.list_words.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "WORD"
        Me.ColumnHeader1.Width = 159
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "TARGET"
        Me.ColumnHeader3.Width = 239
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "TARGET LOCATION"
        Me.ColumnHeader4.Width = 217
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(450, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "FILE SETTINGS"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button5.Location = New System.Drawing.Point(15, 340)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(333, 28)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "BROWSE APPLICATION TARGET:"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'ofd2
        '
        Me.ofd2.FileName = "OpenFileDialog1"
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderSize = 0
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_clear.Location = New System.Drawing.Point(17, 514)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(333, 38)
        Me.btn_clear.TabIndex = 35
        Me.btn_clear.Text = "CLEAR"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(17, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(872, 34)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(728, 24)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(161, 45)
        Me.Button4.TabIndex = 37
        Me.Button4.Text = "CLOSE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'fileSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(903, 560)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.list_words)
        Me.Controls.Add(Me.lbl_parameter)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.select_applicationType)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_word)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "fileSettings"
        Me.Padding = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.Text = "Register Open/close application commands"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents txt_word As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents list_words As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbl_parameter As System.Windows.Forms.Label
    Friend WithEvents select_applicationType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ofd2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
