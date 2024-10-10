Module mod_Global
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' constanta
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Public Const strTitle As String = "Toko"
    Public Const strVersion As String = "1.0.0"
    Public Const devMode As Boolean = False
    Public Const bolAllowEdit As Boolean = True


    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' fields
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Public gstrNoNota As String = ""

    Public gbolEdit As Boolean = False

    Public glistKaryawan As List(Of String) = New List(Of String)
    Public glistPelanggan As List(Of String) = New List(Of String)

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' properties
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------



    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' Function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Public Sub showError(ByVal strMessage As String)
        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        LogWrite(strMessage)
    End Sub

    Public Sub showErrorDB(ByVal strMessage As String)
        If devMode = True Then
            showError(strMessage)
        Else
            showError("An error occurred in the database process!" & vbNewLine &
                        "Make sure the connection is stable!")
        End If
        LogWrite(strMessage)
    End Sub

    Public Sub showMessage(ByVal strMessage As String)
        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Module
