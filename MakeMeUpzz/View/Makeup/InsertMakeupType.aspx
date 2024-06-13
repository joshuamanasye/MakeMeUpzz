<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="InsertMakeupType.aspx.cs" Inherits="MakeMeUpzz.View.Makeup.InsertMakeupType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Insert Makeup Type</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Makeup Type</h1>

    <a href="ManageMakeup.aspx"><< Back</a>

    <div class="inputRow">
        <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <asp:Label CssClass="formErrorLbl" ID="NameErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="inputRow">
        <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
