Public Class WebViewForm
    Inherits Form

    Private webView As Microsoft.Web.WebView2.WinForms.WebView2

    Public Sub New(url As String)
        InitializeComponent()
        InitializeWebView(url)
    End Sub

    Private Sub InitializeComponent()
        Me.webView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.SuspendLayout()

        ' webView
        Me.webView.Dock = DockStyle.Fill
        Me.webView.Location = New Point(0, 0)
        Me.webView.Name = "webView"
        Me.webView.Size = New Size(800, 450)
        Me.webView.TabIndex = 0

        ' WebView Form
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ClientSize = New Size(800, 450) ' You can keep this or remove it
        Me.Controls.Add(Me.webView)
        Me.Name = "WebViewForm"
        Me.ResumeLayout(False)

        ' Set the form to maximized
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Async Sub InitializeWebView(url As String)
        Await webView.EnsureCoreWebView2Async(Nothing)
        webView.CoreWebView2.Navigate(url)
        ' Show vertical scroll bar and hide the horizontal one IF the content on the page is too big
        Await webView.ExecuteScriptAsync("document.body.style.overflowY = 'auto'; document.body.style.overflowX = 'hidden';")
    End Sub
End Class
