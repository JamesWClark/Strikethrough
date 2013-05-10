using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for NotifcationService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com/notifcation")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NotifcationService : System.Web.Services.WebService
    {
        [WebMethod]
        public PlaceHolder BuildNotifications(string userId)
        {
            DataHandler handler = new DataHandler();

            string query;
            PlaceHolder ph = new PlaceHolder();
            DataTable[] tables = new DataTable[2];
            ArrayList messages = new ArrayList();

            GroupService groupService = new GroupService();

            //http://stackoverflow.com/questions/5672862/check-if-datetime-instance-falls-in-between-other-two-datetime-objects
            //notification: you added a teacher
            query =
                "SELECT * FROM user_UserHasTeachers " +
                "WHERE TeacherId = ''" +
                "ORDER BY Timestamp";
            tables[0] = handler.GetDataTable(query);



            foreach (DataRow row in tables[0].Rows)
            {

            }

            //make sense of the data tables
            //for each table
            foreach (DataTable dt in tables)
            {
                //check timestamp
                //insert into position
            }

            return ph;
        }
        //BuildNotifications is going to need a number of private methods. We'll start those here:
        
    }
}
