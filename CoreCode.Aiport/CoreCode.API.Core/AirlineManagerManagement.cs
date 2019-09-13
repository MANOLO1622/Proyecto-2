using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System.Collections.Generic;
using CoreCode.API.Core.Helpers;

namespace CoreCode.API.Core
{
    public class AirlineManagerManagement
    {
        private readonly AirlineManagerCrudFactory crudAirlineManager;

        public AirlineManagerManagement()
        {
            crudAirlineManager = new AirlineManagerCrudFactory();
        }

        public void Create(AirlineManager manager)
        {
            crudAirlineManager.Create(manager);
        }

        public List<AirlineManager> RetrieveAll()
        {
            return crudAirlineManager.RetrieveAll<AirlineManager>();
        }

        public AirlineManager RetrieveById(AirlineManager manager)
        {
            return crudAirlineManager.Retrieve<AirlineManager>(manager);
        }
        public AirlineManager RetrieveAdminAirlineByAirAirlineId(AirlineManager manager)
        {
            return crudAirlineManager.RetrieveAdminAirlineByAirlineId<AirlineManager>(manager);
        }

        public void Update(AirlineManager manager)
        {
            manager.Password = EncryptionHelper.GetEncryptedMd5Value(manager.Password);
            crudAirlineManager.Update(manager);
        }

        public void Delete(AirlineManager manager)
        {
            crudAirlineManager.Delete(manager);
        }
    }
}
