using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Airplane : BaseEntity
    {
        public String Id {get; set; }
        public String Name {get; set; }
        public int License_Plate {get; set; }
        public int Capacity { get; set; }
        public String Model { get; set; }
        public String Brand { get; set; }
        public String Id_Airline {get; set;}
        public bool Status { get; set; }
    }
}
