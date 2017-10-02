<%@ Page Title="Add Job Campaign | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="AddCampaign.aspx.vb" Inherits="Campaign_AddCampaign" %>

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
 <h2><img alt="" src="../Images/icon9.gif" height="25" /> Create a New Job Campaign</h2>
<p>Use the form below to add a new job campaign.</p>
<span class="failureNotification">
<asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="AddDisctrictValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="AddCampaignValidationGroup"/>

                         <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Campaign Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" 
                                    AssociatedControlID="txtLocation">Campaign Location:</asp:Label>
                                <asp:TextBox ID="txtLocation" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DisctrictNameRequired" runat="server" ControlToValidate="txtLocation" 
                                     CssClass="failureNotification" ErrorMessage="Campaign Location is required." ToolTip="District Name is required." 
                                     ValidationGroup="AddCampaignValidationGroup">*</asp:RequiredFieldValidator>
                            </p>

                            <p>
    <asp:Label ID="Label6" runat="server" Text="Date:" 
        AssociatedControlID="ddlYear"></asp:Label>
    <asp:DropDownList ID="ddlYear" runat="server" CssClass="birthday">
        <asp:ListItem>2015</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2010</asp:ListItem>
        <asp:ListItem>2009</asp:ListItem>
        <asp:ListItem>2007</asp:ListItem>
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
       <asp:Label ID="Label15" runat="server" Text="Divisional Area:" 
           AssociatedControlID="ddlDivision"></asp:Label>
       <asp:DropDownList ID="ddlDivision" runat="server" CssClass="general">
       </asp:DropDownList>
   </p>
                            
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="AddCampaignButton" runat="server" CommandName="MoveNext" Text="Create Campaign" 
                                 ValidationGroup="AddCampaignValidationGroup" />
                        </p>
                    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

