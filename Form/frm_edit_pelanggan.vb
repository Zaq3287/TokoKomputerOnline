
Imports MySqlConnector

Public Class frm_edit_pelanggan

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
            Using cmd = New MySqlCommand("SELECT * FROM tbl_pelanggan WHERE nama = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    txtTelepon.Text = dr("telepon").ToString()
                    txtNama.Text = dr("nama").ToString()
                    txtAlamat.Text = dr("alamat").ToString()
                End While

                dr.Close()
            End Using

            txtNama.Enabled = False
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        If result > 0 Then Close()
    End Sub

    Private Sub SetDefault()
        txtTelepon.Text = ""
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtNama.Enabled = True
    End Sub


    Private Sub SaveData()
        Dim result As Integer = 0

        Try
            result = ValidatePelanggan()
            If result > 0 Then Exit Sub

            result = DeletePelanggan(txtNama.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'insert lainnya
                cmd.CommandText = "INSERT INTO tbl_pelanggan(nama, telepon, alamat)" &
                                    " VALUES ('" & txtNama.Text & "', '" & txtTelepon.Text & "', '" & txtAlamat.Text & "')"
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

    Private Function ValidatePelanggan() As Integer
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
    Private Sub frm_edit_pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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