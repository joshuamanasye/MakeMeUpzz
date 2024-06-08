using MakeMeUpzzFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzzFrontEnd.View
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.controller = new LoginController();

            controller.CheckCookie(this);
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            bool remember = rememberChk.Checked;

            controller.DoLogin(username, password, remember, usernameErrorLbl, passwordErrorLbl, loginErrorLbl, Response, Session);
        }
    }
}