using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An user. </summary>
    ///
    /// <remarks>   Celopez, 4/17/2019. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Employee: BaseEntity
    {
        public String ID { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String FirstLastName { get; set; }
        public String SecondLastName { get; set; }
      //  public DateTime BirthDate { get; set; }
        public String BirthDate { get; set; }
        public String Genre { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public String CivilStatus { get; set; }
        public bool Status { get; set; }
        public int Rol { get; set; }
        public String AssignedID { get; set; }
        public String Age { get; set; }
        public String Address { get; set; }
        public String Nationality { get; set; }
        public String Province { get; set; }
        public String Canton { get; set; }
        public String District { get; set; }
        public String Experience { get; set; }
        // public String FormattedYear => GraduationYear.ToString("dd-MM-yyyy");
        // public DateTime GraduationYear { get; set; }
        public String GraduationYear { get; set; }
        public String License { get; set; }
        public String Put { get; set; }
    }
}
