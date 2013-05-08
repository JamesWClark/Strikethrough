using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Members
{
    public partial class SaveCanvas : System.Web.UI.Page
    {
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        private DataHandler handler = new DataHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string mode = (string)Session["DocumentMode"];
            switch (mode)
            {
                case "create":
                    CreateDocument();
                    break;
                case "update":
                    UpdateDocument();
                    break;
            }
            Response.Redirect("~/Members/Default.aspx");
        }
        private void UpdateDocument()
        {
            DeleteDocument();
            CreateDocument();
        }
        private void DeleteDocument()
        {
            string documentId = (string)Session["Value"];
            string delete = "DELETE FROM user_Canvas WHERE DocumentId = '" + documentId + "'";
            handler.ExecuteNonQuery(delete);
        }
        private void CreateDocument()
        {
            //all about the json
            string json = (string)Session["Document"]; //the json document
            JObject pages = (JObject)JsonConvert.DeserializeObject(json); //turned into an object
            IList<string> jsonKeys = pages.Properties().Select(p => p.Name).ToList(); // with dynamic keys retrieved
            string[] jsonValues = new string[jsonKeys.Count]; // to access values for an array

            string documentId = Guid.NewGuid().ToString(); //new document, new ID!
            string label = txtDocName.Value;
            for (int i = 0; i < jsonKeys.Count; i++)
            {
                //build the SQL insert
                string canvasId = Guid.NewGuid().ToString();
                string dataUrl = (string)pages[jsonKeys[i]];
                string insert = "INSERT INTO user_Canvas (CanvasId, DocumentId, UserId, DataUrl, Label, Page) " +
                    "VALUES('" + canvasId + "','" + documentId + "','" + userId + "','" + dataUrl + "','" + label + "'," + (i + 1) + ")";
                handler.ExecuteNonQuery(insert);
            }
            Session["global-message"] = "Document successfully saved.";
        }
    }
}