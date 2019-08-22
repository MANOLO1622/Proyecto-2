﻿function vCreateUser() {


    this.ctrlActions = new ControlActions();
    this.userEmailHtmlElementId = "txtEmail ";
    this.userIdHtmlElementId = "txtId";
    this.Create = function () {

        var instance = this;
        if (this.Validate()) {
            var user;
            var UserData = {};
            UserData = this.ctrlActions.GetDataForm('frmCreateUser');

            let callback = function (response) {
                user = response.Data;
                if (!user) {
                    var regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    if (!regEmail.test(document.querySelector('#txtEmail').value)) {
                        document.querySelector('#txtEmail').classList.add('input-error');
                        swal({
                            title: "Error al registrar Usuario",
                            text: "Correo electrónico no cuenta con formato correcto",
                            icon: "error",
                            button: "Ok",
                        });

                    }
                    else {
                        var birthday = new Date(document.querySelector('#txtBirthDate').value.split('-'));
                        var today = new Date();
                        var age = today.getFullYear() - birthday.getFullYear();
                        var m = today.getMonth() - birthday.getMonth();

                        if (m < 0 || (m === 0 && today.getDate() < birthday.getDate())) {
                            age--;
                        }
                        console.log(age, typeof (age));
                        if (age < 18) {
                            document.querySelector('#txtBirthDate').classList.add('input-error');
                            swal({
                                title: "Error al registrar el Usuario",
                                text: "Usuario debe ser mayor de edad",
                                icon: "error",
                                button: "Ok",
                            });
                        }

                        else {

                            UserData.Status = true;
                            UserData.Rol = "4"; 
                            UserData.Password = instance.GenerateRandomPassword();
                            instance.ctrlActions.PostToAPI('Users/post', UserData, function () {


                                swal({
                                    title: "¡Usuario registrado!",
                                    text: "Se envio un correo con la contraseña temporal a la dirección: " + UserData.Email + " Bienvenido!",
                                    icon: "success",
                                    button: "OK"
                                }).then(function () {
                                    instance.CleanForm();
                                   
                                });
                            });
                        }
                    }

                } else if (user.ID === document.querySelector('#txtId').value) {
                    document.querySelector('#txtId').classList.add('input-error');

                    swal({
                        title: "Error al registrar Usuario",
                        text: "Cédula de identidad ya se encuentra registrada",
                        icon: "error",
                        button: "Ok",
                    });
                } else if (user.Email === document.querySelector('#txtEmail').value) {
                    document.querySelector('#txtEmail').classList.add('input-error');

                    swal({
                        title: "Error al registrar Usuario",
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

    var vUser = new vCreateUser();


});