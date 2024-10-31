<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RFID_Based_Attendance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RFID_Based_Attendance))
        Label1 = New Label()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label8 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        txtRFIDInput = New TextBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(248, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(267, 25)
        Label1.TabIndex = 0
        Label1.Text = "RFID BASED ATTENDANCE"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.DarkSeaGreen
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(785, 53)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(41, 123)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(292, 252)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.5714283F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 71.42857F))
        TableLayoutPanel1.Controls.Add(Label8, 0, 6)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(Label3, 0, 1)
        TableLayoutPanel1.Controls.Add(Label4, 0, 2)
        TableLayoutPanel1.Controls.Add(Label5, 0, 3)
        TableLayoutPanel1.Controls.Add(Label6, 0, 4)
        TableLayoutPanel1.Controls.Add(Label7, 0, 5)
        TableLayoutPanel1.Controls.Add(txtRFIDInput, 1, 0)
        TableLayoutPanel1.Location = New Point(354, 81)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 7
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857113F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857151F))
        TableLayoutPanel1.Size = New Size(380, 364)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Dock = DockStyle.Fill
        Label8.Font = New Font("Roboto", 9.75F)
        Label8.Location = New Point(3, 311)
        Label8.Name = "Label8"
        Label8.Size = New Size(102, 53)
        Label8.TabIndex = 4
        Label8.Text = "Time Out:"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Roboto", 9.75F)
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(102, 51)
        Label2.TabIndex = 0
        Label2.Text = "Employee ID:"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Roboto", 9.75F)
        Label3.Location = New Point(3, 51)
        Label3.Name = "Label3"
        Label3.Size = New Size(102, 52)
        Label3.TabIndex = 1
        Label3.Text = "Name:"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Roboto", 9.75F)
        Label4.Location = New Point(3, 103)
        Label4.Name = "Label4"
        Label4.Size = New Size(102, 52)
        Label4.TabIndex = 2
        Label4.Text = "Department:"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Roboto", 9.75F)
        Label5.Location = New Point(3, 155)
        Label5.Name = "Label5"
        Label5.Size = New Size(102, 52)
        Label5.TabIndex = 3
        Label5.Text = "Designation:"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Roboto", 9.75F)
        Label6.Location = New Point(3, 207)
        Label6.Name = "Label6"
        Label6.Size = New Size(102, 52)
        Label6.TabIndex = 4
        Label6.Text = "Date:"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Dock = DockStyle.Fill
        Label7.Font = New Font("Roboto", 9.75F)
        Label7.Location = New Point(3, 259)
        Label7.Name = "Label7"
        Label7.Size = New Size(102, 52)
        Label7.TabIndex = 5
        Label7.Text = "Time In:"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' txtRFIDInput
        ' 
        txtRFIDInput.Location = New Point(111, 3)
        txtRFIDInput.Name = "txtRFIDInput"
        txtRFIDInput.Size = New Size(174, 23)
        txtRFIDInput.TabIndex = 6
        ' 
        ' RFID_Based_Attendance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(787, 561)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(PictureBox1)
        Controls.Add(Panel1)
        Name = "RFID_Based_Attendance"
        StartPosition = FormStartPosition.CenterScreen
        Text = "RFID_Based_Attendance"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRFIDInput As TextBox
End Class
