using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (User.Identity.IsAuthenticated == true)
                Response.Redirect("~/Members/Default.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}