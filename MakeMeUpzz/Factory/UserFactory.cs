using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class UserFactory
    {
        public static User CreateUser(int id, string username, string email, string gender, DateTime dob, string password, string role)
        {
            User newUser = new User
            {
                UserID = id,
                Username = username,
                UserEmail = email,
                UserGender = gender,
                UserDOB = dob,
                UserPassword = password,
                UserRole = role
            };

            return newUser;
        }
    }
}