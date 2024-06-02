using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private static DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<User> GetUsers()
        {
            return (from User in db.Users select User).ToList();
        }

        public static User GetUser(string username)
        {
            return (from User in db.Users where User.Username.Equals(username) select User).FirstOrDefault();
        }

        public static void AddUser(User user)
        {
            if (user == null) { return; }

            db.Users.Add(user);
            db.SaveChanges();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from u in db.Users select u.UserID).ToList().LastOrDefault());

            return id;
        }
    }
}