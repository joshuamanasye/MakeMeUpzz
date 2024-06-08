<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="InsertMakeup.aspx.cs" Inherits="MakeMeUpzz.View.Makeup.InsertMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="ManageMakeup.aspx"><< Back</a>

    <div class="inputRow">
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="NameErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="PriceErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="WeightLbl" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="WeightTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="WeightErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="TypeLbl" runat="server" Text="Type"></asp:Label>'
        <asp:DropDownList ID="TypeDdl" runat="server"></asp:DropDownList>
    </div>
    <div class="inputRow">
        <asp:Label ID="BrandLbl" runat="server" Text="Brand"></asp:Label>'
        <asp:DropDownList ID="BrandDdl" runat="server"></asp:DropDownList>
    </div>
    <div class="inputRow">
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
    </div>
</asp:Content>
