<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="InsertMakeup.aspx.cs" Inherits="MakeMeUpzzFrontEnd.View.Makeup.InsertMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="ManageMakeup.aspx"><< Back</a>

    <div class="inputRow">
        <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="nameErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="priceLbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="priceErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="weightLbl" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="weightTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="weightErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="typeLbl" runat="server" Text="Type"></asp:Label>'
        <asp:DropDownList ID="typeDdl" runat="server"></asp:DropDownList>
    </div>
    <div class="inputRow">
        <asp:Label ID="brandLbl" runat="server" Text="Brand"></asp:Label>'
        <asp:DropDownList ID="brandDdl" runat="server"></asp:DropDownList>
    </div>
    <div class="inputRow">
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
    </div>
</asp:Content>
