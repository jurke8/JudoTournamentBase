function GetCategoriesByGender(_gender) {
    var url = "/Competitors/GetCategoriesByGender/";
    $.ajax({
        url: url,
        data: { gender: _gender },
        cache: false,
        type: "POST",
        success: function (data) {
            var markup = " ";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlCategories").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}

function GetCategoriesByDate(_date) {
    var url = "/Competitors/GetCategoriesByDate/";
    $.ajax({
        url: url,
        data: { date: _date },
        cache: false,
        type: "POST",
        success: function (data) {
            var markup = " ";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlCategories").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}
