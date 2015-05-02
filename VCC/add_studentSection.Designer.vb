<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_studentSection
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
        Me.listview_sections = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.datetime_timeout = New System.Windows.Forms.DateTimePicker()
        Me.datetime_timein = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'listview_sections
        '
        Me.listview_sections.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader7})
        Me.listview_sections.FullRowSelect = True
        Me.listview_sections.GridLines = True
        Me.listview_sections.HideSelection = False
        Me.listview_sections.Location = New System.Drawing.Point(13, 73)
        Me.listview_sections.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_sections.MultiSelect = False
        Me.listview_sections.Name = "listview_sections"
        Me.listview_sections.ShowItemToolTips = True
        Me.listview_sections.Size = New System.Drawing.Size(749, 168)
        Me.listview_sections.TabIndex = 12
        Me.listview_sections.UseCompatibleStateImageBehavior = False
        Me.listview_sections.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "SECTIONS"
        Me.ColumnHeader3.Width = 160
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
        Me.ColumnHeader1.Text = "PROFESSOR"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "section_id"
        Me.ColumnHeader7.Width = 106
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "PLEASE SELECT SUBJECT SCHEDULE"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(86, 273)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 33)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(270, 273)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(165, 33)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(451, 273)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(165, 33)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "REFRESH"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'datetime_timeout
        '
        Me.datetime_timeout.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.datetime_timeout.Location = New System.Drawing.Point(472, 44)
        Me.datetime_timeout.Name = "datetime_timeout"
        Me.datetime_timeout.Size = New System.Drawing.Size(200, 20)
        Me.datetime_timeout.TabIndex = 18
        Me.datetime_timeout.Visible = False
        '
        'datetime_timein
        '
        Me.datetime_timein.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.datetime_timein.Location = New System.Drawing.Point(472, 12)
        Me.datetime_timein.Name = "datetime_timein"
        Me.datetime_timein.Size = New System.Drawing.Size(200, 20)
        Me.datetime_timein.TabIndex = 17
        Me.datetime_timein.Visible = False
        '
        'add_studentSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 330)
        Me.Controls.Add(Me.datetime_timeout)
        Me.Controls.Add(Me.datetime_timein)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listview_sections)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "add_studentSection"
        Me.Text = "choose section"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listview_sections As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents datetime_timeout As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetime_timein As System.Windows.Forms.DateTimePicker
End Class
