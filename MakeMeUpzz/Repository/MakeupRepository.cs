using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MakeMeUpzz.Repository
{
    public class MakeupRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<Makeup> GetMakeups()
        {
            List<Makeup> makeups = (from m in db.Makeups select m).ToList();

            return makeups;
        }

        public static Makeup GetMakeupById(int id)
        {
            Makeup makeup = (from m in db.Makeups where m.MakeupID == id select m).FirstOrDefault();

            return makeup;
        }

        public static void AddMakeup(Makeup makeup)
        {
            if (makeup == null) { return; }

            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public static void UpdateMakeup(Makeup makeup, string name, int price, int weight, int typeId, int brandId)
        {
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupTypeID = typeId;
            makeup.MakeupBrandID = brandId;

            db.SaveChanges();
        }

        public static void DeleteMakeup(Makeup makeup)
        {
            if (makeup == null) { return; }
            
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }

        public static List<MakeupType> GetMakeupTypes()
        {
            List<MakeupType> types = (from t in db.MakeupTypes select t).ToList();

            return types;
        }

        public static List<MakeupBrand> GetMakeupBrands()
        {
            List<MakeupBrand> brands = (from b in db.MakeupBrands select b).ToList();

            return brands;
        }

        public static int GetMakeupTypeIDByName(string name)
        {
            return (from t
                    in db.MakeupTypes
                    where t.MakeupTypeName.Equals(name)
                    select t.MakeupTypeID).FirstOrDefault();
        }

        public static int GetMakeupBrandIDByName(string name)
        {
            return (from b
                    in db.MakeupBrands
                    where b.MakeupBrandName.Equals(name)
                    select b.MakeupBrandID).FirstOrDefault();
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from m in db.Makeups select m.MakeupID).ToList().LastOrDefault());

            return id;
        }
    }
}