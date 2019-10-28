function vMoneys() {


    this.tblMoneyId = 'tblMoney';
    this.service = 'money';
    this.ctrlActions = new ControlActions();
    this.columns = "IDMoney", "Origen", "Destino","Precio";



    this.MoneyStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {

            document.querySelector("#btnEnable").classList.add('hide');
            document.querySelector("#btnDisable").classList.remove('hide');
            this.ctrlActions.ClearTable(this.tblMoneyId);
            this.RetrieveAvailable();

        }
        else if (document.querySelector('#statusFilter').value === "false") {
            document.querySelector("#btnEnable").classList.remove('hide');
            document.querySelector("#btnDisable").classList.add('hide');
            this.ctrlActions.ClearTable(this.tblMoneyId);
            this.RetrieveUnavailable();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getMoneys', this.tblMoneyId, false, 'Buscar:', 'Origen o destino');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableMoneys', this.tblMoneyId, false, 'Buscar:', 'Origen o destino');
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableMoneys', this.tblMoneyId, false, 'Buscar:', 'Origen o destino');
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblMoneyId);
    }

    this.Create = function () {


        if (document.querySelector('#txtId').value == '' &&
            document.querySelector('#txtOrigen').value != '') {

            document.querySelector('#txtId').classList.remove('input-error');
            document.querySelector('#txtOrigen').classList.remove('input-error');

            var instance = this;
            if (!this.Validate()) {
                var moneyData = {};
                moneyData = this.ctrlActions.GetDataForm('frmEdition');
                moneyData.Status = true;

                let moneys;
                let cont = 0;
                let callback = function (response) {
                    moneys = response.Data;
                    for (let i = 0; i < moneys.length; i++) {
                        cont++;
                    }
                    cont = cont + 1;
                    //Hace el post al create

                    moneyData.IDMoney = "COD- " + cont.toString();

                    instance.ctrlActions.PostToAPI('postMoney', moneyData, function () {
                        //Refresca la tabla
                        swal({
                            title: "¡Precio registrado!",
                            text: "",
                            icon: "success",
                            button: "OK",
                        }).then(function () {
                            instance.CleanForm();
                            instance.ReloadTable();
                        });
                    });
                }
                instance.ctrlActions.GetFromAPI("/getMoneys", "", callback);

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
            document.querySelector('#txtDescription').classList.add('input-error');

            swal({
                title: "¡Error en el registro!",
                text: "No se puede registrar el precio que ya se encuentra en el sistema",
                icon: "error",
                button: "OK",
            });
        }





    }

    this.Update = function () {


        var instance = this;

        if (!this.Validate()) {

            var moneyData = {};
            moneyData = this.ctrlActions.GetDataForm('frmEdition');
            moneyData.Status = true;
            this.ctrlActions.PostToAPI('updateMoney', moneyData);


            instance.ctrlActions.PostToAPI('updateMoney', moneyData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Precio actualizado!",
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
                title: "¡Error al modificar el precio!",
                text: "Por favor, seleccionar el precio del ticket a modificar en la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Enable = function () {


        var instance = this;

        if (!this.Validate()) {

            var moneyData = {};
            moneyData = this.ctrlActions.GetDataForm('frmEdition');
            moneyData.Status = true;
            this.ctrlActions.PostToAPI('updateMoney', moneyData);


            instance.ctrlActions.PostToAPI('updateMoney', moneyData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Precio habilitado!",
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
                title: "¡Error al habilitar el precio!",
                text: "Por favor, seleccionar un precio de la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Disable = function () {

        var instance = this;

        if (!this.Validate()) {

            var moneyData = {};
            moneyData = this.ctrlActions.GetDataForm('frmEdition');
            moneyData.Status = false;
            this.ctrlActions.PostToAPI('updateMoney', moneyData);

            instance.ctrlActions.PostToAPI('updateMoney', moneyData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Precio deshabilitado!",
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
                title: "¡Error al deshabilitar el precio!",
                text: "Por favor, seleccionar un precio de la tabla",
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
        document.querySelector('#txtId').value = '';
        document.querySelector('#txtOrigen').value = '';
        document.querySelector('#txtDestino').value = '';
        document.querySelector('#txtPrecio').value = '';
        document.querySelector('#txtId').classList.remove('input-error');
        document.querySelector('#txtOrigen').classList.remove('input-error');
        document.querySelector('#txtDestino').classList.remove('input-error');
        document.querySelector('#txtPrecio').classList.remove('input-error');
        

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    //  document.querySelector("#tblCategory").classList.add('fixed_header');
    document.querySelector("#txtId").disabled = true;
    document.querySelector("#btnEnable").classList.add('hide');
    var vmoney = new vMoneys();
    vmoney.RetrieveAvailable();

    var dataTable = $('#tblMoney').DataTable();
    //hide the first and second columns
    dataTable.columns([0]).visible(false);

});
