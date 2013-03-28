using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using NUnit.Framework;

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
        public Code.GeoIP GetGeoIP(string ip)
        {
            string url = "http://freegeoip.net/json/" + ip; //System.Web.Configuration.WebConfigurationManager.AppSettings["geo-ip-provider"] + ip;

            WebRequest req = WebRequest.Create(url);
            //req.Credentials = CredentialCache.DefaultCredentials;
            WebResponse resp = req.GetResponse();

            Code.GeoIP geo = new Code.GeoIP();
            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
                string responseFromServer = reader.ReadToEnd();
                geo = JsonConvert.DeserializeObject<Assets.Code.GeoIP>(responseFromServer);
            }
            return geo;
        }
    }
}
