using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class UserRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<User> GetUsers()
        {
            return (from User in db.Users select User).ToList();
        }

        public static User GetUser(string username)
        {
            return (from User in db.Users where User.Username.Equals(username) select User).FirstOrDefault();
        }

        public static List<User> GetUserByRole(string role)
        {
            return (from User in db.Users where User.UserRole.Equals(role) select User).ToList();
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

        public static void UpdateUser(int userId, string username, string email, string gender, DateTime dob)
        {
            User toUpdate = (from u in db.Users where u.UserID == userId select u).ToList().FirstOrDefault();

            if (toUpdate == null) { return; }

            toUpdate.Username = username;
            toUpdate.UserEmail = email;
            toUpdate.UserGender = gender;
            toUpdate.UserDOB = dob;

            db.SaveChanges();
        }

        public static void UpdatePassword(string username, string password)
        {
            User toUpdate = GetUser(username);

            toUpdate.UserPassword = password;

            db.SaveChanges();
        }
    }
}