using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class EmployeeManagement
    {
        private readonly EmployeeCrudFactory crudEmployee;

        public EmployeeManagement()
        {
            crudEmployee = new EmployeeCrudFactory();
        }



        public void Create(Employee employee)
        {
            crudEmployee.Create(employee);
        }

        public List<Employee> RetrieveAll()
        {
            return crudEmployee.RetrieveAll<Employee>();
        }

        public Employee RetrieveById(Employee employee)
        {
            return crudEmployee.Retrieve<Employee>(employee);
        }

        public void Update(Employee employee)
        {
            crudEmployee.Update(employee);
        }

        public void Delete(Employee employee)
        {
            crudEmployee.Delete(employee);
        }
    }
}
