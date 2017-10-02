'(c) Rasan Samarasinghe 2013-11-25

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Campaign
    Dim visitor As New Visitor()

    'Fields

    Private campaign_id_ As Integer
    Private location_ As String
    Private campaign_date_ As Date
    Private dsdivision_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'Properties list

    Public Property campaign_id As Integer
        Get
            Return campaign_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property location As String
        Get
            Return location_
        End Get
        Set(ByVal value As String)
            location_ = value
        End Set
    End Property

    Public Property campaign_date As Date
        Get
            Return campaign_date_
        End Get
        Set(ByVal value As Date)
            campaign_date_ = value
        End Set
    End Property

    Public Property dsdivision_id As Integer
        Get
            Return dsdivision_id_
        End Get
        Set(ByVal value As Integer)
            dsdivision_id_ = value
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

    Public Sub New(ByVal location As String, ByVal campaign_date As Date, ByVal dsdivision_id As Integer)
        campaign_id_ = getNewid()
        location_ = location
        campaign_date_ = campaign_date
        dsdivision_id_ = dsdivision_id
        user_id_ = Visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblCampaign WHERE [campaign_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                campaign_id_ = id
                location_ = read.Item("location").ToString()
                campaign_date_ = read.Item("date").ToString()
                dsdivision_id_ = read.Item("dsdivision_id").ToString()
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
            Dim cmdin As New SqlCommand("INSERT INTO tblCampaign VALUES (" & campaign_id_ & ",'" & location_ & "', '" & campaign_date_ & "', " & dsdivision_id_ & "," & user_id_ & ",'" & created_time_ & "')", DBConnection.SQLConnection)
            affected = cmdin.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return affected > 0
    End Function

    Public Function update() As Boolean
        Dim affected As Integer
        Try
            DBConnection.Open()
            Dim cmdin As New SqlCommand("UPDATE tblCampaign SET [location]='" & location_ & "', Date='" & campaign_date_ & "', dsdivision_id=" & dsdivision_id_ & " WHERE [campaign_id]=" & campaign_id_, DBConnection.SQLConnection)
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
            'cascade delete disabled
            Dim cmd As New SqlCommand("DELETE FROM tblSponsorship WHERE [campaign_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            Dim cmd2 As New SqlCommand("DELETE FROM tblCampaign WHERE [campaign_id]=" & id, DBConnection.SQLConnection)
            cmd2.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'to get new user id to insert
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblCampaign", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(campaign_id) FROM tblCampaign", DBConnection.SQLConnection)
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

    'get location by campaign id
    Public Shared Function getLocation(ByVal id As Integer) As String
        Dim location As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [location] FROM tblCampaign WHERE [campaign_id]=" & id, DBConnection.SQLConnection)
            location = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return location
    End Function

End Class
