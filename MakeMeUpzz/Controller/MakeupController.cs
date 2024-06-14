using MakeMeUpzz.Handler;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository.MakeupRepo;
using MakeMeUpzz.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        public void LoadMakeupsToGV(GridView gv)
        {
            gv.DataSource = MakeUpHandler.GetMakeups();
            gv.DataBind();
        }

        public void LoadMakeupTypesToGV(GridView gv)
        {
            gv.DataSource = MakeUpHandler.GetMakeupTypes();
            gv.DataBind();
        }

        public void LoadMakeupBrandsToGV(GridView gv)
        {
            gv.DataSource = MakeUpHandler.GetMakeupBrands();
            gv.DataBind();
        }

        public void LoadMakeupDataToGV(GridView makeupGV, GridView typeGV, GridView brangGV)
        {
            LoadMakeupsToGV(makeupGV);
            LoadMakeupTypesToGV(typeGV);
            LoadMakeupBrandsToGV(brangGV);
        }

        public void LoadTypesToDDL(DropDownList ddl)
        {
            ddl.DataSource = MakeUpHandler.GetMakeupTypeNames();
            ddl.DataBind();
        }

        public void LoadBrandsToDDL(DropDownList ddl)
        {
            ddl.DataSource = MakeUpHandler.GetMakeupBrandNames();
            ddl.DataBind();
        }

        public void LoadMakeupDDL(DropDownList types, DropDownList brands)
        {
            LoadTypesToDDL(types);
            LoadBrandsToDDL(brands);
        }

        private bool CheckValidMakeupByID(int id)
        {
            Makeup toCheck = MakeupRepository.GetMakeupById(id);

            if (toCheck == null) { return false; }

            return true;
        }

        public int RequestID(HttpRequest request, HttpResponse response)
        {
            int id = UtilConvert.ToInt(request.QueryString["ID"]);

            if( !CheckValidMakeupByID(id) )
            {
                response.Redirect("ManageMakeup.aspx");
            }

            return id;
        }

        public void LoadMakeupDataToForm(int id,
            TextBox nameTxt, TextBox priceTxt, TextBox weightTxt, DropDownList typeDdl, DropDownList brandDdl)
        {
            Makeup toLoad = MakeUpHandler.GetmakeupByID(id);

            nameTxt.Text = toLoad.MakeupName;
            priceTxt.Text = toLoad.MakeupPrice.ToString();
            weightTxt.Text = toLoad.MakeupWeight.ToString();
            typeDdl.SelectedValue = toLoad.MakeupType.MakeupTypeName.ToString();
            brandDdl.SelectedValue = toLoad.MakeupBrand.MakeupBrandName.ToString();
        }

        public void LoadMakeupTypeDataToForm(int id,
            TextBox nameTxt)
        {
            MakeupType toLoad = MakeUpHandler.GetMakeupTypeByID(id);

            nameTxt.Text = toLoad.MakeupTypeName;
        }

        public void LoadMakeupBrandDataToForm(int id,
            TextBox nameTxt, TextBox ratingTxt)
        {
            MakeupBrand toLoad = MakeUpHandler.GetMakeupBrandByID(id);

            nameTxt.Text = toLoad.MakeupBrandName;
            ratingTxt.Text = toLoad.MakeupBrandRating.ToString();
        }

        public void DeleteMakeup(GridView gv, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text);

            MakeUpHandler.DeleteMakeupByID(id);

            LoadMakeupsToGV(gv);
        }

        public void DeleteMakeupType(GridView gv, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text);

            MakeUpHandler.DeleteMakeupTypeByID(id);

            LoadMakeupTypesToGV(gv);
        }

        public void DeleteMakeupBrand(GridView gv, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Text);

            MakeUpHandler.DeleteMakeupBrandByID(id);

            LoadMakeupBrandsToGV(gv);
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

        private bool CheckRating(int rating, Label ratingErrorLbl)
        {
            if (rating > 100 || rating < 0)
            {
                ratingErrorLbl.Text = "Must be between 0 - 100";

                return false;
            }

            ratingErrorLbl.Text = string.Empty;

            return true;
        }

        private bool CheckMakeupData(string name, int price, int weight, string typeName, string brandName,
            Label nameErrorLbl, Label priceErrorLbl, Label weightErrorLbl)
        {
            bool validInput = true;

            if ( !CheckName(name, nameErrorLbl) ) { validInput = false; }
            if ( !CheckPrice(price, priceErrorLbl) ) { validInput = false; }
            if ( !CheckWeight(weight, weightErrorLbl) ) { validInput = false; }

            return validInput;
        }

        public void InsertMakeup(string name, string priceStr, string weightStr, string typeName, string brandName,
            Label nameErrorLbl, Label priceErrorLbl, Label weightErrorLbl,
            HttpResponse response)
        {
            int price = UtilConvert.ToInt(priceStr);
            int weight = UtilConvert.ToInt(weightStr);

            if ( !CheckMakeupData(name, price, weight, typeName, brandName,nameErrorLbl, priceErrorLbl, weightErrorLbl) ) { return; }

            MakeUpHandler.AddMakeup(name, price, weight, typeName, brandName);

            response.Redirect("ManageMakeup.aspx");
        }

        public void UpdateMakeup(int id, string name, string priceStr, string weightStr, string typeName, string brandName,
            Label nameErrorLbl, Label priceErrorLbl, Label weightErrorLbl,
            HttpResponse response)
        {
            int price = UtilConvert.ToInt(priceStr);
            int weight = UtilConvert.ToInt(weightStr);

            if ( !CheckMakeupData(name, price, weight, typeName, brandName, nameErrorLbl, priceErrorLbl, weightErrorLbl) ) { return; }

            MakeUpHandler.UpdateMakeupByID(id, name, price, weight, typeName, brandName);

            response.Redirect("ManageMakeup.aspx");
        }

        public void InsertMakeupType(string name,
            Label nameErrorLbl,
            HttpResponse response)
        {
            if (!CheckName(name, nameErrorLbl)) { return; }

            MakeUpHandler.AddMakeupType(name);

            response.Redirect("ManageMakeup.aspx");
        }

        public void UpdateMakeupType(int id, string name,
            Label nameErrorLbl,
            HttpResponse response)
        {
            if (!CheckName(name, nameErrorLbl)) { return; }

            MakeUpHandler.UpdateMakeupTypeByID(id, name);

            response.Redirect("ManageMakeup.aspx");
        }

        private bool CheckMakeupBrandData(string name, int rating,
            Label nameErrorLbl, Label ratingErrorLbl)
        {
            bool validInput = true;
            if (!CheckName(name, nameErrorLbl)) { validInput = false; }
            if (!CheckRating(rating, ratingErrorLbl)) { validInput = false; }

            return validInput;
        }

        public void InsertMakeupBrand(string name, string ratingStr,
            Label nameErrorLbl, Label ratingErrorLbl,
            HttpResponse response)
        {
            int rating = UtilConvert.ToInt(ratingStr);

            if (!CheckMakeupBrandData(name, rating, nameErrorLbl, ratingErrorLbl)) { return; }

            MakeUpHandler.AddMakeupBrand(name, rating);

            response.Redirect("ManageMakeup.aspx");
        }

        public void UpdateMakeupBrand(int id, string name, string ratingStr,
            Label nameErrorLbl, Label ratingErrorLbl,
            HttpResponse response)
        {
            int rating = UtilConvert.ToInt(ratingStr);

            if ( !CheckMakeupBrandData(name, rating, nameErrorLbl, ratingErrorLbl) ) { return; }

            MakeUpHandler.UpdateMakeupBrandByID(id, name, rating);

            response.Redirect("ManageMakeup.aspx");
        }

        public void RedirectToUpdateMakeup(int id, HttpResponse response)
        {
            response.Redirect("UpdateMakeup.aspx?ID=" + id);
        }

        public void RedirectToUpdateMakeupType(int id, HttpResponse response)
        {
            response.Redirect("UpdateMakeupType.aspx?ID=" + id);
        }

        public void RedirectToUpdateMakeupBrand(int id, HttpResponse response)
        {
            response.Redirect("UpdateMakeupBrand.aspx?ID=" + id);
        }

        public void CheckAdmin(HttpResponse response, HttpSessionState session)
        {
            string username = session["username"].ToString();
            User user = UserHandler.GetUser(username);

            if (!user.UserRole.Equals("admin"))
            {
                response.Redirect("~/View/Home.aspx");
            }
        }

        public void CheckCustomer(HttpResponse response, HttpSessionState session)
        {
            string username = session["username"].ToString();
            User user = UserHandler.GetUser(username);

            if (!user.UserRole.Equals("customer"))
            {
                response.Redirect("~/View/Home.aspx");
            }
        }
    }
}