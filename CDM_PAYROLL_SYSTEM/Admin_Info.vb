Imports DocumentFormat.OpenXml.Bibliography
Imports DocumentFormat.OpenXml.Vml
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class Admin_Info
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
        Main_Dashboard.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        register_fingerprint.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Check if the passwords match
        If TextBox2.Text <> TextBox4.Text Then
            MessageBox.Show("Password does not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' If passwords match, proceed with saving the data
            Dim PD As New PersonalData With {
            .name = TextBox3.Text,
            .email = TextBox1.Text,
            .password = TextBox2.Text
        }

            Try
                Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient()

                ' Attempt to save the data
                Dim admin_save = client.Set("AdminTbl/Account", PD)

                ' Check if the response is valid (if client.Set doesn't throw an error)
                If admin_save IsNot Nothing Then
                    MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to save data to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                ' Handle any exceptions that occur during the process
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Toggle the enabled state of the textboxes
        Dim isEnabled As Boolean = Not TextBox1.Enabled

        TextBox1.Enabled = isEnabled
        TextBox2.Enabled = isEnabled
        TextBox3.Enabled = isEnabled
        TextBox4.Enabled = isEnabled
    End Sub

    Private Sub Admin_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Disable the textboxes when the form loads
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
    End Sub
End Class