$(function() {
    $("#TestButton").click(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "../WebService/GetInfos.asmx/GetInfoList",
            data: "{siteName:'',comName:'mrThink'}",
            dataType: "json",
            success: function(result) {
                $(result.d).each(function() {
                    $("#divTest").append("SiteName:"+this["SiteName"]+"  "+"ComName:"+this["ComName"]);
                });
            },
            error: function(json) {
                var html_ = "error";
                $("#divTest").html(html_);
            }

        });
    });
});