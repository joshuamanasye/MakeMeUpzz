using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class TransactionDetailRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<TransactionDetail> GetTansactionDetailsByID(int transactionId)
        {
            List<TransactionDetail> transactionDetails = (from td
                                                          in db.TransactionDetails
                                                          where td.TransactionID == transactionId
                                                          select td).ToList();

            return transactionDetails;
        }

        public static void AddTransactionDetail(TransactionDetail detail)
        {
            if (detail == null) { return; }

            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        public static bool ExistingTransaction(Makeup makeup)
        {
            TransactionDetail existing = (from td
                                          in db.TransactionDetails
                                          where td.MakeupID == makeup.MakeupID
                                          select td).ToList().FirstOrDefault();
            if (existing != null) { return true; }

            return false;
        }
    }
}