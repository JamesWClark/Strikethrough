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

namespace Strikethrough.Members
{
    public partial class Whiteboard : System.Web.UI.Page
    {
        private string key;
        private string value;

        /*
        private string userId = Membership.GetUser().ProviderUserKey.ToString();
        //web service
        private Assets.WebServices.DataHandler db = new Assets.WebServices.DataHandler();
        private Assets.WebServices.GroupService service = new Assets.WebServices.GroupService();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            string canvasId = (string)Session["Value"];
            //lblMessage.Text = canvasId; //stub

            if (canvasId != null)
            {
                string select = "SELECT DataUrl FROM user_Canvas WHERE CanvasId = '" + canvasId + "'";
                string dataUrl = db.ExecuteScalar(select);
                hiddenCanvasId.Value = canvasId;
                hiddenDataUrl.Value = dataUrl;
            }

            DataTable dtGroups = service.GetSupervisorOfData(userId);
            ddlGroups.DataSource = dtGroups;
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupId";
            ddlGroups.DataBind();
            ddlGroups.Items.Insert(0, "Assign this whiteboard to a group");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
              */
        protected override void OnInit(EventArgs e)
        {
            key = (string)Session["Key"];
            value = (string)Session["Value"];
            if (key != String.Empty)
            {
                LoadDocument();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string json = documentJSON.Value; //javascript parses the canvas pages into a json object of dataurls (stored in the DOM as hidden value)
            
            Session["DocumentMode"] = "create";
            Session["Document"] = json;
            
            Response.Redirect("SaveCanvas.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Members/Default.aspx");
        }
        private void LoadDocument()
        {
            lblHeader.Text = key;

        }
    }
}