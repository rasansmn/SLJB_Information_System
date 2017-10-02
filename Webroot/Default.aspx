<%@ Page Title="Home | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotification" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCommon" Runat="Server">
    <div class ="mainoptions ">
<p><b>Welcome to Sri Lanka Job Bank CMS, click a module below to get started!</b></p>
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
<div class ="mainoptions ">
<p>
 <a href ="~/Job Seeker/JobSeekers.aspx">
     <img alt="" src="Images/icon1.jpg" style="height: 70px; width: 70px" /></a>
    <br /><asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Job Seeker/JobSeekers.aspx">
        Job Seekers</asp:HyperLink>  - Add, Update, Delete, and Search Job Seekers 
</p>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
<div class ="mainoptions ">
<p>
    <a href ="Employer/Employers.aspx">
     <img alt="" src="Images/icon2.jpg" style="height: 80px; width: 80px" /></a>
    <br /><asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/Employer/Employers.aspx">
        Employers</asp:HyperLink>  - Add, Update, Delete, and Search Employers 
    
</p>
<p>
     <a href ="Vacancy/Vacancies.aspx">
     <img alt="" src="Images/icon6.png" style="height: 70px; width: 70px" /></a>
    <br /><asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/Vacancy/Vacancies.aspx">
        Vacancies</asp:HyperLink>  - Add, Update, Delete, and Search Job Vacancies 
</p>

<p>
     <a href ="Campaign/Campaigns.aspx">
     <img alt="" src="Images/icon9.gif" style="height: 70px; width: 70px" /></a>
    <br />
     <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="~/Campaign/Campaigns.aspx">
        Campaigns</asp:HyperLink>  - Add, Update, Delete, and Search Job Campaigns</p>
<p>
     <a href ="Invoice/CampaignInvoices.aspx">
     <img alt="" src="Images/invoice1.jpg" style="height: 70px; width: 70px" /></a>
    <br /><asp:HyperLink ID="HyperLink5" runat="server" 
        NavigateUrl="~/Vacancy/Vacancies.aspx">
        Campaign Invoices</asp:HyperLink>  - Invoices of campaign sponsorships 
</p>
<p>
     <a href ="Invoice/VacancyInvoices.aspx">
     <img alt="" src="Images/invoice2.jpg" style="height: 70px; width: 70px" /></a>
    <br />
     <asp:HyperLink ID="HyperLink6" runat="server" 
        NavigateUrl="~/Invoice/VacancyInvoices.aspx">
        Vacancy Invoices</asp:HyperLink>  - Invoices of vacancies
</p>
<p>
     <a href ="Application/Applications.aspx">
     <img alt="" src="Images/application2.png" style="height: 70px; width: 70px" /></a>
    <br /><asp:HyperLink ID="HyperLink7" runat="server" 
        NavigateUrl="~/Application/Applications.aspx">
        Applications</asp:HyperLink>  - Job applications
</p>
</div> 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
    <div class ="mainoptions ">
<p>
     <a href ="User/Users.aspx">
     <img alt="" src="Images/icon4.jpg" style="height: 70px; width: 70px" /></a>
    <br /><asp:HyperLink ID="HyperLink8" runat="server" 
        NavigateUrl="~/User/Users.aspx">
        Users</asp:HyperLink>  - System users
</p>
</div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphCommonBottom" Runat="Server">
<div class ="bottom-mainoptions ">
<p>
     <a href ="User/UpdateProfile.aspx">
     <img alt="" src="Images/update.png" style="height: 70px; width: 70px" /></a>
    <br />
     <asp:HyperLink ID="HyperLink9" runat="server" 
        NavigateUrl="~/User/UpdateProfile.aspx">
        Update Profile</asp:HyperLink>  - Change username and password
</p>
</div>
</asp:Content>
