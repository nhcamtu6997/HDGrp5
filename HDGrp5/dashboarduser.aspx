<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboarduser.aspx.cs" Inherits="HDGrp5.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 class="text-center mb-4">Dashboard for User</h1>
        <!--Message for User-->
        <div>
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label></div>
        <!-- End Message for User-->
        <div class="row">
            <div class="col-md-8 mx-auto">
                <asp:GridView class="table table-sm table-bordered" ID="GridView1" runat="server" EmptyDataText="No record to display..!" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="id"  OnRowCommand ="GridView1_RowCommand">
                    <Columns>
                        
                        <asp:BoundField DataField="id" HeaderText="Ticket ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="title" HeaderText="Title">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="kategorie_name" HeaderText="Category">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="create_date" HeaderText="Created Date">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True">
                        <HeaderStyle HorizontalAlign ="Center"/>
                        </asp:BoundField>

                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" CommandName="ViewTicket" CommandArgument='<%#Eval("id")%>' CssClass="btn btn-warning">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
