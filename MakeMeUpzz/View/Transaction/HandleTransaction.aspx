<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="HandleTransaction.aspx.cs" Inherits="MakeMeUpzz.View.Transaction.HandleTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Handle Transaction</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Unhandled Transaction</h1>
    <asp:GridView ID="UnhandledGV" runat="server" OnRowCommand="UnhandledGV_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="User.Username" HeaderText="Username" SortExpression="User.Username" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
            <asp:ButtonField ButtonType="Button" CommandName="Handle" Text="Handle" />
        </Columns>
    </asp:GridView>
    <hr />
    <h1>Handled Transaction</h1>
    <asp:GridView ID="HandledGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="User.Username" HeaderText="Username" SortExpression="User.Username" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
        </Columns>
    </asp:GridView>
</asp:Content>
