using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Members
{
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool hasMessage = false;
            bool.TryParse(Request.QueryString["created"], out hasMessage);
            if (hasMessage == true)
                lblMessage.Text = "Group successfully created.";
        }
    }
}