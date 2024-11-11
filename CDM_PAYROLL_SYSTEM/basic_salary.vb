Public Class basic_salary
    Public Property received_email As String
    Public Property user_uid As String
    Public Property add_employee_id As String
    Public Property received_name As String
    Public Property description As String
    Public Property designation As String
    Public Property no_ofUnits As String
    Public Property position As String
    Private Sub basic_salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = add_employee_id
        Label11.Text = received_name
        Label13.Text = received_email
        Label5.Text = position
        Label12.Text = designation
        Label8.Text = description
        Label13.Text = no_ofUnits
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
        ' Define the border color and width
        Dim borderColor As Color = Color.Black
        Dim borderWidth As Integer = 2

        ' Draw a rectangle as the border around the TableLayoutPanel
        Using borderPen As New Pen(borderColor, borderWidth)
            Dim rect As New Rectangle(0, 0, TableLayoutPanel1.Width - 1, TableLayoutPanel1.Height - 1)
            e.Graphics.DrawRectangle(borderPen, rect)
        End Using
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint
        ' Define the border color and width
        Dim borderColor As Color = Color.Black
        Dim borderWidth As Integer = 2

        ' Draw a rectangle as the border around the TableLayoutPanel
        Using borderPen As New Pen(borderColor, borderWidth)
            Dim rect As New Rectangle(0, 0, TableLayoutPanel1.Width - 1, TableLayoutPanel1.Height - 1)
            e.Graphics.DrawRectangle(borderPen, rect)
        End Using
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint
        ' Define the border color and width
        Dim borderColor As Color = Color.Black
        Dim borderWidth As Integer = 2

        ' Draw a rectangle as the border around the TableLayoutPanel
        Using borderPen As New Pen(borderColor, borderWidth)
            Dim rect As New Rectangle(0, 0, TableLayoutPanel1.Width - 1, TableLayoutPanel1.Height - 1)
            e.Graphics.DrawRectangle(borderPen, rect)
        End Using
    End Sub

    Private Sub TableLayoutPanel4_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel4.Paint
        Dim borderColor = Color.Black
        Dim borderWidth = 2

        ' Draw a rectangle as the border around the TableLayoutPanel
        Using borderPen As New Pen(borderColor, borderWidth)
            Dim rect As New Rectangle(0, 0, TableLayoutPanel1.Width - 1, TableLayoutPanel1.Height - 1)
            e.Graphics.DrawRectangle(borderPen, rect)
        End Using
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class