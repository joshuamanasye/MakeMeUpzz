using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Register : System.Web.UI.Page
    {
        RegisterController registerController;

        protected void Page_Load(object sender, EventArgs e)
        {
            registerController = new RegisterController();
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string gender = genderRB.SelectedValue;
            DateTime dob = dobCalendar.SelectedDate;
            string password = passwordTxt.Text;
            string passwordConfirm = passwordConfirmTxt.Text;

            registerController.DoRegister(username, email, gender, dob,
                password, passwordConfirm, usernameErrorLbl, emailErrorLbl,
                genderErrorLbl, dobErrorLbl, passwordErrorLbl, passwordConfirmErrorLbl,
                Response);
        }
    }
}