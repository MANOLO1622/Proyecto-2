using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Reservation : BaseEntity
    {
        public string IDReservation { get; set; }
        public string FirstName { get; set; }//nombre del usuario
        public string FirstLastName { get; set; }//apellidos
        public bool Status { get; set; }//Estado
        public string Destiny { get; set; }//nombre de la ciudad o pais
        public Decimal Price { get; set; }//precio del ticket
        public DateTime Buy_Date { get; set; }//fecha de viaje


    }
}
