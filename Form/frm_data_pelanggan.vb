
Imports System.ComponentModel
Imports MySqlConnector

Public Class frm_data_pelanggan

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

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FindData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        OpenSubForm()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(txtNama.Text) = False Then
            Dim resultDlg As DialogResult = MessageBox.Show("You are about to deleted the selected record." & vbNewLine &
                                                        "This action cannot be undone. Do you want to proceed?", strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultDlg = DialogResult.Yes Then
                Dim result As Integer = DeletePelanggan(txtNama.Text)

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
        Dim subForm As New frm_edit_pelanggan
        subForm.ShowInTaskbar = False
        AddOwnedForm(subForm)
        subForm.ShowDialog()

        If gbolEdit Then setSQL()
    End Sub
    Private Sub EditData()
        If String.IsNullOrEmpty(txtNama.Text) = False Then
            gstrNoNota = txtNama.Text

            OpenSubForm()

            gstrNoNota = ""
        End If
    End Sub
    Private Sub FindData()
        If String.IsNullOrEmpty(txtFind.Text) Then Exit Sub

        strSQL = "SELECT nama, telepon, alamat FROM tbl_pelanggan" &
                    " WHERE nama Like '%" & txtFind.Text & "%'" &
                    " OR telepon LIKE '%" & txtFind.Text & "%'" &
                    " OR alamat LIKE '%" & txtFind.Text & "%'" &
                    " ORDER BY nama"

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
        txtFind.Text = ""
        txtNama.Text = ""

        strSQL = "SELECT nama, telepon, alamat FROM tbl_pelanggan ORDER BY nama"

        If Not bolInit Then refreshData()
    End Sub

    Private Sub FormatGrid()
        dgv.SuspendLayout()
        dgv.Columns(0).HeaderCell.Value = "Nama"
        dgv.Columns(0).Width = 200
        dgv.Columns(1).HeaderCell.Value = "Telepon"
        dgv.Columns(1).Width = 120
        dgv.Columns(2).HeaderCell.Value = "Alamat"
        dgv.Columns(2).Width = 330
        dgv.ResumeLayout()
    End Sub

    Private Sub SetDefault(Optional ByVal bolSetSQL As Boolean = True)
        'avoid setSQL calling automatically
        bolInit = True

        txtFind.Text = ""
        txtNama.Text = ""

        bolInit = False
        If bolSetSQL Then setSQL()
    End Sub

    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    ' control
    ' -------------------------------------------------------------
    ' -------------------------------------------------------------
    Private Sub frm_data_pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bgw.WorkerReportsProgress = True

        SetDGV(dgv)

        bolInit = True
        SetDefault()

        'read only
        btnDelete.Visible = bolAllowEdit
        btnAdd.Visible = bolAllowEdit
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        Dim i As Integer = dgv.CurrentRow.Index
        txtNama.Text = dgv.Item(0, i).Value
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        EditData()
    End Sub


    Private Sub txtFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            FindData()
        End If
    End Sub

End Class
