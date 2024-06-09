using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace MakeMeUpzz.Controller
{
    public class MasterController
    {
        public void LoadUser(HttpResponse response, HttpSessionState session, HttpCookie cookie)
        {
            if (session["username"] == null && cookie == null) { response.Redirect("Login.aspx"); }
            else if (session["username"] == null)
            {
                string username = cookie.Value;
                session["username"] = username;
            }
        }

        public void NavVisibility(Control custNav, Control adminNav, HttpSessionState session)
        {
            string username = session["username"].ToString();

            User user = UserHandler.GetUser(username);
            string userRole = user.UserRole;

            if (userRole.Equals("admin"))
            {
                custNav.Visible = false;
                adminNav.Visible = true;
            }
            else
            {
                custNav.Visible = true;
                adminNav.Visible = false;
            }
        }
        public void DoLogout(HttpContext context)
        {
            context.Session.Clear();
            context.Session.Abandon();

            context.Session["username"] = null;

            string[] cookies = context.Request.Cookies.AllKeys;
            
            foreach (string cookie in cookies)
            {
                context.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            context.Response.Redirect("~/View/Login.aspx");
        }
    }
}