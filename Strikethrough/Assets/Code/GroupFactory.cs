using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Strikethrough.Assets.WebServices;

namespace Strikethrough.Assets.Code
{
    public class GroupFactory
    {
        //i think delegates would improve the following methods, making it possible to use only one method instead of this repeating code

        //shape the table so that the first column is the key, and second is the value, such as groupid, groupname or userid, username
        public static void BuildPlaceHolder(PlaceHolder placeHolder, DataTable groupTable)
        {
            BuildListButtons(placeHolder, groupTable);
        }

        public static void CreateGroup(string groupName, string userId)
        {
            GroupService service = new GroupService();
            service.CreateGroup(Guid.NewGuid().ToString(), groupName, userId);
        }



        private static void BuildListButtons(PlaceHolder placeHolder, DataTable dtGroups)
        {
            for (int i = 0; i < dtGroups.Rows.Count; i++)
            {
                string name = dtGroups.Rows[i].ItemArray[1].ToString();
                string id = dtGroups.Rows[i].ItemArray[0].ToString();

                LinkButton b = new LinkButton();
                b.Text = name;
                b.CommandArgument = id;
                b.Command += new CommandEventHandler(GroupList_LinkButton_Click);

                placeHolder.Controls.Add(b);
            }
        }
        private static void GroupList_LinkButton_Click(Object sender, CommandEventArgs e) 
        {

        }
    }
}