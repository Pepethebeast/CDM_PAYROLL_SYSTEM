<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_account
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_account))
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        TableLayoutPanel4 = New TableLayoutPanel()
        Label1 = New Label()
        Label6 = New Label()
        Button2 = New Button()
        Label7 = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label14 = New Label()
        employee_id_textbox = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        confirmpasswordtextbox = New TextBox()
        CheckBox2 = New CheckBox()
        CheckBox3 = New CheckBox()
        passwordtextbox = New TextBox()
        Label3 = New Label()
        emailtextbox = New TextBox()
        Label2 = New Label()
        Label10 = New Label()
        nametextbox = New TextBox()
        TextBox1 = New TextBox()
        PictureBox2 = New PictureBox()
        Label9 = New Label()
        PictureBox1 = New PictureBox()
        Timer1 = New Timer(components)
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel1, 1, 0)
        TableLayoutPanel1.Controls.Add(PictureBox1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(851, 552)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSeaGreen
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(TableLayoutPanel4)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Label9)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = SystemColors.Window
        Panel1.Location = New Point(428, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(420, 546)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.BackColor = Color.Transparent
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(Label1, 0, 0)
        TableLayoutPanel4.Location = New Point(110, 153)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(193, 27)
        TableLayoutPanel4.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.InfoText
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(187, 27)
        Label1.TabIndex = 2
        Label1.Text = "CREATE ACCOUNT"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Arial Rounded MT Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Maroon
        Label6.Location = New Point(47, 404)
        Label6.Name = "Label6"
        Label6.Size = New Size(91, 12)
        Label6.TabIndex = 9
        Label6.Text = "Password Error"
        Label6.Visible = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.DarkSeaGreen
        Button2.Font = New Font("Roboto Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(178, 463)
        Button2.Name = "Button2"
        Button2.Size = New Size(136, 38)
        Button2.TabIndex = 6
        Button2.Text = "REGISTER"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Roboto Light", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.DarkSlateGray
        Label7.Location = New Point(370, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(47, 46)
        Label7.TabIndex = 5
        Label7.Text = "↩️"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.Transparent
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15F))
        TableLayoutPanel2.Controls.Add(Label14, 0, 2)
        TableLayoutPanel2.Controls.Add(employee_id_textbox, 1, 0)
        TableLayoutPanel2.Controls.Add(Label5, 0, 0)
        TableLayoutPanel2.Controls.Add(Label4, 0, 5)
        TableLayoutPanel2.Controls.Add(confirmpasswordtextbox, 1, 5)
        TableLayoutPanel2.Controls.Add(CheckBox2, 2, 5)
        TableLayoutPanel2.Controls.Add(CheckBox3, 2, 4)
        TableLayoutPanel2.Controls.Add(passwordtextbox, 1, 4)
        TableLayoutPanel2.Controls.Add(Label3, 0, 4)
        TableLayoutPanel2.Controls.Add(emailtextbox, 1, 3)
        TableLayoutPanel2.Controls.Add(Label2, 0, 3)
        TableLayoutPanel2.Controls.Add(Label10, 0, 1)
        TableLayoutPanel2.Controls.Add(nametextbox, 1, 1)
        TableLayoutPanel2.Controls.Add(TextBox1, 1, 2)
        TableLayoutPanel2.Location = New Point(3, 198)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 6
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel2.Size = New Size(411, 259)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.Font = New Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.Black
        Label14.Location = New Point(29, 98)
        Label14.Name = "Label14"
        Label14.Size = New Size(85, 18)
        Label14.TabIndex = 13
        Label14.Text = "Last Name:"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' employee_id_textbox
        ' 
        employee_id_textbox.Anchor = AnchorStyles.None
        employee_id_textbox.Location = New Point(155, 10)
        employee_id_textbox.Name = "employee_id_textbox"
        employee_id_textbox.Size = New Size(180, 23)
        employee_id_textbox.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Font = New Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(23, 12)
        Label5.Name = "Label5"
        Label5.Size = New Size(96, 18)
        Label5.TabIndex = 13
        Label5.Text = "Employee ID:"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto", 11.25F)
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(4, 228)
        Label4.Name = "Label4"
        Label4.Size = New Size(135, 18)
        Label4.TabIndex = 5
        Label4.Text = "Confirm Password:"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' confirmpasswordtextbox
        ' 
        confirmpasswordtextbox.Anchor = AnchorStyles.None
        confirmpasswordtextbox.Location = New Point(155, 225)
        confirmpasswordtextbox.Name = "confirmpasswordtextbox"
        confirmpasswordtextbox.PasswordChar = "*"c
        confirmpasswordtextbox.Size = New Size(180, 23)
        confirmpasswordtextbox.TabIndex = 5
        ' 
        ' CheckBox2
        ' 
        CheckBox2.Anchor = AnchorStyles.None
        CheckBox2.AutoSize = True
        CheckBox2.BackColor = Color.Transparent
        CheckBox2.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox2.ForeColor = Color.Black
        CheckBox2.Location = New Point(354, 223)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(50, 27)
        CheckBox2.TabIndex = 8
        CheckBox2.Text = "👁️"
        CheckBox2.TextAlign = ContentAlignment.MiddleCenter
        CheckBox2.UseVisualStyleBackColor = False
        ' 
        ' CheckBox3
        ' 
        CheckBox3.Anchor = AnchorStyles.None
        CheckBox3.AutoSize = True
        CheckBox3.BackColor = Color.Transparent
        CheckBox3.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox3.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox3.ForeColor = Color.Black
        CheckBox3.Location = New Point(354, 180)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(50, 27)
        CheckBox3.TabIndex = 7
        CheckBox3.Text = "👁️"
        CheckBox3.TextAlign = ContentAlignment.MiddleCenter
        CheckBox3.UseVisualStyleBackColor = False
        ' 
        ' passwordtextbox
        ' 
        passwordtextbox.Anchor = AnchorStyles.None
        passwordtextbox.Location = New Point(155, 182)
        passwordtextbox.Name = "passwordtextbox"
        passwordtextbox.PasswordChar = "*"c
        passwordtextbox.Size = New Size(180, 23)
        passwordtextbox.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Roboto", 11.25F)
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(32, 184)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 18)
        Label3.TabIndex = 4
        Label3.Text = "Password:"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' emailtextbox
        ' 
        emailtextbox.Anchor = AnchorStyles.None
        emailtextbox.Location = New Point(155, 139)
        emailtextbox.Name = "emailtextbox"
        emailtextbox.Size = New Size(180, 23)
        emailtextbox.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Roboto", 11.25F)
        Label2.ForeColor = SystemColors.InfoText
        Label2.Location = New Point(17, 141)
        Label2.Name = "Label2"
        Label2.Size = New Size(109, 18)
        Label2.TabIndex = 3
        Label2.Text = "Email Address:"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.None
        Label10.AutoSize = True
        Label10.Font = New Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(28, 55)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 18)
        Label10.TabIndex = 12
        Label10.Text = "First Name:"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' nametextbox
        ' 
        nametextbox.Anchor = AnchorStyles.None
        nametextbox.Location = New Point(155, 53)
        nametextbox.Name = "nametextbox"
        nametextbox.Size = New Size(180, 23)
        nametextbox.TabIndex = 1
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(155, 96)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(180, 23)
        TextBox1.TabIndex = 2
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(137, 24)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(146, 113)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Arial Rounded MT Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Maroon
        Label9.Location = New Point(50, 362)
        Label9.Name = "Label9"
        Label9.Size = New Size(67, 12)
        Label9.TabIndex = 6
        Label9.Text = "Email error"
        Label9.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.ImageLocation = ""
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(419, 546)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 30000
        ' 
        ' add_account
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(851, 552)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 3, 4, 3)
        Name = "add_account"
        StartPosition = FormStartPosition.CenterScreen
        Text = "add_account"
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents confirmpasswordtextbox As TextBox
    Friend WithEvents passwordtextbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents emailtextbox As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents nametextbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents employee_id_textbox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox1 As TextBox

End Class
