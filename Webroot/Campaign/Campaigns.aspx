<%@ Page Title="Job Campaigns | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Campaigns.aspx.vb" Inherits="Campaign_Campaigns" %>

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
   <h2><img alt="" src="../Images/icon9.gif" height="25" /> Job Campaigns <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Job Campaigns in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="campaign_id">ID</asp:ListItem>
           <asp:ListItem Value="location">Location</asp:ListItem>
           <asp:ListItem Value="date">Date</asp:ListItem>
           <asp:ListItem Value="dsdivision_id">Division ID</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
<asp:Repeater ID="rptCampaigns" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Location</th><th>Date</th><th>Divisional Area</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "campaign_id")%>'></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ='<%#"~/Campaign/ViewCampaign.aspx?id=" & DataBinder.Eval(Container.DataItem, "campaign_id")%>'><%# DataBinder.Eval(Container.DataItem, "location")%></asp:HyperLink>
            </td>
            <td>
               <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "date")%>'></asp:Label>
            </td>
            <td>
              <asp:Label ID="Label4" runat="server" Text='<%#DS_Division.getName(DataBinder.Eval(Container.DataItem, "dsdivision_id"))%>'></asp:Label>
            </td>

            <td ID="editr" runat="server" visible="true">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Campaign/EditCampaign.aspx?id="&DataBinder.Eval(Container.DataItem, "campaign_id")&urlExtend()%>'><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
             <asp:HyperLink ID="HyperLink2" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/Campaign/Campaigns.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "Campaign_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
     <asp:Button ID="btnAddCampaign" runat="server" Text="Add Campaign"  />
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

