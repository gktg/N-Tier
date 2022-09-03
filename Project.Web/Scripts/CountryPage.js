var Countries = [];
var CountryModel = {};
var tbody;

$(document).ready(function () {
    GetCounties()
})




function GetCounties() {
    $.ajax({
        type: "Get",
        url: "/Country/GetCountries/",
        dataType: "json",
        data: null,
        async: false,
        success: function (result) {
            Countries = result;
            DrdFill("drdCountry", Countries)
        },
        error: function (e) {

            console.log(e);
        }
    })
}



function GetCountryInformationWithCountryName(countryNames) {
    $.ajax({
        type: "Get",
        url: "/Country/GetCountryInformationWithCountryName/",
        data: { countryName: countryNames },
        async: false,
        success: function (result) {
            CountryModel = result;
            FillTable()
        },
        error: function (e) {

            console.log(e);
        }
    })
}



function DrdFill(drdID, data) {
    var str = "";
    str += "<option value='Choose'>Choose</option>";
    for (var i of data) {
        var countryName = i.CountryName == undefined ? i.CountryName : i.CountryName;
        str += "<option value='" + i.CountryName + "'>" + countryName + "</option>";
    }
    $("#" + drdID).html(str);
}



function FillTable() {
    $("#tbodyCountry").find("tr").remove();
    tbody = "<tr >\
                  <td >"+ CountryModel.CountryName + "</td>\
                        <td >"+ CountryModel.CountryCapital + "</td>\
                        <td >"+ CountryModel.CountryISOCode + "</td>\
                        <td >"+ CountryModel.CountryCurrency + "</td>\
                        <td class='text-center'><button type='button' class='btn btn-success' onclick='CountrySave()'>Kaydet</button>\
                       </td>\
                         </tr>";

    $("#tbodyCountry").append(tbody);
}


function CountrySave() {
    $.ajax({
        type: "Get",
        url: "/Country/CountrySave/",
        data: CountryModel,
        async: false,
        success: function (result) {
            console.log(result)
            if (result == true) {
                alert("Kayıt Başarılı");

            }
            else {
                alert("Kayıt Alınamamıştır");
            }
        },
        error: function (e) {

            console.log(e);
        }
    })
}