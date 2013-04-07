using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Strikethrough
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //http://www.asp.net/whitepapers/add-mobile-pages-to-your-aspnet-web-forms-mvc-application

            // Redirect mobile users to the mobile home page
            HttpRequest httpRequest = HttpContext.Current.Request;

            if (httpRequest.Browser.IsMobileDevice)
            {
                string path = httpRequest.Url.PathAndQuery;
                bool isOnMobilePage = path.StartsWith("/Mobile/",
                                       StringComparison.OrdinalIgnoreCase);
                if (!isOnMobilePage)
                {
                    string redirectTo = "~/Mobile/Default.aspx";

                    // Could also add special logic to redirect from certain 
                    // recognized pages to the mobile equivalents of those 
                    // pages (where they exist). For example,
                    // if (HttpContext.Current.Handler is UserRegistration)
                    //     redirectTo = "~/Mobile/Register.aspx";

                    HttpContext.Current.Response.Redirect(redirectTo);
                }
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        //http://www.asp.net/whitepapers/add-mobile-pages-to-your-aspnet-web-forms-mvc-application
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (string.Equals(custom, "isMobileDevice", StringComparison.OrdinalIgnoreCase))
                return context.Request.Browser.IsMobileDevice.ToString();

            return base.GetVaryByCustomString(context, custom);
        }
    }
}