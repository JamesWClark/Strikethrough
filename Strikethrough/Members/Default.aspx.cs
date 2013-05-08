using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members
{
    public partial class Default : System.Web.UI.Page
    {
        string userId = Membership.GetUser().ProviderUserKey.ToString();        

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Session.Clear();
            WebControlService wcs = new WebControlService();

            //Groups
            GroupService groupService = new GroupService();
            DataTable dtSuperviorOf = groupService.GetTable(userId, "supervisorOf");
            DataTable dtMemberOf = groupService.GetTable(userId, "memberOf");
            wcs.BuildPlaceHolder(phSupervisorOf, dtSuperviorOf);
            wcs.BuildPlaceHolder(phMemberOf, dtMemberOf);

            //Whiteboards
            CanvasService canvasService = new CanvasService();
            DataTable dtWhiteboards = canvasService.GetTable(userId, "whiteboard");
            wcs.BuildPlaceHolder(phWhiteboards, dtWhiteboards);

            //Notifications
            NotifcationService notificationService = new NotifcationService();
            //DataTable dtProspectiveStudents = notificationService.GetProspectiveStudentsData(userId);
            
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLabels();
            RegisterEvents();
        }
        private void LoadLabels()
        {
            GroupService groupService = new GroupService();

            //see if this is redirected with a query string, display a message if yes
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            //if (hasMessage == true)
                //lblMessage.Text = "Operation successfully completed.";

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

            /*
            //hasTeacher
            if (phHasTeachers.Controls.Count > 0)
                lblHasTeachers.Text = "You added the following teachers: ";
            else
                lblHasTeachers.Text = "You have not added any teachers.";
                         * */

            //hasPropsectiveStudent
            if (groupService.GetProspectiveStudentCount(userId) > 0)
            {
                lblHasProspectiveStudents.Text = "You have prospective students.";
                btnAddStudents.Visible = true;
            }
            else
                lblHasProspectiveStudents.Text = "No students have added you";

        }
        private void RegisterEvents()
        {
            PlaceHolder_RegisterChildren(phSupervisorOf, "supervisorOf");
            PlaceHolder_RegisterChildren(phMemberOf, "memberOf");
            PlaceHolder_RegisterChildren(phWhiteboards, "whiteboard");
        }
        public void PlaceHolder_RegisterChildren(PlaceHolder parent, string command)
        {
            if (parent.Controls.Count > 0)
            {
                foreach (Control c in parent.Controls)
                {
                    LinkButton link = (LinkButton)c;

                    switch (command)
                    {
                        case "supervisorOf":
                        case "memberOf":
                            link.Command += Group_LinkButton_Click;
                            break;
                        case "hasTeachers":
                            break;
                        case "whiteboard":
                            link.Command += Whiteboard_LinkButton_Click;
                            break;
                    }
                }
            }
        }
        private void Whiteboard_LinkButton_Click(object sender, CommandEventArgs e)
        {
            SetKeys(e);
            Response.Redirect("~/Members/Whiteboard.aspx");
        }
        private void Group_LinkButton_Click(object sender, CommandEventArgs e)
        {
            SetKeys(e);
            Response.Redirect("~/Members/Groups/Group.aspx");
        }
        private void SetKeys(CommandEventArgs e)
        {
            Session["Key"] = e.CommandName.ToString(); //should be a label of sorts
            Session["Value"] = e.CommandArgument.ToString(); //should be a GUID
        }

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Members/Groups/AddStudents.aspx");
        }
    }
}