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
        UserHandler userHandler;
        public LoginController()
        {
            this.userHandler = new UserHandler();
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

            User user = userHandler.GetUser(username);

            if (user == null) { return; }

            RedirecttoHome(currentPage.Response, currentPage.Session, username);
        }
        private bool CheckUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;

            return true;
        }

        private bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            return true;
        }
        public void DoLogin(string username, string password, bool remember, Label usernameErrorLbl, Label passwordErrorLbl, Label loginErrorLbl, HttpResponse response, HttpSessionState session)
        {
            if (!CheckUsername(username)) { usernameErrorLbl.Text = "Username cannot be empty"; return; } else { usernameErrorLbl.Text = string.Empty; }

            if (!CheckPassword(password)) { passwordErrorLbl.Text = "Password cannot be empty"; return; } else { passwordErrorLbl.Text = string.Empty; }

            bool isAuthenticated = userHandler.Authenticate(username, password);
            if (!isAuthenticated) { loginErrorLbl.Text = "Username or password is incorrect."; return; }

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("username", username);
                cookie.Expires = DateTime.Now.AddMinutes(2);
                response.Cookies.Add(cookie);
            }

            RedirecttoHome(response, session, username);
        }
    }
}