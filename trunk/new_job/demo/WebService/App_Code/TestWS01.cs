using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;



/// <summary>
/// TestWS01 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
[System.Web.Script.Services.ScriptService]
public class TestWS01 : System.Web.Services.WebService {

    public TestWS01 () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public TestRType HelloWorld()
    {        
        TestRType Result = new TestRType();
        Result.Name = "Todayn";
        Result.Pwd = "123456";
        return Result;
    }
   
    
}

public class TestRType
{
    public string Name{ get; set; }
    public string Pwd { get; set; }
}

