using MakeMeUpzzFrontEnd.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzzFrontEnd.View.Makeup
{
    public partial class ManageMakeup : System.Web.UI.Page
    {
        private MakeupController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            //cek admin bkn, kalo bkn return

            if (IsPostBack) { return; }

            controller.LoadMakeups(MakeupGV);
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            controller.DeleteMakeup(MakeupGV, e);
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}