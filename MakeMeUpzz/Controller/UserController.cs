using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controller
{
    public class UserController
    {
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
        private bool CheckUsernameLogin(string username, Label usernameErrorLbl)
        {
            if (string.IsNullOrEmpty(username))
            {
                usernameErrorLbl.Text = "Username cannot be empty";
                return false;
            }

            usernameErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckPasswordLogin(string password, Label passwordErrorLbl)
        {
            if (string.IsNullOrEmpty(password))
            {
                passwordErrorLbl.Text = "Password cannot be empty";
                return false;
            }

            passwordErrorLbl.Text = string.Empty;
            return true;
        }

        private bool Authenticate(string username, string password, Label errorLbl)
        {
            bool isAuthenticated = UserHandler.Authenticate(username, password);
            if (!isAuthenticated)
            {
                errorLbl.Text = "Invalid credential";
                return false;
            }

            errorLbl.Text = string.Empty;
            return true;
        }

        public void DoLogin(string username, string password, bool remember,
            Label usernameErrorLbl, Label passwordErrorLbl, Label loginErrorLbl,
            HttpResponse response, HttpSessionState session)
        {
            bool validInput = true;

            if (!CheckUsernameLogin(username, usernameErrorLbl)) { validInput = false; }
            if (!CheckPasswordLogin(password, passwordErrorLbl)) { validInput = false; }
            if (!Authenticate(username, password, loginErrorLbl)) { validInput = false; }

            if (!validInput) { return; }

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("username", username)
                {
                    Expires = DateTime.Now.AddHours(1)
                };
                response.Cookies.Add(cookie);
            }

            RedirecttoHome(response, session, username);
        }

        private bool CheckUsername(string username, Label usernameErrorLbl)
        {
            if (string.IsNullOrEmpty(username))
            {
                usernameErrorLbl.Text = "Username cannot be empty";
                return false;
            }

            if (username.Length < 5 || username.Length > 15)
            {
                usernameErrorLbl.Text = "Username must be between 5-15 characters";
                return false;
            }

            if (UserHandler.GetUser(username) != null)
            {
                usernameErrorLbl.Text = "Username already exists";
                return false;
            }

            usernameErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckEmail(string email, Label emailErrorLbl)
        {
            if (string.IsNullOrEmpty(email))
            {
                emailErrorLbl.Text = "Email cannot be empty";
                return false;
            }

            if (!email.EndsWith(".com"))
            {
                emailErrorLbl.Text = "Email must ends with '.com'";
                return false ;
            }

            emailErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckGender(string gender, Label genderErrorLbl)
        {
            if (string.IsNullOrEmpty(gender))
            {
                genderErrorLbl.Text = "Please select your gender";
                return false;
            }

            genderErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckDob (DateTime dob, Label dobErrorLbl)
        {
            if (dob > DateTime.Today || dob == DateTime.MinValue)
            {
                dobErrorLbl.Text = "Please select a valid date of birth";
                return false;
            }

            dobErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckPassword(string password, Label passwordErrorLbl)
        {
            if (string.IsNullOrEmpty(password))
            {
                passwordErrorLbl.Text = "Password cannot be empty";
                return false;
            }

            if (!password.All(char.IsLetterOrDigit))
            {
                passwordErrorLbl.Text = "Password must be alphanumeric";
                return false;
            }

            passwordErrorLbl.Text = string.Empty;
            return true;
        }

        private bool CheckPasswordConfirm(string passwordConfirm, string password, Label passwordConfirmErrorLbl)
        {
            if (!passwordConfirm.Equals(password))
            {
                passwordConfirmErrorLbl.Text = "Password does not match";

                return false;
            }

            passwordConfirmErrorLbl.Text = string.Empty;
            return true;
        }

        public void DoRegister(string username, string email, string gender, DateTime dob,
            string password, string passwordConfirm, Label usernameErrorLbl, Label emailErrorLbl,
            Label genderErrorLbl, Label dobErrorLbl, Label passwordErrorLbl, Label passwordConfirmErrorLbl,
            HttpResponse response)
        {
            bool validInput = true;

            if (!CheckUsername(username, usernameErrorLbl)) { validInput = false; }
            if (!CheckEmail(email, emailErrorLbl)) { validInput = false; }
            if (!CheckGender(gender, genderErrorLbl)) { validInput = false; }
            if (!CheckDob(dob, dobErrorLbl)) { validInput = false; }
            if (!CheckPassword(password, passwordErrorLbl)) { validInput = false; }
            if (!CheckPasswordConfirm(passwordConfirm, password, passwordConfirmErrorLbl)) { validInput = false; }

            if (!validInput) { return; }

            UserHandler.AddCustomer(username, email, gender, dob, password);

            response.Redirect("~/View/Login.aspx");
        }

        public void UpdateProfile(HttpSessionState session,
            string username, string email, string gender, DateTime dob,
            Label usernameErrorLbl, Label emailErrorLbl, Label genderErrorLbl, Label dobErrorLbl,
            Label profileUpdateLbl)
        {
            string currenUsername = session["username"].ToString();
            User currenUser = UserHandler.GetUser(currenUsername);
            int userId = currenUser.UserID;

            bool validInput = true;
            if (!CheckUsername(username, usernameErrorLbl)) { validInput = false; }
            if (!CheckEmail(email, emailErrorLbl)) { validInput = false; }
            if (!CheckGender(gender, genderErrorLbl)) { validInput = false; }
            if (!CheckDob(dob, dobErrorLbl)) { validInput = false; }

            if (!validInput) { return; }

            UserHandler.UpdateProfile(userId, username, email, gender, dob);

            profileUpdateLbl.Text = "Profile updated";
        }

        public void UpdatePassword(HttpSessionState session,
            string oldPassword, string newPassword,
            Label oldPasswordErrorLbl, Label newPasswordErrorLbl,
            Label passwordUpdateLbl)
        {
            string username = session["username"].ToString();

            bool validInput = true;

            if (!Authenticate(username, oldPassword, oldPasswordErrorLbl)) { validInput = false; }
            if (!CheckPassword(newPassword, newPasswordErrorLbl)) { validInput = false; }

            if (!validInput) { return; }

            UserHandler.UpdatePassword(username, newPassword);

            passwordUpdateLbl.Text = "Password updated";
        }
    }
    
}