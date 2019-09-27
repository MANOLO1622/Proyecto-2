function vAsignationAirline() {

    this.tblAsignationAirlineId = 'tblAsignationAirlines';
    this.service = 'asignationAirlin';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Comercial_name,Name";


        this.destinyAirlineDropdownId = "dropdownOriginAirline";
        this.destinyAirportDropdownId = "dropdownOriginAirport";


    this.loadAirportDropdown = function () {
        var instance = this;
        this.ctrlActions.GetFromAPI('getAirports', "", function (response) {
            var destinyAirportElement = $("#" + instance.destinyAirportDropdownId);

            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    destinyAirportElement.append(new Option(response.Data[counter].Name, response.Data[counter].NAME));
                }
            }
        });
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
    
    this.RetrieveAll = function () {
        console.log('paso');
        this.ctrlActions.FillTable('getAsignationAirlines', this.tblAsignationAirlineId, false, 'Buscar:', 'Aerolínea o Aeropuerto');
    }
    
    this.Create = function () {
        if (!this.Validate()) {

            var asignationAirlineData = {};
            asignationAirlineData = this.ctrlActions.GetDataForm('frmEdition');
            console.log('entrp1', asignationAirlineData );

            asignationAirlineData.idAirport = $('#listAirports').children("option:selected").val();
            asignationAirlineData.idUser = $('#listAirlines').children("option:selected").val();
            //Hace el post al create
 
            this.ctrlActions.PostToAPI('createAsignationAirline', asignationAirlineData, function (response) {
                swal({
                    title: "¡Asignación Exitosa!",
                    text: "",
                    icon: "success",
                    button: "OK",
                });

            });
            this.CleanForm();

        }


        this.DisplayInsertForm = function () {

            document.getElementById("btnRegisterAsignationAirline").style.display = 'block';
            document.getElementById("listAirlines").style.display = 'block';
            document.getElementById("listAirports").style.display = 'block';
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
      
        document.getElementById("dropdownOriginAirline").selectedIndex = 0;
        document.getElementById("dropdownOriginAirport").selectedIndex = 0;
    }


}

//ON DOCUMENT READY
$(document).ready(function () {
    
    var vasignationAirline = new vAsignationAirline();
    vasignationAirline.RetrieveAll();

    var dataTable = $('#tblAsignationAirlines').DataTable();
    //hide the first and second columns
    dataTable.columns([0]).visible(false);

});
