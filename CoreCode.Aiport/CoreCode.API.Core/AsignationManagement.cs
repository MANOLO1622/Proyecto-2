using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class AsignationManagement
    {

        private readonly AsignationCrudFactory crudAsignation;

        public AsignationManagement()
        {
            crudAsignation = new AsignationCrudFactory();
        }

        public void Create(Asignation asignation)
        {
            crudAsignation.Create(asignation);
        }

        public List<Asignation> RetrieveAll()
        {
            return crudAsignation.RetrieveAll<Asignation>();
        }


        public Asignation RetrieveById(Asignation asignation)
        {
            return crudAsignation.Retrieve<Asignation>(asignation);
        }



    }
}
