using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

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

        public void LoadUnhandled(GridView gv)
        {
            List<TransactionHeader> unhandled = TransactionHandler.GetTransactionsByStatus(false);

            gv.DataSource = unhandled;
            gv.DataBind();
        }

        public void LoadHandled(GridView gv)
        {
            List<TransactionHeader> handled = TransactionHandler.GetTransactionsByStatus(true);

            gv.DataSource = handled;
            gv.DataBind();
        }

        public void LoadHandleTransaction(GridView unhandledGv, GridView handledGv)
        {
            LoadUnhandled(unhandledGv);
            LoadHandled(handledGv);
        }

        public void HandleTransaction(int id)
        {
            TransactionHeader toHandle = TransactionHandler.GetTransaction(id);

            TransactionHandler.HandleTransaction(toHandle);
        }

        public void CheckTran(HttpResponse response, TransactionHeader tran, int id)
        {
            if (id == -1 || tran == null)
            {
                response.Redirect("~/View/Transaction/TransactionList.aspx");
            }
        }

        public void CheckAdmin(HttpResponse response, HttpSessionState session)
        {
            string username = session["username"].ToString();
            User user = UserHandler.GetUser(username);

            if (!user.UserRole.Equals("admin"))
            {
                response.Redirect("~/View/Home.aspx");
            }
        }
    }
}