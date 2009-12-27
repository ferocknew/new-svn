<%@ WebService Language="C#" class="AddNumbers" %>
using System;
using System.Web.Services;

public class AddNumbers : WebService
{
[WebMethod]
public int Add(int a, int b){
int sum;
sum = a + b;
return sum;
}
}