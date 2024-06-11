using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Util
{
    public class UtilConvert
    {
        public static int ToInt(string str)
        {
            if (int.TryParse(str, out int number))
            {
                return number;
            }

            return -1;
        }
    }
}