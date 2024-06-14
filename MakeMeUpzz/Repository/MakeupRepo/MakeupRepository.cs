using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MakeMeUpzz.Repository.MakeupRepo
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

        public static bool ExistingMakeup(MakeupType type)
        {
            Makeup existing = (from m in db.Makeups where m.MakeupTypeID == type.MakeupTypeID select m).ToList().FirstOrDefault();
            if (existing != null) { return true; } //handle kalo gk bisa didelete

            return false;
        }

        public static bool ExistingMakeup(MakeupBrand brand)
        {
            Makeup existing = (from m in db.Makeups where m.MakeupBrandID == brand.MakeupBrandID select m).ToList().FirstOrDefault();
            if (existing != null) { return true; } //handle kalo gk bisa didelete

            return false;
        }

        public static void DeleteMakeup(Makeup makeup)
        {
            if (makeup == null) { return; }

            if (TransactionDetailRepository.ExistingTransaction(makeup)) { return; }

            try
            {
                db.Makeups.Remove(makeup);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to delete makeup.", ex);
            }
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from m in db.Makeups select m.MakeupID).ToList().LastOrDefault());

            return id;
        }
    }
}