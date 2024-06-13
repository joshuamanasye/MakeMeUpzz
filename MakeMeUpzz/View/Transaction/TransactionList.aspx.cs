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
    public partial class TransactionList : System.Web.UI.Page
    {
        private TransactionController controller;

        public List<TransactionHeader> transactionHeaders = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            controller = new TransactionController();

            transactionHeaders = controller.GetTransactions(Session);
        }
    }
}