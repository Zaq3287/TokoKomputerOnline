Imports MySqlConnector

Module mod_MySQL

    Private strServer As String = ""
    Public strDatabase As String = ""
    Private strUserID As String = ""
    Private strPassword As String = ""
    Private port As Integer = 3306

    Public mySQLConn As MySqlConnection = GetMySQL()
    Public mySQLConn2 As MySqlConnection = GetMySQL()

    Private funcMySQLConn As MySqlConnection = GetMySQL()

    Private Function GetConnectionStringBuilder() As MySqlConnectionStringBuilder
        Dim myCSB As MySqlConnectionStringBuilder = New MySqlConnectionStringBuilder With
            {
                .Server = strServer,
                .UserID = strUserID,
                .Password = strPassword,
                .Database = strDatabase,
                .Port = port,
                .CharacterSet = "utf8mb4",
                .ConnectionTimeout = 60,
                .SslMode = MySqlSslMode.Disabled,
                .UseCompression = True,
                .MaximumPoolSize = 50
            }
        Return myCSB
    End Function

    Public Function GetMySQL() As MySqlConnection
        Dim conn As MySqlConnection = New MySqlConnection(GetConnectionStringBuilder().ConnectionString)
        Return conn
    End Function

    Public Function GetDataSet(ByVal strSQL As String, Optional ByVal bolShowMessage As Boolean = True) As Object
        Dim result As Object = Nothing
        Dim dataSet As New DataSet()
        Try
            Using dataAdapter As New MySqlDataAdapter(strSQL, funcMySQLConn)
                dataAdapter.Fill(dataSet, "data")
                result = dataSet.Tables("data")
            End Using
        Catch ex As Exception
            If bolShowMessage Then showErrorDB(ex.Message)
        End Try

        Return result
    End Function

    Public Function ExecScalar(ByVal strSQL As String, Optional ByVal bolShowMessage As Boolean = True) As Object
        Dim result As Object = Nothing
        Try
            Using cmd = New MySqlCommand(strSQL, funcMySQLConn)
                funcMySQLConn.Open()
                result = cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            If bolShowMessage Then showErrorDB(ex.Message)
        Finally
            funcMySQLConn.Close()
        End Try

        Return result
    End Function

    Public Function ExecCommand(ByVal strSQL As String, Optional ByVal bolShowMessage As Boolean = True) As Object
        Dim result As Object = Nothing
        Try
            Using cmd = New MySqlCommand(strSQL, funcMySQLConn)
                funcMySQLConn.Open()
                cmd.ExecuteNonQuery()
                result = 0
            End Using
        Catch ex As Exception
            If bolShowMessage Then showErrorDB(ex.Message)
        Finally
            funcMySQLConn.Close()
        End Try

        Return result
    End Function

    Public Function RecordExist(ByVal strSQL As String) As Boolean
        Dim result As Boolean = False
        Try
            Using cmd = New MySqlCommand(strSQL, funcMySQLConn)
                funcMySQLConn.Open()
                Dim tmp As Object = cmd.ExecuteScalar()
                If Not tmp Is Nothing Then result = True
            End Using
        Catch ex As Exception
            'do nothing
        Finally
            funcMySQLConn.Close()
        End Try

        Return result
    End Function
End Module
