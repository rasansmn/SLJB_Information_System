Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Sponsorship
    Dim visitor As New Visitor()
    'list of fields
    Private sponsorship_id_ As Integer
    Private emp_id_ As Integer
    Private campaign_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property sponsorship_id As Integer
        Get
            Return sponsorship_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property emp_id As Integer
        Get
            Return emp_id_
        End Get
        Set(ByVal value As Integer)
            emp_id_ = value
        End Set
    End Property

    Public Property campaign_id As Integer
        Get
            Return campaign_id_
        End Get
        Set(ByVal value As Integer)
            campaign_id_ = value
        End Set
    End Property

    Public Property user_id As Integer
        Get
            Return user_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property created_time As Date
        Get
            Return created_time_
        End Get
        Set(ByVal value As Date)
        End Set
    End Property

    Public Sub New(ByVal emp_id As Integer, ByVal campaign_id As Integer)
        sponsorship_id_ = getNewid()
        emp_id_ = emp_id
        campaign_id_ = campaign_id
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblSponsorship WHERE [sponsorship_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                sponsorship_id_ = id
                emp_id_ = read.Item("emp_id")
                campaign_id_ = read.Item("campaign_id")
                user_id_ = read.Item("user_id")
                created_time_ = read.Item("created_time")
            End While
            read.Close()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
    End Sub

    Public Function insert() As Boolean
        Dim affected As Integer
        Try
            DBConnection.Open()
            Dim cmdin As New SqlCommand("INSERT INTO tblSponsorship VALUES (" & sponsorship_id_ & ", " & emp_id_ & ", " & campaign_id_ & ", " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
            affected = cmdin.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return affected > 0
    End Function

    Public Shared Function delete(ByVal id As Integer) As Boolean
        Dim deleted As Boolean
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("DELETE FROM tblSponsorship WHERE [sponsorship_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'to get a new id to insert
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblSponsorship", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(sponsorship_id) FROM tblSponsorship", DBConnection.SQLConnection)
                newid = cmd.ExecuteScalar
            End If
            newid += 1
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return newid
    End Function

End Class
