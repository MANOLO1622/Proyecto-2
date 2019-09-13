function vAsignationAirline() {

    this.ctrlActions = new ControlActions();



        this.destinyAirlineDropdownId = "dropdownOriginAirline";
        this.originUserDropdownId = "dropdownOriginUser";


        //this.ctrlActions.GetFromAPI("getAirports", null, function (result) {
        //    var listAirports = result.Data;
        //    for (var i = 0; i < listAirports.length; i++) {
        //        var airport = listAirports[i];
        //        var option = '<option value="' + airport.ID + '">' + airport.Name + "</option>";
        //        $("#Id_Airport").append(option);
        //    }
        //});
        this.loadAirlineDropdown = function () {
            var instance = this;
            this.ctrlActions.GetFromAPI('getAirlines', "", function (response) {
                var destinyAirlineElement = $("#" + instance.destinyAirlineDropdownId);

                if (response.Data) {
                    for (var counter = 0; counter < response.Data.length; counter++) {
                        destinyAirlineElement.append(new Option(response.Data[counter].Comercial_name, response.Data[counter].Id));
                    }
                }
            });
        }

        this.loadUserDropdown = function () {
            var instance = this;
            this.ctrlActions.GetFromAPI('getUsers', "", function (response) {
                var originUserDropdownId = $("#" + instance.originUserDropdownId);

                if (response.Data) {
                    for (var counter = 0; counter < response.Data.length; counter++) {
                        originUserDropdownId.append(new Option(response.Data[counter].FirstName, response.Data[counter].ID));
                    }
                }
            });
        }
        //this.ctrlActions.GetFromAPI("getAirportManagers", null, function (result) {
        //    var listUsers = result.Data;
        //    for (var i = 0; i < listUsers.length; i++) {
        //        var user = listUsers[i];
        //        var option = '<option value="' + user.ID + '">' + user.FirstName + "</option>"
        //        $("#Id_User").append(option);
        //    }


        //});

    this.Create = function () {
        if (!this.Validate()) {

            var asignationAirlineData = {};
            asignationAirlineData = this.ctrlActions.GetDataForm('frmEdition');
            console.log('entrp1', asignationAirlineData );

            asignationAirlineData.idAirport = $('#listAirports').children("option:selected").val();
            asignationAirlineData.idUser = $('#listUsers').children("option:selected").val();
            //Hace el post al create
 
            this.ctrlActions.PostToAPI('createAsignationAirline', asignationAirlineData, function (response) {
                swal({
                    title: "¡Asignación Exitosa!",
                    text: "",
                    icon: "success",
                    button: "OK",
                });

            });


        }

        this.DisplayInsertForm = function () {

            document.getElementById("btnRegisterAsignationAirline").style.display = 'block';
            document.getElementById("listAirlines").style.display = 'block';
            document.getElementById("listUsers").style.display = 'block';
        }



    }

    this.Validate = function () {
        let aInputs = document.querySelectorAll(':required');
        let bError = false;

        for (let i = 0; i < aInputs.length; i++) {
            if (aInputs[i].value === '') {
                bError = true;
                aInputs[i].classList.add('input-error');
            }
            else {
                aInputs[i].classList.remove('input-error');
            }

        }
        return bError;

    }


}

//ON DOCUMENT READY
$(document).ready(function () {
    
    var vasignationAirline = new vAsignationAirline();
    
});
