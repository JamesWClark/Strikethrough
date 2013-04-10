using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.Code;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            GroupFactory.CreateGroup(txtGroupName.Text, userId);
            Response.Redirect("GroupManager.aspx?created=true");
        }
    }
}