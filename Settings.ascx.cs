using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.Modules.FlexMLS_List.Components;
using GIBS.Modules.FlexMLS.Components;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Tabs;
using System.Collections;
using DotNetNuke.Security;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Localization;

namespace GIBS.Modules.FlexMLS_List
{
    public partial class Settings : FlexMLS_ListSettings
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    GetCondoComplex();
                    GetTowns();
                    BindModules();
                    BindFavoriteModules();
                    
                 //   FlexMLS_ListSettings settingsData = new FlexMLS_ListSettings(this.TabModuleId);


                    if (FavoritesModuleID != null)
                    {
                        drpModuleID.SelectedValue = FavoritesModuleID.ToString();
                    }

                    if (ShowCriteria != null)
                    {
                        if (ShowCriteria.Length > 0)
                        cbxShowCriteria.Checked = Convert.ToBoolean(ShowCriteria.ToString());
                    }
                    
                    if (ListingOfficeMLSID != null)
                    {
                        ddlOfficeID.SelectedValue = ListingOfficeMLSID.ToString();
                    }	

                    if (PropertyType != null)
                    {
                        ddlPropertyType.SelectedValue = PropertyType.ToString();
                    }

                    if (Town != null)
                    {

                        ddl_Town.SelectedValue = Town.ToString();
                    }
                    if (Village != null)
                    {
                        ddl_Village.SelectedValue = Village.ToString();
                    }
                    if (Bedrooms != null)
                    {
                        ddlBedRooms.SelectedValue = Bedrooms.ToString();
                    }
                    if (Bathrooms != null)
                    {
                       ddlBathRooms.SelectedValue = Bathrooms.ToString();
                    }
                    if (PriceLow != null)
                    {
                        ddlPriceLow.SelectedValue = PriceLow.ToString();
                    }
                    if (PriceHigh != null)
                    {
                        ddlPriceHigh.SelectedValue = PriceHigh.ToString();
                    }
                    if (WaterFront != null)
                    {
                        if (WaterFront.Length > 0)
                        cbxWaterFront.Checked = Convert.ToBoolean(WaterFront.ToString());
                    }
                    if (Waterview != null)
                    {
                        if (Waterview.Length > 0)
                        cbxWaterView.Checked = Convert.ToBoolean(Waterview.ToString());
                    }
                    if (Complex != null)
                    {
                        ddlComplex.SelectedValue = Complex.ToString();
                    }
                    if (DOM != null)
                    {
                        ddlDOM.SelectedValue = DOM.ToString();
                    }
                    if (FlexMLSPage != null)
                    {
                        ddlViewListing.SelectedValue = FlexMLSPage.ToString();
                    }

                    if (MaxThumbSize != null)
                    {
                        txtThumbSize.Text = MaxThumbSize.ToString();
                    }

                    if (ShowPaging != null)
                    {
                        if (ShowPaging.Length > 0)
                        cbxShowPaging.Checked = Convert.ToBoolean(ShowPaging);
                    }

                    if (NumberOfRecords != null)
                    {
                        txtNumberOfRecords.Text = NumberOfRecords.ToString();
                    }

                    if (MlsNumbers != null)
                    {
                        txtListingNumbers.Text = MlsNumbers.ToString();
                    }

                    if (YearBuilt != null)
                    {
                        txtYearBuilt.Text = YearBuilt.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
        private void BindFavoriteModules()
        {

            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "GIBS - FlexMLS - Favorites");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                    ListItem objListItem = new ListItem();

                    objListItem.Value = mi.ModuleID.ToString();    // mi.ModuleID.ToString();
                    objListItem.Text = mi.ModuleTitle.ToString();

                    drpModuleID.Items.Add(objListItem);

                }
            }


            drpModuleID.Items.Insert(0, new ListItem("Select Module", "-1"));
        }




        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {

                FavoritesModuleID = drpModuleID.SelectedValue.ToString();
                MLSImagesUrl = txtMLSImagesUrl.Text.ToString();
                Town = ddl_Town.SelectedValue.ToString();
                MaxThumbSize = txtThumbSize.Text.ToString();
                ShowPaging = cbxShowPaging.Checked.ToString();
                ShowCriteria = cbxShowCriteria.Checked.ToString();
                ListingOfficeMLSID = ddlOfficeID.SelectedValue.ToString();
                NumberOfRecords = txtNumberOfRecords.Text.ToString();
                PropertyType = ddlPropertyType.SelectedValue.ToString();
                Village = ddl_Village.SelectedValue.ToString();
                Bedrooms = ddlBedRooms.SelectedValue.ToString();
                Bathrooms = ddlBathRooms.SelectedValue.ToString();
                PriceLow = ddlPriceLow.SelectedValue.ToString();
                PriceHigh = ddlPriceHigh.SelectedValue.ToString();
                WaterFront = cbxWaterFront.Checked.ToString();
                Waterview = cbxWaterView.Checked.ToString();
                Complex = ddlComplex.SelectedValue.ToString();
                DOM = ddlDOM.SelectedValue.ToString();
                FlexMLSPage = ddlViewListing.SelectedValue.ToString();
                MlsNumbers = txtListingNumbers.Text.ToString();
                YearBuilt = txtYearBuilt.Text.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        private void BindModules()
        {

            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "GIBS - FlexMLS");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                    DotNetNuke.Entities.Tabs.TabController tabController = new DotNetNuke.Entities.Tabs.TabController();
                    DotNetNuke.Entities.Tabs.TabInfo tabInfo = tabController.GetTab(mi.TabID, this.PortalId);

                    string strPath = tabInfo.TabName.ToString();

                    ListItem objListItem = new ListItem();

                    objListItem.Value = mi.TabID.ToString();         //mi.ModuleID.ToString();
                    objListItem.Text = strPath + " -> " + mi.ModuleTitle.ToString();

                    ddlViewListing.Items.Add(objListItem);

                    

                }
            }


            ddlViewListing.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
            
        }

        //public void GetMyTabs()
        //{

        //    try
        //    {


        //        ddlViewListing.DataSource = TabController.GetPortalTabs(this.PortalId, this.TabId, true, false);
        //        ddlViewListing.DataBind();


        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }

        //}


        public void GetCondoComplex()
        {

            try
            {

                List<FlexMLSInfo> items;

                FlexMLSController controller = new FlexMLSController();
                items = controller.FlexMLS_Get_CondoComplex();

                ddlComplex.DataSource = items;
                
                ddlComplex.DataTextField = "Town";
                ddlComplex.DataValueField = "Complex";
                ddlComplex.DataBind();

                ddlComplex.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetTowns()
        {

            try
            {

                List<FlexMLSInfo> items;
                List<FlexMLSInfo> itemsOffices;

                FlexMLSController controller = new FlexMLSController();
                items = controller.FlexMLS_Lookup_Town();


                ddl_Town.DataSource = items;
                ddl_Town.DataTextField = "Town";
                ddl_Town.DataValueField = "Town";
                ddl_Town.DataBind();

                ddl_Town.Items.Insert(0, new ListItem("--Select--", ""));

                //ddlOfficeID
                itemsOffices = controller.FlexMLS_Get_Offices();
                ddlOfficeID.DataSource = itemsOffices;
                ddlOfficeID.DataTextField = "ListingOfficeName";
                ddlOfficeID.DataValueField = "OfficeID";
                ddlOfficeID.DataBind();

                ddlOfficeID.Items.Insert(0, new ListItem("--Select--", ""));


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void ddl_Town_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<FlexMLSInfo> items;
            FlexMLSController controller = new FlexMLSController();

            items = controller.FlexMLS_Lookup_Village(ddl_Town.SelectedValue.ToString());

            ddl_Village.DataSource = items;
            ddl_Village.DataTextField = "Village";
            ddl_Village.DataValueField = "Village";
            ddl_Village.DataBind();

            ddl_Village.Items.Insert(0, new ListItem("--Optionally Select--", ""));


        }

    }
}