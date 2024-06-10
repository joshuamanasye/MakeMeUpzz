<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MakeMeUpzz.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<title>MakeMeUpzz - Home</title>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="RoleLbl" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="CustomerGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="DOB" SortExpression="UserDOB" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
