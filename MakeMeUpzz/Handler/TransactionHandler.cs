using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class TransactionHandler
    {
        public static void AddTransaction(string username)
        {
            User user = UserHandler.GetUser(username);

            List<Cart> carts = CartHandler.GetCartsByUsername(username);

            int newId = TransactionHeaderRepository.GetLastID() + 1;

            TransactionHeader header = TransactionFactory.CreateHeader(newId, user.UserID, DateTime.Now, "unhandled");
            TransactionHeaderRepository.AddTransactionHeader(header);
            
            foreach (Cart cart in carts)
            {
                TransactionDetail detail = TransactionFactory.CreateDetail(newId, cart.MakeupID, cart.Quantity);

                TransactionDetailRepository.AddTransactionDetail(detail);
            }
        }

        // TODO get transaction

        public static void HandleTransaction(TransactionHeader header)
        {
            TransactionHeaderRepository.HandleTransaction(header);
        }
    }
}