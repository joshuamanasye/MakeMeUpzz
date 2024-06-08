<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
	<link rel="icon" href="~/assets/logo.png" />
    <link href="CSS/loginRegister.css" rel="stylesheet" />
</head>
<body>
    <div class="formContainer">
        <form id="LoginForm" runat="server">
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
                <asp:Label CssClass="formLbl"  ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox CssClass="formTxt" ID="PasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label CssClass="formErrorLbl" ID="PasswordErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <div class="inputRow">
                <asp:CheckBox CssClass="formChk" ID="RememberChk" runat="server" Text="Remember me" />
            </div>
            
            <div class="inputRow">
                <asp:Label CssClass="formErrorLbl" ID="LoginErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <asp:Button CssClass="formButton" ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
        </form>

        <p>Don't have an account? <a href="Register.aspx">Register</a></p>
    </div>
</body>
</html>
