using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.Modules.FlexMLS_List.Components
{
    public class FlexMLS_ListInfo
    {
        //private vars exposed thro the
        //properties
        private int moduleId;
        private int itemId;
        private string yearBuilt;
        private int createdByUser;
        private DateTime createdDate;
        private string createdByUserName = null;


        /// <summary>
        /// empty cstor
        /// </summary>
        public FlexMLS_ListInfo()
        {
        }


        #region properties

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string YearBuilt
        {
            get { return yearBuilt; }
            set { yearBuilt = value; }
        }

        public int CreatedByUser
        {
            get { return createdByUser; }
            set { createdByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string CreatedByUserName
        {
            get
            {
                if (createdByUserName == null)
                {
                    int portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
                    UserInfo user = UserController.GetUserById(portalId, createdByUser);
                    createdByUserName = user.DisplayName;
                }

                return createdByUserName;
            }
        }

        #endregion
    }
}
