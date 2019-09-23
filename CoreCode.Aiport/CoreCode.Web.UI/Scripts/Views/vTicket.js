function vTicket() {

    // agarrar email session storagevar emailuser = '';
    this.tblTicketId = 'tblTickets';
    this.service = 'ticket';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Id_Flight, Ticket_Class, Status, Price, Buy_Date, Id_User, Person_Name";

    this.TicketStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "a tiempo") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveATiempo();

        }
        else if (document.querySelector('#statusFilter').value === "cancelado") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveCancelado();

        }

        else if (document.querySelector('#statusFilter').value === "retrasado") {
            this.ctrlActions.ClearTable(this.tblTicketId);
            this.RetrieveRetrasado();

        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getTickets', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveATiempo = function () {
        this.ctrlActions.FillTable('getTicketOnTime', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }

    this.RetrieveCancelado = function () {
        this.ctrlActions.FillTable('getTicketCanceled', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }
    this.RetrieveRetrasado = function () {
        this.ctrlActions.FillTable('getTicketDelay', this.tblTicketId, false, 'Buscar:', 'Código o nombre');
    }
    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblTicketId);
    }

    this.Paypal = function () {

    };

    this.Create = function () {
        if (!this.Validate()) {
            var TicketData = {};
            var instance = this;
            TicketData = this.ctrlActions.GetDataForm('frmEdition');
            TicketData.Status = "a tiempo";
           
            //Hace el post al create
            // 
            this.ctrlActions.PostToAPI('createTicket', TicketData, function (response) {
                swal({
                    title: "¡Compra realizada!",
                    text: "Le llegará un correo con los datos de su compra",
                    icon: "success",
                    button: "OK",
                });
                instance.ReloadTable();
                instance.CleanForm();
            });


            this.CleanForm();

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
    this.ValidateUpdate = function () {
        var instance = this;
        var error = false;
        var selectDropdown = document.getElementById("txtStatus");
        if (selectDropdown) {
            if (selectDropdown.value !== "") {
                error = false;
            } else {
                error = true;
            }
        }
        return error;
    }
    this.Update = function () {

        var instance = this;
        instance.DisplayInsertForm();
        if (!instance.ValidateUpdate()) {
            var ticketData = {};
            if (window.currentSelectedRow) {
                window.currentSelectedRow.remove();
                window.currentSelectedRow = null;
            }
            ticketData = instance.ctrlActions.GetDataForm('frmEdition');
            ticketData.Status = ticketData[""];
            instance.ctrlActions.PostToAPI('updateTicket', ticketData, function () {
                swal({
                    title: "¡Ticket modificado!",
                    text: "",
                    icon: "success",
                    button: "OK"
                }).then(function () {
                    //Refresca la tabla
                    instance.CleanForm();
                    instance.ReloadTable();
                    
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

        instance.ReloadTable();


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
        return bError;

    }


    ///fLIGHT SE ELIMINA??
    /*this.Delete = function () {

        var categoryData = {};
        categoryData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, categoryData);
        //Refresca la tabla
        this.ReloadTable();

    }*/
    //esconde los campos
    this.BindFields = function (data, selectedRow) {
        var instance = this;
        document.getElementById("btnEditTicket").style.display = 'block';
        document.getElementById("btnRegisterTicket").style.display = 'none';
        window.currentSelectedRow = selectedRow;
        var txtStatusElement = $("#txtStatos");
        this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
       // document.getElementById("txtStatus").style.display = 'none';
        document.getElementById("txtId_Flight").style.display = 'none';
        document.getElementById("txtPrice").style.display = 'none';
        document.getElementById("txtBuy_Date").style.display = 'none';
        document.getElementById("txtId_User").style.display = 'none';
        document.getElementById("txtPerson_Name").style.display = 'none';
        document.querySelector("label[for='txtId_Flight']").style.display = 'none';
        //document.querySelector("label[for='txtStatus']").style.display = 'none';
        document.querySelector("label[for='txtPrice']").style.display = 'none';
        document.querySelector("label[for='txtBuy_Date']").style.display = 'none';
        document.querySelector("label[for='txtId_User']").style.display = 'none';
        document.querySelector("label[for='txtPerson_Name']").style.display = 'none';
        document.querySelector("label[for='selectCivilStatus']").style.display = 'none';
        
        txtStatusElement.show();
        txtStatusElement.val(data.Status);
    }

    this.DisplayInsertForm = function () {
        var instance = this;
        var txtStatusElement = $("#txtStatos");
        document.getElementById("btnEditTicket").style.display = 'none';
        document.getElementById("btnRegisterTicket").style.display = 'block';
        //instance.ctrlActions.BindFields('frmEdition', data);
        var txtIdElement = document.getElementById("txtId");

        //document.getElementById("txtStatus").style.display = 'block';
        document.getElementById("txtId_Flight").style.display = 'block';
        document.getElementById("txtPrice").style.display = 'block';
        document.getElementById("txtBuy_Date").style.display = 'block';
        document.getElementById("txtId_User").style.display = 'block';
        document.getElementById("txtPerson_Name").style.display = 'block';
        document.querySelector("label[for='txtStatus']").style.display = 'block';
        document.querySelector("label[for='txtId_Flight']").style.display = 'block';
        document.querySelector("label[for='txtStatus']").style.display = 'block';
        document.querySelector("label[for='txtPrice']").style.display = 'block';
        document.querySelector("label[for='txtBuy_Date']").style.display = 'block';
        document.querySelector("label[for='txtId_User']").style.display = 'block';
        document.querySelector("label[for='txtPerson_Name']").style.display = 'block';
        


        txtIdElement.setAttribute("disabled", "");
        txtIdElement.setAttribute("enabled", "enabled");
        txtStatusElement.hide();
    }


    this.CleanForm = function () {

        document.querySelector("txtId_Flight").value = '';
        document.querySelector("txtPrice").value = '';
        document.querySelector("txtBuy_Date").value = '';
        document.querySelector("txtId_User").value = '';
        document.querySelector("txtPerson_Name").value = '';
        document.getElementById("Ticket_Class").selectedIndex = -1;


        //document.querySelector("Ticket_Class").

        

        //document.querySelector('#txtId').value = '';
        //document.querySelector('#txtDescription').value = '';
        //document.querySelector('#txtId').disabled = false;


        //let aInputs = document.querySelectorAll(':required');
        //for (let i = 0; i < aInputs.length; i++) {
        //    aInputs[i].classList.remove('input-error');
        // }

    }
}

$(document).ready(function () {

   document.querySelector("#txtId").disabled = true;
    //document.querySelector("#txtId_Flight").disabled = true;
    document.querySelector("#txtStatus").disabled = true;
    //document.querySelector("#txtPrice").disabled = true;
   // document.querySelector("#txtBuy_Date").disabled = true;
    //document.querySelector("#txtId_Person").disabled = true;
   // var datenow = new Date().toString();
    //document.getElementById("#txtBuy_Date").innerHTML(datenow);
    //txtId_Flight

  //  var now = new Date();

   var note = new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString().split('.')[0];

    var prueba = note.toString("'yyyy-MM-dd'T'HH:mm'");

    $('#txtBuy_Date').val(prueba);
    $('#txtStatus').val("a tiempo");
   

    $('#txtId').val(generar());
   // $('#txtBuy_Date').val(new Date().toDateInputValue()); 
    var vticket = new vTicket();
    vticket.RetrieveATiempo();


    //Función para generar la clave de reservación 
    function generar() {
        var caracteres = "ABCDEFGHIJKLMNPQRTUVWXYZ2346789";
        var reservation = "";
        var longitud = 6;
        for (i = 0; i < longitud; i++) reservation += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
        return reservation;
    }

    var dataTable = $('#tblTickets').DataTable();
    //hide the first and second columns
    dataTable.columns([0]).visible(false);
});