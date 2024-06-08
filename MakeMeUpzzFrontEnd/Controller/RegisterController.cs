using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace MakeMeUpzzFrontEnd.Controller
{
    public class RegisterController
    {
        private UserHandler userHandler;
        public RegisterController()
        {
            this.userHandler = new UserHandler();
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
    }
    
}