Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports System.Drawing
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.Encodings.Web

Public Class List_of_Employees
    Private FirebaseURL As String = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/" ' Your Firebase Realtime Database URL
    Private AuthToken As String = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw" ' Your authentication token if needed
    Public connect As New FirebaseConfig() With
        {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }

    Private client As IFirebaseClient
    Private Const RowHeight As Integer = 60 ' Increased row height
    Private Const FontSize As Single = 8.0F ' Increased font size
    Private previousRowIndex As Integer = -1
    Public Function Base64ToImage(base64String As String) As Image
        ' Convert Base64 String to byte[]  
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image  
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = System.Drawing.Image.FromStream(ms, True)
        Return image__1
    End Function

    Dim former As New Form
    Dim IMG_FileNameInput As String
    Dim clearDGVCol As Boolean = True
    Private dtTableGrd As DataTable

    Sub LoadEmployeeData()
        Try
            Dim SRRecord = client.Get("EmployeeDataTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(SRRecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("No data found! add new employee", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim employeeList As List(Of PersonalData) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.employeeID)).ToList()
            DGVUserData.DataSource = Nothing
            DGVUserData.Columns.Clear()
            DGVUserData.AutoGenerateColumns = False

            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "EmployeeID", .HeaderText = "Employee ID", .Name = "EmployeeID"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "name", .HeaderText = "Name", .Name = "name"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "age", .HeaderText = "Age", .Name = "age"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "date_of_birth", .HeaderText = "Date Of Birth", .Name = "date_of_birth"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "position", .HeaderText = "Position", .Name = "position"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "contact", .HeaderText = "Contact", .Name = "contact"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "email", .HeaderText = "Email Address", .Name = "email"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "designation", .HeaderText = "Designation", .Name = "designation"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "description", .HeaderText = "Description", .Name = "description"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "no_of_units", .HeaderText = "No. of Units", .Name = "no_of_units"})
            DGVUserData.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "image", .HeaderText = "Image", .Name = "image", .ImageLayout = DataGridViewImageCellLayout.Stretch})

            DGVUserData.DataSource = employeeList
            DGVUserData.AllowUserToAddRows = False

            ApplyDataGridViewStyling()
        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CenterAlignDataGridViewHeaders(DGVUserData As DataGridView)
        For Each column As DataGridViewColumn In DGVUserData.Columns
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Private Sub List_of_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGVUserData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Try
            client = New FireSharp.FirebaseClient(connect)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        LoadEmployeeData()
        ApplyDataGridViewStyling()
        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    Private Sub ApplyDataGridViewStyling()
        ' Set header style
        DGVUserData.EnableHeadersVisualStyles = False
        DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen
        DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DGVUserData.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        DGVUserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.ColumnHeadersHeight = 40 ' Increase header height

        ' Set row style
        DGVUserData.RowTemplate.Height = 70 ' Set row height to 70 pixels
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
            column.DefaultCellStyle.Font = New Font("Arial", 9)
        Next

        ' Specific styling for the image column if it exists
        If DGVUserData.Columns.Contains("image") Then
            DGVUserData.Columns("image").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        ' Ensure all rows are set to the new height
        For Each row As DataGridViewRow In DGVUserData.Rows
            row.Height = 70
        Next

        ' Refresh the DataGridView to apply changes
        DGVUserData.Refresh()

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
                            Using originalImage As Image = Image.FromStream(ms)
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
        Me.Close()
        Main_Dashboard.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
        Employee_Dashboard.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        payroll.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
        RFID_Based_Attendance.Show()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
        acc.Show()
    End Sub



    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Me.Close()
        Employee_Dashboard.Show()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        LoadEmployeeData()
        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub



    ' Method to delete data from Firebase
    Public Async Function DeleteDataAsync(ByVal path As String) As Task(Of Boolean)
        Using client As New HttpClient()
            Try
                ' Construct the full URL with the path to the data and the auth token if needed
                Dim url As String = $"{FirebaseURL}{path}.json?auth={AuthToken}"

                ' Perform DELETE request
                Dim response As HttpResponseMessage = Await client.DeleteAsync(url)

                ' Check if the request was successful
                If response.IsSuccessStatusCode Then
                    Console.WriteLine("Data deleted successfully.")
                    Return True
                Else
                    Console.WriteLine($"Failed to delete data. Status code: {response.StatusCode}")
                    Return False
                End If
            Catch ex As Exception
                Console.WriteLine($"An error occurred: {ex.Message}")
                Return False
            End Try
        End Using
    End Function

    Private Async Sub DeleteColumnFromFirebase(ByVal attributeName As String)
        Try
            Dim path As String = $"EmployeeDataTbl/{attributeName}"
            Dim result = Await client.DeleteAsync(path)
            If result.StatusCode = HttpStatusCode.OK Then
                MessageBox.Show("Data deleted from Firebase successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to delete data from Firebase.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting data from Firebase: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        Dim columnName As String = "EmployeeID" ' Replace with the actual column name to delete
        If DGVUserData.Columns.Contains(columnName) Then
            ' Delete column from DataGridView


            ' Delete data from Firebase (replace with actual attribute name if necessary)
            DeleteColumnFromFirebase(columnName)
        Else
            MessageBox.Show("The specified column does not exist.", "Column Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class