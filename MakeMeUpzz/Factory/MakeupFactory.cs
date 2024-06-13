using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int makeupId, string name, int price, int weight, int typeId, int brandId)
        {
            Makeup newMakup = new Makeup
            {
                MakeupID = makeupId,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeId,
                MakeupBrandID = brandId
            };

            return newMakup;
        }

        public static MakeupType CreateType(int typeId, string name)
        {
            MakeupType newType = new MakeupType
            {
                MakeupTypeID = typeId,
                MakeupTypeName = name
            };

            return newType;
        }

        public static MakeupBrand CreateBrand(int brandId, string name, int rating)
        {
            MakeupBrand newBrand = new MakeupBrand
            {
                MakeupBrandID = brandId,
                MakeupBrandName = name,
                MakeupBrandRating = rating
            };

            return newBrand;
        }
    }
}