using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            Makeup makeup = (from m in db.Makeups where m.MakeupID.Equals(id) select m).FirstOrDefault();

            return makeup;
        }
    }
}