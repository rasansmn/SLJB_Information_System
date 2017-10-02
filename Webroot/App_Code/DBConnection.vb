'(c) Rasan Samarasinghe 2013-11-25
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DBConnection
    'database connection string
    Private Shared sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS; Initial Catalog=SLJBDB; Integrated Security=true")

    Public Shared Property SQLConnection As SqlConnection
        Get
            Return sqlcon
        End Get
        Set(ByVal value As SqlConnection)
        End Set
    End Property

    Public Shared Sub Open()
        sqlcon.Open()
    End Sub

    Public Shared Sub Close()
        sqlcon.Close()
    End Sub

End Class
