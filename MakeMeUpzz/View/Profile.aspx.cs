using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Profile : System.Web.UI.Page
    {
        UserController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new UserController();
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderRB.SelectedValue;
            DateTime dob = DobCalendar.SelectedDate;
        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {

        }
    }
}