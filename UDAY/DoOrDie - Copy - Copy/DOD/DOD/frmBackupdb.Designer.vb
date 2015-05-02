<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupdb
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
        Me.btn_backup = New System.Windows.Forms.Button()
        Me.btn_restore = New System.Windows.Forms.Button()
        Me.cmb_Path = New System.Windows.Forms.ComboBox()
        Me.txt_mysqldump = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.ofdApplication = New System.Windows.Forms.OpenFileDialog()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Animation = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.fbdPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_backup
        '
        Me.btn_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_backup.Location = New System.Drawing.Point(41, 25)
        Me.btn_backup.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_backup.Name = "btn_backup"
        Me.btn_backup.Size = New System.Drawing.Size(175, 40)
        Me.btn_backup.TabIndex = 0
        Me.btn_backup.Text = "Backup"
        Me.btn_backup.UseVisualStyleBackColor = True
        '
        'btn_restore
        '
        Me.btn_restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_restore.Location = New System.Drawing.Point(285, 25)
        Me.btn_restore.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_restore.Name = "btn_restore"
        Me.btn_restore.Size = New System.Drawing.Size(175, 40)
        Me.btn_restore.TabIndex = 1
        Me.btn_restore.Text = "Restore"
        Me.btn_restore.UseVisualStyleBackColor = True
        '
        'cmb_Path
        '
        Me.cmb_Path.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Path.FormattingEnabled = True
        Me.cmb_Path.Items.AddRange(New Object() {"A:\", "B:\", "C:\", "D:\", "E:\", "F:\", "G:\", "H:\", "I:\", "J:\", "K:\", "L:\", "M:\", "O:\", "P:\", "Q:\", "R:\", "S:\", "T:\", "U:\", "V:\", "W:\", "X:\", "Y:\", "Z:\"})
        Me.cmb_Path.Location = New System.Drawing.Point(252, 61)
        Me.cmb_Path.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_Path.Name = "cmb_Path"
        Me.cmb_Path.Size = New System.Drawing.Size(130, 27)
        Me.cmb_Path.TabIndex = 2
        Me.cmb_Path.Visible = False
        '
        'txt_mysqldump
        '
        Me.txt_mysqldump.Enabled = False
        Me.txt_mysqldump.Location = New System.Drawing.Point(140, 115)
        Me.txt_mysqldump.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_mysqldump.Name = "txt_mysqldump"
        Me.txt_mysqldump.Size = New System.Drawing.Size(242, 27)
        Me.txt_mysqldump.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(377, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Locate mysqldump: C:\xampp\mysql\bin\mysqldump.exe"
        '
        'btn_browse
        '
        Me.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_browse.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_browse.Location = New System.Drawing.Point(389, 115)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(71, 28)
        Me.btn_browse.TabIndex = 5
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'ofdApplication
        '
        Me.ofdApplication.Filter = "All files | *.*"
        Me.ofdApplication.InitialDirectory = "C:"
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.Green
        Me.lblLeft.Location = New System.Drawing.Point(1, 2)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(5, 250)
        Me.lblLeft.TabIndex = 77
        '
        'lblTop
        '
        Me.lblTop.BackColor = System.Drawing.Color.Green
        Me.lblTop.Location = New System.Drawing.Point(0, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(500, 5)
        Me.lblTop.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(495, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(5, 250)
        Me.Label2.TabIndex = 78
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(1, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(500, 5)
        Me.Label3.TabIndex = 79
        '
        'Animation
        '
        Me.Animation.Interval = 10
        Me.Animation.Tag = "Show"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "mySQL dump"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Path Name"
        '
        'btnPath
        '
        Me.btnPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPath.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPath.Location = New System.Drawing.Point(389, 150)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(71, 28)
        Me.btnPath.TabIndex = 82
        Me.btnPath.Text = "Browse"
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Enabled = False
        Me.txtPath.Location = New System.Drawing.Point(140, 150)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(242, 27)
        Me.txtPath.TabIndex = 81
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(285, 195)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 40)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBackupdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 250)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblLeft)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_mysqldump)
        Me.Controls.Add(Me.cmb_Path)
        Me.Controls.Add(Me.btn_restore)
        Me.Controls.Add(Me.btn_backup)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBackupdb"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_backup As System.Windows.Forms.Button
    Friend WithEvents btn_restore As System.Windows.Forms.Button
    Friend WithEvents cmb_Path As System.Windows.Forms.ComboBox
    Friend WithEvents txt_mysqldump As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents ofdApplication As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Animation As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPath As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents fbdPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
