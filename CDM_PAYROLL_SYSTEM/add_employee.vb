
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

    Public Property EmailReceivedText
    Public Property UserUID As String
    Public Property Pass123 As String
    Private Sub add_employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        email.Text = EmailReceivedText
        Dim User_UID = UserUID
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Employee_Dashboard.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Fname.Text = Nothing Then
            MessageBox.Show("Name field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If Mname.Text = Nothing Then
            MessageBox.Show("Name field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If Lname.Text = Nothing Then
            MessageBox.Show("Name field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
        If CivilStatus.Text = Nothing Then
            MessageBox.Show("Name field is empty." & vbCrLf & "Please fill in the textbox field  to continue")
            Return
        End If
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

            Dim r = New Random
            Dim num As Integer
            num = r.Next(1, 9999999)
            Dim IDresults = Strings.Right("000000" & num.ToString, 7)
            Dim check_ID = client.Get("Employee/ID: " + IDresults)


            If check_ID.Body <> "null" Then
                MessageBox.Show("The same ID is found, please try again to generate new ID...", "Error")

            Else

                Dim newsuffix = Suffix.Text
                Dim namer = Fname.Text & " " & Mname.Text.Substring(0, 1) & "." & " " & Lname.Text & " " & newsuffix
                Dim dob = DateOfBirth.Text
                Dim age = GetAge(dob)
                Dim newID = IDresults
                Dim ImgData = ImageToBase64(PictureBox4.Image)
                Dim PD As New PersonalData With
           {
           .Employee_ID = newID,
           .Name = namer,
           .CivilStatus = CivilStatus.Text,
           .Age = age,
           .DateOfBirth = DateOfBirth.Text,
           .Password = Pass123,
           .Contact = Contact.Text,
           .Email_Address = email.Text,
           .Position = Position.Text,
           .DateHired = DateHired.Text,
           .Department = Department.Text,
           .Designation = Designation.Text,
           .Description = Description.Text,
           .NoofUnits = NoUnits.Text,
           .Image = ImgData
           }

                Dim save = client.Set("employeeDataTbl/" + UserUID, PD)
                MessageBox.Show("Data Saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Hide()
                register_rfid.Show()

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
        timeinout.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)
        Close()
        acc.Show()
    End Sub



    Private Sub Suffix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Suffix.SelectedIndexChanged

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
End Class