function vCategories() {


    this.tblCategoryId = 'tblCategory';
    this.service = 'category';
    this.ctrlActions = new ControlActions();
    this.columns = "IDCategory,Description,Abbreviation";

    this.CategoryStatusDropdownChange = function () {

        if (document.querySelector('#statusFilter').value === "true") {

            document.querySelector("#btnEnable").classList.add('hide');
            document.querySelector("#btnDisable").classList.remove('hide');
            this.ctrlActions.ClearTable(this.tblCategoryId);
            this.RetrieveAvailable();
          
        }
        else if (document.querySelector('#statusFilter').value === "false") {
            document.querySelector("#btnEnable").classList.remove('hide');
            document.querySelector("#btnDisable").classList.add('hide');
            this.ctrlActions.ClearTable(this.tblCategoryId);
            this.RetrieveUnavailable();
         
        }

    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable('getCategories', this.tblCategoryId, false, 'Buscar:', 'Código o descripción');
    }

    this.RetrieveAvailable = function () {
        this.ctrlActions.FillTable('getAvailableCategories', this.tblCategoryId, false, 'Buscar:', 'Código o descripción');
    }
    this.RetrieveUnavailable = function () {
        this.ctrlActions.FillTable('getUnavailableCategories', this.tblCategoryId, false, 'Buscar:', 'Código o descripción');
    }

    this.ReloadTable = function () {
        this.ctrlActions.ReloadTable(this.tblCategoryId);
    }

    this.Create = function () {


        if (document.querySelector('#txtId').value == '' &&
            document.querySelector('#txtDescription').value != '')
            document.querySelector('#txtAbbreviation').value != ''){

            document.querySelector('#txtId').classList.remove('input-error');
            document.querySelector('#txtDescription').classList.remove('input-error');
            document.querySelector('#txtAbbreviation').classList.remove('input-error');

            var instance = this;
            if (!this.Validate()) {
                var categoryData = {};
                categoryData = this.ctrlActions.GetDataForm('frmEdition');
                categoryData.Status = true;

                let categories;
                let cont = 0;
                let callback = function (response) {
                    categories = response.Data;
                    for (let i = 0; i < categories.length; i++) {
                        cont++;
                    }
                    cont = cont + 1;
                    //Hace el post al create

                    categoryData.IDCategory = "COD-" + cont.toString();

                    instance.ctrlActions.PostToAPI('postCategory', categoryData, function () {
                        //Refresca la tabla
                        swal({
                            title: "¡País registrado!",
                            text: "",
                            icon: "success",
                            button: "OK",
                        }).then(function () {
                            instance.CleanForm();
                            instance.ReloadTable();
                        });
                    });
                }
                instance.ctrlActions.GetFromAPI("/getCategories", "", callback);

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
        else {

            document.querySelector('#txtId').classList.add('input-error');
            document.querySelector('#txtDescription').classList.add('input-error');
            document.querySelector('#txtAbbreviation').classList.add('input-error');

            swal({
                title: "¡Error en el registro!",
                text: "No se puede registrar el país que ya se encuentra en el sistema",
                icon: "error",
                button: "OK",
            });
        }

           
       
     
      
    }

    this.Update = function () {

     
        var instance = this;

        if (!this.Validate()) {

            var categoryData = {};
            categoryData = this.ctrlActions.GetDataForm('frmEdition');
            categoryData.Status = true;
            this.ctrlActions.PostToAPI('updateCategory', categoryData);


            instance.ctrlActions.PostToAPI('updateCategory', categoryData, function () {
                //Refresca la tabla
                swal({
                    title: "¡País actualizado!",
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
                title: "¡Error al modificar el país!",
                text: "Por favor, seleccionar un país a modificar en la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Enable = function () {


        var instance = this;

        if (!this.Validate()) {

            var categoryData = {};
            categoryData = this.ctrlActions.GetDataForm('frmEdition');
            categoryData.Status = true;
            this.ctrlActions.PostToAPI('updateCategory', categoryData);


            instance.ctrlActions.PostToAPI('updateCategory', categoryData, function () {
                //Refresca la tabla
                swal({
                    title: "¡Pais habilitado!",
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
                title: "¡Error al habilitar el país!",
                text: "Por favor, seleccionar un país de la tabla",
                icon: "error",
                button: "OK",
            });
        }


    }


    this.Disable = function () {

        var instance = this;

        if (!this.Validate()) {

            var categoryData = {};
            categoryData = this.ctrlActions.GetDataForm('frmEdition');
            categoryData.Status = false;
            this.ctrlActions.PostToAPI('updateCategory', categoryData);
            
            instance.ctrlActions.PostToAPI('updateCategory', categoryData, function () {
                //Refresca la tabla
                swal({
                    title: "¡País deshabilitada!",
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
                title: "¡Error al deshabilitar el país!",
                text: "Por favor, seleccionar un país de la tabla",
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
            return bError;

        }

    

    this.BindFields = function (data) {
       this.ctrlActions.BindFields('frmEdition', data);
        document.getElementById("txtId").setAttribute("disabled", "disabled");
    }


    this.CleanForm = function(){
        document.querySelector('#txtId').value = '';
        document.querySelector('#txtDescription').value = '';
        document.querySelector('#txtAbbreviation').value = '';
        document.querySelector('#txtId').classList.remove('input-error');
        document.querySelector('#txtDescription').classList.remove('input-error');
        document.querySelector('#txtAbbreviation').classList.remove('input-error');
      

    }
}

//ON DOCUMENT READY
$(document).ready(function () {

  //  document.querySelector("#tblCategory").classList.add('fixed_header');
    document.querySelector("#txtId").disabled = true;
    document.querySelector("#btnEnable").classList.add('hide');
    var vcategory = new vCategories();
    vcategory.RetrieveAvailable();

});
