'(c) Rasan Samarasinghe 2013-11-25

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Campaign_Invoice
    Dim visitor As New Visitor()

    'list of fields
    Private campaigninvoice_id_ As Integer
    Private amount_ As String
    Private handled_ As String
    Private sponsorship_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'properties

    Public Property campaigninvoice_id As Integer
        Get
            Return campaigninvoice_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property amount As String
        Get
            Return amount_
        End Get
        Set(ByVal value As String)
            amount_ = value
        End Set
    End Property

    Public Property handled As String
        Get
            Return handled_
        End Get
        Set(ByVal value As String)
            handled_ = value
        End Set
    End Property

    Public Property sponsorship_id As Integer
        Get
            Return sponsorship_id_
        End Get
        Set(ByVal value As Integer)
            sponsorship_id_ = value
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

    Public Sub New(ByVal amount As String, ByVal sponsorship_id As Integer)
        campaigninvoice_id_ = getNewid()
        amount_ = amount
        handled_ = "Pending"
        sponsorship_id_ = sponsorship_id
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblCampaigninvoice WHERE [campaigninvoice_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                campaigninvoice_id_ = id
                amount_ = read.Item("amount")
                handled_ = read.Item("handled")
                sponsorship_id_ = read.Item("sponsorship_id")
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
            Dim cmdin As New SqlCommand("INSERT INTO tblCampaigninvoice VALUES (" & campaigninvoice_id_ & ", '" & amount_ & "', '" & handled_ & "', " & sponsorship_id_ & ", " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblCampaigninvoice SET [amount]='" & amount_ & "', handled='" & handled_ & "', sponsorship_id=" & sponsorship_id_ & " WHERE [campaigninvoice_id]=" & campaigninvoice_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblCampaigninvoice WHERE [campaigninvoice_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'get new id to insert
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblCampaigninvoice", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(campaigninvoice_id) FROM tblCampaigninvoice", DBConnection.SQLConnection)
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

    'to see whether paid or not
    Public Shared Function getPaymentStatus(ByVal campaigninvoice_id As Integer) As Boolean
        Dim handled As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [handled] FROM tblCampaigninvoice WHERE [campaigninvoice_id]=" & campaigninvoice_id, DBConnection.SQLConnection)
            handled = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return handled = "Paid"
    End Function
End Class
