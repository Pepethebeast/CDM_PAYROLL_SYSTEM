Imports Newtonsoft.Json
Imports System.Runtime.InteropServices
Imports ClosedXML.Excel
Imports Newtonsoft.Json.Linq
Public Class reports

    Private Sub LoadDataIntoDataGridView()
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        Dim srrecord As FireSharp.Response.FirebaseResponse

        ' Check the selected item in ComboBox1
        If ComboBox1.Text = "Accounts" Then
            ' Fetch data from the "ReportTbl/account" path
            srrecord = client.Get("ReportTbl/account")
        ElseIf ComboBox1.Text = "Payslip" Then
            ' Fetch data from the "ReportTbl/payslip" path
            srrecord = client.Get("ReportTbl/payslip")
        ElseIf ComboBox1.Text = "TimeRecords" Then
            ' Fetch data from the "ReportTbl/timerecords" path
            srrecord = client.Get("ReportTbl/timerecords")
        Else
            ' Handle case when none of the expected items are selected (optional)
            MessageBox.Show("Invalid selection, please choose a valid report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim rawJson = srrecord.Body

            ' Parse the JSON using JObject for dynamic handling
            Dim reportData As JObject = JObject.Parse(rawJson)

            If reportData Is Nothing OrElse reportData.Count = 0 Then
                MessageBox.Show("No data found.", "Data Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Prepare the DataGridView
            DGVUserData.DataSource = Nothing
            DGVUserData.Columns.Clear()
            DGVUserData.Rows.Clear()
            DGVUserData.AutoGenerateColumns = False

            ' Add required columns
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {
            .HeaderText = "Report Logs",
            .Name = "ReportLogs",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ' Disable auto-sizing
            .Width = 200 ' Explicit width
        })

            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {
            .HeaderText = "Message",
            .Name = "Message",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Fill remaining space
        })

            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {
            .HeaderText = "Date",
            .Name = "Date",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .Width = 250' Fill remaining space
        })

            ' Iterate over the parsed JSON
            For Each outerProperty As JProperty In reportData.Properties()
                Dim reportLogs As String = outerProperty.Name ' Report ID
                Dim innerData As JObject = TryCast(outerProperty.Value, JObject)

                If innerData IsNot Nothing Then
                    ' Get the Date value, ensure it's treated as a string
                    Dim dateStr As String = If(innerData("Date")?.ToString(), "N/A")

                    ' Iterate over the nested data (except "Date")
                    For Each innerProperty As JProperty In innerData.Properties()
                        If innerProperty.Name <> "Date" Then
                            Dim message As String = innerProperty.Value.ToString()
                            ' Add a row for each log
                            DGVUserData.Rows.Add(reportLogs, message, dateStr)
                        End If
                    Next
                Else
                    ' If the inner data is not an object, treat it as a simple message
                    Dim message As String = outerProperty.Value.ToString()
                    DGVUserData.Rows.Add(reportLogs, message, "N/A")
                End If
            Next

            ' Apply DataGridView styles (optional)
            DGVUserData.EnableHeadersVisualStyles = False
            DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
            DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVUserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVUserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVUserData.DefaultCellStyle.Font = New Font("Roboto", 12)
            DGVUserData.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", 8, FontStyle.Regular)
            DGVUserData.RowTemplate.Height = 30
            DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGVUserData.BorderStyle = BorderStyle.None
            DGVUserData.BackgroundColor = Color.White
            DGVUserData.GridColor = Color.White
            DGVUserData.RowHeadersVisible = False
            DGVUserData.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black

        Catch ex As Exception
            MessageBox.Show($"Error loading report logs: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToExcel(dataGridView As DataGridView)
        Try
            ' Create a new Excel workbook using ClosedXML
            Using workbook As New XLWorkbook()
                ' Add a worksheet to the workbook
                Dim worksheet = workbook.Worksheets.Add("Report")

                ' Export column headers
                For col As Integer = 0 To dataGridView.Columns.Count - 1
                    worksheet.Cell(1, col + 1).Value = dataGridView.Columns(col).HeaderText
                Next

                ' Export rows
                For row As Integer = 0 To dataGridView.Rows.Count - 1
                    For col As Integer = 0 To dataGridView.Columns.Count - 1
                        worksheet.Cell(row + 2, col + 1).Value = dataGridView.Rows(row).Cells(col).Value
                    Next
                Next

                ' Auto-fit the columns
                worksheet.Columns().AdjustToContents()

                ' Show save dialog
                Dim saveFileDialog As New SaveFileDialog With {
                    .Filter = "Excel Files (*.xlsx)|*.xlsx",
                    .Title = "Save as Excel File"
                }

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    ' Save the workbook to the selected file
                    workbook.SaveAs(saveFileDialog.FileName)
                    MessageBox.Show("Data exported successfully!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Helper method to release COM objects
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then
                Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub reports_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not IsExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                IsExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub
    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load ' Initialize the DataGridView only once when the form loads

        ComboBox1.Text = "Accounts"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Clear existing rows before loading new data


        If ComboBox1.Text = "Accounts" Then
            LoadDataIntoDataGridView()
        ElseIf ComboBox1.Text = "Payslip" Then
            LoadDataIntoDataGridView()
        End If
    End Sub


    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Main_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        List_of_Employees.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        payroll.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        RFID_Based_Attendance.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Employee_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ExportToExcel(DGVUserData)
    End Sub
End Class
