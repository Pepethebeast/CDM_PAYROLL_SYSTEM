Imports System.Data
Imports System.Collections.Generic
Imports FireSharp.Response
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.IO
Imports System.Net.Http
Imports System.Security.Cryptography
Imports Firebase.Auth.Providers
Imports System.Threading.Tasks
Imports System
Imports System.Windows.Forms
Imports System.Diagnostics
Public Class acc

    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()
    Private Sub acc_load(sender As Object, e As EventArgs) Handles MyBase.Load
        loademployeedata()
        'TextBox4.Text = "Scan your rfid_tag"
        DGVuserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub
    Private Sub acc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    ' load users from firebase into datagridview

    Public Async Function GetAllUserUIDs() As Task(Of List(Of String))
        Dim uids As New List(Of String)

        Try
            ' Get data from usersTbl
            Dim response As FirebaseResponse = Await client.GetAsync("usersTbl")
            Dim data As JObject = JObject.Parse(response.Body)

            ' Loop through each UID in usersTbl
            For Each item In data.Properties()
                uids.Add(item.Name)  ' Add each UID to the list
            Next
        Catch ex As Exception
            MessageBox.Show("Error retrieving UIDs: " & ex.Message)
        End Try

        Return uids
    End Function

    Private Sub ApplyDataGridViewStyling()
        ' Set header style
        DGVuserData.EnableHeadersVisualStyles = False
        DGVuserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
        DGVuserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DGVuserData.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        DGVuserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVuserData.ColumnHeadersHeight = 30 ' Increase header height

        ' Set row style
        DGVuserData.RowTemplate.Height = 10 ' Set row height to 70 pixels
        DGVuserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Set border style and color
        DGVuserData.BorderStyle = BorderStyle.Fixed3D
        DGVuserData.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DGVuserData.GridColor = Color.Black ' This sets the color of the grid lines (borders between cells)

        ' Other general styling
        DGVuserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVuserData.BackgroundColor = Color.White
        DGVuserData.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen
        DGVuserData.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Alternating row colors for better readability
        DGVuserData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)

        ' Apply styling to all columns
        For Each column As DataGridViewColumn In DGVuserData.Columns
            column.DefaultCellStyle.Font = New Font("Arial", 10)
        Next

        ' Specific styling for the image column if it exists
        If DGVuserData.Columns.Contains("image") Then
            DGVuserData.Columns("image").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        ' Ensure all rows are set to the new height
        For Each row As DataGridViewRow In DGVuserData.Rows
            row.Height = 30
        Next

        ' Refresh the DataGridView to apply changes
        DGVuserData.Refresh()

    End Sub
    Sub loademployeedata()

        Try
            Dim srrecord = client.Get("usersTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(srrecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("No employee data! Please add an employee", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update each PersonalData object to include the UID
            For Each kvp As KeyValuePair(Of String, PersonalData) In employees
                kvp.Value.UID = kvp.Key
            Next

            ' Create a list of employees with UID included
            Dim employeelist As List(Of PersonalData) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.employeeID)).ToList()

            ' Clear and set up DataGridView columns
            DGVuserData.DataSource = Nothing
            DGVuserData.Columns.Clear()
            DGVuserData.AutoGenerateColumns = False

            ' Add columns to DataGridView, including UID
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "employeeID", .HeaderText = "Employee ID", .Name = "employee_id"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email Address", .Name = "email"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "firstName", .HeaderText = "First Name", .Name = "firstName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "lastName", .HeaderText = "Last Name", .Name = "lastName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "password", .HeaderText = "Password", .Name = "password"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "rfidTag", .HeaderText = "RFID Tag", .Name = "rfidTag"})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Info", .Name = "editButton", .Text = "View", .UseColumnTextForButtonValue = True})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "RFID", .Name = "rfid_register.dgv", .Text = "Register", .UseColumnTextForButtonValue = True})


            ' Set DataGridView styles
            DGVuserData.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            DGVuserData.DefaultCellStyle.BackColor = Color.White
            DGVuserData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
            DGVuserData.DefaultCellStyle.SelectionForeColor = Color.Black
            DGVuserData.DataSource = employeelist
            DGVuserData.AllowUserToAddRows = False
            DGVuserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ApplyDataGridViewStyling()
        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' event handlers
    Private Sub label1_click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub label2_click(sender As Object, e As EventArgs) Handles Label2.Click
        Employee_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub label5_click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub iconbutton1_click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub iconbutton2_click(sender As Object, e As EventArgs) Handles IconButton2.Click
        loademployeedata()
        'TextBox4.Clear()

        'TextBox4.Text = "Scan your rfid_tag"
    End Sub

    'Public Function verifypassword(plainpassword As String, hashedpassword As String) As Boolean
    '    Dim hashedinputpassword As String = TextBox4.Text(plainpassword)
    '    Return hashedinputpassword.Equals(hashedpassword)
    'End Function

    Private Function safegetstring(value As Object) As String
        ' returns an empty string if the value is dbnull or null
        Return If(value Is Nothing OrElse IsDBNull(value), String.Empty, value.ToString())
    End Function

    Private Sub iconbutton4_click(sender As Object, e As EventArgs) Handles IconButton4.Click

    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Textbox4_Enter(sender As Object, e As EventArgs)
        'TextBox4.Text = ""
    End Sub

    Private Sub DGVuserData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVuserData.CellContentClick
        If e.RowIndex >= 0 AndAlso (e.ColumnIndex = DGVuserData.Columns("rfid_register.dgv").Index OrElse e.ColumnIndex = DGVuserData.Columns("editButton").Index) Then
            ' Retrieve the data from the clicked row
            Dim uid As String = DGVuserData.Rows(e.RowIndex).Cells("UID").Value.ToString()
            Dim selectedRow As DataGridViewRow = DGVuserData.Rows(e.RowIndex)

            If e.ColumnIndex = DGVuserData.Columns("rfid_register.dgv").Index Then
                ' RFID Register button clicked
                Dim rfidForm As New register_rfid()
                rfidForm.UserUID = uid ' Set the UID property
                rfidForm.Show()

            ElseIf e.ColumnIndex = DGVuserData.Columns("editButton").Index Then

                Dim userData As String = selectedRow.Cells("employee_id").Value.ToString() ' Replace "UserDataColumnName" with the actual column name
                Dim email_received As String = selectedRow.Cells("email").Value.ToString()
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
                Dim name_received As String = selectedRow.Cells("firstName").Value.ToString() + " " + selectedRow.Cells("lastName").Value.ToString()
                Dim add_employee_info As New add_employee
                add_employee_info.received_name = name_received
                add_employee_info.add_employee_id = userData
                add_employee_info.received_email = email_received
                add_employee_info.user_uid = selectedUID
                add_employee_info.Show()
            End If


        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        Hide()
        register_rfid.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim selectedRow = DGVuserData.CurrentRow
        If selectedRow IsNot Nothing Then
            Dim selectedUID = selectedRow.Cells("UID").Value.ToString ' Get the UID from the selected row

            ' Pass the UID to register_rfid
            Dim rfidForm As New register_rfid
            rfidForm.UserUID = selectedUID ' Set the UID property
            rfidForm.Show()
            ' Optionally hide the current form
        Else
            MessageBox.Show("Please select a row to continue.", "No row selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        RFID_Based_Attendance.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub
End Class
