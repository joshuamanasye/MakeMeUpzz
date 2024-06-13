using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MakeMeUpzz.Repository.MakeupRepo
{
    public class MakeupTypeRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<MakeupType> GetMakeupTypes()
        {
            List<MakeupType> types = (from t in db.MakeupTypes select t).ToList();

            return types;
        }

        public static MakeupType GetMakeupTypeByID(int id)
        {
            return (from t
            in db.MakeupTypes
                    where t.MakeupTypeID == id
                    select t).FirstOrDefault();
        }

        public static MakeupType GetMakeupTypeByName(string name)
        {
            return (from t
                    in db.MakeupTypes
                    where t.MakeupTypeName.Equals(name)
                    select t).FirstOrDefault();
        }

        public static void AddMakeupType(MakeupType type)
        {
            db.MakeupTypes.Add(type);
            db.SaveChanges();
        }

        public static void UpdateMakeupType(MakeupType type, string name)
        {
            type.MakeupTypeName = name;
            db.SaveChanges();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from mt in db.MakeupTypes select mt.MakeupTypeID).ToList().LastOrDefault());

            return id;
        }
    }
}