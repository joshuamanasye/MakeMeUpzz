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
        private DBMakeMeUpzzEntities db;

        public MakeupRepository()
        {
            db = DatabaseSingleton.GetInstance();
        }

        public List<Makeup> GetMakeups()
        {
            List<Makeup> makeups = (from m in db.Makeups orderby m.MakeupBrand.MakeupBrandRating descending select m).ToList();

            return makeups;
        }

        public Makeup GetMakeupById(int id)
        {
            Makeup makeup = (from m in db.Makeups where m.MakeupID == id select m).FirstOrDefault();

            return makeup;
        }

        public void AddMakeup(Makeup makeup)
        {
            if (makeup == null) { return; }

            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public void DeleteMakeup(Makeup makeup)
        {
            if (makeup == null) { return; }
            
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }

        public List<MakeupType> GetMakeupTypes()
        {
            List<MakeupType> types = (from t in db.MakeupTypes select t).ToList();

            return types;
        }

        public List<MakeupBrand> GetMakeupBrands()
        {
            List<MakeupBrand> brands = (from b in db.MakeupBrands select b).ToList();

            return brands;
        }

        public int GetMakeupTypeIDByName(string name)
        {
            return (from t in db.MakeupTypes where t.MakeupTypeName.Equals(name) select t.MakeupTypeID).FirstOrDefault();
        }

        public int GetMakeupBrandIDByName(string name)
        {
            return (from b in db.MakeupBrands where b.MakeupBrandName.Equals(name) select b.MakeupBrandID).FirstOrDefault();
        }

        public int GetLastID()
        {
            int id = Convert.ToInt32((from m in db.Makeups select m.MakeupID).ToList().LastOrDefault());

            return id;
        }
    }
}