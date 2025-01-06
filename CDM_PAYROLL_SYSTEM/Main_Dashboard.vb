Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Globalization

Public Class Main_Dashboard
    Public adminID As String
    Public Fingerprint As String
    Public getName As String
    Public Permissions As String
    Public Role As String
    Public RoleID As String
    Dim former As New Form
    Public username As String
    Private range As String
    Private payday As String
    Private daysremaining As Integer
    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient
    Sub GetHalfMonthRange()
        Dim today As DateTime = DateTime.Now
        Dim year As Integer = today.Year
        Dim month As Integer = today.Month

        ' Get the total days in the current month
        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, month)

        ' Calculate the midpoint of the month (integer division ensures correct midpoint)
        Dim halfOfMonth As Integer = daysInMonth \ 2

        ' Define the start and midpoint dates
        Dim startDate As DateTime = New DateTime(year, month, 1)
        Dim midDate As DateTime = New DateTime(year, month, halfOfMonth)
        daysremaining = (midDate - DateTime.Now).Days
        payday = midDate.ToString("MMMM d, yyyy")
        ' Format the result
        range = $"{startDate.Month}-{startDate.Day}-{startDate.Year} to {midDate.Month}-{midDate.Day}-{midDate.Year}"
    End Sub
    Sub recentPayroll()
        Try
            ' Get the JSON data from Firebase (the result from client.Get)
            Dim jsonData = client.Get($"ReportTbl/payslip")

            ' Check if the data is not null or empty
            If jsonData IsNot Nothing AndAlso jsonData.Body IsNot Nothing Then

                ' Deserialize the JSON data into a JObject
                Dim reportData As JObject = JObject.Parse(jsonData.Body.ToString())

                ' Check if we have any data
                If reportData IsNot Nothing AndAlso reportData.HasValues Then
                    ' Create a list to store messages
                    Dim messages As New List(Of String)()

                    ' Iterate through the JObject to extract the message for each entry
                    For Each entry In reportData.Properties()
                        ' Each entry is a JObject with "Date" and "message"
                        Dim entryData As JObject = CType(entry.Value, JObject)

                        ' Check if "message" exists and add it to the list
                        If entryData.ContainsKey("message") Then
                            messages.Add(entryData("message").ToString())
                        End If
                    Next

                    ' Display the messages in the labels (up to four)
                    If messages.Count > 0 Then
                        Label18.Text = messages(0)
                        Label18.Visible = True
                    Else
                        Label18.Visible = False
                    End If

                    If messages.Count > 1 Then
                        Label19.Text = messages(1)
                        Label19.Visible = True
                    Else
                        Label19.Visible = False
                    End If

                    If messages.Count > 2 Then
                        Label22.Text = messages(2)
                        Label22.Visible = True
                    Else
                        Label22.Visible = False
                    End If

                    If messages.Count > 3 Then
                        Label21.Text = messages(3)
                        Label21.Visible = True
                    Else
                        Label21.Visible = False
                    End If

                Else
                    MessageBox.Show("No messages found in the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("No data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle any errors
            MessageBox.Show($"Error retrieving or processing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Sub CalculateTotalSalary()
        Dim jsonData = client.Get($"EmployeePayrollDataTbl/PayPeriod/{range}")

        ' Deserialize the JSON data to a dictionary
        Dim employeeData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonData.Body)

        ' Initialize the total salary sum
        Dim totalSalarySum As Decimal = 0

        ' Loop through each employee's data and sum up the TotalSalary
        For Each employee In employeeData.Values
            ' Deserialize employee data to a dictionary
            Dim employeeDetails As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(employee.ToString())

            ' Get the TotalSalary and add to the sum (ensure it's converted to Decimal)
            Dim totalSalary As Decimal
            If Decimal.TryParse(employeeDetails("TotalSalary"), totalSalary) Then
                totalSalarySum += totalSalary

                Label11.Text = "₱" & totalSalarySum
            End If
        Next
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs)
        Hide()
        List_of_Employees.Show()

    End Sub
    Private Sub Main_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetEmployeesLastMonth()
        GetHalfMonthRange()
        CalculateTotalSalary()
        recentPayroll()

        Label17.Text = daysremaining & " days from now"
        Label16.Text = payday
        Label5.Text = username
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)
        Employee_Dashboard.Show()
        Hide()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        time_records_dashboard.Show()
        Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        List_of_Employees.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Employee_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)
        Hide()
        Employee_Dashboard.Show()

    End Sub

    Public Async Sub GetEmployeesLastMonth()
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

        Try
            ' Retrieve all employee data from EmployeeDataTbl
            Dim response As FireSharp.Response.FirebaseResponse = Await client.GetAsync("EmployeeDataTbl")

            ' Deserialize the response into a dictionary
            Dim employees As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response.Body)

            ' Count the number of employees
            Dim employeeCount As Integer = If(employees IsNot Nothing, employees.Count, 0)

            ' Display the count in Label3
            Label3.Text = employeeCount.ToString()

        Catch ex As Exception
            MessageBox.Show("Error fetching employee count: " & ex.Message)
        End Try
    End Sub

    Private Sub Main_Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to True
        If Not IsExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                IsExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        reports.Show()
        Me.Hide()
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)
        Hide()
        reports.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        time_records_dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs)
        Admin_Info.Show
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        calculations.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Admin_Info.Show()
        Me.Hide()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            ' Optionally notify the user
            MessageBox.Show("You have been logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Redirect to Login Form
            Dim loginForm As New ADMIN_LOGIN()
            loginForm.Show()

            ' Close current form
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class