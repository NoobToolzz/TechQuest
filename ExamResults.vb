Public Class ExamResults
    Private server As SimpleHttpServer
    Private htmlText As String
    Private leaderboardHtmlText As String

    Private Sub ExamResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Convert this to HTML table format
        Dim results As String = "Results:" & Environment.NewLine
        htmlText = "<table><thead><tr><th>Question</th><th>Your Answer</th><th>Correct Answer</th></tr></thead><tbody>"

        For i As Integer = 0 To Examination.correctAnswersList.Count - 1
            htmlText &= $"<tr><td>{Examination.questions(i).Text}</td><td>{Examination.selectedAnswersList(i)}</td><td>{Examination.correctAnswersList(i)}</td></tr>"
        Next

        htmlText &= "</tbody></table>"

        ' Generate leaderboard HTML
        leaderboardHtmlText = "<table><thead><tr><th>Position</th><th>Name</th><th>Score</th></tr></thead><tbody>"
        Dim random As New Random()
        Dim userScore As Integer = Examination.correctQuestions
        Dim leaderboardEntries As New List(Of (String, Integer))()

        Dim fakeUsernames As String() = {
            "EpicGamer123", "NoobSlayer", "SniperWolf", "ShadowHunter", "DragonFury",
            "NinjaWarrior", "GhostRider", "ThunderStrike", "VortexViper", "PixelProwler",
            "StealthAssassin", "FrostByte", "CyberKnight", "BlazeStorm", "RogueAgent"
        }

        ' Generate 14 unique fake names and random scores
        Dim usedNames As New HashSet(Of String)()
        Dim usedScores As New HashSet(Of Integer)()

        For i As Integer = 1 To 14
            Dim fakeName As String
            Dim fakeScore As Integer

            ' Make sure it's a unique fake name and score (no dupes)
            Do
                fakeName = fakeUsernames(random.Next(0, fakeUsernames.Length))
            Loop While usedNames.Contains(fakeName)
            usedNames.Add(fakeName)

            Do
                fakeScore = random.Next(0, Examination.questions.Length + 1)
            Loop While usedScores.Contains(fakeScore)
            usedScores.Add(fakeScore)

            leaderboardEntries.Add((fakeName, fakeScore))
        Next

        ' Add user's score to the leaderboard
        leaderboardEntries.Add(($"You", userScore))

        ' Sort the leaderboard by score in descending order
        leaderboardEntries = leaderboardEntries.OrderByDescending(Function(entry) entry.Item2).ToList()

        ' Build the leaderboard HTML with positions
        For position As Integer = 0 To leaderboardEntries.Count - 1
            Dim entry = leaderboardEntries(position)
            leaderboardHtmlText &= $"<tr><td>{position + 1}</td><td>{entry.Item1}</td><td>{entry.Item2}</td></tr>"
        Next

        leaderboardHtmlText &= "</tbody></table>"

        lblResults.Text = $"You got {Examination.correctQuestions} out of {Examination.questions.Length} questions correct!"
        ' Depending on how many questions were answered correctly, display a different message
        If Examination.correctQuestions = Examination.questions.Length Then
            ' If the user got all the questions correct
            lblMessage.Text = "Congratulations! You got all the questions correct!"
        ElseIf Examination.correctQuestions >= Math.Ceiling(Examination.questions.Length / 2.0) Then
            ' If the user got at least half of the questions correct (rounded to nearest whole number)
            lblMessage.Text = "Good job! You got most of the questions correct!"
        Else
            ' If the user got less than half of the questions correct
            lblMessage.Text = "Keep practicing! You can do better next time!"
        End If
    End Sub

    Private Sub btnLeaderboard_Click(sender As Object, e As EventArgs) Handles btnLeaderboard.Click
        server = New SimpleHttpServer(8081)
        server.Start("resultPage", htmlText, leaderboardHtmlText)

        Dim webViewForm As New WebViewForm("http://localhost:8081/")
        'AddHandler webViewForm.FormClosing, AddressOf WebView_FormClosing
        webViewForm.Show()
    End Sub

    Private Sub WebView_FormClosing(sender As Object, e As FormClosingEventArgs)
        'lblInstructs.Text = "Before we begin, please enter your name:"
        'btnInstructions.Visible = False : txtUsername.Visible = True
    End Sub
End Class
