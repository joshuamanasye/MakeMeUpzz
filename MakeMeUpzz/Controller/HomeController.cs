using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controller
{
    public class HomeController
    {
        public void LoadHomePageData(HttpSessionState session, Label usernameLbl, Label roleLbl, GridView customerGV)
        {
            if (session["username"] == null) { return; }

            string username = session["username"].ToString();
            User user = UserHandler.GetUser(username);

            usernameLbl.Text = user.Username;
            roleLbl.Text = user.UserRole;

            if (user.UserRole.Equals("admin"))
            {   
                List<User> users = UserHandler.GetUserByRole("customer");

                customerGV.DataSource = users;
                customerGV.DataBind();
            }
            else
            {
                customerGV.Visible = false;
            }
        }
    }
}