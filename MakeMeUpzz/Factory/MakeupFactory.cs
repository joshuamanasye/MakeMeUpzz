using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int id, string name, int price, int weight, int typeId, int brandId)
        {
            Makeup newMakup = new Makeup
            {
                MakeupID = id,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeId,
                MakeupBrandID = brandId
            };

            return newMakup;
        }
    }
}