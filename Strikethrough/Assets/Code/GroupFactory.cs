using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strikethrough.Assets.Code
{
    public class GroupFactory
    {
        public static void CreateGroup(string GroupId, string GroupName, string UserId)
        {
            WebServices.DataHandler handler = new WebServices.DataHandler();

            string insert = 
                "INSERT INTO user_Groups (GroupId, GroupName, UserId) " +
                "VALUES ('" + GroupId + "','" + GroupName + "','" + UserId + "')";

            handler.ExecuteNonQuery(insert);
        }
    }
}