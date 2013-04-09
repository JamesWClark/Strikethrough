using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Members
{
    public partial class GroupManager : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Assets.WebServices.GroupService groupService = new Assets.WebServices.GroupService();
            //get group list for the current logged in user
            DataTable groupList = groupService.GetGroupList(Membership.GetUser().ProviderUserKey.ToString());


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            if (hasMessage == true)
                lblMessage.Text = "Group successfully created.";
        }
    }
}