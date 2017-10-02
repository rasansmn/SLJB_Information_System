
Partial Class User_UpdateProfile
    Inherits System.Web.UI.Page
    Dim visitor As New Visitor()
    Dim update_user As User_Account

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        update_user = New User_Account(visitor.getSession)
        If Not IsPostBack Then ' fill the text fields
            txtUsername.Text = update_user.username
            txtName.Text = update_user.name
        End If
        If Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "User Account updated successfully!"
        End If
    End Sub

    Protected Sub UpdateAccountButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateAccountButton.Click
        Try
            'validating input
            If User_Account.getExist(txtUsername.Text) And update_user.username <> txtUsername.Text Then
                valUsername.IsValid = False
                valUsername.ErrorMessage = "Username already exist"
                valUsername.ToolTip = "Username already exist"
            ElseIf visitor.Login(update_user.username, txtCurrentPassword.Text) = False Then
                valCurrentPassword.IsValid = False
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
                If update_user.update() Then
                    Dim log As New User_Log("User", "Profile Updated")
                    log.insert()
                    Response.Redirect("UpdateProfile.aspx?action=update")
                Else
                    divError.Visible = True
                    lblError.Text = "User Account updating failed"
                End If
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
