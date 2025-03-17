Imports WebView2.Runtime.AutoInstaller

Public Class WebViewChecker
    ' Check and install WebView2 runtime if not installed
    Public Async Function CheckAndInstall() As Task(Of Boolean)
        Try
            ' Check if WebView2 is already installed
            Dim isInstalled As Boolean = Await WebView2AutoInstaller.CheckAndInstallAsync(True)

            If Not isInstalled Then
                Dim result As DialogResult = MessageBox.Show("WebView2 runtime is required for this application. Would you like to install it now?", "Installation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' If the user agrees, show the WebView2 runtime installer after downloading it
                    Await WebView2AutoInstaller.CheckAndInstallAsync(False, False)
                    MessageBox.Show("Please allow WebView2 to install and restart once it's completed.", "Installation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
                    Return False ' Return false to indicate that the app needs to be restarted
                Else
                    MessageBox.Show("The application cannot run without WebView2. Exiting now.", "Installation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Application.Exit()
                    Return False
                End If
            End If

            Return True ' If WebView2 is alreaddy installed, return true
        Catch ex As Exception
            ' Handle exceptions with checker or installation
            MessageBox.Show($"Error checking or installing WebView2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
