using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class IdManagement
    {
        private readonly IdCrudFactory crudId;

        public IdManagement()
        {
            crudId = new IdCrudFactory();
        }

        public void Create(IdFligth id)
        {   
            crudId.Create(id);
        }
        public List<IdFligth> RetrieveAll()
        {
            return crudId.RetrieveAll<IdFligth>();
        }


    }
}
