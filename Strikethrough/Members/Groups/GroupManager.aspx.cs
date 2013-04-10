using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.Code;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members
{
    public partial class GroupManager : System.Web.UI.Page
    {
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            GroupService service = new GroupService();

            DataTable dtSuperviorOf = service.GetSupervisorOfData(userId);
            DataTable dtMemberOf = service.GetMemberOfData(userId);
            DataTable dtHasTeachers = service.GetHasTeachersData(userId);

            GroupFactory.BuildPlaceHolder(phSupervisorOf, dtSuperviorOf);
            GroupFactory.BuildPlaceHolder(phMemberOf, dtMemberOf);
            GroupFactory.BuildPlaceHolder(phHasTeachers, dtHasTeachers);
        }
        //mostly used to set messages on this page
        protected void Page_Load(object sender, EventArgs e)
        {
            //see if this is redirected with a query string, display a message if yes
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            if (hasMessage == true)
                lblMessage.Text = "Group successfully created.";

            //supervisorOf
            if (phSupervisorOf.Controls.Count > 0)
                lblSupervisorOf.Text = "You supervise the following groups: ";
            else
                lblSupervisorOf.Text = "You are not supervising any groups.";

            //memberOf
            if (phMemberOf.Controls.Count > 0)
                lblMemberOf.Text = "You are a member of the following groups: ";
            else
                lblMemberOf.Text = "You do not belong to anyone else's groups.";

            //hasTeacher
            if (phHasTeachers.Controls.Count > 0)
                lblHasTeachers.Text = "You added the following teachers: ";
            else
                lblHasTeachers.Text = "You have not added any teachers.";
        }
    }
}