using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class DatabaseSingleton
    {
        private static DBMakeMeUpzzEntities db = null;

        public static DBMakeMeUpzzEntities GetInstance()
        {
            if (db == null)
            {
                db = new DBMakeMeUpzzEntities();
            }

            return db;
        }
    }
}