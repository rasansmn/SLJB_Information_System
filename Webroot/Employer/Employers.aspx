<%@ Page Title="Employers | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Employers.aspx.vb" Inherits="Employer_Employers" %>

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
    <h2><img alt="" src="../Images/icon2.jpg" height="25" /> Employers <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Employers in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="emp_id">ID</asp:ListItem>
           <asp:ListItem Value="name">Name</asp:ListItem>
           <asp:ListItem Value="description">Description</asp:ListItem>
           <asp:ListItem Value="address">Address</asp:ListItem>
           <asp:ListItem Value="phone">Phone</asp:ListItem>
           <asp:ListItem Value="fax">Fax</asp:ListItem>
           <asp:ListItem Value="email">E-Mail</asp:ListItem>
           <asp:ListItem Value="website">Website</asp:ListItem>
           <asp:ListItem Value="coordinator">Coordinator</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
<asp:Repeater ID="rptEmployers" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Name</th><th>Phone</th><th>E-Mail</th><th>Vacancies</th><th>Coordinator</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "emp_id")%>'></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ='<%#"~/Employer/ViewEmployer.aspx?id=" & DataBinder.Eval(Container.DataItem, "emp_id")%>'><%#DataBinder.Eval(Container.DataItem, "name")%></asp:HyperLink>
            </td>
            <td>
              <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "phone")%>'></asp:Label>
            </td>
  		<td>
              <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink4" NavigateUrl ='<%#"~/Vacancy/Vacancies.aspx?emp_id=" & DataBinder.Eval(Container.DataItem, "emp_id")%>' runat="server"><%# Vacancy.getNoOfVacancies(DataBinder.Eval(Container.DataItem, "emp_id"))%></asp:HyperLink>
            </td>
  		<td>
              <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "coordinator")%>'></asp:Label>
            </td>
            <td ID="editr" runat="server" visible="true">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Employer/EditEmployer.aspx?id="&DataBinder.Eval(Container.DataItem, "emp_id")&urlExtend()%>'><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
             <asp:HyperLink ID="HyperLink2" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/Employer/Employers.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "emp_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
     <asp:Button ID="btnAddEmployer" runat="server" Text="Add Employer"  />
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

