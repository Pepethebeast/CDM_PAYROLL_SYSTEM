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
Imports FirebaseAdmin
Imports System.Reflection
Imports FirebaseAdmin.Auth
Imports Google.Apis.Auth.OAuth2

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


    Sub loademployeedata(Optional keyword As String = "")

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
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "employeeID", .HeaderText = "Employee ID", .Name = "employeeID"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "firstName", .HeaderText = "First Name", .Name = "firstName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "lastName", .HeaderText = "Last Name", .Name = "lastName"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "password", .HeaderText = "Password", .Name = "password"})
            DGVuserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "rfidTag", .HeaderText = "RFID Tag", .Name = "rfidTag"})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Info", .Name = "editButton", .Text = "View", .UseColumnTextForButtonValue = True})
            DGVuserData.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "RFID", .Name = "rfid_register.dgv", .Text = "Register", .UseColumnTextForButtonValue = True})


            ' Set DataGridView styles
            DGVuserData.EnableHeadersVisualStyles = False
            DGVuserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
            DGVuserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVuserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVuserData.ColumnHeadersHeight = 40 ' Increase header height
            DGVuserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVuserData.DefaultCellStyle.Font = New Font("Roboto", 12)
            DGVuserData.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", 8, FontStyle.Regular)
            DGVuserData.RowTemplate.Height = 40
            DGVuserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGVuserData.BorderStyle = BorderStyle.None
            DGVuserData.BackgroundColor = Color.White
            DGVuserData.GridColor = Color.White
            DGVuserData.RowHeadersVisible = False
            DGVuserData.EnableHeadersVisualStyles = False
            DGVuserData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            DGVuserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVuserData.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            DGVuserData.DefaultCellStyle.SelectionForeColor = Color.Black
            DGVuserData.DataSource = employeelist
            DGVuserData.AllowUserToAddRows = False


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
        List_of_Employees.Show()
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

    Private Async Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        If DGVuserData.SelectedRows.Count = 1 Then
            ' Ask for confirmation before deleting
            Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If result = DialogResult.Yes Then
                ' Get the selected row (index 0, since there is only one selected row)
                Dim selectedRow As DataGridViewRow = DGVuserData.SelectedRows(0)
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
                Dim employeeID As String = selectedRow.Cells("employeeID").Value.ToString()

                ' Delete the data from Firebase (based on UID)
                Dim numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
                client.Delete("usersTbl/" & selectedUID)
                client.Delete("employeeDataTbl/" & selectedUID)
                client.Set("NotificationTbl/" & selectedUID + "/", "Your account has been deleted")
                client.Set("ReportTbl/account/" & numericGuid + "/", "Account deletion for employee ID: " + employeeID)

                ' Initialize FirebaseApp with your service account credentials
                Dim app As FirebaseApp = FirebaseApp.Create(New AppOptions() With {
            .Credential = GoogleCredential.FromFile("C:\Users\Zedrick\Documents\Visual Basic\CDM_PAYROLL_SYSTEM\CDM_PAYROLL_SYSTEM\cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")
        })

                ' Get FirebaseAuth instance using the FirebaseApp
                Dim auth As FirebaseAuth = FirebaseAuth.DefaultInstance

                ' Use Await for the async call
                Await auth.DeleteUserAsync(selectedUID)

                MessageBox.Show("User deleted successfully.")
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
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

                Dim userData As String = selectedRow.Cells("employeeID").Value.ToString() ' Replace "UserDataColumnName" with the actual column name
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

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        Dim keyword As String = TextBox5.Text.Trim()
        loademployeedata(keyword)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ' Check if data is already loaded
        If DGVuserData.DataSource Is Nothing Then Return

        ' Get the search text and remove leading/trailing spaces
        Dim searchText As String = TextBox5.Text.Trim().ToLower()

        ' Cast the DataSource back to a list of PersonalData
        Dim employeeList As List(Of PersonalData) = TryCast(DGVuserData.DataSource, List(Of PersonalData))
        If employeeList Is Nothing Then Return

        ' Check if searchText is empty
        If String.IsNullOrEmpty(searchText) Then
            ' If empty, show all records
            DGVuserData.DataSource = Nothing
            DGVuserData.DataSource = employeeList
        Else
            ' If not empty, filter the data based on search text
            Dim filteredList = employeeList.Where(Function(emp) _
            emp.employeeID.ToLower().Contains(searchText) OrElse
            emp.email.ToLower().Contains(searchText) OrElse
            emp.firstName.ToLower().Contains(searchText)
        ).ToList()

            ' Update the DataGridView with the filtered list
            DGVuserData.DataSource = Nothing
            DGVuserData.DataSource = filteredList
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub
End Class
