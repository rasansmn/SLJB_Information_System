'(c) Rasan Samarasinghe 2013-11-25

Partial Class MasterMain
    Inherits System.Web.UI.MasterPage
    Dim Visitor As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim perm As Integer = Visitor.getPerm() 'who is the user?

        If perm > 0 Then 'this is a logged user!
            setWelcome(perm)
            setMenu(perm)
            setContent(perm)
        ElseIf Not Request.Cookies("uid") Is Nothing Then 'otherwise check for cookies
            If Visitor.getPerm(Request.Cookies("uid").Value) > 0 Then
                Visitor.setSession(Request.Cookies("uid").Value)
                perm = Visitor.getPerm()
                setWelcome(perm)
                setMenu(perm)
                setContent(perm)
            Else 'this is not a logged user
                Response.Redirect("~/User/Login.aspx")
            End If
        Else 'this is not a logged user
            Response.Redirect("~/User/Login.aspx")
        End If
       
    End Sub

    'set visibility of content place holder
    Private Sub setContent(ByVal perm As Integer)
        If perm >= 3 Then
            cphPerm1.Visible = True
            cphPerm2.Visible = True
            cphPerm3.Visible = True
        ElseIf perm >= 2 Then
            cphPerm1.Visible = True
            cphPerm2.Visible = True
        ElseIf perm >= 1 Then
            cphPerm1.Visible = True
        End If
    End Sub

    'prepare menu items for each user type
    Private Sub setMenu(ByVal perm As Integer)
        If perm = 1 Then
            NavigationMenu.Items.RemoveAt(7)
            NavigationMenu.Items.RemoveAt(6)
            NavigationMenu.Items.RemoveAt(5)
            NavigationMenu.Items.RemoveAt(4)
            NavigationMenu.Items.RemoveAt(3)
            NavigationMenu.Items.RemoveAt(2)
        ElseIf perm = 2 Then
            NavigationMenu.Items.RemoveAt(7)
        ElseIf perm = 3 Then
            'OK
        Else
            NavigationMenu.Items.RemoveAt(8)
            NavigationMenu.Items.RemoveAt(7)
            NavigationMenu.Items.RemoveAt(6)
            NavigationMenu.Items.RemoveAt(5)
            NavigationMenu.Items.RemoveAt(4)
            NavigationMenu.Items.RemoveAt(3)
            NavigationMenu.Items.RemoveAt(2)
            NavigationMenu.Items.RemoveAt(1)
        End If
    End Sub

    'welcome message and logout link
    Private Sub setWelcome(ByVal perm As Integer)
        If perm > 0 Then
            lblVisitor.Text = Visitor.getName(Visitor.getSession())
            lnkLogout.Visible = True
        End If
    End Sub

End Class

