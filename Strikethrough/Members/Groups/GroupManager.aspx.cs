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

            //(teacher) get a table of the groups this person is teaching
            DataTable teacherGroupTable = service.GetTeacherGroupTable(userId);

            //(membership) get a table of groups this person belongs to 
            DataTable memberGroupTable = service.GetMemberGroupTable(userId);

            //build the teacher list
            GroupFactory.BuildPlaceHolder(phTeacherList, teacherGroupTable);

            //build the membership list
            GroupFactory.BuildPlaceHolder(phMemberList, memberGroupTable);
        }
        //mostly used to set label text values (pertinent messages)
        protected void Page_Load(object sender, EventArgs e)
        {
            //see if this is redirected with a query string, display a message if yes
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            if (hasMessage == true)
                lblMessage.Text = "Group successfully created.";

            //display a message before the teaching list
            if (phTeacherList.Controls.Count > 0)
                lblTeacherMessage.Text = "You are teaching the following groups: ";
            else
                lblTeacherMessage.Text = "You are not teaching any groups.";

            //display a message before the member list
            if (phMemberList.Controls.Count > 0)
                lblMemberMessage.Text = "You are a member of the following groups: ";
            else
                lblMemberMessage.Text = "You do not belong to any groups.";
        }
    }
}