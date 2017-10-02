'(c) Rasan Samarasinghe 2013-11-25

Imports System.Data.SqlClient

Partial Class Log_Logs
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12
    Public logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 3 Then 'access only for admin
            Response.Redirect("~/Default.aspx")
        End If

        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        'user actions?
        If Request.QueryString("action") = "delete" Then
            Try
                If User_Log.delete(CInt(Request.QueryString("id"))) Then
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
        ElseIf Request.QueryString("action") = "clear" Then
            divNotific.Visible = True
            lblAlert.Text = "User log cleared successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare a query to show on each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblLog WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblLog WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND log_id NOT IN (SELECT TOP " & limitstart & " log_id FROM tblLog WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY log_id DESC) ORDER BY log_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        ElseIf Val(Request.QueryString("user_id")) > 0 Then
            querycount = "SELECT * FROM tblLog WHERE user_id=" & Val(Request.QueryString("user_id"))
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblLog WHERE user_id=" & Val(Request.QueryString("user_id")) & " AND log_id NOT IN (SELECT TOP " & limitstart & " log_id FROM tblLog WHERE user_id=" & Val(Request.QueryString("user_id")) & " ORDER BY log_id DESC) ORDER BY log_id DESC"
            lblTitle.Text = "- " & User_Account.getName(Request.QueryString("user_id"))
            lblTableCapation.Text = "Showing activities of " & User_Account.getName(Request.QueryString("user_id"))
        Else
            querycount = "SELECT * FROM tblLog"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblLog WHERE log_id NOT IN (SELECT TOP " & limitstart & " log_id FROM tblLog ORDER BY log_id DESC) ORDER BY log_id DESC"
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
        Dim js As String = "if(!confirm('Are you sure you want to clear this log?')) return false;"
        btnClear.Attributes.Add("onclick", js)
    End Sub

    Sub showitems(ByVal query As String) ' loading items to repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblLogs")
            rptLog.DataSource = dsItem
            rptLog.DataBind()
            If rptLog.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & pagen & "&user_id=" & Request.QueryString("user_id")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("Logs.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Logs.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&user_id=" & Request.QueryString("user_id"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Logs.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&user_id=" & Request.QueryString("user_id"))
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=logs")
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            If User_Log.clear() Then
                Response.Redirect("~/Log/Logs.aspx?action=clear")
            Else
                divError.Visible = True
                lblError.Text = "Error on clearing user log"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
