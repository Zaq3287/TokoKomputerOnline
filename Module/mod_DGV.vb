Imports System.Reflection

Module mod_DGV

    Private Sub DoubleBufferedPanel(ByVal myPanel As Object, ByVal setting As Boolean)
        Dim panType As Type = myPanel.[GetType]()
        Dim pi As PropertyInfo = panType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(myPanel, setting, Nothing)
    End Sub

    Public Sub SetDGV(ByVal dataGridView As DataGridView)
        DoubleBufferedPanel(dataGridView, True)
        dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        dataGridView.RowHeadersVisible = False
        dataGridView.EditMode = False
        dataGridView.ReadOnly = True
        dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dataGridView.RowTemplate.Height = 50
        dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dataGridView.AllowUserToAddRows = False
    End Sub

    Public Sub SetDataSource(ByVal dataGridView As DataGridView, ByVal strSQL As String)
        Dim result As Object = mod_MySQL.GetDataSet(strSQL)

        If result IsNot Nothing Then
            dataGridView.Invoke(Sub() dataGridView.DataSource = result)
        End If
    End Sub

End Module
