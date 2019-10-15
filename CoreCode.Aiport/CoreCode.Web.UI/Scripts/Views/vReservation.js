function vReservation() {


    this.tblReservationId = 'tblReservation';
    this.service = 'reservation';
    this.ctrlActions = new ControlActions();
    this.destinyTicketDropdownId = "dropdownOriginTicket";
    this.columns = "IDReservation,FirstName","FirstLastName","Destiny","Price","Buy_Date";



    


    this.loadTicketDropdown = function () {
        var instance = this;
        this.ctrlActions.GetFromAPI('getPrices', "", function (response) {
            var destinyTicketElement = $("#" + instance.destinyTicketDropdownId);

            if (response.Data) {
                for (var counter = 0; counter < response.Data.length; counter++) {
                    destinyTicketElement.append(new Option(response.Data[counter].Price, response.Data[counter].Id));
                }
            }
        });
    }

    this.CategoryStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {

            document.querySelector("#btnEnable").classList.add('hide');
            document.querySelector("#btnDisable").classList.remove('hide');
            this.ctrlActions.ClearTable(this.tblCategoryId);
            this.RetrieveAvailable();

        }
        else if (document.querySelector('#statusFilter').value === "false") {
            document.querySelector("#btnEnable").classList.remove('hide');
            document.querySelector("#btnDisable").classList.add('hide');
            this.ctrlActions.ClearTable(this.tblCategoryId);
            this.RetrieveUnavailable();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getReservations', this.tblReservationId, false, 'Buscar:', 'Código o reservación');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableReservations', this.tblReservationId, false, 'Buscar:', 'Código o reservación');
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableReservations', this.tblReservationId, false, 'Buscar:', 'Código o reservación');
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblReservationId);
    }

    this.Create = function () {


        if (document.querySelector('#txtId').value !== '' &&
            document.querySelector('#txtFirstName').value !== '') {

            document.querySelector('#txtId').classList.remove('input-error');
            document.querySelector('#txtFirstName').classList.remove('input-error');

            var instance = this;
            if (!this.Validate()) {
                var reservationData = {};
                reservationData = this.ctrlActions.GetDataForm('frmEdition');
                reservationData.Status = true;

                let reservations;
                let cont = 0;
                let callback = function (response) {
                    reservations = response.Data;
                    for (let i = 0; i < reservations.length; i++) {
                        cont++;
                    }
                    cont = cont + 1;
                    //Hace el post al create

                    //reservationData.IDReservation = "RE- " + cont.toString();

                    instance.ctrlActions.PostToAPI('postReservation', reservationData, function () {
                        //Refresca la tabla
                        swal({
                            title: "¡Reservación exitosa!",
                            text: "",
                            icon: "success",
                            button: "OK",
                        }).then(function () {
                            instance.CleanForm();
                            instance.ReloadTable();
                        });
                    });
                }
                instance.ctrlActions.GetFromAPI("/getReservations", "", callback);

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
        else {

            document.querySelector('#txtId').classList.add('input-error');
            document.querySelector('#txtFirstName').classList.add('input-error');

            swal({
                title: "¡Error en el registro!",
                text: "No se puede hacer la reservación porque ya se encuentra reservada",
                icon: "error",
                button: "OK",
            });
        }





    }

    this.Update = function () {


        var instance = this;

        if (!this.Validate()) {

            var reservationData = {};
            reservationData = this.ctrlActions.GetDataForm('frmEdition');
            reservationData.Status = true;
            this.ctrlActions.PostToAPI('updateReservation', reservationData);


            instance.ctrlActions.PostToAPI('updateReservation', reservationData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Reservación actualizada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

                });
            });

        }
        else {
            swal({
                title: "¡Error al modificar la reservación!",
                text: "Por favor, seleccionar la reservación primero",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Enable = function () {


        var instance = this;

        if (!this.Validate()) {

            var reservationData = {};
            reservationData = this.ctrlActions.GetDataForm('frmEdition');
            reservationData.Status = true;
            this.ctrlActions.PostToAPI('updateReservation', reservationData);


            instance.ctrlActions.PostToAPI('updateReservation', reservationData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Reservación habilitada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

                });
            });

        }
        else {
            swal({
                title: "¡Error al habilitar la reservación!",
                text: "Por favor, seleccione primero la reservación",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Disable = function () {

        var instance = this;

        if (!this.Validate()) {

            var reservationData = {};
            reservationData = this.ctrlActions.GetDataForm('frmEdition');
            reservationData.Status = false;
            this.ctrlActions.PostToAPI('updateReservation', reservationData);

            instance.ctrlActions.PostToAPI('updateReservation', reservationData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Reservación deshabilitada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();

                });
            });

        }
        else {
            swal({
                title: "¡Error al deshabilitar la reservación!",
                text: "Por favor, seleccionar la reservación primero",
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



    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
    }


    this.CleanForm = function () {
        //limpia los campos
        document.querySelector('#txtId').value = '';
        document.querySelector('#txtFirstName').value = '';
        document.querySelector('#txtFirstLastName').value = '';
        document.querySelector('#txtDestiny').value = '';
        document.querySelector("#txtBuy_Date").value = '';
        //valida los campos
        document.querySelector('#txtId').classList.remove('input-error');
        document.querySelector('#txtFirstName').classList.remove('input-error');
        document.querySelector('#txtFirstLastName').classList.remove('input-error');
        document.querySelector('#txtDestiny').classList.remove('input-error');
        document.querySelector('#txtBuy_Date').classList.remove('input-error');
        document.getElementById("dropdownOriginTicket").selectedIndex = 0;

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    //  document.querySelector("#tblCategory").classList.add('fixed_header');
    document.querySelector("#txtId").disabled = false;
    document.querySelector("#btnEnable").classList.add('hide');
    var vreservation = new vReservation();
    vreservation.RetrieveAvailable();


});
