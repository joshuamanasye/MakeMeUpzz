using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MakeMeUpzz.Util
{
    public class JsonHandler
    {
        public static string Encode(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T Decode<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}