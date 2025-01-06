
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response

Public Class add_new_rate
    Public Property Designation As String
    Public Property Rate As String

    Private Sub add_new_rate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "Position"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate ComboBox selection
            If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
                MessageBox.Show("Please select a category from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get Firebase client
            Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

            ' Path for the calculations section with dynamic ComboBox1 selection
            Dim path As String = $"AdminTbl/Calculations/{ComboBox1.Text}"

            ' Create the data to be added (position as key and rate as value)
            Dim addData As New Dictionary(Of String, String) From {
            {TextBox1.Text, TextBox2.Text}  ' Add the designation (TextBox1) with the rate (TextBox2)
        }

            ' Use Update to add data without removing existing ones
            Dim response As FireSharp.Response.FirebaseResponse = client.Update(path, addData)

            ' Handle the response
            If response.StatusCode = System.Net.HttpStatusCode.OK Then
                MessageBox.Show("Rate successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to add rate to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Designation" Then
            Label1.Text = "Designation"
            Label2.Text = "Rate per Unit"
        Else
            Label1.Text = "Position"
            Label2.Text = "Fixed Rate"
        End If
    End Sub
End Class