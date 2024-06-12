<%@ Page Title="" Language="C#" MasterPageFile="~/View/Web.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MakeMeUpzz.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="inputRow">
            <asp:Label CssClass="formLbl" ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox CssClass="formTxt" ID="UsernameTxt" runat="server"></asp:TextBox>
            <asp:Label CssClass="formErrorLbl" ID="UsernameErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <div class="inputRow">
            <asp:Label CssClass="formLbl"  ID="EmailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox CssClass="formTxt" ID="EmailTxt" runat="server"></asp:TextBox>
            <asp:Label CssClass="formErrorLbl" ID="EmailErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <div class="inputRow">
            <asp:Label CssClass="formLbl"  ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRB" runat="server" CssClass="rBList">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label CssClass="formErrorLbl" ID="GenderErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <div class="inputRow">
            <asp:Label CssClass="formLbl"  ID="DobLbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar CssClass="formCalendar" ID="DobCalendar" runat="server"></asp:Calendar>
            <asp:Label CssClass="formErrorLbl" ID="DobErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <asp:Button ID="UpdateBtn" runat="server" Text="Update Profile" OnClick="UpdateBtn_Click" />
    </div>
    
    <div>
        <div class="inputRow">
            <asp:Label CssClass="formLbl"  ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox CssClass="formTxt" ID="OldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label CssClass="formErrorLbl" ID="OldPasswordErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <div class="inputRow">
            <asp:Label CssClass="formLbl"  ID="NewPasswordConfirmLbl" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox CssClass="formTxt" ID="NewPasswordConfirmTxt" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label CssClass="formErrorLbl" ID="NewPasswordConfirmErrorLbl" runat="server" Text=""></asp:Label>
        </div>

        <asp:Button CssClass="formButton" ID="UpdatePasswordBtn" runat="server" Text="Update Password" OnClick="UpdatePasswordBtn_Click" />
    </div>

</asp:Content>
