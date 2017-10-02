Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Vacancy_Application
    Private Shared send_email As Boolean = False 'turn on email messages
    'list of fields
    Private application_id_ As Integer
    Private jobseeker_ As Job_Seeker
    Private vacancy_ As Vacancy
    Private user_ As Visitor
    Private created_time_ As Date

    'list of properties
    Public Property application_id As Integer
        Get
            Return application_id_
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Property jobseeker As Job_Seeker
        Get
            Return jobseeker_
        End Get
        Set(ByVal value As Job_Seeker)
            jobseeker_ = value
        End Set
    End Property

    Public Property vacancy As Vacancy
        Get
            Return vacancy_
        End Get
        Set(ByVal value As Vacancy)
            vacancy_ = value
        End Set
    End Property

    Public Property user As Visitor
        Get
            Return user_
        End Get
        Set(ByVal value As Visitor)
            user_ = value
        End Set
    End Property

    Public Property created_time As Date
        Get
            Return created_time_
        End Get
        Set(ByVal value As Date)
        End Set
    End Property

    Public Sub New(ByVal jobseeker As Job_Seeker, ByVal vacancy As Vacancy)
        application_id_ = getNewid()
        jobseeker_ = jobseeker
        vacancy_ = vacancy
        user_ = New Visitor()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblApplication WHERE [application_id]=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                application_id_ = id
                jobseeker_ = New Job_Seeker(read.Item("jobseeker_id"))
                vacancy_ = New Vacancy(read.Item("vacancy_id"))
                user_ = New Visitor()
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
            Dim cmdin As New SqlCommand("INSERT INTO tblApplication VALUES (" & application_id_ & "," & jobseeker_.jobseeker_id & ", " & vacancy_.vacancy_id & ", " & user_.getSession() & ",'" & created_time_ & "')", DBConnection.SQLConnection)
            affected = cmdin.ExecuteNonQuery()

            Try ' to send resume to the employer
                Dim sb As New StringBuilder
                Dim mailmsg As New System.Net.Mail.MailMessage
                Dim mailaddr As New System.Net.Mail.MailAddress("fedoramedi@wegaspace.com")
                Dim mailer As New System.Net.Mail.SmtpClient()
                Dim creds As New System.Net.NetworkCredential("fedoramedi@wegaspace.com", "1234")
                sb.AppendLine("<b>Name:</b> " & jobseeker_.name)
                sb.AppendLine("<b>Address:</b> " & jobseeker_.address)
                sb.AppendLine("<b>Phone:</b> " & jobseeker_.phone)
                sb.AppendLine("<b>Birthday:</b> " & jobseeker_.birthday)
                sb.AppendLine("<b>Gender:</b> " & jobseeker_.gender)
                sb.AppendLine("<b>Ordinary Level:</b> " & jobseeker_.ordinary_level)
                sb.AppendLine("<b>Advanced Level:</b> " & jobseeker_.Advanced_level)
                sb.AppendLine("<b>Work Experience:</b> " & jobseeker_.name)
                sb.AppendLine("<br><br>Thank you.")
                sb.AppendLine("<br>Sri Lanka Job Bank") 'add additional text
                mailmsg.IsBodyHtml = True
                mailmsg.Subject = "Application For The Vacancy: " & vacancy_.title
                mailmsg.Body = sb.ToString()
                mailmsg.From = mailaddr
                mailer.Host = "mail.wegaspace.com"
                mailer.UseDefaultCredentials = False
                mailer.Credentials = creds
                If send_email = True Then
                    mailmsg.To.Add(Employer.getEmailbyVacancy(vacancy_.vacancy_id))
                    mailer.Send(mailmsg)
                End If
            Catch ex As Exception
            End Try
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
            Dim cmd As New SqlCommand("DELETE FROM tblApplication WHERE [application_id]=" & id, DBConnection.SQLConnection)
            cmd.ExecuteNonQuery()
            deleted = True
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return deleted
    End Function

    'insert new record
    Private Function getNewid() As Integer
        Dim count, newid As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblApplication", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(application_id) FROM tblApplication", DBConnection.SQLConnection)
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

    'to get no of applications of each job seeker
    Public Shared Function getApplicationsbyjobseeker(ByVal jobseeker_id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblApplication WHERE [jobseeker_id]=" & jobseeker_id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to get no of applications per each vacancy
    Public Shared Function getApplicationsbyvacancy(ByVal vacancy_id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblApplication WHERE [vacancy_id]=" & vacancy_id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

End Class
