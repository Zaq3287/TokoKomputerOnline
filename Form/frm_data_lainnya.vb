
Imports System.ComponentModel
Imports MySqlConnector

Public Class frm_data_lainnya

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
                Dim result As Integer = DeleteLainnya(txtNota.Text)

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
        Dim subForm As New frm_edit_lainnya
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

        strSQL = "SELECT noNota, tanggal, karyawan, transaksi, jenis, total FROM tbl_lainnya" &
                    " WHERE noNota Like '%" & txtFind.Text & "%'" &
                    " OR transaksi LIKE '%" & txtFind.Text & "%'" &
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

        If cmbJenis.Text <> "Semua" Then
            strWhere = "jenis = '" & cmbJenis.Text & "'"
        End If

        If cmbShow.Text = "Limit" Then
            strLimit = " LIMIT 100"
        End If

        If strWhere.Length > 0 Then
            strWhere = " WHERE " & strWhere
        End If

        strSQL = "SELECT noNota, tanggal, karyawan, transaksi, jenis, total FROM tbl_lainnya" & strWhere & " ORDER BY noNota DESC" & strLimit

        If Not bolInit Then refreshData()
    End Sub

    Private Sub SetComboBox()
        cmbJenis.DataSource = {"Semua", "Keluar", "Masuk"}
        cmbShow.DataSource = {"Limit", "Semua"}
    End Sub

    Private Sub FormatGrid()
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "No nota"
        dgv.Columns(0).Width = 70
        dgv.Columns(1).HeaderCell.Value = "Tanggal"
        dgv.Columns(1).Width = 110
        dgv.Columns(2).HeaderCell.Value = "Karyawan"
        dgv.Columns(2).Width = 100
        dgv.Columns(3).HeaderCell.Value = "Transaksi"
        dgv.Columns(3).Width = 150
        dgv.Columns(4).HeaderCell.Value = "Jenis"
        dgv.Columns(4).Width = 80
        dgv.Columns(5).HeaderCell.Value = "Total"
        dgv.Columns(5).Width = 80
        dgv.Columns(5).DefaultCellStyle.Format = "N0"
        dgv.ResumeLayout()
    End Sub

    Private Sub SetDefault(Optional ByVal bolSetSQL As Boolean = True)
        'avoid setSQL calling automatically
        bolInit = True

        txtFind.Text = ""
        txtNota.Text = ""

        cmbJenis.SelectedItem = cmbJenis.Items(0)
        cmbShow.SelectedItem = cmbShow.Items(0)

        bolInit = False
        If bolSetSQL Then setSQL()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_data_lainnya_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If e.ColumnIndex = 4 Then 'pembayaran
            If e.Value = "Keluar" Then
                dgv.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.Yellow
            ElseIf e.Value = "Masuk" Then
                dgv.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.LightBlue
            End If
        End If
    End Sub

    Private Sub cmbOption_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbShow.SelectedValueChanged, cmbJenis.SelectedValueChanged
        setSQL()
    End Sub

    Private Sub txtFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            FindData()
        End If
    End Sub

End Class
