'(c) Rasan Samarasinghe 2013-11-25
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class User_Account
    Inherits Visitor
    'list of fields
    Private user_id_ As Integer
    Private name_ As String
    Private username_ As String
    Private password_ As String
    Private permission_ As Integer

    'list of properties

    Public Property user_id As Integer
        Get
            Return user_id_
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

    Public Property username As String
        Get
            Return username_
        End Get
        Set(ByVal value As String)
            username_ = value
        End Set
    End Property

    Public Property password As String
        Get
            Return password_
        End Get
        Set(ByVal value As String)
            password_ = value
        End Set
    End Property

    Public Property permission As Integer
        Get
            Return permission_
        End Get
        Set(ByVal value As Integer)
            permission_ = value
        End Set
    End Property

    Public Sub New(ByVal username As String, ByVal name As String, ByVal password As String, ByVal permission As Permission)
        user_id_ = getNewid()
        username_ = username
        name_ = name
        password_ = getmd5(password)
        permission_ = permission
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblUser WHERE user_id=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                user_id_ = id
                username_ = read.Item("username").ToString()
                name_ = read.Item("name").ToString()
                password_ = read.Item("password").ToString()
                permission_ = CInt(read.Item("permission"))
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
            Dim cmdin As New SqlCommand("INSERT INTO tblUser VALUES (" & user_id_ & ",'" & name_ & "','" & username_ & "','" & password_ & "'," & permission_ & ")", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblUser SET [name]='" & name_ & "', [username]='" & username_ & "', [password]='" & getmd5(password_) & "' WHERE [user_id]=" & user_id_, DBConnection.SQLConnection)
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
            'cascade delete disabled for reference key tables
            Dim cmd As New SqlCommand("DELETE FROM tblApplication WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            Dim cmd2 As New SqlCommand("DELETE tblApplication FROM tblApplication INNER JOIN tblVacancy ON tblApplication.vacancy_id=tblVacancy.vacancy_id AND tblVacancy.user_id=" & id, DBConnection.SQLConnection)
            cmd2.ExecuteNonQuery()
            Dim cmd3 As New SqlCommand("DELETE FROM tblVacancy WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd3.ExecuteNonQuery()
            Dim cmd4 As New SqlCommand("DELETE FROM tblCampaigninvoice WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd4.ExecuteNonQuery()
            Dim cmd5 As New SqlCommand("DELETE FROM tblSponsorship WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd5.ExecuteNonQuery()
            Dim cmd6 As New SqlCommand("DELETE FROM tblVacancyinvoice WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd6.ExecuteNonQuery()
            Dim cmd7 As New SqlCommand("DELETE FROM tblDsdivision WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd7.ExecuteNonQuery()
            Dim cmd8 As New SqlCommand("DELETE FROM tblDistrict WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd8.ExecuteNonQuery()
            Dim cmd9 As New SqlCommand("DELETE FROM tblUser WHERE [user_id]=" & id, DBConnection.SQLConnection)
            cmd9.ExecuteNonQuery()
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
            Dim cmdcount As New SqlCommand("SELECT COUNT (*) FROM tblUser", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(user_id) FROM tblUser", DBConnection.SQLConnection)
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

    'to check existance when updating account
    Public Shared Function getExist(ByVal username As String) As Boolean
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblUser WHERE [username]='" & username & "'", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count > 0
    End Function

End Class
