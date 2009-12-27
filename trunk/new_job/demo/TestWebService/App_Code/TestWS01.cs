using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for TestWS01
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TestWS01 : System.Web.Services.WebService {

    public TestWS01 () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string ReturnXMLAsStr()
    {
        return "<Root>" +
                "<User name='Todayn' pwd='123456'>" +
                "<User name='Sukim' pwd='654321'>"
                + "</Root>";
    }

    [WebMethod]
    public XmlDocument ReturnXMLAsXMLDocument()
    {
        string XmlStr = "<Root>" +
                "<User name='Todayn' pwd='123456'>" +
                "<User name='Sukim' pwd='654321'>"
                + "</Root>";
        XmlDocument Result = new XmlDocument();
        Result.LoadXml(XmlStr);

        return Result;
    }  
}

