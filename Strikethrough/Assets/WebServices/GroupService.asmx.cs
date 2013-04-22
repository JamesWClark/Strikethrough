using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Strikethrough.Assets.WebServices;
using NUnit.Framework;

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

    [TestFixture]
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
        public DataTable GetTable(string userId, string tableId)
        {
            handler = new DataHandler();
            string select;

            switch (tableId)
            {
                case "supervisorOf":
                    select = "SELECT * FROM user_Groups WHERE TeacherId = '" + userId + "'";
                    return handler.GetDataTable(select);
                case "memberOf":
                    select =
                        "SELECT * FROM user_Groups, user_UsersInGroups " + 
                        "WHERE user_UsersInGroups.UserId = '" + userId + "' " + 
                        "AND user_Groups.GroupId = user_Groups.GroupId";
                    return handler.GetDataTable(select);
            }

            return null;
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
        [WebMethod]
        public int GetProspectiveStudentCount(string UserId)
        {
            handler = new DataHandler();
            //this find students that added a teacher but do not exist in their group
            //critical: needs to include a comparison to the teacher's groups
            //right now, a student could be in someone else's group and this would exlude from from this teacher's query
            string select =
                "SELECT COUNT(aspnet_Users.UserName) " +
                "FROM user_UserHasTeachers, aspnet_Users " +
                "WHERE TeacherId = '" + UserId + "' " +
                "AND aspnet_Users.UserId = user_UserHasTeachers.UserId " +
                "AND aspnet_Users.UserId NOT IN " +
	                "(SELECT UserId FROM user_UsersInGroups)";

            int count;
            int.TryParse(handler.ExecuteScalar(select), out count);
            return count;
        }
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
        [WebMethod]
        public void AddStudentToGroup(string userId, string groupId)
        {
            handler = new DataHandler();
            string insert =
                "INSERT INTO user_UsersInGroups (UserId, GroupId) VALUES ('" + userId + "','" + groupId + "')";
            handler.ExecuteNonQuery(insert);
        }
        [WebMethod]
        public DataTable GetUsersInGroup(string groupId)
        {
            handler = new DataHandler();
            string select =
                "SELECT aspnet_Users.UserId, aspnet_Users.UserName " +
                "FROM user_UsersInGroups, aspnet_Users " +
                "WHERE user_UsersInGroups.UserId = aspnet_Users.UserId " +
                "AND user_UsersInGroups.GroupId = '" + groupId + "'";
            return handler.GetDataTable(select);
        }
        #region TESTING
        /************************ TESTING ******************************/

        private string test_userId = "";
        private int test_numGroups = 0;
        DataHandler test_handler = new DataHandler();

        [SetUp]
        public void Test_Init()
        {
            //this is the NUnit test account for database operations
            test_userId = "2E7D538B-4C62-45B5-AF40-62EE3598E926";
            test_numGroups = 0;
        }
        [Test]
        public void Test_CreateGroup()
        {
            string selectNumGroups = "SELECT COUNT(TeacherId) FROM user_Groups WHERE TeacherId = '" + test_userId + "'";

            //should be zero
            test_numGroups = int.Parse(test_handler.ExecuteScalar(selectNumGroups));
            Assert.AreEqual(0, test_numGroups);

            //now do an insert
            CreateGroup(Guid.NewGuid().ToString(), "Test Group", test_userId);

            //should be 1
            test_numGroups = int.Parse(test_handler.ExecuteScalar(selectNumGroups));
            Assert.AreEqual(1, test_numGroups);
        }
        [TearDown]
        public void Test_TearDown()
        {
            string delete = "DELETE FROM user_Groups WHERE UserId = '" + test_userId + "'";
            test_handler.ExecuteNonQuery(delete);
        }
        #endregion
    }
}
