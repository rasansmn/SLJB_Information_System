Imports System.Data.SqlClient
Imports System.Data

Partial Class Vacancy_EditVacancy
    Inherits System.Web.UI.Page
    Dim vacany_id As Integer
    Dim update_vacancy As Vacancy
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            Dim ds As New DataSet() 'fill the drop down list
            Dim da As New SqlDataAdapter("SELECT [emp_id], [name] from tblEmployer", DBConnection.SQLConnection)
            da.Fill(ds, "tblEmployers")
            ddlEmployer.DataSource = ds
            ddlEmployer.DataValueField = "emp_id"
            ddlEmployer.DataTextField = "name"
            ddlEmployer.DataBind()
        End If

        If Request.QueryString("id") <> Nothing Then 'fill the text fields
            vacany_id = Request.QueryString("id")
            update_vacancy = New Vacancy(vacany_id)
            If Not IsPostBack Then
                txtTitle.Text = update_vacancy.title
                txtDescription.Text = update_vacancy.description
                txtQualifications.Text = update_vacancy.qualifications
                ddlStatus.SelectedValue = update_vacancy.status
                txtPositions.Text = update_vacancy.no_of_positions
                txtInterviewdate.Text = update_vacancy.interview_date
                txtSalary.Text = update_vacancy.salary
                ddlEmployer.SelectedValue = update_vacancy.emp_id
            End If
        End If
    End Sub

    Protected Sub btnUpdateVacancy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateVacancy.Click
        Try
            update_vacancy.title = txtTitle.Text
            update_vacancy.description = txtDescription.Text
            update_vacancy.qualifications = txtQualifications.Text
            update_vacancy.status = ddlStatus.SelectedValue
            update_vacancy.no_of_positions = txtPositions.Text
            update_vacancy.interview_date = txtInterviewdate.Text
            update_vacancy.salary = txtSalary.Text
            update_vacancy.emp_id = ddlEmployer.SelectedValue
            If update_vacancy.update() Then
                Dim log As New User_Log("Vacancy", "Updated")
                log.insert()
                Response.Redirect("Vacancies.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&emp_id=" & Request.QueryString("emp_id") & "&pagen=" & Request.QueryString("pagen"))
            Else
                divError.Visible = True
                lblError.Text = "Record updating failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
