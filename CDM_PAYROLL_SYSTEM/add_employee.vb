﻿
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
Imports Google.Apis.Auth.OAuth2
Imports Google.Cloud.Storage.V1
Imports Microsoft.DotNet.DesignTools.Protocol.Notifications
Imports Newtonsoft.Json
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
            LoadETLValues()

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
                ' Calculate age from Date of Birth
                Dim dob = DateOfBirth.Text
                Dim age = GetAge(dob)
                Dim ImgData = ImageToBase64(PictureBox4.Image)
                ' Prepare employee data object
                Dim PD As New PersonalData With {
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
                Try
                    ' Get the directory where the executable is located (the application directory)
                    Dim appDirectory As String = Application.StartupPath

                    ' Combine it with the relative path to the credential file
                    Dim credentialPath As String = Path.Combine("C:\Users\Zedrick\Documents\Visual Basic\CDM_PAYROLL_SYSTEM\CDM_PAYROLL_SYSTEM\cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")

                    ' Check if the credential file exists
                    If File.Exists(credentialPath) Then
                        ' Set the environment variable for Firebase credentials
                        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath)

                        ' Initialize Firebase using the credentials file
                        If FirebaseApp.DefaultInstance Is Nothing Then
                            FirebaseApp.Create(New AppOptions() With {
                    .Credential = GoogleCredential.FromFile(credentialPath)
                })
                        End If
                    Else
                        ' Show an error message if the file is not found
                        MessageBox.Show("Credential file not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    ' Handle any errors during initialization
                    MessageBox.Show($"Firebase initialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                Dim bucketName As String = "cdm-payroll-system.appspot.com"
                Dim user_uid123 As String = user_uid ' Use Employee ID as unique identifier
                Dim objectPath As String = $"profilePicture/{user_uid}/image.jpg"

                ' Convert PictureBox image to byte array
                Dim memoryStream As New MemoryStream()
                PictureBox4.Image.Save(memoryStream, Imaging.ImageFormat.Jpeg)
                Dim imageBytes As Byte() = memoryStream.ToArray()

                ' Upload the image to Firebase Storage (This will overwrite any existing file at this path)
                Dim storageClient As StorageClient = StorageClient.Create()
                Using uploadStream = New MemoryStream(imageBytes)
                    storageClient.UploadObject(bucketName, objectPath, "image/jpeg", uploadStream)
                End Using

                ' Save data to Firebase Realtime Database
                Dim numericGuid As String = New String(Guid.NewGuid().ToString().Where(AddressOf Char.IsDigit).ToArray()).Substring(0, 8)
                Dim save = client.Set("EmployeeDataTbl/" & user_uid, PD)
                Dim save2 = client.Set("NotificationTbl/" & user_uid & "/", "Your information has been updated by admin.")
                Dim reportTbl = client.Set("ReportTbl/account/" & numericGuid & "/message", "Information has been updated for employee ID: " + add_employee_id)
                reportTbl = client.Set("ReportTbl/" & "account/" & numericGuid & "/Date", FirebaseModule.today + " " + FirebaseModule.nowTime)
                MessageBox.Show("Data Saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Close the form
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Dim bucketName As String = "gs://cdm-payroll-system.appspot.com"
    Dim fileName As String = "images/" & Guid.NewGuid().ToString() & ".jpg"
    Dim objectPath As String = $"profilePicture/{user_uid}/image.jpg"
    Private Sub DateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles DateOfBirth.ValueChanged

    End Sub

    Private Sub DateHired_ValueChanged(sender As Object, e As EventArgs) Handles DateHired.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)
        Close()
        time_records_dashboard.Show()
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
        Me.Hide()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Description_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub LoadETLValues()
        Try
            ' Fetch the ETL data from Firebase
            Dim ETLComboBox = client.Get("AdminTbl/Calculations/Position")

            ' Deserialize the JSON response into a dictionary
            Dim calculationsComboBox = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(ETLComboBox.Body)

            Dim InstructorComboBox = client.Get("AdminTbl/Calculations/Designation")

            ' Deserialize the JSON response into a dictionary
            Dim instructorCalcu = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(InstructorComboBox.Body)

            ' Populate the ComboBox with the ETL roles (keys)
            If calculationsComboBox IsNot Nothing Then
                Position.Items.Clear()

                ' Add the roles (keys) to the ComboBox
                For Each role As KeyValuePair(Of String, Object) In calculationsComboBox
                    Position.Items.Add(role.Key)
                Next

                ' Optionally, select the first item as default (if you want a default value selected)
                If Position.Items.Count > 0 Then
                    Position.SelectedIndex = 0
                End If
            End If

            If instructorCalcu IsNot Nothing Then
                Designation.Items.Clear()

                ' Add the roles (keys) to the ComboBox
                For Each role As KeyValuePair(Of String, Object) In instructorCalcu
                    Designation.Items.Add(role.Key)
                Next

                ' Optionally, select the first item as default (if you want a default value selected)
                If Designation.Items.Count > 0 Then
                    Designation.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            ' Handle any errors that occur during the Firebase operation.
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub
    Private Sub Position_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position.SelectedIndexChanged
        If Position.Text = "Instructor" Then
            Description.Text = ""
        Else
            Description.Text = "ETL"
        End If
    End Sub

    Private Sub NoUnits_TextChanged(sender As Object, e As EventArgs) Handles NoUnits.TextChanged

        If NoUnits.Text Is Nothing Then
            Description.Text = ""
        ElseIf Description.Text = "ETL" Then
            Try
                ' Parse the text in NoUnits and ensure it is an integer
                Dim noUnitsValue As Integer = Integer.Parse(NoUnits.Text)

                ' Check if the Description is "ETL"
                If Description.Text = "ETL" Then
                    ' Limit the value of NoUnits to a maximum of 12
                    If noUnitsValue > 12 Then
                        MessageBox.Show("The maximum value allowed for ETL is 12.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        NoUnits.Text = "12" ' Reset the value to 12
                    End If
                End If

            Catch ex As Exception

            End Try
        Else
            Try
                If Integer.Parse(NoUnits.Text) > 24 AndAlso Position.Text = "Instructor" Then
                    Description.Text = "OL"
                Else
                    Description.Text = ""
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Public Sub InitializeFirebase()
        ' Get the path to the user's AppData folder
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        ' Combine the AppData path with your app's folder and the credential file name
        Dim credentialPath As String = Path.Combine(appDataPath, "CDM_PAYROLL_SYSTEM", "cdm-payroll-system-firebase-adminsdk-9mm0e-ccf4eb02cc.json")

        ' Set the environment variable for Firebase credentials
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath)

        ' Now the environment variable is set, and you can initialize Firebase
        Try
            ' Check if FirebaseApp instance already exists
            If FirebaseApp.DefaultInstance Is Nothing Then
                FirebaseApp.Create(New AppOptions() With {
            .Credential = GoogleCredential.FromFile(credentialPath)
        })
            End If
        Catch ex As Exception
            MessageBox.Show($"Firebase initialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Department.SelectedIndexChanged

    End Sub
    Public Sub UploadImageToFirebaseStorage(pictureBox As PictureBox, bucketName As String, fileName As String)
        Try
            ' Initialize Firebase
            InitializeFirebase()

            ' Convert PictureBox image to byte array
            Dim memoryStream As New MemoryStream()
            pictureBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim imageBytes As Byte() = memoryStream.ToArray()

            ' Create Firebase Storage Client
            Dim storageClient As StorageClient = StorageClient.Create()

            ' Upload the image
            Using uploadStream = New MemoryStream(imageBytes)
                storageClient.UploadObject(bucketName, fileName, "image/jpeg", uploadStream)
                MessageBox.Show("Image uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error uploading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub
End Class