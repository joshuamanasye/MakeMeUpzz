using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Web : System.Web.UI.MasterPage
    {
        MasterController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.controller = new MasterController();

            controller.LoadUser(Response, Session, Request.Cookies["username"]);
            controller.NavVisibility(CustNav, AdminNav, Session);
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            controller.DoLogout(Context);
        }
    }
}