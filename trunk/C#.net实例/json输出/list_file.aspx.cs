using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string callback = Request.QueryString["callback"];
        string username_ = Request.QueryString["username"];

        if (username_ == null) { Response.Write(callback + "(error)"); Response.End(); } //判断用户信息

        //------------建立连接--------------------SQL Server
        string strConnection = "user id=sa;password=sa;";
        strConnection += "initial catalog=ed2klink;Server=chenyl;";
        strConnection += "Connect Timeout=30";
        SqlConnection objConnection = new SqlConnection(strConnection);
        //------------建立连接--------------------

        SqlCommand sqlcmd = new SqlCommand("select UserID_FileUpLoad.userid,ed2klinks.filename,UserID_FileUpLoad.upload from UserID_FileUpLoad inner  join ed2klinks  on (ed2klinks.filehash = UserID_FileUpLoad.fileid) where (UserID_FileUpLoad.userid = '" + username_ + "')", objConnection);
        SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
        DataSet set_d = new DataSet();

        if (adapter.Fill(set_d) != 0)
        {

            List<Config> config = new List<Config>();
            foreach (DataRow one in set_d.Tables[0].Rows)
            {

                Config config2 = new Config()
                {
                    username = new string[] { one[0].ToString() },
                    filename = new string[] { one[1].ToString() },
                    upload = new string[] { one[2].ToString() },
                };
                config.Add(config2);
            }

            var serializer = new DataContractJsonSerializer(typeof(Config[]));
            Response.Write(callback + "(");
            serializer.WriteObject(Response.OutputStream, config.ToArray());
            Response.Write(")");

        }
        else { Response.Write(callback + "(error)"); };
        Response.End();
    }
}
[Serializable]
class Config
{
    public string[] username;
    public string[] filename;
    public string[] upload;
}