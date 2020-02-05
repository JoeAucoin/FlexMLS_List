using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Common.Controls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Web.Client;
using DotNetNuke.Services.ClientCapability;
using GIBS.Modules.FlexMLS.Components;
using GIBS.Modules.FlexMLS_List.Components;
using DotNetNuke.Common;
using System.Web;
using System.Text;
using DotNetNuke.Web.Client.ClientResourceManagement;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI.HtmlControls;

namespace GIBS.Modules.FlexMLS_List
{
    public partial class ViewFlexMLS_List : PortalModuleBase
    {
        public string _propertyType = "";
        public string _village = "";
        public string _town = "";
        public string _beds = "0";
        public string _baths = "0";
        public string _waterfront = "";
        public string _waterview = "";
        public string _pricelow = "0";
        public string _pricehigh = "50000000";
        public string _returnURL = "";
        public string _listingOfficeMLSID = "";
        public string _complex = "";
        public string _dom = "";
        static string _FlexMLSPage = "";
        static string _favoritesModule = "";

        public int _CurrentPage = 1;
        public string _ViewListingPage = "";
        public int PageSize = 5;
        public string _maxThumbSize = "80";

        public bool _searchMlsNumber = false;
        public string _MlsNumbers = "";
        public string _yearBuilt = "";
        static string _MLSImagesURL = "";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //<cc1:GMap ID="GMap1" runat="server" Width="100%" Height="500px"  /><%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

           // GMap1.Key = "AIzaSyB6ckfi9Mjq3BDjdFeaz2NAhBagNzLEPJY";  //Key for browser apps (with referers)  
           // GControl control = new GControl(GControl.preBuilt.LargeMapControl);
           // //     GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Bottom_Left));
           //// GMap1.markerManager.options.
           // GMap1.Add(control);

        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            //  RegisterStyleSheet("", "");
            //      ClientResourceManager.RegisterStyleSheet(this.Page, this.Page.ResolveUrl("~/DesktopModules/GIBS/FlexMLS/CustomStyleSheet.css"), FileOrder.Css.ModuleCss);




            if (!IsPostBack)
            {
                



            }

         //   CheckQueryString();

            LoadSettings();
            SearchMLS();


        }

        public void CheckQueryString()
        {

            try
            {




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void LoadSettings()
        {

            try
            {

                if (Settings.Contains("MLSImagesUrl"))
                {
                    _MLSImagesURL = Settings["MLSImagesUrl"].ToString();
                }
                
                if (Settings.Contains("YearBuilt"))
                {
                    _yearBuilt = Settings["YearBuilt"].ToString();
                }

                if (Settings.Contains("FavoritesModuleID"))
                {
                    _favoritesModule = Settings["FavoritesModuleID"].ToString();
                }
                
                if (Settings.Contains("ShowCriteria"))
                {
                    divSearchCriteria.Visible = Convert.ToBoolean(Settings["ShowCriteria"].ToString());
                }

                if (Settings.Contains("ListingOfficeMLSID"))
                {
                    _listingOfficeMLSID = Settings["ListingOfficeMLSID"].ToString();
                }

                if (Settings.Contains("PropertyType"))
                {
                    _propertyType = Settings["PropertyType"].ToString();
                }

                if (Settings.Contains("Town"))
                {
                    _town = Settings["Town"].ToString();
                }

                if (Settings.Contains("Village"))
                {
                    _village = Settings["Village"].ToString();
                }

                if (Settings.Contains("Bedrooms"))
                {
                    _beds = Settings["Bedrooms"].ToString();
                }

                if (Settings.Contains("Bathrooms"))
                {
                    _baths = Settings["Bathrooms"].ToString();
                }

                if (Settings.Contains("PriceLow"))
                {
                    _pricelow = Settings["PriceLow"].ToString();
                }
                if (Settings.Contains("PriceHigh"))
                {
                    _pricehigh = Settings["PriceHigh"].ToString();
                }
                if (Settings.Contains("WaterFront"))
                {
                    _waterfront = Settings["WaterFront"].ToString();
                }
                if (Settings.Contains("Waterview"))
                {
                    _waterview = Settings["Waterview"].ToString();
                }
                if (Settings.Contains("Complex"))
                {
                    _complex = Settings["Complex"].ToString();
                }
                if (Settings.Contains("DOM"))
                {
                    _dom = Settings["DOM"].ToString();
                }
                if (Settings.Contains("FlexMLSPage"))
                {
                    _FlexMLSPage = Settings["FlexMLSPage"].ToString();
                }
                if (Settings.Contains("ShowPaging"))
                {
                    if (Convert.ToBoolean(Settings["ShowPaging"].ToString()) == false)
                    {
                        PagingControl1.Visible = false;
                    }
                }
                if (Settings.Contains("NumberOfRecords"))
                {
                    PageSize = Int32.Parse(Settings["NumberOfRecords"].ToString());
                }
                if (Settings.Contains("MaxThumbSize"))
                {
                    if (Int32.Parse(Settings["MaxThumbSize"].ToString()) > 1)
                    {
                        _maxThumbSize = Settings["MaxThumbSize"].ToString();
                    }
                }
                if (Settings.Contains("MlsNumbers"))
                {
                    if (Settings["MlsNumbers"].ToString().Length > 5)
                    {
                        _searchMlsNumber = true;
                        _MlsNumbers = Settings["MlsNumbers"].ToString();
                    }
                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void SearchMLS()
        {

            try
            {

                
                //Display 20 items per page
                //Get the currentpage index from the url parameter
                if (Request.QueryString["currentpage"] != null)
                {
                    _CurrentPage = Convert.ToInt32(Request.QueryString["currentpage"].ToString());
                }
                else
                {
                    _CurrentPage = 1;
                }




                int _bedRooms = Convert.ToInt32(_beds.ToString());
                int _bathRooms = Convert.ToInt32(_baths.ToString());
                string _SearchWaterFront = "";
                string _SearchWaterView = "";
                int _priceLow = Convert.ToInt32(_pricelow.ToString());
                int _priceHigh = Convert.ToInt32(_pricehigh.ToString());

                if (_waterfront.ToString() == "True")
                {
                    _SearchWaterFront = "YES";
                }
                if (_waterview.ToString() == "True")
                {
                    _SearchWaterView = "YES";
                }


                StringBuilder _SearchCriteria = new StringBuilder();
                _SearchCriteria.Capacity = 500;

                if (_propertyType.ToString().Length > 0)
                {
                    _SearchCriteria.Append("Listing Type: <b>" + _propertyType.ToString() + "</b> &nbsp;");
                }
                if (_town.ToString().Length > 0)
                {
                    _SearchCriteria.Append(" Town: <b>" + _town.ToString() + "</b> &nbsp;");
                }
                if (_village.ToString().Length > 0)
                {
                    _SearchCriteria.Append(" Village: <b>" + _village.ToString() + "</b> &nbsp;");
                }



                if (_yearBuilt.ToString().Length > 0)
                {
                    _SearchCriteria.Append(" Year Built: <b>" + _yearBuilt.ToString() + " or Newer</b> &nbsp;");
                }

                if (_bedRooms > 0)
                {
                    _SearchCriteria.Append(" Bedrooms: <b>" + _bedRooms.ToString() + "</b> &nbsp;");
                }
                if (_bathRooms > 0)
                {
                    _SearchCriteria.Append(" Bathrooms: <b>" + _bathRooms.ToString() + "</b> &nbsp;");
                }
                if (_SearchWaterFront.ToString() == "YES")
                {
                    _SearchCriteria.Append(" Waterfront: <b>" + _SearchWaterFront.ToString() + "</b> &nbsp;");
                }
                if (_SearchWaterView.ToString() == "YES")
                {
                    _SearchCriteria.Append(" Waterview: <b>" + _SearchWaterView.ToString() + "</b> &nbsp;");
                }
                if (_priceLow > 0)
                {
                    _SearchCriteria.Append(" Min. Price: <b>" + _priceLow.ToString() + "</b> &nbsp;");
                }
                if (_priceHigh < 50000000)
                {
                    _SearchCriteria.Append(" Max Price: <b>" + _priceHigh.ToString() + "</b> &nbsp;");
                }
                if (_listingOfficeMLSID.ToString().Length > 0)
                {
                    _SearchCriteria.Append(" Office: <b>" + _listingOfficeMLSID.ToString() + "</b> &nbsp;");
                }
                //else
                //{
                //    _listingOfficeMLSID = "";
                //}

                if (_dom.ToString().Trim().Length > 0)
                {
                    _SearchCriteria.Append(" Days On Market: <b>" + _dom.ToString() + " day or less</b> &nbsp;");
                }
                else
                {
                    _dom = "";
                }

                if (_complex.ToString().Length > 0)
                {
                    _SearchCriteria.Append(" Complex: <b>" + _complex.ToString() + "</b> &nbsp;");
                }
                else
                {
                    _complex = "";
                }


                lblSearchCriteria.Text = _SearchCriteria.ToString();

                List<FlexMLSInfo> items;
                FlexMLSController controller = new FlexMLSController();


                if (_complex.ToString().Length > 0)
                {
                    items = controller.FlexMLS_Search_Condo(_propertyType.ToString(),
                            _town.ToString(), _village.ToString(),
                            _bedRooms.ToString(), _bathRooms.ToString(),
                            _SearchWaterFront.ToString(),
                            _SearchWaterView.ToString(),
                            _priceLow.ToString(),
                            _priceHigh.ToString(),
                            _listingOfficeMLSID.ToString(), _dom.ToString(), _complex.ToString());
               //     lblDebug.Text = " Searching Condos";
                }
                else if (_searchMlsNumber == true)
                {
                    items = controller.FlexMLS_Search_MLS_Numbers(_MlsNumbers.ToString());
               //     lblDebug.Text = " Searching MLS Numbers";
                }
                else
                {
                    items = controller.FlexMLS_Search_YearBuilt(_propertyType.ToString(),
                            _town.ToString(), _village.ToString(),
                            _bedRooms.ToString(), _bathRooms.ToString(),
                            _SearchWaterFront.ToString(),
                            _SearchWaterView.ToString(),
                            _priceLow.ToString(),
                            _priceHigh.ToString(),
                            _listingOfficeMLSID.ToString(), _dom.ToString(), _yearBuilt.ToString());
                //    lblDebug.Text = " Searching Search Criteria: " + _listingOfficeMLSID.ToString();
                }


                //DataTable dt = ToDataTable(items);

             //   items.Sort("ListingPrice desc",);

                //dt.DefaultView.Sort = "ListingPrice desc";
                //dt = dt.DefaultView.ToTable();
                ////DataList1.DataSource = dt.DefaultView;
                ////DataList1.DataBind();
                //DataTable dtSorted = dt;

                PagedDataSource objPagedDataSource = new PagedDataSource();
                objPagedDataSource.DataSource = items;
                


             //   objPagedDataSource.s
                if (objPagedDataSource.PageCount > 0)
                {
                    objPagedDataSource.PageSize = PageSize;
                    objPagedDataSource.CurrentPageIndex = _CurrentPage - 1;
                    objPagedDataSource.AllowPaging = true;
                }

                lstSearchResults.DataSource = objPagedDataSource;
                lstSearchResults.DataBind();

                lblSearchSummary.Text = "Total Listings Found: " + items.Count.ToString();

                if (PageSize == 0 || items.Count <= PageSize)
                {
                    PagingControl1.Visible = false;
                }
                else
                {
                    PagingControl1.Visible = true;
                    PagingControl1.TotalRecords = items.Count;
                    PagingControl1.PageSize = PageSize;
                    PagingControl1.CurrentPage = _CurrentPage;
                    PagingControl1.TabID = TabId;
                    PagingControl1.QuerystringParams = GenerateQueryStringParameters(this.Request, "Town", "Village", "Beds", "Baths", "WaterFront", "WaterView", "Type", "Low", "High", "LOID", "DOM", "Complex");

                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        protected void linkButtonFavoritesAddListing_Click(object sender, EventArgs e)
        {
            try
            {
                int MLSnumber = 0;
                LinkButton myButton = sender as LinkButton;

                if (myButton != null)
                {
                    MLSnumber = Convert.ToInt32(myButton.CommandArgument);
                }

                FlexMLSController controller = new FlexMLSController();
                FlexMLSInfo item = new FlexMLSInfo();

                item.Favorite = MLSnumber.ToString();
                item.FavoriteType = "Listing";
                item.ModuleId = Int32.Parse(_favoritesModule.ToString());    
                item.UserID = this.UserId;
                item.EmailSearch = false;

                controller.FlexMLS_Favorites_Add(item);

                myButton.Text = "SAVED! - " + item.Favorite.ToString();

                


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }



        protected static string GenerateQueryStringParameters(HttpRequest request, params string[] queryStringKeys)
        {
            StringBuilder queryString = new StringBuilder(64);
            foreach (string key in queryStringKeys)
            {
                if (request.QueryString[key] != null)
                {
                    if (queryString.Length > 0)
                    {
                        queryString.Append("&");
                    }

                    queryString.Append(key).Append("=").Append(request.QueryString[key]);
                }
            }

            return queryString.ToString();
        }

        private string GetAdditionalQueryStringParams()
        {
            throw new NotImplementedException();
        }


        //public void BuildGoogleMap(double Latitude, double Longitude, string BubbleText)
        //{

        //    try
        //    {

        //        GMap1.setCenter(new GLatLng(Latitude, Longitude), 14);
                

        //        GLatLng latlng = new GLatLng(Latitude, Longitude);

        //        string vBubbleText = BubbleText.ToString();  
 
        //        GMarker marker = new GMarker(latlng, new GMarkerOptions(new GIcon("https://chart.apis.google.com/chart?chst=d_map_xpin_letter&chld=pin_star|+|FF0000|FFFFFF|FFD700")));
        //        GInfoWindowOptions windowOptions = new GInfoWindowOptions();
        //        GInfoWindow commonInfoWindow = new GInfoWindow(marker, vBubbleText.ToString(), false);
        //        GMap1.Add(commonInfoWindow);



        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }

        //}

        protected void lstSearchResults_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {

            try
            {

                //GMap1.mapType = GMapType.GTypes.Hybrid;
                //GMap1.Add(GMapType.GTypes.Normal);      //.addMapType(GMapType.GTypes.Physical);
                //GMap1.Add(GMapType.GTypes.Physical);
                string _ListingNumber = "";
                string _PropertyType = "";


                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    _ListingNumber = DataBinder.Eval(e.Item.DataItem, "ListingNumber").ToString();
                    _PropertyType = DataBinder.Eval(e.Item.DataItem, "PropertyType").ToString();

                    // Retrieve the Hyperlink control in the current DataListItem.
                    HyperLink eLink = (HyperLink)e.Item.FindControl("hyperlinkListingDetail");
                    string _pageName = DataBinder.Eval(e.Item.DataItem, "Address").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + "_" + DataBinder.Eval(e.Item.DataItem, "Village").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + ".aspx";
                   
                  //  string vLink = Globals.NavigateURL(Int32.Parse(_FlexMLSPage.ToString()));
                  ////  var result = vLink.Substring(vLink.LastIndexOf('/') + 1);
                  //  vLink = vLink.ToString().Replace(result.ToString(), "tabid/" + _FlexMLSPage.ToString() + "/pg/v/MLS/" + _ListingNumber.ToString() + "/" + _pageName.ToString());

                    string vLink = Globals.NavigateURL(Int32.Parse(_FlexMLSPage.ToString()));

                    vLink = vLink.ToString() + "/pg/v/MLS/" + _ListingNumber.ToString() + "/" + _pageName.ToString();
                    
                    eLink.NavigateUrl = vLink.ToString();

                    //   HyperLinkVirtualTourLink
                    HyperLink VirtualTourLink = (HyperLink)e.Item.FindControl("HyperLinkVirtualTourLink");
                    Image VirtualTourImage = (Image)e.Item.FindControl("ImageVirtualTour1");
                    if (DataBinder.Eval(e.Item.DataItem, "VirtualTourLink").ToString().Trim() != "")
                    {
                        VirtualTourImage.Visible = true;
                        VirtualTourLink.Visible = true;
                        VirtualTourLink.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "VirtualTourLink").ToString();
                        VirtualTourLink.ToolTip = "Virtual Tour for MLS# " + _ListingNumber.ToString();
                    }
                    else
                    {
                        VirtualTourImage.Visible = false;
                        VirtualTourLink.Visible = false;
                    }

                    // END //HyperLinkVirtualTourLink


                    Label MLS = (Label)e.Item.FindControl("lblListingNumber");
                    //           MLS.Text = "MLS " + _ListingNumber.ToString();

                    // lblLotSquareFootage
                    Label LotSquareFootage = (Label)e.Item.FindControl("lblLotSquareFootage");
                    double sqft = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Acres"));
                    if (sqft > 0)
                    {
                        LotSquareFootage.Text = Math.Round(sqft, 2).ToString() + " Acres";
                    }

                    if (_PropertyType.ToString().ToUpper() == "COND" || _PropertyType.ToString().ToUpper() == "COMM")
                    {
                        LotSquareFootage.Text = DataBinder.Eval(e.Item.DataItem, "Complex").ToString();    //CONDO COMPLEX NAME
                    }

                    Label ListingStatus = (Label)e.Item.FindControl("lblListingStatus");
                    string _listingstatus = DataBinder.Eval(e.Item.DataItem, "StatusCode").ToString();
                    ListingStatus.Text = _listingstatus.ToString();

                    Label MLNumber = (Label)e.Item.FindControl("lblMLNumber");
                    MLNumber.Text = "MLS # " + _ListingNumber.ToString();

                    //lblBedsBaths
                    string _S_baths = "";
                    string _S_beds = "";
                    string _S_halfbaths = "";
                    if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString()) > 1)
                    {
                        _S_beds = "s";
                    }
                    if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "FullBaths").ToString()) > 1)
                    {
                        _S_baths = "s";
                    }

                    Label BedsBaths = (Label)e.Item.FindControl("lblBedsBaths");




                    if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString()) > 0)
                    {
                        BedsBaths.Text = DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString() + " Bedroom" + _S_beds.ToString();
                    }
                    if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "FullBaths").ToString()) > 0)
                    {
                        BedsBaths.Text = BedsBaths.Text.ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "FullBaths").ToString() + " Full Bath" + _S_baths.ToString();
                    }

                    if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "HalfBaths").ToString()) > 0)
                    {
                        BedsBaths.Text = BedsBaths.Text.ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "HalfBaths").ToString() + " Half Bath" + _S_halfbaths.ToString();
                    }
                    if (_PropertyType.ToString() == "COMM" || _PropertyType.ToString() == "MULT")
                    {
                        BedsBaths.Text = DataBinder.Eval(e.Item.DataItem, "Style").ToString();
                    }


                    // lblLivingSpace  
                    Label SquareFootage = (Label)e.Item.FindControl("lblLivingSpace");
                    int livingspace = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "LivingSpace").ToString());
                    SquareFootage.Text = livingspace.ToString("##,###") + " Sqft.";

                    // lblAddress

                    HyperLink Address = (HyperLink)e.Item.FindControl("hyperlinkListingAddress");
                    //HyperLinkImage
                    HyperLink ImageLink = (HyperLink)e.Item.FindControl("HyperLinkImage");

                    string _UnitNumber = "";
                    if (DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString().Length >= 1 && DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString() != "0")
                    {
                        _UnitNumber = " #" + DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString();
                    }

                    Address.Text = DataBinder.Eval(e.Item.DataItem, "Address").ToString() + " " + _UnitNumber.ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "Village").ToString();
                    string BubbleAddress = Address.Text.ToString();
                    Address.NavigateUrl = vLink.ToString();
                    ImageLink.NavigateUrl = vLink.ToString();
                    // lblListingPrice
                    Label ListingPrice = (Label)e.Item.FindControl("lblListingPrice");
                    //  ListingPrice.Text = String.Format("{0:C0}",Int32.Parse(DataBinder.Eval(e.Item.DataItem, "ListingPrice").ToString()));
                    string vListingPrice = DataBinder.Eval(e.Item.DataItem, "ListingPrice").ToString();
                    string vOriginalListingPrice = DataBinder.Eval(e.Item.DataItem, "originalListPrice").ToString();
                    ListingPrice.Text = String.Format("{0:C0}", double.Parse(vListingPrice.ToString()));

                    //imgPriceChange
                    //   double.Parse
                    //   Double.Parse
                    Image PriceChangeImage = (Image)e.Item.FindControl("imgPriceChange");
                    if (double.Parse(vListingPrice.ToString()) < double.Parse(vOriginalListingPrice.ToString()))
                    {
                        double _priceChange = double.Parse(vOriginalListingPrice.ToString()) - double.Parse(vListingPrice.ToString());
                        string _priceChangeAmt = String.Format("{0:C0}", _priceChange);
                        PriceChangeImage.Visible = true;
                        PriceChangeImage.ToolTip = _priceChangeAmt.ToString() + " Price Reduction";
                    }
                    else
                    {
                        PriceChangeImage.Visible = false;
                    }


                    //lblYearBuilt
                    Label YearBuilt = (Label)e.Item.FindControl("lblYearBuilt");
                    YearBuilt.Text = DataBinder.Eval(e.Item.DataItem, "PropertySubType1").ToString() + "<br />Built In " + DataBinder.Eval(e.Item.DataItem, "YearBuilt").ToString();

                    // CHECK FOR LAND LISTING
                    if (_PropertyType.ToString() == "LOTL" || _PropertyType.ToString() == "MULT")
                    {
                        YearBuilt.Text = DataBinder.Eval(e.Item.DataItem, "PropertySubType1").ToString();
                    }


                    // FIND fotorama DIV

                    //HtmlGenericControl DIVfotorama = e.Item.FindControl("fotorama") as HtmlGenericControl;


                    //DIVfotorama.Attributes.Add("data-minwidth", _maxThumbSize.ToString());
                    //DIVfotorama.Attributes.Add("data-maxwidth", _maxThumbSize.ToString());

                    // IMAGE
                    Image ListingImage = (Image)e.Item.FindControl("imgListingImage");
                    // ListingImage.ImageUrl = "~/DesktopModules/GIBS/FlexMLS/ImageHandler.ashx?MlsNumber=" + _ListingNumber.ToString() + "&MaxSize=" + _maxThumbSize.ToString();

                  

                    string checkImage = _MLSImagesURL.ToString() + _ListingNumber.ToString() + ".jpg";

                    if (UrlExists(checkImage.ToString()) == true)
                    {
                        // ListingImage.ImageUrl = checkImage.ToString();
                        ListingImage.ImageUrl = _MLSImagesURL.ToString() + _ListingNumber.ToString() + ".jpg";

                    }
                    else if (UrlExists(_MLSImagesURL.ToString() + _ListingNumber.ToString() + "_1.jpg") == true)
                    {
                        //
                        ListingImage.ImageUrl = _MLSImagesURL.ToString() + _ListingNumber.ToString() + "_1.jpg";

                    }
                    else
                    {

                        ListingImage.ImageUrl = _MLSImagesURL.ToString() + "NoImage.jpg";

                        ImageNeeded(_ListingNumber.ToString());
                    }

                    ListingImage.ToolTip = "MLS Listing " + _ListingNumber.ToString();
                    ListingImage.AlternateText = "MLS Listing " + _ListingNumber.ToString();


                    //  ListingImage.Width = 175;

                    // CHECK IF AUTHENTICATED
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        // lblMarketingRemarks
                        Label MarketingRemarks = (Label)e.Item.FindControl("lblMarketingRemarks");
                        MarketingRemarks.Text = DataBinder.Eval(e.Item.DataItem, "PublicRemarks").ToString();

                        ////tblRegisteredUsersContent
                      //  string _dom = (DateTime.Today - DateTime.Parse(DataBinder.Eval(e.Item.DataItem, "InsertDate").ToString())).TotalDays.ToString();

                        string _dom = DataBinder.Eval(e.Item.DataItem, "DOM").ToString();

                        PlaceHolder RegisteredUsersContent = (PlaceHolder)e.Item.FindControl("PlaceHolder_RegisterUserContent");
                        Literal RegUserContent = new Literal();
                        RegUserContent.Text = "<div class=\"RegisterUserContent\"><ul><li>Days on Market: "
                            + _dom.ToString()
                            + "</li></ul></div>";
                        // + "</li><li>Original List Price: " + String.Format("{0:C0}", double.Parse(DataBinder.Eval(e.Item.DataItem, "OriginalListPrice").ToString())) + "</li></ul></div>";


                        RegisteredUsersContent.Controls.Add(RegUserContent);

                        ////if (item.InteriorFeatures.Length > 1)
                        ////{

                        //HtmlTableRow tRow = new HtmlTableRow();
                        //HtmlTableCell tb_l = new HtmlTableCell();
                        //HtmlTableCell tb_r = new HtmlTableCell();
                        //tb_l.Attributes.Add("class", "featurelabel");
                        //tb_r.Attributes.Add("class", "featuredata");
                        //tb_l.InnerHtml = "Days on Market";
                        //tb_r.InnerHtml = DataBinder.Eval(e.Item.DataItem, "DOM").ToString();
                        //tRow.Controls.Add(tb_l);
                        //tRow.Controls.Add(tb_r);

                        //RegisteredUsersContent.Rows.Add(tRow);

                        //AddToTableRegisteredUsersContent("Days on Market", DataBinder.Eval(e.Item.DataItem, "DOM").ToString(), RegisteredUsersContent);
                        ////}
                    }



                    //HyperLinkInquiry - CONTACT FORM
                    HyperLink InquiryHyperLink = (HyperLink)e.Item.FindControl("HyperLinkInquiry");

                    string InquiryLink = vLink.ToString().Replace("pg/v", "pg/Contact");
                    InquiryHyperLink.NavigateUrl = InquiryLink.ToString();

                    //HyperLinkShowing - SCHEDULE A SHOWING
                    HyperLink ShowingHyperLink = (HyperLink)e.Item.FindControl("HyperLinkShowing");
                    string ShowingLink = vLink.ToString().Replace("pg/v", "pg/Contact/Schedule/Showing");
                    ShowingLink = ShowingLink.ToString().Replace("ctl/View/", "");
                    ShowingHyperLink.NavigateUrl = ShowingLink.ToString();

                    //HyperLinkInquiry - TELL A FRIEND FORM
                    HyperLink TellFriendHyperLink = (HyperLink)e.Item.FindControl("HyperLinkTellAFriend");
                    if (this.UserId > -1)
                    {              
                        string TellAFriendLink = vLink.ToString().Replace("pg/v", "pg/TellAFriend");
                        TellAFriendLink = TellAFriendLink.ToString().Replace("ctl/View/", "");
                        TellFriendHyperLink.NavigateUrl = TellAFriendLink.ToString();
                    }
                    else
                    {
                        TellFriendHyperLink.Visible = false;
                                        
                    }





                    //// ADD TO MAP
                    //double _lat = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Latitude").ToString());
                    //double _log = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Longitude").ToString());
                    //string _bubbleText = "<div style='width:270px;height:120px;'><img src='" + "/DesktopModules/GIBS/FlexMLS/ImageHandler.ashx?MlsNumber=" + _ListingNumber.ToString() + "&MaxSize=140' id='" + _ListingNumber.ToString() + "' align='right' alt='" + BubbleAddress.ToString() + "' style='border: 1px solid #000000;'>"
                    //    + Address.Text.ToString() + "<br />" + ListingPrice.Text.ToString()
                    //    + "<br /><a href='" + vLink.ToString() + "'>MLS " + _ListingNumber.ToString() + "<br />View Listing</a></div>";
                    ////  _bubbleText = "";
                    //if (_lat > 0)
                    //{
                    //    BuildGoogleMap(_lat, _log, _bubbleText.ToString());
                    //}



                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        //protected void lstSearchResults_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        //{

        //    try
        //    {

        //        GMap1.mapType = GMapType.GTypes.Hybrid;
        //        GMap1.Add(GMapType.GTypes.Normal);      //.addMapType(GMapType.GTypes.Physical);
        //        GMap1.Add(GMapType.GTypes.Physical);
        //        string _ListingNumber = "";
        //        string _PropertyType = "";


        //        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            _ListingNumber = DataBinder.Eval(e.Item.DataItem, "ListingNumber").ToString();
        //            _PropertyType = DataBinder.Eval(e.Item.DataItem, "PropertyType").ToString();

        //            string _UnitNumber = "";
        //            if (DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString().Length >= 1 && DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString() != "0")
        //            {
        //                _UnitNumber = " #" + DataBinder.Eval(e.Item.DataItem, "UnitNumber").ToString();
        //            }

        //            // Retrieve the Hyperlink control in the current DataListItem.
        //            HyperLink eLink = (HyperLink)e.Item.FindControl("hyperlinkListingDetail");
        //            string _pageName = DataBinder.Eval(e.Item.DataItem, "Address").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + "_" + DataBinder.Eval(e.Item.DataItem, "Village").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + ".aspx";
        //            string vLink = Globals.NavigateURL(Int32.Parse(_FlexMLSPage.ToString()));
        //            var result = vLink.Substring(vLink.LastIndexOf('/') + 1);
        //            vLink = vLink.ToString().Replace(result.ToString(), "tabid/" + _FlexMLSPage.ToString() + "/pg/v/MLS/" + _ListingNumber.ToString() + "/" + _pageName.ToString());
        //            eLink.NavigateUrl = vLink.ToString();

        //            //   HyperLinkVirtualTourLink
        //            HyperLink VirtualTourLink = (HyperLink)e.Item.FindControl("HyperLinkVirtualTourLink");
        //            Image VirtualTourImage = (Image)e.Item.FindControl("ImageVirtualTour1");
        //            if (DataBinder.Eval(e.Item.DataItem, "VirtualTourLink").ToString() != "")
        //            {
        //                VirtualTourImage.Visible = true;
        //                VirtualTourLink.Visible = true;
        //                VirtualTourLink.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "VirtualTourLink").ToString();
        //                VirtualTourLink.ToolTip = "Virtual Tour for MLS# " + _ListingNumber.ToString();
        //            }
        //            else
        //            {
        //                VirtualTourImage.Visible = false;
        //                VirtualTourLink.Visible = false;
        //            }


        //            Label MLS = (Label)e.Item.FindControl("lblListingNumber");
        //            //           MLS.Text = "MLS " + _ListingNumber.ToString();

        //            // lblLotSquareFootage
        //            Label LotSquareFootage = (Label)e.Item.FindControl("lblLotSquareFootage");
        //            double sqft = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Acres"));
        //            if (sqft > 0)
        //            {
        //                LotSquareFootage.Text = Math.Round(sqft, 2).ToString() + " Acres";
        //            }

        //            if (_PropertyType.ToString().ToUpper() == "COND" || _PropertyType.ToString().ToUpper() == "COMM")
        //            {
        //                LotSquareFootage.Text = DataBinder.Eval(e.Item.DataItem, "Complex").ToString();    //CONDO COMPLEX NAME
        //            }

        //            //lblMLNumber
        //            Label ListingNumber = (Label)e.Item.FindControl("lblMLNumber");
        //            ListingNumber.Text = "MLS # " + _ListingNumber.ToString();


        //            Label ListingStatus = (Label)e.Item.FindControl("lblListingStatus");
        //            string _listingstatus = GetStatusDesc(DataBinder.Eval(e.Item.DataItem, "ListingStatus").ToString());
        //            ListingStatus.Text = _listingstatus.ToString();

        //            //lblBedsBaths
        //            string _S_baths = "";
        //            string _S_beds = "";
        //            string _S_halfbaths = "";
        //            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString()) > 1)
        //            {
        //                _S_beds = "s";
        //            }
        //            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Bathrooms").ToString()) > 1)
        //            {
        //                _S_baths = "s";
        //            }

        //            Label BedsBaths = (Label)e.Item.FindControl("lblBedsBaths");




        //            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString()) > 0)
        //            {
        //                BedsBaths.Text = DataBinder.Eval(e.Item.DataItem, "Bedrooms").ToString() + " Bedroom" + _S_beds.ToString();
        //            }
        //            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "BathRooms").ToString()) > 0)
        //            {
        //                BedsBaths.Text = BedsBaths.Text.ToString() + " - " + DataBinder.Eval(e.Item.DataItem, "Bathrooms").ToString() + " Full Bath" + _S_baths.ToString();
        //            }

        //            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "HalfBathrooms").ToString()) > 0)
        //            {
        //                BedsBaths.Text = BedsBaths.Text.ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "HalfBathrooms").ToString() + " Half Bath" + _S_halfbaths.ToString();
        //            }
        //            if (_PropertyType.ToString() == "COMM" || _PropertyType.ToString() == "MULT")
        //            {
        //                BedsBaths.Text = DataBinder.Eval(e.Item.DataItem, "Style").ToString();
        //            }


        //            // lblLivingSpace  
        //            Label SquareFootage = (Label)e.Item.FindControl("lblLivingSpace");
        //            int livingspace = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "LivingSpace").ToString());
        //            SquareFootage.Text = livingspace.ToString("##,###") + " Sqft.";

        //            // lblAddress

        //            HyperLink Address = (HyperLink)e.Item.FindControl("hyperlinkListingAddress");
                    
        //            Address.Text = DataBinder.Eval(e.Item.DataItem, "Address").ToString() + _UnitNumber.ToString() + "<br />" + DataBinder.Eval(e.Item.DataItem, "Village").ToString();
        //            string BubbleAddress = Address.Text.ToString().Replace("<br />", ", ").ToString();
        //            Address.NavigateUrl = vLink.ToString();

        //            // lblListingPrice
        //            Label ListingPrice = (Label)e.Item.FindControl("lblListingPrice");
        //            //  ListingPrice.Text = String.Format("{0:C0}",Int32.Parse(DataBinder.Eval(e.Item.DataItem, "ListingPrice").ToString()));
        //            string vListingPrice = "0";
        //            vListingPrice = DataBinder.Eval(e.Item.DataItem, "ListingPrice").ToString();
        //            ListingPrice.Text = String.Format("{0:C0}", Int32.Parse(vListingPrice.ToString()));


        //            string vOriginalListingPrice = DataBinder.Eval(e.Item.DataItem, "originalListPrice").ToString();
        //            Image PriceChangeImage = (Image)e.Item.FindControl("imgPriceChange");
        //            if (double.Parse(vListingPrice.ToString()) < double.Parse(vOriginalListingPrice.ToString()))
        //            {
        //                double _priceChange = double.Parse(vOriginalListingPrice.ToString()) - double.Parse(vListingPrice.ToString());
        //                string _priceChangeAmt = String.Format("{0:C0}", _priceChange);
        //                PriceChangeImage.Visible = true;
        //                PriceChangeImage.ToolTip = _priceChangeAmt.ToString() + " Price Reduction";
        //            }
        //            else
        //            {
        //                PriceChangeImage.Visible = false;
        //            }




        //            //lblYearBuilt
        //            Label YearBuilt = (Label)e.Item.FindControl("lblYearBuilt");
        //            YearBuilt.Text = DataBinder.Eval(e.Item.DataItem, "PropertyTypeLookup").ToString() + "<br />Built In " + DataBinder.Eval(e.Item.DataItem, "YearBuilt").ToString();

        //            // CHECK FOR LAND LISTING
        //            if (_PropertyType.ToString() == "LOTL" || _PropertyType.ToString() == "MULT")
        //            {
        //                YearBuilt.Text = DataBinder.Eval(e.Item.DataItem, "PropertyTypeLookup").ToString();
        //            }


        //            // IMAGE
        //       //    string checkImage = "http://mls.gibs.com/images/" + _ListingNumber.ToString() + ".jpg";
        //            Image ListingImage = (Image)e.Item.FindControl("imgListingImage");



        //            string _content = DataBinder.Eval(e.Item.DataItem, "Address").ToString() + ", " + DataBinder.Eval(e.Item.DataItem, "Village").ToString();


        //            //ListingImage.ImageUrl = "~/DesktopModules/GIBS/FlexMLS/ImageHandler.ashx?MlsNumber=" + _ListingNumber.ToString() + "&MaxSize=" + _maxThumbSize.ToString();        //checkImage.ToString();
        //          //  ListingImage.ImageUrl = "http://mls.gibs.com/images/" + _ListingNumber.ToString() + ".jpg";



        //            string checkImage = "http://mls.gibs.com/images/" + _ListingNumber.ToString() + ".jpg";

        //            if (UrlExists(checkImage.ToString()) == true)
        //            {
        //                // ListingImage.ImageUrl = checkImage.ToString();
        //                ListingImage.ImageUrl = "http://mls.gibs.com/images/" + _ListingNumber.ToString() + ".jpg";

        //            }
        //            else if (UrlExists("http://mls.gibs.com/images/" + _ListingNumber.ToString() + "_1.jpg") == true)
        //            {
        //                //
        //                ListingImage.ImageUrl = "http://mls.gibs.com/images/" + _ListingNumber.ToString() + "_1.jpg";

        //            }
        //            else
        //            {

        //                ListingImage.ImageUrl = "http://mls.gibs.com/images/NoImage.jpg";

        //                ImageNeeded(Int32.Parse(_ListingNumber.ToString()));
        //            }


                    
        //            ListingImage.AlternateText = "MLS Listing " + _ListingNumber.ToString() + " - " + _content.ToString();
        //            ListingImage.ToolTip = "MLS " + _ListingNumber.ToString() + " - " + _content.ToString();

        //            // CHECK IF AUTHENTICATED
        //            if (HttpContext.Current.User.Identity.IsAuthenticated)
        //            {
        //                // lblMarketingRemarks
        //                Label MarketingRemarks = (Label)e.Item.FindControl("lblMarketingRemarks");
        //                MarketingRemarks.Text = DataBinder.Eval(e.Item.DataItem, "PublicRemarks").ToString();
        //            }

                    
        //            //HyperLinkInquiry - CONTACT FORM
        //            HyperLink InquiryHyperLink = (HyperLink)e.Item.FindControl("HyperLinkInquiry");
                 
        //            string InquiryLink = vLink.ToString().Replace("pg/v", "pg/Contact");
        //            InquiryHyperLink.NavigateUrl = InquiryLink.ToString();

        //            //HyperLinkShowing - SCHEDULE A SHOWING
        //            HyperLink ShowingHyperLink = (HyperLink)e.Item.FindControl("HyperLinkShowing");
        //            string ShowingLink = vLink.ToString().Replace("pg/v", "pg/Contact/Schedule/Showing");
        //            ShowingLink = ShowingLink.ToString().Replace("ctl/View/", "");
        //            ShowingHyperLink.NavigateUrl = ShowingLink.ToString();

        //            //HyperLinkInquiry - TELL A FRIEND FORM
        //            HyperLink TellFriendHyperLink = (HyperLink)e.Item.FindControl("HyperLinkTellAFriend");
        //            string TellAFriendLink = vLink.ToString().Replace("pg/v", "pg/TellAFriend");

        //            TellAFriendLink = TellAFriendLink.ToString().Replace("ctl/View/", "");
        //            TellFriendHyperLink.NavigateUrl = TellAFriendLink.ToString();


        //            // ADD TO MAP
        //            double _lat = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Latitude").ToString());
        //            double _log = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Longitude").ToString());

        //            string _bubbleText = "<div style='width:270px;height:120px;'><img src='" + "/DesktopModules/GIBS/FlexMLS/ImageHandler.ashx?MlsNumber="
        //                                    + _ListingNumber.ToString() + "&MaxSize=140' id='" + _ListingNumber.ToString()
        //                                    + "' align='right' alt='" + BubbleAddress.ToString() + "' style='border: 1px solid #000000;'>"
        //                                    + Address.Text.ToString() + "<br />" + ListingPrice.Text.ToString()
        //                                    + "<br /><a href='" + vLink.ToString() + "'>MLS " + _ListingNumber.ToString() + "<br />View Listing</a></div>";
                    
        //            if (_lat > 0)
        //            {
        //                BuildGoogleMap(_lat, _log, _bubbleText.ToString());
        //            }



        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }

        //}

        public void ImageNeeded(string listingNumber)
        {
            try
            {

                FlexMLSController controller = new FlexMLSController();
                FlexMLSInfo item = new FlexMLSInfo();

                item.ListingNumber = listingNumber;

                controller.FlexMLS_ImagesNeeded_Insert(item);

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public string GetStatusDesc(string Status)
        {

            try
            {
                string myRetValue = "";
                switch (Status)
                {
                    case "A":
                        myRetValue = "Active";
                        break;
                    case "C":
                        myRetValue = "Pending with Contingencies";
                        break;

                    default:
                        myRetValue = "";
                        break;
                }
                return myRetValue.ToString();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
                return "Error";
            }

        }


        private static bool UrlExists(string url)
        {
            try
            {
                new System.Net.WebClient().DownloadData(url);
                return true;
            }
            catch (System.Net.WebException e)
            {
                if (((System.Net.HttpWebResponse)e.Response).StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                else
                    throw;
            }
        }






    }
}