<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboardadmin.aspx.cs" Inherits="HDGrp5.dashboardadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h1 class="text-center mb-4">Dashboard for Admin</h1>
        <!--Message for User-->
        <div>
            <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label></div>
        <!-- End Message for User-->
        <div class="row">
            <div class="col">
                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" EmptyDataText="No record to display..!" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="id">
                    <Columns>
                        
                        <asp:BoundField DataField="id" HeaderText="Ticket ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="title" HeaderText="Title">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="user_id" HeaderText="User ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="kategorie_name" HeaderText="Category">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="create_date" HeaderText="Created Date">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
