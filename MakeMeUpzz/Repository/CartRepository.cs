using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class CartRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetCartsByUserID(int userId)
        {
            List<Cart> userCarts = (from c in db.Carts where c.UserID == userId select c).ToList();

            return userCarts;
        }

        public static void AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void DeleteCartsByUserID(int userID)
        {
            List<Cart> userCarts = GetCartsByUserID(userID);

            db.Carts.RemoveRange(userCarts);
            db.SaveChanges();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from c in db.Carts select c.CartID).ToList().LastOrDefault());

            return id;
        }
    }
}