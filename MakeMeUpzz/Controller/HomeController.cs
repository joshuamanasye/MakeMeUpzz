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
        public HomeController()
        {

        }

        public void LoadUser(HttpResponse response, HttpSessionState session, HttpCookie cookie, Label usernameLbl)
        {
            if (session["username"] == null && cookie == null) { response.Redirect("Login.aspx"); }
            else if (session["username"] == null)
            {
                string username = cookie.Value;
                session["username"] = username;
            }

            usernameLbl.Text = session["username"].ToString();
        }
    }
}