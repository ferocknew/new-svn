using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;



namespace TestFunctions
{
    /// <summary>
    /// Summary description for GetInfo
    /// </summary>
    public class InfoList
    {
        private string ConString = null;        

        public InfoList()
        {
            //
            // TODO: Add constructor logic here
            //

            Initialize();
        }

        private void Initialize()
        {
            // Initialize data source. Use connection string from configuration.
            string v_ConnectionStringsType = "ConnectionString";

            if (ConfigurationManager.ConnectionStrings[v_ConnectionStringsType] == null ||
                ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named 'ConnectionStringType' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            ConString = ConfigurationManager.ConnectionStrings[v_ConnectionStringsType].ConnectionString;
        }

        public List<InfoBody> GetInfo(string siteName, string comName)
        {
            List<InfoBody> Result = null;
            DataTable RDT = new DataTable("Info");

            string SqlCom = "select * from info";
            string SqlCondition = " where ";

            if (!string.IsNullOrEmpty(siteName))
            {
                SqlCom = SqlCom + SqlCondition + "site_name='" + siteName + "'";
                SqlCondition = " and ";
            }

            if (!string.IsNullOrEmpty(comName))
            {
                SqlCom = SqlCom + SqlCondition + "com_name='" + comName + "'";
                SqlCondition = " and ";
            }

            SqlCom = SqlCom + "order by com_name";

            //方便测试连接字符串采用绝对路径
            //string ConnectionStr="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+System.Web.HttpContext.Current.Server.MapPath("~//App_Data//Data.mdb")+";Jet OLEDB:System Database=system.mdw;";
            //OleDbConnection Con = new OleDbConnection(ConnectionStr);
            OleDbConnection Con = new OleDbConnection(ConString);
            OleDbDataAdapter Adp = new OleDbDataAdapter(SqlCom, Con);

            try
            {
                Con.Open();                
                Adp.Fill(RDT);
            }
            catch (SqlException ex)
            {
                Result = null;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }

            if (RDT.Rows.Count > 0)
            {
                Result = new List<InfoBody>();
                foreach (DataRow a in RDT.Rows)
                {
                    InfoBody IBody = new InfoBody();
                    IBody.SiteName = a["site_name"].ToString();
                    IBody.ComName = a["com_name"].ToString();
                    IBody.ComIntro = "dd";
                    Result.Add(IBody);
                }
            }

            return Result;
        }
    }

    public class InfoBody
    {
        public string SiteName { get; set; }
        public string ComName { get; set; }
        public string ComIntro { get; set; }
    }
}
