Imports Newtonsoft.Json
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports System.Net

Public Class calculations
    Private Sub calculations_Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Main_Dashboard.Show()
    End Sub
    Private Sub calculations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFirebaseData()
        ComboBox1.Text = "Designation"
    End Sub

    Private Sub LoadFirebaseData()
        ' Retrieve data from Firebase
        Dim Json As IFirebaseClient = FirebaseModule.GetFirebaseClient
        Dim jsonData = Json.Get("AdminTbl/Calculations")

        ' Parse the JSON data into a dictionary
        Dim calculations As Dictionary(Of String, Object) =
        Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonData.Body)

        ' Convert ETL and Instructors data to dictionaries
        Dim etlData As Dictionary(Of String, Object) =
        CType(calculations("Position"), Newtonsoft.Json.Linq.JObject).ToObject(Of Dictionary(Of String, Object))()
        Dim instructorsData As Dictionary(Of String, Object) =
        CType(calculations("Designation"), Newtonsoft.Json.Linq.JObject).ToObject(Of Dictionary(Of String, Object))()

        ' Clear existing data and columns in DataGridView1
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.AllowUserToAddRows = False

        ' Check the ComboBox selection and display data accordingly
        If ComboBox1.Text = "Designation" Then
            ' Configure DataGridView1 for Instructors
            ConfigureDataGridView(DataGridView1, "Designation")
            AddDataToDataGridView(DataGridView1, instructorsData)

        ElseIf ComboBox1.Text = "Position" Then
            ' Configure DataGridView1 for ETL
            ConfigureDataGridView(DataGridView1, "Position")
            AddDataToDataGridView(DataGridView1, etlData)
        End If
    End Sub

    Private Sub ConfigureDataGridView(dgv As DataGridView, roleColumnHeader As String)
        ' Add common columns (Role, Rate, etc.)
        dgv.Columns.Add("Role", roleColumnHeader)
        dgv.Columns.Add("Rate", "Rate per Unit")

        ' Add action buttons for Edit, Delete, and Add
        Dim editButtonColumn As New DataGridViewButtonColumn()
        editButtonColumn.Name = "EditButtonColumn"
        editButtonColumn.Text = "Edit"
        editButtonColumn.UseColumnTextForButtonValue = True
        dgv.Columns.Add(editButtonColumn)

        Dim deleteButtonColumn As New DataGridViewButtonColumn()
        deleteButtonColumn.Name = "DeleteButtonColumn"
        deleteButtonColumn.Text = "Delete"
        deleteButtonColumn.UseColumnTextForButtonValue = True
        dgv.Columns.Add(deleteButtonColumn)

        Dim addButtonColumn As New DataGridViewButtonColumn()
        addButtonColumn.Name = "AddButtonColumn"
        addButtonColumn.Text = "Add"
        addButtonColumn.UseColumnTextForButtonValue = True
        dgv.Columns.Add(addButtonColumn)

        ' Set the column width to auto-fill for non-action columns
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Explicitly set the width of action columns (Edit, Delete, Add) to the same size
        dgv.Columns("EditButtonColumn").Width = 50
        dgv.Columns("DeleteButtonColumn").Width = 50
        dgv.Columns("AddButtonColumn").Width = 80

        ' Set the header for the action buttons to be merged into one "Actions" header
        dgv.Columns("EditButtonColumn").HeaderText = "Actions"
        dgv.Columns("DeleteButtonColumn").HeaderText = "Actions"
        dgv.Columns("AddButtonColumn").HeaderText = "Actions"

        ' Apply style to the DataGridView
        dgv.EnableHeadersVisualStyles = False ' Disable the default header style
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Green ' Set header background color to green
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White ' Set header text color to white
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold) ' Set header font to bold
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Center-align header text

        ' Set data grid style for rows
        dgv.RowsDefaultCellStyle.BackColor = Color.LightGray ' Set row background color
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke ' Set alternating row colors
        dgv.RowsDefaultCellStyle.Font = New Font("Arial", 10) ' Set row font size
        dgv.RowsDefaultCellStyle.ForeColor = Color.Black ' Set row text color
        dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Center-align row text

        ' Set a fixed row height
        dgv.RowTemplate.Height = 40

        ' Set the grid line color
        dgv.GridColor = Color.Gray
        dgv.BorderStyle = BorderStyle.None ' Make border less prominent

        ' Attach the CellPainting event to customize button background color
        AddHandler dgv.CellPainting, AddressOf dgv_CellPainting
    End Sub

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        ' Check if it's a button column cell (Edit, Delete, Add)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            If dgv.Columns(e.ColumnIndex).Name = "EditButtonColumn" OrElse
           dgv.Columns(e.ColumnIndex).Name = "DeleteButtonColumn" OrElse
           dgv.Columns(e.ColumnIndex).Name = "AddButtonColumn" Then

                ' Set the button color based on button text
                If dgv.Columns(e.ColumnIndex).Name = "EditButtonColumn" Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightGreen), e.CellBounds)
                ElseIf dgv.Columns(e.ColumnIndex).Name = "DeleteButtonColumn" Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightCoral), e.CellBounds)
                ElseIf dgv.Columns(e.ColumnIndex).Name = "AddButtonColumn" Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightGoldenrodYellow), e.CellBounds)
                End If

                ' Draw the button text in the center
                TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

                ' Draw a black border around the button
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), e.CellBounds)

                ' Mark the event as handled
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub AddDataToDataGridView(dgv As DataGridView, data As Dictionary(Of String, Object))
        ' Loop through the data and populate the DataGridView
        For Each entry In data
            ' Add the role and rate as row data, assuming the data is structured this way
            Dim role As String = entry.Key
            Dim rate As String = entry.Value.ToString()
            dgv.Rows.Add(role, rate, "Edit", "Delete", "Add")
        Next
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Reload data based on ComboBox selection
        LoadFirebaseData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = DataGridView1.Columns("EditButtonColumn").Index Then
                ' Toggle between "Edit" and "Cancel"
                Dim actionButton = DataGridView1.Rows(e.RowIndex).Cells("EditButtonColumn")

                If actionButton.Value.ToString() = "Edit" Then
                    ' Enable editing for the "Rate" column
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").ReadOnly = False

                    ' Change background color of the "Rate" column to make it obvious
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Style.BackColor = Color.DarkSeaGreen
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Style.ForeColor = Color.Black

                    ' Change the button text to "Cancel"
                    actionButton.Value = "Cancel"

                    ' Begin editing the "Rate" column
                    DataGridView1.BeginEdit(True)

                ElseIf actionButton.Value.ToString() = "Cancel" Then
                    ' Revert the "Rate" column to read-only
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").ReadOnly = True

                    ' Reset the background color of the "Rate" column
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Style.BackColor = Color.White
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Style.ForeColor = Color.Black

                    ' Change the button text back to "Edit"
                    actionButton.Value = "Edit"
                End If

            ElseIf e.ColumnIndex = DataGridView1.Columns("DeleteButtonColumn").Index Then
                ' Handle Delete button click
                Dim role As String = DataGridView1.Rows(e.RowIndex).Cells("Role").Value.ToString()
                Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete the role '{role}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )
                If result = DialogResult.Yes Then
                    Try
                        ' Replace this with your actual deletion logic
                        DeleteFromDatabase(role)

                        ' Remove the row from the DataGridView after deletion
                        DataGridView1.Rows.RemoveAt(e.RowIndex)

                        MessageBox.Show("Role deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show($"Failed to delete role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If

            ElseIf e.ColumnIndex = DataGridView1.Columns("AddButtonColumn").Index Then
                add_new_rate.Show()
            End If
        End If
    End Sub
    Private Sub DeleteFromDatabase(role As String)
        Dim client As IFirebaseClient = FirebaseModule.GetFirebaseClient

        Dim response = client.Delete($"AdminTbl/Calculations/{ComboBox1.Text}/{role}") ' Example path
        If response.StatusCode <> HttpStatusCode.OK Then
            Throw New Exception("Failed to delete from Firebase.")
        End If
    End Sub
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Dim cell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If String.IsNullOrEmpty(cell.Value?.ToString()) Then
            cell.Value = "Type here..." ' Placeholder text
            cell.Style.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Rate").Index Then
            ' Save the updated value to Firebase
            Dim role As String = DataGridView1.Rows(e.RowIndex).Cells("Role").Value.ToString()
            Dim updatedRate As String = DataGridView1.Rows(e.RowIndex).Cells("Rate").Value.ToString()


            Try
                Dim Json As IFirebaseClient = FirebaseModule.GetFirebaseClient
                Dim path As String = $"AdminTbl/Calculations/{ComboBox1.Text}/"

                ' Update Firebase with the new rate
                Dim updatedEntry = New Dictionary(Of String, Object) From {
                {role, updatedRate}
            }
                Json.Update(path, updatedEntry)

                MessageBox.Show($"Rate updated successfully for '{role}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show($"An error occurred while saving the updated rate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Lock the cell again after editing
            DataGridView1.Rows(e.RowIndex).Cells("Rate").ReadOnly = True
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        ' Open the Add New form
        Dim addForm As New add_new_rate()
        If addForm.ShowDialog() = DialogResult.OK Then
            ' Retrieve data from the form
            Dim designation As String = addForm.Designation
            Dim rate As String = addForm.Rate

            ' Save the new entry to Firebase
            Try
                Dim Json As IFirebaseClient = FirebaseModule.GetFirebaseClient
                Dim newEntry = New Dictionary(Of String, Object) From {
                    {designation, rate}
                }
                Json.Update("AdminTbl/Calculations", newEntry)

                MessageBox.Show($"New entry '{designation}' added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the DataGridViews
                LoadFirebaseData()
            Catch ex As Exception
                MessageBox.Show($"An error occurred while adding the entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
