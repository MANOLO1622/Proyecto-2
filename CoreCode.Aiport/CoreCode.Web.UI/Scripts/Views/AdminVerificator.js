

function verifyAccount() {


    this.startVerification = function () {
        console.log("Iniciando verificacion");
        try {
            var email = JSON.parse(sessionStorage["userObject"]).Email;
            console.log("Email encontrado: " + email)
            var role = this.getRole(email);
            
            var isAdmin = role === 1;//Reemplazar por el numero del Role del usuario, o el administrador de aeropuerto, o, el admin general
            if (!isAdmin) {
                window.location.href = "http://localhost:57312";
            }
        } catch (error) {
            window.location.href = "http://localhost:57312";
        }
    }

    this.getRole = function (pemail) {
        console.log("Verificando ", pemail)
        var con = new connector();
        var role = con.GetFromAPISync("http://localhost:54982/api/role?email=" + encodeURIComponent(pemail)).Data;
        return role;
    }
}

this.verifyAccount = new verifyAccount();
this.verifyAccount.startVerification();


function connector() {

    this.GetFromAPISync = function (purl) {
        var responseFromSync;

        $.ajax({
            url: purl,
            type: 'GET',
            success: function (response) {
                responseFromSync = response;
            },
            data: null,
            async: false
        });
        return responseFromSync;
    }
}


