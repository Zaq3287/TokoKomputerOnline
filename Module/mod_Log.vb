Imports System.IO

Module mod_Log
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' fields
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim strAppPath As String = Application.StartupPath
    Dim strFileName As String = "log.txt"
    Dim strLogPath As String = Path.Combine(strAppPath, strFileName)


    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' Function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Public Sub LogWrite(ByVal strMessage As String)

        Try
            Dim fs As New FileStream(strLogPath, FileMode.Append, FileAccess.Write)
            Dim s As New StreamWriter(fs, Text.Encoding.Default)

            s.BaseStream.Seek(0, SeekOrigin.End)
            s.WriteLine(Date.Today.ToLongDateString() & " " & Date.Now.ToLongTimeString)
            s.WriteLine(strMessage)
            s.WriteLine("-------------------------------")
            s.Close()

        Catch ex As Exception

        End Try
    End Sub

End Module
