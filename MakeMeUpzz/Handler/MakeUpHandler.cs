using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository.MakeupRepo;
using MakeMeUpzz.View.Makeup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class MakeUpHandler
    {
        public static List<Makeup> GetMakeups()
        {
            return MakeupRepository.GetMakeups();
        }

        public static Makeup GetmakeupByID(int id)
        {
            return MakeupRepository.GetMakeupById(id);
        }

        public static void DeleteMakeupByID(int id)
        {
            Makeup toDelete = MakeupRepository.GetMakeupById(id);

            MakeupRepository.DeleteMakeup(toDelete);
        }

        public static List<MakeupType> GetMakeupTypes()
        {
            return MakeupTypeRepository.GetMakeupTypes();
        }

        public static MakeupType GetMakeupTypeByID(int id)
        {
            return MakeupTypeRepository.GetMakeupTypeByID(id);
        }

        public static List<MakeupBrand> GetMakeupBrands()
        {
            return MakeupBrandRepository.GetMakeupBrands();
        }

        public static MakeupBrand GetMakeupBrandByID(int id)
        {
            return MakeupBrandRepository.GetMakeupBrandByID(id);
        }

        public static List<string> GetMakeupTypeNames()
        {
            List<MakeupType> types = MakeupTypeRepository.GetMakeupTypes();

            List<string> typeNames = new List<string>();

            foreach (MakeupType type in types)
            {
                typeNames.Add(type.MakeupTypeName);
            }

            return typeNames;
        }

        public static List<string> GetMakeupBrandNames()
        {
            List<MakeupBrand> brands = MakeupBrandRepository.GetMakeupBrands();

            List<string> brandNames = new List<string>();

            foreach (MakeupBrand brand in brands)
            {
                brandNames.Add(brand.MakeupBrandName);
            }

            return brandNames;
        }

        public static void AddMakeup(string name, int price, int weight, string typeName, string brandName)
        {
            int newId = MakeupRepository.GetLastID() + 1;

            MakeupType type = MakeupTypeRepository.GetMakeupTypeByName(typeName);
            MakeupBrand brand = MakeupBrandRepository.GetMakeupBrandByName(brandName);

            Makeup newMakeup = MakeupFactory.CreateMakeup(newId, name, price, weight, type.MakeupTypeID, brand.MakeupBrandID);

            MakeupRepository.AddMakeup(newMakeup);
        }

        public static void UpdateMakeupByID(int id, string name, int price, int weight, string typeName, string brandName)
        {
            Makeup toUpdate = MakeupRepository.GetMakeupById(id);

            MakeupType type = MakeupTypeRepository.GetMakeupTypeByName(typeName);
            MakeupBrand brand = MakeupBrandRepository.GetMakeupBrandByName(brandName);

            MakeupRepository.UpdateMakeup(toUpdate, name, price, weight, type.MakeupTypeID, brand.MakeupBrandID);
        }

        public static void AddMakeupType(string name)
        {
            int newId = MakeupTypeRepository.GetLastID() + 1;

            MakeupType newMakeupType = MakeupFactory.CreateType(newId, name);

            MakeupTypeRepository.AddMakeupType(newMakeupType);
        }

        public static void UpdateMakeupTypeByID(int id, string name)
        {
            MakeupType toUpdate = MakeupTypeRepository.GetMakeupTypeByID(id);

            MakeupTypeRepository.UpdateMakeupType(toUpdate, name);
        }

        public static void DeleteMakeupTypeByID(int id)
        {
            MakeupType toDelete = MakeupTypeRepository.GetMakeupTypeByID(id);
            MakeupTypeRepository.DeleteMakeupType(toDelete);
        }

        public static void AddMakeupBrand(string name, int rating)
        {
            int newId = MakeupBrandRepository.GetLastID() + 1;

            MakeupBrand newMakeupbrand = MakeupFactory.CreateBrand(newId, name, rating);

            MakeupBrandRepository.AddMakeupBrand(newMakeupbrand);
        }

        public static void UpdateMakeupBrandByID(int id, string name, int rating)
        {
            MakeupBrand toUpdate = MakeupBrandRepository.GetMakeupBrandByID(id);

            MakeupBrandRepository.UpdateMakeupBrand(toUpdate, name, rating);
        }

        public static void DeleteMakeupBrandByID(int id)
        {
            MakeupBrand toDelete = MakeupBrandRepository.GetMakeupBrandByID(id);
            MakeupBrandRepository.DeleteMakeupBrand(toDelete);
        }
    }
}