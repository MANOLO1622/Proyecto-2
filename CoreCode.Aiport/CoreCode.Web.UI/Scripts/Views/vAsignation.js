function vAsignation() {

    this.ctrlActions = new ControlActions();



        this.destinyAirportDropdownId = "dropdownOriginAirport";
        this.originUserDropdownId = "dropdownOriginUser";


        //this.ctrlActions.GetFromAPI("getAirports", null, function (result) {
        //    var listAirports = result.Data;
        //    for (var i = 0; i < listAirports.length; i++) {
        //        var airport = listAirports[i];
        //        var option = '<option value="' + airport.ID + '">' + airport.Name + "</option>";
        //        $("#Id_Airport").append(option);
        //    }
        //});
        this.loadAirportDropdown = function () {
            var instance = this;
            this.ctrlActions.GetFromAPI('getAirports', "", function (response) {
                var destinyAirportElement = $("#" + instance.destinyAirportDropdownId);

                if (response.Data) {
                    for (var counter = 0; counter < response.Data.length; counter++) {
                        destinyAirportElement.append(new Option(response.Data[counter].Name, response.Data[counter].ID));
                    }
                }
            });
        }

    this.loadUserDropdown = function () {
        console.log("ENTRO");
        //$.get("http://localhost/SonyAirlinesAPI/api/getUsersByRol/", function (data) {
        //    existingAirports = data.Data;
        //    console.log(existingAirports);
        //    for (let i = 0; i < existingAirports.length; i++) {
        //        originUserDropdownId.append(new Option(existingAirports[i].FirstName, existingAirports[i].ID_ROL));
        //    }
        //});
            var instance = this;
        this.ctrlActions.GetFromAPI('getUsersByRol', "", function (response) {
                var originUserDropdownId = $("#" + instance.originUserDropdownId);

                if (response.Data) {
                    for (var counter = 0; counter < response.Data.length; counter++) {
                        originUserDropdownId.append(new Option(response.Data[counter].FirstName, response.Data[counter].ID_ROL));
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

            var asignationData = {};
            asignationData = this.ctrlActions.GetDataForm('frmEdition');
            console.log('entrp1', asignationData );

            asignationData.idAirport = $('#listAirports').children("option:selected").val();
            asignationData.idUser = $('#listUsers').children("option:selected").val();
            //Hace el post al create
 
            this.ctrlActions.PostToAPI('createAsignation', asignationData, function (response) {
                swal({
                    title: "¡Asignación Exitosa!",
                    text: "",
                    icon: "success",
                    button: "OK",
                });

            });


        }

        this.DisplayInsertForm = function () {

            document.getElementById("btnRegisterAsignation").style.display = 'block';
            document.getElementById("listAirports").style.display = 'block';
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
    
    var vasignation = new vAsignation();
    
});
