
Imports System.ComponentModel
Imports MySqlConnector

Public Class frm_data_penjualan_tempo

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim myTime As DateTime
    Dim strSQL As String
    Dim listPelangganTempo As List(Of String) = New List(Of String)
    Dim total As Integer
    Dim result As Object
    Dim strPelanggan As String = ""

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' background worker
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgw.DoWork
        Dim dataSet As New DataSet()
        Try
            Dim dataAdapter As New MySqlDataAdapter(strSQL, mySQLConn)
            dataAdapter.Fill(dataSet, "data")

            bgw.ReportProgress(1, dataSet)
        Catch ex As Exception
            showErrorDB(ex.Message)
            e.Cancel = True
        End Try

        If strPelanggan.Length > 0 Then
            Try
                Using cmd = New MySqlCommand("", mySQLConn)
                    mySQLConn.Open()

                    'total
                    cmd.CommandText = "SELECT SUM(total) AS total FROM tbl_penjualan WHERE status = 'Tempo' AND pelanggan = '" & strPelanggan & "'"
                    result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) Then
                        total = Convert.ToInt32(result)
                    Else
                        total = 0
                    End If
                End Using

            Catch ex As Exception
                showErrorDB(ex.Message)
            Finally
                mySQLConn.Close()
            End Try
        End If
    End Sub

    Private Sub bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgw.ProgressChanged
        dgv.DataSource = CType(e.UserState, DataSet).Tables("data")
    End Sub

    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'Error in the work thread
        ElseIf e.Cancelled Then
            'Operation cancelled
        Else
            'Everything OK
            FormatGrid()
            lblWait.Visible = False
            dgv.Visible = True
            Dim timeSpan = Now() - myTime
            lblTime.Text = timeSpan.TotalSeconds.ToString("N2") + " s"

            lblTotal.Text = "Total: Rp. " & total.ToString("N0") & ",-"
        End If
    End Sub

    Private Sub bgwPelanggan_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwPelanggan.DoWork
        Try
            Using cmd = New MySqlCommand("", mySQLConn)
                mySQLConn.Open()

                'pelanggan
                cmd.CommandText = "SELECT pelanggan FROM tbl_penjualan WHERE status = 'Tempo' GROUP BY pelanggan ORDER BY pelanggan"
                Dim dr As MySqlDataReader = cmd.ExecuteReader
                While dr.Read
                    listPelangganTempo.Add(dr(0).ToString())
                End While

                dr.Close()
            End Using

        Catch ex As Exception
            showErrorDB(ex.Message)
        Finally
            mySQLConn.Close()
        End Try
    End Sub

    Private Sub bgwPelanggan_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwPelanggan.ProgressChanged

    End Sub

    Private Sub bgwPelanggan_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwPelanggan.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            'Error in the work thread
        ElseIf e.Cancelled Then
            'Operation cancelled
        Else
            'Everything OK

            SetComboBox()

            If cmbPelanggan.Items.Count > 0 Then cmbPelanggan.SelectedItem = cmbPelanggan.Items(0)

        End If
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' button
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Dim subForm As New frm_menu_admin
        subForm.Show()
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtNota.Text) = False Then
            Dim resultDlg As DialogResult = MessageBox.Show("You are about to deleted the selected record." & vbNewLine &
                                                        "This action cannot be undone. Do you want to proceed?", strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultDlg = DialogResult.Yes Then
                Dim result As Integer = DeletePenjualan(txtNota.Text)

                If result = 0 Then setSQL()
            End If
        End If
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' function
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub OpenSubForm()
        gbolEdit = False
        Dim subForm As New frm_edit_penjualan
        subForm.ShowInTaskbar = False
        AddOwnedForm(subForm)
        subForm.ShowDialog()

        If gbolEdit Then setSQL()
    End Sub
    Private Sub EditData()
        If String.IsNullOrEmpty(txtNota.Text) = False Then
            gstrNoNota = txtNota.Text

            OpenSubForm()

            gstrNoNota = ""
        End If
    End Sub

    Private Sub refreshData()
        dgv.Visible = False
        lblWait.Visible = True

        myTime = Now()
        If Not bgw.IsBusy Then bgw.RunWorkerAsync()
    End Sub

    Private Sub setSQL()
        Dim strWhere As String = ""

        txtNota.Text = ""

        If cmbPelanggan.Text.Length > 0 Then
            strWhere = " AND pelanggan = '" & cmbPelanggan.Text & "'"
            strPelanggan = cmbPelanggan.Text
        End If

        strSQL = "SELECT noNota, tanggal, pelanggan, telepon, karyawan, status, total FROM tbl_penjualan WHERE status = 'Tempo'" & strWhere & " ORDER BY noNota DESC"

        refreshData()
    End Sub

    Private Sub SetComboBox()
        cmbPelanggan.DataSource = listPelangganTempo
    End Sub

    Private Sub FormatGrid()
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "No nota"
        dgv.Columns(0).Width = 70
        dgv.Columns(1).HeaderCell.Value = "Tanggal"
        dgv.Columns(1).Width = 110
        dgv.Columns(2).HeaderCell.Value = "Pelanggan"
        dgv.Columns(2).Width = 150
        dgv.Columns(3).HeaderCell.Value = "No telepon"
        dgv.Columns(3).Width = 110
        dgv.Columns(4).HeaderCell.Value = "Karyawan"
        dgv.Columns(4).Width = 100
        dgv.Columns(5).HeaderCell.Value = "Pembayaran"
        dgv.Columns(5).Width = 80
        dgv.Columns(6).HeaderCell.Value = "Total"
        dgv.Columns(6).Width = 80
        dgv.Columns(6).DefaultCellStyle.Format = "N0"
        dgv.ResumeLayout()
    End Sub

    Private Sub SetDefault(Optional ByVal bolSetSQL As Boolean = True)
        txtNota.Text = ""
        total = 0
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_data_penjualan_tempo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw.WorkerReportsProgress = True
        bgwPelanggan.WorkerReportsProgress = True

        SetDGV(dgv)
        SetDefault()

        'read only
        btnDelete.Visible = bolAllowEdit

        If Not bgwPelanggan.IsBusy Then bgwPelanggan.RunWorkerAsync()
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        Dim i As Integer = dgv.CurrentRow.Index
        txtNota.Text = dgv.Item(0, i).Value
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        EditData()
    End Sub

    Private Sub cmbOption_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPelanggan.SelectedValueChanged
        setSQL()
    End Sub


End Class
