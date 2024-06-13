using MakeMeUpzz.Controller;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Transaction
{
    public partial class HandleTransaction : System.Web.UI.Page
    {
        TransactionController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new TransactionController();

            controller.CheckAdmin(Response, Session);

            if (IsPostBack) { return; }

            controller.LoadHandleTransaction(UnhandledGV, HandledGV);
        }

        protected void UnhandledGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Handle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = UnhandledGV.Rows[index];
                int id = Convert.ToInt32(row.Cells[0].Text);

                controller.HandleTransaction(id);

                controller.LoadHandleTransaction(UnhandledGV, HandledGV);
            }
        }
    }
}