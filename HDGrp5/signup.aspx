<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="HDGrp5.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
        <center><h1>Sign up</h1></center>
        </div>
        <div class="row">
                <asp:Label ID="lblErrorMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
            </div>
            <div class="form-group">
                <label for="Name">Name</label>
                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Your Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredName" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </div>
        
            <div class="form-group">
                <label for="EmailAdress">E-Mail Adress</label>
                <asp:TextBox CssClass="form-control" ID="SignUpEmail" runat="server" placeholder="abc@xcy.hf"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredEMail" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="SignUpEmail"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Enter a Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredPassword" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                
            </div>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txtReEnterPassword" runat="server" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredReEnterPassword" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="txtReEnterPassword"></asp:RequiredFieldValidator>
                
            </div>
            <div class="form-group">
                <asp:Button class="btn btn-success btn-block" ID="btnSignup" runat="server" Text="Sign Up" OnClick="CreateUser" />
            </div>
             
       
    </div>

    </asp:Content>