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
                <!--Message for User-->
                <div class="row">
                    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
                </div>
                <!--End Message for User-->
                <div class="row">
                    <div class="col">
                        <label>Subject</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtSubject" runat="server"></asp:TextBox>
                        </div>
                        <label>Kategorie</label>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control w-100" AppendDataBoundItems="true" DataTextField="name" DataValueField="name" DataSourceID="SqlDataSource1">
                                <asp:ListItem Value="0"> Select Category</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFielValidator1" runat="server" ErrorMessage="This field is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [name] FROM [g5_kategorie]"></asp:SqlDataSource>
                        </div>
                        <label>Message</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtMessage" TextMode="MultiLine" Columns="50" Rows="10" runat="server" placeholder="Ihre Problem .."></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <input type="file" name="attachment">
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnDiscard" class="btn btn-link" runat="server" Text="Discard" OnClick="btnDiscard_Click" />
                            <asp:Button ID="btnSubmit" class="btn btn-primary btn-success" runat="server" Text="Add" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
