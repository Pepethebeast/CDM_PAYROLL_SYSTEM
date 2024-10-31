<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADMIN_LOGIN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADMIN_LOGIN))
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Button1 = New Button()
        Label1 = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        CheckBox1 = New CheckBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.White
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
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSeaGreen
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(PictureBox2)
        Panel1.ForeColor = SystemColors.Window
        Panel1.Location = New Point(428, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(420, 546)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Controls.Add(Button1, 0, 0)
        TableLayoutPanel3.Location = New Point(137, 328)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(202, 52)
        TableLayoutPanel3.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkCyan
        Button1.Font = New Font("Roboto Medium", 9.75F, FontStyle.Bold)
        Button1.Location = New Point(3, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(196, 46)
        Button1.TabIndex = 3
        Button1.Text = "LOG-IN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.InfoText
        Label1.Location = New Point(149, 162)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 21)
        Label1.TabIndex = 2
        Label1.Text = "ADMIN LOG-IN"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.Transparent
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.8644981F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 57.31978F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 11.8157225F))
        TableLayoutPanel2.Controls.Add(CheckBox1, 2, 1)
        TableLayoutPanel2.Controls.Add(TextBox2, 1, 1)
        TableLayoutPanel2.Controls.Add(Label2, 0, 0)
        TableLayoutPanel2.Controls.Add(Label3, 0, 1)
        TableLayoutPanel2.Controls.Add(TextBox1, 1, 0)
        TableLayoutPanel2.Location = New Point(3, 205)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(414, 117)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.BackgroundImageLayout = ImageLayout.Stretch
        CheckBox1.Dock = DockStyle.Fill
        CheckBox1.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox1.ForeColor = Color.Black
        CheckBox1.Location = New Point(367, 61)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(44, 53)
        CheckBox1.TabIndex = 5
        CheckBox1.Text = "👁️"
        CheckBox1.TextAlign = ContentAlignment.MiddleCenter
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(135, 76)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.Size = New Size(220, 23)
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
        Label2.Size = New Size(121, 58)
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
        Label3.Location = New Point(3, 58)
        Label3.Name = "Label3"
        Label3.Size = New Size(121, 59)
        Label3.TabIndex = 4
        Label3.Text = "Password:"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(135, 17)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(220, 23)
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
        ' ADMIN_LOGIN
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSeaGreen
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(851, 552)
        Controls.Add(TableLayoutPanel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.SizableToolWindow
        Margin = New Padding(4, 3, 4, 3)
        Name = "ADMIN_LOGIN"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ADMIN_LOGIN"
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
End Class
