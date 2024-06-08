using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controller
{
    public class LoginController
    {
        public LoginController()
        {
            
        }

        private void RedirecttoHome(HttpResponse response, HttpSessionState session, string username)
        {
            session["username"] = username;

            response.Redirect("Home.aspx");
        }

        public void CheckCookie(Page currentPage)
        {
            HttpCookie cookie = currentPage.Request.Cookies["username"];

            if (cookie == null) { return; }

            string username = cookie.Value;

            User user = UserHandler.GetUser(username);

            if (user == null) { return; }

            RedirecttoHome(currentPage.Response, currentPage.Session, username);
        }
        private bool CheckUsername(string username, Label usernameErrorLbl)
        {
            if (string.IsNullOrEmpty(username))
            {
                usernameErrorLbl.Text = "Username cannot be empty";
                return false;
            }

            usernameErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckPassword(string password, Label passwordErrorLbl)
        {
            if (string.IsNullOrEmpty(password))
            {
                passwordErrorLbl.Text = "Password cannot be empty";
                return false;
            }

            passwordErrorLbl.Text = string.Empty;
            return true;
        }
        public void DoLogin(string username, string password, bool remember, Label usernameErrorLbl, Label passwordErrorLbl, Label loginErrorLbl, HttpResponse response, HttpSessionState session)
        {
            bool validInput = true;

            if (!CheckUsername(username, usernameErrorLbl)) { validInput = false; }
            if (!CheckPassword(password, passwordErrorLbl)) { validInput = false; }

            bool isAuthenticated = UserHandler.Authenticate(username, password);
            if (!isAuthenticated) { loginErrorLbl.Text = "Username or password is incorrect."; validInput = false; }

            if (!validInput) { return; }

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("username", username)
                {
                    Expires = DateTime.Now.AddMinutes(2)
                };
                response.Cookies.Add(cookie);
            }

            RedirecttoHome(response, session, username);
        }
    }
}