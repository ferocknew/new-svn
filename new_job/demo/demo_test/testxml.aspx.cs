using System;
using System.Collections;
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
using System.Xml;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument xml = new XmlDocument();
        XmlDeclaration xde;//表示 XML 声明节点：<?xml version='1.0'...?>
        xde = xml.CreateXmlDeclaration("1.0", "utf-8", null);//参数的第二项为编码方式
        xml.AppendChild(xde);
        XmlElement xn = xml.CreateElement("div");
        xn.InnerXml = "我靠";
        xml.AppendChild(xn);
        
        Response.ContentType = "text/xml";
        Response.Charset = "utf-8";
        Response.Expires = 0;
        Response.ExpiresAbsolute = DateTime.Now;
        Response.CacheControl = "no-cache";
        Response.Write(xml.OuterXml);

        /*
        DataSet ds = new DataSet();
        DataTable table = new DataTable("Item");
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Price", typeof(string));

        DataRow r = table.NewRow();
        r[0] = "huzhen";
        r[1] = "huzhen";
        table.Rows.Add(r);

        r = table.NewRow();
        r[0] = "huzhen";
        r[1] = "huzhen";
        table.Rows.Add(r);

        ds.Tables.Add(table);
        Response.Clear();
        Response.ContentType = "text/xml";
        Response.Charset = "utf-8";
        Response.Expires = 0;
        Response.ExpiresAbsolute = DateTime.Now;
        Response.CacheControl = "no-cache";
        Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n " + ds.GetXml());
        Response.End();
        */
        /*
        Response.ContentType = "text/xml";
        Response.Charset = "utf-8";
        Response.Expires = 0;
        Response.ExpiresAbsolute = DateTime.Now;
        Response.CacheControl = "no-cache";
        Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        Response.Write("<root>中文</root>");
        */
    }
}