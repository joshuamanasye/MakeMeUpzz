using MakeMeUpzz.Util;
using MakeMeUpzzFrontEnd.Model;
using MakeMeUpzzFrontEnd.WebService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MakeMeUpzzFrontEnd.Controllers
{
    public class MakeupController
    {
        WebService1 service = new WebService1();
        public MakeupController()
        {
            
        }

        public void LoadMakeups(GridView gv)
        {
            gv.DataSource = JsonHandler.Decode<List<Makeup>>(service.GetMakeups());
            gv.DataBind();
        }

        public void LoadTypes(DropDownList ddl)
        {
            ddl.DataSource = MakeUpHandler.GetMakeupTypeNames();
            ddl.DataBind();
        }

        public void LoadBrands(DropDownList ddl)
        {
            ddl.DataSource = MakeUpHandler.GetMakeupBrandNames();
            ddl.DataBind();
        }

        public void LoadMakeupDDL(DropDownList types, DropDownList brands)
        {
            LoadTypes(types);
            LoadBrands(brands);
        }

        public void DeleteMakeup(GridView gv, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text);

            MakeUpHandler.DeleteMakeupByID(id);

            LoadMakeups(gv);
        }

        private int ToInt(string str)
        {
            if (int.TryParse(str, out int number)) {
                return number;
            }

            return -1;
        }

        private bool CheckName(string name, Label nameErrorLbl)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                nameErrorLbl.Text = "Length must be between 1-99 characters.";

                return false;
            }

            nameErrorLbl.Text = string.Empty;

            return true;
        }

        private bool CheckPrice(int price, Label priceErrorLbl)
        {
            if (price < 1)
            {
                priceErrorLbl.Text = "Price must be >= 1";

                return false;
            }

            priceErrorLbl.Text = string.Empty;

            return true;
        }

        private bool CheckWeight(int weight, Label weightErrorLbl)
        {
            if (weight > 1500 || weight < 1)
            {
                weightErrorLbl.Text = "Cannot be less than 1500 and more than 0";

                return false;
            }

            weightErrorLbl.Text = string.Empty;

            return true;
        }

        public void InsertMakeup(string name, string priceStr, string weightStr, string typeName, string brandName,
            Label nameErrorLbl, Label priceErrorLbl, Label weightErrorLbl, HttpResponse response)
        {
            bool validInput = true;

            int price = ToInt(priceStr);
            int weight = ToInt(weightStr);

            if (!CheckName(name, nameErrorLbl)) { validInput = false; }
            if (!CheckPrice(price, priceErrorLbl)) { validInput = false; }
            if (!CheckWeight(weight, weightErrorLbl)) { validInput = false; }

            if (!validInput) { return; }

            MakeUpHandler.AddMakeup(name, price, weight, typeName, brandName);

            response.Redirect("ManageMakeup.aspx");
        }
    }
}