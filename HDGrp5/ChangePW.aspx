<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePW.aspx.cs" Inherits="HDGrp5.ChangePW" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
                <asp:Label ID="lblErrorMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
            </div>
        <div class="row">
                <asp:Label ID="lblSuccess" runat="server" Visible="false" CssClass="form-control"></asp:Label>
            </div>

        <div class="form-group">
                <label for="CurrentPassword">Current Password:</label>
                <asp:TextBox CssClass="form-control" ID="txtCurrentPassword" runat="server" TextMode="Password" placeholder="Enter your current Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredPassword" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="txtCurrentPassword"></asp:RequiredFieldValidator>
            </div>

         <div class="form-group">
                <label for="NewPassword">New Password:</label>
                <asp:TextBox CssClass="form-control" ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Enter your new Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredNewPassword" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
            </div>

        <div class="form-group">
                <label for="ConfirmNewPassword">Confirm new Password:</label>
                <asp:TextBox CssClass="form-control" ID="txtConfirmNewPassword" runat="server" TextMode="Password" placeholder="Re-Enter your new Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredConfirmNewPassword" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="txtConfirmNewPassword"></asp:RequiredFieldValidator>
            </div>
        <div class="form-group">
            <asp:Button class="btn btn-success btn-block" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="ChangePassword" />
        </div>
   
    </div>

</asp:Content>