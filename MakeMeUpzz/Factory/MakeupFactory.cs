using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class MakeupFactory
    {
        public MakeupFactory() { }

        public Makeup CreateMakeup(int id, string name, int price, int weight, int typeId, int brandId)
        {
            Makeup newMakup = new Makeup();

            newMakup.MakeupID = id;
            newMakup.MakeupName = name;
            newMakup.MakeupPrice = price;
            newMakup.MakeupWeight = weight;
            newMakup.MakeupTypeID = typeId;
            newMakup.MakeupBrandID = brandId;

            return newMakup;
        }
    }
}