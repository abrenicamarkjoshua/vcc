<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class network_setup
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbl_ipaddress = New System.Windows.Forms.Label()
        Me.lbl_computername = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.listview_computers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.txt_word = New System.Windows.Forms.TextBox()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ToolTip2
        '
        Me.ToolTip2.IsBalloon = True
        '
        'ToolTip3
        '
        Me.ToolTip3.IsBalloon = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(653, 67)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 50)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "TUTORIAL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(772, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 49)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbl_ipaddress
        '
        Me.lbl_ipaddress.AutoSize = True
        Me.lbl_ipaddress.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ipaddress.ForeColor = System.Drawing.Color.White
        Me.lbl_ipaddress.Location = New System.Drawing.Point(554, 277)
        Me.lbl_ipaddress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ipaddress.Name = "lbl_ipaddress"
        Me.lbl_ipaddress.Size = New System.Drawing.Size(94, 17)
        Me.lbl_ipaddress.TabIndex = 38
        Me.lbl_ipaddress.Text = "<IPADDRESS"
        '
        'lbl_computername
        '
        Me.lbl_computername.AutoSize = True
        Me.lbl_computername.BackColor = System.Drawing.Color.Transparent
        Me.lbl_computername.ForeColor = System.Drawing.Color.White
        Me.lbl_computername.Location = New System.Drawing.Point(554, 202)
        Me.lbl_computername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_computername.Name = "lbl_computername"
        Me.lbl_computername.Size = New System.Drawing.Size(145, 17)
        Me.lbl_computername.TabIndex = 37
        Me.lbl_computername.Text = "<COMPUTER NAME>"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(772, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 50)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "REFRESH"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(463, 54)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "NETWORK SETUP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "DETECTED CLIENTS:"
        '
        'listview_computers
        '
        Me.listview_computers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listview_computers.FullRowSelect = True
        Me.listview_computers.GridLines = True
        Me.listview_computers.HideSelection = False
        Me.listview_computers.Location = New System.Drawing.Point(14, 106)
        Me.listview_computers.Margin = New System.Windows.Forms.Padding(4)
        Me.listview_computers.Name = "listview_computers"
        Me.listview_computers.Size = New System.Drawing.Size(504, 367)
        Me.listview_computers.TabIndex = 0
        Me.listview_computers.UseCompatibleStateImageBehavior = False
        Me.listview_computers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "WORD CALL"
        Me.ColumnHeader1.Width = 170
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "COMPUTER NAME"
        Me.ColumnHeader2.Width = 192
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "IP ADDRESS"
        Me.ColumnHeader3.Width = 220
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(533, 260)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 17)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "IP ADDRESS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(533, 125)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "WORD CALL:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(532, 185)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "COMPUTER NAME:"
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderSize = 0
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_clear.Location = New System.Drawing.Point(535, 432)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(321, 34)
        Me.btn_clear.TabIndex = 26
        Me.btn_clear.Text = "CLEAR"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_update
        '
        Me.btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_update.FlatAppearance.BorderSize = 0
        Me.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_update.Location = New System.Drawing.Point(535, 345)
        Me.btn_update.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(321, 34)
        Me.btn_update.TabIndex = 18
        Me.btn_update.Text = "UPDATE"
        Me.btn_update.UseVisualStyleBackColor = False
        '
        'txt_word
        '
        Me.txt_word.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_word.Location = New System.Drawing.Point(535, 146)
        Me.txt_word.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_word.Name = "txt_word"
        Me.txt_word.Size = New System.Drawing.Size(321, 23)
        Me.txt_word.TabIndex = 21
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_delete.FlatAppearance.BorderSize = 0
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_delete.Location = New System.Drawing.Point(535, 389)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(321, 34)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "DELETE"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'network_setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(888, 530)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lbl_ipaddress)
        Me.Controls.Add(Me.lbl_computername)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.listview_computers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.txt_word)
        Me.Controls.Add(Me.btn_delete)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "network_setup"
        Me.Text = "COMPUTERS SETUP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listview_computers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents txt_word As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_computername As System.Windows.Forms.Label
    Friend WithEvents lbl_ipaddress As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
End Class
