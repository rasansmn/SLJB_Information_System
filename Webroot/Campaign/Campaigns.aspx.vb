Imports System.Data.SqlClient

Partial Class Campaign_Campaigns
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12
    Dim logged_user As New Visitor()

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
                If Campaign.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Campaign", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Campaign deleted successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on deleting"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "insert" Then
            divNotific.Visible = True
            lblAlert.Text = "Campaign inserted successfully!"
        ElseIf Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "Campaign updated successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare the query to show on each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblCampaign WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblCampaign WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND campaign_id NOT IN (SELECT TOP " & limitstart & " campaign_id FROM tblCampaign WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%)' ORDER BY campaign_id DESC) ORDER BY campaign_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblCampaign"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblCampaign WHERE campaign_id NOT IN (SELECT TOP " & limitstart & " campaign_id FROM tblCampaign ORDER BY campaign_id DESC) ORDER BY campaign_id DESC"
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
            adapter.Fill(dsItem, "tblCampaigns")
            rptCampaigns.DataSource = dsItem
            rptCampaigns.DataBind()
            If rptCampaigns.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("Campaigns.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Campaigns.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Campaigns.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnAddCampaign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCampaign.Click
        Response.Redirect("~/Campaign/AddCampaign.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=campaigns")
    End Sub
End Class
