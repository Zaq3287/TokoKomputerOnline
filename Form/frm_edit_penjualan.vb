
Imports MySqlConnector

Public Class frm_edit_penjualan

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim listPenjualan As List(Of Penjualan) = New List(Of Penjualan)

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeletePenjualanSub()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddPenjualanSub()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub AddPenjualanSub()
        Dim result As Integer = 0
        Dim nama As String = ""
        Dim harga As Integer = 0
        Dim jumlah As Integer = 0

        result = ValidatePenjualan()
        If result > 0 Then Exit Sub

        harga = IIf(IsNumeric(txtHargaBarang.Text), txtHargaBarang.Text, 0)
        jumlah = IIf(IsNumeric(txtJumlahBarang.Text), txtJumlahBarang.Text, 0)

        Dim tmp As Penjualan = listPenjualan.Where(Function(x) x.Kode = txtKodeBarang.Text And x.Nama = txtNamaBarang.Text).FirstOrDefault()

        If Not tmp Is Nothing Then listPenjualan.Remove(tmp)

        listPenjualan.Add(
                            New Penjualan With
                            {
                                .Kode = txtKodeBarang.Text,
                                .Nama = txtNamaBarang.Text,
                                .Harga = harga,
                                .Jumlah = jumlah,
                                .Garansi = cmbGaransiBarang.Text
                            })

        setDataSource(listPenjualan, dgv)

        ResetBarang()
    End Sub

    Private Sub DeletePenjualanSub()
        Dim tmp As Penjualan = listPenjualan.Where(Function(x) x.Kode = txtKodeBarang.Text And x.Nama = txtNamaBarang.Text).FirstOrDefault()

        If Not tmp Is Nothing Then
            listPenjualan.Remove(tmp)

            setDataSource(listPenjualan, dgv)

            ResetBarang()
        End If
    End Sub

    Private Sub GetBarang()
        If String.IsNullOrEmpty(txtKodeBarang.Text) Then Exit Sub

        ResetBarang(False)

        Try
            Using cmd = New MySqlCommand("SELECT nama, harga FROM tbl_barang WHERE Kode = '" & txtKodeBarang.Text & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    txtNamaBarang.Text = dr("nama").ToString()
                    txtHargaBarang.Text = dr("harga").ToString()
                    txtJumlahBarang.Text = "1"
                    cmbGaransiBarang.SelectedItem = "7"
                End While

                dr.Close()
            End Using
        Catch ex As Exception
            showError(ex.Message)
        Finally
            mySQLConn.Close()
        End Try
    End Sub

    Private Sub ResetBarang(Optional ByVal bolKode As Boolean = True)
        If bolKode Then txtKodeBarang.Text = ""

        txtNamaBarang.Text = ""
        txtHargaBarang.Text = ""
        txtJumlahBarang.Text = ""
        cmbGaransiBarang.SelectedItem = "7"
    End Sub

    Private Sub SetData()
        Dim result As Integer = 0
        Dim dtStart As String = "", dtEnd As String = ""

        Try
            Using cmd = New MySqlCommand("SELECT * FROM tbl_penjualan WHERE noNota = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    If Not IsDBNull(dr("tanggal")) Then
                        dtStart = dr.GetDateTime("tanggal").ToString("d")
                        dtTanggalMasuk.Value = dtStart
                    End If

                    cmbKaryawan.SelectedItem = dr("karyawan").ToString()

                    If dr.GetBoolean("isPelanggan") Then
                        cmbPelanggan.SelectedItem = dr("pelanggan").ToString()
                    Else
                        cmbPelanggan.SelectedItem = cmbPelanggan.Items(0)
                    End If

                    txtNota.Text = dr("noNota").ToString()
                    txtNama.Text = dr("pelanggan").ToString()
                    txtTelepon.Text = dr("telepon").ToString()
                    cmbPembayaran.SelectedItem = dr("status").ToString()
                    txtTotal.Text = dr("total").ToString()
                    txtDP.Text = dr("dp").ToString()

                End While

                dr.Close()

                cmd.CommandText = "SELECT kode, nama, harga, jumlah, garansi FROM tbl_penjualan_sub WHERE noNota = '" & gstrNoNota & "'"

                dr = cmd.ExecuteReader

                While dr.Read
                    listPenjualan.Add(
                        New Penjualan With
                        {
                            .Kode = dr("kode").ToString(),
                            .Nama = dr("nama").ToString(),
                            .Harga = dr("harga").ToString(),
                            .Jumlah = dr("jumlah").ToString(),
                            .Garansi = dr("garansi").ToString()
                        })
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

        noNota = ExecScalar("SELECT noNota FROM tbl_penjualan ORDER BY noNota DESC LIMIT 1")

        If noNota = Nothing Then
            txtNota.Text = 1.ToString("0000000")
        Else
            txtNota.Text = (Convert.ToInt32(noNota) + 1).ToString("0000000")
        End If

        dtTanggalMasuk.Value = Now
        cmbKaryawan.SelectedItem = cmbKaryawan.Items(0)
        cmbPelanggan.SelectedItem = cmbPelanggan.Items(0)
        txtNama.Text = "User"
        txtTelepon.Text = ""
        cmbPembayaran.SelectedItem = "Lunas"
        txtTotal.Text = "0"
        txtDP.Text = "0"
    End Sub

    Private Sub setDataSource(ByVal cl As List(Of Penjualan), ByVal dgv As DataGridView)
        dgv.DataSource = (From c In cl Select New With {c.Kode, c.Nama, c.Harga, c.Jumlah, c.Garansi}).OrderBy(Function(x) x.Kode.ToString()).
                                                                                                        ThenBy(Function(x) x.Nama).
                                                                                                        ToList

        Dim total As Integer = 0

        For Each tmp As Penjualan In listPenjualan
            total += tmp.Jumlah * tmp.Harga
        Next

        txtTotal.Text = total
    End Sub

    Private Sub SetComboBox()
        cmbKaryawan.DataSource = glistKaryawan
        cmbPelanggan.DataSource = glistPelanggan
        cmbPembayaran.DataSource = {"Lunas", "Tempo", "DP", "ATM"}
        cmbGaransiBarang.DataSource = {"0", "1", "3", "7", "14", "30", "60", "90"}
    End Sub

    Private Sub SaveData()
        Dim result As Integer = 0
        Dim dtStart As String = "", dtEnd As String = ""
        Dim bolFound As Boolean = False
        Dim dbTotal As String = 0, dbDP As String = 0, dbPembayaran As String = "", dbStatus As String = ""
        Dim intDP As Integer = 0, intTotal As Integer, bolPelanggan As Boolean = False, intTempo As Integer

        Try
            result = DeletePenjualan(txtNota.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                intDP = IIf(IsNumeric(txtDP.Text), txtDP.Text, 0)
                intTotal = IIf(IsNumeric(txtTotal.Text), txtTotal.Text, 0)
                intTempo = IIf(cmbPembayaran.Text = "Tempo", 14, 0)
                bolPelanggan = IIf(cmbPelanggan.Text = txtNama.Text, True, False)

                'insert penjualan
                cmd.CommandText = "INSERT INTO tbl_penjualan(noNota, tanggal, isPelanggan, pelanggan, telepon, karyawan, status, tempo, total, dp)" &
                                    " VALUES ('" & txtNota.Text & "', '" & dtTanggalMasuk.Value.ToString("yyyy-MM-dd") & "', " & bolPelanggan & ", '" & txtNama.Text & "'," &
                                    " '" & txtTelepon.Text & "', '" & cmbKaryawan.Text & "', '" & cmbPembayaran.Text & "', " & intTempo & ", " & intTotal & ", " & intDP & ")"
                cmd.ExecuteNonQuery()

                'update saldo
                If cmbPembayaran.Text = "DP" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & intDP
                    cmd.ExecuteNonQuery()
                ElseIf cmbPembayaran.Text = "Lunas" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & intTotal
                    cmd.ExecuteNonQuery()
                End If

                For Each tmp As Penjualan In listPenjualan
                    'insert penjualan sub
                    cmd.CommandText = "INSERT INTO tbl_penjualan_sub(noNota, kode, nama, harga, jumlah, garansi)" &
                                        " VALUES ('" & txtNota.Text & "', '" & tmp.Kode & "', '" & tmp.Nama & "', " & tmp.Harga & ", " & tmp.Jumlah & ", " & tmp.Garansi & ")"
                    cmd.ExecuteNonQuery()
                Next

                'update stock on barang
                cmd.CommandText = "UPDATE tbl_barang AS t" &
                                    " INNER JOIN (SELECT * FROM tbl_penjualan_sub WHERE noNota = '" & txtNota.Text & "') AS p" &
                                    " ON t.Kode = p.Kode AND t.Nama = p.nama" &
                                    " SET t.Jumlah = t.Jumlah - p.jumlah"
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

    Private Sub FormatGrid()
        dgv.ColumnHeadersVisible = False
        dgv.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "Kode"
        dgv.Columns(0).Width = 155
        dgv.Columns(1).HeaderCell.Value = "Nama barang"
        dgv.Columns(1).Width = 300
        dgv.Columns(2).HeaderCell.Value = "Harga"
        dgv.Columns(2).Width = 95
        dgv.Columns(3).HeaderCell.Value = "Jumlah"
        dgv.Columns(3).Width = 95
        dgv.Columns(4).HeaderCell.Value = "Garansi [hari]"
        dgv.Columns(4).Width = 110
        dgv.ResumeLayout()
    End Sub

    Private Function ValidatePenjualan() As Integer
        Dim result As Integer = 0

        If String.IsNullOrEmpty(txtKodeBarang.Text) And String.IsNullOrEmpty(txtNamaBarang.Text) Then Return 1

        If Not String.IsNullOrEmpty(txtKodeBarang.Text) Then
            If Not RecordExist("SELECT 1 FROM tbl_barang WHERE kode = '" & txtKodeBarang.Text & "' AND nama = '" & txtNamaBarang.Text & "' LIMIT 1") Then
                showError("Kode barang dan nama tidak ada yang cocok!")
                Return 1
            End If
        End If

        Return result
    End Function

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_edit_penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTanggalMasuk.CustomFormat = " "
        dtTanggalMasuk.Format = DateTimePickerFormat.Custom

        SetDGV(dgv)

        SetComboBox()

        If String.IsNullOrEmpty(gstrNoNota) Then
            SetDefault()
        Else
            SetData()
        End If

        ResetBarang()

        setDataSource(listPenjualan, dgv)

        FormatGrid()

        txtFocus.Select()

        'read only
        btnSave.Visible = bolAllowEdit
        btnAdd.Visible = bolAllowEdit
        btnDelete.Visible = bolAllowEdit
    End Sub

    Private Sub dtTanggalMasuk_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggalMasuk.ValueChanged
        dtTanggalMasuk.Format = DateTimePickerFormat.Short
    End Sub

    Private Sub dtTanggalMasuk_Enter(sender As Object, e As EventArgs) Handles dtTanggalMasuk.Enter
        SendKeys.Send("{F4}")
    End Sub

    Private Sub txtKodeBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeBarang.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            GetBarang()
        End If
    End Sub

    Private Sub dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Dim i As Integer = dgv.CurrentRow.Index
        txtKodeBarang.Text = dgv.Item(0, i).Value
        txtNamaBarang.Text = dgv.Item(1, i).Value
        txtHargaBarang.Text = dgv.Item(2, i).Value
        txtJumlahBarang.Text = dgv.Item(3, i).Value
        cmbGaransiBarang.SelectedItem = dgv.Item(4, i).Value
    End Sub

    Private Sub txtKodeBarang_Leave(sender As Object, e As EventArgs) Handles txtKodeBarang.Leave
        GetBarang()
    End Sub

    Private Sub cmbPelanggan_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPelanggan.SelectedValueChanged
        If cmbPelanggan.Text <> cmbPelanggan.Items(0) Then txtNama.Text = cmbPelanggan.Text
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        lblTotal.Text = "Total: Rp. " & Convert.ToInt32(txtTotal.Text).ToString("N0") & ",-"
    End Sub
End Class

Public Class Penjualan
    Public Kode As String
    Public Nama As String
    Public Harga As String
    Public Jumlah As String
    Public Garansi As String
End Class
