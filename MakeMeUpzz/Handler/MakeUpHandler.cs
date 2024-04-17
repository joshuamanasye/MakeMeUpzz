using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class MakeUpHandler
    {
        private MakeupRepository repository;

        public MakeUpHandler()
        {
            this.repository = new MakeupRepository();
        }

        public List<Makeup> GetMakeups()
        {
            return repository.GetMakeups();
        }

        public void DeleteMakeupByID(int id)
        {
            Makeup toDelete = repository.GetMakeupById(id);

            repository.DeleteMakeup(toDelete);
        }

        public List<MakeupType> GetMakeupTypes()
        {
            return repository.GetMakeupTypes();
        }

        public List<MakeupBrand> GetMakeupBrands()
        {
            return repository.GetMakeupBrands();
        }

        public List<string> GetMakeupTypeNames()
        {
            List<MakeupType> types = repository.GetMakeupTypes();

            List<string> typeNames = new List<string>();

            foreach (MakeupType type in types)
            {
                typeNames.Add(type.MakeupTypeName);
            }

            return typeNames;
        }

        public List<string> GetMakeupBrandNames()
        {
            List<MakeupBrand> brands = repository.GetMakeupBrands();

            List<string> brandNames = new List<string>();

            foreach (MakeupBrand brand in brands)
            {
                brandNames.Add(brand.MakeupBrandName);
            }

            return brandNames;
        }
    }
}