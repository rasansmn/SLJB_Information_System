Imports System.Data.SqlClient
Imports System.Data

Partial Class Job_Seeker_ViewJobSeeker
    Inherits System.Web.UI.Page
    Dim job_seeker As Job_Seeker
    Dim jobseeker_id As Integer
    Public logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter("SELECT [vacancy_id], [title] from tblVacancy", DBConnection.SQLConnection)
            da.Fill(ds, "vacancies")
            ddlVacancy.DataSource = ds
            ddlVacancy.DataValueField = "vacancy_id"
            ddlVacancy.DataTextField = "title"
            ddlVacancy.DataBind()
        End If

        'actions by user?
        If Request.QueryString("action") = "apply" Then
            divNotific.Visible = True
            lblAlert.Text = "Application created successfully!"
        End If

        If Request.QueryString("id") <> Nothing Then 'fill the labels
            jobseeker_id = Request.QueryString("id")
            job_seeker = New Job_Seeker(jobseeker_id)

            If Not IsPostBack Then
                lblHeader.Text = job_seeker.name
                lblId.Text = job_seeker.jobseeker_id
                lblName.Text = job_seeker.name
                lblAddress.Text = job_seeker.address
                lblPhone.Text = job_seeker.phone
                lblStatus.Text = job_seeker.status
                lblNic.Text = job_seeker.nic
                lblBirthday.Text = job_seeker.birthday
                lblGender.Text = job_seeker.gender
                lblLicense.Text = job_seeker.license
                lblLanguages.Text = job_seeker.languages
                lblOl.Text = job_seeker.ordinary_level
                lblAl.Text = job_seeker.Advanced_level
                lblHigher.Text = job_seeker.higher_edu
                lblExperience.Text = job_seeker.work_experience
                If job_seeker.cv <> "" Then
                    lnkCv.Visible = True
                    lnkCv.NavigateUrl = job_seeker.cv
                End If
                If logged_user.getPerm = 3 Then
                    lnkCreatedby.Text = User_Account.getName(job_seeker.user_id)
                    lnkCreatedby.NavigateUrl = "~/User/ViewUser.aspx?id=" & job_seeker.user_id
                    lnkCreatedby.Visible = True
                Else
                    lblCreatedby.Text = User_Account.getName(job_seeker.user_id)
                    lblCreatedby.Visible = True
                End If
                lblCreatedtime.Text = job_seeker.created_time.ToString()
                lnkApplications.Text = Vacancy_Application.getApplicationsbyjobseeker(job_seeker.jobseeker_id)
                lnkApplications.NavigateUrl = "~/Application/Applications.aspx?jobseeker_id=" & job_seeker.jobseeker_id
                lnkDelete.NavigateUrl = "~/Job Seeker/JobSeekers.aspx?action=delete&id=" & job_seeker.jobseeker_id
                lnkEdit.NavigateUrl = "~/Job Seeker/EditJobSeeker.aspx?id=" & job_seeker.jobseeker_id
                If logged_user.getPerm < 2 Then
                    trApplications.Visible = False
                End If
            End If
        End If
    End Sub

    Protected Sub btnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim application As New Vacancy_Application(New Job_Seeker(job_seeker.jobseeker_id), New Vacancy(Val(ddlVacancy.SelectedValue)))
        If application.insert() Then
            Dim log As New User_Log("Application", "Created")
            log.insert()
            Response.Redirect("ViewJobSeeker.aspx?action=apply&id=" & jobseeker_id)
        Else
            divError.Visible = True
            lblError.Text = "Record insertion failed"
        End If
    End Sub
End Class
