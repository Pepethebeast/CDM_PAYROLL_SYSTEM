Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports System.Drawing
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.Encodings.Web

Public Class List_of_Employees

    Public connect As New FirebaseConfig() With
        {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }

    Private client As IFirebaseClient
    Private Const RowHeight As Integer = 60 ' Increased row height
    Private Const FontSize As Single = 8.0F ' Increased font size



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
            Dim SRRecord = client.Get("usersTbl/")
            Dim employees As Dictionary(Of String, PersonalData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PersonalData))(SRRecord.Body)

            If employees Is Nothing OrElse employees.Count = 0 Then
                MessageBox.Show("NO EMPLOYEE DATA! Please Add Employee", "NO DATA SHOWED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim employeeList As List(Of PersonalData) = employees.Values.Where(Function(emp) Not String.IsNullOrEmpty(emp.Employee_ID)).ToList()

            DGVUserData.DataSource = Nothing
            DGVUserData.Columns.Clear()
            DGVUserData.AutoGenerateColumns = False

            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Employee_ID", .HeaderText = "Employee ID", .Name = "Employee_ID"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Name", .HeaderText = "Name", .Name = "Name"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Age", .HeaderText = "Age", .Name = "Age"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "DateOfBirth", .HeaderText = "Date Of Birth", .Name = "DateOfBirth"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Position", .HeaderText = "Position", .Name = "Position"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Contact", .HeaderText = "Contact", .Name = "Contact"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Email_Address", .HeaderText = "Email Address", .Name = "Email_Address"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Designation", .HeaderText = "Designation", .Name = "Designation"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Description", .HeaderText = "Description", .Name = "Description"})
            DGVUserData.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "NoofUnits", .HeaderText = "Total No. of Units", .Name = "NoofUnits"})
            DGVUserData.Columns.Add(New DataGridViewImageColumn With {.DataPropertyName = "Image", .HeaderText = "Image", .Name = "Image", .ImageLayout = DataGridViewImageCellLayout.Stretch})



            DGVUserData.DataSource = employeeList
            DGVUserData.AllowUserToAddRows = False


            SetRowHeightsAndStyling()

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetRowHeightsAndStyling()
        ' Set row heights
        For Each row As DataGridViewRow In DGVUserData.Rows
            row.Height = RowHeight
        Next
        DGVUserData.RowTemplate.Height = RowHeight

        ' Apply styling to all cells
        DGVUserData.DefaultCellStyle.Font = New Font("Roboto", FontSize, FontStyle.Regular)
        DGVUserData.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
        DGVUserData.DefaultCellStyle.BackColor = Color.White
        DGVUserData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250)
        DGVUserData.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Style header row
        DGVUserData.ColumnHeadersDefaultCellStyle.Font = New Font("Roboto", FontSize, FontStyle.Regular)
        DGVUserData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237)
        DGVUserData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DGVUserData.EnableHeadersVisualStyles = False

        ' Style alternating rows
        DGVUserData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)

        ' Set column widths
        DGVUserData.Columns("Employee_ID").Width = 20
        DGVUserData.Columns("Name").Width = 200
        DGVUserData.Columns("Age").Width = 50
        DGVUserData.Columns("Contact").Width = 50
        DGVUserData.Columns("Email_Address").Width = 200
        DGVUserData.Columns("Designation").Width = 150
        DGVUserData.Columns("Description").Width = 200
        DGVUserData.Columns("NoofUnits").Width = 80
        DGVUserData.Columns("Image").Width = 80

        ' Center-align specific columns
        DGVUserData.Columns("Employee_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Age").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Contact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Email_Address").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("NoofUnits").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Designation").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Image").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("Position").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVUserData.Columns("DateOfBirth").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub List_of_Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            client = New FireSharp.FirebaseClient(connect)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        LoadEmployeeData()

        DGVUserData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    Private Sub DGVUserData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVUserData.CellFormatting
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return

        Dim column As DataGridViewColumn = DGVUserData.Columns(e.ColumnIndex)
        If column Is Nothing Then Return

        If column.Name = "Image" AndAlso e.Value IsNot Nothing Then
            Try
                Dim base64String As String = TryCast(e.Value, String)
                If Not String.IsNullOrEmpty(base64String) Then
                    Dim imageBytes = Convert.FromBase64String(base64String)
                    Using ms As New MemoryStream(imageBytes)
                        Dim originalImage As Image = Image.FromStream(ms)
                        ' Create a new Bitmap with the size of the cell
                        Dim cellSize As Size = CType(sender, DataGridView).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Size
                        Dim stretchedImage As New Bitmap(cellSize.Width, cellSize.Height)

                        ' Draw the original image onto the new Bitmap, stretching it to fit
                        Using g As Graphics = Graphics.FromImage(stretchedImage)
                            g.DrawImage(originalImage, New Rectangle(0, 0, cellSize.Width, cellSize.Height))
                        End Using

                        e.Value = stretchedImage
                    End Using
                    e.FormattingApplied = True
                End If
            Catch ex As Exception
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
        timeinout.Show()

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
End Class