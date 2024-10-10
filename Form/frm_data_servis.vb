
Imports System.ComponentModel
Imports MySqlConnector

Public Class frm_data_servis

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' field
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Dim myTime As DateTime
    Dim strSQL As String
    Dim bolInit As Boolean = False

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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        SetDefault()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FindData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        OpenSubForm()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtNota.Text) = False Then
            Dim resultDlg As DialogResult = MessageBox.Show("You are about to deleted the selected record." & vbNewLine &
                                                        "This action cannot be undone. Do you want to proceed?", strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultDlg = DialogResult.Yes Then
                Dim result As Integer = DeleteServis(txtNota.Text)

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
        Dim subForm As New frm_edit_servis
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
    Private Sub FindData()
        If String.IsNullOrEmpty(txtFind.Text) Then Exit Sub

        strSQL = "SELECT * FROM tbl_servis" &
                    " WHERE noNota Like '%" & txtFind.Text & "%'" &
                    " OR pelanggan LIKE '%" & txtFind.Text & "%'" &
                    " OR barang LIKE '%" & txtFind.Text & "%'" &
                    " OR telepon LIKE '%" & txtFind.Text & "%'" &
                    " ORDER BY noNota DESC"

        refreshData()

        SetDefault(False)
    End Sub

    Private Sub refreshData()
        dgv.Visible = False
        lblWait.Visible = True

        myTime = Now()
        If Not bgw.IsBusy Then bgw.RunWorkerAsync()
    End Sub

    Private Sub setSQL()
        Dim strWhere As String = "", strLimit As String = ""

        txtFind.Text = ""
        txtNota.Text = ""

        If cmbPembayaran.Text <> "Semua" Then
            strWhere = "status = '" & cmbPembayaran.Text & "'"
        End If

        If cmbProses.Text <> "Semua" Then
            strWhere = IIf(strWhere.Length > 0, strWhere & " AND ", "") & "proses = '" & cmbProses.Text & "'"
        End If

        If cmbStatus.Text <> "Semua" Then
            strWhere = IIf(strWhere.Length > 0, strWhere & " AND ", "") & "lokasi = '" & cmbStatus.Text & "'"
        End If

        If cmbShow.Text = "Limit" Then
            strLimit = " LIMIT 100"
        End If

        If strWhere.Length > 0 Then
            strWhere = " WHERE " & strWhere
        End If

        strSQL = "SELECT * FROM tbl_servis" & strWhere & " ORDER BY noNota DESC" & strLimit

        If Not bolInit Then refreshData()
    End Sub

    Private Sub SetComboBox()
        cmbPembayaran.DataSource = {"Semua", "Lunas", "ATM", "Tempo", "DP"}
        cmbProses.DataSource = {"Semua", "Proses", "Selesai", "Pending", "Batal"}
        cmbStatus.DataSource = {"Semua", "Masuk", "Diambil"}
        cmbShow.DataSource = {"Limit", "Semua"}
    End Sub

    Private Sub FormatGrid()
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "No nota"
        dgv.Columns(0).Width = 70
        dgv.Columns(1).HeaderCell.Value = "Tanggal masuk"
        dgv.Columns(1).Width = 110
        dgv.Columns(2).Visible = False 'tanggal selesai
        dgv.Columns(3).HeaderCell.Value = "Pelanggan"
        dgv.Columns(3).Width = 150
        dgv.Columns(4).HeaderCell.Value = "No telepon"
        dgv.Columns(4).Width = 110
        dgv.Columns(5).Visible = False 'karyawan
        dgv.Columns(6).HeaderCell.Value = "Barang"
        dgv.Columns(6).Width = 150
        dgv.Columns(7).HeaderCell.Value = "Kelengkapan"
        dgv.Columns(7).Width = 150
        dgv.Columns(8).Visible = False 'serial number
        dgv.Columns(9).HeaderCell.Value = "Keluhan"
        dgv.Columns(9).Width = 150
        dgv.Columns(10).HeaderCell.Value = "Pengerjaan"
        dgv.Columns(10).Width = 200
        dgv.Columns(11).Visible = False 'catatan
        dgv.Columns(12).HeaderCell.Value = "Pembayaran"
        dgv.Columns(12).Width = 80
        dgv.Columns(13).Visible = False 'garansi
        dgv.Columns(14).HeaderCell.Value = "Proses"
        dgv.Columns(14).Width = 60
        dgv.Columns(15).HeaderCell.Value = "Status"
        dgv.Columns(15).Width = 60
        dgv.Columns(16).HeaderCell.Value = "Total"
        dgv.Columns(16).Width = 80
        dgv.Columns(16).DefaultCellStyle.Format = "N0"
        dgv.Columns(17).Visible = False 'dp
        dgv.Columns(18).Visible = False 'dp checkbox
        dgv.Columns(19).Visible = False 'entry date
        dgv.ResumeLayout()
    End Sub

    Private Sub SetDefault(Optional ByVal bolSetSQL As Boolean = True)
        'avoid setSQL calling automatically
        bolInit = True

        txtFind.Text = ""
        txtNota.Text = ""

        cmbPembayaran.SelectedItem = cmbPembayaran.Items(0)
        cmbProses.SelectedItem = cmbProses.Items(0)
        cmbStatus.SelectedItem = cmbStatus.Items(0)
        cmbShow.SelectedItem = cmbShow.Items(0)

        bolInit = False
        If bolSetSQL Then setSQL()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_data_servis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw.WorkerReportsProgress = True

        SetDGV(dgv)

        bolInit = True
        SetComboBox()
        SetDefault()

        'read only
        btnDelete.Visible = bolAllowEdit
        btnAdd.Visible = bolAllowEdit
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        Dim i As Integer = dgv.CurrentRow.Index
        txtNota.Text = dgv.Item(0, i).Value
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        EditData()
    End Sub

    Private Sub dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If e.ColumnIndex = 12 Then 'pembayaran
            If e.Value = "Lunas" Then
                dgv.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.LightGreen
            ElseIf e.Value = "DP" Then
                dgv.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.Coral
            ElseIf e.Value = "ATM" Then
                dgv.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.LightBlue
            ElseIf e.Value = "Tempo" Then
                dgv.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.IndianRed
            End If
        ElseIf e.ColumnIndex = 14 Then 'proses
            If e.Value = "Selesai" Then
                dgv.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.LightGreen
            ElseIf e.Value = "Proses" Then
                dgv.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.Yellow
            ElseIf e.Value = "Pending" Then
                dgv.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.Coral
            ElseIf e.Value = "Batal" Then
                dgv.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.IndianRed
            End If
        ElseIf e.ColumnIndex = 15 Then 'status
            If e.Value = "Diambil" Then
                dgv.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.LightGreen
            ElseIf e.Value = "Masuk" Then
                dgv.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.Yellow
            End If
        End If
    End Sub

    Private Sub cmbOption_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedValueChanged, cmbShow.SelectedValueChanged, cmbProses.SelectedValueChanged, cmbPembayaran.SelectedValueChanged
        setSQL()
    End Sub

    Private Sub txtFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            FindData()
        End If
    End Sub

End Class
