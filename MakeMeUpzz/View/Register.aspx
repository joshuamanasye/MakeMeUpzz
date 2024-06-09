<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeMeUpzz.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
	<link rel="icon" href="~/assets/logo.png" />
    <link href="CSS/loginRegister.css" rel="stylesheet" />
</head>
<body>
    <div class="formContainer">
        <form id="RegisterForm" runat="server">
            <div class="logoContainer">
                <%-- edited from https://www.freepik.com/icon/makeup_5964540#fromView=search&page=1&position=0&uuid=c4810840-47e3-4fc9-bc5c-3975c254b245 --%>
                <asp:Image ID="FormImg" CssClass="formLogo" runat="server" ImageUrl="~/assets/logo.png" AlternateText="logo" />
                <h1>MakeMeUpzz</h1>
            </div>

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

            <div class="inputRow">
                <asp:Label CssClass="formLbl"  ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox CssClass="formTxt" ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label CssClass="formErrorLbl" ID="PasswordErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <div class="inputRow">
                <asp:Label CssClass="formLbl"  ID="PasswordConfirmLbl" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox CssClass="formTxt" ID="PasswordConfirmTxt" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label CssClass="formErrorLbl" ID="PasswordConfirmErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <asp:Button CssClass="formButton" ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        </form>
        
        <p>Already have an account? <a href="Login.aspx">Login</a></p>
    </div>
</body>
</html>
