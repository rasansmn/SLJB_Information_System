Imports System.Data.SqlClient
Imports System.Data

Partial Class Vacancy_AddVacancy
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub btnCreateVacancy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateVacancy.Click
        Try
            Dim new_vacancy As New Vacancy(txtTitle.Text, txtDescription.Text, txtQualifications.Text, ddlStatus.SelectedValue, txtPositions.Text, txtInterviewdate.Text, txtSalary.Text, Val(ddlEmployer.SelectedValue))
            If new_vacancy.insert() Then
                Dim log As New User_Log("Vacancy", "Created")
                log.insert()
                Response.Redirect("Vacancies.aspx?action=insert")
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            Dim ds As New DataSet() 'load items to the list
            Dim da As New SqlDataAdapter("SELECT [emp_id], [name] from tblEmployer", DBConnection.SQLConnection)
            da.Fill(ds, "tblEmployers")
            ddlEmployer.DataSource = ds
            ddlEmployer.DataValueField = "emp_id"
            ddlEmployer.DataTextField = "name"
            ddlEmployer.DataBind()
        End If
    End Sub
End Class
