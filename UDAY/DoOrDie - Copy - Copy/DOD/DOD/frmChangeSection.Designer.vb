<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeSection
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
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lvStudents = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblDescription.Location = New System.Drawing.Point(23, 43)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(193, 21)
        Me.lblDescription.TabIndex = 25
        Me.lblDescription.Text = "Select a section to Activate"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(22, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(154, 28)
        Me.lblTitle.TabIndex = 24
        Me.lblTitle.Text = "Change Section"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(0, 0)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 450)
        Me.lblLeft.TabIndex = 23
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(350, 5)
        Me.lblTop.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(345, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 450)
        Me.Label1.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 445)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 5)
        Me.Label2.TabIndex = 27
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.lblCancel.Location = New System.Drawing.Point(275, 21)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(50, 21)
        Me.lblCancel.TabIndex = 29
        Me.lblCancel.Text = "Close"
        '
        'lvStudents
        '
        Me.lvStudents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvStudents.FullRowSelect = True
        Me.lvStudents.GridLines = True
        Me.lvStudents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvStudents.Location = New System.Drawing.Point(25, 155)
        Me.lvStudents.Name = "lvStudents"
        Me.lvStudents.Size = New System.Drawing.Size(300, 250)
        Me.lvStudents.TabIndex = 30
        Me.lvStudents.UseCompatibleStateImageBehavior = False
        Me.lvStudents.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Student ID"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Student Name"
        Me.ColumnHeader2.Width = 190
        '
        'cmbSection
        '
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(25, 95)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(300, 25)
        Me.cmbSection.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(23, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "List of Students"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(221, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 21)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Total :"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblTotal.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTotal.Location = New System.Drawing.Point(279, 130)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(46, 19)
        Me.lblTotal.TabIndex = 36
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChange
        '
        Me.lblChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblChange.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblChange.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblChange.Location = New System.Drawing.Point(25, 410)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(300, 25)
        Me.lblChange.TabIndex = 37
        Me.lblChange.Text = "Continue"
        Me.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'frmChangeSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(350, 450)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbSection)
        Me.Controls.Add(Me.lvStudents)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmChangeSection"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChangeSection"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCancel As System.Windows.Forms.Label
    Friend WithEvents lvStudents As System.Windows.Forms.ListView
    Friend WithEvents cmbSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblChange As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Animation As System.Windows.Forms.Timer
End Class
