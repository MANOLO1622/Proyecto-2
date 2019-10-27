function vEditUser() {


    this.ctrlActions = new ControlActions();
    this.UserId = localStorage.getItem('idUserLS');


    this.Update = function () {

        let idUser = {
            id: localStorage.getItem('idUserLS')
        };

        var instance = this;
        if (!this.Validate()) {

            var userData = {};
            userData = this.ctrlActions.GetDataForm('frmEdition');


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
                    title: "Error al registrar administrador",
                    text: "Usuario debe ser mayor de edad",
                    icon: "error",
                    button: "Ok",
                });
            } else {

                var regPass = /^(?=\S*[a-z])(?=\S*[A-Z])(?=\S*\d)(?=\S*[^\w\s])\S{8,}$/;
                if (regPass.test(document.querySelector("#txtPassword").value)) {
                    document.querySelector("#txtPassword").classList.add("input-error");
                    swal({
                        title: "Error en la contraseña",
                        text: "Por favor, cumplir con el formato requerido",
                        icon: "error",
                        button: "Ok",
                    });
                } else {

                    if (document.querySelector("#txtPassword").value != document.querySelector("#txtPassword2").value) {
                        document.querySelector("#txtPassword").classList.add("input-error");
                        document.querySelector("#txtPassword2").classList.add("input-error");
                        swal({
                            title: "Error en la contraseña",
                            text: "Las contraseñas no son idénticas",
                            icon: "error",
                            button: "Ok",
                        });
                    }
                    else {

                        userData.Status = true;
                        userData.Rol = "4";
                        userData.UserID = instance.UserId;

                        instance.ctrlActions.PostToAPI('updateUsers', userData, function () {

                            swal({
                                title: "¡Modificación Exitosa!",
                                text: "",
                                icon: "success",
                                button: "OK"
                            }).then(function () {
                                checkUserMapping();
                                //window.location.href = siteVariables.webAppUrl + 'dashboard/general/';
                            });
                        });
                    }
                }
            }
        } else {

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


        if (document.querySelector('#txtSecondName').value == "") {
            document.querySelector('#txtSecondName').value = "N/N";
        }
        if (document.querySelector('#txtSecondLastName').value == "") {
            document.querySelector('#txtSecondLastName').value = "N/N";
        }



        return bError;

    }



    this.Cancel = function () {
        checkUserMapping();
        //window.location.href = siteVariables.webAppUrl + 'dashboard/general/';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {


    let idUser = "ID=" + localStorage.getItem('idUserLS');
    let userObject = JSON.parse(sessionStorage.getItem('userObject'));
    // let a = userObject.ID;
    console.log('u',userObject.ID);
    //console.log('a', a);
  
    var vUserEdit = new vEditUser();
    document.querySelector("#txtId").disabled = true;
    document.querySelector("#txtEmail").disabled = true;
    var user;
    let callback = function (response) {

        user = response.Data;
        console.log(response.Data);
        var date = new Date(user.BirthDate);
        console.log('date', user.BirthDate);
        var formattedDate = date.getFullYear() + "-" + ((date.getMonth() + 1) < 10 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1)) + "-" + ((date.getDate()) < 10 ? "0" + (date.getDate()) : (date.getDate()));
        console.log('date1', formattedDate);

        document.querySelector("#txtId").value = user.ID;
        document.querySelector("#txtEmail").value = user.Email;
        document.querySelector("#txtFirstName").value = user.FirstName;
        document.querySelector("#txtLastName").value = user.FirstLastName;
        document.querySelector("#txtSecondName").value = user.SecondName;
        document.querySelector("#txtSecondLastName").value = user.SecondLastName;
        document.querySelector("#txtBirthDate").value = formattedDate;
        document.querySelector("#txtPhone").value = user.Phone;
        document.querySelector("#txtPassword").value = user.Password;
        document.querySelector("#txtPassword2").value = user.Password;
        document.querySelector("#selectCivilStatus").value = user.CivilStatus;
        document.querySelector("#selectGenre").value = user.Genre;

    }
    vUserEdit.ctrlActions.GetFromAPI("getUserById", `ID=${userObject.ID}`, callback);

});

