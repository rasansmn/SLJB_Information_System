<%@ Page Title="Campaign Sponsorships | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Sponsorships.aspx.vb" Inherits="Sponsorship_Sponsorships" %>

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
    <h2><img alt="" src="../Images/icon9.gif" height="25" /> Campaign Sponsorships <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Campaign Sponsorships in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="sponsorship_id">ID</asp:ListItem>
           <asp:ListItem Value="emp_id">Employer ID</asp:ListItem>
           <asp:ListItem Value="campaign_id">Campaign ID</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>

<asp:Repeater ID="rptSponsorships" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Employer</th><th>Job Campaign</th><th>Created By</th><th>Created Time</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "sponsorship_id")%>'></asp:Label>
            </td>
            <td>
            <asp:HyperLink ID="HyperLink5" NavigateUrl ='<%#"~/Employer/ViewEmployer.aspx?id=" & DataBinder.Eval(Container.DataItem, "emp_id")%>' runat="server"><%# Employer.getName(DataBinder.Eval(Container.DataItem, "emp_id"))%></asp:HyperLink>
            </td>
 		<td>
        
               <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ='<%#"~/Campaign/ViewCampaign.aspx?id=" & DataBinder.Eval(Container.DataItem, "campaign_id")%>'><%# Campaign.getLocation(DataBinder.Eval(Container.DataItem, "campaign_id"))%></asp:HyperLink>
            </td>
            <td>
               <asp:Label ID="Label3" runat="server" visible ='<%#logged_user.getPerm() < 3 %>' Text='<%#User_Account.getName(DataBinder.Eval(Container.DataItem, "user_id"))%>'></asp:Label>
                <asp:HyperLink ID="HyperLink4" runat="server" visible ='<%#logged_user.getPerm() > 2 %>' NavigateUrl ='<%#"~/User/ViewUser.aspx?id=" & DataBinder.Eval(Container.DataItem, "user_id")%>'><%#User_Account.getName(DataBinder.Eval(Container.DataItem, "user_id"))%></asp:HyperLink>
            </td>
            <td>
              <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "created_time")%>'></asp:Label>
           
            <td ID="editr" runat="server" visible="true">
             <asp:HyperLink ID="HyperLink2" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" runat="server" NavigateUrl='<%#"~/Sponsorship/Sponsorships.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "sponsorship_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
</asp:Content>

