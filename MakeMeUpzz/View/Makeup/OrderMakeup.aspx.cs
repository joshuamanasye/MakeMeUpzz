using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Makeup
{
    public partial class OrderMakeup : System.Web.UI.Page
    {
        private MakeupController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            //TODO check if user is customer

            if (IsPostBack) { return; }

            controller.LoadMakeups(MakeupGV);
        }

        protected void MakeupGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = MakeupGV.Rows[index];

                HiddenField makeupIDHiddenField = (HiddenField)row.FindControl("MakeupIDHiddenField");
                int makeupID = int.Parse(makeupIDHiddenField.Value);

                TextBox qtyTxt = (TextBox)row.FindControl("QtyTxt");
                int quantity = int.Parse(qtyTxt.Text);


            }
        }
    }
}