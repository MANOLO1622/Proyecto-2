using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Airplane : BaseEntity
    {
        public String Id_Airplane {get; set; }
        public String Name {get; set; }
        public int Quota_First_Class {get; set; }
        public int Quota_Second_Class { get; set; }
        public int Quota_Load { get; set; }
        public String Type { get; set; }
        public String Id_Airline {get; set;}
        public bool Status { get; set; }
    }
}
