using MakeMeUpzz.Controller;
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
        private MakeupController makeupController;
        private CartController cartController;
        protected void Page_Load(object sender, EventArgs e)
        {
            makeupController = new MakeupController();
            cartController = new CartController();

            //TODO check if user is customer

            if (IsPostBack) { return; }

            makeupController.LoadMakeups(MakeupGV);
        }

        protected void MakeupGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                string username = Session["username"].ToString();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = MakeupGV.Rows[index];
                HiddenField makeupIDHiddenField = (HiddenField)row.FindControl("MakeupIDHiddenField");
                int makeupID = int.Parse(makeupIDHiddenField.Value);

                TextBox qtyTxt = (TextBox)row.FindControl("QtyTxt");
                string quantityStr = qtyTxt.Text;

                cartController.AddToCart(username, makeupID, quantityStr, OrderLbl);

                qtyTxt.Text = string.Empty;
            }
        }
    }
}