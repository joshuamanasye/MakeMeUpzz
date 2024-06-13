using MakeMeUpzz.Controller;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View.Transaction
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        private TransactionController controller;
        
        public TransactionHeader tran = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new TransactionController();

            tran = controller.GetTransaction(Request, Response);
        }
    }
}