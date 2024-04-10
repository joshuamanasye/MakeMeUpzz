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
        public UserHandler() { }
        public bool doLogin(string username, string password)
        {
            User user = UserRepository.getUser(username);

            if (user == null || !password.Equals(user.UserPassword))
            {
                return false;
            }

            return true;
        }
    }
}