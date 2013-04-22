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
        //private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string groupId = (string)Session["Value"];
            lblHeader.Text = (string)Session["Key"];
            GroupService service = new GroupService();
            DataTable dtStudents = service.GetUsersInGroup(groupId);
            GroupFactory.BuildPlaceHolder(phUsers, dtStudents);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}