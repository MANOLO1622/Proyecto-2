using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class PriceManagement
    {
        private readonly PriceCrudFactory crudPrice;

        public PriceManagement()
        {
            crudPrice = new PriceCrudFactory();
        }

        public void Create(PriceAmount price)
        {   
            crudPrice.Create(price);
        }
        public List<PriceAmount> RetrieveAll()
        {
            return crudPrice.RetrieveAll<PriceAmount>();
        }


    }
}
