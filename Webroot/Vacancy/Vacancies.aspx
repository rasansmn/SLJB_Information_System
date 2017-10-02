<%@ Page Title="Vacancies | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Vacancies.aspx.vb" Inherits="Vacancy_Vacancies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotification" Runat="Server">
    <div id="divError" class="error" runat="server" visible="false">
    <asp:Image ID="imgNotok" runat="server" ImageUrl="~/Images/notok.gif" />
<asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
</div>
<div id="divNotific" class="alert" runat="server" visible="false">
    <asp:Image ID="imgOk" runat="server" ImageUrl="~/Images/ok.gif" />
<asp:Label ID="lblAlert" runat="server" Text="Label"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCommon" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
    <h2><img alt="" src="../Images/icon6.png" height="25" /> Vacancies <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Vacancies in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="vacancy_id">ID</asp:ListItem>
           <asp:ListItem Value="title">Title</asp:ListItem>
           <asp:ListItem Value="description">Description</asp:ListItem>
           <asp:ListItem Value="qualifications">Qualifications</asp:ListItem>
           <asp:ListItem Value="status">Status</asp:ListItem>
           <asp:ListItem Value="no_of_positions">No of positions</asp:ListItem>
           <asp:ListItem Value="interview_date">Interview Date</asp:ListItem>
           <asp:ListItem Value="salary_range">Salary Range</asp:ListItem>
           <asp:ListItem Value="emp_id">Employer ID</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
<asp:Repeater ID="rptVacancies" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Title</th><th>Employer</th><th>Applications</th><th>Status</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "vacancy_id")%>'></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ='<%#"~/Vacancy/ViewVacancy.aspx?id=" & DataBinder.Eval(Container.DataItem, "vacancy_id")%>'><%#DataBinder.Eval(Container.DataItem, "title")%></asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink5" NavigateUrl ='<%#"~/Employer/ViewEmployer.aspx?id=" & DataBinder.Eval(Container.DataItem, "emp_id")%>' runat="server"><%# Employer.getName(DataBinder.Eval(Container.DataItem, "emp_id"))%></asp:HyperLink>
            </td>
             <td>
                 <asp:HyperLink ID="HyperLink4" NavigateUrl ='<%# "~/Application/Applications.aspx?vacancy_id="& DataBinder.Eval(Container.DataItem, "vacancy_id")%>' runat="server"><%# Vacancy_Application.getApplicationsbyvacancy(DataBinder.Eval(Container.DataItem, "vacancy_id"))%></asp:HyperLink>
            </td>
            <td>
              <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "status")%>'></asp:Label>
            </td>

            <td ID="editr" runat="server" visible="true">
                <asp:HyperLink NavigateUrl ='<%#"~/Vacancy/Vacancies.aspx?action=setopen&id=" & DataBinder.Eval(Container.DataItem, "vacancy_id")&urlExtend()%>' ID="HyperLink6" Visible ='<%#enableOpen(DataBinder.Eval(Container.DataItem, "status"))%>' runat="server"><img src="../Images/Open.gif" alt="" height="12" />Open</asp:HyperLink>
                <asp:HyperLink NavigateUrl ='<%#"~/Vacancy/Vacancies.aspx?action=setclose&id=" & DataBinder.Eval(Container.DataItem, "vacancy_id")&urlExtend()%>' ID="HyperLink7" Visible ='<%#enableClose(DataBinder.Eval(Container.DataItem, "status"))%>' runat="server"><img src="../Images/close.png" alt="" height="12" />Close</asp:HyperLink>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Vacancy/EditVacancy.aspx?id="&DataBinder.Eval(Container.DataItem, "vacancy_id")&urlExtend()%>'><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
             <asp:HyperLink ID="HyperLink2" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/Vacancy/Vacancies.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "vacancy_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
            </td>
            
        </tr>
         </ItemTemplate>
         <FooterTemplate></table></FooterTemplate>
     </asp:Repeater>
      <div class="table-bottom">
    <div class="tb-left" >
    <asp:Button ID="btnPrev" runat="server" Text="Prev" Enabled="False" />  &nbsp;<asp:Label 
            ID="lblPages" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Button ID="btnNext" runat="server" Text="Next" Enabled="False" />
         </div>
    <div class="tb-right">
     <asp:Button ID="btnAddVacancy" runat="server" Text="Add Vacancy"  />
    </div>
</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
<div class="tb-right">
    <br /><asp:Button ID="btnReport" runat="server" 
        Text="Generate Report From Query" 
        onclientclick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);" />
    </div>
</asp:Content>

