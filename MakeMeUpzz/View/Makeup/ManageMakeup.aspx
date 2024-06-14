<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz.View.ManageMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Makeup</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Makeup</h1>
    <hr />
    <div>
        <h2>Makeup</h2>
        <asp:GridView ID="MakeupGV" runat="server" OnRowEditing="MakeupGV_RowEditing" OnRowDeleting="MakeupGV_RowDeleting" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandRating" HeaderText="Brand Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True"/>
            </Columns>
        </asp:GridView>
        <a href="InsertMakeup.aspx">Insert Makeup</a>
    </div>
    <div>
        <h2>Makeup Type</h2>
        <asp:GridView ID="MakeupTypeGV" runat="server" OnRowEditing="MakeupTypeGV_RowEditing" OnRowDeleting="MakeupTypeGV_RowDeleting" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Name" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True"/>
            </Columns>
        </asp:GridView>
        <a href="InsertMakeupType.aspx">Insert Makeup Type</a>
    </div>
    <div>
        <h2>Makeup Brand</h2>
        <asp:GridView ID="MakeupBrandGV" runat="server" OnRowEditing="MakeupBrandGV_RowEditing" OnRowDeleting="MakeupBrandGV_RowDeleting" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Name" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True"/>
            </Columns>
        </asp:GridView>
        <a href="InsertMakeupBrand.aspx">Insert Makeup Brand</a>
    </div>
</asp:Content>
