using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class CartHandler
    {
        public static void AddToCart(string username, int makeupId, int quantity)
        {
            User user = UserHandler.GetUser(username);

            int newId = CartRepository.GetLastID() + 1;

            Cart newCart = CartFactory.CreateCart(newId, user.UserID, makeupId, quantity);

            CartRepository.AddCart(newCart);
        }
    }
}