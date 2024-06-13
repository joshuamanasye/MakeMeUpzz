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
        public static List<Cart> GetCartsByUsername(string username)
        {
            User user = UserRepository.GetUser(username);
            List<Cart> carts = CartRepository.GetCartsByUserID(user.UserID);

            return carts;
        }

        public static void AddToCart(string username, int makeupId, int quantity)
        {
            User user = UserHandler.GetUser(username);

            Cart cart = CartRepository.GetCart(user.UserID, makeupId);

            if (cart != null)
            {
                CartRepository.UpdateCart(cart, cart.Quantity + quantity);
            }
            else
            {
                int newId = CartRepository.GetLastID() + 1;

                Cart newCart = CartFactory.CreateCart(newId, user.UserID, makeupId, quantity);

                CartRepository.AddCart(newCart);
            }
        }

        public static void ClearCartByUsername(string username)
        {
            List<Cart> toDelete = GetCartsByUsername(username);

            CartRepository.DeleteCarts(toDelete);
        }
    }
}