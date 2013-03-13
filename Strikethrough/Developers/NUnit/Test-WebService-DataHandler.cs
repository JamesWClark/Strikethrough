using System;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;

namespace Strikethrough.Developers.NUnit
{
    [TestFixture]
    public class Test_WebService_DataHandler
    {


        [SetUp]
        public void Init()
        {
        }
        [Test]
        public void IsResultDataTable()
        {
            string query = "SELECT * FROM aspnet_Users";
            Assets.WebServices.DataHandler dataHandler = new Assets.WebServices.DataHandler();
            DataTable dt = new DataTable();
            Assert.AreEqual(dt.GetType(), dataHandler.GetDataTable(query).GetType());
        }

    }
}