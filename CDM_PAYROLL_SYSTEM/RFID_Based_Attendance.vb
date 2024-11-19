Imports System.Globalization
Imports System.IO
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class RFID_Based_Attendance

    Private client As IFirebaseClient
    Private Sub RFID_Based_Attendance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub RFID_Based_Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGVUserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim config = New FirebaseConfig() With {
            .AuthSecret = "ivwZ5tA6oaxVQs1uQNnSecoaSqm38VwV6eJtc7Bn",
            .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }
        client = New FireSharp.FirebaseClient(config)
        loademployeedata()
        ApplyDataGridViewStyling()
    End Sub
    Public Function Base64ToImage(base64String As String) As Image
        ' Convert Base64 String to byte[]  
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        ' Create a MemoryStream from the byte array
        Using ms As New MemoryStream(imageBytes)
            ' Convert byte[] to Image  
            Return System.Drawing.Image.FromStream(ms)
        End Using
    End Function
    Private Sub DGVUserData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVUserData.CellFormatting
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return

        Dim column As DataGridViewColumn = DGVUserData.Columns(e.ColumnIndex)
        If column Is Nothing Then Return

        If column.Name.ToLower() = "image" AndAlso e.Value IsNot Nothing Then
            Try
                ' Validate that the value is actually a string
                Dim base64String As String = TryCast(e.Value, String)
                If String.IsNullOrEmpty(base64String) Then
                    e.Value = Nothing
                    e.FormattingApplied = True
                    Return
                End If

                ' Validate the Base64 string format
                Try
                    ' Try to decode the Base64 string first to validate it
                    Dim imageBytes = Convert.FromBase64String(base64String)

                    ' Only proceed if we have valid image data
                    If imageBytes.Length > 0 Then
                        Using ms As New MemoryStream(imageBytes)
                            ' Validate that the data is actually an image
                            Dim originalimage As Image = System.Drawing.Image.FromStream(ms)
                            ' Get the cell size
                            Dim cellSize As Size = CType(sender, DataGridView).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Size

                            ' Only create new image if we have valid dimensions
                            If cellSize.Width > 0 AndAlso cellSize.Height > 0 Then
                                ' Create a new Bitmap with the size of the cell
                                Using stretchedImage As New Bitmap(cellSize.Width, cellSize.Height)
                                    ' Draw the original image onto the new Bitmap, stretching it to fit
                                    Using g As Graphics = Graphics.FromImage(stretchedImage)
                                        g.DrawImage(originalimage, New Rectangle(0, 0, cellSize.Width, cellSize.Height))
                                    End Using
                                    e.Value = New Bitmap(stretchedImage)
                                End Using
                            End If
                        End Using

                    End If
                    e.FormattingApplied = True
                Catch ex As FormatException
                    ' Handle invalid Base64 string
                    e.Value = Nothing
                    e.FormattingApplied = True
                    Debug.WriteLine($"Invalid Base64 string: {ex.Message}")
                End Try
            Catch ex As Exception
                ' Handle any other errors
                e.Value = Nothing
                e.FormattingApplied = True
                Debug.WriteLine($"Error formatting image: {ex.Message}")
            End Try
        End If
    End Sub
    Sub loademployeedata()

        Try
            Dim srrecord = client.Get("EmployeeDataTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(srrecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                Return
            End If

            ' Update each PersonalData object to include the UID
            For Each kvp As KeyValuePair(Of String, PersonalData) In employees
                kvp.Value.UID = kvp.Key
            Next

            ' Create a list of employees with UID included
            Dim employeelist As List(Of PersonalData) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.employeeID)).ToList()

            ' Clear and set up DataGridView columns
            DGVUserData.DataSource = Nothing
            DGVUserData.Columns.Clear()
            DGVUserData.AutoGenerateColumns = False

            ' Add columns to DataGridView, including UID
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "designation", .HeaderText = "designation", .Name = "designation", .Visible = False})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "description", .HeaderText = "description", .Name = "description", .Visible = False})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "no_of_units", .HeaderText = "no_of_units", .Name = "no_of_units", .Visible = False})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "employeeID", .HeaderText = "Employee ID", .Name = "employeeid"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "name", .HeaderText = "Name", .Name = "name"})
            DGVUserData.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "image", .HeaderText = "Image", .Name = "image", .ImageLayout = DataGridViewImageCellLayout.Stretch, .Visible = False})

            ' Set DataGridView styles
            DGVUserData.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            DGVUserData.DefaultCellStyle.BackColor = Color.White
            DGVUserData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
            DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black
            DGVUserData.DataSource = employeelist
            DGVUserData.AllowUserToAddRows = False
            DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ApplyDataGridViewStyling()
        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyDataGridViewStyling()
        ' Set header style
        DGVUserData.EnableHeadersVisualStyles = False
        DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
        DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DGVUserData.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        DGVUserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.ColumnHeadersHeight = 30 ' Increase header height

        ' Set row style
        DGVUserData.RowTemplate.Height = 10 ' Set row height to 70 pixels
        DGVUserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Set border style and color
        DGVUserData.BorderStyle = BorderStyle.Fixed3D
        DGVUserData.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DGVUserData.GridColor = Color.Black ' This sets the color of the grid lines (borders between cells)

        ' Other general styling
        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVUserData.BackgroundColor = Color.White
        DGVUserData.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen
        DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Alternating row colors for better readability
        DGVUserData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)

        ' Apply styling to all columns
        For Each column As DataGridViewColumn In DGVUserData.Columns
            column.DefaultCellStyle.Font = New Font("Arial", 10)
        Next

        ' Specific styling for the image column if it exists
        If DGVUserData.Columns.Contains("image") Then
            DGVUserData.Columns("image").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        ' Ensure all rows are set to the new height
        For Each row As DataGridViewRow In DGVUserData.Rows
            row.Height = 30
        Next

        ' Refresh the DataGridView to apply changes
        DGVUserData.Refresh()

    End Sub

    Private Sub DGVUserData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUserData.CellContentClick
        If e.ColumnIndex >= 0 And checkbox1.Checked = True OrElse CheckBox2.Checked = True OrElse CheckBox3.Checked = True Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = DGVUserData.Rows(e.RowIndex)

            ' Retrieve the UID from the selected row's "UID" cell
            Dim employeeUID As String = selectedRow.Cells("UID").Value.ToString()
            Label4.Text = selectedRow.Cells("employeeID").Value.ToString()
            Label11.Text = selectedRow.Cells("name").Value.ToString()
            Label13.Text = selectedRow.Cells("designation").Value.ToString()
            Label15.Text = selectedRow.Cells("description").Value.ToString()
            Label17.Text = selectedRow.Cells("no_of_units").Value.ToString()
            If selectedRow.Cells("image").Value IsNot Nothing Then
                Dim base64String As String = selectedRow.Cells("image").Value.ToString()
                PictureBox5.Image = Base64ToImage(base64String)
            Else
                PictureBox5.Image = Nothing
            End If

            ' Call the method to load session data for the selected UID
            If checkbox1.Checked Then
                loadSessionDataPerday(employeeUID)
                CheckBox2.Checked = False
                CheckBox3.Checked = False
            End If


            If CheckBox2.Checked Then
                loadsessiondataperweek(employeeUID)
                checkbox1.Checked = False
                CheckBox3.Checked = False
            End If

            If CheckBox3.Checked Then
                loadsessiondatapermonth(employeeUID)
                checkbox1.Checked = False
                CheckBox2.Checked = False
            End If

        End If
    End Sub

    Private Sub loadsessiondataperweek(employeeUID As String)
        Try
            ' Retrieve data from Firebase for a specific employee UID
            Dim srrecord = client.Get($"EmployeeSessionTbl/{employeeUID}")
            Dim employeeData As JObject = JObject.Parse(srrecord.Body)

            ' Extract individual logs from JSON data
            Dim datelogs As Dictionary(Of String, String) = Nothing
            Dim timeInLogs As Dictionary(Of String, String) = Nothing
            Dim timeOutLogs As Dictionary(Of String, String) = Nothing

            If employeeData.ContainsKey("Datelogs") AndAlso employeeData("Datelogs") IsNot Nothing Then
                datelogs = employeeData("Datelogs").ToObject(Of Dictionary(Of String, String))()
            Else
                datelogs = New Dictionary(Of String, String)() ' Assign an empty dictionary if null
            End If

            If employeeData.ContainsKey("TimeInLogs") AndAlso employeeData("TimeInLogs") IsNot Nothing Then
                timeInLogs = employeeData("TimeInLogs").ToObject(Of Dictionary(Of String, String))()
            Else
                timeInLogs = New Dictionary(Of String, String)()
            End If

            If employeeData.ContainsKey("TimeOutLogs") AndAlso employeeData("TimeOutLogs") IsNot Nothing Then
                timeOutLogs = employeeData("TimeOutLogs").ToObject(Of Dictionary(Of String, String))()
            Else
                timeOutLogs = New Dictionary(Of String, String)()
            End If

            ' Get the current date
            Dim currentDate As Date = Date.Today

            ' Filter the sessions to only include the last 7 days
            Dim sessionLogs As New List(Of PersonalData.PerWeek)
            For Each kvp In datelogs
                ' Parse the date from the session log (assuming it's stored as a string in the format "yyyy-MM-dd")
                Dim sessionDate As Date
                If Date.TryParse(kvp.Value, sessionDate) Then
                    ' Check if the session date is within the last 7 days
                    If sessionDate >= currentDate.AddDays(-5) AndAlso sessionDate <= currentDate Then
                        Dim sessionId = kvp.Key
                        sessionLogs.Add(New PersonalData.PerWeek With {
                        .session_id = sessionId,
                        .date_stamp = kvp.Value,
                        .time_in_stamp = If(timeInLogs.ContainsKey(sessionId), timeInLogs(sessionId), ""),
                        .time_out_stamp = If(timeOutLogs.ContainsKey(sessionId), timeOutLogs(sessionId), "")
                    })
                    End If
                End If
            Next
            sessionLogs = sessionLogs.OrderByDescending(Function(x) Date.Parse(x.date_stamp)).ToList()
            ' Set up DataGridView columns
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()
            AttendanceGridVIew.AutoGenerateColumns = False

            ' Add columns to DataGridView
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "session_id", .HeaderText = "Session ID", .Name = "session_id"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_stamp", .HeaderText = "Date", .Name = "date_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_in_stamp", .HeaderText = "Time In", .Name = "time_in_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_out_stamp", .HeaderText = "Time Out", .Name = "time_out_stamp"})

            ' Bind data to DataGridView
            AttendanceGridVIew.DataSource = sessionLogs
            AttendanceGridVIew.AllowUserToAddRows = False
            AttendanceGridVIew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Apply additional styling as needed
            AttendanceGridVIew.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            AttendanceGridVIew.DefaultCellStyle.BackColor = Color.White
            AttendanceGridVIew.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
            AttendanceGridVIew.DefaultCellStyle.SelectionForeColor = Color.Black
            AttendanceGridVIew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AttendanceGridVIew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ex As Exception
            MessageBox.Show("Unable to retrieve attendance data: " & ex.Message)
        End Try
    End Sub
    Private Sub loadsessiondatapermonth(employeeUID As String)
        Try
            ' Retrieve data from Firebase for a specific employee UID
            Dim srrecord = client.Get($"EmployeeSessionTbl/{employeeUID}")
            Dim employeeData As JObject = JObject.Parse(srrecord.Body)

            ' Extract individual logs from JSON data
            Dim datelogs As Dictionary(Of String, String) = Nothing
            Dim timeInLogs As Dictionary(Of String, String) = Nothing
            Dim timeOutLogs As Dictionary(Of String, String) = Nothing

            If employeeData.ContainsKey("Datelogs") AndAlso employeeData("Datelogs") IsNot Nothing Then
                datelogs = employeeData("Datelogs").ToObject(Of Dictionary(Of String, String))()
            Else
                datelogs = New Dictionary(Of String, String)() ' Assign an empty dictionary if null
            End If

            If employeeData.ContainsKey("TimeInLogs") AndAlso employeeData("TimeInLogs") IsNot Nothing Then
                timeInLogs = employeeData("TimeInLogs").ToObject(Of Dictionary(Of String, String))()
            Else
                timeInLogs = New Dictionary(Of String, String)()
            End If

            If employeeData.ContainsKey("TimeOutLogs") AndAlso employeeData("TimeOutLogs") IsNot Nothing Then
                timeOutLogs = employeeData("TimeOutLogs").ToObject(Of Dictionary(Of String, String))()
            Else
                timeOutLogs = New Dictionary(Of String, String)()
            End If

            ' Get the current date and first and last days of the current month
            Dim currentDate As Date = Date.Today
            Dim firstDayOfMonth As Date = New Date(currentDate.Year, currentDate.Month, 1)
            Dim lastDayOfMonth As Date = firstDayOfMonth.AddMonths(1).AddDays(-1)

            ' Filter the sessions to only include the current month's data
            Dim sessionLogs As New List(Of PersonalData.PerWeek)
            For Each kvp In datelogs
                ' Parse the date from the session log (assuming it's stored as a string in the format "yyyy-MM-dd")
                Dim sessionDate As Date
                If Date.TryParse(kvp.Value, sessionDate) Then
                    ' Check if the session date is within the current month
                    If sessionDate >= firstDayOfMonth AndAlso sessionDate <= lastDayOfMonth Then
                        Dim sessionId = kvp.Key
                        sessionLogs.Add(New PersonalData.PerWeek With {
                        .session_id = sessionId,
                        .date_stamp = kvp.Value,
                        .time_in_stamp = If(timeInLogs.ContainsKey(sessionId), timeInLogs(sessionId), ""),
                        .time_out_stamp = If(timeOutLogs.ContainsKey(sessionId), timeOutLogs(sessionId), "")
                    })
                    End If
                End If
            Next
            sessionLogs = sessionLogs.OrderByDescending(Function(x) Date.Parse(x.date_stamp)).ToList()
            ' Set up DataGridView columns
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()
            AttendanceGridVIew.AutoGenerateColumns = False

            ' Add columns to DataGridView
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "session_id", .HeaderText = "Session ID", .Name = "session_id"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_stamp", .HeaderText = "Date", .Name = "date_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_in_stamp", .HeaderText = "Time In", .Name = "time_in_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_out_stamp", .HeaderText = "Time Out", .Name = "time_out_stamp"})

            ' Bind data to DataGridView
            AttendanceGridVIew.DataSource = sessionLogs
            AttendanceGridVIew.AllowUserToAddRows = False
            AttendanceGridVIew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Apply additional styling as needed
            AttendanceGridVIew.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            AttendanceGridVIew.DefaultCellStyle.BackColor = Color.White
            AttendanceGridVIew.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
            AttendanceGridVIew.DefaultCellStyle.SelectionForeColor = Color.Black
            AttendanceGridVIew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AttendanceGridVIew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AttendanceGridVIew.DataSource = sessionLogs

        Catch ex As Exception
            MessageBox.Show($"Error loading session data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        payroll_dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Employee_Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub AttendanceGridVIew_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AttendanceGridVIew.CellContentClick

    End Sub
    Public Sub loadSessionDataPerday(employeeUID As String)
        Try
            Dim srrecord = client.Get($"EmployeeSessionTbl/{employeeUID}")
            Dim employees As Dictionary(Of String, PersonalData.EmployeeSessionToday) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData.EmployeeSessionToday))(srrecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then


            End If

            ' Update each PersonalData object to include the UID
            For Each kvp As KeyValuePair(Of String, PersonalData.EmployeeSessionToday) In employees
                Dim sessionData As PersonalData.EmployeeSessionToday = kvp.Value
            Next

            ' Create a list of employees with UID included
            Dim employeelist As List(Of PersonalData.EmployeeSessionToday) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.session_id)).ToList()

            ' Clear and set up DataGridView columns
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()
            AttendanceGridVIew.AutoGenerateColumns = False

            ' Add columns to DataGridView, including UID
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "session_id", .HeaderText = "Session ID", .Name = "session_id"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_stamp", .HeaderText = "Date", .Name = "date_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_in_stamp", .HeaderText = "Time In", .Name = "time_in_stamp"})
            AttendanceGridVIew.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "time_out_stamp", .HeaderText = "Time Out", .Name = "time_out_stamp"})

            ' Set DataGridView styles
            AttendanceGridVIew.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            AttendanceGridVIew.DefaultCellStyle.BackColor = Color.White
            AttendanceGridVIew.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
            AttendanceGridVIew.DefaultCellStyle.SelectionForeColor = Color.Black
            AttendanceGridVIew.DataSource = employeelist
            AttendanceGridVIew.AllowUserToAddRows = False
            AttendanceGridVIew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            AttendanceGridVIew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AttendanceGridVIew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ApplyDataGridViewStyling()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox1.CheckedChanged
        If checkbox1.Checked Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        Else
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            checkbox1.Checked = False
            CheckBox3.Checked = False
        Else
            ' Optionally clear the DataGridView when unchecked
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            CheckBox2.Checked = False
            checkbox1.Checked = False
        Else
            AttendanceGridVIew.DataSource = Nothing
            AttendanceGridVIew.Columns.Clear()
        End If
    End Sub

End Class