'(c) Rasan Samarasinghe 2013-11-25
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Enum Permission As Integer
    admin = 3
    coordinator = 2
    data_entry_operator = 1
End Enum

Public Class Visitor
    Inherits System.Web.UI.Page

    Function Login(ByVal Username As String, ByVal Password As String) As Boolean
        DBConnection.Open()
        Dim cmdcount As SqlCommand = New SqlCommand("SELECT [user_id] FROM tblUser WHERE [permission] > 0 AND [username]='" + Username + "' AND [password]='" + getmd5(Password) + "'", DBConnection.SQLConnection)
        Dim user_id As Object = cmdcount.ExecuteScalar()
        DBConnection.Close()
        If CInt(user_id) > 0 Then
            setSession(user_id)
            Return True
        Else
            Return False
        End If
        Return False
    End Function

    'set as logged user!
    Sub setSession(ByVal uid As Integer)
        Session("uid") = Nothing
        Session("uid") = uid
    End Sub

    Sub logout()
        Session("uid") = Nothing
    End Sub

    'get user id of ses
    Public Function getSession() As Integer
        If Session("uid") <> Nothing Then
            Return Session("uid")
        End If
        Return 0
    End Function

    'who is the user?
    Public Function getPerm() As Integer
        Dim perm As Integer = 0
        If getSession() > 0 Then
            Try
                DBConnection.Open()
                Dim cmd As New SqlCommand("SELECT [permission] FROM tblUser WHERE [user_id]=" & getSession(), DBConnection.SQLConnection)
                perm = cmd.ExecuteScalar()
            Catch ex As Exception
            Finally
                DBConnection.Close()
            End Try
        End If
        Return perm
    End Function

    'who is the user?
    Public Function getPerm(ByVal id As Integer) As Integer
        Dim perm As Integer = 0
            Try
                DBConnection.Open()
                Dim cmd As New SqlCommand("SELECT [permission] FROM tblUser WHERE [user_id]=" & id, DBConnection.SQLConnection)
                perm = cmd.ExecuteScalar()
            Catch ex As Exception
            Finally
                DBConnection.Close()
            End Try
        Return perm
    End Function

    'password encryption
    Protected Function getmd5(ByVal SourceText As String) As String
        Dim Ue As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Shared Function getName(ByVal id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [username] FROM tblUser WHERE [user_id]=" & id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

End Class
