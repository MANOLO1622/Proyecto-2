using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class UserManagement
    {
        private UserCrudFactory crudUser;

        public UserManagement()
        {
            crudUser = new UserCrudFactory();
        }

        public void Create(User user)
        {

            crudUser.Create(user);

        }


        public List<User> RetrieveAll()
        {
            return crudUser.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            return crudUser.Retrieve<User>(user);
        }

        public User RetrieveByRol(User user)
        {
            return crudUser.Retrieve<User>(user);
        }
        internal void Update(User user)
        {
            crudUser.Update(user);
        }

        internal void Delete(User user)
        {
            crudUser.Delete(user);
        }
    }
}
