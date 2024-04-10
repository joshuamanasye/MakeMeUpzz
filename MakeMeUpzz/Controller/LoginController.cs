using MakeMeUpzz.Handler;
using System.Web;
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
        private bool checkUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;

            return true;
        }

        private bool checkPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            return true;
        }
        public void doLogin(string username, string password, Label usernameErrorLbl, Label passwordErrorLbl, Label loginErrorLbl, HttpResponse response)
        {
            if (!checkUsername(username)) { usernameErrorLbl.Text = "Username cannot be empty"; return; } else { usernameErrorLbl.Text = string.Empty; }

            if (!checkPassword(password)) { passwordErrorLbl.Text = "Password cannot be empty"; return; } else { passwordErrorLbl.Text = string.Empty; }

            bool loggedIn = userHandler.doLogin(username, password);
            if (!loggedIn) { loginErrorLbl.Text = "Username or password is incorrect."; return; }

            HttpCookie cookie = new HttpCookie("username", username);
            response.Cookies.Add(cookie);

            response.Redirect("Home.aspx");
        }
    }
}