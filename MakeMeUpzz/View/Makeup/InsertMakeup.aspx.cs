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
            this.controller = new MakeupController();

            if (IsPostBack) { return; }

            controller.LoadMakeupDDL(typeDdl, brandDdl);
        }

        protected void isnertBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string price = priceTxt.Text;
            string weight = weightTxt.Text;
            string typeName = typeDdl.SelectedValue;
            string brandName = brandDdl.SelectedValue;


        }
    }
}