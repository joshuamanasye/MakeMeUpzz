using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class UserFactory
    {
        public UserFactory() { }

        public User CreateUser(int id, string username, string email, string gender, DateTime dob, string password, string role)
        {
            User newUser = new User();

            newUser.UserID = id;
            newUser.Username = username;
            newUser.UserEmail = email;
            newUser.UserGender = gender;
            newUser.UserDOB = dob;
            newUser.UserPassword = password;
            newUser.UserRole = role;

            return newUser;
        }
    }
}