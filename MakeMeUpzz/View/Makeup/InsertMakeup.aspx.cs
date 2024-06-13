using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Makeup
{
    public partial class InsertMakeup : System.Web.UI.Page
    {
        MakeupController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            controller.CheckAdmin(Response, Session);

            if (IsPostBack) { return; }

            controller.LoadMakeupDDL(TypeDdl, BrandDdl);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string name = NameTxt.Text;
            string priceStr = PriceTxt.Text;
            string weightStr = WeightTxt.Text;
            string typeName = TypeDdl.SelectedValue;
            string brandName = BrandDdl.SelectedValue;

            controller.InsertMakeup(name, priceStr, weightStr, typeName, brandName, NameErrorLbl, PriceErrorLbl, WeightErrorLbl, Response);
        }
    }
}