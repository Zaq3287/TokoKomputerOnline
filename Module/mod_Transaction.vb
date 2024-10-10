Imports MySqlConnector

Module mod_Transaction
    Public Function DeleteServis(ByVal strNota As String)
        Dim dbTotal As String = 0, dbDP As String = 0, dbPembayaran As String = "", dbStatus As String = ""
        Dim bolFound As Boolean = False
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("SELECT total, dp, status, lokasi FROM tbl_servis WHERE noNota = '" & strNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    'data found, save to local variable
                    bolFound = True
                    dbTotal = dr("total").ToString()
                    dbDP = dr("dp").ToString()
                    dbPembayaran = dr("status").ToString()
                    dbStatus = dr("lokasi").ToString()
                End While

                dr.Close()

                If bolFound Then
                    'update saldo
                    If dbPembayaran = "DP" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & dbDP
                        cmd.ExecuteNonQuery()
                    ElseIf dbStatus = "Diambil" And dbPembayaran = "Lunas" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & dbTotal
                        cmd.ExecuteNonQuery()
                    End If

                    'reverse stock on barang
                    cmd.CommandText = "UPDATE tbl_barang AS t" &
                                        " INNER JOIN (SELECT * FROM tbl_servis_sub WHERE noNota = '" & strNota & "') AS p" &
                                        " ON t.Kode = p.Kode AND t.Nama = p.nama" &
                                        " SET t.Jumlah = t.Jumlah + p.jumlah"
                    cmd.ExecuteNonQuery()

                    'delete servis sub
                    cmd.CommandText = "DELETE FROM tbl_servis_sub WHERE noNota = '" & strNota & "'"
                    cmd.ExecuteNonQuery()

                    'delete servis
                    cmd.CommandText = "DELETE FROM tbl_servis WHERE noNota = '" & strNota & "'"
                    cmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function

    Public Function DeletePenjualan(ByVal strNota As String)
        Dim dbTotal As String = 0, dbDP As String = 0, dbPembayaran As String = ""
        Dim bolFound As Boolean = False
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("SELECT total, dp, status FROM tbl_penjualan WHERE noNota = '" & strNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    'data found, save to local variable
                    bolFound = True
                    dbTotal = dr("total").ToString()
                    dbDP = dr("dp").ToString()
                    dbPembayaran = dr("status").ToString()
                End While

                dr.Close()

                If bolFound Then
                    'update saldo
                    If dbPembayaran = "DP" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & dbDP
                        cmd.ExecuteNonQuery()
                    ElseIf dbPembayaran = "Lunas" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & dbTotal
                        cmd.ExecuteNonQuery()
                    End If

                    'reverse stock on barang
                    cmd.CommandText = "UPDATE tbl_barang AS t" &
                                        " INNER JOIN (SELECT * FROM tbl_penjualan_sub WHERE noNota = '" & strNota & "') AS p" &
                                        " ON t.Kode = p.Kode AND t.Nama = p.nama" &
                                        " SET t.Jumlah = t.Jumlah + p.jumlah"
                    cmd.ExecuteNonQuery()

                    'delete servis sub
                    cmd.CommandText = "DELETE FROM tbl_penjualan_sub WHERE noNota = '" & strNota & "'"
                    cmd.ExecuteNonQuery()

                    'delete servis
                    cmd.CommandText = "DELETE FROM tbl_penjualan WHERE noNota = '" & strNota & "'"
                    cmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function

    Public Function DeleteLainnya(ByVal strNota As String)
        Dim dbTotal As String = 0, dbJenis As String = 0
        Dim bolFound As Boolean = False
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("SELECT jenis, total FROM tbl_lainnya WHERE noNota = '" & strNota & "'", mySQLConn)
                mySQLConn.Open()

                Dim dr As MySqlDataReader = cmd.ExecuteReader

                While dr.Read
                    'data found, save to local variable
                    bolFound = True
                    dbTotal = dr("total").ToString()
                    dbJenis = dr("jenis").ToString()
                End While

                dr.Close()

                If bolFound Then
                    'update saldo
                    If dbJenis = "Masuk" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo - " & dbTotal
                        cmd.ExecuteNonQuery()
                    ElseIf dbJenis = "Keluar" Then
                        cmd.CommandText = "UPDATE tbl_toko SET Saldo = Saldo + " & dbTotal
                        cmd.ExecuteNonQuery()
                    End If

                    'delete lainnya
                    cmd.CommandText = "DELETE FROM tbl_lainnya WHERE noNota = '" & strNota & "'"
                    cmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function

    Public Function DeleteBarang(ByVal strKode As String)
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'delete barang
                cmd.CommandText = "DELETE FROM tbl_barang WHERE kode = '" & strKode & "'"
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function

    Public Function DeleteKaryawan(ByVal strNama As String)
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'delete barang
                cmd.CommandText = "DELETE FROM tbl_karyawan WHERE Nama = '" & strNama & "'"
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function

    Public Function DeletePelanggan(ByVal strNama As String)
        Dim result As Integer = 0

        Try
            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'delete barang
                cmd.CommandText = "DELETE FROM tbl_pelanggan WHERE Nama = '" & strNama & "'"
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            showErrorDB(ex.Message)
            result = 1
        Finally
            mySQLConn.Close()
        End Try

        Return result

    End Function
End Module
