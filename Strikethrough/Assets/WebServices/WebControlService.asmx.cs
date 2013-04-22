using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for WebControlService
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebControlService : System.Web.Services.WebService
    {
        /*
         * This method generates LinkButton controls from the key/value pairs of any DataTable
         * first column is the key, and second is the value, such as groupid/groupname or userid/username.
         * example: EA9C9EFE-A774-4996-96DF-19116E1B9FEA, Label
         */

        [WebMethod]
        public void BuildPlaceHolder(PlaceHolder placeHolder, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i].ItemArray[1].ToString();
                string id = table.Rows[i].ItemArray[0].ToString();

                LinkButton b = new LinkButton();
                b.CssClass = "dynamic-placeholder-linkbutton";
                b.Text = name;
                b.CommandArgument = id;
                b.CommandName = name;

                placeHolder.Controls.Add(b);
            }
        }
    }
}
