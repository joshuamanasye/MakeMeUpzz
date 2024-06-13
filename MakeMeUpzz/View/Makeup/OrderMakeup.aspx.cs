using MakeMeUpzz.Controller;
using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

            makeupController.CheckCustomer(Response, Session);

            if (IsPostBack) { return; }

            makeupController.LoadMakeupsToGV(MakeupGV);

            // Hanya untuk mempermudah, tidak ada di soal
            cartController.LoadCarts(CartGV, Session["username"].ToString());
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

                cartController.LoadCarts(CartGV, Session["username"].ToString()); // Hanya untuk mempermudah, tidak ada di soal
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();

            cartController.ClearCart(username);

            cartController.LoadCarts(CartGV, Session["username"].ToString()); // Hanya untuk mempermudah, tidak ada di soal
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();

            cartController.CheckOut(username);

            cartController.LoadCarts(CartGV, Session["username"].ToString()); // Hanya untuk mempermudah, tidak ada di soal
        }
    }
}