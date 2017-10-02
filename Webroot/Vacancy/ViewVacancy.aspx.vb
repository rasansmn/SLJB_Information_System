
Partial Class Vacancy_ViewVacancy
    Inherits System.Web.UI.Page
    Dim vacancy As Vacancy
    Dim vacancy_id As Integer
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        'user actions?
        If Request.QueryString("action") = "setclose" Then
            If vacancy.Close(Val(Request.QueryString("id"))) Then
                Dim log As New User_Log("Vacancy", "Closed")
                log.insert()
                divNotific.Visible = True
                lblAlert.Text = "Vacancy closed successfully!"
            End If
        ElseIf Request.QueryString("action") = "setopen" Then
            If vacancy.Open(Val(Request.QueryString("id"))) Then
                Dim log As New User_Log("Vacancy", "Opened")
                log.insert()
                divNotific.Visible = True
                lblAlert.Text = "Vacancy opened successfully!"
            End If
        ElseIf Request.QueryString("action") = "invoice" Then
                divNotific.Visible = True
            lblAlert.Text = "Vacancy invoice created successfully!"
        ElseIf Request.QueryString("action") = "apply" Then
            divNotific.Visible = True
            lblAlert.Text = "Application sent successfully!"
        End If

        If Request.QueryString("id") <> Nothing Then
            vacancy_id = Request.QueryString("id")
            vacancy = New Vacancy(vacancy_id)

            If Not IsPostBack Then 'fill the labels!
                lblHeader.Text = "Vacancy: " & vacancy.title
                lblVacancy_id.Text = vacancy.vacancy_id
                lnkEmployer.Text = Employer.getName(vacancy.emp_id)
                lnkEmployer.NavigateUrl = "~/Employer/ViewEmployer.aspx?id=" & vacancy.emp_id
                lblTitle.Text = vacancy.title
                lblDescription.Text = vacancy.description
                lblQualifications.Text = vacancy.qualifications
                lblStatus.Text = vacancy.status
                lblPositions.Text = vacancy.no_of_positions
                lblInterview.Text = vacancy.interview_date
                lblSalary.Text = vacancy.salary
                lnkApplications.Text = Vacancy_Application.getApplicationsbyvacancy(vacancy.vacancy_id)
                lnkApplications.NavigateUrl = "~/Application/Applications.aspx?vacancy_id=" & vacancy.vacancy_id
                If logged_user.getPerm = 3 Then
                    lnkCreatedby.Text = User_Account.getName(vacancy.user_id)
                    lnkCreatedby.NavigateUrl = "~/User/ViewUser.aspx?id=" & vacancy.user_id
                    lnkCreatedby.Visible = True
                Else
                    lblCreatedby.Text = User_Account.getName(vacancy.user_id)
                    lblCreatedby.Visible = True
                End If
                lblCreatedtime.Text = vacancy.created_time.ToString()
                lnkDelete.NavigateUrl = "~/Vacancy/Vacancies.aspx?action=delete&id=" & vacancy.vacancy_id
                lnkEdit.NavigateUrl = "~/Vacancy/EditVacancy.aspx?id=" & vacancy.vacancy_id
                lnkOpen.NavigateUrl = "~/Vacancy/ViewVacancy.aspx?action=setopen&id=" & vacancy.vacancy_id
                lnkClose.NavigateUrl = "~/Vacancy/ViewVacancy.aspx?action=setclose&id=" & vacancy.vacancy_id
                If vacancy.status = "Open" Then
                    lnkClose.Visible = True
                Else
                    lnkOpen.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Job_Seeker.getExist(Val(txtJobseekerid.Text)) Then
            Dim application As New Vacancy_Application(New Job_Seeker(Val(txtJobseekerid.Text)), New Vacancy(vacancy.vacancy_id))
            If application.insert() Then
                Dim log As New User_Log("Application", "Created")
                log.insert()
                Response.Redirect("ViewVacancy.aspx?action=apply&id=" & vacancy.vacancy_id)
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Else
            valjobseekernotexist.IsValid = False
        End If
    End Sub

    Protected Sub btnCreateInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateInvoice.Click
        If Val(txtAmount.Text) > 0 Then
            Dim invoice As New Vacancy_Invoice(Val(txtAmount.Text), vacancy.vacancy_id)
            If invoice.insert() Then
                Dim log As New User_Log("Vacancy Invoice", "Created")
                log.insert()
                Response.Redirect("ViewVacancy.aspx?action=invoice&id=" & vacancy.vacancy_id)
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Else
            valinvalidamount.IsValid = False
        End If
    End Sub
End Class
