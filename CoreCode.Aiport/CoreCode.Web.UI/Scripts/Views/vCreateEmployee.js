function vCreateEmployee() {


    this.ctrlActions = new ControlActions();
    this.EmployeeId = 'tblEmployee';
    this.EmployeeId = localStorage.getItem('idEmployeeLS');
    this.userEmailHtmlElementId = "txtEmail ";
    this.userIdHtmlElementId = "txtId";

    this.destinyAirlineDropdownId = "dropdownOriginAirline";

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
            var user;
            var employeeData = {};
            employeeData = this.ctrlActions.GetDataForm('frmCreateEmployee');
            let callback = function (response) {
                user = response.Data;
                if (!user) {
                    employeeData.Status = false;//quitar input password
                    employeeData.Rol = "5";
                    localStorage.setItem("idEmployeeLS", employeeData.Rol);
                    //employeeData.EmployeeID = instance.EmployeeId;
                    employeeData.Password = instance.GenerateRandomPassword();
                    instance.ctrlActions.PostToAPI('postEmployee', employeeData, function () {
                        swal({
                            title: "¡Empleado Registrado!",
                            text: "Se envio al correo: " + employeeData.Email + "su confirmación de cuenta  !Bienvenido!",
                            icon: "success",
                            button: "OK"
                        }).then(function () {
                            instance.CleanForm();
                            //  window.location.href = 'http://localhost:57312/vCreateAirlineAdmin';
                        });
                    });
                } else if (user.ID === document.querySelector('#txtId').value) {
                    document.querySelector('#txtId').classList.add('input-error');

                    swal({
                        title: "Error al registrar empleado",
                        text: "Cédula de identidad ya se encuentra registrada",
                        icon: "error",
                        button: "Ok"
                    });
                }
                else if (user.Email === document.querySelector('#txtEmail').value) {
                    document.querySelector('#txtEmail').classList.add('input-error');
                    swal({
                        title: "Error al registrar empleado",
                        text: "Correo electrónico ya se encuentra registrado",
                        icon: "error",
                        button: "Ok",
                    });
                }
            }
            instance.ctrlActions.GetFromAPI("checkIfUserExistsByUserNameOrId?userName=" + $("#" + instance.userEmailHtmlElementId).val() + "&id=" + $("#" + instance.userIdHtmlElementId).val() + "", "", callback);
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

    this.GenerateRandomPassword = function () {//--GENERAR LA CONTRASEÑA RANDOM
        var caracteres = "!@abcdefghijkmnpqrtuvwxyzABCDEFGHIJKLMNPQRTUVWXYZ2346789!@";
        var pass = "";
        var longitud = 8;
        for (i = 0; i < longitud; i++) pass += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
        return pass;
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


        if (document.querySelector('#txtSecondName').value == "") {
            document.querySelector('#txtSecondName').value = "N/N";
        }
        if (document.querySelector('#txtSecondLastName').value == "") {
            document.querySelector('#txtSecondLastName').value = "N/N";
        }



        return bError;

    }



    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {

            aInputs[i].value = '';


        }
        document.querySelector('#txtSecondName').value = '';
        document.querySelector('#txtSecondLastName').value = '';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vemployee = new vCreateEmployee();


});
