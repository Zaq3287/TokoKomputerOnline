Imports MySqlConnector

Public Class frm_menu_admin
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim saldo As Integer
    Dim bolInit As Boolean
    Dim status As String, dtUpdated As String

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' background worker
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim result As Object = Nothing

        Try
            glistKaryawan.Clear()
            glistPelanggan.Clear()

            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'saldo
                cmd.CommandText = "SELECT saldo FROM tbl_toko"
                result = cmd.ExecuteScalar()
                If Not IsDBNull(result) Then
                    saldo = Convert.ToInt32(result)
                Else
                    saldo = 0
                End If

                'karyawan
                cmd.CommandText = "SELECT Nama FROM tbl_karyawan ORDER BY Nama"
                Dim dr As MySqlDataReader = cmd.ExecuteReader
                While dr.Read
                    glistKaryawan.Add(dr(0).ToString())
                End While
                dr.Close()

                'pelanggan
                cmd.CommandText = "SELECT Nama FROM tbl_pelanggan ORDER BY Nama"
                glistPelanggan.Add("   --- PILIH ---   ")

                dr = cmd.ExecuteReader
                While dr.Read
                    glistPelanggan.Add(dr(0).ToString())
                End While
                dr.Close()

                'status
                cmd.CommandText = "SELECT status FROM tbl_status"
                result = cmd.ExecuteScalar()
                If Not IsDBNull(result) Then
                    status = result.ToString()
                End If

                'date updated
                cmd.CommandText = "SELECT dtUpdate FROM tbl_status"
                result = cmd.ExecuteScalar()
                If Not IsDBNull(result) Then
                    dtUpdated = CType(result, Date).ToString()
                    dtCurrent = CType(result, Date)
                Else
                    dtCurrent = Date.Today
                End If
            End Using

        Catch ex As Exception
            showErrorDB(ex.Message)
        Finally
            mySQLConn.Close()
        End Try
    End Sub

    Private Sub bgw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged

    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'Error in the work thread
        ElseIf e.Cancelled Then
            'Operation cancelled
        Else
            'Everything OK
            lblSaldo.Text = "Saldo: Rp. " & saldo.ToString("N0") & ",-"
            lblOnline.Text = "Online"
            panOnline.BackColor = Color.LightGreen

            If status = "Success" Then
                lblStatus.Text = "Last updated: " & dtUpdated
                lblStatus.ForeColor = Color.Green
            Else
                lblStatus.Text = "Failed: " & dtUpdated
                lblStatus.ForeColor = Color.Red
            End If

            lblStatus.Visible = True

            dtTanggal.Value = dtCurrent
        End If
    End Sub

    Private Sub bgwLaporan_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwLaporan.DoWork
        CalculateReport()
    End Sub

    Private Sub bgwLaporan_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwLaporan.ProgressChanged

    End Sub

    Private Sub bgwLaporan_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLaporan.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'Error in the work thread
        ElseIf e.Cancelled Then
            'Operation cancelled
        Else
            'Everything OK

            lblPLunasHari.Text = PLunasHari.ToString("N0")
            lblPATMHari.Text = PATMHari.ToString("N0")
            lblPTempoHari.Text = PTempoHari.ToString("N0")
            lblSLunasHari.Text = SLunasHari.ToString("N0")
            lblSATMHari.Text = SATMHari.ToString("N0")
            lblSTempoHari.Text = STempoHari.ToString("N0")
            lblLMasukHari.Text = LMasukHari.ToString("N0")
            lblLKeluarHari.Text = LKeluarHari.ToString("N0")
            lblCMasukHari.Text = CMasukHari.ToString("N0")
            lblCKeluarHari.Text = CKeluarHari.ToString("N0")
            lblCTotalHari.Text = CTotalHari.ToString("N0")
            lblPendapatanHari.Text = PTotalHari.ToString("N0")

            lblPLunasBulan.Text = PLunasBulan.ToString("N0")
            lblPATMBulan.Text = PATMBulan.ToString("N0")
            lblPTempoBulan.Text = PTempoBulan.ToString("N0")
            lblSLunasBulan.Text = SLunasBulan.ToString("N0")
            lblSATMBulan.Text = SATMBulan.ToString("N0")
            lblSTempoBulan.Text = STempoBulan.ToString("N0")
            lblLMasukBulan.Text = LMasukBulan.ToString("N0")
            lblLKeluarBulan.Text = LKeluarBulan.ToString("N0")
            lblCMasukBulan.Text = CMasukBulan.ToString("N0")
            lblCKeluarBulan.Text = CKeluarBulan.ToString("N0")
            lblCTotalBulan.Text = CTotalBulan.ToString("N0")
            lblPendapatanBulan.Text = PTotalBulan.ToString("N0")

            lblPLunasTahun.Text = PLunasTahun.ToString("N0")
            lblPATMTahun.Text = PATMTahun.ToString("N0")
            lblPTempoTahun.Text = PTempoTahun.ToString("N0")
            lblSLunasTahun.Text = SLunasTahun.ToString("N0")
            lblSATMTahun.Text = SATMTahun.ToString("N0")
            lblSTempoTahun.Text = STempoTahun.ToString("N0")
            lblLMasukTahun.Text = LMasukTahun.ToString("N0")
            lblLKeluarTahun.Text = LKeluarTahun.ToString("N0")
            lblCMasukTahun.Text = CMasukTahun.ToString("N0")
            lblCKeluarTahun.Text = CKeluarTahun.ToString("N0")
            lblCTotalTahun.Text = CTotalTahun.ToString("N0")
            lblPendapatanTahun.Text = PTotalTahun.ToString("N0")

            pLaporan.Visible = False
        End If
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' button
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub btnDataServis_Click(sender As Object, e As EventArgs) Handles btnDataServis.Click
        OpenSubForm("servis")
    End Sub

    Private Sub btnJualTempo_Click(sender As Object, e As EventArgs) Handles btnJualTempo.Click
        OpenSubForm("penjualan_tempo")
    End Sub

    Private Sub btnBarang_Click(sender As Object, e As EventArgs) Handles btnBarang.Click
        OpenSubForm("barang")
    End Sub

    Private Sub btnKaryawan_Click(sender As Object, e As EventArgs) Handles btnKaryawan.Click
        OpenSubForm("karyawan")
    End Sub

    Private Sub btnPelanggan_Click(sender As Object, e As EventArgs) Handles btnPelanggan.Click
        OpenSubForm("pelanggan")
    End Sub

    Private Sub btnDataJual_Click(sender As Object, e As EventArgs) Handles btnDataJual.Click
        OpenSubForm("penjualan")
    End Sub

    Private Sub btnDataLainnya_Click(sender As Object, e As EventArgs) Handles btnDataLainnya.Click
        OpenSubForm("lainnya")
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        'change database
        If lblToko.Text = "Yogyakarta" Then
            strDatabase = ""
        Else
            strDatabase = ""
        End If

        'refresh connection
        mySQLConn = GetMySQL()
        mySQLConn2 = GetMySQL()

        dtSelect = 0
        mtSelect = 0
        yrSelect = 0

        'reset all form
        SetDefault()

        If Not bgw.IsBusy Then bgw.RunWorkerAsync()
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        Dim message As String = ""

        If bgw.IsBusy Then Exit Sub

        Try
            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'info
                cmd.CommandText = "SELECT * FROM tbl_toko"
                Dim dr As MySqlDataReader = cmd.ExecuteReader
                While dr.Read
                    message = "Nama: " & dr("nama").ToString() & " (" & lblToko.Text & ")" & vbNewLine &
                                "Deskripsi: " & dr("deskripsi").ToString() & vbNewLine &
                                "Alamat: " & dr("alamat").ToString() & vbNewLine &
                                "Telepon: " & dr("telepon").ToString()
                End While
                dr.Close()

                showMessage(message)
            End Using

        Catch ex As Exception
            showError(ex.Message)
        Finally
            mySQLConn.Close()
        End Try
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Close()
    End Sub


    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub SetDefault()
        lblOnline.Text = "Offline..."
        panOnline.BackColor = Color.IndianRed

        lblToko.Text = "Yogyakarta"


        lblSaldo.Text = "Please wait..."

        dtTanggal.CustomFormat = " "
        dtTanggal.Format = DateTimePickerFormat.Custom

        pLaporan.Visible = True

        lblStatus.Visible = False
    End Sub

    Private Sub SetComboBox()
        cmbShow.DataSource = {"Edit", "Tanggal"}
        cmbShow.SelectedItem = cmbShow.Items(0)
    End Sub

    Private Sub OpenSubForm(ByVal strFormName As String)
        'exit if busy
        If bgw.IsBusy Then Exit Sub

        Dim formName As String = Me.GetType().Namespace & ".frm_data_" & strFormName
        Dim subForm = CType(Activator.CreateInstance(Type.GetType(formName)), Form)
        subForm.Show()
        Close()
    End Sub

    Private Sub initForm()
        bolInit = True

        bgw.WorkerReportsProgress = True
        bgwLaporan.WorkerReportsProgress = True

        SetComboBox()
        SetDefault()

        bolInit = False

        If Not bgw.IsBusy Then bgw.RunWorkerAsync()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_menu_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initForm()
    End Sub

    Private Sub dtTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtTanggal.ValueChanged
        If dtSelect = dtTanggal.Value.Day And mtSelect = dtTanggal.Value.Month And yrSelect = dtTanggal.Value.Year Then
            bolDateChange = False
        Else
            bolDateChange = True
        End If

        If mtSelect = dtTanggal.Value.Month And yrSelect = dtTanggal.Value.Year Then
            bolMonthChange = False
        Else
            bolMonthChange = True
        End If

        If yrSelect = dtTanggal.Value.Year Then
            bolYearChange = False
        Else
            bolYearChange = True
        End If

        dtSelect = dtTanggal.Value.Day
        mtSelect = dtTanggal.Value.Month
        yrSelect = dtTanggal.Value.Year

        dtSQL = dtTanggal.Value.ToString("yyyy-MM-dd")

        lblTahun.Text = "[" & dtTanggal.Value.ToString("yyyy") & "]"
        lblBulan.Text = "[" & dtTanggal.Value.ToString("MMMM yyyy") & "]"
        lblHari.Text = "[" & dtTanggal.Value.ToString("dd MMMM yyyy") & "]"

        If bolInit = False Then
            If Not bgwLaporan.IsBusy Then bgwLaporan.RunWorkerAsync()
        End If
    End Sub

    Private Sub dtTanggal_Enter(sender As Object, e As EventArgs) Handles dtTanggal.Enter
        SendKeys.Send("{F4}")
    End Sub

    Private Sub cmbShow_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbShow.SelectedValueChanged
        If cmbShow.Text = "Edit" Then
            strFieldDate = "EntryDate"
        Else
            strFieldDate = "Tanggal"
        End If

        If bolInit = False Then
            pLaporan.Visible = False
            If Not bgwLaporan.IsBusy Then bgwLaporan.RunWorkerAsync()
        End If
    End Sub

End Class