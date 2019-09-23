function vRequestUser() {

    this.UserId = UserSession.getUserSessionInstance().Id;//AGARRA IDASSIGNED DE SESSION STORAGE
    this.tblUserId = 'tblUser';
    this.service = 'user';
    this.ctrlActions = new ControlActions();
    this.columns = "ID", "FirstName", "SecondName", "FirstLastName", "SecondLastName", "BirthDate", "Genre", "Email",
        "Password", "Phone", "CivilStatus", "Status", "Rol", "Age", "Address", "Nationality", "Province", "Canton", "District", "Experience"
        , "GraduationYear","License","Put";

  

}

//ON DOCUMENT READY
$(document).ready(function () {

    var vrequestUser = new vRequestUser();
    vrequestUser.RetrieveAssociatedUsers();

});
