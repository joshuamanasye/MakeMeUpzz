using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class UserHandler
    {
        public static bool Authenticate(string username, string password)
        {
            User user = UserRepository.GetUser(username);

            if (user == null || !password.Equals(user.UserPassword))
            {
                return false;
            }

            return true;
        }

        public static User GetUser(string username)
        {
            return UserRepository.GetUser(username);
        }

        public static void AddCustomer(string username, string email, string gender, DateTime dob, string password)
        {
            int newID = UserRepository.GetLastID() + 1;

            User newCustomer = UserFactory.CreateUser(newID, username, email, gender, dob, password, "customer");

            UserRepository.AddUser(newCustomer);
        }
    }
}