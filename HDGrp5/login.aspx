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
            <div class="row">
                <div class="col">
                    <label>Email</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="abc@xcy.hf"></asp:TextBox>
                    </div>
                    <label>Password</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="*******" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                    </div>
                 </div>

            </div>
            <a href="resetpass.aspx">Reset password? >> </a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
