Imports MySqlConnector

Module mod_Laporan
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' constanta
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------



    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' fields
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Public PLunasHari As Integer, PLunasBulan As Integer, PLunasTahun As Integer
    Public PATMHari As Integer, PATMBulan As Integer, PATMTahun As Integer
    Public PTempoHari As Integer, PTempoBulan As Integer, PTempoTahun As Integer
    Public SLunasHari As Integer, SLunasBulan As Integer, SLunasTahun As Integer
    Public SATMHari As Integer, SATMBulan As Integer, SATMTahun As Integer
    Public STempoHari As Integer, STempoBulan As Integer, STempoTahun As Integer
    Public LMasukHari As Integer, LMasukBulan As Integer, LMasukTahun As Integer
    Public LKeluarHari As Integer, LKeluarBulan As Integer, LKeluarTahun As Integer

    Public CMasukHari As Integer, CMasukBulan As Integer, CMasukTahun As Integer
    Public CKeluarHari As Integer, CKeluarBulan As Integer, CKeluarTahun As Integer
    Public CTotalHari As Integer, CTotalBulan As Integer, CTotalTahun As Integer
    Public PTotalHari As Integer, PTotalBulan As Integer, PTotalTahun As Integer

    Public dtSelect As Integer = 0, mtSelect As Integer = 0, yrSelect As Integer = 0
    Public bolDateChange As Boolean = False, bolMonthChange As Boolean = False, bolYearChange As Boolean = False
    Public strFieldDate As String
    Public dtSQL As String
    Public dtCurrent As Date = Date.Today



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
    Public Sub CalculateReport()
        Dim result As Object = Nothing

        Try
            Using cmd = New MySqlCommand("", mySQLConn2)
                mySQLConn2.Open()

                If bolDateChange Then
                    'penjualan lunas hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "' AND status = 'Lunas'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PLunasHari = Convert.ToInt32(result)
                    Else
                        PLunasHari = 0
                    End If

                    'penjualan ATM hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "' AND status = 'ATM'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PATMHari = Convert.ToInt32(result)
                    Else
                        PATMHari = 0
                    End If

                    'penjualan tempo hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "' AND status = 'Tempo'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PTempoHari = Convert.ToInt32(result)
                    Else
                        PTempoHari = 0
                    End If

                    'servis lunas hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "'" &
                                    " And (status = 'Lunas' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SLunasHari = Convert.ToInt32(result)
                    Else
                        SLunasHari = 0
                    End If

                    'servis ATM hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "'" &
                                    " AND (status = 'ATM' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SATMHari = Convert.ToInt32(result)
                    Else
                        SATMHari = 0
                    End If

                    'servis tempo hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "'" &
                                    " AND (status = 'Tempo' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        STempoHari = Convert.ToInt32(result)
                    Else
                        STempoHari = 0
                    End If

                    'lain masuk hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "' AND jenis = 'Masuk'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LMasukHari = Convert.ToInt32(result)
                    Else
                        LMasukHari = 0
                    End If

                    'lain keluar hari
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                    " WHERE DATE(" & strFieldDate & ") = '" & dtSQL & "' AND jenis = 'Keluar'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LKeluarHari = Convert.ToInt32(result)
                    Else
                        LKeluarHari = 0
                    End If

                    'calculate
                    CMasukHari = PLunasHari + SLunasHari + LMasukHari
                    CKeluarHari = LKeluarHari
                    CTotalHari = CMasukHari - CKeluarHari

                    PTotalHari = PLunasHari + SLunasHari + LMasukHari + PATMHari + SATMHari
                End If

                If bolMonthChange Then
                    'penjualan lunas bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect & " AND status = 'Lunas'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PLunasBulan = Convert.ToInt32(result)
                    Else
                        PLunasBulan = 0
                    End If

                    'penjualan ATM bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect & " AND status = 'ATM'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PATMBulan = Convert.ToInt32(result)
                    Else
                        PATMBulan = 0
                    End If

                    'penjualan tempo bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect & " AND status = 'Tempo'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PTempoBulan = Convert.ToInt32(result)
                    Else
                        PTempoBulan = 0
                    End If

                    'servis lunas bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'Lunas' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SLunasBulan = Convert.ToInt32(result)
                    Else
                        SLunasBulan = 0
                    End If

                    'servis ATM bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'ATM' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SATMBulan = Convert.ToInt32(result)
                    Else
                        SATMBulan = 0
                    End If

                    'servis tempo bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'Tempo' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        STempoBulan = Convert.ToInt32(result)
                    Else
                        STempoBulan = 0
                    End If

                    'lain masuk bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect & " AND jenis = 'Masuk'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LMasukBulan = Convert.ToInt32(result)
                    Else
                        LMasukBulan = 0
                    End If

                    'lain keluar bulan
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                        " WHERE MONTH(" & strFieldDate & ") = " & mtSelect & " AND YEAR(" & strFieldDate & ") = " & yrSelect & " AND jenis = 'Keluar'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LKeluarBulan = Convert.ToInt32(result)
                    Else
                        LKeluarBulan = 0
                    End If

                    'calculate
                    CMasukBulan = PLunasBulan + SLunasBulan + LMasukBulan
                    CKeluarBulan = LKeluarBulan
                    CTotalBulan = CMasukBulan - CKeluarBulan

                    PTotalBulan = PLunasBulan + SLunasBulan + LMasukBulan + PATMBulan + SATMBulan
                End If

                If bolYearChange Then
                    'penjualan lunas tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect & " And status = 'Lunas'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PLunasTahun = Convert.ToInt32(result)
                    Else
                        PLunasTahun = 0
                    End If

                    'penjualan ATM tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect & " And status = 'ATM'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PATMTahun = Convert.ToInt32(result)
                    Else
                        PATMTahun = 0
                    End If

                    'penjualan tempo tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_penjualan" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect & " And status = 'Tempo'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        PTempoTahun = Convert.ToInt32(result)
                    Else
                        PTempoTahun = 0
                    End If

                    'servis lunas tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'Lunas' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SLunasTahun = Convert.ToInt32(result)
                    Else
                        SLunasTahun = 0
                    End If

                    'servis ATM tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'ATM' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        SATMTahun = Convert.ToInt32(result)
                    Else
                        SATMTahun = 0
                    End If

                    'servis tempo tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_servis" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect &
                                        " AND (status = 'Tempo' AND proses = 'Selesai' AND lokasi = 'Diambil')"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        STempoTahun = Convert.ToInt32(result)
                    Else
                        STempoTahun = 0
                    End If

                    'lain masuk tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect & " AND jenis = 'Masuk'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LMasukTahun = Convert.ToInt32(result)
                    Else
                        LMasukTahun = 0
                    End If

                    'lain keluar tahun
                    cmd.CommandText = "SELECT SUM(total) AS t FROM tbl_lainnya" &
                                        " WHERE YEAR(" & strFieldDate & ") = " & yrSelect & " And jenis = 'Keluar'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        LKeluarTahun = Convert.ToInt32(result)
                    Else
                        LKeluarTahun = 0
                    End If

                    'calculate
                    CMasukTahun = PLunasTahun + SLunasTahun + LMasukTahun
                    CKeluarTahun = LKeluarTahun
                    CTotalTahun = CMasukTahun - CKeluarTahun

                    PTotalTahun = PLunasTahun + SLunasTahun + LMasukTahun + PATMTahun + SATMTahun
                End If
            End Using

        Catch ex As Exception
            showErrorDB(ex.Message)
        Finally
            mySQLConn2.Close()
        End Try
    End Sub

End Module
