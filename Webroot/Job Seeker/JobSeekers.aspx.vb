Imports System.Data.SqlClient

Partial Class Job_Seeker_JobSeekers
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        'user actions
        If Request.QueryString("action") = "delete" Then
            Try
                If Job_Seeker.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Job Seeker", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Job Seeker deleted successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on deleting"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "Job Seeker updated successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare a query to show on each page
        If Val(Request.QueryString("dsdivision_id")) > 0 Then
            querycount = "SELECT * FROM tblJobseeker WHERE dsdivision_id=" & Val(Request.QueryString("dsdivision_id"))
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblJobseeker WHERE dsdivision_id=" & Val(Request.QueryString("dsdivision_id")) & " AND jobseeker_id NOT IN (SELECT TOP " & limitstart & " jobseeker_id FROM tblJobseeker WHERE dsdivision_id=" & Val(Request.QueryString("dsdivision_id")) & " ORDER BY jobseeker_id DESC) ORDER BY jobseeker_id DESC"
            lblTitle.Text = "- " & DS_Division.getName(Request.QueryString("dsdivision_id"))
            lblTableCapation.Text = "Showing Job Seekers in: " & DS_Division.getName(Request.QueryString("dsdivision_id"))
        ElseIf Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblJobseeker WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblJobseeker WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND jobseeker_id NOT IN (SELECT TOP " & limitstart & " jobseeker_id FROM tblJobseeker WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY jobseeker_id DESC) ORDER BY jobseeker_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblJobseeker"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblJobseeker WHERE jobseeker_id NOT IN (SELECT TOP " & limitstart & " jobseeker_id FROM tblJobseeker ORDER BY jobseeker_id DESC) ORDER BY jobseeker_id DESC"
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

    Sub showitems(ByVal query As String) 'loading items to the repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblJobseekers")
            rptJobseekers.DataSource = dsItem
            rptJobseekers.DataBind()
            If rptJobseekers.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&dsdivision_id=" & Request.QueryString("dsdivision_id") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("JobSeekers.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("JobSeekers.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&dsdivision_id=" & Request.QueryString("dsdivision_id"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("JobSeekers.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&dsdivision_id=" & Request.QueryString("dsdivision_id"))
    End Sub

    Protected Sub btnAddJobSeeker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddJobSeeker.Click
        Response.Redirect("~/Job Seeker/AddJobSeeker.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=jobseekers")
    End Sub
End Class
