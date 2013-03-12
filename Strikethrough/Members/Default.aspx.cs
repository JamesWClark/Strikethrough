using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Members
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void hiddenUserId_Init(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser();
            hiddenUserId.Value = currentUser.ProviderUserKey.ToString();
        }
        //bind data source
        protected void ddlOpen_Init(object sender, EventArgs e)
        {
            dsCanvasId.ConnectionString = ConfigurationManager.ConnectionStrings["Strikethrough_DevConnectionString"].ConnectionString;
            MembershipUser currentUser = Membership.GetUser();
            string userId = currentUser.ProviderUserKey.ToString();
            dsCanvasId.SelectCommand = "SELECT CanvasId, Label FROM user_Canvas WHERE UserId = '" + userId + "'";
            ddlOpen.DataSource = dsCanvasId;
            ddlOpen.DataBind();
            ddlOpen.DataValueField = "CanvasId";
            ddlOpen.DataTextField = "Label";
            ddlOpen.Items.Insert(0, new ListItem("Open an Existing Whiteboard", "Placeholder"));
        }

        protected void ddlOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string canvasId = ddlOpen.SelectedValue;
            Response.Redirect("Whiteboard.aspx?CanvasId=" + canvasId);
        }
    }
}