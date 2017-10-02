<%@ Page Title="Job Seekers | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="JobSeekers.aspx.vb" Inherits="Job_Seeker_JobSeekers" %>

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



<h2><img alt="" src="../Images/icon1.jpg" height="25" /> Job Seekers <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>

  
   <div class="table-top">
   <div class="tt-left">
   <asp:Label ID="lblTableCapation" runat="server" 
           Text="The list of Job Seekers in the system."></asp:Label>
   </div>
   <div class="tt-right">
   Look In: 
       <asp:DropDownList ID="ddlLookin" runat="server">
           <asp:ListItem Value="jobseeker_id">ID</asp:ListItem>
           <asp:ListItem Value="name">Name</asp:ListItem>
           <asp:ListItem Value="address">Address</asp:ListItem>
           <asp:ListItem Value="phone">Phone</asp:ListItem>
           <asp:ListItem Value="status">Status</asp:ListItem>
           <asp:ListItem Value="nic">NIC</asp:ListItem>
           <asp:ListItem Value="birthday">Birthday</asp:ListItem>
           <asp:ListItem Value="gender">Gender</asp:ListItem>
           <asp:ListItem Value="license">License</asp:ListItem>
           <asp:ListItem Value="languages">Languages</asp:ListItem>
           <asp:ListItem Value="ordinary_level">Ordinary Level</asp:ListItem>
           <asp:ListItem Value="advanced_level">Advanced Level</asp:ListItem>
           <asp:ListItem Value="higher_edu">Higher Education</asp:ListItem>
           <asp:ListItem Value="work_experience">Work Experience</asp:ListItem>
           <asp:ListItem Value="cv">CV File</asp:ListItem>
           <asp:ListItem Value="dsdivision_id">Division ID</asp:ListItem>
           <asp:ListItem Value="user_id">Created By ID</asp:ListItem>
           <asp:ListItem Value="created_time">Created Time</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="Search" />
   </div>
   </div>
   <asp:Repeater ID="rptJobseekers" runat="server">
    <HeaderTemplate>
    <table id="customers">
    <th>ID</th><th>Name</th><th>Divisional Area</th><th>Phone</th><th>Gender</th><th>Applications</th><th>Actions</th>
    </HeaderTemplate>
         <ItemTemplate>
         <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "jobseeker_id")%>'></asp:Label>
            </td>
            <td>
              <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%#"~/Job Seeker/ViewJobSeeker.aspx?id="&DataBinder.Eval(Container.DataItem, "jobseeker_id")%>'><%# DataBinder.Eval(Container.DataItem, "name")%></asp:HyperLink>
            </td>
            <td>
               <asp:Label ID="Label2" runat="server" Text='<%#DS_Division.getName(DataBinder.Eval(Container.DataItem, "dsdivision_id"))%>'></asp:Label>
            </td>
            <td>
              <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "phone")%>'></asp:Label>
            </td>
  		<td>
              <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "gender")%>'></asp:Label>
            </td>
  		<td>
         
              <asp:HyperLink ID="HyperLink4" NavigateUrl ='<%#"~/Application/Applications.aspx?jobseeker_id=" & DataBinder.Eval(Container.DataItem, "jobseeker_id")%>' runat="server"><%# Vacancy_Application.getApplicationsbyjobseeker(DataBinder.Eval(Container.DataItem, "jobseeker_id"))%></asp:HyperLink>
            </td>
            <td ID="editr" runat="server" visible="true">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/Job Seeker/EditJobSeeker.aspx?id="&DataBinder.Eval(Container.DataItem, "jobseeker_id")&urlExtend()%>'><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
             <asp:HyperLink ID="HyperLink2" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }" NavigateUrl='<%#"~/Job Seeker/JobSeekers.aspx?action=delete&id="&DataBinder.Eval(Container.DataItem, "jobseeker_id")&urlExtend()%>'><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
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
     <asp:Button ID="btnAddJobSeeker" runat="server" Text="Add Job Seeker"  />
    </div>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
<div class="tb-right">
    <br /><asp:Button ID="btnReport" runat="server" 
        Text="Generate Report From Query" 
        onclientclick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);" />
    </div>
</asp:Content>

