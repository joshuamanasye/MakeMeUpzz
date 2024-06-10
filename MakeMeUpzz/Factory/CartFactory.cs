using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int cartId, int userId, int makeupId, int quantity)
        {
            Cart newCart = new Cart()
            {
                CartID = cartId,
                UserID = userId,
                MakeupID = makeupId,
                Quantity = quantity
            };

            return newCart;
        }
    }
}