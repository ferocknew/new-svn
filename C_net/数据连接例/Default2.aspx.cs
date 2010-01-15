using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Text;
using System.Xml;
using System.Data.OleDb;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //------------建立连接--------------------
        string strConnection = "Provider=Microsoft.Jet.OleDb.4.0;";
        strConnection += @"Data Source=" + Server.MapPath("data/data.mdb");
        OleDbConnection objConnection = new OleDbConnection(strConnection);
        //------------建立连接--------------------

        string sql_s;
        sql_s = "select [password],[id],[name] from [table] where (name='admin')";
        OleDbCommand sqlcmd = new OleDbCommand(sql_s, objConnection);
        // OleDbDataReader reader = sqlcmd.ExecuteReader(); //执行查询
        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlcmd);
        DataSet set_d = new DataSet();
        adapter.Fill(set_d);

        //Response.Write(set_d.Tables[0].Rows.Count);
        //Response.Write(set_d.Tables[0].Rows[0][0].ToString());
        //Response.Write("<br />");
        
        objConnection.Open();
        OleDbDataReader reader = sqlcmd.ExecuteReader(); //执行查询
        List<List<string>> kk = new List<List<string>>();
        while (reader.Read())
        {
            List<string> aa = new List<string>();
            aa.Add(reader["id"].ToString());
            aa.Add(reader["password"].ToString());
            aa.Add(reader["name"].ToString());
            kk.Add(aa);
        }
        objConnection.Close();


        //Response.Write("<br />");
        //Response.Write(kk.Count);

        //xml
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement("root");
        doc.AppendChild(root);
        foreach (var one in kk)
        {
            //Response.Write(one);
            XmlElement line = doc.CreateElement("file");
            line.SetAttribute("id", one[0].ToString());
            line.SetAttribute("password", one[1].ToString());
            line.SetAttribute("name", one[2].ToString());
            root.AppendChild(line);
        }
        
        Encoding encoding = Encoding.GetEncoding("utf-8");
        Response.Charset = encoding.BodyName;
        Response.ContentType = "text/xml";
        Response.Expires = 0;
        Response.ExpiresAbsolute = DateTime.Now;
        Response.CacheControl = "no-cache";
        XmlWriterSettings outputseting = new XmlWriterSettings();
        outputseting.Encoding = encoding;
        outputseting.CloseOutput = false;
        XmlWriter outputer = XmlWriter.Create(Response.OutputStream, outputseting);
        doc.Save(outputer);
        outputer.Flush();
        outputer.Close();
        Response.End();


    }
}
