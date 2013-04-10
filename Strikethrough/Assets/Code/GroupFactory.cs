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
        //first column is the key, and second is the value, such as groupid/groupname or userid/username
        public static void BuildPlaceHolder(PlaceHolder placeHolder, DataTable groupTable)
        {
            BuildListButtons(placeHolder, groupTable);
        }
        public static void CreateGroup(string groupName, string userId)
        {
            GroupService service = new GroupService();
            service.CreateGroup(Guid.NewGuid().ToString(), groupName, userId);
        }
        public static void SubscribeToTeacher(string teacherEmail, string userId)
        {
            //get the teacherId from the email address the user entered
            DataHandler handler = new DataHandler();
            string select = "SELECT UserId FROM aspnet_Membership WHERE LoweredEmail = '" + teacherEmail.ToLower() + "'";
            string teacherId = handler.ExecuteScalar(select);

            //add the teacher to the student by the teacher's userId
            string insert = "INSERT INTO user_UserHasTeachers (TeacherId, UserId) VALUES ('" + teacherId + "', '" + userId + "')";
            handler.ExecuteNonQuery(insert);
        }



        //first column is the key, and second is the value, such as groupid/groupname or userid/username
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