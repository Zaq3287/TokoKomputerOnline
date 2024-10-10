
Imports MySqlConnector

Public Class frm_edit_karyawan

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------


    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' background worker
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------


    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' button
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------

    Private Sub SetData()
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("SELECT * FROM tbl_karyawan WHERE nama = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    txtNama.Text = dr("nama").ToString()
                End While

                dr.Close()
            End Using

        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        If result > 0 Then Close()
    End Sub

    Private Sub SetDefault()
        txtNama.Text = ""
    End Sub


    Private Sub SaveData()
        Dim result As Integer = 0

        Try
            result = ValidateKaryawan()
            If result > 0 Then Exit Sub

            result = DeleteKaryawan(txtNama.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'insert lainnya
                cmd.CommandText = "INSERT INTO tbl_karyawan(nama)" &
                                    " VALUES ('" & txtNama.Text & "')"
                cmd.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        If result = 0 Then
            gbolEdit = True
            Close()
        End If
    End Sub

    Private Function ValidateKaryawan() As Integer
        Dim result As Integer = 0

        If String.IsNullOrEmpty(txtNama.Text) Then
            showError("Nama tidak boleh kosong!")
            Return 1
        End If

        Return result
    End Function

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_edit_karyawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(gstrNoNota) Then
            SetDefault()
            txtNama.Select()
        Else
            SetData()
            txtFocus.Select()
        End If

        'read only
        btnSave.Visible = bolAllowEdit
    End Sub
End Class