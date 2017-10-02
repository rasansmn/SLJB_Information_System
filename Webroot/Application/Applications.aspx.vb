'(c) Rasan Samarasinghe 2013-11-25

Imports System.Data.SqlClient

Partial Class Application_Applications
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12
    Public logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        'user actions
        If Request.QueryString("action") = "delete" Then
            Try
                If Vacancy_Application.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Application", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Record deleted successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on deleting"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare the query to show on each page
        If Val(Request.QueryString("jobseeker_id")) > 0 Then
            querycount = "SELECT * FROM tblApplication WHERE jobseeker_id=" & Val(Request.QueryString("jobseeker_id"))
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblApplication WHERE jobseeker_id=" & Val(Request.QueryString("jobseeker_id")) & " AND application_id NOT IN (SELECT TOP " & limitstart & " application_id FROM tblApplication WHERE jobseeker_id=" & Val(Request.QueryString("jobseeker_id")) & " ORDER BY application_id DESC) ORDER BY application_id DESC"
            lblTitle.Text = "- " & Job_Seeker.getName(Request.QueryString("jobseeker_id"))
            lblTableCapation.Text = "Showing Applications of " & Job_Seeker.getName(Request.QueryString("jobseeker_id"))
        ElseIf Val(Request.QueryString("vacancy_id")) > 0 Then
            querycount = "SELECT * FROM tblApplication WHERE vacancy_id=" & Val(Request.QueryString("vacancy_id"))
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblApplication WHERE vacancy_id=" & Val(Request.QueryString("vacancy_id")) & " AND application_id NOT IN (SELECT TOP " & limitstart & " application_id FROM tblApplication WHERE vacancy_id=" & Val(Request.QueryString("vacancy_id")) & " ORDER BY application_id DESC) ORDER BY application_id DESC"
            lblTitle.Text = "- " & Vacancy.getTitle(Request.QueryString("vacancy_id"))
            lblTableCapation.Text = "Showing Applications for Vacancy: " & Vacancy.getTitle(Request.QueryString("vacancy_id"))
        ElseIf Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblApplication WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblApplication WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND application_id NOT IN (SELECT TOP " & limitstart & " application_id FROM tblApplication WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY application_id DESC) ORDER BY application_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblApplication"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblApplication WHERE application_id NOT IN (SELECT TOP " & limitstart & " application_id FROM tblApplication ORDER BY application_id DESC) ORDER BY application_id DESC"
        End If

        'navigation buttons
        lblPages.Text = "Page " & pagen & " of " & numpages
        If pagen < numpages Then
            btnNext.Enabled = True
        End If
        If pagen > 1 Then
            btnPrev.Enabled = True
        End If

        showitems(query)
    End Sub

    Sub showitems(ByVal query As String) 'loading items on the repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblApplications")
            rptApplications.DataSource = dsItem
            rptApplications.DataBind()
            If rptApplications.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&jobseeker_id=" & Request.QueryString("jobseeker_id") & "&vacancy_id=" & Request.QueryString("vacancy_id") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("Applications.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Applications.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&jobseeker_id=" & Request.QueryString("jobseeker_id") & "&vacancy_id=" & Request.QueryString("vacancy_id"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Applications.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&jobseeker_id=" & Request.QueryString("jobseeker_id") & "&vacancy_id=" & Request.QueryString("vacancy_id"))
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=applications")
    End Sub
End Class
