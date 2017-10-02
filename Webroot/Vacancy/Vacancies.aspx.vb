Imports System.Data.SqlClient

Partial Class Vacancy_Vacancies
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

        'actions by user?
        If Request.QueryString("action") = "delete" Then
            Try
                If Vacancy.delete(Val(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Vacancy", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Vacancy deleted successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on deleting"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "setclose" Then
            Try
                If Vacancy.Close(Val(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Vacancy", "Closed")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Vacancy closed successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on closing"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "setopen" Then
            Try
                If Vacancy.Open(Val(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Vacancy", "Opened")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Vacancy opened successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on opening"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "insert" Then
            divNotific.Visible = True
            lblAlert.Text = "Vacancy inserted successfully!"
        ElseIf Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "Vacancy updated successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare a query to show on each page
        If Val(Request.QueryString("emp_id")) > 0 Then
            querycount = "SELECT * FROM tblVacancy WHERE emp_id=" & Val(Request.QueryString("emp_id"))
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblVacancy WHERE emp_id=" & Val(Request.QueryString("emp_id")) & " AND vacancy_id NOT IN (SELECT TOP " & limitstart & " vacancy_id FROM tblVacancy WHERE emp_id=" & Val(Request.QueryString("emp_id")) & " ORDER BY vacancy_id DESC) ORDER BY vacancy_id DESC"
            lblTitle.Text = "- " & Employer.getName(Request.QueryString("emp_id"))
            lblTableCapation.Text = "Showing Job Vacancies in " & Employer.getName(Request.QueryString("emp_id"))
        ElseIf Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblVacancy WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblVacancy WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND vacancy_id NOT IN (SELECT TOP " & limitstart & " vacancy_id FROM tblVacancy WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY vacancy_id DESC) ORDER BY vacancy_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblVacancy"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblVacancy WHERE vacancy_id NOT IN (SELECT TOP " & limitstart & " vacancy_id FROM tblVacancy ORDER BY vacancy_id DESC) ORDER BY vacancy_id DESC"
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

    Sub showitems(ByVal query As String) 'load items to the repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblVacancies")
            rptVacancies.DataSource = dsItem
            rptVacancies.DataBind()
            If rptVacancies.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    'each item opened or closed?
    Protected Function enableOpen(ByVal status As String) As Boolean
        If status = "Closed" Then
            Return True
        End If
        Return False
    End Function

    'each item opened or closed?
    Protected Function enableClose(ByVal status As String) As Boolean
        If status = "Open" Then
            Return True
        End If
        Return False
    End Function

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&emp_id=" & Request.QueryString("emp_id") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("Vacancies.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Vacancies.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&emp_id=" & Request.QueryString("emp_id"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Vacancies.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&emp_id=" & Request.QueryString("emp_id"))
    End Sub

    Protected Sub btnAddVacancy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddVacancy.Click
        Response.Redirect("~/Vacancy/AddVacancy.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=vacancies")
    End Sub
End Class
