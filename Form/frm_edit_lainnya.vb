
Imports MySqlConnector

Public Class frm_edit_lainnya

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
        Dim dtStart As String = "", dtEnd As String = ""

        Try
            Using cmd = New MySqlCommand("SELECT * FROM tbl_lainnya WHERE noNota = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    If Not IsDBNull(dr("tanggal")) Then
                        dtStart = dr.GetDateTime("tanggal").ToString("d")
                        dtTanggalMasuk.Value = dtStart
                    End If

                    cmbKaryawan.SelectedItem = dr("karyawan").ToString()
                    cmbJenis.SelectedItem = dr("jenis").ToString()

                    txtNota.Text = dr("noNota").ToString()
                    txtTransaksi.Text = dr("transaksi").ToString()
                    txtTotal.Text = dr("total").ToString()

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
        Dim noNota As String

        noNota = ExecScalar("SELECT noNota FROM tbl_lainnya ORDER BY noNota DESC LIMIT 1")

        If noNota = Nothing Then
            txtNota.Text = 1.ToString("0000000")
        Else
            txtNota.Text = (Convert.ToInt32(noNota) + 1).ToString("0000000")
        End If

        dtTanggalMasuk.Value = Now
        cmbKaryawan.SelectedItem = cmbKaryawan.Items(0)
        cmbJenis.SelectedItem = cmbJenis.Items(0)
        txtTotal.Text = "0"
    End Sub

    Private Sub SetComboBox()
        cmbKaryawan.DataSource = glistKaryawan
        cmbJenis.DataSource = {"Keluar", "Masuk"}
    End Sub

    Private Sub SaveData()
        Dim result As Integer = 0
        Dim dtStart As String = "", dtEnd As String = ""
        Dim bolFound As Boolean = False
        Dim dbTotal As String = 0, dbDP As String = 0, dbPembayaran As String = "", dbStatus As String = ""
        Dim intTotal As Integer

        Try
            result = DeleteLainnya(txtNota.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                intTotal = IIf(IsNumeric(txtTotal.Text), txtTotal.Text, 0)

                'insert lainnya
                cmd.CommandText = "INSERT INTO tbl_lainnya(noNota, tanggal, karyawan, transaksi, jenis, total)" &
                                    " VALUES ('" & txtNota.Text & "', '" & dtTanggalMasuk.Value.ToString("yyyy-MM-dd") & "', '" & cmbKaryawan.Text & "', '" & txtTransaksi.Text & "'," &
                                    " '" & cmbJenis.Text & "', " & intTotal & ")"
                cmd.ExecuteNonQuery()

                'update saldo
                If cmbJenis.Text = "Keluar" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & intTotal
                    cmd.ExecuteNonQuery()
                ElseIf cmbJenis.Text = "Masuk" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & intTotal
                    cmd.ExecuteNonQuery()
                End If


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

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_edit_lainnya_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTanggalMasuk.CustomFormat = " "
        dtTanggalMasuk.Format = DateTimePickerFormat.Custom

        SetComboBox()

        If String.IsNullOrEmpty(gstrNoNota) Then
            SetDefault()
            txtTransaksi.Select()
        Else
            SetData()
            txtFocus.Select()
        End If

        'read only
        btnSave.Visible = bolAllowEdit
    End Sub

    Private Sub dtTanggalMasuk_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggalMasuk.ValueChanged
        dtTanggalMasuk.Format = DateTimePickerFormat.Short
    End Sub

    Private Sub dtTanggalMasuk_Enter(sender As Object, e As EventArgs) Handles dtTanggalMasuk.Enter
        SendKeys.Send("{F4}")
    End Sub
End Class