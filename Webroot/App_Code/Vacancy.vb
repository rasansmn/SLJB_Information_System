Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Vacancy
    Dim visitor As New Visitor()
    'list of fields
    Private vacancy_id_ As Integer
    Private title_ As String
    Private description_ As String
    Private qualifications_ As String
    Private status_ As String
    Private no_of_positions_ As String
    Private interview_date_ As String
    Private salary_ As String
    Private emp_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties

    Public Property vacancy_id As Integer
        Get
            Return vacancy_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property title As String
        Get
            Return title_
        End Get
        Set(ByVal value As String)
            title_ = value
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

    Public Property qualifications As String
        Get
            Return qualifications_
        End Get
        Set(ByVal value As String)
            qualifications_ = value
        End Set
    End Property

    Public Property status As String
        Get
            Return status_
        End Get
        Set(ByVal value As String)
            status_ = value
        End Set
    End Property

    Public Property no_of_positions As String
        Get
            Return no_of_positions_
        End Get
        Set(ByVal value As String)
            no_of_positions_ = value
        End Set
    End Property

    Public Property interview_date As String
        Get
            Return interview_date_
        End Get
        Set(ByVal value As String)
            interview_date_ = value
        End Set
    End Property

    Public Property salary As String
        Get
            Return salary_
        End Get
        Set(ByVal value As String)
            salary_ = value
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

    Public Sub New(ByVal title As String, ByVal description As String, ByVal qualifications As String, ByVal status As String, ByVal no_of_positions As String, ByVal interview_date As String, ByVal salary As String, ByVal emp_id As Integer)
        vacancy_id_ = getNewid()
        title_ = title
        description_ = description
        qualifications_ = qualifications
        status_ = status
        no_of_positions_ = no_of_positions
        interview_date_ = interview_date
        salary_ = salary
        emp_id_ = emp_id
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblVacancy WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                vacancy_id_ = id
                title_ = read.Item("title").ToString()
                description_ = read.Item("description").ToString()
                qualifications_ = read.Item("qualifications").ToString()
                status_ = read.Item("status").ToString()
                no_of_positions_ = read.Item("no_of_positions").ToString()
                interview_date_ = read.Item("interview_date").ToString()
                salary_ = read.Item("salary_range").ToString()
                emp_id_ = read.Item("emp_id")
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
            Dim cmdin As New SqlCommand("INSERT INTO tblVacancy VALUES (" & vacancy_id_ & ", '" & title_ & "', '" & description_ & "', '" & qualifications_ & "', '" & status_ & "', '" & no_of_positions_ & "', '" & interview_date_ & "', '" & salary_ & "', " & emp_id_ & ", " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblVacancy SET [title]='" & title_ & "', [description]='" & description_ & "', [qualifications]='" & qualifications_ & "', [status]='" & status_ & "', [no_of_positions]='" & no_of_positions_ & "', [interview_date]='" & interview_date_ & "', [salary_range]='" & salary_ & "', [emp_id]=" & emp_id_ & " WHERE [vacancy_id]=" & vacancy_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblApplication WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            Dim cmd2 As New SqlCommand("DELETE FROM tblVacancy WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            cmd2.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'open the vacancy
    Public Shared Function Open(ByVal id As Integer) As Boolean
        Dim Opened As Boolean
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("UPDATE tblVacancy SET [status]='Open' WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            Opened = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return Opened
    End Function

    'close the vacancy
    Public Shared Function Close(ByVal id As Integer) As Boolean
        Dim Closed As Boolean
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("UPDATE tblVacancy SET [status]='Closed' WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            Closed = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return Closed
    End Function

    'to insert a new record
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblVacancy", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(vacancy_id) FROM tblVacancy", DBConnection.SQLConnection)
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

    'get no of applications for each vacancy
    Public Shared Function getNo_of_applications(ByVal id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblApplication WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to get no of vacancies of each employer
    Public Shared Function getNoOfVacancies(ByVal emp_id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblVacancy WHERE [emp_id]=" & emp_id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to show title on applications list
    Public Shared Function getTitle(ByVal id As Integer) As String
        Dim title As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [title] FROM tblVacancy WHERE [vacancy_id]=" & id, DBConnection.SQLConnection)
            title = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return title
    End Function

End Class
