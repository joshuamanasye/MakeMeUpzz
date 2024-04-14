using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MakeMeUpzz.Controller
{
    public class MasterController
    {
        public MasterController() { }

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