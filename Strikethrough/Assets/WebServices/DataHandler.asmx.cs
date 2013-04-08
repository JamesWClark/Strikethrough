using System;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Strikethrough.Assets.WebServices
{
    /// <summary>
    /// Summary description for DataHandler
    /// </summary>
    [WebService(Namespace = "vhost0165.site1.compute.ihost.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataHandler : System.Web.Services.WebService
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter sda;
        private static DataTable dt;

        [WebMethod]
        public void ExecuteNonQuery(string command)
        {
            try
            {
                Connect();

                //create a new command with the column name and data type query above
                cmd = new SqlCommand();
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                cmd.Dispose(); conn.Dispose();
            }
            catch (Exception)
            {
            }
        }
        [WebMethod]
        public string ExecuteScalar(string query)
        {
            string value = "";
            try
            {

                Connect();

                //create a new command with the column name and data type query above
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                value = cmd.ExecuteScalar().ToString();

                cmd.Dispose(); conn.Dispose();
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }
            return value;
        }
        [WebMethod]
        public DataTable GetDataTable(string query)
        {
            try
            {
                Connect();

                //create a new command with the column name and data type query above
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                dt = new DataTable();
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                sda.Dispose(); cmd.Dispose(); conn.Dispose();

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //create and open a connection to the database
        private void Connect()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Strikethrough_DevConnectionString"].ConnectionString;
            conn.Open();
        }
    }
}
