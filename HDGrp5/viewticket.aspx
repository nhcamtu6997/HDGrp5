<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewticket.aspx.cs" Inherits="HDGrp5.viewticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <h1 class="text-center mb-4">Ticket</h1>
                <%--Message for User--%>
                <div class="row">
                    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="form-control"></asp:Label>
                </div>
                <%--End Message for User--%>

                <div class="row">
                    <div class="col">
                        <%--Ticket--%>
                        <div class="card mb-3">
                            <div class="card-header">
                                <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Bold="true" Font-Size="Larger"></asp:Label>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <div id="dMsg" runat="server"></div>
                                        <br />
                                        <i class="fas fa-user mr-1"></i>
                                        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                                        <i class="fas fa-calendar ml-4 mr-1"></i>
                                        <asp:Label ID="lblDate" runat="server" Text="Created Date"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--End Ticket--%>
                        <h3 class="mb-4">Replies</h3>
                        <%--Reply output repeat--%>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="card mb-3">
                                    <div class="card-header">
                                        <i class="fas fa-user mr-1"></i>
                                        <asp:Label ID="lblRepUserName" runat="server" Text='<%#Eval("name") %>' />
                                        <i class="fas fa-calendar ml-4 mr-1"></i>
                                        <asp:Label ID="lblRepTime" runat="server" Text='<%#Eval("date") %>' />
                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <div id="Div1" runat="server" InnerText='<%#Eval("text") %>' />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--End output repeat--%>

                        <%--Reply input--%>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtReply" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnReply" class="btn btn-primary btn-success" runat="server" Text="Reply" OnClick="btnReply_Click" />
                        </div>
                        <%--End Reply input--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
