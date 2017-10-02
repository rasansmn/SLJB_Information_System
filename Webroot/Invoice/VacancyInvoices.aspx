<%@ Page Title="Vacancy Invoices | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="VacancyInvoices.aspx.vb" Inherits="Invoice_VacancyInvoices" %>

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
    <h2><img alt="" src="../Images/invoice2.jpg" height="25" /> Vacancy Invoices <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
  <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Vacancy Invoices in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="vacancyinvoice_id">ID</asp:ListItem>
           <asp:ListItem Value="amount">Amount</asp:ListItem>
           <asp:ListItem Value="handled">Status</asp:ListItem>
           <asp:ListItem Value="vacancy_id">Vacancy ID</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
<asp:Repeater ID="rptVacancyinvoice" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Amount</th><th>Employer</th><th>Status</th><th>Vacancy</th><th>Created By</th><th>Created Time</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "vacancyinvoice_id")%>'></asp:Label>
            </td>
            <td>
              <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'></asp:Label>
            </td>
            <td>
               <asp:HyperLink ID="HyperLink1" NavigateUrl ='<%#"~/Employer/ViewEmployer.aspx?id=" & Employer.getIDbyVacancy(DataBinder.Eval(Container.DataItem, "vacancy_id"))%>' runat="server"><%# Employer.getNamebyVacany(DataBinder.Eval(Container.DataItem, "vacancy_id"))%></asp:HyperLink>
            </td>
 		<td>
              <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "handled")%>'></asp:Label>
            </td>
		<td>
           <asp:HyperLink ID="HyperLink6" NavigateUrl ='<%#"~/Vacancy/ViewVacancy.aspx?id=" & DataBinder.Eval(Container.DataItem, "vacancy_id")%>' runat="server"><%# Vacancy.getTitle(DataBinder.Eval(Container.DataItem, "vacancy_id"))%></asp:HyperLink>
            </td>
            <td>
              
            <asp:Label ID="Label7" runat="server" visible ='<%#logged_user.getPerm() < 3 %>' Text='<%#User_Account.getName(DataBinder.Eval(Container.DataItem, "user_id"))%>'></asp:Label>
            <asp:HyperLink ID="HyperLink5" runat="server" visible ='<%#logged_user.getPerm() > 2 %>' NavigateUrl ='<%#"~/User/ViewUser.aspx?id=" & DataBinder.Eval(Container.DataItem, "user_id")%>'><%#User_Account.getName(DataBinder.Eval(Container.DataItem, "user_id"))%></asp:HyperLink>
            </td>
            <td>
              <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "created_time")%>'></asp:Label>
           
            <td ID="editr" runat="server" visible="true">
 		<asp:HyperLink ID="HyperLink2" Visible ='<%#enablePaid(DataBinder.Eval(Container.DataItem, "vacancyinvoice_id"))%>' runat="server" NavigateUrl='<%#"~/Invoice/VacancyInvoices.aspx?action=setpaid&id="&DataBinder.Eval(Container.DataItem, "vacancyinvoice_id")&urlExtend()%>'><img src="../Images/paymentOk.png" alt="" height="12" />Set Paid</asp:HyperLink>
        <asp:HyperLink ID="HyperLink4" Visible ='<%#enablePending(DataBinder.Eval(Container.DataItem, "vacancyinvoice_id"))%>' runat="server" NavigateUrl='<%#"~/Invoice/VacancyInvoices.aspx?action=setpending&id="&DataBinder.Eval(Container.DataItem, "vacancyinvoice_id")&urlExtend()%>'><img src="../Images/paymentPending.gif" alt="" height="12" />Set Pending</asp:HyperLink>
             <asp:HyperLink ID="HyperLink3" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/Invoice/VacancyInvoices.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "vacancyinvoice_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
    </div>
</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
<div class="tb-right">
    <asp:Button ID="btnReport" runat="server" 
        Text="Generate Report From Query" 
        onclientclick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);" />
    </div>
</asp:Content>

