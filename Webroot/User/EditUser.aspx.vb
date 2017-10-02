
Partial Class User_EditUser
    Inherits System.Web.UI.Page
    Dim user_id As Integer
    Dim update_user As User_Account
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 3 Then 'access only for admin
            Response.Redirect("~/Default.aspx")
        End If

        If Val(Request.QueryString("id")) > 0 Then 'fill the text fields
            user_id = Request.QueryString("id")
            update_user = New User_Account(user_id)
            If Not IsPostBack Then
                txtUsername.Text = update_user.username
                txtName.Text = update_user.name
            End If
        End If
    End Sub

    Protected Sub UpdateUserButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateUserButton.Click
        Try
            'validating the input
            If User_Account.getExist(txtUsername.Text) And update_user.username <> txtUsername.Text Then
                valUsername.IsValid = False
                valUsername.ErrorMessage = "Username already exist"
                valUsername.ToolTip = "Username already exist"
            ElseIf txtUsername.Text.Length < 4 Then
                valUsername.IsValid = False
                valUsername.ErrorMessage = "Username should be at least 4 charactors"
                valUsername.ToolTip = "Username should be at least 4 charactors"
            ElseIf txtPassword.Text.Length < 4 Then
                valPassword.IsValid = False
                valPassword.ErrorMessage = "Password should be at least 4 charactors"
                valPassword.ToolTip = "Password should be at least 4 charactors"
            Else
                update_user.username = txtUsername.Text
                update_user.name = txtName.Text
                update_user.password = txtPassword.Text
                update_user.permission = CInt(ddlPermission.SelectedValue)
                If update_user.update() Then
                    Dim log As New User_Log("User", "Updated")
                    log.insert()
                    Response.Redirect("Users.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & Request.QueryString("pagen"))
                Else
                    divError.Visible = True
                    lblError.Text = "Record updating failed"
                End If
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
