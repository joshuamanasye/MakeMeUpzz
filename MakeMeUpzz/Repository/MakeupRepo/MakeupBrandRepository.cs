﻿using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository.MakeupRepo
{
    public class MakeupBrandRepository
    {
        private static readonly DBMakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<MakeupBrand> GetMakeupBrands()
        {
            List<MakeupBrand> brands = (from b
                                        in db.MakeupBrands
                                        orderby b.MakeupBrandRating
                                        descending
                                        select b).ToList();

            return brands;
        }

        public static MakeupBrand GetMakeupBrandByID(int id)
        {
            return (from b
                    in db.MakeupBrands
                    where b.MakeupBrandID == id
                    select b).FirstOrDefault();
        }

        public static MakeupBrand GetMakeupBrandByName(string name)
        {
            return (from b
                    in db.MakeupBrands
                    where b.MakeupBrandName.Equals(name)
                    select b).FirstOrDefault();
        }

        public static void AddMakeupBrand(MakeupBrand brand)
        {
            db.MakeupBrands.Add(brand);
            db.SaveChanges();
        }

        public static void UpdateMakeupBrand(MakeupBrand brand, string name, int rating)
        {
            brand.MakeupBrandName = name;
            brand.MakeupBrandRating = rating;
            db.SaveChanges();
        }

        public static void DeleteMakeupBrand(MakeupBrand brand)
        {
            if (brand == null) { return; }

            if (MakeupRepository.ExistingMakeup(brand)) { return; } //handle kalo gk bisa didelete

            try
            {
                db.MakeupBrands.Remove(brand);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to delete makeup brand.", ex);
            }
        }

        public static int GetLastID()
        {
            int id = Convert.ToInt32((from mb in db.MakeupBrands select mb.MakeupBrandID).ToList().LastOrDefault());

            return id;
        }
    }
}