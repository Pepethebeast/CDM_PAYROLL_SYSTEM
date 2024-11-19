Imports Newtonsoft.Json
Imports System.Runtime.InteropServices
Imports ClosedXML.Excel
Public Class reports
    Private Sub LoadDataIntoDataGridView()
        ' Initialize the Firebase client
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

        If client IsNot Nothing Then
            ' Retrieve data from Firebase
            Dim response As FireSharp.Response.FirebaseResponse = client.Get("ReportTbl/account/")
            If response.StatusCode = 200 Then
                ' Deserialize the data
                Dim accountData As Dictionary(Of String, String) = response.ResultAs(Of Dictionary(Of String, String))()

                ' Clear any existing data in DataGridView
                DGVUserData.Rows.Clear()

                ' Loop through the dictionary and add data to the DataGridView
                For Each kvp As KeyValuePair(Of String, String) In accountData
                    ' Add the UID (key) and associated information (value) to DataGridView
                    DGVUserData.Rows.Add(kvp.Key, kvp.Value)
                Next
            Else
                MessageBox.Show("Failed to retrieve data from Firebase")
            End If
        Else
            MessageBox.Show("Failed to connect to Firebase")
        End If
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

    Private Sub InitializeDataGridView()
        ' Prevent adding columns again if already initialized
        If DGVUserData.Columns.Count > 0 Then Exit Sub

        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' Remove the border of the DataGridView
        DGVUserData.BorderStyle = BorderStyle.None

        ' Set the font to Roboto, size 12
        Dim robotoFont As New System.Drawing.Font("Roboto", 12, FontStyle.Regular)
        DGVUserData.DefaultCellStyle.Font = robotoFont
        DGVUserData.ColumnHeadersDefaultCellStyle.Font = robotoFont

        ' Optional: Adjust additional styles to match a modern look
        DGVUserData.BackgroundColor = Color.White
        DGVUserData.GridColor = Color.White
        DGVUserData.RowHeadersVisible = False
        DGVUserData.EnableHeadersVisualStyles = False
        DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DGVUserData.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black
        DGVUserData.ReadOnly = True

        DGVUserData.AllowUserToAddRows = False
        DGVUserData.Columns.Add("Reportlogs", "report logs")
        DGVUserData.Columns.Add("Message", "Message")
        DGVUserData.Columns("Reportlogs").Width = 200
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
    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the DataGridView only once when the form loads
        InitializeDataGridView()
        ComboBox1.Text = "Accounts"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Clear existing rows before loading new data
        DGVUserData.Rows.Clear()

        If ComboBox1.Text = "Accounts" Then
            LoadDataIntoDataGridView()
        ElseIf ComboBox1.Text = "Payslip" Then
            LoadPayslipReport()
        End If
    End Sub

    Private Sub LoadPayslipReport()
        ' Initialize the Firebase client
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

        If client IsNot Nothing Then
            ' Retrieve data from Firebase
            Dim response As FireSharp.Response.FirebaseResponse = client.Get("ReportTbl/payslip/")
            If response.StatusCode = 200 Then
                ' Deserialize the data
                Dim payslipData As Dictionary(Of String, String) = response.ResultAs(Of Dictionary(Of String, String))()

                ' Clear any existing data in DataGridView
                DGVUserData.Rows.Clear()

                ' Loop through the dictionary and add data to the DataGridView
                For Each kvp As KeyValuePair(Of String, String) In payslipData
                    ' Add the UID (key) and associated information (value) to DataGridView
                    DGVUserData.Rows.Add(kvp.Key, kvp.Value)
                Next
            Else
                MessageBox.Show("Failed to retrieve data from Firebase")
            End If
        Else
            MessageBox.Show("Failed to connect to Firebase")
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
        acc.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ExportToExcel(DGVUserData)
    End Sub
End Class
