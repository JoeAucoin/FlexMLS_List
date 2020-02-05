using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.Modules.FlexMLS_List.Components
{
    public class FlexMLS_ListController : IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the FlexMLS_ListInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<FlexMLS_ListInfo> GetFlexMLS_Lists(int moduleId)
        {
            return CBO.FillCollection<FlexMLS_ListInfo>(DataProvider.Instance().GetFlexMLS_Lists(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public FlexMLS_ListInfo GetFlexMLS_List(int moduleId, int itemId)
        {
            return CBO.FillObject<FlexMLS_ListInfo>(DataProvider.Instance().GetFlexMLS_List(moduleId, itemId));

        }


        /// <summary>
        /// Adds a new FlexMLS_ListInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddFlexMLS_List(FlexMLS_ListInfo info)
        {
            //check we have some content to store
            if (info.YearBuilt != string.Empty)
            {
                DataProvider.Instance().AddFlexMLS_List(info.ModuleId, info.YearBuilt, info.CreatedByUser);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdateFlexMLS_List(FlexMLS_ListInfo info)
        {
            //check we have some content to update
            if (info.YearBuilt != string.Empty)
            {
                DataProvider.Instance().UpdateFlexMLS_List(info.ModuleId, info.ItemId, info.YearBuilt, info.CreatedByUser);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeleteFlexMLS_List(int moduleId, int itemId)
        {
            DataProvider.Instance().DeleteFlexMLS_List(moduleId, itemId);
        }


        #endregion

        //#region ISearchable Members

        ///// <summary>
        ///// Implements the search interface required to allow DNN to index/search the content of your
        ///// module
        ///// </summary>
        ///// <param name="modInfo"></param>
        ///// <returns></returns>
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        //{
        //    SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

        //    List<FlexMLS_ListInfo> infos = GetFlexMLS_Lists(modInfo.ModuleID);

        //    foreach (FlexMLS_ListInfo info in infos)
        //    {
        //        SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.YearBuilt, info.CreatedByUser, info.CreatedDate,
        //                                            modInfo.ModuleID, info.ItemId.ToString(), info.YearBuilt, "Item=" + info.ItemId.ToString());
        //        searchItems.Add(searchInfo);
        //    }

        //    return searchItems;
        //}

        //#endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<FlexMLS_ListInfo> infos = GetFlexMLS_Lists(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<FlexMLS_Lists>");
                foreach (FlexMLS_ListInfo info in infos)
                {
                    sb.Append("<FlexMLS_List>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.YearBuilt));
                    sb.Append("</content>");
                    sb.Append("</FlexMLS_List>");
                }
                sb.Append("</FlexMLS_Lists>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "FlexMLS_Lists");

            foreach (XmlNode info in infos.SelectNodes("FlexMLS_List"))
            {
                FlexMLS_ListInfo FlexMLS_ListInfo = new FlexMLS_ListInfo();
                FlexMLS_ListInfo.ModuleId = ModuleID;
                FlexMLS_ListInfo.YearBuilt = info.SelectSingleNode("content").InnerText;
                FlexMLS_ListInfo.CreatedByUser = UserID;

                AddFlexMLS_List(FlexMLS_ListInfo);
            }
        }

        #endregion
    }
}
