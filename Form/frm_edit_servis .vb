
Imports MySqlConnector

Public Class frm_edit_servis

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim listSparePart As List(Of SparePart) = New List(Of SparePart)

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
        DeleteSparePart()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddSparepart()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub AddSparepart()
        Dim result As Integer = 0
        Dim nama As String = ""
        Dim harga As String = ""

        result = ValidateSparePart()
        If result > 0 Then Exit Sub

        Dim tmp As SparePart = listSparePart.Where(Function(x) x.Kode = txtKodeSP.Text).FirstOrDefault()

        If tmp Is Nothing Then
            Try
                Using cmd = New MySqlCommand("SELECT nama, harga FROM tbl_barang WHERE Kode = '" & txtKodeSP.Text & "'", mySQLConn)
                    mySQLConn.Open()

                    Dim dr As MySqlDataReader = cmd.ExecuteReader

                    While dr.Read
                        nama = dr("nama").ToString()
                        harga = dr("harga").ToString()
                    End While

                    dr.Close()
                End Using
            Catch ex As Exception
                showError(ex.Message)
                result = 1
            Finally
                mySQLConn.Close()
            End Try

            If result > 0 Then Exit Sub

            listSparePart.Add(
                            New SparePart With
                            {
                                .Kode = txtKodeSP.Text,
                                .Nama = nama,
                                .Harga = harga,
                                .Jumlah = 1
                            })
        Else
            Dim idx As Integer = listSparePart.IndexOf(tmp)
            listSparePart(idx).Jumlah += 1
        End If

        setDataSource(listSparePart, dgv)

        txtKodeSP.Text = ""
    End Sub

    Private Sub DeleteSparePart()
        Dim tmp As SparePart = listSparePart.Where(Function(x) x.Kode = txtKodeSP.Text).FirstOrDefault()

        If Not tmp Is Nothing Then
            listSparePart.Remove(tmp)

            setDataSource(listSparePart, dgv)

            txtKodeSP.Text = ""
        End If
    End Sub

    Private Sub SetData()
        Dim result As Integer = 0
        Dim dtStart As String = "", dtEnd As String = ""

        Try
            Using cmd = New MySqlCommand("SELECT * FROM tbl_servis WHERE noNota = '" & gstrNoNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    If Not IsDBNull(dr("tanggal")) Then
                        dtStart = dr.GetDateTime("tanggal").ToString("d")
                        dtTanggalMasuk.Value = dtStart
                    End If
                    If Not IsDBNull(dr("tanggalSelesai")) Then
                        dtEnd = dr.GetDateTime("tanggalSelesai").ToString("d")
                        dtTanggalSelesai.Value = dtEnd
                    End If

                    txtNota.Text = dr("noNota").ToString()
                    txtNama.Text = dr("pelanggan").ToString()
                    txtTelepon.Text = dr("telepon").ToString()
                    txtBarang.Text = dr("barang").ToString()
                    txtKelengkapan.Text = dr("kelengkapan").ToString()
                    txtSN.Text = dr("sn").ToString()
                    txtKeluhan.Text = dr("keluhan").ToString()
                    txtPengerjaan.Text = dr("pengerjaan").ToString()
                    txtCatatan.Text = dr("catatan").ToString()
                    txtTotal.Text = dr("total").ToString()
                    txtDP.Text = dr("dp").ToString()

                    cmbKaryawan.SelectedItem = dr("karyawan").ToString()
                    cmbProses.SelectedItem = dr("proses").ToString()
                    cmbStatus.SelectedItem = dr("lokasi").ToString()
                    cmbPembayaran.SelectedItem = dr("status").ToString()
                    cmbGaransi.SelectedItem = dr("garansi").ToString()
                End While

                dr.Close()

                cmd.CommandText = "SELECT kode, nama, harga, jumlah FROM tbl_servis_sub WHERE noNota = '" & gstrNoNota & "'"

                dr = cmd.ExecuteReader

                While dr.Read
                    listSparePart.Add(
                        New SparePart With
                        {
                            .Kode = dr("kode").ToString(),
                            .Nama = dr("nama").ToString(),
                            .Harga = dr("harga").ToString(),
                            .Jumlah = dr("jumlah").ToString()
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

        noNota = ExecScalar("SELECT noNota FROM tbl_servis ORDER BY noNota DESC LIMIT 1")

        If noNota = Nothing Then
            txtNota.Text = 1.ToString("0000000")
        Else
            txtNota.Text = (Convert.ToInt32(noNota) + 1).ToString("0000000")
        End If

        dtTanggalMasuk.Value = Now
        txtNama.Text = ""
        txtTelepon.Text = ""
        txtBarang.Text = ""
        txtKelengkapan.Text = ""
        txtKeluhan.Text = ""
        txtPengerjaan.Text = ""
        txtCatatan.Text = ""
        txtSN.Text = ""
        cmbProses.SelectedItem = "Proses"
        cmbStatus.SelectedItem = "Masuk"
        cmbPembayaran.SelectedItem = "Lunas"
        cmbGaransi.SelectedItem = "7"
        txtTotal.Text = "0"
        cmbKaryawan.SelectedItem = cmbKaryawan.Items(0)
        txtDP.Text = "0"
    End Sub

    Private Sub setDataSource(ByVal cl As List(Of SparePart), ByVal dgv As DataGridView)
        dgv.DataSource = (From c In cl Select New With {c.Kode, c.Nama, c.Harga, c.Jumlah}).ToList
    End Sub

    Private Sub SetComboBox()
        cmbKaryawan.DataSource = glistKaryawan
        cmbProses.DataSource = {"Proses", "Selesai", "Pending", "Batal"}
        cmbStatus.DataSource = {"Masuk", "Diambil"}
        cmbPembayaran.DataSource = {"Lunas", "Tempo", "DP", "ATM"}
        cmbGaransi.DataSource = {"0", "1", "3", "7", "14", "30", "60", "90"}
    End Sub

    Private Sub SaveData()
        Dim result As Integer = 0
        Dim dtStart As String = "", dtEnd As String = ""
        Dim bolFound As Boolean = False
        Dim dbTotal As String = 0, dbDP As String = 0, dbPembayaran As String = "", dbStatus As String = ""
        Dim intDP As Integer = 0, intTotal As Integer

        Try
            result = DeleteServis(txtNota.Text)
            If result > 0 Then Exit Sub

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                intDP = IIf(IsNumeric(txtDP.Text), txtDP.Text, 0)
                intTotal = IIf(IsNumeric(txtTotal.Text), txtTotal.Text, 0)

                'insert servis
                cmd.CommandText = "INSERT INTO tbl_servis(noNota, tanggal, tanggalSelesai, pelanggan, telepon, karyawan, barang, kelengkapan, sn," &
                                    " keluhan, pengerjaan, catatan, status, garansi, proses, lokasi, total, dp)" &
                                    " VALUES ('" & txtNota.Text & "', '" & dtTanggalMasuk.Value.ToString("yyyy-MM-dd") & "', " &
                                    IIf(dtTanggalSelesai.Text = " ", "Null, ", "'" & dtTanggalSelesai.Value.ToString("yyyy-MM-dd") & "', ") & "'" & txtNama.Text & "'," &
                                    " '" & txtTelepon.Text & "', '" & cmbKaryawan.Text & "', '" & txtBarang.Text & "', '" & txtKelengkapan.Text & "', '" & txtSN.Text & "', '" & txtKeluhan.Text & "', " &
                                    " '" & txtPengerjaan.Text & "', '" & txtCatatan.Text & "', '" & cmbPembayaran.Text & "', '" & cmbGaransi.Text & "', '" & cmbProses.Text & "', " &
                                    " '" & cmbStatus.Text & "', " & intTotal & ", " & intDP & ")"
                cmd.ExecuteNonQuery()

                'update saldo
                If cmbPembayaran.Text = "DP" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & intDP
                    cmd.ExecuteNonQuery()
                ElseIf cmbStatus.Text = "Diambil" And cmbPembayaran.Text = "Lunas" Then
                    cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & intTotal
                    cmd.ExecuteNonQuery()
                End If

                For Each tmp As SparePart In listSparePart
                    'insert servis sub
                    cmd.CommandText = "INSERT INTO tbl_servis_sub(noNota, kode, nama, harga, jumlah)" &
                                        " VALUES ('" & txtNota.Text & "', '" & tmp.Kode & "', '" & tmp.Nama & "', " & tmp.Harga & ", " & tmp.Jumlah & ")"
                    cmd.ExecuteNonQuery()
                Next

                'update stock on barang
                cmd.CommandText = "UPDATE tbl_barang AS t" &
                                    " INNER JOIN (SELECT * FROM tbl_servis_sub WHERE noNota = '" & txtNota.Text & "') AS p" &
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
        dgv.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "Kode"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).HeaderCell.Value = "Nama barang"
        dgv.Columns(1).Width = 250
        dgv.Columns(2).HeaderCell.Value = "Harga"
        dgv.Columns(2).Width = 100
        dgv.Columns(3).HeaderCell.Value = "Jumlah"
        dgv.Columns(3).Width = 70
        dgv.ResumeLayout()
    End Sub

    Private Function ValidateSparePart() As Integer
        Dim result As Integer = 0

        If String.IsNullOrEmpty(txtKodeSP.Text) Then Return 1

        If Not RecordExist("SELECT 1 FROM tbl_barang WHERE kode = '" & txtKodeSP.Text & "' LIMIT 1") Then
            showError("Kode barang tidak ada yang cocok!")
            Return 1
        End If

        Return result
    End Function

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_edit_servis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTanggalMasuk.CustomFormat = " "
        dtTanggalMasuk.Format = DateTimePickerFormat.Custom

        dtTanggalSelesai.CustomFormat = " "
        dtTanggalSelesai.Format = DateTimePickerFormat.Custom

        SetDGV(dgv)

        SetComboBox()

        If String.IsNullOrEmpty(gstrNoNota) Then
            SetDefault()
        Else
            SetData()
        End If

        setDataSource(listSparePart, dgv)

        FormatGrid()

        txtFocus.Select()

        'read only
        btnSave.Visible = bolAllowEdit
        btnAdd.Visible = bolAllowEdit
        btnDelete.Visible = bolAllowEdit
        txtKodeSP.Enabled = bolAllowEdit
    End Sub

    Private Sub dtTanggalMasuk_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggalMasuk.ValueChanged
        dtTanggalMasuk.Format = DateTimePickerFormat.Short
    End Sub

    Private Sub dtTanggalSelesai_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggalSelesai.ValueChanged
        dtTanggalSelesai.Format = DateTimePickerFormat.Short
    End Sub

    Private Sub dtTanggalSelesai_Enter(sender As Object, e As EventArgs) Handles dtTanggalSelesai.Enter
        SendKeys.Send("{F4}")
    End Sub

    Private Sub dtTanggalMasuk_Enter(sender As Object, e As EventArgs) Handles dtTanggalMasuk.Enter
        SendKeys.Send("{F4}")
    End Sub

    Private Sub txtKodeSP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeSP.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            AddSparepart()
        End If
    End Sub

    Private Sub dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Dim i As Integer = dgv.CurrentRow.Index
        txtKodeSP.Text = dgv.Item(0, i).Value
    End Sub
End Class

Public Class SparePart
    Public Kode As String
    Public Nama As String
    Public Harga As String
    Public Jumlah As String
End Class
