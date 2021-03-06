﻿Imports System.Data.SqlClient

Partial Class Sponsorship_Sponsorships
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

        'user actions?
        If Request.QueryString("action") = "delete" Then
            If Sponsorship.delete(CInt(Request.QueryString("id"))) Then
                Dim log As New User_Log("Sponsorship", "Deleted")
                log.insert()
                divNotific.Visible = True
                lblAlert.Text = "Record deleted successfully!"
            End If
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare a query to show on each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblSponsorship WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblSponsorship WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND sponsorship_id NOT IN (SELECT TOP " & limitstart & " sponsorship_id FROM tblSponsorship WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY sponsorship_id DESC) ORDER BY sponsorship_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblSponsorship"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblSponsorship WHERE sponsorship_id NOT IN (SELECT TOP " & limitstart & " sponsorship_id FROM tblSponsorship ORDER BY sponsorship_id DESC) ORDER BY sponsorship_id DESC"
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

    Sub showitems(ByVal query As String) 'loading items to repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblSponsorships")
            rptSponsorships.DataSource = dsItem
            rptSponsorships.DataBind()
            If rptSponsorships.Items.Count = 0 Then
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
        Response.Redirect("Sponsorships.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Sponsorships.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Sponsorships.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub
End Class
