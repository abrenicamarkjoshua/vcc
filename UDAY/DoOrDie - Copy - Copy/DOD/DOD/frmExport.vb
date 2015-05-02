Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmExport
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim okExit As Boolean = False

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        okExit = True
        Animation.Tag = "Hide"
        Animation.Start()
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Regular)
        lblClose.ForeColor = Color.White
    End Sub

    Private Sub lblClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClose.MouseMove
        lblClose.Font = New Font("Segoe UI Semibold", 13, FontStyle.Underline)
        lblClose.ForeColor = Color.LawnGreen
    End Sub

    Sub LoadDrives()
        cmbDrives.Items.Clear()

        Dim sDrive As String, sDrives() As String
        sDrives = ListAllDrives()

        For Each sDrive In sDrives
            cmbDrives.Items.Add(sDrive.ToString)
        Next
    End Sub

    Private Sub Animation_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Animation.Tick
        If Animation.Tag = "Show" Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.05
                Me.Top -= 1
            Else
                Animation.Stop()

                LoadDrives()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.05
                Me.Top += 1
            Else
                Animation.Stop()

                Try
                    frmMyClass.rec.LoadGrammar(grammarclass)
                    frmMyClass.rec.SetInputToDefaultAudioDevice()
                    frmMyClass.rec.RecognizeAsync(1)
                Catch : End Try

                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmExport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        
    End Sub

    Private Sub frmExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If okExit = False Then
            e.Cancel = True
        End If
    End Sub

    Public Function ListAllDrives() As String()
        Dim Drivesarr() As String
        Drivesarr = Directory.GetLogicalDrives()

        Return Drivesarr
    End Function

    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Animation.Tag = "Show"
        Animation.Start()
    End Sub

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Private Sub lblExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExport.Click
        If cmbDrives.Text = "" Then
            message = "Please select a Drive to store the Exported File"
            MsgBox("Please select a Drive to store the Exported File", MsgBoxStyle.Information, "Export File")

            Exit Sub
        End If

        message = "Press 'Yes' to start Exporting.. and 'No' to cancel"

        If MsgBox("Are you sure you want to Export the Activities and Attendance on " & dtpDate.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Export File") = MsgBoxResult.Yes Then
            If Not System.IO.Directory.Exists(cmbDrives.Text) Then
                message = "Unablet to Locate the Storage to Store Exported File"
                MsgBox("Unable to Locate the Storage to Store Exported File", MsgBoxStyle.Information, "Export File")

                Exit Sub
            End If

            If Not System.IO.Directory.Exists(Path.Combine(cmbDrives.Text, dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year)) Then
                System.IO.Directory.CreateDirectory(Path.Combine(cmbDrives.Text, dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year))
            End If

            Try
                CopyDirectory(Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Activity", dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year), Path.Combine(cmbDrives.Text, dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year))
            Catch ex As Exception
                message = "Exporting of Activities and Attendance has been Interupted due to an Error"
                MsgBox("Exporting of Activities and Attendance has been Interupted due to an Error", MsgBoxStyle.Information, "Export File")

                Exit Sub
            End Try

            Try
                '~~> Create an Excel Application for Attendance
                xlWorkBook = xlApp.Workbooks.Add

                xlApp.Visible = False

                xlWorkSheet = xlWorkBook.Sheets("Sheet1")
                xlWorkSheet.Name = "Attendance"

                '~~> Set the Font Format for the Cell
                xlWorkSheet.Range("A:G").Font.Color = 1
                xlWorkSheet.Range("A:G").Font.Size = 11
                xlWorkSheet.Range("A:G").Font.Name = "Calibri"

                With xlWorkSheet
                    '~~> Set the Width of the Column
                    .Columns("A").ColumnWidth = 15
                    .Columns("B").ColumnWidth = 54
                    .Columns("C").ColumnWidth = 17.57

                    '~~> Create the Title for the Attendance
                    .Range("A1:C1").Merge()
                    .Range("A1").Value = "Students Attendance"
                    .Range("A1").HorizontalAlignment = Excel.Constants.xlCenter
                    .Range("A1").Font.Bold = True
                    .Range("A2:C2").Merge()
                    .Range("A2").Value = dtpDate.Text
                    .Range("A2").HorizontalAlignment = Excel.Constants.xlCenter
                    .Range("A2").Font.Bold = True
                    .Range("A3:C3").Merge()
                    .Range("A3").Value = frmMenu.lblSection.Text
                    .Range("A3").HorizontalAlignment = Excel.Constants.xlCenter
                    .Range("A3").Font.Bold = True

                    .Range("A5").Value = "Student-ID"
                    .Range("B5").Value = "Student Name"
                    .Range("C5").Value = "Status"

                    With .Range("A5:C5")
                        With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                            .LineStyle = Excel.XlLineStyle.xlDouble
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                    End With

                    '~~> Loop to the Number of Students for their Attendance
                    sql = "SELECT * FROM tbl_student WHERE major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user ORDER BY studentlname ASC"
                    Dim selstud As New MySqlCommand(sql, con)
                    selstud.Parameters.AddWithValue("?major", frmMenu.major)
                    selstud.Parameters.AddWithValue("?year", frmMenu.year)
                    selstud.Parameters.AddWithValue("?section", frmMenu.section)
                    selstud.Parameters.AddWithValue("?subject", frmMenu.subject)
                    selstud.Parameters.AddWithValue("?user", frmMenu.username)
                    da = New MySqlDataAdapter(selstud)
                    ds.Clear()
                    da.Fill(ds, "stud")

                    If ds.Tables("stud").Rows.Count > 0 Then
                        For a = 1 To ds.Tables("stud").Rows.Count
                            .Range("A" & a + 6).Value = "'" & ds.Tables("stud").Rows(a - 1).Item("studentid").ToString
                            .Range("A" & a + 6).HorizontalAlignment = Excel.Constants.xlCenter

                            .Range("B" & a + 6).Value = "'" & ds.Tables("stud").Rows(a - 1).Item("studentlname").ToString & ", " & ds.Tables("stud").Rows(a - 1).Item("studentfname").ToString
                            .Range("B" & a + 6).HorizontalAlignment = Excel.Constants.xlLeft

                            With .Range("A" & 6 & ":C" & 6)
                                With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                            End With

                            Dim isAbsent As Boolean = True

                            sql = "SELECT * FROM tbl_attendance WHERE studentid=?id AND major=?major AND year=?year AND section=?section AND subject=?subject AND accountuser=?user AND (loginfo=?log)"
                            Dim att As New MySqlCommand(sql, con)
                            att.Parameters.AddWithValue("?id", ds.Tables("stud").Rows(a - 1).Item("studentid").ToString)
                            att.Parameters.AddWithValue("?major", frmMenu.major)
                            att.Parameters.AddWithValue("?year", frmMenu.year)
                            att.Parameters.AddWithValue("?section", frmMenu.section)
                            att.Parameters.AddWithValue("?subject", frmMenu.subject)
                            att.Parameters.AddWithValue("?user", frmMenu.username)
                            att.Parameters.AddWithValue("?log", dtpDate.Value.ToShortDateString)
                            da = New MySqlDataAdapter(att)
                            da.Fill(ds, "att")

                            If ds.Tables("att").Rows.Count > 0 Then
                                .Range("C" & a + 6).Value = "Present"
                                isAbsent = False

                                GoTo skip
                            End If

                            .Range("C" & a + 6).Value = "Absent"
                            isAbsent = True

skip:
                            ds.Tables("att").Clear()

                            If isAbsent = True Then
                                .Range("C" & a + 6).Font.ColorIndex = 3
                            Else
                                .Range("C" & a + 6).Font.ColorIndex = 1
                            End If

                            With .Range("A" & a + 6 & ":C" & a + 6)
                                With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                    .LineStyle = Excel.XlLineStyle.xlDouble
                                    .ColorIndex = 0
                                    .TintAndShade = 0
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                            End With
                        Next

                        If Not File.Exists(cmbDrives.Text & dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year & "\Attendance.xls") Then
                            xlWorkBook.SaveAs(cmbDrives.Text & dtpDate.Value.Month & "-" & dtpDate.Value.Day & "-" & dtpDate.Value.Year & "\Attendance.xls")
                        End If

                        xlApp.Workbooks.Close()
                        xlApp.Quit()
                    End If
                End With
            Catch ex As Exception
                message = "An error occured while creating an Attendance"
                MsgBox("An error occured while creating an Attendance", MsgBoxStyle.Information, "Export File")

                Exit Sub
            End Try

            message = "Exporting of Activities and Attendance has been Completed"
            MsgBox("Exporting of Activities and Attendance has been Completed", MsgBoxStyle.Information, "Export File")

            cmbDrives.Text = ""
        End If
    End Sub

    Private Sub lblExport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExport.MouseLeave
        lblExport.BackColor = Color.FromArgb(2, 97, 102)
    End Sub

    Private Sub lblExport_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblExport.MouseMove
        lblExport.BackColor = Color.FromArgb(2, 97, 80)
    End Sub

    Private Sub cmbDrives_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDrives.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbDrives_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDrives.SelectedIndexChanged

    End Sub
End Class