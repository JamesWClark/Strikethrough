using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Members
{
    public partial class Whiteboard : System.Web.UI.Page
    {
        //web service
        private Assets.WebServices.DataHandler db = new Assets.WebServices.DataHandler();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string canvasId = Request.QueryString["CanvasId"];

            if (canvasId != null)
            {
                string select = "SELECT DataUrl FROM user_Canvas WHERE CanvasId = '" + canvasId + "'";
                string dataUrl = db.ExecuteScalar(select);
                hiddenCanvasId.Value = canvasId;
                hiddenDataUrl.Value = dataUrl;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser();
            
            //build insert
            string userId = currentUser.ProviderUserKey.ToString();
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