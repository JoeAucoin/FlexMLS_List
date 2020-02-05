using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.Modules.FlexMLS_List.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class FlexMLS_ListSettings : ModuleSettingsBase
    {
       

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
        /// 

        public string MLSImagesUrl
        {
            get
            {
                if (Settings.Contains("MLSImagesUrl"))
                    return Settings["MLSImagesUrl"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "MLSImagesUrl", value.ToString());
            }
        }

        public string MaxThumbSize
        {
            get
            {
                if (Settings.Contains("MaxThumbSize"))
                    return Settings["MaxThumbSize"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "MaxThumbSize", value.ToString());
            }
        }

        public string ShowPaging
        {
            get
            {
                if (Settings.Contains("ShowPaging"))
                    return Settings["ShowPaging"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowPaging", value.ToString());
            }
        }

        public string NumberOfRecords
        {
            get
            {
                if (Settings.Contains("NumberOfRecords"))
                    return Settings["NumberOfRecords"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "NumberOfRecords", value.ToString());
            }
        }

        public string ShowCriteria
        {
            get
            {
                if (Settings.Contains("ShowCriteria"))
                    return Settings["ShowCriteria"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowCriteria", value.ToString());
            }
        }

        public string FavoritesModuleID
        {
            get
            {
                if (Settings.Contains("FavoritesModuleID"))
                    return Settings["FavoritesModuleID"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "FavoritesModuleID", value.ToString());
            }
        }


        public string ListingOfficeMLSID
        {
            get
            {
                if (Settings.Contains("ListingOfficeMLSID"))
                    return Settings["ListingOfficeMLSID"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ListingOfficeMLSID", value.ToString());
            }
        }

        public string PropertyType
        {
            get
            {
                if (Settings.Contains("PropertyType"))
                    return Settings["PropertyType"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "PropertyType", value.ToString());
            }
        }

        public string Town
        {
            get
            {
                if (Settings.Contains("Town"))
                    return Settings["Town"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Town", value.ToString());
            }
        }


        public string Village
        {
            get
            {
                if (Settings.Contains("Village"))
                    return Settings["Village"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Village", value.ToString());
            }
        }

        public string Bedrooms
        {
            get
            {
                if (Settings.Contains("Bedrooms"))
                    return Settings["Bedrooms"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Bedrooms", value.ToString());
            }
        }

        public string Bathrooms
        {
            get
            {
                if (Settings.Contains("Bathrooms"))
                    return Settings["Bathrooms"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Bathrooms", value.ToString());
            }
        }


        public string PriceLow
        {
            get
            {
                if (Settings.Contains("PriceLow"))
                    return Settings["PriceLow"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "PriceLow", value.ToString());
            }
        }

        public string PriceHigh
        {
            get
            {
                if (Settings.Contains("PriceHigh"))
                    return Settings["PriceHigh"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "PriceHigh", value.ToString());
            }
        }

        public string WaterFront
        {
            get
            {
                if (Settings.Contains("WaterFront"))
                    return Settings["WaterFront"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "WaterFront", value.ToString());
            }
        }

        public string Waterview
        {
            get
            {
                if (Settings.Contains("Waterview"))
                    return Settings["Waterview"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Waterview", value.ToString());
            }
        }

        public string Complex
        {
            get
            {
                if (Settings.Contains("Complex"))
                    return Settings["Complex"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "Complex", value.ToString());
            }
        }

        public string DOM
        {
            get
            {
                if (Settings.Contains("DOM"))
                    return Settings["DOM"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "DOM", value.ToString());
            }
        }

        public string FlexMLSPage
        {
            get
            {
                if (Settings.Contains("FlexMLSPage"))
                    return Settings["FlexMLSPage"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "FlexMLSPage", value.ToString());
            }
        }


        public string MlsNumbers
        {
            get
            {
                if (Settings.Contains("MlsNumbers"))
                    return Settings["MlsNumbers"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "MlsNumbers", value.ToString());
            }
        }

        public string YearBuilt
        {
            get
            {
                if (Settings.Contains("YearBuilt"))
                    return Settings["YearBuilt"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "YearBuilt", value.ToString());
            }
        }		

        #endregion
    }
}
