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
            db.SaveChanges(); // TODO ERROR DI SINI PAS MAU CHECKOUT
        }
    }
}