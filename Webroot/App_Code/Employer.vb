Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Employer
    Dim visitor As New Visitor()
    'list of fields
    Private employer_id_ As Integer
    Private name_ As String
    Private description_ As String
    Private address_ As String
    Private phone_ As String
    Private fax_ As String
    Private email_ As String
    Private website_ As String
    Private coordinator_ As String
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property employer_id As Integer
        Get
            Return employer_id_
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

    Public Property description As String
        Get
            Return description_
        End Get
        Set(ByVal value As String)
            description_ = value
        End Set
    End Property

    Public Property address As String
        Get
            Return address_
        End Get
        Set(ByVal value As String)
            address_ = value
        End Set
    End Property

    Public Property phone As String
        Get
            Return phone_
        End Get
        Set(ByVal value As String)
            phone_ = value
        End Set
    End Property

    Public Property fax As String
        Get
            Return fax_
        End Get
        Set(ByVal value As String)
            fax_ = value
        End Set
    End Property

    Public Property email As String
        Get
            Return email_
        End Get
        Set(ByVal value As String)
            email_ = value
        End Set
    End Property

    Public Property website As String
        Get
            Return website_
        End Get
        Set(ByVal value As String)
            website_ = value
        End Set
    End Property

    Public Property coordinator As String
        Get
            Return coordinator_
        End Get
        Set(ByVal value As String)
            coordinator_ = value
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

    Public Sub New(ByVal name As String, ByVal description As String, ByVal address As String, ByVal phone As String, ByVal fax As String, ByVal email As String, ByVal website As String, ByVal coordinator As String)
        employer_id_ = getNewid()
        name_ = name
        description_ = description
        address_ = address
        phone_ = phone
        fax_ = fax
        email_ = email
        website_ = website
        coordinator_ = coordinator
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblEmployer WHERE [emp_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                employer_id_ = id
                name_ = read.Item("name").ToString()
                description_ = read.Item("description").ToString()
                address_ = read.Item("address").ToString()
                phone_ = read.Item("phone").ToString()
                fax_ = read.Item("fax").ToString()
                email_ = read.Item("email").ToString()
                website_ = read.Item("website").ToString()
                coordinator_ = read.Item("coordinator").ToString()
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
            Dim cmdin As New SqlCommand("INSERT INTO tblEmployer VALUES (" & employer_id_ & ", '" & name_ & "', '" & description_ & "', '" & address_ & "', '" & phone_ & "', '" & fax_ & "', '" & email_ & "', '" & website_ & "', '" & coordinator_ & "', " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblEmployer SET [name]='" & name_ & "', [description]='" & description_ & "', [address]='" & address_ & "', [phone]='" & phone_ & "', [fax]='" & fax_ & "', [email]='" & email_ & "', [website]='" & website_ & "', [coordinator]='" & coordinator_ & "' WHERE [emp_id]=" & employer_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblEmployer WHERE [emp_id]=" & id, DBConnection.SQLConnection)
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
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblEmployer", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(emp_id) FROM tblEmployer", DBConnection.SQLConnection)
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

    'to show number of vacancies in the list
    Public Shared Function getNo_of_vacancies(ByVal id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblVacancy WHERE [emp_id]=" & id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to show the name in vacancies, applications info
    Public Shared Function getName(ByVal id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [name] FROM tblEmployer WHERE [emp_id]=" & id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

    'to show the name on sponsorships list
    Public Shared Function getNamebySponsorshipid(ByVal sponsorship_id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT tblEmployer.name FROM tblEmployer INNER JOIN tblSponsorship ON tblEmployer.emp_id = tblSponsorship.emp_id AND tblSponsorship.sponsorship_id=" & sponsorship_id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

    'to show the link on sponsorships list
    Public Shared Function getIDbySponsorshipid(ByVal sponsorship_id As Integer) As Integer
        Dim id As Integer
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT tblEmployer.emp_id FROM tblEmployer INNER JOIN tblSponsorship ON tblEmployer.emp_id = tblSponsorship.emp_id AND tblSponsorship.sponsorship_id=" & sponsorship_id, DBConnection.SQLConnection)
            id = cmd.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return id
    End Function

    'to show the name on vacancies list
    Public Shared Function getNamebyVacany(ByVal vacancy_id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT tblEmployer.name FROM tblEmployer INNER JOIN tblVacancy ON tblEmployer.emp_id = tblVacancy.emp_id AND tblVacancy.vacancy_id=" & vacancy_id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

    Public Shared Function getIDbyVacancy(ByVal vacancy_id As Integer) As Integer
        Dim id As Integer
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT tblEmployer.emp_id FROM tblEmployer INNER JOIN tblVacancy ON tblEmployer.emp_id = tblVacancy.emp_id AND tblVacancy.vacancy_id=" & vacancy_id, DBConnection.SQLConnection)
            id = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return id
    End Function

    Public Shared Function getEmailbyVacancy(ByVal vacancy_id As Integer) As Integer
        Dim id As Integer
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT tblEmployer.email FROM tblEmployer INNER JOIN tblVacancy ON tblEmployer.emp_id = tblVacancy.emp_id AND tblVacancy.vacancy_id=" & vacancy_id, DBConnection.SQLConnection)
            id = cmd.ExecuteScalar().ToString
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return id
    End Function

End Class
