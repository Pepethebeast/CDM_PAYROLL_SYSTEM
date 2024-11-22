<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class brute_foce_password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(brute_foce_password))
        TableLayoutPanel1 = New TableLayoutPanel()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        Label5 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        Label1 = New Label()
        TableLayoutPanel2 = New TableLayoutPanel()
        Label2 = New Label()
        Button1 = New Button()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.White
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65F))
        TableLayoutPanel1.Controls.Add(TextBox3, 1, 2)
        TableLayoutPanel1.Controls.Add(TextBox2, 1, 1)
        TableLayoutPanel1.Controls.Add(Label5, 0, 2)
        TableLayoutPanel1.Controls.Add(Label3, 0, 0)
        TableLayoutPanel1.Controls.Add(Label4, 0, 1)
        TableLayoutPanel1.Controls.Add(TextBox1, 1, 0)
        TableLayoutPanel1.Location = New Point(14, 143)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Size = New Size(436, 142)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.None
        TextBox3.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox3.Location = New Point(155, 103)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(278, 30)
        TextBox3.TabIndex = 10
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox2.Location = New Point(155, 55)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(278, 30)
        TextBox2.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(6, 108)
        Label5.Name = "Label5"
        Label5.Size = New Size(139, 19)
        Label5.TabIndex = 7
        Label5.Text = "Confirm Password"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(49, 14)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 19)
        Label3.TabIndex = 3
        Label3.Text = "Email:"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(34, 61)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 19)
        Label4.TabIndex = 4
        Label4.Text = "Password:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Font = New Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(155, 8)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(278, 30)
        TextBox1.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Roboto Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(37, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(362, 28)
        Label1.TabIndex = 1
        Label1.Text = "Force change email and password"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.BackColor = Color.Transparent
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(Label2, 0, 1)
        TableLayoutPanel2.Controls.Add(Label1, 0, 0)
        TableLayoutPanel2.Location = New Point(14, 25)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(436, 100)
        TableLayoutPanel2.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Roboto Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Maroon
        Label2.Location = New Point(190, 61)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 28)
        Label2.TabIndex = 2
        Label2.Text = "UID:"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Location = New Point(178, 291)
        Button1.Name = "Button1"
        Button1.Size = New Size(272, 47)
        Button1.TabIndex = 3
        Button1.Text = "SAVE"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' brute_foce_password
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(462, 363)
        Controls.Add(Button1)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        Name = "brute_foce_password"
        StartPosition = FormStartPosition.CenterScreen
        Text = "brute_foce_password"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
