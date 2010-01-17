using System;
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
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    string action = string.Empty;
    public OleDbConnection CONN
    {
        //------------建立连接--------------------
        get { return new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;data source=" + Server.MapPath("app_data/data.mdb")); }
        //------------建立连接--------------------
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        using (OleDbConnection conn = CONN) {
            conn.Open();
        }
        action = Request.Params["action"];
        Response.Write(action);


    }
}
