<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="JS/jquery-1.4a2.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('#TestButton').click(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "http://localhost/WebService/TestWS01.asmx/HelloWorld",
                    data: "{}",
                    dataType: "json",
                    success: function(result) {
                        
                        $('#divTest').append("Name:" + result.d.Name + "  Pwd:" + result.d.Pwd); 
                                               
                    },
                    error: function(result) {
                        alert(result.d);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <input type="button" value="Click" id="TestButton" />        
    </div>
    <br />
    <div id="divTest">      
    </div>
    </form>
</body>
</html>
