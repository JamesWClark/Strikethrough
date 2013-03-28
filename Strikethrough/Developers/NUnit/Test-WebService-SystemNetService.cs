using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace Strikethrough.Developers.NUnit
{
    [TestFixture]
    public class Test_WebService_SystemNetService
    {
        //known values
        private static string ip = "69.76.186.116";
        private static string country_code = "US";
        private static string country_name = "United States";
        private static string region_code = "MO";
        private static string region_name = "Missouri";
        private static string city = "Kansas City";
        private static string zipcode = "64111";
        //private static string latitude = "?";
        //private static string longitude = "?";
        //private static string metro_code = "?";
        private static string areacode = "816";

        private Assets.WebServices.SystemNetService sns = new Assets.WebServices.SystemNetService();
        private Assets.Code.GeoIP geo = new Assets.Code.GeoIP();

        [SetUp]
        public void Init()
        {
            geo = sns.GetGeoIP(ip);
        }
        [Test]
        public void IsCountryCode()
        {
            Assert.AreEqual(country_code, geo.country_code);
        }
        [Test]
        public void IsCountryName()
        {
            Assert.AreEqual(country_name, geo.country_name);
        }
        [Test]
        public void IsRegionCode()
        {
            Assert.AreEqual(region_code, geo.region_code);
        }
        [Test]
        public void IsRegionName()
        {
            Assert.AreEqual(region_name, geo.region_name);
        }
        [Test]
        public void IsCity()
        {
            Assert.AreEqual(city, geo.city);
        }
        [Test]
        public void IsZip()
        {
            Assert.AreEqual(zipcode, geo.zipcode);
        }
        [Test]
        public void IsAreaCode()
        {
            Assert.AreEqual(areacode, geo.areacode);
        }
    }
}