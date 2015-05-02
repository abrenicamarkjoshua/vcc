<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MY_ACCOUNT
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
        Me.LBL_USERNAME = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listview_sections = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lbl_section = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LBL_SETSECTION = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_closeSection = New System.Windows.Forms.Button()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_USERNAME
        '
        Me.LBL_USERNAME.AutoSize = True
        Me.LBL_USERNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBL_USERNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_USERNAME.ForeColor = System.Drawing.Color.White
        Me.LBL_USERNAME.Location = New System.Drawing.Point(138, 79)
        Me.LBL_USERNAME.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBL_USERNAME.Name = "LBL_USERNAME"
        Me.LBL_USERNAME.Size = New System.Drawing.Size(105, 20)
        Me.LBL_USERNAME.TabIndex = 16
        Me.LBL_USERNAME.Text = "USERNAME:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(23, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "USERNAME:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "REGISTERED SECTIONS"
        '
        'listview_sections
        '
        Me.listview_sections.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader7})
        Me.listview_sections.FullRowSelect = True
        Me.listview_sections.GridLines = True
        Me.listview_sections.HideSelection = False
        Me.listview_sections.Location = New System.Drawing.Point(20, 58)
        Me.listview_sections.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_sections.MultiSelect = False
        Me.listview_sections.Name = "listview_sections"
        Me.listview_sections.ShowItemToolTips = True
        Me.listview_sections.Size = New System.Drawing.Size(749, 168)
        Me.listview_sections.TabIndex = 11
        Me.ToolTip2.SetToolTip(Me.listview_sections, "STEP2. SELECT THE SECTION FROM THE LIST")
        Me.listview_sections.UseCompatibleStateImageBehavior = False
        Me.listview_sections.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "SECTIONS"
        Me.ColumnHeader3.Width = 230
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "SUBJECTS"
        Me.ColumnHeader4.Width = 142
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "DAY"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "TIME IN"
        Me.ColumnHeader6.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "TIME OUT"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "sched_id"
        Me.ColumnHeader7.Width = 106
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.listview_sections)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(308, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(791, 272)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SECTIONS"
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(20, 231)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(170, 35)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "UPDATE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(27, 144)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(170, 36)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "TUTORIAL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lbl_section
        '
        Me.lbl_section.AutoSize = True
        Me.lbl_section.BackColor = System.Drawing.Color.Transparent
        Me.lbl_section.ForeColor = System.Drawing.Color.White
        Me.lbl_section.Location = New System.Drawing.Point(134, 108)
        Me.lbl_section.Name = "lbl_section"
        Me.lbl_section.Size = New System.Drawing.Size(0, 20)
        Me.lbl_section.TabIndex = 24
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(27, 296)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(170, 35)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "SET SECTION"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LBL_SETSECTION
        '
        Me.LBL_SETSECTION.AutoSize = True
        Me.LBL_SETSECTION.BackColor = System.Drawing.Color.Transparent
        Me.LBL_SETSECTION.ForeColor = System.Drawing.Color.White
        Me.LBL_SETSECTION.Location = New System.Drawing.Point(23, 108)
        Me.LBL_SETSECTION.Name = "LBL_SETSECTION"
        Me.LBL_SETSECTION.Size = New System.Drawing.Size(83, 20)
        Me.LBL_SETSECTION.TabIndex = 20
        Me.LBL_SETSECTION.Text = "SECTION:"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(27, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 35)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "ADD SECTION"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.VCC.My.Resources.Resources.title
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 62)
        Me.Panel1.TabIndex = 21
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.OwnerDraw = True
        Me.ToolTip1.ShowAlways = True
        '
        'ToolTip2
        '
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip2.OwnerDraw = True
        Me.ToolTip2.ShowAlways = True
        '
        'ToolTip3
        '
        Me.ToolTip3.IsBalloon = True
        Me.ToolTip3.OwnerDraw = True
        Me.ToolTip3.ShowAlways = True
        '
        'ToolTip4
        '
        Me.ToolTip4.IsBalloon = True
        Me.ToolTip4.OwnerDraw = True
        Me.ToolTip4.ShowAlways = True
        '
        'btn_closeSection
        '
        Me.btn_closeSection.ForeColor = System.Drawing.Color.Black
        Me.btn_closeSection.Location = New System.Drawing.Point(27, 365)
        Me.btn_closeSection.Name = "btn_closeSection"
        Me.btn_closeSection.Size = New System.Drawing.Size(170, 35)
        Me.btn_closeSection.TabIndex = 26
        Me.btn_closeSection.Text = "CLOSE"
        Me.btn_closeSection.UseVisualStyleBackColor = True
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ACCESS CODE"
        Me.ColumnHeader9.Width = 97
        '
        'MY_ACCOUNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background_blue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1111, 459)
        Me.Controls.Add(Me.btn_closeSection)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_section)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.LBL_USERNAME)
        Me.Controls.Add(Me.LBL_SETSECTION)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "MY_ACCOUNT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MY_ACCOUNT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LBL_USERNAME As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listview_sections As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LBL_SETSECTION As System.Windows.Forms.Label
    Friend WithEvents lbl_section As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_closeSection As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
