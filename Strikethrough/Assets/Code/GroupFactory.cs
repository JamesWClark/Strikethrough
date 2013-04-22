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
        public static void CreateGroup(string groupName, string userId)
        {
            GroupService service = new GroupService();
            service.CreateGroup(Guid.NewGuid().ToString(), groupName, userId);
        }
        public static void SubscribeToTeacher(string teacherEmail, string userId)
        {
            //get the teacher's userId from the email address the user entered
            DataHandler handler = new DataHandler();
            string select = "SELECT UserId FROM aspnet_Membership WHERE LoweredEmail = '" + teacherEmail.ToLower() + "'";
            string teacherId = handler.ExecuteScalar(select);

            //add the teacher to the student by the teacher's userId
            string insert = "INSERT INTO user_UserHasTeachers (TeacherId, UserId) VALUES ('" + teacherId + "', '" + userId + "')";
            handler.ExecuteNonQuery(insert);
        }
        //first column is the key, and second is the value, such as groupid/groupname or userid/username
        public static void BuildPlaceHolder(PlaceHolder placeHolder, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i].ItemArray[1].ToString();
                string id = table.Rows[i].ItemArray[0].ToString();

                LinkButton b = new LinkButton();
                b.CssClass = "dynamic-placeholder-linkbutton";
                b.Text = name;
                b.CommandArgument = id;
                b.CommandName = name;

                placeHolder.Controls.Add(b);
            }
        }
        public static void BuildStudentProspectTable(Table table, string userId)
        {
            GroupService service = new GroupService();
            DataTable dtProspects = service.GetProspectiveStudentsData(userId);
            DataTable dtGroups = service.GetSupervisorOfData(userId);

            for (int i = 0; i < dtProspects.Rows.Count; i++)
            {
                DropDownList ddlGroupList = new DropDownList();
                ddlGroupList.DataSource = dtGroups;
                ddlGroupList.DataTextField = "GroupName";
                ddlGroupList.DataValueField = "GroupId";
                ddlGroupList.DataBind();
                ddlGroupList.Items.Insert(0, "Add a group");

                string name = dtProspects.Rows[i].ItemArray[0].ToString();
                string id = dtProspects.Rows[i].ItemArray[1].ToString();

                LinkButton b = new LinkButton();
                b.Text = name;
                b.CommandArgument = id;
                b.CommandName = name;

                TableRow row = new TableRow();
                TableCell cellProspects = new TableCell();
                TableCell cellGroups = new TableCell();

                cellProspects.Controls.Add(b);
                cellGroups.Controls.Add(ddlGroupList);
                row.Cells.Add(cellProspects);
                row.Cells.Add(cellGroups);
                table.Rows.Add(row);
            }
        }


        //first column is the key, and second is the value, such as groupid/groupname or userid/username
        private static void BuildListButtons(PlaceHolder placeHolder, DataTable dtGroups)
        {
            for (int i = 0; i < dtGroups.Rows.Count; i++)
            {
                string name = dtGroups.Rows[i].ItemArray[1].ToString();
                string id = dtGroups.Rows[i].ItemArray[0].ToString();

                LinkButton b = new LinkButton();
                b.CssClass = "dynamic-placeholder-linkbutton";
                b.Text = name;
                b.CommandArgument = id;
                b.CommandName = name;

                placeHolder.Controls.Add(b);
            }
        }
        public static void AssignProspectsToGroups(Table table, string userId)
        {
            GroupService service = new GroupService();
            foreach (TableRow row in table.Rows)
            {
                LinkButton b = (LinkButton)row.Cells[0].Controls[0];
                DropDownList ddl = (DropDownList)row.Cells[1].Controls[0];
                service.AddStudentToGroup(b.CommandArgument, ddl.SelectedValue);
            }
        }
    }
}