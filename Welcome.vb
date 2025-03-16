Public Class welcome
    Private server As SimpleHttpServer
    Private markdownText As String
    Public Shared userName As String

    Dim webViewChecker As New WebViewChecker()
    Private profanityFilterLoader As New ProfanityFilterLoader()
    Private profanityFilter As List(Of String) = New List(Of String)()

    Private Async Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check and install WebView2 runtime (if it doesn't exist)
        Dim isWebViewInstalled As Boolean = Await webViewChecker.CheckAndInstall()

        If Not isWebViewInstalled Then
            ' If WebView2 is not installed, the application will exit from within WebViewChecker
            Return
        End If

        ' Start the HTTP server on port 8081
        server = New SimpleHttpServer(8081)
        server.Start("welcomePage", "", "") ' 2 empty values since they are meant for the results page

        ' Fetch and load the profanity filter
        Await LoadProfanityFilter()
    End Sub

    Private Async Function LoadProfanityFilter() As Task
        Try
            Await profanityFilterLoader.LoadProfanityFilter()
            profanityFilter = profanityFilterLoader.GetProfanityFilter()
        Catch ex As Exception
            MessageBox.Show($"Error loading profanity filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnInstructions_Click(sender As Object, e As EventArgs) Handles btnInstructions.Click
        Dim webViewForm As New WebViewForm("http://localhost:8081/")
        AddHandler webViewForm.FormClosing, AddressOf WebView_FormClosing
        webViewForm.Show()
    End Sub

    Private Sub WebView_FormClosing(sender As Object, e As FormClosingEventArgs)
        lblInstructs.Text = "Before we begin, please enter your name:"
        btnInstructions.Visible = False : txtUsername.Visible = True
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        server.Stop()

        ' Hide the Welcome form
        Me.Hide()

        ' Show the Examination form
        Dim examForm As New Examination()
        examForm.Show()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrWhiteSpace(txtUsername.Text) Then
                MessageBox.Show("Please enter a username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                userName = txtUsername.Text.Trim()

                ' Check for profane words using the ProfanityFilterLoader instance
                If profanityFilterLoader.ContainsProfanity(userName) Then
                    MessageBox.Show("Don't include profane words in your username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    lblInstructs.Text = $"Hello, {userName}! Press the button below to begin!" : txtUsername.Visible = False : btnStart.Visible = True
                End If
            End If
        End If
    End Sub
End Class
