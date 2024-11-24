Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports System.Drawing
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.Encodings.Web
Imports Firebase.Database
Imports CDM_PAYROLL_SYSTEM.PersonalData
Imports FirebaseAdmin.Auth
Imports System.Windows.Controls

Public Class List_of_Employees
    Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()
    Public Function Base64ToImage(base64String As String) As System.Drawing.Image
        ' Convert Base64 String to byte[]  
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Using ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
            ' Convert byte[] to Image  
            Return System.Drawing.Image.FromStream(ms, True)
        End Using
    End Function

    Dim former As New Form
    Dim IMG_FileNameInput As String
    Dim clearDGVCol As Boolean = True
    Private dtTableGrd As DataTable

    Sub LoadEmployeeData(Optional keyword As String = "")
        Try
            ' Retrieve data from Firebase
            Dim SRRecord = Client.Get("EmployeeDataTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(SRRecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("No data found! Add new employee.", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Assign UID to each employee
            For Each kvp As KeyValuePair(Of String, PersonalData) In employees
                kvp.Value.UID = kvp.Key
            Next

            ' Filter the employee list based on the keyword
            Dim employeeList As List(Of PersonalData) = employees.Values _
            .Where(Function(emp) Not String.IsNullOrEmpty(emp.employeeID) AndAlso
                                 (String.IsNullOrEmpty(keyword) OrElse
                                  emp.employeeID.Contains(keyword, StringComparison.OrdinalIgnoreCase) OrElse
                                  emp.name.Contains(keyword, StringComparison.OrdinalIgnoreCase) OrElse
                                  emp.email.Contains(keyword, StringComparison.OrdinalIgnoreCase))) _
            .ToList()

            ' Display a message if no data matches the search criteria
            If employeeList.Count = 0 Then

                Return
            End If

            ' Reset DataGridView and add columns
            DGVUserData.DataSource = Nothing
            DGVUserData.Columns.Clear()
            DGVUserData.AutoGenerateColumns = False

            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "UID", .HeaderText = "UID", .Name = "UID", .Visible = False})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "EmployeeID", .HeaderText = "Employee ID", .Name = "EmployeeID"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "name", .HeaderText = "Name", .Name = "name"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "age", .HeaderText = "Age", .Name = "age"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_of_birth", .HeaderText = "Date Of Birth", .Name = "date_of_birth"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "position", .HeaderText = "Position", .Name = "position"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "contact", .HeaderText = "Contact", .Name = "contact"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "designation", .HeaderText = "Designation", .Name = "designation"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "description", .HeaderText = "Description", .Name = "description"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "no_of_units", .HeaderText = "No. of Units", .Name = "no_of_units"})
            DGVUserData.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "image", .HeaderText = "Image", .Name = "image", .ImageLayout = DataGridViewImageCellLayout.Stretch})

            DGVUserData.EnableHeadersVisualStyles = False
            DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
            DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVUserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVUserData.ColumnHeadersHeight = 40 ' Increase header height
            DGVUserData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVUserData.DefaultCellStyle.Font = New Font("Roboto", 12)
            DGVUserData.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", 8, FontStyle.Regular)
            DGVUserData.RowTemplate.Height = 55
            DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGVUserData.BorderStyle = BorderStyle.None
            DGVUserData.BackgroundColor = Color.White
            DGVUserData.GridColor = Color.White
            DGVUserData.RowHeadersVisible = False
            DGVUserData.EnableHeadersVisualStyles = False
            DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
            DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            DGVUserData.DefaultCellStyle.SelectionBackColor = Color.LightBlue
            DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black
            DGVUserData.ReadOnly = True
            ' Bind the filtered list to the DataGridView
            DGVUserData.DataSource = employeeList
            DGVUserData.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub List_of_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DGVUserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        LoadEmployeeData()
    End Sub
    Private Sub listofemployees_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
                            Using originalImage As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                                ' Get the cell size
                                Dim cellSize As Size = CType(sender, DataGridView).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Size

                                ' Only create new image if we have valid dimensions
                                If cellSize.Width > 0 AndAlso cellSize.Height > 0 Then
                                    ' Create a new Bitmap with the size of the cell
                                    Using stretchedImage As New Bitmap(cellSize.Width, cellSize.Height)
                                        ' Draw the original image onto the new Bitmap, stretching it to fit
                                        Using g As Graphics = Graphics.FromImage(stretchedImage)
                                            g.DrawImage(originalImage, New Rectangle(0, 0, cellSize.Width, cellSize.Height))
                                        End Using
                                        e.Value = New Bitmap(stretchedImage)
                                    End Using
                                End If
                            End Using
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


    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
        Main_Dashboard.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        payroll.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        RFID_Based_Attendance.Show()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Employee_Dashboard.Show()
    End Sub



    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Hide()
        Employee_Dashboard.Show()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        LoadEmployeeData()
        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click

        If DGVUserData.SelectedRows.Count = 1 Then
            ' Ask for confirmation before deleting
            Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                ' Get the selected row
                Dim selectedRow As DataGridViewRow = DGVUserData.SelectedRows(0)
                Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()

                ' Delete the data from Firebase


                ' Delete the data from Firebase (based on UID)
                client.Delete("EmployeeDataTbl/" & selectedUID)

                ' Optionally, show a success message
                MessageBox.Show("Record deleted from Firebase successfully!")
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DGVUserData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUserData.CellContentClick

    End Sub

    Dim selectedRowData As List(Of String)
    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click

        If DGVUserData.SelectedRows.Count > 0 Then
            ' Debugging step to confirm row selection

            ' Retrieve the data from the selected row
            Dim selectedRow As DataGridViewRow = DGVUserData.SelectedRows(0)
            Dim name_received As String = selectedRow.Cells("Name").Value.ToString()
            Dim userData As String = selectedRow.Cells("EmployeeID").Value.ToString()
            Dim email_received As String = selectedRow.Cells("email").Value.ToString()
            Dim selectedUID As String = selectedRow.Cells("UID").Value.ToString()

            ' Check if there is an image
            If selectedRow.Cells("image").Value IsNot Nothing Then
                Dim base64String As String = selectedRow.Cells("image").Value.ToString()
                Dim image_for_emp As System.Drawing.Image = Base64ToImage(base64String)

                ' Create an instance of the add_employee form
                Dim add_employee_info As New add_employee()

                ' Pass the data to the add_employee form
                add_employee_info.received_name = name_received
                add_employee_info.add_employee_id = userData
                add_employee_info.received_email = email_received
                add_employee_info.user_uid = selectedUID

                ' Set the image to PictureBox4 in the add_employee form
                add_employee_info.PictureBox4.Image = image_for_emp

                ' Show the add_employee form
                add_employee_info.Show()
            End If
        Else
            MessageBox.Show("Please select a row first.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        Dim keyword As String = TextBox1.Text.Trim()
        LoadEmployeeData(keyword)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Check if data is already loaded
        If DGVUserData.DataSource Is Nothing Then Return

        ' Get the search text and remove leading/trailing spaces
        Dim searchText As String = TextBox1.Text.Trim().ToLower()

        ' Cast the DataSource back to a list of PersonalData
        Dim employeeList As List(Of PersonalData) = TryCast(DGVUserData.DataSource, List(Of PersonalData))
        If employeeList Is Nothing Then Return

        ' Check if searchText is empty
        If String.IsNullOrEmpty(searchText) Then
            ' If empty, show all records
            DGVUserData.DataSource = Nothing
            DGVUserData.DataSource = employeeList
        Else
            ' If not empty, filter the data based on search text
            Dim filteredList = employeeList.Where(Function(emp) _
            emp.employeeID.Contains(searchText) OrElse
            emp.name.Contains(searchText) OrElse
            emp.position.Contains(searchText)
        ).ToList()

            ' Update the DataGridView with the filtered list
            DGVUserData.DataSource = Nothing
            DGVUserData.DataSource = filteredList
        End If
    End Sub
    Private Sub HighlightMatches(searchText As String)
        For Each row As DataGridViewRow In DGVUserData.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    cell.Style.BackColor = Color.Yellow
                Else
                    cell.Style.BackColor = Color.White
                End If
            Next
        Next
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Me.Hide()
        reports.Show()
    End Sub
End Class