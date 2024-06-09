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
        UserController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new UserController();
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderRB.SelectedValue;
            DateTime dob = DobCalendar.SelectedDate;
            string password = PasswordTxt.Text;
            string passwordConfirm = PasswordConfirmTxt.Text;

            controller.DoRegister(username, email, gender, dob,
                password, passwordConfirm, UsernameErrorLbl, EmailErrorLbl,
                GenderErrorLbl, DobErrorLbl, PasswordErrorLbl, PasswordConfirmErrorLbl,
                Response);
        }
    }
}