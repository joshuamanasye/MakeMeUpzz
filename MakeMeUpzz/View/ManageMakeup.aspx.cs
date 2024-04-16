using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class ManageMakeup : System.Web.UI.Page
    {
        private ManageMakeupController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new ManageMakeupController();

            if (IsPostBack) { return; }

            controller.LoadMakeups(makeupGV);
        }

        protected void makeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void makeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}