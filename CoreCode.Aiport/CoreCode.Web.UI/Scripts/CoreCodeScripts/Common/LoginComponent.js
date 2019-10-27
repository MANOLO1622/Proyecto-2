﻿var LoginComponent = function() {
    var instance = this;
    instance.id = "";
    instance.userNameElementId = "userName";
    instance.loginPasswordElementId = "loginPassword";
    instance.ctrlActions = new ControlActions();

    instance.init = function() {
        var instance = this;
        var loginPasswordElement = document.getElementById(instance.loginPasswordElementId);
        if (loginPasswordElement) {
            loginPasswordElement.addEventListener("keypress", function(event) {
                if (event.keyCode === 13) {
                    event.preventDefault();
                    instance.loginEvent();
                }
            });
        }
    }
    instance.loginEvent = function () {
        //Get the user name
        var instance = this;
        var fieldsAreNotEmpty = true;
        var userNameElement = document.getElementById(instance.userNameElementId);
        //Get the user password
        var loginPasswordElement = document.getElementById(instance.loginPasswordElementId);
        if (userNameElement && loginPasswordElement) {
            userNameElement.addEventListener("focus", function(event) {
                if (event.target) {
                    event.target.classList.remove("has-error");
                }
            });
            
            loginPasswordElement.addEventListener("focus", function(event) {
                if (event.target) {
                    event.target.classList.remove("has-error");
                }
            });
            
            if (userNameElement.value === "") {
                fieldsAreNotEmpty = false;
                userNameElement.classList.add("has-error");

            }
            if (loginPasswordElement.value === "") {
                fieldsAreNotEmpty = false;
                loginPasswordElement.classList.add("has-error");
            }
               
            if (fieldsAreNotEmpty) {

                var currentUserData = {
                    userName: userNameElement.value,
                    password: loginPasswordElement.value
                }

                //Call the API to retrieve user
                instance.ctrlActions.GetFromAPI("getUser", currentUserData,
                    function (response) {
                        console.log("response", response);
                        console.log("response", response.Data);
                        let user = response.Data;
                        console.log('a', user);
                        if (user != undefined) {
                            console.log()
                            var userObjectElement = user;
                            var sourceUrl = siteVariables.webAppUrl; //window.location.protocol + "//" + window.location.host + "/SonyAirlines"; 
                            if (response.errorThrown) {
                                //Swal error message.
                                return;
                            }
                            //If the response is available, store to SessionStorage and redirect.        
                            sessionStorage.setItem("userObject", JSON.stringify(userObjectElement));
                            console.log("userObjectElement", userObjectElement);
                            //Redirect the user to a specific page.
                            switch (userObjectElement.Rol) {
                            case 1: //UserAdmin
                                window.location.href = sourceUrl + "/dashboard/general/";
                                console.log("User Admin");
                                break;
                            case 2: //AirportUser
                                    var airportIdObject = "id=" + userObjectElement.AssignedID;

                                    instance.ctrlActions.GetFromAPI("getAirportById", airportIdObject, function (response) {
                                        if (response) {
                                            sessionStorage.setItem("airportObject", JSON.stringify(response.Data));
                                        }
                                        //Redirect to dashboard
                                        window.location.href = sourceUrl + "dashboard/airport/" + response.Data.ID;
                                    });
                                console.log("Airport User");
                                break;
                                case 3: //AirlineUser
                                    var airlineIdObject = "id=" + userObjectElement.AssignedID;

                                    instance.ctrlActions.GetFromAPI("getAirlineById", airlineIdObject, function (response) {
                                        if (response) {
                                            sessionStorage.setItem("airlineObject", JSON.stringify(response.Data));
                                        }
                                        //Redirect to dashboard
                                        window.location.href = sourceUrl + "dashboard/airline/" + response.Data.ID;
                                    });
                                    console.log("Airline User");
                                    break;
                                case 4: //User
                                    var userIdObject = "id=" + userObjectElement.ID;

                                    instance.ctrlActions.GetFromAPI("getUserById", userIdObject, function (response) {
                                        if (response) {
                                            sessionStorage.setItem("userObject", JSON.stringify(response.Data));
                                        }
                                        //Redirect to dashboard
                                        window.location.href = sourceUrl + "dashboard/user/" + response.Data.ID;
                                    });
                        
                                    console.log("User");
                                    break;
                            }
                        } else {
                            swal({
                                title: "Información no válida.",
                                text: "El usuario y/o contraseña no coinciden con nuestra lista de usuarios. Intente de nuevo.",
                                icon: "error",
                                button: "Aceptar"
                            });
                        }
                    });
            } else {
                //Display error, fields must be filled.
                swal({
                    title: "Campos inválidos.",
                    text: "Por favor rellene los campos requeridos (Correo y contraseña).",
                    icon: "error",
                    button: "Aceptar"
                });
            }

            
            
        }
    };

    instance.recoverPasswordEvent = function(e) {
        //Get user name
        //Send to API recover the password with user name

        $('#btnRecover').click(function (e) { //checkIfUserExists

            let username = $('#userName').val();
            $("#btnRecover").attr("disabled", true);
            e.stopImmediatePropagation();

            if (username !== undefined && username !== "") {

                var user = { userName: username };

                instance.ctrlActions.GetFromAPI("checkIfUserExists", user, function (data) {
                    let userExist = data.Data !== null;
                    if (userExist) {

                        swal({
                            title: "¡Contraseña reenviada!",
                            text: "Estimado usuario, se le informa que se envió a su correo electrónico la contraseña actual.",
                            icon: "success",
                            button: "Ok"
                        });
                        $("#btnRecover").attr("disabled", false);

                    } else {
                        swal({
                            title: "Usuario no encontrado. Por favor inténtelo de nuevo.",
                            text: "",
                            icon: "error",
                            button: "Ok",
                        });
                        $("#btnRecover").attr("disabled", false);
                    }

                });

            } else {

                swal({
                    title: "Por favor introduzca su correo electrónico.",
                    text: "",
                    icon: "error",
                    button: "Ok",
                });
                $("#btnRecover").attr("disabled", false);
            }


        });
        
    }
};

$(document).ready(function() {
    var loginInstance = new LoginComponent();
    loginInstance.init();
});