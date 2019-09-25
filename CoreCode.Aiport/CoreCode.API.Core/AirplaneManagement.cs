using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class AirplaneManagement
    {

        private readonly AirplaneCrudFactory crudAirplane;

        public AirplaneManagement()
        {
            crudAirplane = new AirplaneCrudFactory();
        }

        public void Create(Airplane airplane)
        {
            crudAirplane.Create(airplane);
        }

        public List<Airplane> RetrieveAllAirplane()
        {
            return crudAirplane.RetrieveAll<Airplane>();
        }

        /*public List<Airplane> RetrieveWaitingAirplans()
        {
            return crudAirplane.RetrieveWaitingAirplans<Airplane>();
        }

        public List<Airplane> RetrieveAcceptedAirplans()
        {
            return crudAirplane.RetrieveAcceptedAirplans<Airplane>();
        }

        public List<Airplane> RetrieveDeniedAirplans()
        {
            return crudAirplane.RetrieveDeniedAirplans<Airplane>();
        }

        public List<Airplane> RetrieveAvailableAirplans()
        {
            return crudAirplane.RetrieveAvailableAirplans<Airplane>();
        }

        public List<Airplane> RetrieveUnvailableAirplans()
        {
            return crudAirplane.RetrieveUnvailableAirplans<Airplane>();
        }

        public List<Airplane> RetrieveAssociatedAirplans(Airplane airplane)
        {
            return crudAirplane.RetrieveAssociatedAirplans<Airplane>(airplane);
        }

        public List<Airplane> RetrieveRejectedAirplans(Airplane airplane)
        {
            return crudAirplane.RetrieveRejectedAirplans<Airplane>(airplane);
        }

        public List<Airplane> RetrieveWaitingAirplans(Airplane airplane)
        {
            return crudAirplane.RetrieveWaitingAirplans<Airplane>(airplane);
        }


        public Airplane RetrieveById(Airplane airplane)
        {
            return crudAirplane.Retrieve<Airplane>(airplane);
        }*/

        public void Update(Airplane airplane)
        {
            crudAirplane.Update(airplane);
        }

        public void Delete(Airplane airplane)
        {
            crudAirplane.Delete(airplane);
        }


    }
}
