using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class PriceAmount : BaseEntity
    {
        public String Id { get; set; }
        public Decimal Price { get; set; }


    }
}
