Imports System.Data.SqlClient

Public Class BancoDeDados
    Private Shared Function GetDbConnection() As SqlConnection
        Try
            Dim connection As SqlConnection = New sqlConnection()
            connection.ConnectionString = "Data Source=DESKTOP-TOTE7QV;Initial Catalog=TestePortifolioDB;Integrated Security=True"
            connection.Open()
            Return connection
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Overloads Shared Function GetDataTable(ByVal sql As String)
        Using connection As SqlConnection = GetDbConnection()
            Using da As New SqlDataAdapter(sql, connection)
                Dim table As New DataTable
                da.Fill(table)
                Return table
            End Using
        End Using
    End Function
    Public Overloads Shared Function ExecuteNonQuery(ByVal sql As String)
        Using connection As SqlConnection = GetDbConnection()
            Dim comando = New SqlCommand(sql, connection)
            comando.ExecuteNonQuery()
        End Using
    End Function
End Class
