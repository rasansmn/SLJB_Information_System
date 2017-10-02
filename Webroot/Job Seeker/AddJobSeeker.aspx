<%@ Page Title="Add Job Seeker | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="AddJobSeeker.aspx.vb" Inherits="Job_Seeker_AddJobSeeker" %>

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
<h2><img alt="" src="../Images/icon1.jpg" height="25" /> Add a New Job Seeker</h2>
<p>Use the form below to add a new job seeker.</p>

<asp:ValidationSummary ID="AddJobSeekerValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="AddJobSeekerValidationGroup"/>
<div class="accountInfo">
<fieldset class="register">
<legend>Job Seeker Information</legend>
<p>
    <asp:Label ID="Label1" runat="server" Text="Name:"  
        AssociatedControlID="txtName"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" runat="server" 
        ErrorMessage="Name is required." ControlToValidate="txtName" ValidationGroup="AddJobSeekerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Address:" 
        AssociatedControlID="txtAddress"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Address is required." ControlToValidate="txtAddress" ValidationGroup="AddJobSeekerValidationGroup" CssClass="failureNotification">*</asp:RequiredFieldValidator>

</p>
   <p>
       <asp:Label ID="Label15" runat="server" Text="Divisional Area:"></asp:Label>
       <asp:DropDownList ID="ddlDivision" runat="server" CssClass="general">
       </asp:DropDownList>
   </p>
<p>
 <asp:Label ID="Label3" runat="server" Text="Phone:"></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
</p>

<p>
    <asp:Label ID="Label4" runat="server" Text="Civil Status:"></asp:Label>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="general">
        <asp:ListItem>Single</asp:ListItem>
        <asp:ListItem>Married</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="NIC Number:"></asp:Label>
    <asp:TextBox ID="txtNic" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Birthday:" 
        AssociatedControlID="ddlYear"></asp:Label>
    <asp:DropDownList ID="ddlYear" runat="server" CssClass="birthday">
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2008</asp:ListItem>
        <asp:ListItem>2007</asp:ListItem>
        <asp:ListItem>2006</asp:ListItem>
        <asp:ListItem>2005</asp:ListItem>
        <asp:ListItem>2004</asp:ListItem>
        <asp:ListItem>2003</asp:ListItem>
        <asp:ListItem>2002</asp:ListItem>
        <asp:ListItem>2001</asp:ListItem>
        <asp:ListItem>2000</asp:ListItem>
        <asp:ListItem>1999</asp:ListItem>
        <asp:ListItem>1998</asp:ListItem>
        <asp:ListItem>1997</asp:ListItem>
        <asp:ListItem>1996</asp:ListItem>
        <asp:ListItem>1995</asp:ListItem>
        <asp:ListItem>1994</asp:ListItem>
        <asp:ListItem>1993</asp:ListItem>
        <asp:ListItem>1992</asp:ListItem>
        <asp:ListItem>1991</asp:ListItem>
        <asp:ListItem>1990</asp:ListItem>
        <asp:ListItem>1989</asp:ListItem>
        <asp:ListItem>1988</asp:ListItem>
        <asp:ListItem>1987</asp:ListItem>
        <asp:ListItem>1986</asp:ListItem>
        <asp:ListItem>1985</asp:ListItem>
        <asp:ListItem>1984</asp:ListItem>
        <asp:ListItem>1983</asp:ListItem>
        <asp:ListItem>1982</asp:ListItem>
        <asp:ListItem>1981</asp:ListItem>
        <asp:ListItem>1980</asp:ListItem>
        <asp:ListItem>1979</asp:ListItem>
        <asp:ListItem>1978</asp:ListItem>
        <asp:ListItem>1977</asp:ListItem>
        <asp:ListItem>1976</asp:ListItem>
        <asp:ListItem>1975</asp:ListItem>
        <asp:ListItem>1974</asp:ListItem>
        <asp:ListItem>1973</asp:ListItem>
        <asp:ListItem>1972</asp:ListItem>
        <asp:ListItem>1971</asp:ListItem>
        <asp:ListItem>1970</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="birthday">
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlDate" runat="server" CssClass="birthday">
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
        <asp:ListItem>24</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>26</asp:ListItem>
        <asp:ListItem>27</asp:ListItem>
        <asp:ListItem>28</asp:ListItem>
        <asp:ListItem>29</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>31</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label7" runat="server" Text="Gender:"></asp:Label>
    <asp:DropDownList ID="ddlGender" runat="server" CssClass="general">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label8" runat="server" Text="Driving License No:"></asp:Label>
    <asp:TextBox ID="txtLicense" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label9" runat="server" Text="Languages"></asp:Label>
    <asp:TextBox ID="txtLanguages" runat="server" CssClass="textEntry"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label10" runat="server" Text="G.C.E Ordinary Level:"></asp:Label>
    <asp:TextBox ID="txtOl" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label11" runat="server" Text="G.C.E Advanced Level:"></asp:Label>
    <asp:TextBox ID="txtAl" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label12" runat="server" Text="Higher Education:"></asp:Label>
    <asp:TextBox ID="txtHigher" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label13" runat="server" Text="Work Experience:"></asp:Label>
    <asp:TextBox ID="txtExperience" runat="server" CssClass="textEntry" 
        TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label14" runat="server" Text="Resume File: "></asp:Label>
    <asp:FileUpload ID="fleCv" runat="server" CssClass="upld" />
    <asp:CustomValidator ID="valFile" runat="server" 
        ErrorMessage="Invalid file format." 
        ValidationGroup="AddJobSeekerValidationGroup" CssClass="failureNotification" 
        ControlToValidate="fleCv">*</asp:CustomValidator>
</p>

</fieldset>
<p class="submitButton">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit Job Seeker" ValidationGroup="AddJobSeekerValidationGroup"/>
</p>
</div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

