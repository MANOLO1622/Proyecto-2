function checkUserMapping() {

    var userObjectElement = JSON.parse(sessionStorage.getItem("userObject"));
    var ctrlActions = new ControlActions();

    switch (userObjectElement.Rol) {
        case 1: //UserAdmin
            window.location.href = siteVariables.webAppUrl + "dashboard/general/";
            console.log("User Admin");
            break;
        case 2: //AirportUser
            var airportIdObject = "id=" + userObjectElement.AssignedID;
            ctrlActions.GetFromAPI("getAirportById", airportIdObject, function (response) {
                if (response) {
                    //Redirect to dashboard
                    window.location.href = siteVariables.webAppUrl + "dashboard/airport/" + response.Data.ID;
                }               
            });
            console.log("Airport User");
            break;
        case 3: //AirlineUser
            var airlineIdObject = "id=" + userObjectElement.AssignedID;
            ctrlActions.GetFromAPI("getAirlineById", airlineIdObject, function (response) {
                if (response) {
                    //Redirect to dashboard
                    window.location.href = siteVariables.webAppUrl + "dashboard/airline/" + response.Data.ID;
                }               
            });
            console.log("Airline User");
            break;
        case 4: //User
            var userIdObject = "id=" + userObjectElement.ID;
            ctrlActions.GetFromAPI("getUserById", userIdObject, function (response) {
                if (response) {
                    //Redirect to dashboard
                    window.location.href = siteVariables.webAppUrl + "dashboard/user/" + response.Data.ID;
                }                
            });
            console.log("User");
            break;
    }
};