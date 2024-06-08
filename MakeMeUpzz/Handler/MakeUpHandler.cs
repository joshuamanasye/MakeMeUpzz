using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
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

        public static void DeleteMakeupByID(int id)
        {
            Makeup toDelete = MakeupRepository.GetMakeupById(id);

            MakeupRepository.DeleteMakeup(toDelete);
        }

        public static List<MakeupType> GetMakeupTypes()
        {
            return MakeupRepository.GetMakeupTypes();
        }

        public static List<MakeupBrand> GetMakeupBrands()
        {
            return MakeupRepository.GetMakeupBrands();
        }

        public static List<string> GetMakeupTypeNames()
        {
            List<MakeupType> types = MakeupRepository.GetMakeupTypes();

            List<string> typeNames = new List<string>();

            foreach (MakeupType type in types)
            {
                typeNames.Add(type.MakeupTypeName);
            }

            return typeNames;
        }

        public static List<string> GetMakeupBrandNames()
        {
            List<MakeupBrand> brands = MakeupRepository.GetMakeupBrands();

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

            int typeId = MakeupRepository.GetMakeupTypeIDByName(typeName);
            int brandId = MakeupRepository.GetMakeupBrandIDByName(brandName);

            Makeup newMakeup = MakeupFactory.CreateMakeup(newId, name, price, weight, typeId, brandId);

            MakeupRepository.AddMakeup(newMakeup);
        }

        public static void UpdateMakeupByID(int id, string name, int price, int weight, string typeName, string brandName)
        {
            Makeup toUpdate = MakeupRepository.GetMakeupById(id);
            int typeId = MakeupRepository.GetMakeupTypeIDByName(typeName);
            int brandId = MakeupRepository.GetMakeupBrandIDByName(brandName);

            MakeupRepository.UpdateMakeup(toUpdate, name, price, weight, typeId, brandId);
        }
    }
}