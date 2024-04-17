using MakeMeUpzz.Controllers;
using MakeMeUpzz.Model;
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
        private MakeupController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            //cek admin bkn, kalo bkn return

            if (IsPostBack) { return; }

            controller.LoadMakeups(makeupGV);
        }

        protected void makeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            controller.DeleteMakeup(makeupGV, e);
        }

        protected void makeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}