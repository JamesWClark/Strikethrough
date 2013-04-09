using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Strikethrough.Assets.Code
{
    public class GroupFactory
    {
        public static void PopulateList(PlaceHolder placeHolder, DataTable dtGroups)
        {
            if (dtGroups.Rows.Count < 1) // no items exist
            {
                Label memberMessage = new Label();
                memberMessage.Text = "You are not a member of any groups.";
                placeHolder.Controls.Add(memberMessage);
            }
            else
            {
                for (int i = 0; i < dtGroups.Rows.Count; i++)
                {
                    LinkButton b = new LinkButton();
                    b.Text = dtGroups.Rows[i].ItemArray[1].ToString();
                    //b.CommandArgument = 
                }
            }
        }
    }
}