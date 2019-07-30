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
        private readonly EmployeeCrudFactory crudFaq;

        public EmployeeManagement()
        {
            crudFaq = new EmployeeCrudFactory();

        }

        public void Create(Employee employee)
        {

            var c = crudFaq.Retrieve<Employee>(employee);

            if (c != null)
            {
                //FAQ already exist

            }
            else { crudFaq.Create(employee); }



        }

        public List<Employee> RetrieveAll()
        {
            return crudFaq.RetrieveAll<Employee>();
        }

        public Employee RetrieveById(Employee employee)
        {
            return crudFaq.Retrieve<Employee>(employee);
        }

        public void Update(Employee employee)
        {
            crudFaq.Update(employee);
        }

        public void Delete(Employee employee)
        {
            crudFaq.Delete(employee);
        }
    }
}
