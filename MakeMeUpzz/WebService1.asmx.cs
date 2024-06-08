using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MakeMeUpzz
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool Authenticate(string username, string password)
        {
            return UserHandler.Authenticate(username, password);
        }

        [WebMethod]
        public string GetUser(string username)
        {
            return JsonHandler.Encode(UserHandler.GetUser(username));
        }

        [WebMethod]
        public void AddCustomer(string username, string email, string gender, DateTime dob, string password)
        {
            UserHandler.AddCustomer(username, email, gender, dob, password);
        }

        [WebMethod]
        public string GetMakeups()
        {
            return JsonHandler.Encode(MakeUpHandler.GetMakeups());
        }

        [WebMethod]
        public void DeleteMakeupByID(int id)
        {
            MakeUpHandler.DeleteMakeupByID(id);
        }

        [WebMethod]
        public string GetMakeupTypes()
        {
            return JsonHandler.Encode(MakeUpHandler.GetMakeupTypes());
        }

        [WebMethod]
        public string GetMakeupBrands()
        {
            return JsonHandler.Encode(MakeUpHandler.GetMakeupBrands());
        }

        [WebMethod]
        public string GetMakeupTypeNames()
        {
            return JsonHandler.Encode(MakeUpHandler.GetMakeupTypeNames());
        }

        [WebMethod]
        public string GetMakeupBrandNames()
        {
            return JsonHandler.Encode(MakeUpHandler.GetMakeupBrandNames());
        }

        [WebMethod]
        public void AddMakeup(string name, int price, int weight, string typeName, string brandName)
        {
            MakeUpHandler.AddMakeup(name, price, weight, typeName, brandName);
        }
    }
}
