<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class STUDENT_MODULE
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lbl_section = New System.Windows.Forms.Label()
        Me.lbl_subject = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_student_id = New System.Windows.Forms.Label()
        Me.listview_sections = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_student_name = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbl_timeleft = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblWordCall = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.lbl_section)
        Me.Panel1.Controls.Add(Me.lbl_subject)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lbl_student_id)
        Me.Panel1.Controls.Add(Me.listview_sections)
        Me.Panel1.Controls.Add(Me.lbl_student_name)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(40, 106)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 567)
        Me.Panel1.TabIndex = 8
        '
        'Button5
        '
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(43, 408)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(212, 36)
        Me.Button5.TabIndex = 25
        Me.Button5.Text = "REFRESH"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'lbl_section
        '
        Me.lbl_section.AutoSize = True
        Me.lbl_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_section.Location = New System.Drawing.Point(55, 85)
        Me.lbl_section.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_section.Name = "lbl_section"
        Me.lbl_section.Size = New System.Drawing.Size(90, 22)
        Me.lbl_section.TabIndex = 21
        Me.lbl_section.Text = "SECTION"
        '
        'lbl_subject
        '
        Me.lbl_subject.AutoSize = True
        Me.lbl_subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subject.Location = New System.Drawing.Point(55, 113)
        Me.lbl_subject.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_subject.Name = "lbl_subject"
        Me.lbl_subject.Size = New System.Drawing.Size(93, 22)
        Me.lbl_subject.TabIndex = 20
        Me.lbl_subject.Text = "SUBJECT"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(43, 452)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 36)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "ENTER CLASS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbl_student_id
        '
        Me.lbl_student_id.AutoSize = True
        Me.lbl_student_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_student_id.Location = New System.Drawing.Point(55, 51)
        Me.lbl_student_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_student_id.Name = "lbl_student_id"
        Me.lbl_student_id.Size = New System.Drawing.Size(76, 22)
        Me.lbl_student_id.TabIndex = 12
        Me.lbl_student_id.Text = "10-0381"
        '
        'listview_sections
        '
        Me.listview_sections.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.listview_sections.FullRowSelect = True
        Me.listview_sections.GridLines = True
        Me.listview_sections.HideSelection = False
        Me.listview_sections.Location = New System.Drawing.Point(43, 223)
        Me.listview_sections.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_sections.MultiSelect = False
        Me.listview_sections.Name = "listview_sections"
        Me.listview_sections.ShowItemToolTips = True
        Me.listview_sections.Size = New System.Drawing.Size(749, 168)
        Me.listview_sections.TabIndex = 18
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
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "active"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        '
        'lbl_student_name
        '
        Me.lbl_student_name.AutoSize = True
        Me.lbl_student_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_student_name.Location = New System.Drawing.Point(55, 23)
        Me.lbl_student_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_student_name.Name = "lbl_student_name"
        Me.lbl_student_name.Size = New System.Drawing.Size(221, 22)
        Me.lbl_student_name.TabIndex = 15
        Me.lbl_student_name.Text = "Abrenica, Mark Joshua, R."
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(43, 167)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(212, 36)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "ADD SUBJECT SCHEDULE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(43, 500)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(212, 36)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "logout"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbl_timeleft
        '
        Me.lbl_timeleft.BackColor = System.Drawing.Color.Transparent
        Me.lbl_timeleft.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_timeleft.Location = New System.Drawing.Point(738, 273)
        Me.lbl_timeleft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_timeleft.Name = "lbl_timeleft"
        Me.lbl_timeleft.Size = New System.Drawing.Size(441, 102)
        Me.lbl_timeleft.TabIndex = 22
        Me.lbl_timeleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImage = Global.VCC.My.Resources.Resources.title
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1192, 54)
        Me.Panel2.TabIndex = 9
        '
        'lblWordCall
        '
        Me.lblWordCall.BackColor = System.Drawing.Color.Transparent
        Me.lblWordCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWordCall.Location = New System.Drawing.Point(892, 70)
        Me.lblWordCall.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWordCall.Name = "lblWordCall"
        Me.lblWordCall.Size = New System.Drawing.Size(271, 102)
        Me.lblWordCall.TabIndex = 12
        Me.lblWordCall.Text = "PC1"
        Me.lblWordCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(865, 172)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 102)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "TIME LEFT:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'STUDENT_MODULE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.background_blue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1192, 728)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblWordCall)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_timeleft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "STUDENT_MODULE"
        Me.Text = "Timer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbl_student_id As System.Windows.Forms.Label
    Friend WithEvents lbl_student_name As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblWordCall As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents listview_sections As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_section As System.Windows.Forms.Label
    Friend WithEvents lbl_subject As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl_timeleft As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
