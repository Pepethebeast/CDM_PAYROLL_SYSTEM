Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase.Database
Imports Firebase.Database.Query
Imports System.IO.Ports
Imports System.Drawing.Drawing2D
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports DocumentFormat.OpenXml.Bibliography

Public Class ADMIN_LOGIN
    Public Property email As String
    Public Property password As String
    Public username As String

    Dim fbClient As IFirebaseClient

    ' Variable to store the registered fingerprint from Firebase
    Dim registeredFingerprint As String

    ' Flag for exiting the application
    Private isExiting As Boolean = False

    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SerialPort.IsOpen Then
            SerialPort.Close()
        End If
    End Sub
    Private Sub HandleLoginSuccess()
        Timer1.Enabled = True
    End Sub


    ' Confirmation for exiting the application
    Private Sub ADMIN_LOGIN_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Show a confirmation dialog (optional)
        ' Only show the exit confirmation if isExiting is set to False
        If Not isExiting Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
            Else
                isExiting = True ' Set the flag to prevent further prompts
                Application.Exit() ' Exit the entire application
            End If
        End If
    End Sub

    ' Panel paint event handler


    Private Sub ADMIN_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    ' Declare placeholder text and shadow color for both TextBoxes
    Private placeholderTextUsername As String = "Enter username"
    Private placeholderTextPassword As String = "Enter password"
    Private shadowColor As Color = Color.Gray

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        ' Clear placeholder text when the TextBox is focused
        If TextBox1.Text = placeholderTextUsername Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        ' Show placeholder text if the TextBox is empty
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.Text = placeholderTextUsername
            TextBox1.ForeColor = shadowColor
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Make sure placeholder text is only shown when the box is empty
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.ForeColor = shadowColor
        Else
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Paint(sender As Object, e As PaintEventArgs) Handles TextBox1.Paint
        ' If TextBox1 is empty, draw shadow placeholder text
        If String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso TextBox1.ForeColor = shadowColor Then
            ' Set the shadow effect
            Dim shadowBrush As New SolidBrush(shadowColor)
            Dim shadowFont As New Font(TextBox1.Font.FontFamily, TextBox1.Font.Size, FontStyle.Italic)
            e.Graphics.DrawString(placeholderTextUsername, shadowFont, shadowBrush, 2, 2) ' Draw shadow slightly off (2,2)

            ' Draw the original placeholder text
            Dim textBrush As New SolidBrush(TextBox1.ForeColor)
            e.Graphics.DrawString(placeholderTextUsername, TextBox1.Font, textBrush, 0, 0) ' Draw original text (0,0)
        End If
    End Sub

    ' Similar code for TextBox2 (Password)

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        ' Clear placeholder text when the TextBox is focused
        If TextBox2.Text = placeholderTextPassword Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        ' Show placeholder text if the TextBox is empty
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            TextBox2.Text = placeholderTextPassword
            TextBox2.ForeColor = shadowColor
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ' Make sure placeholder text is only shown when the box is empty
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            TextBox2.ForeColor = shadowColor
        Else
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_Paint(sender As Object, e As PaintEventArgs) Handles TextBox2.Paint
        ' If TextBox2 is empty, draw shadow placeholder text
        If String.IsNullOrWhiteSpace(TextBox2.Text) AndAlso TextBox2.ForeColor = shadowColor Then
            ' Set the shadow effect
            Dim shadowBrush As New SolidBrush(shadowColor)
            Dim shadowFont As New Font(TextBox2.Font.FontFamily, TextBox2.Font.Size, FontStyle.Italic)
            e.Graphics.DrawString(placeholderTextPassword, shadowFont, shadowBrush, 2, 2) ' Draw shadow slightly off (2,2)

            ' Draw the original placeholder text
            Dim textBrush As New SolidBrush(TextBox2.ForeColor)
            e.Graphics.DrawString(placeholderTextPassword, TextBox2.Font, textBrush, 0, 0) ' Draw original text (0,0)
        End If
    End Sub

    ' FingerprintScanner class definition

    ' Simulated method for scanning a fingerprint
    Public Function Scan() As String
        ' Code to interact with your fingerprint scanner and return the scanned fingerprint ID as a string
        ' Replace this with the actual fingerprint scanning code
        Return "sample_fingerprint_id" ' This is just a placeholder for demonstration
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Declare variables for tracking login attempts and cooldown
        Dim failedAttempts As Integer = 0
        Dim lastFailedAttempt As DateTime = DateTime.MinValue

        ' Get the Firebase client
        Dim ref As IFirebaseClient = FirebaseModule.GetFirebaseClient()

        ' Retrieve the data from Firebase
        Dim accountData As FirebaseResponse = ref.Get("AdminTbl/Account")

        ' Check if accountData is not null and contains data
        If accountData IsNot Nothing AndAlso Not String.IsNullOrEmpty(accountData.Body) Then
            ' Deserialize the JSON data into a Dictionary
            Dim accountDict As Dictionary(Of String, Object) = accountData.ResultAs(Of Dictionary(Of String, Object))()

            ' Check if password exists in the data
            If accountDict.ContainsKey("password") Then
                Dim storedPassword As String = accountDict("password").ToString()

                ' Check if either email or username matches and password matches
                If (accountDict.ContainsKey("email") AndAlso TextBox1.Text = accountDict("email").ToString()) OrElse
           (accountDict.ContainsKey("username") AndAlso TextBox1.Text = accountDict("username").ToString()) Then

                    If TextBox2.Text = storedPassword Then
                        ' Reset failed attempts after successful login
                        failedAttempts = 0
                        ' Success, login is successful
                        MessageBox.Show("Login successful!")
                        Dim former As New Main_Dashboard
                        former.username = TextBox1.Text
                        former.Show()
                    Else
                        ' Increment failed attempts if password is incorrect
                        failedAttempts += 1

                        ' Check if failed attempts exceed 5
                        If failedAttempts >= 5 Then
                            ' Check the cooldown time
                            If DateTime.Now.Subtract(lastFailedAttempt).TotalMinutes >= 5 Then
                                ' Allow login after cooldown period
                                failedAttempts = 0 ' Reset attempts
                                MessageBox.Show("You can try logging in again.")
                            Else
                                ' Deny login and show cooldown message
                                MessageBox.Show("Too many failed attempts. Please wait 5 minutes before trying again.")
                            End If
                        Else
                            ' Error, wrong password
                            MessageBox.Show("Invalid password.")
                        End If
                    End If

                Else
                    ' Error, wrong username or email
                    MessageBox.Show("Invalid username or email.")
                End If

            Else
                ' Error, account data is incomplete (missing password)
                MessageBox.Show("Account data is incomplete.")
            End If

        Else
            ' Error, account data not found or is empty
            MessageBox.Show("Account data not found.")
        End If

        ' Store the timestamp of the last failed attempt
        If failedAttempts >= 5 Then
            lastFailedAttempt = DateTime.Now
        End If

    End Sub
End Class