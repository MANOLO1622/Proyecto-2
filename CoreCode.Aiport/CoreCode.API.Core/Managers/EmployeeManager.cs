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
    public class EmployeeManager : IManager
    {
        private readonly EmployeeCrudFactory _crudFactory;

        public EmployeeManager()
        {
            _crudFactory = new EmployeeCrudFactory();
        }

        public Employee RetrieveEmployee(Employee employee)
        {
            Employee reportToReturn = null;
            try
            {
                reportToReturn = _crudFactory.RetrieveByEmployeeId<Employee>(employee);
                if (reportToReturn == null)
                {
                    throw new BussinessException(5);
                }
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reportToReturn;
        }

        public void Create(Employee employee)
        {
            
            _crudFactory.Create(employee);
        }
        
        public void Update(Employee employee)
        {
            _crudFactory.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _crudFactory.Delete(employee);
        }

    }
}
