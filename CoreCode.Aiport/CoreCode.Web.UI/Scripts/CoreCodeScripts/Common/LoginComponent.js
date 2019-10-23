var LoginComponent = function() {
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
                                        window.location.href = sourceUrl + "/dashboard/airport/" + response.Data.ID;
                                    });
                                    //window.location.href = sourceUrl + "/dashboard/airport/" + response.Data.ID;
                                    //window.location.href = sourceUrl + "/dashboard/airport/" + userObjectElement.ID;
                                console.log("Airport User");
                                break;
                                case 3: //AirlineUser
                                    var airlineIdObject = "id=" + userObjectElement.AssignedID;

                                    instance.ctrlActions.GetFromAPI("getAirlineById", airlineIdObject, function (response) {
                                        if (response) {
                                            sessionStorage.setItem("airlineObject", JSON.stringify(response.Data));
                                        }
                                        //Redirect to dashboard
                                        window.location.href = sourceUrl + "/dashboard/airline/" + response.Data.ID;
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
                                        window.location.href = sourceUrl + "/dashboard/user/" + response.Data.ID;
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

    instance.recoverPasswordEvent = function() {
        //Get user name
        //Send to API recover the password with user name

        $('#btnRecover').click(function () {

            function generar() {
                var caracteres = "!@abcdefghijkmnpqrtuvwxyzABCDEFGHIJKLMNPQRTUVWXYZ2346789!@";
                var password = "";
                var longitud = 8;
                for (i = 0; i < longitud; i++) password += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
                return contraseña;
            }

            let username = $('#loginEmail').val();

            if (users === null) {


                for (let i = 0; i < users.length; i++) {
                    if (users[i].Email === username) {
                        userRecovered = users[i];
                        opcion = users[i].Rol;
                        pwdGeneric = generar();

                        var user = {
                            ID: users.ID,
                            name: users.name,
                            lastName: users.lastName

                        }



                        //switch (opcion) {
                        //    case '2':
                        //        ApiService.postToAPI('postFAQ', user, function (response) { });
                        //        break;

                        //    case '3':
                        //        ApiService.postToAPI('postFAQ', user, function (response) { });
                        //        break;


                        //}

                    } else {
                        swal({
                            title: "Usuario  incorrecto. Por favor inténtelo de nuevo.",
                            text: "",
                            icon: "error",
                            button: "Ok",
                        });

                    }

                }
            } else {
                swal({
                    title: "Usuario  incorrecto. Por favor inténtelo de nuevo.",
                    text: "",
                    icon: "error",
                    button: "Ok",
                });
                console.log("error")
            }


        })
        
    }
};

$(document).ready(function() {
    var loginInstance = new LoginComponent();
    loginInstance.init();
});