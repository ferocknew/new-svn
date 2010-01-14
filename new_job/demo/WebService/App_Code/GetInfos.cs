using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TestFunctions;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetInfos
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class GetInfos : System.Web.Services.WebService {

    public GetInfos () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";        
        
    }

    [WebMethod]
    public List<InfoBody> GetInfoList(string siteName,string comName)
    {
        InfoList Infos = new InfoList();

        return Infos.GetInfo(siteName, comName);
        //return siteName;
    }
    
}

