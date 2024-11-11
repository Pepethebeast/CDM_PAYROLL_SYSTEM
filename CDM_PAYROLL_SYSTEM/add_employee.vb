
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports System.ComponentModel
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Firebase.Auth.Providers
Imports Firebase.Auth
Imports FontAwesome.Sharp
Imports System.Text
Imports System.Security.Cryptography

Public Class add_employee

    Dim IMG_FileNameInput As String
    Public connect As New FirebaseConfig() With
        {
        .AuthSecret = "iGGHOybA7ysmBiZFfNe8jFuKIE2ljaIjKHkKyCaw",
        .BasePath = "https://cdm-payroll-system-default-rtdb.asia-southeast1.firebasedatabase.app/"
        }

    Private client As IFirebaseClient

    Public Property received_email
    Public Property user_uid As String
    Public Property add_employee_id As String
    Public Property received_name As String
    Private Sub add_employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = received_name
        TextBox2.Text = received_email
        Try
            client = New FireSharp.FirebaseClient(connect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Function ImageToBase64(image As Image) As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]  
            Dim Format As System.Drawing.Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
            image.Save(ms, Format)
            Dim imageBytes As Byte() = ms.ToArray()

            ' Convert byte[] to Base64 String  
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function



    Public Function GetAge(ByVal DateofBirth As Date) As Integer

        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - DateofBirth.Year

        If (today.Month < DateofBirth.Month) Or (today.Month = DateofBirth.Month And today.Day < DateofBirth.Day) Then
            age -= 1


        End If

        Return age

    End Function

    Private Sub Label1_Click_1(sender As Object, e As EventArgs)
        Close()
        Main_Dashboard.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Close()
        payroll.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Close()
        Employee_Dashboard.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Contact.Text = Nothing Then
            MessageBox.Show("Contact field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If DateOfBirth.Text = Nothing Then
            MessageBox.Show("Date of Birth field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If Position.Text = Nothing Then
            MessageBox.Show("Position field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If DateHired.Text = Nothing Then
            MessageBox.Show("Date Hired field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If Department.Text = Nothing Then
            MessageBox.Show("Department field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If Designation.Text = Nothing Then
            MessageBox.Show("Designation field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If NoUnits.Text = Nothing Then
            MessageBox.Show("No of Units field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If IMG_FileNameInput = Nothing Then
            MessageBox.Show("Image file has not been entered." & vbCrLf & "Please enter the image to continue.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        Try

            Dim check_ID = client.Get("usersTbl/Employee_ID " + add_employee_id)
            If check_ID.Body <> "null" Then
                MessageBox.Show("The same ID is found, please try again to generate new ID...", "Error")

            Else

                Dim dob = DateOfBirth.Text
                Dim age = GetAge(dob)
                Dim ImgData = ImageToBase64(PictureBox4.Image)
                Dim PD As New PersonalData With
           {
           .name = TextBox1.Text,
           .employeeID = add_employee_id,
           .age = age,
           .date_of_birth = dob,
           .contact = Contact.Text,
           .email = TextBox2.Text,
           .position = Position.Text,
           .date_hired = DateHired.Text,
           .department = Department.Text,
           .designation = Designation.Text,
           .description = Description.Text,
           .no_of_units = NoUnits.Text,
           .image = ImgData
           }

                Dim save = client.Set("EmployeeDataTbl/" & user_uid, PD)
                MessageBox.Show("Data Saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()

            End If

        Catch ex As Exception

            If ex.Message = "One or more errors occured." Then
                MessageBox.Show("Cannot connect to firebase, check your network!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try

    End Sub

    Private Sub DateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles DateOfBirth.ValueChanged

    End Sub

    Private Sub DateHired_ValueChanged(sender As Object, e As EventArgs) Handles DateHired.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Close()
        RFID_Based_Attendance.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)
        Close()
        acc.Show()
    End Sub



    Private Sub Suffix_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Using openFileDialog As New OpenFileDialog
            openFileDialog.FileName = ""
            openFileDialog.Filter = "JPEG (*.jpeg;*.jpg)|*.jpeg;*.jpg"

            If openFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                IMG_FileNameInput = openFileDialog.FileName
                PictureBox4.ImageLocation = IMG_FileNameInput
            End If
        End Using
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    'Private Async Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    '    Dim result = MessageBox.Show("Do you want to cancel the account creation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    If result = DialogResult.Yes Then
    '        Try
    '            ' Delete the user's data from Firebase Realtime Database
    '            Dim deleteResponse As FirebaseResponse = client.Delete($"usersTbl/{UserUID}")
    '            If deleteResponse.StatusCode = Net.HttpStatusCode.OK Then
    '                ' Now, delete the user from Firebase Authentication
    '                Dim authSecret = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs" ' Your Firebase Auth Secret
    '                Dim userId = UserUID ' User ID of the user to delete
    '                Dim firebaseAuthUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:delete?key={authSecret}"

    '                Using httpClient As New HttpClient()
    '                    Dim jsonContent = $"{{""idToken"": ""{userId}""}}"
    '                    Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")
    '                    Dim response = Await httpClient.PostAsync(firebaseAuthUrl, content) ' Await is valid now

    '                    If response.IsSuccessStatusCode Then
    '                        MessageBox.Show("Account Creation successfully cancelled and user information deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        MessageBox.Show("Failed to delete user from Firebase Authentication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If
    '                End Using
    '            Else
    '                MessageBox.Show("Failed to delete user information: " & deleteResponse.Body, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show("Error occurred while deleting user information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '        Me.Close()
    '        Employee_Dashboard.Show()
    '    End If
    'End Sub
End Class