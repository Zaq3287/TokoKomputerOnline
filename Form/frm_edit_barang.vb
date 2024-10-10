
Imports MySqlConnector

Public Class frm_edit_barang

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
            Using cmd = New MySqlCommand("SELECT * FROM tbl_barang WHERE kode = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    txtKode.Text = dr("kode").ToString()
                    txtNama.Text = dr("nama").ToString()
                    txtStok.Text = dr("jumlah").ToString()
                    txtModal.Text = dr("modal").ToString()
                    txtHarga.Text = dr("harga").ToString()
                End While

                dr.Close()
            End Using

            txtKode.Enabled = False
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        If result > 0 Then Close()
    End Sub

    Private Sub SetDefault()
        txtKode.Text = ""
        txtNama.Text = ""
        txtStok.Text = "0"
        txtModal.Text = "0"
        txtHarga.Text = "0"
        txtKode.Enabled = True
    End Sub


    Private Sub SaveData()
        Dim result As Integer = 0
        Dim intHarga As Integer, intStok As Integer, intModal As Integer

        Try
            result = ValidateBarang()
            If result > 0 Then Exit Sub

            result = DeleteBarang(txtKode.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                intHarga = IIf(IsNumeric(txtHarga.Text), txtHarga.Text, 0)
                intModal = IIf(IsNumeric(txtModal.Text), txtModal.Text, 0)
                intStok = IIf(IsNumeric(txtStok.Text), txtStok.Text, 0)

                'insert lainnya
                cmd.CommandText = "INSERT INTO tbl_barang(kode, nama, modal, harga, jumlah)" &
                                " VALUES ('" & txtKode.Text & "', '" & txtNama.Text & "', " & intModal & "," &
                                " " & intHarga & ", " & intStok & ")"
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

    Private Function ValidateBarang() As Integer
        Dim result As Integer = 0

        If String.IsNullOrEmpty(txtKode.Text) Or String.IsNullOrEmpty(txtNama.Text) Then
            showError("Kode atau nama tidak boleh kosong!")
            Return 1
        End If

        Return result
    End Function

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_edit_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(gstrNoNota) Then
            SetDefault()
            txtKode.Select()
        Else
            SetData()
            txtFocus.Select()
        End If

        'read only
        btnSave.Visible = bolAllowEdit
    End Sub
End Class