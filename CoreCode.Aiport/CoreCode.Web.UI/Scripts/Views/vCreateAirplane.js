function vCreateAirplane() {


    this.tblAirplaneId = 'tblAirplans';
    this.ctrlActions = new ControlActions();
    this.destinyAirlineDropdownId = "dropdownOriginAirline";
    this.columns = "Id", "Name", "License_Plate","Capacity","Model","Brand","Id_Airline";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getAirplans', this.tblAirplaneId, false, 'Buscar:', 'Código o # de avión');
        //this.RetrieveAll();
    }


    this.loadAirlineDropdown = function () {
        var instance = this;
        this.ctrlActions.GetFromAPI('getAirlines', "", function (response) {
            var destinyAirlineElement = $("#" + instance.destinyAirlineDropdownId);

            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    destinyAirlineElement.append(new Option(response.Data[counter].Comercial_name, response.Data[counter].ID));
                }
            }
        });
    }
    this.Create = function () {
        var instance = this;
        if (!this.Validate()) {

            var airplaneData = {};
            airplaneData = this.ctrlActions.GetDataForm('frmEditionAirplane');
            console.log(airplaneData);
            let repeatedId = false;
            let airplans;
            let emailRepeated = false;
            let callback = function (response) {

                airplans = response.Data;

                for (let i = 0; i < airplans.length; i++) {
                    if (airplans[i]['Id'] === document.querySelector('#txtId').value) {
                        repeatedId = true;
                        break;
                    }
                }

                if (repeatedId) {
                    document.querySelector('#txtId').classList.add('input-error');
                    swal({
                        title: "Error al registrar avión",
                        text: "Cédula jurídica ya se encuentra registrada en el sistema",
                        icon: "error",
                        button: "Ok",
                    });

                }
                else {
                    for (let i = 0; i < airplans.length; i++) {
                        if (airplans[i]['text'] == document.querySelector('#txtBrand').value) {
                            emailRepeated = true;
                        }
                    }
                    if (emailRepeated) {
                        document.querySelector('#txtBrand').classList.add('input-error');
                        swal({
                            title: "Error al registrar avión",
                            text: "El tipo ya se encuentra en el sistema",
                            icon: "error",
                            button: "Ok",
                        });
                    }
                    else {

                        //var creationYear = new Date(document.querySelector('#txtCreationYear').value.split('-'));
                        //var today = new Date();
                        if (null) {
                            //document.querySelector('#txtCreationYear').classList.add('input-error');

                            //swal({
                            //    title: "Error al registrar aerolínea",
                            //    text: "La fecha de creación no es válida",
                            //    icon: "error",
                            //    button: "Ok",
                            //});
                        }

                        else {
                            airplaneData.Status = true;
                            airplaneData.Request = "waiting";
                            localStorage.setItem('idAirplaneLS', airplaneData.ID);

                            localStorage.setItem('typeAirplaneLS', document.querySelector("#txtBrand").value);


                            instance.ctrlActions.PostToAPI('createAirplane', airplaneData, function (response) {
                                swal({
                                    title: "¡Avión registrado!",
                                    text: "",
                                    icon: "success",
                                    button: "OK"
                                }).then(function () {
                                    instance.CleanForm();
                                    //window.location.href = 'http://localhost:57312/vCreateAirlineAdmin';


                                });
                            });
                        }
                    }

                    
                }
            }
            instance.ctrlActions.GetFromAPI("/getAirplans", "", callback);


        }
        else {

            swal({
                title: "¡Ocurrió un error!",
                text: "Revisar campos vacíos",
                icon: "error",
                button: "OK",
            });

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

    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {

            aInputs[i].value = '';

            document.getElementById("dropdownOriginAirline").selectedIndex = 0;
        }

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vairplane = new vCreateAirplane();
    vairplane.RetrieveAll();

    var dataTable = $('#tblAirplans').DataTable();
    //hide the first and second columns
    dataTable.columns([0,6]).visible(false);


});
