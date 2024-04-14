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
        UserRepository userRepository;
        public UserHandler()
        {
            this.userRepository = new UserRepository();
        }
        public bool Authenticate(string username, string password)
        {
            User user = userRepository.GetUser(username);

            if (user == null || !password.Equals(user.UserPassword))
            {
                return false;
            }

            return true;
        }

        public User GetUser(string username)
        {
            return userRepository.GetUser(username);
        }

        public void AddCustomer(string username, string email, string gender, DateTime dob, string password)
        {
            UserFactory userFactory = new UserFactory();

            int newID = userRepository.GenerateID();

            User newCustomer = userFactory.CreateUser(newID, username, email, gender, dob, password, "customer");

            userRepository.AddUser(newCustomer);
        }
    }
}