<%@ Page Title="Users | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="User_Users" %>

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
    <h2><img alt="" src="../Images/icon4.jpg" height="25" /> Users <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Users in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="user_id">ID</asp:ListItem>
           <asp:ListItem Value="username">User Name</asp:ListItem>
           <asp:ListItem Value="name">Name</asp:ListItem>
           <asp:ListItem Value="permission">Permission ID</asp:ListItem>
       </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
     <asp:Repeater ID="rptUsers" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Name</th><th>Username</th><th>Permission</th><th>Logs</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "user_id")%>'></asp:Label>
            </td>
            <td>
              <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
            </td>
            <td>
              <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ='<%#"~/User/ViewUser.aspx?id=" & DataBinder.Eval(Container.DataItem, "user_id")%>'><%# DataBinder.Eval(Container.DataItem, "username")%></asp:HyperLink>
            </td>
            <td>
              <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "permission")%>'></asp:Label>
            </td>
            <td>
            <asp:HyperLink ID="HyperLink4" NavigateUrl ='<%#"~/Log/Logs.aspx?user_id=" & DataBinder.Eval(Container.DataItem, "user_id")%>' runat="server"><%# User_Log.getNumLogs(DataBinder.Eval(Container.DataItem, "user_id"))%></asp:HyperLink>
            </td>
            <td ID="editr" runat="server" visible="true">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/User/EditUser.aspx?id="&DataBinder.Eval(Container.DataItem, "user_id")&urlExtend()%>'><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
             <asp:HyperLink ID="HyperLink2" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/User/Users.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "user_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
     <asp:Button ID="btnAddUser" runat="server" Text="Add User"  />
    </div>
</div>
<div class="clear"></div>

     </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

