
Partial Class Employer_EditEmployer
    Inherits System.Web.UI.Page
    Dim employer_id As Integer
    Dim update_employer As Employer
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Request.QueryString("id") <> Nothing Then 'fill the text fields
            employer_id = Request.QueryString("id")
            update_employer = New Employer(employer_id)
            If Not IsPostBack Then
                txtName.Text = update_employer.name
                txtDescription.Text = update_employer.description
                txtAddress.Text = update_employer.address
                txtPhone.Text = update_employer.phone
                txtFax.Text = update_employer.fax
                txtEmail.Text = update_employer.email
                txtWebsite.Text = update_employer.website
                txtCoordinator.Text = update_employer.coordinator
            End If
        End If
    End Sub

    Protected Sub btnUpdateEmployer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateEmployer.Click
        Try
            update_employer.name = txtName.Text
            update_employer.description = txtDescription.Text
            update_employer.address = txtAddress.Text
            update_employer.phone = txtPhone.Text
            update_employer.fax = txtFax.Text
            update_employer.email = txtEmail.Text
            update_employer.website = txtWebsite.Text
            update_employer.coordinator = txtCoordinator.Text
            If update_employer.update() Then
                Dim log As New User_Log("Employer", "Updated")
                log.insert()
                Response.Redirect("Employers.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & Request.QueryString("pagen"))
            Else
                divError.Visible = True
                lblError.Text = "Record updating failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
