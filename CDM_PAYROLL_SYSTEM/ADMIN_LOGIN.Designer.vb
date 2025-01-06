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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADMIN_LOGIN))
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox1 = New PictureBox()
        Timer1 = New Timer(components)
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(PictureBox3)
        Panel1.ForeColor = SystemColors.Window
        Panel1.Location = New Point(428, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(420, 546)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.Transparent
        TableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80F))
        TableLayoutPanel2.Controls.Add(TextBox1, 0, 0)
        TableLayoutPanel2.Controls.Add(TextBox2, 0, 1)
        TableLayoutPanel2.Controls.Add(Button1, 0, 2)
        TableLayoutPanel2.Location = New Point(26, 211)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.Size = New Size(367, 195)
        TableLayoutPanel2.TabIndex = 7
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(54, 17)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(259, 30)
        TextBox1.TabIndex = 5
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox2.Location = New Point(53, 81)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.Size = New Size(261, 30)
        TextBox2.TabIndex = 6
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(65, 140)
        Button1.Name = "Button1"
        Button1.Size = New Size(237, 43)
        Button1.TabIndex = 8
        Button1.Text = "LOG-IN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.InfoText
        Label1.Location = New Point(106, 170)
        Label1.Name = "Label1"
        Label1.Size = New Size(210, 21)
        Label1.TabIndex = 2
        Label1.Text = "PAYROLL ADMIN LOG-IN"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(127, 9)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(175, 135)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.None
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(167, 421)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(104, 94)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
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
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox3 As PictureBox
End Class
