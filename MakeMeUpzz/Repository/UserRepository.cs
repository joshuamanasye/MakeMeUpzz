using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private static DBMakeMeUpzzEntities db = DatabaseSingleton.getInstance();

        public static List<User> getUsers()
        {
            return (from User in db.Users select User).ToList();
        }

        public static User getUser(string username)
        {
            return (from User in db.Users where User.Username.Equals(username) select User).FirstOrDefault();
        }
    }
}