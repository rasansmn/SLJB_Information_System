Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Job_Seeker
    Dim visitor As New Visitor()
    'list of fields
    Private jobseeker_id_ As Integer
    Private name_ As String
    Private address_ As String
    Private phone_ As String
    Private status_ As String
    Private nic_ As String
    Private birthday_ As Date
    Private gender_ As String
    Private license_ As String
    Private languages_ As String
    Private ordinary_level_ As String
    Private advanced_level_ As String
    Private higher_edu_ As String
    Private work_experience_ As String
    Private cv_ As String
    Private dsdivision_id_ As Integer
    Private user_id_ As Integer
    Private created_time_ As Date

    'list of properties 

    Public Property jobseeker_id As Integer
        Get
            Return jobseeker_id_
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

    Public Property status As String
        Get
            Return status_
        End Get
        Set(ByVal value As String)
            status_ = value
        End Set
    End Property

    Public Property nic As String
        Get
            Return nic_
        End Get
        Set(ByVal value As String)
            nic_ = value
        End Set
    End Property

    Public Property birthday As Date
        Get
            Return birthday_
        End Get
        Set(ByVal value As Date)
            birthday_ = value
        End Set
    End Property

    Public Property gender As String
        Get
            Return gender_
        End Get
        Set(ByVal value As String)
            gender_ = value
        End Set
    End Property

    Public Property license As String
        Get
            Return license_
        End Get
        Set(ByVal value As String)
            license_ = value
        End Set
    End Property

    Public Property languages As String
        Get
            Return languages_
        End Get
        Set(ByVal value As String)
            languages_ = value
        End Set
    End Property

    Public Property ordinary_level As String
        Get
            Return ordinary_level_
        End Get
        Set(ByVal value As String)
            ordinary_level_ = value
        End Set
    End Property

    Public Property Advanced_level As String
        Get
            Return advanced_level_
        End Get
        Set(ByVal value As String)
            advanced_level_ = value
        End Set
    End Property

    Public Property higher_edu As String
        Get
            Return higher_edu_
        End Get
        Set(ByVal value As String)
            higher_edu_ = value
        End Set
    End Property

    Public Property work_experience As String
        Get
            Return work_experience_
        End Get
        Set(ByVal value As String)
            work_experience_ = value
        End Set
    End Property

    Public Property cv As String
        Get
            Return cv_
        End Get
        Set(ByVal value As String)
            cv_ = value
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

    Public Sub New(ByVal name As String, ByVal address As String, ByVal phone As String, ByVal status As String, ByVal nic As String, ByVal birthday As Date, ByVal gender As String, ByVal license As String, ByVal languages As String, ByVal ordinary_level As String, ByVal advanced_level As String, ByVal higher_edu As String, ByVal work_experience As String, ByVal cv As String, ByVal dsdivision_id As Integer)
        jobseeker_id_ = getNewid()
        name_ = name
        address_ = address
        phone_ = phone
        status_ = status
        nic_ = nic
        birthday_ = birthday
        gender_ = gender
        license_ = license
        languages_ = languages
        ordinary_level_ = ordinary_level
        advanced_level_ = advanced_level
        higher_edu_ = higher_edu
        work_experience_ = work_experience
        cv_ = cv
        dsdivision_id_ = dsdivision_id
        user_id_ = visitor.getSession()
        created_time_ = Date.Now
    End Sub

    Public Sub New(ByVal id As Integer)
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM tblJobseeker WHERE jobseeker_id=" & id, DBConnection.SQLConnection)
            Dim read As SqlDataReader = cmd.ExecuteReader
            While read.Read
                jobseeker_id_ = id
                name_ = read.Item("name").ToString()
                address_ = read.Item("address").ToString()
                phone_ = read.Item("phone").ToString()
                status_ = read.Item("status").ToString()
                nic_ = read.Item("nic").ToString()
                birthday_ = read.Item("birthday").ToString()
                gender_ = read.Item("gender").ToString()
                languages_ = read.Item("languages").ToString()
                license_ = read.Item("license").ToString()
                ordinary_level_ = read.Item("ordinary_level").ToString()
                advanced_level_ = read.Item("advanced_level").ToString()
                higher_edu_ = read.Item("higher_edu").ToString()
                work_experience_ = read.Item("work_experience").ToString()
                cv_ = read.Item("cv").ToString()
                dsdivision_id_ = read.Item("dsdivision_id").ToString()
                user_id_ = read.Item("user_id")
                created_time_ = read.Item("created_time").ToString()
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
            Dim cmdin As New SqlCommand("INSERT INTO tblJobseeker VALUES (" & jobseeker_id_ & ", '" & name_ & "', '" & address_ & "', '" & phone_ & "', '" & status_ & "', '" & nic_ & "', '" & birthday_ & "', '" & gender_ & "', '" & license_ & "', '" & languages_ & "', '" & ordinary_level_ & "', '" & advanced_level_ & "', '" & higher_edu_ & "', '" & work_experience_ & "', '" & cv_ & "', " & dsdivision_id_ & ", " & user_id_ & ", '" & created_time_ & "')", DBConnection.SQLConnection)
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
            Dim cmdin As New SqlCommand("UPDATE tblJobseeker SET [name]='" & name_ & "', [address]='" & address_ & "', [phone]='" & phone_ & "', [status]='" & status_ & "', [nic]='" & nic_ & "', [birthday]='" & birthday_ & "', [gender]='" & gender_ & "', [license]='" & license_ & "', [languages]='" & languages_ & "', [ordinary_level]='" & ordinary_level_ & "', [advanced_level]='" & advanced_level_ & "', [higher_edu]='" & higher_edu_ & "', [work_experience]='" & work_experience_ & "', [cv]='" & cv_ & "' WHERE [jobseeker_id]=" & jobseeker_id_, DBConnection.SQLConnection)
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
            Dim cmd As New SqlCommand("DELETE FROM tblJobseeker WHERE [jobseeker_id]=" & id, DBConnection.SQLConnection)
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
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblJobseeker", DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar
            If count > 0 Then
                Dim cmd As New SqlCommand("SELECT max(jobseeker_id) FROM tblJobseeker", DBConnection.SQLConnection)
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

    'validating the file input
    Public Shared Function Checkfile(ByVal filename As String) As Boolean
        Dim strExt As String = ""
        If filename.Length > 0 Then
            strExt = filename.Substring(filename.LastIndexOf(".")).ToLower()
        End If
        Return (strExt = ".jpg") Or (strExt = ".gif") Or (strExt = ".pdf") Or (strExt = ".doc") Or (strExt = ".docx")
    End Function

    'get existance when applying for a job
    Public Shared Function getExist(ByVal id As Integer) As Boolean
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblJobseeker WHERE [jobseeker_id]=" & id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count > 0
    End Function

    'to show number in ds division
    Public Shared Function getNo_of_jobseekers(ByVal id As Integer) As Integer
        Dim count As Integer
        Try
            DBConnection.Open()
            Dim cmdcount As New SqlCommand("SELECT COUNT(*) FROM tblJobseeker WHERE [dsdivision_id]=" & id, DBConnection.SQLConnection)
            count = cmdcount.ExecuteScalar()
        Catch ex As Exception
            Throw ex
        Finally
            DBConnection.Close()
        End Try
        Return count
    End Function

    'to show name in application
    Public Shared Function getName(ByVal id As Integer) As String
        Dim name As String = Nothing
        Try
            DBConnection.Open()
            Dim cmd As New SqlCommand("SELECT [name] FROM tblJobseeker WHERE [jobseeker_id]=" & id, DBConnection.SQLConnection)
            name = cmd.ExecuteScalar().ToString
        Catch ex As Exception
        Finally
            DBConnection.Close()
        End Try
        Return name
    End Function

End Class
