function vRequestEmployee() {

    this.EmployeeId = UserSession.getEmployeeSessionInstance().Id;//AGARRA IDASSIGNED DE SESSION STORAGE
    this.tblEmployeeId = 'tblEmployeeId';
    this.service = 'employee';
    this.ctrlActions = new ControlActions();
    this.columns = "ID", "FirstName", "SecondName", "FirstLastName", "SecondLastName", "BirthDate", "Genre", "Email",
        "Password", "Phone", "CivilStatus", "Status", "Rol", "Age", "Address", "Nationality", "Province", "Canton", "District", "Experience"
        , "GraduationYear","License","Put";

  

}

//ON DOCUMENT READY
$(document).ready(function () {

    var vrequestEmployee = new vRequestEmployee();
    vrequestEmployee.RetrieveAssociatedEmployees();

});
