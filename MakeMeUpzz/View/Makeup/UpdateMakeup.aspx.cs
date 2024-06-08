using MakeMeUpzz.Controllers;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Makeup
{
    public partial class UpdateMakeup : System.Web.UI.Page
    {
        MakeupController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            //TODO check if user is admin

            if (IsPostBack) { return; }

            controller.LoadMakeupDDL(TypeDdl, BrandDdl);

            int id = Convert.ToInt32(Request.QueryString["id"]);

            controller.LoadMakeupDatatoForm(id, NameTxt, PriceTxt, WeightTxt, TypeDdl, BrandDdl);
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string name = NameTxt.Text;
            string priceStr = PriceTxt.Text;
            string weightStr = WeightTxt.Text;
            string typeName = TypeDdl.SelectedValue;
            string brandName = BrandDdl.SelectedValue;

            controller.UpdateMakeup(id, name, priceStr, weightStr, typeName, brandName, NameErrorLbl, PriceErrorLbl, WeightErrorLbl, Response);
        }
    }
}