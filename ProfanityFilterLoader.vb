Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ProfanityFilterLoader
    Private profanityFilter As List(Of String)

    Public Async Function LoadProfanityFilter() As Task
        Using client As New HttpClient()
            Try
                Dim response As String = Await client.GetStringAsync("https://raw.githubusercontent.com/zacanger/profane-words/refs/heads/master/words.json")
                profanityFilter = JsonConvert.DeserializeObject(Of List(Of String))(response)
            Catch ex As Exception
                Throw New Exception($"Error loading profanity filter: {ex.Message}")
            End Try
        End Using
    End Function

    Public Function GetProfanityFilter() As List(Of String)
        Return profanityFilter
    End Function

    Public Function ContainsProfanity(username As String) As Boolean
        For Each word In profanityFilter
            If username.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return True
            End If
        Next
        Return False
    End Function
End Class
