<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="TransactionList.aspx.cs" Inherits="MakeMeUpzz.View.Transaction.TransactionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transaction List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1">
        <tr>
            <th>Transaction ID</th>
            <th>User</th>
            <th>Date</th>
            <th>Total Product</th>
            <th>Status</th>
            <th>View Details</th>
        </tr>
        <% foreach(var th in transactionHeaders) { %>
            <tr>
                <td><%=th.TransactionID %></td>
                <td><%=th.User.Username %></td>
                <td><%=th.TransactionDate %></td>
                <td><%=th.TransactionDetails.Count() %></td>
                <td><%=th.Status %></td>
                <td><a href="/View/Transaction/TransactionDetail.aspx?ID=<%=th.TransactionID %>">View Detail</a></td>
            </tr>
        <% }%>
    </table>
</asp:Content>
