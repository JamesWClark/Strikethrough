using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Admin
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            /*
            string path = HttpContext.Current.Server.MapPath("~/Admin/Queries/");

            string[] files = Directory.GetFiles(path);  //(path,"*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                lblStub.Text += "<br />" + file;
            }
            */
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}