<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class welcome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Label1 = New Label()
        lblInstructs = New Label()
        btnInstructions = New Button()
        btnStart = New Button()
        txtUsername = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Comic Sans MS", 16F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(549, 31)
        Label1.TabIndex = 0
        Label1.Text = "Welcome to the TechQuest: Knowledge Challenge!"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblInstructs
        ' 
        lblInstructs.AutoSize = True
        lblInstructs.Font = New Font("Comic Sans MS", 14F, FontStyle.Regular, GraphicsUnit.Point)
        lblInstructs.Location = New Point(3, 54)
        lblInstructs.Name = "lblInstructs"
        lblInstructs.Size = New Size(497, 26)
        lblInstructs.TabIndex = 1
        lblInstructs.Text = "Here's a quick rundown of what you're going to expect."
        ' 
        ' btnInstructions
        ' 
        btnInstructions.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnInstructions.Location = New Point(3, 85)
        btnInstructions.Name = "btnInstructions"
        btnInstructions.Size = New Size(549, 54)
        btnInstructions.TabIndex = 2
        btnInstructions.Text = "Read the rundown"
        btnInstructions.UseVisualStyleBackColor = True
        ' 
        ' btnStart
        ' 
        btnStart.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnStart.Location = New Point(3, 87)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(549, 54)
        btnStart.TabIndex = 3
        btnStart.Text = "Start"
        btnStart.UseVisualStyleBackColor = True
        btnStart.Visible = False
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(12, 97)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(191, 23)
        txtUsername.TabIndex = 4
        txtUsername.Visible = False
        ' 
        ' welcome
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(558, 149)
        Controls.Add(txtUsername)
        Controls.Add(btnStart)
        Controls.Add(btnInstructions)
        Controls.Add(lblInstructs)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "welcome"
        Text = "Welcome!"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblInstructs As Label
    Friend WithEvents btnInstructions As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents txtUsername As TextBox

End Class
