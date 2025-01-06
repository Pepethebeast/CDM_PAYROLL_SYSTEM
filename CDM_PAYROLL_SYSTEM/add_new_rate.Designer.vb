<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_new_rate
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Label3 = New Label()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        Label1 = New Label()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label3, 0, 0)
        TableLayoutPanel1.Controls.Add(ComboBox1, 1, 0)
        TableLayoutPanel1.Controls.Add(Label2, 0, 2)
        TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        TableLayoutPanel1.Controls.Add(TextBox2, 1, 2)
        TableLayoutPanel1.Controls.Add(TextBox1, 1, 1)
        TableLayoutPanel1.Location = New Point(12, 6)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Size = New Size(565, 189)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(82, 21)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 21)
        Label3.TabIndex = 5
        Label3.Text = "Title Selector"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Designation", "Position"})
        ComboBox1.Location = New Point(300, 20)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(247, 23)
        ComboBox1.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(30, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(222, 21)
        Label2.TabIndex = 4
        Label2.Text = "Rate per Unit / Fixed Rate"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(131, 84)
        Label1.Name = "Label1"
        Label1.Size = New Size(20, 21)
        Label1.TabIndex = 3
        Label1.Text = "0"
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Location = New Point(300, 146)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(246, 23)
        TextBox2.TabIndex = 1
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Location = New Point(299, 83)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(248, 23)
        TextBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.DarkSeaGreen
        Button1.Location = New Point(596, 62)
        Button1.Name = "Button1"
        Button1.Size = New Size(116, 35)
        Button1.TabIndex = 2
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = Color.Red
        Button2.Location = New Point(596, 105)
        Button2.Name = "Button2"
        Button2.Size = New Size(116, 35)
        Button2.TabIndex = 3
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' add_new_rate
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(724, 207)
        Controls.Add(Button2)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Button1)
        Name = "add_new_rate"
        StartPosition = FormStartPosition.CenterScreen
        Text = "add_new_rate"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
