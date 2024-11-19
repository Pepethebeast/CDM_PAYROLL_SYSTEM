Imports Firebase.Database
Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports FireSharp.Config
Imports FireSharp.Response
Imports System.IO

Public Class payroll

    Private client As IFirebaseClient
    Private Sub payroll_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Main_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        List_of_Employees.Show()
        Me.Hide()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        RFID_Based_Attendance.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Employee_Dashboard.Show()
        Me.Hide()
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
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "designation", .HeaderText = "Designation", .Name = "designation"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "description", .HeaderText = "Description", .Name = "description"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "no_of_units", .HeaderText = "No. of Units", .Name = "no_of_units"})
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_hired", .HeaderText = "Date Hired", .Name = "Date_hired", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "image", .HeaderText = "Image", .Name = "image", .Visible = False})
            DataGridView1.Columns.Add(New DataGridViewButtonColumn With {.HeaderText = "Payroll", .Name = "payroll", .Text = "Process", .UseColumnTextForButtonValue = True})


            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersHeight = 40 ' Increase header height
            DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.DefaultCellStyle.Font = New Font("Roboto", 12)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", 8, FontStyle.Regular)
            DataGridView1.RowTemplate.Height = 50
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.BorderStyle = BorderStyle.None
            DataGridView1.BackgroundColor = Color.White
            DataGridView1.GridColor = Color.White
            DataGridView1.RowHeadersVisible = False
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
            DataGridView1.DataSource = employeeList
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.ReadOnly = True
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Handle the month change event
        UpdatePeriodComboBox()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Handle the year change event
        UpdatePeriodComboBox()
    End Sub

    Private Sub UpdatePeriodComboBox()
        Dim selectedYear As Integer
        If ComboBox2.SelectedItem Is Nothing OrElse Not Integer.TryParse(ComboBox2.SelectedItem.ToString(), selectedYear) Then
            Return
        End If

        ' Get selected month
        Dim selectedMonth As Integer = ComboBox1.SelectedIndex + 1 ' ComboBox1 indexes months from 0 to 11, so we add 1
        If selectedMonth < 1 Or selectedMonth > 12 Then
            Return
        End If

        ' Get number of days in the selected month
        Dim daysInMonth As Integer = DateTime.DaysInMonth(selectedYear, selectedMonth)
        Dim monthName As String = New DateTime(selectedYear, selectedMonth, 1).ToString("MMMM")

        ' Clear ComboBox3 and add the period items
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add($"{monthName} 1-15") ' Always add the 1-15 period
        If daysInMonth > 15 Then
            ComboBox3.Items.Add($"{monthName} 16-{daysInMonth}") ' Add the second period
        End If

        ' Automatically set the selected item based on the current day
        Dim currentDay As Integer = DateTime.Now.Day
        If currentDay > 16 Then
            ComboBox3.SelectedIndex = ComboBox3.Items.IndexOf($"{monthName} 16-{daysInMonth}")
        Else
            ComboBox3.SelectedIndex = ComboBox3.Items.IndexOf($"{monthName} 1-15")
        End If
    End Sub

    Private Sub payroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ComboBox2.Items.Clear()
            For year As Integer = 2000 To 2030
                ComboBox2.Items.Add(year.ToString())
            Next
            ComboBox2.SelectedIndex = ComboBox2.Items.IndexOf(DateTime.Now.Year.ToString()) ' Set current year as default
            LoadEmployeeData()
            ' Initialize ComboBox3 (Periods)
            UpdatePeriodComboBox()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function Base64ToImage(base64String As String) As Image
        ' Convert Base64 String to byte[]  
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image  
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = System.Drawing.Image.FromStream(ms, True)
        Return image__1
    End Function
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("payroll").Index Then
            ' Retrieve the data from the clicked row
            Dim uid As String = DataGridView1.Rows(e.RowIndex).Cells("UID").Value.ToString()
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            Dim name_received As String = selectedRow.Cells("Name").Value.ToString()
            Dim userData As String = selectedRow.Cells("EmployeeID").Value.ToString() ' Replace "UserDataColumnName" with the actual column name
            Dim email_received As String = selectedRow.Cells("email").Value.ToString()
            Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()
            Dim description As String = selectedRow.Cells("description").Value.ToString() ' Replace "UserDataColumnName" with the actual column name
            Dim designation As String = selectedRow.Cells("designation").Value.ToString()
            Dim position As String = selectedRow.Cells("position").Value.ToString()
            Dim no_of_units As String = selectedRow.Cells("no_of_units").Value.ToString()
            Dim date_hired As String = selectedRow.Cells("date_hired").Value.ToString()
            Dim pay_period = ComboBox3.Text + ComboBox2.Text

            If selectedRow.Cells("image").Value IsNot Nothing Then
                Dim base64String As String = selectedRow.Cells("image").Value.ToString()
                PictureBox1.Image = Base64ToImage(base64String)
                Dim add_employee_info As New payslip
                add_employee_info.date_hired = date_hired
                add_employee_info.no_ofUnits = no_of_units
                add_employee_info.position123 = position
                add_employee_info.description = description
                add_employee_info.designation = designation
                add_employee_info.received_name = name_received
                add_employee_info.add_employee_id = userData
                add_employee_info.received_email = email_received
                add_employee_info.user_uid = selectedUID
                add_employee_info.get_pey_period_hehe = pay_period

                add_employee_info.SetImage(PictureBox1.Image)
                add_employee_info.Show()
                Me.Hide()
            End If


        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Check if data is already loaded
        If DataGridView1.DataSource Is Nothing Then Return

        ' Get the search text and remove leading/trailing spaces
        Dim searchText As String = TextBox1.Text.Trim().ToLower()

        ' Cast the DataSource back to a list of PersonalData
        Dim employeeList As List(Of PersonalData) = TryCast(DataGridView1.DataSource, List(Of PersonalData))
        If employeeList Is Nothing Then Return

        ' Check if searchText is empty
        If String.IsNullOrEmpty(searchText) Then
            ' If empty, show all records
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = employeeList
        Else
            ' If not empty, filter the data based on search text
            Dim filteredList = employeeList.Where(Function(emp) _
            emp.employeeID.ToLower().Contains(searchText) OrElse
            emp.name.ToLower().Contains(searchText) OrElse
            emp.position.ToLower().Contains(searchText)
        ).ToList()

            ' Update the DataGridView with the filtered list
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = filteredList
        End If
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub
End Class