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

        public static List<Cart> GetCartsByUsername(string username)
        {
            List<Cart> userCarts = (from c
                                    in db.Carts
                                    where c.User.Username.Equals(username)
                                    select c).ToList();

            return userCarts;
        }

        public static void AddCart(Cart cart)
        {
            if (cart == null) { return; }

            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static void DeleteCarts(List<Cart> toDelete)
        {
            db.Carts.RemoveRange(toDelete);
            db.SaveChanges();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from c in db.Carts select c.CartID).ToList().LastOrDefault());

            return id;
        }
    }
}