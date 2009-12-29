$(function(){
	$("#TestButton").click(function(){
		$.ajax({
			type: "POST",
			contentType: "application/json",
			url: "../WebService/TestWS01.asmx/HelloWorld",
			 data: "{}",
			dataType: "json",
			success: function(json){
				var html_="Name:" + json.d.Name + "  Pwd:" + json.d.Pwd;
				 $("#divTest").html(html_); 
			}
		});
	});
});