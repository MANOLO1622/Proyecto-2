﻿using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CoreCode.API.Core.Helpers;
using CoreCode.API.Core.Managers;

namespace CoreCode.API.Core
{
    public class LoginManager : IManager
    {
        private readonly LoginCrudFactory crudLoginManager;
        
        public LoginManager()
        {
            crudLoginManager = new LoginCrudFactory();
        }

        public List<UserLogin> RetrieveAll()
        {
            return crudLoginManager.RetrieveAll<UserLogin>();
        }

        public void Update(User user)
        {
            crudLoginManager.Update(user);
        }

        public User RetrieveByUserNameAndPassword(string userName, string password)
        {
            var createdUser = new User
            {
                Email = userName,
                Password = EncryptionHelper.Encrypt(password)
            };
            return crudLoginManager.Retrieve<User>(createdUser);
        }

        public User CheckIfUserExists(string userName)
        {
            var createdUser = new User
            {
                Email = userName
            };
            return crudLoginManager.UserExists<User>(createdUser);
        }

        
        public User CheckIfUserExistsByUserOrId(string userName, string userId)
        {
            var createdUser = new User
            {
                Email = userName,
                ID = userId
            };
            return crudLoginManager.UserExistsByUserNameOrId<User>(createdUser);
        }

        public void  RecoverPasswordAdminAirline(User user)
        {
            crudLoginManager.UpdatePsswdAdminAirline(user);
        }

        public void RecoverPasswordAdminAirport(User user)
        {
            crudLoginManager.UpdatePsswdAdminAirport(user);
        }
    }
}
