Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogMsg("MS Edge Version: " + CoreWebView2Environment.GetAvailableBrowserVersionString())
    End Sub

    Private Sub LogMsg(msg As String, Optional addTimestamp As Boolean = True)
        'ToDo: add desired code

        If addTimestamp Then
            msg = String.Format("{0} - {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"), msg)
        End If

        Debug.WriteLine(msg)
    End Sub
    Private Sub WebsiteNavigate(ByVal dest As String)
        If WebView21 IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dest) Then

            'URL must start with one of the specified strings
            'if Not, pre-pend with "https://"
            If Not dest = "about:blank" AndAlso
                   Not dest.StartsWith("http://") AndAlso
                   Not dest.StartsWith("https://") AndAlso
                   Not System.Text.RegularExpressions.Regex.IsMatch(dest, "^([A-Z]|[a-z]):") Then

                'set value
                dest = "https://" & dest
            End If

            'option 1
            WebView21.Source = New Uri(dest, UriKind.Absolute)

            'option 2
            'WebView21.CoreWebView2.Navigate(dest)
        End If
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        LogMsg("WebView21_CoreWebView2InitializationCompleted")
        LogMsg("UserDataFolder: " & WebView21.CoreWebView2.Environment.UserDataFolder.ToString())
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        LogMsg("WebView21_NavigationCompleted")
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        LogMsg("WebView21_WebMessageReceived")
    End Sub

    Private Sub WebView21_Click(sender As Object, e As EventArgs) Handles WebView21.Click

    End Sub
End Class