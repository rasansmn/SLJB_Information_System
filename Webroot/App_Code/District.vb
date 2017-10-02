Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class District
    Dim visitor As New Visitor()
    'list of fields
    Private district_id_ As Integer
    Private name_ As String
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property district_id As Integer
        Get
            Return district_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property name As String
        Get
            Return name_
        End Get
        Set(ByVal value As String)
            name_ = value
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

    Public Sub New(ByVal name As String)
        district_id_ = getNewid()
        name_ = name
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblDistrict WHERE [district_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                district_id_ = id
                name_ = read.Item("name").ToString()
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
            Dim cmdin As New SqlCommand("INSERT INTO tblDistrict VALUES (" & district_id_ & ",'" & name_ & "', " & user_id_ & ",'" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblDistrict SET [name]='" & name_ & "' WHERE [district_id]=" & district_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblDistrict WHERE [district_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'to get new id to insert
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblDistrict", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(district_id) FROM tblDistrict", DBConnection.SQLConnection)
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

    'to show name on the districts table
    Public Shared Function getName(ByVal id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [name] FROM tblDistrict WHERE [district_id]=" & id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

End Class
