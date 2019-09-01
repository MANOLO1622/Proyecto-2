function vListEmployeesRequest() {


    this.tblEmployeeRequestId = 'tblEmployeeRequest';
    this.rolUser = "5";
    this.rolId = localStorage.getItem('idEmployeeLS');
    this.ctrlActions = new ControlActions();
    this.columns = "ID", "FirstName", "FirstLastName", "SecondLastName", "Put", "Email";

   

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getEmployees', this.tblEmployeeRequestId, false, 'Buscar:', 'Cédula o Nombre');
    }


    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblEmployeeRequestId);

    }



    this.Update = function () {



        var instance = this;

        if (!this.Validate()) {


            var employeeData = {};
            employeeData = this.ctrlActions.GetDataForm('frmEditionEmployee');
            //Hace el post al create
            employeeData.Request = 'accepted';
            employeeData.Status = true;
            //employeeData.Creation_year = employeeData.FormattedYear;
            instance.ctrlActions.PostToAPI('updateEmployee', employeeData, function () {

                swal({
                    title: "¡Empleado modificada!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    
                });
            });

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

    //this.BindFields = function (data) {
    //    this.ctrlActions.BindFields('frmEditionEmployee', data);
    //    document.getElementById("txtId").setAttribute("disabled", "disabled");
    //}


    //this.CleanForm = function () {
    //    let aInputs = document.querySelectorAll(':required');

    //    for (let i = 0; i < aInputs.length; i++) {
    //        aInputs[i].value = '';
    //    }
    //}   


    //this.Validate = function () {
    //    let aInputs = document.querySelectorAll(':required');
    //    let bError = false;

    //    for (let i = 0; i < aInputs.length; i++) {
    //        if (aInputs[i].value === '') {
    //            bError = true;
    //            aInputs[i].classList.add('input-error');
    //        }
    //        else {
    //            aInputs[i].classList.remove('input-error');
    //        }

    //    }
    //    return bError;

    //}

}

//ON DOCUMENT READY
$(document).ready(function () {

    //document.querySelector("#btnAdmin").classList.add('hide');
    //document.querySelector('#txtId').disabled = true;
    //document.querySelector('#txtEmail').disabled = true;
    var vlistemployeerequest = new vListEmployeesRequest();




    if (vlistemployeerequest.rolUser == "5") {
        
        document.querySelector("#btnEdit").classList.remove('hide');
        document.querySelector("#btnClean").classList.add('hide');



        let idUser = {
            id: localStorage.getItem('idEmployeeLS')//saca session storage IDAssigned
        };
        let user;
        let callback = function (response) {

            user = response.Data;
            document.querySelector('#txtId').value = localStorage.getItem('idEmployeeLS');
            document.querySelector('#txtFirstName').value = user.FirstName;
            document.querySelector('#txtFirstLastName').value = user.FirstLastName;
            document.querySelector('#txtSecondLastName').value = user.SecondLastName;
            document.querySelector('#txtPut').value = user.Put;
            document.querySelector('#txtEmail').value = user.Email;

        };
        ApiService.getFromAPI("/getUserByRolId", idUser.id, callback);
    }


});
