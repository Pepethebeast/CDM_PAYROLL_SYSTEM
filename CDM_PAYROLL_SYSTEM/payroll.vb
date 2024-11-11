Imports Firebase.Database
Imports FireSharp.Interfaces
Imports Newtonsoft.Json

Public Class payroll

    Private client As IFirebaseClient = FirebaseModule.GetFirebaseClient
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Close()
        Main_Dashboard.ShowDialog()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Employee_Dashboard.Show()
        Me.Close()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
        RFID_Based_Attendance.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        acc.Show()
        Me.Close()
    End Sub
    Sub LoadEmployeeData()
        Try
            Dim SRRecord = client.Get("EmployeeDataTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(SRRecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("No data found! add new employee", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            For Each kvp As KeyValuePair(Of String, PersonalData) In employees
                kvp.Value.UID = kvp.Key
            Next

            Dim employeeList As List(Of PersonalData) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.employeeID)).ToList()
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            DataGridView1.AutoGenerateColumns = False


            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "EmployeeID", .HeaderText = "Employee ID", .Name = "EmployeeID"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "name", .HeaderText = "Name", .Name = "name"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "age", .HeaderText = "Age", .Name = "age", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_of_birth", .HeaderText = "Date Of Birth", .Name = "date_of_birth", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "position", .HeaderText = "Position", .Name = "position"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "contact", .HeaderText = "Contact", .Name = "contact", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email Address", .Name = "email"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "designation", .HeaderText = "Designation", .Name = "designation"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "description", .HeaderText = "Description", .Name = "description"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "no_of_units", .HeaderText = "No. of Units", .Name = "no_of_units"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "pay status", .HeaderText = "Payment Status", .Name = "pay_status"})

            ApplyDataGridViewStyling()
            DataGridView1.DataSource = employeeList
            DataGridView1.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ApplyDataGridViewStyling()
        ' Set header style
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black

        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersHeight = 30 ' Increase header height

        ' Set row style
        DataGridView1.RowTemplate.Height = 50 ' Set row height to 70 pixels
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Set border style and color
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridView1.GridColor = Color.Black ' This sets the color of the grid lines (borders between cells)

        ' Other general styling
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Alternating row colors for better readability


        ' Apply styling to all columns
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.DefaultCellStyle.Font = New Font("Arial", 10)
        Next

        ' Specific styling for the image column if it exists
        If DataGridView1.Columns.Contains("image") Then
            DataGridView1.Columns("image").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        ' Ensure all rows are set to the new height
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.Height = 30
        Next

        ' Refresh the DataGridView to apply changes
        DataGridView1.Refresh()

    End Sub
    Private Sub payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = Date.Now
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        LoadEmployeeData()
        ApplyDataGridViewStyling()
        ComboBox1.Items.Clear()

        ' Add months
        Dim months As String() = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
        ComboBox1.Items.AddRange(months)

        ' Add years from 2000 to 2030
        For year As Integer = 2000 To 2030
            ComboBox2.Items.Add(year.ToString())
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the selected row (assuming single row selection mode)
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Retrieve data from the selected row
            Dim uid As String = selectedRow.Cells("UID").Value.ToString()
            Dim userData As String = selectedRow.Cells("EmployeeID").Value.ToString()
            Dim email_received As String = selectedRow.Cells("email").Value.ToString()
            Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
            Dim name_received As String = selectedRow.Cells("name").Value.ToString()
            Dim designation As String = selectedRow.Cells("designation").Value.ToString()
            Dim description As String = selectedRow.Cells("description").Value.ToString()
            Dim no_of_units As String = selectedRow.Cells("no_of_units").Value.ToString()
            Dim position As String = selectedRow.Cells("position").Value.ToString()

            ' Open the add_basicsalary form and pass data
            Dim add_basicsalary As New basic_salary
            add_basicsalary.designation = designation
            add_basicsalary.description = description
            add_basicsalary.no_ofUnits = no_of_units
            add_basicsalary.position = position
            add_basicsalary.received_name = name_received
            add_basicsalary.add_employee_id = userData
            add_basicsalary.received_email = email_received
            add_basicsalary.user_uid = selectedUID
            add_basicsalary.Show()
        Else
            ' Show a message if no row is selected
            MessageBox.Show("Please select a row first.")
        End If
    End Sub
End Class