using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class Web : System.Web.UI.MasterPage
    {
        MasterController masterController;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.masterController = new MasterController();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            masterController.DoLogout(Context);
        }
    }
}