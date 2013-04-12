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
    public partial class AddStudents : System.Web.UI.Page
    {
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            GroupFactory.BuildStudentProspectTable(tblProspectiveStudents, userId);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GroupFactory.AssignProspectsToGroups(tblProspectiveStudents, userId);
            Response.Redirect("GroupManager.aspx?created=true"); //web service is catching errors, so this may actuall say true when in fact it fails
        }
    }
}