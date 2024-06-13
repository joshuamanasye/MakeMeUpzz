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

            controller.CheckAdmin(Response, Session);

            if (IsPostBack) { return; }

            controller.LoadMakeupDataToGV(MakeupGV, MakeupTypeGV, MakeupBrandGV);
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            controller.DeleteMakeup(MakeupGV, e);
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupGV.Rows[e.NewEditIndex].Cells[0].Text);

            controller.RedirectToUpdateMakeup(id, Response);
        }

        protected void MakeupTypeGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupGV.Rows[e.NewEditIndex].Cells[0].Text);

            controller.RedirectToUpdateMakeupType(id, Response);
        }

        protected void MakeupBrandGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupGV.Rows[e.NewEditIndex].Cells[0].Text);

            controller.RedirectToUpdateMakeupBrand(id, Response);
        }
    }
}