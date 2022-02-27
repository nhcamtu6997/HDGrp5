<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="createticket.aspx.cs" Inherits="HDGrp5.createticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <!--Message for User-->
                <div class="row">
                    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
                </div>
                <!--End Message for User-->
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


                            <asp:TextBox CssClass="form-control" ValidationGroup="valGroup1" ID="txtSubject" placeholder="Headline to your issue..." runat="server"></asp:TextBox>


                        </div>

                        <label>Category</label>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control w-100" AppendDataBoundItems="true" DataTextField="name" DataValueField="name" DataSourceID="SourceCategory" AutoPostBack="true">
                                <asp:ListItem Value="0"> Select Category</asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SourceCategory" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [name] FROM [g5_kategorie] WHERE [parentName] IS NULL"></asp:SqlDataSource>
                        </div>

                        <label>Sub Category</label>
                        <div class="form-group">


                            <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control w-h-100" AutoPostBack="true" ValidationGroup="valGroup1"  DataTextField="name" DataValueField="name" DataSourceID="SourceSubCategory">
                                <asp:ListItem Value="0">Select Sub Category</asp:ListItem>                              


                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SourceSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [name] from [g5_kategorie] WHERE parentName=@name">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCategory" PropertyName="SelectedValue" Name="name" Type="String" DefaultValue="Select SubCategory" />
                                </SelectParameters>
                            </asp:SqlDataSource>


                        
                           
                        </div>
                        <label>Message</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtMessage" TextMode="MultiLine" Columns="50" Rows="10" runat="server" placeholder="Describe your issue..."></asp:TextBox>

                        </div>

                        <div class="form-group d-grid gap-2 d-md-flex justify-content-md-end">

                            <asp:Button ID="btnDiscard" class="btn btn-link me-md-2" runat="server" Text="Discard" OnClick="btnDiscard_Click" />
                            <asp:Button ID="btnSubmit" ValidationGroup="valGroup1" CausesValidation="true" class="btn btn-primary btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtsubject" ValidationGroup="valGroup1" ErrorMessage="Please select a Subject."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSubCategory" ValidationGroup="valGroup1" ErrorMessage="Please select a Category."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMessage" ValidationGroup="valGroup1" ErrorMessage="Please describe your issue."/>

                            

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
