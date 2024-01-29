Imports System.Data.SqlClient

Public Class BancoDeDados
    Private Shared Function GetDbConnection() As SqlConnection
        Try
            Dim connection As SqlConnection = New sqlConnection()
            connection.ConnectionString = "Data Source=KABIR-DESKTOP; _
         Initial Catalog=testDB;Integrated Security=True"
        Catch ex As Exception

        End Try
    End Function
End Class
