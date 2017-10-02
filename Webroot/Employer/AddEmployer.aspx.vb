
Partial Class Employer_AddEmployer
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub btnAddEmployer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEmployer.Click
        Try
            Dim new_employer As New Employer(txtName.Text, txtDescription.Text, txtAddress.Text, txtPhone.Text, txtFax.Text, txtEmail.Text, txtWebsite.Text, txtCoordinator.Text)
            If new_employer.insert() Then
                Dim log As New User_Log("Employer", "Deleted")
                log.insert()
                Response.Redirect("Employers.aspx?action=insert")
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class
