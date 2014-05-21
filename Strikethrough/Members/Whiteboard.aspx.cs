using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members
{
    public partial class Whiteboard : System.Web.UI.Page
    {


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string json = documentJSON.Value; //javascript parses the canvas pages into a json object of dataurls (stored in the DOM as hidden value)

            Session["Document"] = json;
            
            Response.Redirect("SaveCanvas.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Members/Default.aspx");
        }
        
    }
}