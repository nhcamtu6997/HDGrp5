<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="resetRequest.aspx.cs" Inherits="HDGrp5.resetRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="row">
                <div class="col">
                    <center>
                        <h1>Reset Password</h1>
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
                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="abc@xcy.hf"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredType" ErrorMessage="This field is required" runat="server" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                    <asp:Button class="btn btn-success btn-block" ID="btnReset" runat="server" Text="Send request to reset password" OnClick="btnReset_Click" />
                    </div>
                 </div>

            </div>
         </div>
      </div>
   </div>
</asp:Content>
