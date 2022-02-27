<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeUsername.aspx.cs" Inherits="HDGrp5.ChangeUsername" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-md-6 mx-auto">
                <div class="row">
                        <asp:Label ID="lblSuccess" runat="server" Visible="false" CssClass="alert alert-success"></asp:Label>      
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <label for="txtNewUsername">New Username:</label>
                            <asp:TextBox CssClass="form-control" ID="txtNewUsername" runat="server" placeholder="Enter your new Username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredName" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="txtNewUsername"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="NewUsername" runat="server" Text="Change Username" OnClick="ChangeUser" class="btn btn-success btn-block"/>
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
