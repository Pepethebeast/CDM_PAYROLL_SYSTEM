Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.Office.Interop.Excel
Imports ClosedXML.Excel
Public Class payroll_data
    Private getDateforTbl As String
    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdatePeriodComboBox()
    End Sub

    Private Sub rangedate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rangedate.SelectedIndexChanged
        UpdatePeriodComboBox()
    End Sub

    Private Sub rangeyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rangeyear.SelectedIndexChanged
        UpdatePeriodComboBox()
    End Sub
    Private Sub dateConverter()
        If String.IsNullOrWhiteSpace(rangeyear.Text) OrElse String.IsNullOrWhiteSpace(rangeyear.Text) Then
            MessageBox.Show("Please select a valid period and year.")
            Exit Sub
        End If
        Dim periodText As String = rangedate.Text.Trim() ' Example: "December 1-15"
        Dim yearText As String = rangeyear.Text.Trim() ' Example: "2024"
        Dim parts() As String = periodText.Split(" "c)


        If parts.Length < 2 Then
            MessageBox.Show("Invalid format. Use 'Month Day-Day' format, e.g., 'December 1-15'.")
            Exit Sub
        End If

        Dim monthName As String = parts(0).Trim() ' "December"
        Dim dayRange() As String = parts(1).Split("-"c) ' {"1", "15"}
        If dayRange.Length < 2 Then
            MessageBox.Show("Invalid day range. Use 'Day-Day' format, e.g., '1-15'.")
            Exit Sub
        End If

        ' Convert month name to numeric month
        Dim monthNumber As Integer
        If Not DateTime.TryParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, Nothing) Then
            MessageBox.Show("Invalid month.")
            Exit Sub
        Else
            monthNumber = DateTime.ParseExact(monthName, "MMMM", Globalization.CultureInfo.InvariantCulture).Month
        End If

        ' Construct the PayPeriod key
        Dim startDate As String = $"{monthNumber}-{dayRange(0).Trim()}-{yearText}"
        Dim endDate As String = $"{monthNumber}-{dayRange(1).Trim()}-{yearText}"
        getDateforTbl = $"{startDate} to {endDate}"
    End Sub
    Private Sub payroll_data_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not IsExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
            End If
        End If
    End Sub
    Private Sub UpdatePeriodComboBox()
        Try
            ' Store the current selection before updating
            Dim currentSelection As String = If(rangedate.SelectedItem IsNot Nothing, rangedate.SelectedItem.ToString(), "")

            ' Temporarily detach event handlers
            RemoveHandler rangedate.SelectedIndexChanged, AddressOf rangedate_SelectedIndexChanged

            Dim selectedYear As Integer
            If rangeyear.SelectedItem Is Nothing OrElse Not Integer.TryParse(rangeyear.SelectedItem.ToString(), selectedYear) Then
                Exit Sub
            End If

            Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1
            If selectedMonth < 1 Or selectedMonth > 12 Then
                Exit Sub
            End If

            Dim daysInMonth As Integer = DateTime.DaysInMonth(selectedYear, selectedMonth)
            Dim monthName As String = New DateTime(selectedYear, selectedMonth, 1).ToString("MMMM")

            ' Clear and repopulate rangedate
            rangedate.Items.Clear()
            rangedate.Items.Add($"{monthName} 1-15")
            If daysInMonth > 15 Then
                rangedate.Items.Add($"{monthName} 16-{daysInMonth}")
            End If

            ' Try to restore previous selection if it exists in the new items
            If Not String.IsNullOrEmpty(currentSelection) AndAlso rangedate.Items.Contains(currentSelection) Then
                rangedate.SelectedItem = currentSelection
            Else
                ' If previous selection isn't available, set default based on current day
                Dim currentDay As Integer = DateTime.Now.Day
                If currentDay > 15 AndAlso rangedate.Items.Count > 1 Then
                    rangedate.SelectedIndex = 1
                Else
                    rangedate.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Reattach event handlers
            AddHandler rangedate.SelectedIndexChanged, AddressOf rangedate_SelectedIndexChanged
        End Try
    End Sub


    Sub loadpayrolldata()
        dateConverter()
        Try
            ' Clear any existing rows in DataGridView
            DGVUserData.Rows.Clear()

            ' Retrieve data from Firebase
            Dim SRRecord = client.Get($"EmployeePayrollDataTbl/PayPeriod/{getDateforTbl}")
            If SRRecord.Body Is Nothing Then
                MessageBox.Show("No data found! Add new employee.", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Deserialize the response into a Dictionary
            Dim employeeData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(SRRecord.Body)
            If employeeData Is Nothing OrElse employeeData.Count = 0 Then
                MessageBox.Show("NO PAYSLIP DATA!", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Add columns to DataGridView if they are not already added
            If DGVUserData.Columns.Count = 0 Then
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "EmployeeID", .HeaderText = "Employee ID", .Name = "EmployeeID"})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "PayOutPeriod", .HeaderText = "Pay Out Period", .Name = "PayOutPeriod"})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "PayslipID", .HeaderText = "Payslip ID", .Name = "PayslipID"})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "TotalDeduction", .HeaderText = "Total Deduction", .Name = "TotalDeduction"})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "TotalHours", .HeaderText = "Total Hours", .Name = "TotalHours"})
                DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "TotalSalary", .HeaderText = "Total Salary", .Name = "TotalSalary"})
                ' Apply any styling methods for the DataGridView
                ApplyDGVUserDataStyling()
            End If

            ' Loop through each employee record and populate the DataGridView
            For Each employeeKey In employeeData.Keys
                Dim employeeDetails As Dictionary(Of String, Object) = Nothing

                Try
                    ' Ensure we're deserializing a dictionary for each employee's details
                    employeeDetails = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(employeeData(employeeKey).ToString())
                Catch jsonEx As Exception
                    MessageBox.Show($"Error deserializing employee data for UID {employeeKey}: {jsonEx.Message}", "JSON Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Continue For
                End Try

                ' Extract values, handling nested fields
                Dim EmployeeID = If(employeeDetails.ContainsKey("EmployeeID"), employeeDetails("EmployeeID").ToString(), "N/A")
                Dim payOutPeriod = If(employeeDetails.ContainsKey("PayOutPeriod"), employeeDetails("PayOutPeriod").ToString(), "N/A")
                Dim payslipID = If(employeeDetails.ContainsKey("PayslipID"), employeeDetails("PayslipID").ToString(), "N/A")
                Dim totalDeduction = If(employeeDetails.ContainsKey("TotalDeduction"), employeeDetails("TotalDeduction").ToString(), "0")
                Dim totalHours = If(employeeDetails.ContainsKey("TotalHours"), employeeDetails("TotalHours").ToString(), "0")
                Dim totalSalary = If(employeeDetails.ContainsKey("TotalSalary"), employeeDetails("TotalSalary").ToString(), "0")

                ' Add a new row to the DataGridView
                DGVUserData.Rows.Add(
                employeeKey, ' UID
                EmployeeID,
                payOutPeriod,
                payslipID,
                totalDeduction,
                totalHours,
                totalSalary
            )
            Next

            ' Disable the row adding functionality in DataGridView if needed
            DGVUserData.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show($"Error loading payroll data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExportToExcelClosedXML()
        Try
            Using workbook As New XLWorkbook()
                Dim worksheet = workbook.Worksheets.Add("Sheet1")

                ' Export headers
                For j As Integer = 0 To DGVUserData.ColumnCount - 1
                    worksheet.Cell(1, j + 1).Value = DGVUserData.Columns(j).HeaderText
                Next

                ' Export data
                For i As Integer = 0 To DGVUserData.RowCount - 1
                    For j As Integer = 0 To DGVUserData.ColumnCount - 1
                        worksheet.Cell(i + 2, j + 1).Value = If(DGVUserData.Rows(i).Cells(j).Value IsNot Nothing,
                                                              DGVUserData.Rows(i).Cells(j).Value.ToString(),
                                                              "")
                    Next
                Next

                ' Auto-fit columns
                worksheet.Columns().AdjustToContents()

                ' Show save dialog
                Dim saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                saveDialog.FilterIndex = 1
                saveDialog.RestoreDirectory = True
                saveDialog.FileName = "Payroll Data for " + rangedate.Text + ", " + rangeyear.Text

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(saveDialog.FileName)
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


    Private Sub ApplyDGVUserDataStyling()
        ' Set overall grid appearance
        With DGVUserData
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowTemplate.Height = 30
            .ColumnHeadersHeight = 40
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
        End With

        ' Style headers
        With DGVUserData.ColumnHeadersDefaultCellStyle
            .BackColor = Color.DarkSlateGray
            .ForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' Style rows
        With DGVUserData.RowsDefaultCellStyle
            .BackColor = Color.LightGray
            .ForeColor = Color.Black
        End With

        ' Style alternating rows
        With DGVUserData.AlternatingRowsDefaultCellStyle
            .BackColor = Color.WhiteSmoke
        End With



    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub


    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Me.Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        loadpayrolldata()
    End Sub

    Private Sub payroll_data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = FirebaseModule.GetFirebaseClient()
            If client Is Nothing Then
                MessageBox.Show("Failed to connect to Firebase. Please check your configuration.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Initialize ComboBox1 (Months) and ComboBox2 (Years)
            ComboBox1.Items.Clear()
            Dim months As String() = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
            ComboBox1.Items.AddRange(months)
            ComboBox1.SelectedIndex = DateTime.Now.Month - 1 ' Set current month as default

            rangeyear.Items.Clear()
            For year As Integer = 2000 To 2030
                rangeyear.Items.Add(year.ToString())
            Next
            rangeyear.SelectedIndex = rangeyear.Items.IndexOf(DateTime.Now.Year.ToString()) ' Set current year as default
            loadpayrolldata()
            ' Initialize ComboBox3 (Periods)
            UpdatePeriodComboBox()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Main_Dashboard.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        List_of_Employees.Show()
        Me.Hide()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        payroll_dashboard.Show()
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

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        reports.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        ExportToExcelClosedXML()
    End Sub
End Class