using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for CanvasService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CanvasService : System.Web.Services.WebService
    {
        DataHandler handler = new DataHandler();

        [WebMethod]
        public Pair GetDimensions(int x, int y)
        {
            Pair p = new Pair(x, y);
            return p;
        }
        [WebMethod]
        public DataTable GetTable(string userId, string tableId)
        {
            switch (tableId)
            {
                case "whiteboard":
                    string query = "SELECT CanvasId, Label FROM user_Canvas WHERE UserId = '" + userId + "'";
                    return handler.GetDataTable(query);
            }
            return null;
        }
    }
}
