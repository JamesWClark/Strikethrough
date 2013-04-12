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
        private string key;
        private string value;
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        #region Presentation Layer
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            PlaceHolder_Load();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLabels();
            PlaceHolder_RegisterChildren(phSupervisorOf, "supervisorOf");
            PlaceHolder_RegisterChildren(phMemberOf, "memberOf");
            PlaceHolder_RegisterChildren(phHasTeachers, "hasTeachers");
        }
        private void PlaceHolder_Load()
        {
            GroupService service = new GroupService();
            DataTable dtSuperviorOf = service.GetSupervisorOfData(userId);
            DataTable dtMemberOf = service.GetMemberOfData(userId);
            DataTable dtHasTeachers = service.GetHasTeachersData(userId);
            GroupFactory.BuildPlaceHolder(phSupervisorOf, dtSuperviorOf);
            GroupFactory.BuildPlaceHolder(phMemberOf, dtMemberOf);
            GroupFactory.BuildPlaceHolder(phHasTeachers, dtHasTeachers);
        }
        private void LoadLabels()
        {
            GroupService service = new GroupService();

            //see if this is redirected with a query string, display a message if yes
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            if (hasMessage == true)
                lblMessage.Text = "Operation successfully completed.";

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

            //hasPropsectiveStudent
            if (service.GetProspectiveStudentCount(userId) > 0)
                lblHasProspectiveStudents.Text = "You have prospective students.<br /><a href='AddStudents.aspx'>See who added you</a>";
            else
                lblHasProspectiveStudents.Text = "No students have added you";

        }
        #endregion

        #region Event Layer
        private void PlaceHolder_RegisterChildren(PlaceHolder parent, string command)
        {
            if (parent.Controls.Count > 0)
            {
                foreach (Control c in parent.Controls)
                {
                    LinkButton link = (LinkButton)c;
                    switch (command)
                    {
                        case "supervisorOf":
                            link.PostBackUrl = "Group.aspx";
                            this.key = link.CommandName;
                            this.value = link.CommandArgument;
                            break;
                        case "memberOf":
                            break;
                        case "hasTeachers":
                            break;
                    }
                }
            }
        }

        #endregion

        #region Page Properties
        //these are generic key value properties useful for passing a LinkButton name/argument pair to the requested page
        public string Key
        {
            get
            {
                return key;
            }
        }
        public string Value
        {
            get
            {
                return value;
            }
        }
        #endregion
    }
}