(function(global, factory) {
    "use strict";
    //Defining the ApiService on the window so that can be used from anywhere.
    global.UserSession = factory(global);
})(window, function() {
    var getAirportSession = function() {
        return JSON.parse(sessionStorage.getItem("airportObject"));
    }
    var getCurrentUser = function() {
        return JSON.parse(sessionStorage.getItem("userObject"));
    }

    var getAirlineSession = function() {
        return JSON.parse(sessionStorage.getItem("airlineObject"));
    }

    var getEmployeeSession = function () {
        return JSON.parse(sessionStorage.getItem("employeeObject"));
    }

    var getUserSession = function () {
        return JSON.parse(sessionStorage.getItem("userObject"));
    }

    var setCurrentUser = function(userObject) {
        sessionStorage.setItem("userObject", JSON.stringify(userObject));
    }

    var cleanUserSession = function() {
        sessionStorage.removeItem("userObject");
        sessionStorage.removeItem("airlineObject");
        sessionStorage.removeItem("airportObject");
        sessionStorage.removeItem("employeeObject");
    }
    return {
        getAirportInstance: getAirportSession,
        getCurrentUserInstance: getCurrentUser,
        getAirlineSessionInstance: getAirlineSession,
        getEmployeeSessionInstance: getEmployeeSession,
        getUserSessionInstance: getUserSession,
        setCurrentUserInstance: setCurrentUser,
        cleanUserSession: cleanUserSession

}
});