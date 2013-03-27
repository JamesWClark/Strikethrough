using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Strikethrough.Developers
{
    public partial class Net : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new HttpRequestWrapper(Page.Request);

            string ipString;
            if (string.IsNullOrEmpty(request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                ipString = request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ipString = request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            }

            IPAddress result;
            if (!IPAddress.TryParse(ipString, out result))
            {
                result = IPAddress.None;
            }

            string ip = result.ToString();

            Label1.Text = "Your IP address is: " + ip;

            SetLabel2(ip);
        }
        private void SetLabel2(string ip)
        {
            string url = "http://freegeoip.net/json/" + ip;
            WebRequest req = WebRequest.Create(url);
            //req.Credentials = CredentialCache.DefaultCredentials;
            WebResponse resp = req.GetResponse();

            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
                string responseFromServer = reader.ReadToEnd();
                Assets.Code.GeoIP geo = JsonConvert.DeserializeObject<Assets.Code.GeoIP>(responseFromServer);

                Label2.Text = geo.city;
            }
        }

    }
}