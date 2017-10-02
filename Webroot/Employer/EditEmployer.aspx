<%@ Page Title="Edit Employer | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="EditEmployer.aspx.vb" Inherits="Employer_EditEmployer" %>

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
    <h2><img alt="" src="../Images/icon2.jpg" height="25" /> Edit Employer</h2>
<p>Use the form below to update Employer.</p>

<asp:ValidationSummary ID="AddEmployerValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="UpdateEmployerValidationGroup"/>
<div class="accountInfo">
<fieldset class="register">
<legend>Employer Information</legend>
<p>
    <asp:Label ID="Label1" runat="server" Text="Name:" 
        AssociatedControlID="txtName"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Name is required." ControlToValidate="txtName" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Description:" 
        AssociatedControlID="txtDescription"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Description is required." ControlToValidate="txtDescription" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label8" runat="server" Text="Address:" 
        AssociatedControlID="txtAddress"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Address is required." ControlToValidate="txtAddress" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Telephone:" 
        AssociatedControlID="txtPhone"></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Telephone is required." ControlToValidate="txtPhone" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Fax:" 
        AssociatedControlID="txtFax"></asp:Label>
    <asp:TextBox ID="txtFax" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="E-Mail:" 
        AssociatedControlID="txtEmail"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ErrorMessage="E-Mail is required." ControlToValidate="txtEmail" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
<asp:Label ID="Label6" runat="server" Text="Website:" 
        AssociatedControlID="txtWebsite"></asp:Label>
    <asp:TextBox ID="txtWebsite" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label7" runat="server" Text="Coordinator:" 
        AssociatedControlID="txtCoordinator"></asp:Label>
    <asp:TextBox ID="txtCoordinator" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ErrorMessage="Coordinator is required." ControlToValidate="txtCoordinator" 
        ValidationGroup="UpdateEmployerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>

</fieldset>
<p class="submitButton">
    <asp:Button ID="btnUpdateEmployer" runat="server" 
        ValidationGroup="UpdateEmployerValidationGroup" Text="Update Employer" />
</p>
</div> 
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

