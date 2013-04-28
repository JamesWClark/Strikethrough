using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for NotifcationService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NotifcationService : System.Web.Services.WebService
    {
        DataHandler handler;

        [WebMethod]
        public DataTable GetProspectiveStudentsData(string UserId)
        {
            handler = new DataHandler();
            string select =
                "SELECT aspnet_Users.UserName, aspnet_Users.UserId " +
                "FROM user_UserHasTeachers, aspnet_Users " +
                "WHERE TeacherId = '" + UserId + "' " +
                "AND aspnet_Users.UserId = user_UserHasTeachers.UserId " +
                "AND aspnet_Users.UserId NOT IN " +
                    "(SELECT UserId FROM user_UsersInGroups)";

            return handler.GetDataTable(select);
        }
    }
}
