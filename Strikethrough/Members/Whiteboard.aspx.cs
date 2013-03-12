using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Members
{
    public partial class Whiteboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //web service
            Assets.WebServices.DataHandler db = new Assets.WebServices.DataHandler();

            //get UserId (Guid) as string type
            string userName = User.Identity.Name;
            string select = "SELECT UserId FROM aspnet_Users WHERE UserName = '" + userName + "'";
            
            //build insert
            string userId = db.ExecuteScalar(select);
            string canvasId = Guid.NewGuid().ToString();
            string dataUrl = hiddenDataUrl.Value;
            string label = txtCanvasName.Value;

            string insert = "INSERT INTO user_Canvas (CanvasId, UserId, DataUrl, Label) VALUES ('"
                + canvasId + "','"
                + userId + "','"
                + dataUrl + "','"
                + label + "')";

            //execute
            db.ExecuteNonQuery(insert);
        }
    }
}