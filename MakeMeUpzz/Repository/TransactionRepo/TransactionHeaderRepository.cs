using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class TransactionHeaderRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            List<TransactionHeader> transactionHeaders = (from th in db.TransactionHeaders select th).ToList();

            return transactionHeaders;
        }

        public static List<TransactionHeader> GetUnhandledTransactionHeaders()
        {
            List<TransactionHeader> transactionHeaders = (from th
                                                          in db.TransactionHeaders
                                                          where th.Status.Equals("unhandled")
                                                          select th).ToList();

            return transactionHeaders;
        }

        public static List<TransactionHeader> GetTransactionheadersByUserID(int userId)
        {
            List<TransactionHeader> transactionHeaders = (from th
                                                          in db.TransactionHeaders
                                                          where th.UserID == userId
                                                          select th).ToList();

            return transactionHeaders;
        }

        public static TransactionHeader GetTransactionHeaderById(int id)
        {
            TransactionHeader transactionHeader = (from th
                                                   in db.TransactionHeaders
                                                   where th.TransactionID == id
                                                   select th).ToList().FirstOrDefault();

            return transactionHeader;
        }

        public static void AddTransactionHeader(TransactionHeader header)
        {
            if (header == null) { return; }

            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public static void HandleTransaction(TransactionHeader transactionHeader)
        {
            transactionHeader.Status = "handled";
            db.SaveChanges();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from th
                                      in db.TransactionHeaders
                                      select th.TransactionID).ToList().LastOrDefault());

            return id;
        }
    }
}