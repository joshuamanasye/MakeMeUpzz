using MakeMeUpzz.Handler;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controllers
{
    public class ManageMakeupController
    {
        MakeUpHandler makeupHandler;

        public ManageMakeupController()
        {
            makeupHandler = new MakeUpHandler();
        }

        public void LoadMakeups(GridView gv)
        {
            gv.DataSource = makeupHandler.GetMakeups();

            gv.DataBind();
        }
    }
}