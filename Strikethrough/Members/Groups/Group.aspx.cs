using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.Code;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members.Groups
{
    public partial class Group : System.Web.UI.Page
    {
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string groupId = PreviousPage.Value;
            GroupService service = new GroupService();
            DataTable dtStudentsInGroup = service.GetUsersInGroup(groupId);
            GroupFactory.BuildPlaceHolder(phUsers, dtStudentsInGroup);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}