<%@ Page Title="Edit Vacancy | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="EditVacancy.aspx.vb" Inherits="Vacancy_EditVacancy" %>

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
    <h2><img alt="" src="../Images/icon6.png" height="25" /> Edit Vacancy</h2>
<p>Use the form below to update Vacancy.</p>

<asp:ValidationSummary ID="AddVacancyValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="UpdateVacancyValidationGroup"/>

<div class="accountInfo">
<fieldset class="register">
<legend>Vacancy Information</legend>
<p>
    <asp:Label ID="Label1" runat="server" Text="Title:" 
        AssociatedControlID="txtTitle"></asp:Label>
    <asp:TextBox ID="txtTitle" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Title is required." ControlToValidate="txtTitle" 
        ValidationGroup="UpdateVacancyValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
   <p>
       <asp:Label ID="Label15" runat="server" Text="Employer:" 
           AssociatedControlID="ddlEmployer"></asp:Label>
       <asp:DropDownList ID="ddlEmployer" runat="server" CssClass="general">
       </asp:DropDownList>
   </p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Description:" 
        AssociatedControlID="txtDescription"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Description is required." ControlToValidate="txtDescription" 
        ValidationGroup="UpdateVacancyValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Qualifications:" 
        AssociatedControlID="txtQualifications"></asp:Label>
    <asp:TextBox ID="txtQualifications" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Qualifications are required." ControlToValidate="txtQualifications" 
        ValidationGroup="UpdateVacancyValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
   <p>
       <asp:Label ID="Label7" runat="server" Text="Status:" 
           AssociatedControlID="ddlStatus"></asp:Label>
       <asp:DropDownList ID="ddlStatus" runat="server" CssClass="general">
           <asp:ListItem>Open</asp:ListItem>
           <asp:ListItem>Closed</asp:ListItem>
       </asp:DropDownList>
   </p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Number of Positions:" 
        AssociatedControlID="txtPositions"></asp:Label>
    <asp:TextBox ID="txtPositions" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="Interview Date (if available):" 
        AssociatedControlID="txtInterviewdate"></asp:Label>
    <asp:TextBox ID="txtInterviewdate" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Salary Scale:" 
        AssociatedControlID="txtSalary"></asp:Label>
    <asp:TextBox ID="txtSalary" runat="server" CssClass="textEntry"></asp:TextBox>
</p>

</fieldset>
<p class="submitButton">
    <asp:Button ID="btnUpdateVacancy" runat="server" 
        ValidationGroup="UpdateVacancyValidationGroup" Text="Update Vacancy" />
</p>
</div> 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

