using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.Code;

namespace Strikethrough.Members
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Assets.WebServices.GroupService service = new Assets.WebServices.GroupService();
            service.CreateGroup(Guid.NewGuid().ToString(), txtGroupName.Text, Membership.GetUser().ProviderUserKey.ToString());
            Response.Redirect("GroupManager.aspx?created=true");
        }
    }
}