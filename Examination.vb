Public Class Examination
    ' Structure to hold question data
    Public Structure Question
        Public Text As String ' The question
        Public Answers As String() ' The available answers for the question
        Public CorrectAnswerIndex As Integer ' Whether the correct answer is A, B, C or D respectively as integers
    End Structure

    ' Array of questions
    Public Shared questions As Question() = {
        New Question With {.Text = "What does CPU stand for?", .Answers = New String() {"A) Central Processing Unit", "B) Computer Personal Unit", "C) Central Power Unit", "D) Computer Processing Unit"}, .CorrectAnswerIndex = 0},
        New Question With {.Text = "Which company developed the PlayStation console?", .Answers = New String() {"A) Microsoft", "B) Nintendo", "C) Sony", "D) Sega"}, .CorrectAnswerIndex = 2},
        New Question With {.Text = "What is the primary function of an operating system?", .Answers = New String() {"A) To run applications", "B) To manage hardware and software resources", "C) To provide internet access", "D) To store files"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "Which of the following is a popular programming language?", .Answers = New String() {"A) HTML", "B) JPEG", "C) Python", "D) MP3"}, .CorrectAnswerIndex = 2},
        New Question With {.Text = "What is the name of the virtual reality headset developed by Oculus?", .Answers = New String() {"A) Vive", "B) Rift", "C) Quest", "D) HoloLens"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "Which game is known as the 'Battle Royale' phenomenon?", .Answers = New String() {"A) Minecraft", "B) Fortnite", "C) The Sims", "D) Tetris"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "What does Wi-Fi stand for?", .Answers = New String() {"A) Wireless Fidelity", "B) Wide Fidelity", "C) Wireless Frequency", "D) Wide Frequency"}, .CorrectAnswerIndex = 0},
        New Question With {.Text = "Which of the following is a cloud storage service?", .Answers = New String() {"A) Google Drive", "B) Microsoft Word", "C) Adobe Photoshop", "D) VLC Media Player"}, .CorrectAnswerIndex = 0},
        New Question With {.Text = "What is the main purpose of a graphics card?", .Answers = New String() {"A) To store data", "B) To process images and videos", "C) To connect to the internet", "D) To manage sound output"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "Which of the following is a popular mobile operating system?", .Answers = New String() {"A) Windows", "B) Android", "C) Linux", "D) DOS"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "What is the term for a computer program that replicates itself?", .Answers = New String() {"A) Virus", "B) Malware", "C) Trojan", "D) Worm"}, .CorrectAnswerIndex = 0},
        New Question With {.Text = "Which gaming console is known for its motion-sensing capabilities?", .Answers = New String() {"A) Xbox 360", "B) PlayStation 4", "C) Nintendo Wii", "D) Sega Genesis"}, .CorrectAnswerIndex = 2},
        New Question With {.Text = "What is the primary purpose of a firewall?", .Answers = New String() {"A) To speed up internet connection", "B) To protect a network from unauthorized access", "C) To store files securely", "D) To enhance graphics performance"}, .CorrectAnswerIndex = 1},
        New Question With {.Text = "Which of the following is a popular online gaming platform?", .Answers = New String() {"A) Steam", "B) Epic Games", "C) Ubisoft Connect", "D) All of the above"}, .CorrectAnswerIndex = 3},
        New Question With {.Text = "What does the term 'open source' refer to?", .Answers = New String() {"A) Software that is free to use and modify", "B) Software that is only available for purchase", "C) Software that is only for personal use", "D) Software that isn't compatible with other programs"}, .CorrectAnswerIndex = 0}
    }

    Private currentQuestionIndex As Integer = 0 ' Integer to represent what question we are on, e.g. q1, q2, q3 so I can pull the respective question and answer from the array list
    Public Shared correctQuestions As Integer = 0
    Public Shared totalQuestions As Integer = 0

    ' These are the lists that'll be gathered at the end to compare results in the final page
    Public Shared correctAnswersList As New List(Of String)()
    Public Shared selectedAnswersList As New List(Of String)()

    Private Sub Examination_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.Text = $"Logged in as: {welcome.userName} | Question 1/{questions.Length}"
        LoadQuestion(currentQuestionIndex)
    End Sub

    Private Sub Label_MouseHover(sender As Object, e As EventArgs) Handles lblAnswerA.MouseEnter, lblAnswerB.MouseEnter, lblAnswerC.MouseEnter, lblAnswerD.MouseEnter, lblAnswerA.MouseLeave, lblAnswerB.MouseLeave, lblAnswerC.MouseLeave, lblAnswerD.MouseLeave
        ' Change the cursor to a hand when hovering over the answer labels, and back to default when leaving
        If TypeOf e Is MouseEventArgs AndAlso DirectCast(e, MouseEventArgs).Button = MouseButtons.None Then
            Cursor = If(sender Is lblAnswerA OrElse sender Is lblAnswerB OrElse sender Is lblAnswerC OrElse sender Is lblAnswerD, Cursors.Hand, Cursors.Default)
        End If
    End Sub

    Private Sub LoadQuestion(index As Integer)
        Dim question As Question = questions(index)
        lblQuestion.Text = question.Text
        lblQuestion.TextAlign = ContentAlignment.MiddleCenter

        ' Center lblQuestion at the top of the form
        lblQuestion.Left = (Me.ClientSize.Width - lblQuestion.Width) \ 2
        lblQuestion.Top = 10 ' Set a fixed distance from the top

        ' Set the answers for the question
        lblAnswerA.Text = question.Answers(0)
        lblAnswerB.Text = question.Answers(1)
        lblAnswerC.Text = question.Answers(2)
        lblAnswerD.Text = question.Answers(3)

        ResetAnswerColors()
    End Sub

    Private Sub ResetAnswerColors()
        ' Reset the answer colors to the default color
        lblAnswerA.ForeColor = SystemColors.ControlText
        lblAnswerB.ForeColor = SystemColors.ControlText
        lblAnswerC.ForeColor = SystemColors.ControlText
        lblAnswerD.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub lblAnswer_Click(sender As Object, e As EventArgs) Handles lblAnswerA.Click, lblAnswerB.Click, lblAnswerC.Click, lblAnswerD.Click
        ' This is to determine which answer was selected
        Dim selectedLabel As Label = DirectCast(sender, Label)
        Dim selectedAnswerIndex As Integer = -1 ' Placeholder value

        If selectedLabel Is lblAnswerA Then
            selectedAnswerIndex = 0
        ElseIf selectedLabel Is lblAnswerB Then
            selectedAnswerIndex = 1
        ElseIf selectedLabel Is lblAnswerC Then
            selectedAnswerIndex = 2
        ElseIf selectedLabel Is lblAnswerD Then
            selectedAnswerIndex = 3
        End If

        CheckAnswer(selectedAnswerIndex)
    End Sub

    ' This is to determine if the selected answer is correct or not
    Private Sub CheckAnswer(selectedIndex As Integer)
        Dim question As Question = questions(currentQuestionIndex)

        ' Store the selected answer
        selectedAnswersList.Add(question.Answers(selectedIndex))

        If selectedIndex = question.CorrectAnswerIndex Then
            ' If the answer is correct, highlight it in green
            DirectCast(Me.Controls($"lblAnswer{Chr(65 + selectedIndex)}"), Label).ForeColor = Color.Green
            correctAnswersList.Add(question.Answers(question.CorrectAnswerIndex))
        Else
            ' If the answer is incorrect, highlight the selected answer in red and the correct answer in green
            DirectCast(Me.Controls($"lblAnswer{Chr(65 + selectedIndex)}"), Label).ForeColor = Color.Red
            DirectCast(Me.Controls($"lblAnswer{Chr(65 + question.CorrectAnswerIndex)}"), Label).ForeColor = Color.Green
            correctAnswersList.Add(question.Answers(question.CorrectAnswerIndex))
        End If

        currentQuestionIndex += 1 ' Move to the next question

        ' Check if there are more questions
        If currentQuestionIndex < questions.Length Then
            lblStatus.Text = $"Logged in as: {welcome.userName} | Question {currentQuestionIndex + 1}/{questions.Length}"
            Timer1.Start() ' Wait 1 second before loading the next question
        Else
            ' Hide the Examination and show the post-exam form
            Me.Hide()

            Dim resultsForm As New ExamResults()
            resultsForm.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        LoadQuestion(currentQuestionIndex)
    End Sub
End Class
