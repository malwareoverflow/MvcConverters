$(document).ready(function () {
    var enabletype1 = false;
    $("#listfrom").change(function () {
        enabletype1 = true;
    });
    $('#listto').change(function () {
        if (enabletype1) {
            $("#btntype1").show();
        }
     
        
    });
});

