Imports Firebase.Database
Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports FireSharp.Config
Imports FireSharp.Response
Imports System.IO
Imports CDM_PAYROLL_SYSTEM.PersonalData
Imports DocumentFormat.OpenXml.Drawing

Public Class payroll

    Private client As IFirebaseClient
    Private getDateforTbl As String

    Private Sub dateConverter()
        If String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse String.IsNullOrWhiteSpace(ComboBox3.Text) Then
            MessageBox.Show("Please select a valid period and year.")
            Exit Sub
        End If
        Dim periodText As String = ComboBox3.Text.Trim() ' Example: "December 1-15"
        Dim yearText As String = ComboBox2.Text.Trim() ' Example: "2024"
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

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        time_records_dashboard.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Employee_Dashboard.Show()
        Me.Hide()
    End Sub
    Sub LoadEmployeeData()
        dateConverter()

        Try
            ' Clear existing rows in DataGridView
            DataGridView1.Rows.Clear()
            ' Retrieve employeeDataTbl from Firebase
            Dim employeeDataResponse = client.Get("EmployeeDataTbl")
            Dim employeeData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(employeeDataResponse.Body)

            ' Retrieve employeepayrolldataTbl from Firebase for the specified PayPeriod
            Dim payrollDataResponse = client.Get($"EmployeePayrollDataTbl/PayPeriod/{getDateforTbl}")
            Dim payrollData = If(payrollDataResponse.Body IsNot Nothing AndAlso payrollDataResponse.Body <> "null", JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(payrollDataResponse.Body), New Dictionary(Of String, Object))
            ' Ensure columns are added before loading data (if not already done)

            ' Iterate through EmployeeDataTbl
            For Each employeeKey In employeeData.Keys
                Dim employeeDetails = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(employeeData(employeeKey).ToString())
                Dim isProcessed = payrollData.ContainsKey(employeeKey)

                If DataGridView1.Columns.Count = 0 Then
                    ApplyDataGridViewStyling()
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
                    DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_hired", .HeaderText = "Date Hired", .Name = "date_hired", .Visible = False})
                    DataGridView1.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "image", .HeaderText = "Image", .Name = "image", .Visible = False})

                    DataGridView1.Columns.Add(New DataGridViewButtonColumn With {
        .HeaderText = "Payroll",
        .Name = "payroll",
        .Text = String.Empty, ' Default empty text
        .UseColumnTextForButtonValue = False ' Allow per-cell text customization
    })
                    ApplyDataGridViewStyling()
                End If

                Dim rowIndex As Integer
                rowIndex = DataGridView1.Rows.Add(
                        employeeKey, ' UID
                        employeeDetails("employeeID").ToString(),
                        employeeDetails("name").ToString(),
                        employeeDetails("age").ToString(),
                        employeeDetails("date_of_birth").ToString(),
                        employeeDetails("position").ToString(),
                        employeeDetails("contact").ToString(),
                        employeeDetails("email").ToString(),
                        employeeDetails("designation").ToString(),
                        employeeDetails("description").ToString(),
                        employeeDetails("no_of_units").ToString(),
                        employeeDetails("date_hired").ToString(),
                        employeeDetails("image").ToString()
                    )
                Dim buttonCell = CType(DataGridView1.Rows(rowIndex).Cells("payroll"), DataGridViewButtonCell)
                If isProcessed Then
                    buttonCell.Value = "Done" ' Button text for processed employees
                    buttonCell.Style.BackColor = Color.Gray ' Gray background for visual indicator
                    buttonCell.Tag = "disabled" ' Use a tag to identify disabled buttons
                Else
                    buttonCell.Value = "Process" ' Button text for unprocessed employees
                    buttonCell.Style.BackColor = Color.LightGreen ' Default background for unprocessed
                    buttonCell.Tag = "enabled" ' Use a tag to identify enabled buttons
                End If


            Next

            ' Adjust DataGridView settings
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading employee data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub ApplyDataGridViewStyling()
        ' Set overall grid appearance
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Font = New Font("Arial", 10)
            .RowTemplate.Height = 35
            .ColumnHeadersHeight = 40
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
        End With

        ' Style headers
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.DarkSlateGray
            .ForeColor = Color.White
            .Font = New Font("Arial", 12, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        ' Style rows
        With DataGridView1.RowsDefaultCellStyle
            .BackColor = Color.LightGray
            .ForeColor = Color.Black
        End With

        ' Style alternating rows
        With DataGridView1.AlternatingRowsDefaultCellStyle
            .BackColor = Color.WhiteSmoke
        End With
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
    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "payroll" Then
            e.Handled = True ' Prevent default painting
            e.PaintBackground(e.ClipBounds, True) ' Paint the cell background

            ' Get the button's state from the Tag
            Dim buttonCell = CType(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewButtonCell)
            Dim buttonState As String = buttonCell.Tag?.ToString()

            ' Set colors based on the state
            Dim backColor As Color
            Dim textColor As Color

            If buttonState = "disabled" Then
                backColor = Color.DarkSeaGreen
                textColor = Color.Black
            Else
                backColor = Color.Gray
                textColor = Color.Black
            End If

            ' Draw the button background
            Using brush As New SolidBrush(backColor)
                e.Graphics.FillRectangle(brush, e.CellBounds)
            End Using

            ' Draw the button text
            TextRenderer.DrawText(e.Graphics, buttonCell.Value.ToString(), e.CellStyle.Font, e.CellBounds, textColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.WordBreak)
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        dateConverter()
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "payroll" Then
            Dim buttonCell = CType(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewButtonCell)

            ' Check the button's state using the Tag property
            If buttonCell.Tag.ToString() = "disabled" Then
                ' Ignore click if the button is disabled
                MessageBox.Show("This employee's payroll has already been processed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        ' Ensure the event is triggered for the "payroll" column and a valid row
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("payroll").Index Then
            Try
                ' Retrieve data from the selected row
                Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim uid As String = selectedRow.Cells("UID").Value?.ToString()
                Dim name_received As String = selectedRow.Cells("Name").Value?.ToString()
                Dim userData As String = selectedRow.Cells("EmployeeID").Value?.ToString()
                Dim email_received As String = selectedRow.Cells("email").Value?.ToString()
                Dim description As String = selectedRow.Cells("description").Value?.ToString()
                Dim designation As String = selectedRow.Cells("designation").Value?.ToString()
                Dim position As String = selectedRow.Cells("position").Value?.ToString()
                Dim no_of_units As String = selectedRow.Cells("no_of_units").Value?.ToString()
                Dim date_hired As String = selectedRow.Cells("date_hired").Value?.ToString()
                Dim pay_period As String = ComboBox3.Text + ", " + ComboBox2.Text

                ' Check if the "image" cell has data and load it into the PictureBox
                If selectedRow.Cells("image").Value IsNot Nothing Then
                    Dim base64String As String = selectedRow.Cells("image").Value.ToString()
                    PictureBox1.Image = Base64ToImage(base64String)

                    ' Create a new instance of the payslip form
                    Dim add_employee_info As New payslip With {
                    .date_hired = date_hired,
                    .no_ofUnits = no_of_units,
                    .position123 = position,
                    .description = description,
                    .designation = designation,
                    .received_name = name_received,
                    .add_employee_id = userData,
                    .received_email = email_received,
                    .user_uid = uid,
                    .getDateForTbl = getDateforTbl,
                    .get_pey_period_hehe = pay_period
                }

                    add_employee_info.SetImage(PictureBox1.Image)
                    add_employee_info.Show()
                    Me.Hide()


                Else
                    MessageBox.Show("Image data is missing for the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred while processing the row: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        LoadEmployeeData()
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


    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        LoadEmployeeData()
        Me.Hide()
        payroll_dashboard.Show()
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click

    End Sub
End Class