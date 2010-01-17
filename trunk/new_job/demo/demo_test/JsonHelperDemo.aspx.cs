using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JsonHelper;

public partial class JsonHelperDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //序列化
        JSONArray jsonArray = new JSONArray();
        jsonArray.Add("2006");   
        jsonArray.Add("2007");
        jsonArray.Add("2008");
        jsonArray.Add("2009");
        jsonArray.Add("中文1");

        JSONObject jsonObject = new JSONObject();
        jsonObject.Add("domain", "mzwu.com");
        jsonObject.Add("years", jsonArray);

        Response.Write(JSONConvert.SerializeObject(jsonObject)); 
    }
}
