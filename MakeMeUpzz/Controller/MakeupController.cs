using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        MakeUpHandler makeupHandler;

        public MakeupController()
        {
            makeupHandler = new MakeUpHandler();
        }

        public void LoadMakeups(GridView gv)
        {
            gv.DataSource = makeupHandler.GetMakeups();
            gv.DataBind();
        }

        public void LoadTypes(DropDownList ddl)
        {
            ddl.DataSource = makeupHandler.GetMakeupTypeNames();
            ddl.DataBind();
        }

        public void LoadBrands(DropDownList ddl)
        {
            ddl.DataSource = makeupHandler.GetMakeupBrandNames();
            ddl.DataBind();
        }

        public void LoadMakeupDDL(DropDownList types, DropDownList brands)
        {
            LoadTypes(types);
            LoadBrands(brands);
        }

        public void InsertMakeup()
        {

        }

        public void DeleteMakeup(GridView gv, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text);

            makeupHandler.DeleteMakeupByID(id);
        }

        private int ToInt(string str)
        {
            int a = -1;

            try
            {
                a = Convert.ToInt32(str);
            }
            catch { }

            return a;
        }

        private bool CheckName(string name, Label nameErrorLbl)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                nameErrorLbl.Text = "Length must be between 1-99 characters.";

                return false;
            }

            return true;
        }

        private bool CheckPrice(string priceStr, Label priceErrorLbl)
        {
            int price = ToInt(priceStr);

            if (price < 1)
            {
                priceErrorLbl.Text = "Price must be >= 1";

                return false;
            }

            return true;
        }

        //TODO

        public void InsertMakeup(string name, string price, string weight, string typeName, string brandName,
            Label nameErrorLbl, Label priceErrorLbl, Label weightErrorLbl)
        {
            bool validInput = true;

            if (!CheckName(name, nameErrorLbl)) { validInput = false; }
            if (!CheckPrice(price, priceErrorLbl)) { validInput = false; }

            if (!validInput) { return; }
        }
    }
}