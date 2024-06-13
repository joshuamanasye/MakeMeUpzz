<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="MakeMeUpzz.View.Transaction.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transaction Detail</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction <%=Request.QueryString["id"] %></h1>
    <hr />
    <div>
        <table>
            <tr>
                <td>Buyer</td>
                <td><%=tran.User.Username %></td>
            </tr>
            <tr>
                <td>Date</td>
                <td><%=tran.TransactionDate %></td>
            </tr>
            <tr>
                <td>Total Product</td>
                <td><%=tran.TransactionDetails.Count %></td>
            </tr>
            <tr>
                <td>Total Quantity</td>
                <td><%=tran.TransactionDetails.Sum(td=>td.Quantity) %></td>
           
            </tr>
            <tr>
                <td>Total Type</td>
                <td><%=tran.TransactionDetails.GroupBy(td=>td.Makeup.MakeupTypeID).Count() %></td>
            </tr>
        </table>
        <br />
        <table border="1">
            <tr>
                <th>Makeup</th>
                <th>Makeup Type</th>
                <th>Makeup Price</th>
                <th>Quantity</th>
                <th>Subtotal</th>
            </tr>
            <%foreach (var td in tran.TransactionDetails) { %>
                <tr>
                    <td><%=td.Makeup.MakeupName %></td>
                    <td><%=td.Makeup.MakeupType.MakeupTypeName %></td>
                    <td><%=td.Makeup.MakeupPrice %></td>
                    <td><%=td.Quantity %></td>
                    <td><%=td.Quantity * td.Makeup.MakeupPrice %></td>
                </tr>
            <%} %>
            <tr>
                <td colspan="4">Total</td>
                <td colspan="1"><%=tran.TransactionDetails.Sum(td=>td.Quantity * td.Makeup.MakeupPrice) %></td>
            </tr>
        </table>
    </div>
</asp:Content>
