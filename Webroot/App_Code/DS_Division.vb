Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DS_Division
    Dim visitor As New Visitor()
    'list of fields
    Private dsdivision_id_ As Integer
    Private name_ As String
    Private district_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property dsdivision_id As Integer
        Get
            Return dsdivision_id_
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

    Public Property district_id As Integer
        Get
            Return district_id_
        End Get
        Set(ByVal value As Integer)
            district_id_ = value
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

    Public Sub New(ByVal name As String, ByVal district_id As Integer)
        dsdivision_id_ = getNewid()
        name_ = name
        district_id_ = district_id
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblDsdivision WHERE [dsdivision_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                dsdivision_id_ = id
                name_ = read.Item("name").ToString()
                district_id_ = read.Item("district_id")
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
            Dim cmdin As New SqlCommand("INSERT INTO tblDsdivision VALUES (" & dsdivision_id_ & ", '" & name_ & "', " & district_id_ & ", " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblDsdivision SET [name]='" & name_ & "', [district_id]=" & district_id_ & " WHERE [dsdivision_id]=" & dsdivision_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblDsdivision WHERE [dsdivision_id]=" & id, DBConnection.SQLConnection)
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
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblDsdivision", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(dsdivision_id) FROM tblDsdivision", DBConnection.SQLConnection)
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

    'to show the number in districts list
    Public Shared Function getNo_of_divisions(ByVal id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblDsdivision WHERE [district_id]=" & id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to show name on job seekers info
    Public Shared Function getName(ByVal id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [name] FROM tblDsdivision WHERE [dsdivision_id]=" & id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

End Class
