using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.Code;

namespace Strikethrough.Members.Groups
{
    public partial class AddTeacher : System.Web.UI.Page
    {
        private string userId = Membership.GetUser().ProviderUserKey.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                GroupFactory.SubscribeToTeacher(txtTeacherEmail.Text, userId);
                Response.Redirect("../Default.aspx"); //web service is catching errors, so this may actuall say true when in fact it fails
            }
            catch (NullReferenceException)
            {
                lblMessage.Text = "Teacher not found.";
            }
        }
    }
}