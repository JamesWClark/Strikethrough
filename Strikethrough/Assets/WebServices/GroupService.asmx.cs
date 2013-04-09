using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for GroupService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GroupService : System.Web.Services.WebService
    {
        WebServices.DataHandler handler;

        [WebMethod]
        public void CreateGroup(string GroupId, string GroupName, string UserId)
        {
            handler = new WebServices.DataHandler();

            string insert =
                "INSERT INTO user_Groups (GroupId, GroupName, UserId) " +
                "VALUES ('" + GroupId + "','" + GroupName + "','" + UserId + "')";

            handler.ExecuteNonQuery(insert);
        }
        [WebMethod]
        public DataTable GetGroupList(string UserId)
        {
            handler = new WebServices.DataHandler();
            string select = "SELECT * FROM user_Groups WHERE TeacherId = '" + UserId + "'";
            return handler.GetDataTable(select);
        }
    }
}
