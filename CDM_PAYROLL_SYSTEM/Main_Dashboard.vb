Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports System.Globalization

Public Class Main_Dashboard
    Public adminID As String
    Public Fingerprint As String
    Public getName As String
    Public Permissions As String
    Public Role As String
    Public RoleID As String
    Dim former As New Form
    Private Sub Label8_Click(sender As Object, e As EventArgs)
        Hide()
        List_of_Employees.Show()

    End Sub
    Private Sub Main_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetEmployeesLastMonth()
        Label5.Text = "Admin ID: " + adminID
        Label9.Text = "Fingerprint: " + Fingerprint
        Label7.Text = "Role: " + Role
        Label6.Text = "Name: " + getName
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
        RFID_Based_Attendance.Show()
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
        payroll.Show()
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
        RFID_Based_Attendance.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
        Admin_Info.Show()
        Me.Hide()
    End Sub
End Class