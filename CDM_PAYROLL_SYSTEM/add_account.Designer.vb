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
        Label8 = New Label()
        Label1 = New Label()
        Label6 = New Label()
        Button2 = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        TextBox6 = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        Label9 = New Label()
        Label7 = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        CheckBox3 = New CheckBox()
        CheckBox2 = New CheckBox()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        Timer1 = New Timer(components)
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
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
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(PictureBox2)
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
        TableLayoutPanel4.Controls.Add(Label8, 0, 1)
        TableLayoutPanel4.Controls.Add(Label1, 0, 0)
        TableLayoutPanel4.Location = New Point(80, 154)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(271, 53)
        TableLayoutPanel4.TabIndex = 11
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Dock = DockStyle.Fill
        Label8.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.InfoText
        Label8.Location = New Point(3, 26)
        Label8.Name = "Label8"
        Label8.Size = New Size(265, 27)
        Label8.TabIndex = 10
        Label8.Text = "Account ID:"
        Label8.TextAlign = ContentAlignment.MiddleCenter
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
        Label1.Size = New Size(265, 26)
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
        Label6.Location = New Point(47, 324)
        Label6.Name = "Label6"
        Label6.Size = New Size(366, 12)
        Label6.TabIndex = 9
        Label6.Text = "Important: Write your Email correctly to get the verification code!"
        Label6.Visible = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.DarkSeaGreen
        Button2.Font = New Font("Roboto Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(198, 441)
        Button2.Name = "Button2"
        Button2.Size = New Size(135, 45)
        Button2.TabIndex = 8
        Button2.Text = "REGISTER"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.BackColor = Color.Transparent
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15F))
        TableLayoutPanel3.Controls.Add(TextBox6, 1, 0)
        TableLayoutPanel3.Controls.Add(Label5, 0, 0)
        TableLayoutPanel3.Controls.Add(Button1, 2, 0)
        TableLayoutPanel3.Location = New Point(3, 388)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(411, 47)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' TextBox6
        ' 
        TextBox6.Anchor = AnchorStyles.None
        TextBox6.Location = New Point(146, 12)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(199, 23)
        TextBox6.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Roboto", 11.25F)
        Label5.ForeColor = SystemColors.InfoText
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(137, 47)
        Label5.TabIndex = 3
        Label5.Text = "Verification Code:"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Dock = DockStyle.Fill
        Button1.Font = New Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(351, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(57, 41)
        Button1.TabIndex = 3
        Button1.Text = "SEND"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Arial Rounded MT Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Maroon
        Label9.Location = New Point(57, 272)
        Label9.Name = "Label9"
        Label9.Size = New Size(366, 12)
        Label9.TabIndex = 6
        Label9.Text = "Important: Write your Email correctly to get the verification code!"
        Label9.Visible = False
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
        TableLayoutPanel2.Controls.Add(CheckBox3, 2, 2)
        TableLayoutPanel2.Controls.Add(CheckBox2, 2, 1)
        TableLayoutPanel2.Controls.Add(TextBox3, 1, 2)
        TableLayoutPanel2.Controls.Add(TextBox2, 1, 1)
        TableLayoutPanel2.Controls.Add(Label2, 0, 0)
        TableLayoutPanel2.Controls.Add(Label3, 0, 1)
        TableLayoutPanel2.Controls.Add(Label4, 0, 2)
        TableLayoutPanel2.Controls.Add(TextBox1, 1, 0)
        TableLayoutPanel2.Location = New Point(3, 232)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel2.Size = New Size(411, 156)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' CheckBox3
        ' 
        CheckBox3.AutoSize = True
        CheckBox3.BackColor = Color.Transparent
        CheckBox3.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox3.Dock = DockStyle.Fill
        CheckBox3.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox3.ForeColor = Color.Black
        CheckBox3.Location = New Point(351, 107)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(57, 46)
        CheckBox3.TabIndex = 11
        CheckBox3.Text = "👁️"
        CheckBox3.TextAlign = ContentAlignment.MiddleCenter
        CheckBox3.UseVisualStyleBackColor = False
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.BackColor = Color.Transparent
        CheckBox2.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox2.Dock = DockStyle.Fill
        CheckBox2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox2.ForeColor = Color.Black
        CheckBox2.Location = New Point(351, 55)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(57, 46)
        CheckBox2.TabIndex = 10
        CheckBox2.Text = "👁️"
        CheckBox2.TextAlign = ContentAlignment.MiddleCenter
        CheckBox2.UseVisualStyleBackColor = False
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.None
        TextBox3.Location = New Point(146, 118)
        TextBox3.Name = "TextBox3"
        TextBox3.PasswordChar = "*"c
        TextBox3.Size = New Size(199, 23)
        TextBox3.TabIndex = 8
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(146, 66)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.Size = New Size(199, 23)
        TextBox2.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Roboto", 11.25F)
        Label2.ForeColor = SystemColors.InfoText
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(137, 52)
        Label2.TabIndex = 3
        Label2.Text = "Email Address:"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Roboto", 11.25F)
        Label3.ForeColor = SystemColors.InfoText
        Label3.Location = New Point(3, 52)
        Label3.Name = "Label3"
        Label3.Size = New Size(137, 52)
        Label3.TabIndex = 4
        Label3.Text = "Password:"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Roboto", 11.25F)
        Label4.ForeColor = SystemColors.InfoText
        Label4.Location = New Point(3, 104)
        Label4.Name = "Label4"
        Label4.Size = New Size(137, 52)
        Label4.TabIndex = 5
        Label4.Text = "Confirm Password:"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(146, 14)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(199, 23)
        TextBox1.TabIndex = 6
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
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
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
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
End Class
