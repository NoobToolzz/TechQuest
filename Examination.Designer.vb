<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Examination
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
        lblStatus = New Label()
        lblQuestion = New Label()
        lblAnswerA = New Label()
        lblAnswerB = New Label()
        lblAnswerC = New Label()
        lblAnswerD = New Label()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(2, 158)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(0, 15)
        lblStatus.TabIndex = 1
        ' 
        ' lblQuestion
        ' 
        lblQuestion.AutoSize = True
        lblQuestion.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point)
        lblQuestion.Location = New Point(250, 9)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(91, 28)
        lblQuestion.TabIndex = 2
        lblQuestion.Text = "Question"
        ' 
        ' lblAnswerA
        ' 
        lblAnswerA.AutoSize = True
        lblAnswerA.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblAnswerA.Location = New Point(12, 72)
        lblAnswerA.Name = "lblAnswerA"
        lblAnswerA.Size = New Size(22, 15)
        lblAnswerA.TabIndex = 3
        lblAnswerA.Text = "A) "
        ' 
        ' lblAnswerB
        ' 
        lblAnswerB.AutoSize = True
        lblAnswerB.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblAnswerB.Location = New Point(320, 72)
        lblAnswerB.Name = "lblAnswerB"
        lblAnswerB.Size = New Size(21, 15)
        lblAnswerB.TabIndex = 4
        lblAnswerB.Text = "B) "
        ' 
        ' lblAnswerC
        ' 
        lblAnswerC.AutoSize = True
        lblAnswerC.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblAnswerC.Location = New Point(12, 122)
        lblAnswerC.Name = "lblAnswerC"
        lblAnswerC.Size = New Size(22, 15)
        lblAnswerC.TabIndex = 5
        lblAnswerC.Text = "C) "
        ' 
        ' lblAnswerD
        ' 
        lblAnswerD.AutoSize = True
        lblAnswerD.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblAnswerD.Location = New Point(319, 122)
        lblAnswerD.Name = "lblAnswerD"
        lblAnswerD.Size = New Size(22, 15)
        lblAnswerD.TabIndex = 6
        lblAnswerD.Text = "D) "
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' Examination
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(606, 173)
        Controls.Add(lblAnswerD)
        Controls.Add(lblAnswerC)
        Controls.Add(lblAnswerB)
        Controls.Add(lblAnswerA)
        Controls.Add(lblQuestion)
        Controls.Add(lblStatus)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Examination"
        Text = "TechQuest: Examination"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents lblAnswerA As Label
    Friend WithEvents lblAnswerB As Label
    Friend WithEvents lblAnswerC As Label
    Friend WithEvents lblAnswerD As Label
    Friend WithEvents Timer1 As Timer
End Class
