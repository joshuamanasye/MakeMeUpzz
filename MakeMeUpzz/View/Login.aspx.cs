using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Login : System.Web.UI.Page
    {
        private UserController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.controller = new UserController();

            controller.CheckCookie(this);
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
            bool remember = RememberChk.Checked;

            controller.DoLogin(username, password, remember, UsernameErrorLbl, PasswordErrorLbl, LoginErrorLbl, Response, Session);
        }
    }
}