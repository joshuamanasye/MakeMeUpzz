<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="MakeMeUpzz.View.Makeup.OrderMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Makeup</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Makeup</h1>

    <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowCommand="MakeupGV_RowCommand">
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="MakeupIDHiddenField" runat="server" Value='<%# Eval("MakeupID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName"/>
            <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
            <asp:BoundField DataField="MakeupWeight" HeaderText="Weight (grams)" SortExpression="MakeupWeight" />
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeName" />
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrandName" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="QtyTxt" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Order" Text="Order" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="OrderLbl" runat="server" Text=""></asp:Label>

    <%-- CartGV hanya untuk tes, bukan aplikasi karena tidak ada di soal --%>
    <asp:GridView ID="CartGV" runat="server"></asp:GridView>
    
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />

</asp:Content>
