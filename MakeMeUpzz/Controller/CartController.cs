using MakeMeUpzz.Handler;
using MakeMeUpzz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controller
{
    public class CartController
    {
        public void AddToCart(string username, int makeupId, string quantityStr, Label orderLbl)
        {
            int quantity = UtilConvert.ToInt(quantityStr);

            if (quantity <= 0)
            {
                orderLbl.ForeColor = System.Drawing.Color.Red;
                orderLbl.Text = "Quantity must be bigger than 0";
                return;
            }

            CartHandler.AddToCart(username, makeupId, quantity);

            orderLbl.ForeColor = System.Drawing.Color.Green;
            orderLbl.Text = "Added to cart";
        }
    }
}