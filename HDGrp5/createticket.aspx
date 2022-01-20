<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="createticket.aspx.cs" Inherits="HDGrp5.createticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="row">
                <div class="col">
                    <center>
                        <h1>Create new Ticket</h1>
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
                    <label>Subject</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                    </div>
                    <label>Kategorie</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox2" ReadOnly="True" runat="server"></asp:TextBox>
                    </div>
                    <label>Message</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="TextBox3" TextMode="MultiLine" Columns="50" Rows="10" runat="server" placeholder="Ihre Problem .."></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <input type="file" name="attachment">
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Button1" class="btn btn-link" runat="server" Text="Discard" />
                        <asp:Button ID="Button2" class="btn btn-primary btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                    </div>
                 </div>

            </div>
         </div>
      </div>
   </div>
</asp:Content>
