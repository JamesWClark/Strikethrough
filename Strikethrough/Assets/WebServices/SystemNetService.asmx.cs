using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for SystemNetService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SystemNetService : System.Web.Services.WebService
    {
        [WebMethod]
        public void ExecuteNonQuery(string query)
        {

        }
    }
}
