function vAsignation() {

    this.ctrlActions = new ControlActions();


    this.setData = function () {
        this.ctrlActions.GetFromAPI("getAirports", null, function (result) {
            var listAirports = result.Data;
            for (var i = 0; i < listAirports.length; i++) {
                var airport = listAirports[i];
                var option = '<option value="' + airport.ID + '">' + airport.Name + "</option>";
                $("#listAirports").append(option);
            }
        });
        this.ctrlActions.GetFromAPI("getAirportManagers", null, function (result) {
            var listUsers = result.Data;
            for (var i = 0; i < listUsers.length; i++) {
                var user = listUsers[i];
                var option = '<option value="' + user.ID + '">' + user.FirstName + "</option>"
                $("#listUsers").append(option);
            }


        });
    }








}

//ON DOCUMENT READY
$(document).ready(function () {
    
    var vasignation = new vAsignation();

    vasignation.setData();
    
});

function save() {

    var idAirport = $('#listAirports').children("option:selected").val();


    var idUser = $('#listUsers').children("option:selected").val();
    
}