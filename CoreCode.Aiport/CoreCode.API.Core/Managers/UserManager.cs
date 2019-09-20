using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.API.Core.Helpers;
using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;

namespace CoreCode.API.Core.Managers
{
    public class UserManager : IManager
    {
        private readonly UserCrudFactory _crudFactory;

        public UserManager()
        {
            _crudFactory = new UserCrudFactory();
        }

        public User RetrieveUser(string userId)
        {
            User reportToReturn = null;
            try
            {
                reportToReturn = _crudFactory.RetrieveByUserId<User>(userId);
                if (reportToReturn == null)
                {
                    throw new BussinessException(4);
                }
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reportToReturn;
        }
        public User RetrieveUsersByRol(BaseEntity entity)
        {
            User reportToReturn = null;
            try
            {
                reportToReturn = _crudFactory.Retrieve<User>(entity);
                if (reportToReturn == null)
                {
                    throw new BussinessException(4);
                }
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reportToReturn;
        }
        

        public void Create(User user)
        {
            
            _crudFactory.Create(user);
        }
        
        public void Update(User user)
        {
            _crudFactory.Update(user);
        }

        public void Delete(User user)
        {
            _crudFactory.Delete(user);
        }

    }
}
