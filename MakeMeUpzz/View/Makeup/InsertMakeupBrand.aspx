<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrand.aspx.cs" Inherits="MakeMeUpzz.View.Makeup.InsertMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Insert Makeup Brand</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Makeup Brand</h1>

    <a href="ManageMakeup.aspx"><< Back</a>

    <div class="inputRow">
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="NameErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Label ID="RatingLbl" runat="server" Text="Rating"></asp:Label>
        <asp:TextBox ID="RatingTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="RatingErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
