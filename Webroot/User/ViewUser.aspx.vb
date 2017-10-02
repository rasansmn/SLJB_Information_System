
Partial Class User_ViewUser
    Inherits System.Web.UI.Page
    Dim user_id As Integer
    Dim viewing_user As User_Account
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 3 Then 'access only for admin
            Response.Redirect("~/Default.aspx")
        End If

        If Request.QueryString("id") <> Nothing Then 'fill the labels
            user_id = Request.QueryString("id")
            viewing_user = New User_Account(user_id)

            If Not IsPostBack Then
                lblHeader.Text = "User Account: " & viewing_user.name
                lblUser_id.Text = viewing_user.user_id
                lblName.Text = viewing_user.name
                lblUsername.Text = viewing_user.username
                lblPermission.Text = viewing_user.permission
                lnkLogs.Text = User_Log.getNumLogs(viewing_user.user_id)
                lnkLogs.NavigateUrl = "~/Log/Logs.aspx?user_id=" & viewing_user.user_id
                lnkDelete.NavigateUrl = "~/User/Users.aspx?action=delete&id=" & viewing_user.user_id
                lnkEdit.NavigateUrl = "~/User/EditUser.aspx?id=" & viewing_user.user_id
            End If
        End If
    End Sub
End Class
