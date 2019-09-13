using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class AsignationAirlineManagement
    {

        private readonly AsignationAirlineCrudFactory crudAsignationAirline;

        public AsignationAirlineManagement()
        {
            crudAsignationAirline = new AsignationAirlineCrudFactory();
        }

        public void Create(AsignationAirline asignationAirline)
        {
            crudAsignationAirline.Create(asignationAirline);
        }

        public List<AsignationAirline> RetrieveAll()
        {
            return crudAsignationAirline.RetrieveAll<AsignationAirline>();
        }


        public AsignationAirline RetrieveById(AsignationAirline asignationAirline)
        {
            return crudAsignationAirline.Retrieve<AsignationAirline>(asignationAirline);
        }



    }
}
