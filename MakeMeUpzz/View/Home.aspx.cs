using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Home : System.Web.UI.Page
    {
        private HomeController homeController;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.homeController = new HomeController();

            homeController.LoadUser(Response, Session, Request.Cookies["username"], usernameLbl);
        }
    }
}