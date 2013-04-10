using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Strikethrough.Assets.WebServices;

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
        DataHandler handler;

        //web services throw errors differently. these shoudl return values or something instead, bc the app won't catch errors
        [WebMethod]
        public void CreateGroup(string GroupId, string GroupName, string UserId)
        {
            handler = new DataHandler();

            string insert =
                "INSERT INTO user_Groups (GroupId, GroupName, TeacherId) " +
                "VALUES ('" + GroupId + "','" + GroupName + "','" + UserId + "')";

            handler.ExecuteNonQuery(insert);
        }
        [WebMethod]
        public DataTable GetSupervisorOfData(string UserId)
        {
            handler = new DataHandler();
            string select = "SELECT * FROM user_Groups WHERE TeacherId = '" + UserId + "'";
            return handler.GetDataTable(select);
        }
        [WebMethod]
        public DataTable GetMemberOfData(string UserId)
        {
            handler = new DataHandler();
            string select =
                "SELECT * FROM user_Groups, user_UsersInGroups " + 
                "WHERE user_UsersInGroups.UserId = '" + UserId + "' " + 
                "AND user_Groups.GroupId = user_Groups.GroupId";

            return handler.GetDataTable(select);
        }
        [WebMethod]
        public DataTable GetHasTeachersData(string UserId)
        {
            handler = new DataHandler();
            string select =
                "SELECT user_UserHasTeachers.TeacherId, aspnet_Users.UserName " +
                "FROM user_UserHasTeachers, aspnet_Users " +
                "WHERE user_UserHasTeachers.TeacherId = aspnet_Users.UserId " +
                "AND user_UserHasTeachers.UserId = '" + UserId + "'";

            return handler.GetDataTable(select);
        }
    }
}
