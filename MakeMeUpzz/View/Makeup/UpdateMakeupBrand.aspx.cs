using MakeMeUpzz.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Makeup
{
    public partial class UpdateMakeupBrand : System.Web.UI.Page
    {
        MakeupController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new MakeupController();

            controller.CheckAdmin(Response, Session);

            if (IsPostBack) { return; }

            int id = controller.RequestID(Request, Response);

            controller.LoadMakeupBrandDataToForm(id, NameTxt, RatingTxt);
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            string name = NameTxt.Text;
            string rating = RatingTxt.Text;

            controller.UpdateMakeupBrand(id, name, rating, NameErrorLbl, RatingErrorLbl, Response);
        }
    }
}