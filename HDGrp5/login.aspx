<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HDGrp5.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
      <div class="row">  
         <div class="col-md-6 mx-auto">
            <div class="row">
                <div class="col">
                    <center>
                        <h1>Login</h1>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <hr>
                </div>
            </div>
             <!--Message for User-->
            <div class="row">
                <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
            </div>
            <div class="row">
                <div class="col">
                    <label>Email</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="abc@xcy.hf"></asp:TextBox>
                    </div>
                    <label>Password</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="*******" TextMode="Password"></asp:TextBox>
                    </div>
                    <label>Login Type</label>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlLoginType" CssClass="form-control w-100" runat="server">
                            <asp:ListItem Value="0">Select Login Type</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>User</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                    <asp:Button class="btn btn-success btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                 </div>

            </div>
             <div class="form-group position-relative">
                 <a href="resetpass.aspx">Reset password?</a>
                 <a href="signup.aspx" style="display:flex; width:100%; padding:0;">Not signed up yet? Create Account</a>                              
             </div>
             
            <div>
                <p>Test Data
                    <br>Admin: test.projekten.tun@gmail.com
                    <br>Passwort: 123
                    <br>User: tun.ltinh23@gmail.com
                    <br>Passwort: YH?y}_8Y
                </p>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
