<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Info
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Info))
        TableLayoutPanel3 = New TableLayoutPanel()
        Label3 = New Label()
        Label2 = New Label()
        Label18 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        Label14 = New Label()
        Label11 = New Label()
        TextBox1 = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        TableLayoutPanel3.Controls.Add(Label3, 1, 0)
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Controls.Add(Label18, 0, 3)
        TableLayoutPanel3.Controls.Add(Label1, 1, 3)
        TableLayoutPanel3.Controls.Add(Button1, 1, 2)
        TableLayoutPanel3.Controls.Add(Label14, 0, 2)
        TableLayoutPanel3.Controls.Add(Label11, 0, 1)
        TableLayoutPanel3.Controls.Add(TextBox1, 1, 1)
        TableLayoutPanel3.Location = New Point(12, 85)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 4
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.Size = New Size(423, 299)
        TableLayoutPanel3.TabIndex = 50
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(210, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(129, 22)
        Label3.TabIndex = 52
        Label3.Text = "Super Admin"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(24, 27)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 19)
        Label2.TabIndex = 51
        Label2.Text = "Admin ID:"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label18
        ' 
        Label18.Anchor = AnchorStyles.None
        Label18.AutoSize = True
        Label18.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.Location = New Point(41, 251)
        Label18.Margin = New Padding(4, 0, 4, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(44, 19)
        Label18.TabIndex = 15
        Label18.Text = "Role:"
        Label18.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(210, 249)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 22)
        Label1.TabIndex = 50
        Label1.Text = "Super Admin"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Location = New Point(159, 167)
        Button1.Name = "Button1"
        Button1.Size = New Size(230, 35)
        Button1.TabIndex = 49
        Button1.Text = "Register"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.Location = New Point(18, 175)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(89, 19)
        Label14.TabIndex = 8
        Label14.Text = "Fingerprint:"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(35, 101)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(55, 19)
        Label11.TabIndex = 47
        Label11.Text = "Name:"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(153, 99)
        TextBox1.Margin = New Padding(4, 3, 4, 3)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(242, 23)
        TextBox1.TabIndex = 48
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(184, 36)
        Label4.Name = "Label4"
        Label4.Size = New Size(80, 22)
        Label4.TabIndex = 53
        Label4.Text = "Admin1"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Roboto Medium", 26.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(387, 17)
        Label5.Name = "Label5"
        Label5.Size = New Size(48, 46)
        Label5.TabIndex = 54
        Label5.Text = "↩"
        ' 
        ' Admin_Info
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(447, 396)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(TableLayoutPanel3)
        FormBorderStyle = FormBorderStyle.None
        Name = "Admin_Info"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin_Info"
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
