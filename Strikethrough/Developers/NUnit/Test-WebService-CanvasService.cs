using System;
using System.Data;
using Strikethrough.Assets.WebServices;
using NUnit.Framework;

namespace Strikethrough.Developers.NUnit
{
    [TestFixture]
    public class Test_WebService_CanvasService
    {
        CanvasService svc = new CanvasService();

        /* GetTable
         * params: userId, tableId
         * 
         * */
        [Test]
        public void GetTable()
        {
            string userId = "jw"; //known test account
            DataTable dt = svc.GetTable(userId, "whiteboard");
            Assert.Greater(0, dt.Rows.Count);
        }
        [Test]
        public void GetRelativeHeight()
        {
            int width = 1;
            string paper = "letter";
            double height = svc.GetRelativeHeight(width, paper);
            Assert.AreEqual(1.2941176466020761, height);

        }
    }
}