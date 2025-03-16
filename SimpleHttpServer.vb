Imports System.Net
Imports System.Text
Imports System.Threading

Public Class SimpleHttpServer
    Private listener As HttpListener
    Private port As Integer
    Private cts As CancellationTokenSource

    Public Sub New(port As Integer)
        Me.port = port
        listener = New HttpListener()
        listener.Prefixes.Add($"http://localhost:{port}/")
        cts = New CancellationTokenSource()
    End Sub

    Public Async Sub Start(pageType As String, htmlText As String, leaderboardHtmlText As String)
        listener.Start()
        Dim html As String


        ' welcomePage does not need any input text but resultPage does.
        If pageType = "welcomePage" Then
            html = $"<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Welcome to TechQuest!</title> <style> body {{ font-family: Arial, sans-serif; background: linear-gradient(to right, #4e54c8, #8f94fb); color: #333; margin: 0; padding: 0; display: flex; justify-content: center; align-items: center; height: 100vh; overflow: hidden; }} .container {{ display: flex; background: rgba(255, 255, 255, 0.8); border-radius: 15px; box-shadow: 0 8px 30px rgba(0, 0, 0, 0.3); padding: 30px; max-width: 1100px; margin: 20px; opacity: 0; transform: translateY(-20px); animation: fadeInUp 0.8s forwards; }} .notification {{ position: fixed; top: 20px; right: -300px; background: linear-gradient(to right, #ff7e5f, #feb47b); color: white; padding: 15px 20px; border-radius: 10px; box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2); display: flex; align-items: center; z-index: 1000; opacity: 0; transition: right 1s ease, opacity 1s ease; }} @keyframes slideIn {{ from {{ right: -300px; opacity: 0; }} to {{ right: 20px; opacity: 1; }} }} .icon {{ font-size: 2em; margin-right: 15px; }} .notification-content {{ display: flex; flex-direction: column; }} .notification-content h3 {{ margin: 0; font-size: 1.2em; }} @keyframes fadeInUp {{ to {{ opacity: 1; transform: translateY(0); }} }} .left-section {{ flex: 1; padding-right: 20px; text-align: left; }} .right-section {{ flex: 1; padding-left: 20px; text-align: left; }} .instruction-pairs {{ display: flex; justify-content: space-between; margin-bottom: 20px; }} .instruction-pair {{ flex: 1; margin-right: 10px; }} .instruction-pair:last-child {{ margin-right: 0; }} .center {{ text-align: center; margin-top: 20px; }} h1 {{ font-size: 2.5em; margin-bottom: 20px; color: #4e54c8; }} h2 {{ font-size: 1.5em; margin: 20px 0; color: #333; }} p {{ font-size: 1.1em; line-height: 1.6; margin: 10px 0; }} .emoji {{ font-size: 1.2em; }} .highlight {{ font-weight: bold; color: #4e54c8; }} .divider {{ width: 2px; background-color: #4e54c8; margin: 0 20px; height: auto; box-shadow: 0 0 10px rgba(0, 0, 0, 0.2); }} </style></head><body> <div id='notification' class='notification'> <div class='icon'>🛈</div> <div class='notification-content'> <h3>Hey there!</h3> <p>When you're done reading, close this window to continue the program.</p> </div> </div> <div class='container'> <div class='left-section'> <h1>Welcome to TechQuest! 🎮</h1> <p>Thank you for joining us on this exciting journey to test your knowledge of <span class='highlight'>technology</span> and <span class='highlight'>gaming</span>! 🚀</p> <p>In <span class='highlight'>TechQuest</span>, you'll face a series of questions designed to challenge your understanding of:</p> <p class='emoji'>- The latest trends 📈</p> <p class='emoji'>- Classic games 🎮</p> <p class='emoji'>- Essential tech concepts 💻</p> <p>Whether you're a <span class='highlight'>casual gamer</span> or a <span class='highlight'>tech enthusiast</span>, this challenge is perfect for you! 🌟</p> </div> <div class='divider'></div> <div class='right-section'> <h2>Instructions 📚</h2> <div class='instruction-pairs'> <div class='instruction-pair'> <p><span class='highlight'>Getting Started</span>: 🏁 When you first launch the app, you will see a welcome screen (you're already seeing it!). Simply enter a username to track your progress.</p> </div> <div class='instruction-pair'> <p><span class='highlight'>Navigating the App</span>: 🧭 After entering your username, you will immediately begin the examination process, diving straight into the challenge without any additional instructions.</p> </div> </div> <div class='instruction-pairs'> <div class='instruction-pair'> <p><span class='highlight'>Taking the Challenge</span>: 📝 Click the 'Start' button to begin the examination. You will be presented with a series of questions. Read each question carefully and select your answer.</p> </div> <div class='instruction-pair'> <p><span class='highlight'>Scoring and Feedback</span>: 📊 After completing the challenge, you will receive your score along with feedback on your performance. You can review the questions you answered correctly.</p> </div> </div> <div class='instruction-pair center'> <p><span class='highlight'>Compete and Share</span>: 🏆 Feel free to share your scores with friends and challenge them to beat your results! 🎉</p> </div> <p>We hope you enjoy the TechQuest: Knowledge Challenge and learn something new along the way! Good luck! 🍀</p> </div></body><script> window.onload = function() {{ setTimeout(function() {{ document.getElementById('notification').style.opacity = '1'; document.getElementById('notification').style.right = '20px'; }}, 2000); }};</script></html>"
        ElseIf pageType = "resultPage" Then
            If String.IsNullOrEmpty(htmlText) Or String.IsNullOrEmpty(leaderboardHtmlText) Then
                Throw New ArgumentException("HTML text must be provided for resultPage")
            End If
            html = $"<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>TechQuest Results</title> <style> body {{ font-family: Arial, sans-serif; background: linear-gradient(to right, #4e54c8, #8f94fb); color: #333; margin: 0; padding: 0; display: flex; justify-content: center; align-items: center; height: 100vh; overflow: hidden; }} .container {{ display: flex; flex-direction: column; background: rgba(255, 255, 255, 0.8); border-radius: 15px; box-shadow: 0 8px 30px rgba(0, 0, 0, 0.3); padding: 30px; max-width: 2000px; margin: 20px; opacity: 0; transform: translateY(-20px); animation: fadeInUp 0.8s forwards; }} .header {{ font-size: 2em; color: #4e54c8; text-align: center; margin: 0; }} .horizontal-divider {{ width: 100%; height: 2px; background-color: #4e54c8; margin: 5px 0; }} .content {{ display: flex; margin-top: 20px; }} .divider {{ width: 2px; background-color: #4e54c8; margin: 0 20px; height: auto; box-shadow: 0 0 10px rgba(0, 0, 0, 0.2); }} @keyframes fadeInUp {{ to {{ opacity: 1; transform: translateY(0); }} }} .left-section {{ flex: 1; padding-right: 20px; text-align: left; }} .right-section {{ flex: 1; padding-left: 20px; text-align: left; }} h2 {{ font-size: 1.5em; margin: 20px 0; color: #333; }} p {{ font-size: 1.1em; line-height: 1.6; margin: 10px 0; }} .highlight {{ font-weight: bold; color: #4e54c8; }} table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }} th, td {{ border: 1px solid #4e54c8; padding: 10px; text-align: left; }} th {{ background-color: #4e54c8; color: white; }} </style></head><body> <div class='container'> <h1 class='header'>TechQuest Global Statistics</h1> <div class='horizontal-divider'></div> <div class='content'> <div class='left-section'> <h2>Your Results</h2> {htmlText} </div> <div class='divider'></div> <div class='right-section'> <h2>Global Leaderboard</h2> {leaderboardHtmlText} </div> </div> </div></body></html>"
        Else
            Throw New ArgumentException("Invalid page type")
        End If

        Try
            While Not cts.Token.IsCancellationRequested
                Dim context As HttpListenerContext = Await listener.GetContextAsync()
                Dim response As HttpListenerResponse = context.Response
                Dim buffer As Byte() = Encoding.UTF8.GetBytes(html)
                response.ContentLength64 = buffer.Length
                Dim output As System.IO.Stream = response.OutputStream
                Await output.WriteAsync(buffer, 0, buffer.Length)
                output.Close()
            End While
        Catch ex As HttpListenerException
            ' Handle the exception if the listener is stopped (app closed)
            If Not cts.Token.IsCancellationRequested Then
                Throw
            End If
        Finally
            listener.Stop()
        End Try
    End Sub

    Public Sub [Stop]()
        cts.Cancel() ' Signal cancellation
        listener.Stop() ' Stop the listener
    End Sub
End Class
