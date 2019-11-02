var DashboardNav = function() {
    var instance = this;
    this.userObject = JSON.parse(sessionStorage.getItem("userObject"));
};

DashboardNav.prototype.init = function() {
    var instance = this;
    var logOutElement = document.getElementById("log-out-btn");
    if (logOutElement) {
        logOutElement.style.display = 'block';
        logOutElement.addEventListener("click",
            function() {
                sessionStorage.removeItem("userObject");
                window.location.href = "http://localhost/SonyAirlines";
            });
    }
    if (instance.userObject) {
        switch (instance.userObject.Rol) {
        case 1:
            instance.setNavForGeneralAdmin();
            break;
        case 2:
            instance.setNavForAirportAdmin();
            break;
        case 3:
            instance.setNavForAirlineAdmin();
            break;
        case 4:
            instance.setNavForUser();
            break;
        case 5:
            instance.setNavForEmployee();
            break;
        default:
            //Redirect to home page.
            location.href = window.location.protocol + "//" + window.location.hostname;
        }
    } else {
        //location.href = window.location.protocol + "//" + window.location.hostname;
    }
}


DashboardNav.prototype.setNavForGeneralAdmin = function() { //Vista del SUPER ADMIN
    //Airport List
    $("#airportNavBtn").fadeIn();
    $("#seeAirportsNavBtn").removeAttr('style');
    $("#createAirportsNavBtn").removeAttr('style');
    
    //Money List
    $("#moneyNavBtn").fadeIn(1000);
    $("#addMoneyNavBtn").removeAttr('style');
    $("#viewMoneyNavBtn").removeAttr('style');
   

    $("#faqNavBtn").fadeIn(1800);
    $("#viewFaqNavBtn").removeAttr('style');

    //Vuelos
    $("#flightsNavBtn").fadeIn(2200);
    $("#viewFlights").removeAttr('style');
    $("#viewFlightsNavBtn").removeAttr('style');
    $("#viewTickets").removeAttr('style');

    //Reservacion
    $("#reservationNavBtn").fadeIn(2200);
    $("#viewReservationNavBtn").removeAttr('style');

    //Empleados
    $("#employeeNavBtn").fadeIn(2200);
    $("#viewEmployeeNavBtn").removeAttr('style');

    //Aerolineas
    $("#airlineNavBtn").fadeIn(2200);
    $("#airline-register-nav").removeAttr('style');
    $("#viewAirlinesNavBtn").removeAttr('style');

    //Asignaciones
    $("#asignationNavBtn").fadeIn(2200);
    $("#viewAsignationNavBtn").removeAttr('style');

    //Aviones
    $("#airplaneNavBtn").fadeIn(2200);
    $("#addAirplaneNavBtn").removeAttr('style');
    $("#viewAairplaneNavBtn").removeAttr('style');
};

DashboardNav.prototype.setNavForAirportAdmin = function() {
    //Airport List
    $("#airportNavBtn").fadeIn();
    $("#editAirportNavBtn").removeAttr('style');

    //Money List
    $("#moneyNavBtn").fadeIn(1000);
    $("#createStoreNavBtn").removeAttr('style');
    $("#viewStores").removeAttr('style');

    //Gate List
    $("#gatesNavBtn").fadeIn(1600);
    $("#addGateNavBtn").removeAttr('style');
    $("#seeGatesNavBtn").removeAttr('style');

    //Airlines List
   //$("#airlineNavBtn").fadeIn(2000);
   // $("#viewAirlinesNavBtn").removeAttr('style');

};

DashboardNav.prototype.setNavForAirlineAdmin = function() {//Optiones que puede ver el Amid de aerolinea

    //Aerolíneas
    $("#airlineNavBtn").fadeIn(4000);
    $("#viewAirlineNavBtn").removeAttr('style');
    //Empleados
    $("#employeeNavBtn").fadeIn(4000);
    $("#viewEmployeeNavBtn").removeAttr('style');
    //Vuelos
    $("#flightsNavBtn").fadeIn(4000);
    $("#viewFlightsNavBtn").removeAttr('style');
    //Aviones
    $("#airplaneNavBtn").fadeIn(4000);
    $("#viewAirplans").removeAttr('style');

    //Money List
    $("#moneyNavBtn").fadeIn(1000);
    $("#viewMoneyNavBtn").removeAttr('style');
   
};

DashboardNav.prototype.setNavForUser = function () {//Optiones que puede ver el Cliente

    //Aerolíneas
    $("#reservationNavBtn").fadeIn(4000);
    $("#viewReservationNavBtn").removeAttr('style');

    //Vuelos
    $("#flightsNavBtn").fadeIn(4000);
    $("#viewFlights").removeAttr('style');

    //Money List
    $("#moneyNavBtn").fadeIn(1000);
    $("#viewMoneyNavBtn").removeAttr('style');


};
DashboardNav.prototype.setNavForEmployee = function () {//Optiones que puede ver el empleado

    //Aerolíneas
    $("#reservationNavBtn").fadeIn(4000);
    $("#viewReservationNavBtn").removeAttr('style');

    //Vuelos
    $("#flightsNavBtn").fadeIn(4000);
    $("#viewFlights").removeAttr('style');

    //Money List
    $("#moneyNavBtn").fadeIn(1000);
    $("#viewMoneyNavBtn").removeAttr('style');


};
DashboardNav.prototype.setNavForUserAdmin = function () { //Optiones que puede ver el Amid de Admin Airport

    //Aeropuertos
    $("#airportNavBtn").fadeIn();
    $("#seeAirportNavBtn").removeAttr('style');
    //Vuelos
    $("#flightsNavBtn").fadeIn(4000);
    $("#viewFlightsNavBtn").removeAttr('style');
    //Reservacion
    $("#reservationNavBtn").fadeIn(4000);
    $("#viewReservationNavBtn").removeAttr('style');
    //Empleados
    $("#employeeNavBtn").fadeIn(4000); 
    $("#viewEmployeeNavBtn").removeAttr('style');
    //Aerolíneas
    $("#airlineNavBtn").fadeIn(4000);
    $("#viewAirlinesNavBtn").removeAttr('style');
    //Asignaciones
    $("#asignationNavBtn").fadeIn(4000);
    $("#viewAsignationNavBtn").removeAttr('style');
    //Aviones
    $("#airplaneNavBtn").fadeIn(4000);
    $("#viewAairplaneNavBtn").removeAttr('style');

    $("#viewAirlinesNavBtn").removeAttr('style');
    $("#viewTickets").removeAttr('style');
};

$(document).ready(function() {
    var dashboardNavInstance = new DashboardNav();
    dashboardNavInstance.init();
    setSidenavListeners();
});


// Sidenav list sliding functionality
function setSidenavListeners() {
    const subHeadings = $('.navList__subheading'); console.log('subHeadings: ', subHeadings);
    const SUBHEADING_OPEN_CLASS = 'navList__subheading--open';
    const SUBLIST_HIDDEN_CLASS = 'subList--hidden';

    subHeadings.each((i, subHeadingEl) => {
        $(subHeadingEl).on('click', (e) => {
            const subListEl = $(subHeadingEl).siblings();

            // Add/remove selected styles to list category heading
            if (subHeadingEl) {
                toggleClass($(subHeadingEl), SUBHEADING_OPEN_CLASS);
            }

            // Reveal/hide the sublist
            if (subListEl && subListEl.length === 1) {
                toggleClass($(subListEl), SUBLIST_HIDDEN_CLASS);
            }
        });
    });
}

function toggleClass(el, className) {
    if (el.hasClass(className)) {
        el.removeClass(className);
    } else {
        el.addClass(className);
    }
}



