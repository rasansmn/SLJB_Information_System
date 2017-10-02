'(c) Rasan Samarasinghe 2013-11-25

Partial Class User_Login
    Inherits System.Web.UI.Page
    Dim Visitor As New Visitor()

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Visitor.Login(txtUsername.Text, txtPassword.Text) Then
            If chkRememberme.Checked = True Then 'remember me
                Response.Cookies("uid").Value = Visitor.getSession()
                Response.Cookies("uid").Expires = DateTime.Now.AddDays(7)
            End If
            Response.Redirect("~/Default.aspx")
        Else
            litFailure.Text = "Your login attempt was not successful. Please try again."
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If
        If Request.QueryString("action") = "logout" Then 'good bye!!!
            Visitor.logout()
            Response.Cookies("uid").Expires = DateTime.Now.AddDays(-1)
            divNotific.Visible = True
            lblAlert.Text = "You have logged out successfully"
        ElseIf Visitor.getPerm > 0 Then
            Response.Redirect("~/Default.aspx")
        ElseIf Not Request.Cookies("uid") Is Nothing Then
            If Visitor.getPerm(Request.Cookies("uid").Value) > 0 Then
                Visitor.setSession(Request.Cookies("uid").Value)
                Response.Redirect("~/Default.aspx")
            End If
        End If
    End Sub
End Class
