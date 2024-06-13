using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MakeMeUpzz.Controller
{
    public class TransactionController
    {
        public List<TransactionHeader> GetTransactions(HttpSessionState session)
        {
            string username = session["username"].ToString();

            User user = UserHandler.GetUser(username);

            List<TransactionHeader> transactions = null;

            if (user.UserRole.Equals("admin"))
            {
                transactions = TransactionHandler.GetTransactions();
            }
            else
            {
                transactions = TransactionHandler.GetUserTransactions(user.UserID);
            }

            return transactions;
        }

        public TransactionHeader GetTransaction(HttpRequest request, HttpResponse response)
        {
            string idStr  = request.QueryString["ID"];
            int id = UtilConvert.ToInt(idStr);

            TransactionHeader tran = TransactionHandler.GetTransaction(id);

            CheckTran(response, tran, id);

            return tran;
        }

        public void CheckTran(HttpResponse response, TransactionHeader tran, int id)
        {
            if (id == -1 || tran == null)
            {
                response.Redirect("~/View/Transaction/TransactionList.aspx");
            }
        }
    }
}