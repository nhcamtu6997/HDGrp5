<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeUsername.aspx.cs" Inherits="HDGrp5.ChangeUsername" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
                <asp:Label ID="lblSuccess" runat="server" Visible="false" CssClass="form-control"></asp:Label>
           </div>

        <div class="form-group">
                <label for="txtNewUsername">New Username:</label>
                <asp:TextBox CssClass="form-control" ID="txtNewUsername" runat="server" placeholder="Enter your new Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredName" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="txtNewUsername"></asp:RequiredFieldValidator>
            </div>
    <div class="form-group">
        <asp:Button ID="NewUsername" runat="server" Text="Change Username" OnClick="ChangeUser" />
        </div>
</div>
    </asp:Content>