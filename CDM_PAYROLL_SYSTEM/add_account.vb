Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Text
Imports Newtonsoft.Json
Imports Firebase.Auth
Imports Firebase.Database
Imports Firebase.Database.Query
Imports System.Threading.Tasks
Imports Firebase.Auth.Providers
Imports FireSharp.Config
Imports FireSharp.Interfaces

Public Class add_account

    Public FirebaseApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs" ' Replace with your Firebase API key

    Private firebaseAuthProvider As FirebaseAuthClient

    Public Sub InitializeFirebase()
        Dim config = New FirebaseAuthConfig() With {
        .ApiKey = FirebaseApiKey,
        .AuthDomain = "" ' Optional: only if you have one
    }

        ' Initialize the providers
        config.Providers = New FirebaseAuthProvider() {
        New EmailProvider()}
        ' You can add other providers here if needed, like GoogleProvider or FacebookProvider


        firebaseAuthProvider = New FirebaseAuthClient(config)
    End Sub

    ' Firebase configuration
    Private Const FirebaseAuthUrl As String = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Private Const ApiKey As String = "AIzaSyCo7k9JfcuPnIheEF36U-rgtiOMYNtSCZs"
    Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@pnm\.edu\.ph$"
    Dim inputPattern As String = "^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"
    Dim firebaseclient As IFirebaseClient = FirebaseModule.GetFirebaseClient()
    ' Corrected code to initialize FirebaseAuthProvider
    Dim authProvider As FirebaseAuthProvider

    ' Hash password using SHA256
    Public Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' Form load event
    Private Sub add_account_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim firebaseclient As IFirebaseClient = FirebaseModule.GetFirebaseClient()
        Catch
            MessageBox.Show("There was a problem connecting to Firebase.")
        End Try

    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(nametextbox.Text) OrElse
       String.IsNullOrWhiteSpace(emailtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(passwordtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(confirmpasswordtextbox.Text) OrElse
       String.IsNullOrWhiteSpace(employee_id_textbox.Text) Then
            MessageBox.Show("Please fill all required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf passwordtextbox.Text <> confirmpasswordtextbox.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(emailtextbox.Text, emailPattern) Then
            MessageBox.Show("Please use email format: @pnm.edu.ph", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(passwordtextbox.Text, inputPattern) Then
            MessageBox.Show("Please use a strong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            Dim email As String = emailtextbox.Text
            Dim password As String = passwordtextbox.Text

            Dim client As New HttpClient()
            Dim requestUri As String = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}"
            Dim jsonPayload = JsonConvert.SerializeObject(New With {
            .email = email,
            .password = password,
            .returnSecureToken = True
        })

            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Try
                Dim response = Await client.PostAsync(requestUri, content)
                If response.IsSuccessStatusCode Then
                    Dim resultJson = Await response.Content.ReadAsStringAsync()
                    Dim resultData = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(resultJson)
                    Dim uid = resultData("localId")
                    MessageBox.Show("Account created successfully!")

                    ' Hash the password
                    Dim passwordhasher = HashPassword(passwordtextbox.Text)

                    ' Prepare the personal data object
                    Dim now As DateTime = DateTime.UtcNow
                    Dim unixTimestamp As Long = CLng((now - New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds)
                    Dim nanoSeconds As Integer = now.Millisecond * 1000000  ' Convert milliseconds to nanoseconds

                    Dim PD As New PersonalData With {
                    .firstName = nametextbox.Text,
                    .lastName = TextBox1.Text,
                    .email = email,
                    .password = passwordhasher,
                    .createdAt = New PersonalData.CreatedAte With {
                        .nanoseconds = nanoSeconds,
                        .seconds = unixTimestamp
                    },
                    .employeeID = employee_id_textbox.Text
                }

                    ' Save the data to Firebase
                    Dim save = firebaseclient.Set("usersTbl/" + uid, PD)


                    ' Send verification email
                    Dim verificationUri As String = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={ApiKey}"
                    Dim verificationPayload = JsonConvert.SerializeObject(New With {
                    .requestType = "VERIFY_EMAIL",
                    .idToken = resultData("idToken")
                })

                    Dim verificationContent As New StringContent(verificationPayload, Encoding.UTF8, "application/json")
                    Dim verificationResponse = Await client.PostAsync(verificationUri, verificationContent)

                    If verificationResponse.IsSuccessStatusCode Then
                        MessageBox.Show("Verification email sent. Please check your inbox.")
                    Else
                        Dim verificationErrorJson = Await verificationResponse.Content.ReadAsStringAsync()
                        Dim verificationErrorData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(verificationErrorJson)
                        Dim errorMessage As String = verificationErrorData("error")("message").ToString()
                        MessageBox.Show("Error sending verification email: " & errorMessage)
                        Debug.WriteLine("Verification email error: " & errorMessage) ' Log the error
                    End If

                    ' Proceed to RFID registration
                    Dim rfidregisteruid As New register_rfid
                    rfidregisteruid.UserUID = uid
                    rfidregisteruid.Show()
                    Me.Close()
                    ClearFields() ' Call a separate method to clear fields

                Else
                    Dim errorJson = Await response.Content.ReadAsStringAsync()
                    Dim errorData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(errorJson)
                    MessageBox.Show("Error: " & errorData("error")("message").ToString())
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            Return
        End If
    End Sub


    Private Sub ClearFields()
        emailtextbox.Clear()
        passwordtextbox.Clear()
        confirmpasswordtextbox.Clear()
        nametextbox.Clear()
        employee_id_textbox.Clear() ' Also clear employee ID textbox
    End Sub

    Private Sub nametextbox_TextChanged(sender As Object, e As EventArgs) Handles nametextbox.TextChanged

    End Sub

    Private Sub emailtextbox_TextChanged(sender As Object, e As EventArgs) Handles emailtextbox.TextChanged

        ' Check if the input matches the required email pattern
        If System.Text.RegularExpressions.Regex.IsMatch(emailtextbox.Text, emailPattern) Then
            Label9.Visible = False
        Else
            Label9.Text = "Email must be in the format: username@pnm.edu.ph"
            Label9.ForeColor = Color.Maroon
            Label9.Visible = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox3.Checked = True Then
            confirmpasswordtextbox.PasswordChar = ""
        Else
            confirmpasswordtextbox.PasswordChar = "*"
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            passwordtextbox.PasswordChar = ""
        Else
            passwordtextbox.PasswordChar = "*"
        End If
    End Sub

    Private Sub passwordtextbox_TextChanged(sender As Object, e As EventArgs) Handles passwordtextbox.TextChanged

        If System.Text.RegularExpressions.Regex.IsMatch(passwordtextbox.Text, inputPattern) Then
            Label6.Visible = False
        Else
            Label6.Text = "Password must contain Number, Capslock and Special Characters."
            Label6.ForeColor = Color.Maroon
            Label6.Visible = True
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Close()
        Employee_Dashboard.Show()
    End Sub
End Class
