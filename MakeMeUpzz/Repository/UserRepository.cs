using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public List<User> GetUsers()
        {
            return (from User in db.Users select User).ToList();
        }

        public User GetUser(string username)
        {
            return (from User in db.Users where User.Username.Equals(username) select User).FirstOrDefault();
        }
    }
}