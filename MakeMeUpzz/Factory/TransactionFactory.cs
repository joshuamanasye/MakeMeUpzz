using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateHeader(int transactionId, int userId, DateTime transactionDate, string status)
        {
            TransactionHeader newTransactionHeader = new TransactionHeader()
            {
                TransactionID = transactionId,
                UserID = userId,
                TransactionDate = transactionDate,
                Status = status
            };

            return newTransactionHeader;
        }

        public static TransactionDetail CreateDetail(int transactionId, int makeupId, int quantity)
        {
            TransactionDetail newTransactionDetail = new TransactionDetail()
            {
                TransactionID = transactionId,
                MakeupID = makeupId,
                Quantity = quantity
            };

            return newTransactionDetail;
        }
    }
}