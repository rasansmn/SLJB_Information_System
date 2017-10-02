'(c) Rasan Samarasinghe 2013-11-25

Imports System.Data.SqlClient

Partial Class Invoice_CampaignInvoices
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
                If Campaign_Invoice.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Campaign Invoice", "Deleted")
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
        ElseIf Request.QueryString("action") = "setpaid" And Val(Request.QueryString("id")) > 0 Then
            Try
                Dim invoice As New Campaign_Invoice(Val(Request.QueryString("id")))
                invoice.handled = "Paid"
                If invoice.update() Then
                    Dim log As New User_Log("Campaign Invoice", "Set Paid")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Payment status updated successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Payment updating failed"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "setpending" And Val(Request.QueryString("id")) > 0 Then
            Try
                Dim invoice As New Campaign_Invoice(Val(Request.QueryString("id")))
                invoice.handled = "Pending"
                If invoice.update() Then
                    Dim log As New User_Log("Campaign Invoice", "Set Pending")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Payment status updated successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Payment updating failed"
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

        'prepare a query to show on each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblCampaigninvoice WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblCampaigninvoice WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND campaigninvoice_id NOT IN (SELECT TOP " & limitstart & " campaigninvoice_id FROM tblCampaigninvoice WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY campaigninvoice_id DESC) ORDER BY campaigninvoice_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblCampaigninvoice"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblCampaigninvoice WHERE campaigninvoice_id NOT IN (SELECT TOP " & limitstart & " campaigninvoice_id FROM tblCampaigninvoice ORDER BY campaigninvoice_id DESC) ORDER BY campaigninvoice_id DESC"
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
            adapter.Fill(dsItem, "tblCampaigninvoices")
            rptCampaigninvoice.DataSource = dsItem
            rptCampaigninvoice.DataBind()
            If rptCampaigninvoice.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    'each item paid or not?
    Protected Function enablePending(ByVal campaigninvoice_id As Integer) As Boolean
        Return Campaign_Invoice.getPaymentStatus(campaigninvoice_id) = True
    End Function

    'each item paid or not?
    Protected Function enablePaid(ByVal campaigninvoice_id As Integer) As Boolean
        Return Campaign_Invoice.getPaymentStatus(campaigninvoice_id) = False
    End Function

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("CampaignInvoices.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("CampaignInvoices.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("CampaignInvoices.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=campaigninvoices")
    End Sub
End Class
