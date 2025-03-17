<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExamResults
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
        Label1 = New Label()
        lblResults = New Label()
        lblMessage = New Label()
        lblInformClickButton = New Label()
        btnLeaderboard = New Button()
        btnExit = New Button()
        btnRetry = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Comic Sans MS", 14F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(13, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(425, 27)
        Label1.TabIndex = 0
        Label1.Text = "Congratulations! You've completed the exam!"
        ' 
        ' lblResults
        ' 
        lblResults.AutoSize = True
        lblResults.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point)
        lblResults.Location = New Point(12, 48)
        lblResults.Name = "lblResults"
        lblResults.Size = New Size(0, 28)
        lblResults.TabIndex = 1
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point)
        lblMessage.Location = New Point(12, 87)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(0, 28)
        lblMessage.TabIndex = 2
        ' 
        ' lblInformClickButton
        ' 
        lblInformClickButton.AutoSize = True
        lblInformClickButton.Font = New Font("Comic Sans MS", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lblInformClickButton.Location = New Point(12, 133)
        lblInformClickButton.Name = "lblInformClickButton"
        lblInformClickButton.Size = New Size(440, 19)
        lblInformClickButton.TabIndex = 3
        lblInformClickButton.Text = "Click the button below to check out your score on the leaderboard!"
        ' 
        ' btnLeaderboard
        ' 
        btnLeaderboard.Font = New Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point)
        btnLeaderboard.Location = New Point(12, 165)
        btnLeaderboard.Name = "btnLeaderboard"
        btnLeaderboard.Size = New Size(426, 38)
        btnLeaderboard.TabIndex = 4
        btnLeaderboard.Text = "To the leaderboard!"
        btnLeaderboard.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        btnExit.Location = New Point(396, 165)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(42, 38)
        btnExit.TabIndex = 5
        btnExit.Text = "⟳"
        btnExit.UseVisualStyleBackColor = True
        btnExit.Visible = False
        ' 
        ' btnRetry
        ' 
        btnRetry.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        btnRetry.Location = New Point(348, 165)
        btnRetry.Name = "btnRetry"
        btnRetry.Size = New Size(42, 38)
        btnRetry.TabIndex = 6
        btnRetry.Text = CStr(ChrW(9211))
        btnRetry.UseVisualStyleBackColor = True
        btnRetry.Visible = False
        ' 
        ' ExamResults
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(450, 215)
        Controls.Add(btnRetry)
        Controls.Add(btnExit)
        Controls.Add(btnLeaderboard)
        Controls.Add(lblInformClickButton)
        Controls.Add(lblMessage)
        Controls.Add(lblResults)
        Controls.Add(Label1)
        MaximizeBox = False
        Name = "ExamResults"
        Text = "Results"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblResults As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblInformClickButton As Label
    Friend WithEvents btnLeaderboard As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRetry As Button
End Class
