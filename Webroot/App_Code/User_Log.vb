'(c) Rasan Samarasinghe 2013-11-25
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class User_Log
    Dim visitor As New Visitor()
    'list of fields
    Private log_id_ As Integer
    Private entity_ As String
    Private action_ As String
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property log_id As Integer
        Get
            Return log_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property system_entity As String
        Get
            Return entity_
        End Get
        Set(ByVal value As String)
            entity_ = value
        End Set
    End Property

    Public Property action As String
        Get
            Return entity_
        End Get
        Set(ByVal value As String)
            entity_ = value
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

    Public Sub New(ByVal entity As String, ByVal action As String)
        log_id_ = getNewid()
        system_entity = entity
        action_ = action
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Function insert() As Boolean
        Dim affected As Integer
        Try
            DBConnection.Open()
            Dim cmdin As New SqlCommand("INSERT INTO tblLog VALUES (" & log_id_ & ", '" & entity_ & "', '" & action_ & "', " & user_id_ & ",'" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblLog WHERE [log_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'clear all!
    Public Shared Function clear() As Boolean
        Dim clr As Boolean
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("DELETE FROM tblLog", DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            clr = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return clr
    End Function

    'to insert a new record
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblLog", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(log_id) FROM tblLog", DBConnection.SQLConnection)
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

    'get number of logs of a user
    Public Shared Function getNumLogs(ByVal user_id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblLog WHERE [user_id]=" & user_id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

End Class
