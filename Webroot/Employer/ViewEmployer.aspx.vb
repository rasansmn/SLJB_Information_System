
Partial Class Employer_ViewEmployer
    Inherits System.Web.UI.Page
    Dim employer As Employer
    Dim emp_id As Integer
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Request.QueryString("id") <> Nothing Then
            emp_id = Request.QueryString("id")
            employer = New Employer(emp_id)

            If Not IsPostBack Then ' fill the labels
                lblHeader.Text = employer.name
                lblEmpid.Text = employer.employer_id
                lblName.Text = employer.name
                lblDescription.Text = employer.description
                lblAddress.Text = employer.address
                lblPhone.Text = employer.phone
                lblFax.Text = employer.fax
                lblEmail.Text = employer.email
                lblWebsite.Text = employer.website
                lblCoordinator.Text = employer.coordinator
                If logged_user.getPerm = 3 Then
                    lnkCreatedby.Text = User_Account.getName(employer.user_id)
                    lnkCreatedby.NavigateUrl = "~/User/ViewUser.aspx?id=" & employer.user_id
                    lnkCreatedby.Visible = True
                Else
                    lblCreatedby.Text = User_Account.getName(employer.user_id)
                    lblCreatedby.Visible = True
                End If
                lblCreatedtime.Text = employer.created_time.ToString()
                lnkVacancies.Text = Vacancy.getNoOfVacancies(employer.employer_id)
                lnkVacancies.NavigateUrl = "~/Vacancy/Vacancies.aspx?emp_id=" & employer.employer_id
                lnkDelete.NavigateUrl = "~/Employer/Employers.aspx?action=delete&id=" & employer.employer_id
                lnkEdit.NavigateUrl = "~/Employer/EditEmployer.aspx?id=" & employer.employer_id
            End If
        End If
    End Sub
End Class
