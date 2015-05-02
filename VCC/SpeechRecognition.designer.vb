<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpeechRecognition
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER OPEN NOTEPAD")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER OPEN VISUAL-STUDIO")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER START TYPING")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER STOP TYPING")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("ALL CONNECT SERVER")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("ALL UNLOCK UNIT")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER CLOSE PROGRAM")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER SETUP TIME")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER START TIME")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("SERVER TELL TIME")
        Me.lbl_feedback2 = New System.Windows.Forms.Label()
        Me.lbl_mode = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lbl_type = New System.Windows.Forms.Label()
        Me.list_commands = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_timeleft = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_feedback2
        '
        Me.lbl_feedback2.AutoSize = True
        Me.lbl_feedback2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_feedback2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_feedback2.ForeColor = System.Drawing.Color.White
        Me.lbl_feedback2.Location = New System.Drawing.Point(101, 245)
        Me.lbl_feedback2.Name = "lbl_feedback2"
        Me.lbl_feedback2.Size = New System.Drawing.Size(90, 24)
        Me.lbl_feedback2.TabIndex = 1
        Me.lbl_feedback2.Text = "Listening."
        '
        'lbl_mode
        '
        Me.lbl_mode.AutoSize = True
        Me.lbl_mode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mode.ForeColor = System.Drawing.Color.Red
        Me.lbl_mode.Location = New System.Drawing.Point(101, 269)
        Me.lbl_mode.Name = "lbl_mode"
        Me.lbl_mode.Size = New System.Drawing.Size(69, 24)
        Me.lbl_mode.TabIndex = 2
        Me.lbl_mode.Text = "mode1"
        '
        'Timer1
        '
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Red
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(616, 251)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(102, 30)
        Me.Button7.TabIndex = 4
        Me.Button7.Text = "X"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'lbl_type
        '
        Me.lbl_type.AutoSize = True
        Me.lbl_type.BackColor = System.Drawing.Color.Transparent
        Me.lbl_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_type.ForeColor = System.Drawing.Color.White
        Me.lbl_type.Location = New System.Drawing.Point(242, 269)
        Me.lbl_type.Name = "lbl_type"
        Me.lbl_type.Size = New System.Drawing.Size(0, 24)
        Me.lbl_type.TabIndex = 5
        '
        'list_commands
        '
        Me.list_commands.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.list_commands.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10})
        Me.list_commands.Location = New System.Drawing.Point(81, 60)
        Me.list_commands.Name = "list_commands"
        Me.list_commands.Size = New System.Drawing.Size(521, 182)
        Me.list_commands.TabIndex = 6
        Me.list_commands.UseCompatibleStateImageBehavior = False
        Me.list_commands.View = System.Windows.Forms.View.Details
        Me.list_commands.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "COMMANDS"
        Me.ColumnHeader1.Width = 366
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(517, 258)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "COMMANDS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbl_timeleft
        '
        Me.lbl_timeleft.AutoSize = True
        Me.lbl_timeleft.BackColor = System.Drawing.Color.Transparent
        Me.lbl_timeleft.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_timeleft.ForeColor = System.Drawing.Color.White
        Me.lbl_timeleft.Location = New System.Drawing.Point(412, 257)
        Me.lbl_timeleft.Name = "lbl_timeleft"
        Me.lbl_timeleft.Size = New System.Drawing.Size(0, 24)
        Me.lbl_timeleft.TabIndex = 8
        '
        'SpeechRecognition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.BackgroundImage = Global.VCC.My.Resources.Resources.speech2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(760, 538)
        Me.Controls.Add(Me.lbl_timeleft)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.list_commands)
        Me.Controls.Add(Me.lbl_type)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.lbl_mode)
        Me.Controls.Add(Me.lbl_feedback2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SpeechRecognition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_feedback2 As System.Windows.Forms.Label
    Friend WithEvents lbl_mode As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lbl_type As System.Windows.Forms.Label
    Friend WithEvents list_commands As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents lbl_timeleft As System.Windows.Forms.Label
End Class
