using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Money : BaseEntity
    {
        public string IDMoney { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool Status { get; set; }
        public String Precio { get; set; }


    }
}
