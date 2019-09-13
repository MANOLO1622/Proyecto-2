using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CoreCode.DataAccess.Mapper
{
    //clase creada para funcionalidad del login
    public class UserMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "FIRST_NAME";
        private const string DB_COL_SECOND_NAME = "SECOND_NAME";
        private const string DB_COL_FIRST_LAST_NAME = "FIRST_LAST_NAME";
        private const string DB_COL_SECOND_LAST_NAME = "SECOND_LAST_NAME";
        private const string DB_COL_BIRTHDATE = "BIRTHDATE";
        private const string DB_COL_GENRE = "GENRE";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_CIVIL_STATUS = "CIVIL_STATUS";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_AGE = "AGE";
        private const string DB_COL_ADDRESS = "ADDRESS";
        private const string DB_COL_NATIONALITY = "NATIONALITY";
        private const string DB_COL_PROVINCE = "PROVINCE";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRICT = "DISTRICT";
        private const string DB_COL_EXPERIENCE = "EXPERIENCE";
        private const string DB_COL_GRADUATION_YEAR = "GRADUATION_YEAR";
        private const string DB_COL_LICENSE = "LICENSE";
        private const string DB_COL_PUT = "PUT";


        //hace una instancia del pojo de user
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            int x = 0;
            var User = new User
            {
                ID = GetStringValue(row, DB_COL_ID),
                FirstName =  GetStringValue(row,DB_COL_NAME),
                SecondName = GetStringValue(row,DB_COL_SECOND_NAME),
                FirstLastName=  GetStringValue(row, DB_COL_FIRST_LAST_NAME), 
                SecondLastName = GetStringValue(row,DB_COL_SECOND_LAST_NAME),
                BirthDate = GetStringValue(row, DB_COL_BIRTHDATE),
                Genre = GetStringValue(row, DB_COL_GENRE),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Phone = GetStringValue(row, DB_COL_PHONE),
                CivilStatus = GetStringValue(row, DB_COL_CIVIL_STATUS),
                Status = Convert.ToBoolean(GetBoolValue(row, DB_COL_STATUS)),
                //Status = GetBoolValue(row, DB_COL_STATUS),
                Rol = GetIntValue(row, DB_COL_ID_ROL),
                Age = GetStringValue(row, DB_COL_AGE),
                Address = GetStringValue(row, DB_COL_ADDRESS),
                Nationality = GetStringValue(row, DB_COL_NATIONALITY),
                Province = GetStringValue(row, DB_COL_PROVINCE),
                Canton = GetStringValue(row, DB_COL_CANTON),
                District = GetStringValue(row, DB_COL_DISTRICT),
                Experience = GetStringValue(row, DB_COL_EXPERIENCE),
                GraduationYear = GetStringValue(row, DB_COL_GRADUATION_YEAR),
                License = GetStringValue(row, DB_COL_LICENSE),
                Put = GetStringValue(row, DB_COL_PUT)


            };

            return User;
        }

        public User BuildObjectFromDataRow(DataRow row)
        {
            var user = new User
            {
                ID = row.Field<string>(DB_COL_ID),
                FirstName = row.Field<string>(DB_COL_NAME),
                SecondName = row.Field<string>(DB_COL_SECOND_NAME),
                FirstLastName = row.Field<string>(DB_COL_FIRST_LAST_NAME),
                SecondLastName = row.Field<string>(DB_COL_SECOND_LAST_NAME),
                BirthDate = row.Field<string>(DB_COL_BIRTHDATE),
                Genre = row.Field<string>(DB_COL_GENRE),
                Email = row.Field<string>(DB_COL_EMAIL),
                Password = row.Field<string>(DB_COL_PASSWORD),
                Phone = row.Field<string>(DB_COL_PHONE),
                CivilStatus = row.Field<string>(DB_COL_CIVIL_STATUS),
                Status = row.Field<bool>(DB_COL_STATUS),
                Rol = row.Field<int>(DB_COL_ID_ROL),
                Age = row.Field<string>(DB_COL_AGE),
                Address = row.Field<string>(DB_COL_ADDRESS),
                Nationality = row.Field<string>(DB_COL_NATIONALITY),
                Province = row.Field<string>(DB_COL_PROVINCE),
                Canton = row.Field<string>(DB_COL_CANTON),
                District = row.Field<string>(DB_COL_DISTRICT),
                Experience = row.Field<string>(DB_COL_EXPERIENCE),
                GraduationYear = row.Field<string>(DB_COL_GRADUATION_YEAR),
                License = row.Field<string>(DB_COL_LICENSE),
                Put = row.Field<string>(DB_COL_PUT)
            };
            return user;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_CreateUsers" };
            var m = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, m.ID);
            operation.AddVarcharParam(DB_COL_NAME, m.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, m.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, m.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, m.SecondLastName);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, m.BirthDate);
            operation.AddVarcharParam(DB_COL_GENRE, m.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, m.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, m.Password);
            operation.AddVarcharParam(DB_COL_PHONE, m.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, m.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, m.Status ? 1 : 0);
            operation.AddIntParam(DB_COL_ID_ROL, m.Rol);
            //operation.AddIntParam(DB_COL_ASIGNED, c.Asigned ? 1 : 0);
            operation.AddVarcharParam(DB_COL_AGE, m.Age);
            operation.AddVarcharParam(DB_COL_ADDRESS, m.Address);
            operation.AddVarcharParam(DB_COL_NATIONALITY, m.Nationality);
            operation.AddVarcharParam(DB_COL_PROVINCE, m.Province);
            operation.AddVarcharParam(DB_COL_CANTON, m.Canton);
            operation.AddVarcharParam(DB_COL_DISTRICT, m.District);
            operation.AddVarcharParam(DB_COL_EXPERIENCE, m.Experience);
            operation.AddVarcharParam(DB_COL_GRADUATION_YEAR, m.GraduationYear);
            operation.AddVarcharParam(DB_COL_LICENSE, m.License);
            operation.AddVarcharParam(DB_COL_PUT, m.Put);


            return operation;
        }
        
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_DeleteUser" };

            var m = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "GET_ALL_USERS" };
            

            return operation;
        }
            
        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            Console.WriteLine("Entro al metodo GetRetrieveStatement");
            var operation = new SqlOperation { ProcedureName = "CRE_OBTENER_USUARIO_POR_EMAIL_Y_PASSWORD_PR" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, userEntity.Password);
            return operation;
        }

        public SqlOperation GetRetrieveStatementByUser(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetUsersByUserName" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            return operation;
        }

        public SqlOperation GetRetrieveStatementByUserOrId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetUsersByUserNameOrId" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            operation.AddVarcharParam(DB_COL_ID, userEntity.ID);
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        //--- REINICIO DE CONTRASEÑA DE ADMIN AIPORT
        public SqlOperation UpdatePasswordAdminAirport(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEPSWDADMINAIRPORT" };

            var user = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, user.ID);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.Password);
            //operation.AddVarcharParam(DB_COL_ANSWER, user);

            return operation;
        }
        //--- REINICIO DE CONTRASEÑA DE USUARIO
        public SqlOperation UpdatePasswordUser(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEPASSWORDUSER" };

            var user = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, user.ID);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.Password);
            //operation.AddVarcharParam(DB_COL_ANSWER, user);

            return operation;
        }
        //--- REINICIO DE CONTRASEÑA DE ADMIN AIRLINE
        public SqlOperation UpdatePasswordAdminAirline(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEPSWDADMINAIRLINE" };
            var user = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, user.ID);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.Password);
            return operation;
        }

        public SqlOperation GetUpdateGeneralAdminStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateGeneralAdmin" };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetUpdateAirportAdmin(BaseEntity entity)
        {
            return CommonUpdateUser("sp_UpdateAirportAdmin", entity);
        }

        private SqlOperation CommonUpdateUser(string procName, BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = procName };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_NAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, c.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, c.FirstLastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, c.SecondLastName);
          //  operation.AddDateParam(DB_COL_BIRTHDATE, c.BirthDate);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, c.BirthDate);
            operation.AddVarcharParam(DB_COL_GENRE, c.Genre);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, c.CivilStatus);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Age);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Address);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Nationality);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Province);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Canton);
            operation.AddVarcharParam(DB_COL_EMAIL, c.District);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Experience);
            // operation.AddDateParam(DB_COL_EMAIL, c.GraduationYear);
            operation.AddVarcharParam(DB_COL_EMAIL, c.GraduationYear);
            operation.AddVarcharParam(DB_COL_EMAIL, c.License);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Put);
            return operation;
        }

        public SqlOperation GetUpdateAirlineAdmin(BaseEntity entity)
        {
            return CommonUpdateUser("sp_UpdateUsers", entity);
        }

        public SqlOperation GetUpdateUserAdmin(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateAirlineAdmin" };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetUserByUserId(string userId)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USERS" };
            operation.AddVarcharParam(DB_COL_ID, userId);
            return operation;
        }

        public SqlOperation GetRetrieveByRolStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "GET_ASIGNATION_ALL_BY_ROL" };
            var u = (User)entity;
            operation.AddIntParam(DB_COL_ID_ROL, u.Rol);
            return operation;
        }

        //public SqlOperation GetUserByRolId(int rolId)
        //{
        //    var operation = new SqlOperation { ProcedureName = "RET_ALL_EMPLOYEES" };
        //    operation.AddIntParam(DB_COL_ID_ROL, rolId);
        //    return operation;
        //}


    }

    //clase creada para funcionalidad del login
    public class UserLoginMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_ASSIGNEDID = "ASSIGNEDID";


        //hace una instancia del pojo de user
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {           
            var UserLogin = new UserLogin 
            {
                ID = GetStringValue(row, DB_COL_ID),
                Rol = GetIntValue(row, DB_COL_ID_ROL),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                AssignedId = GetStringValue(row, DB_COL_ASSIGNEDID),

            };

            return UserLogin;
        }

        public UserLogin BuildObjectFromDataRow(DataRow row)
        {
            var userLogin = new UserLogin
            {
                ID = row.Field<string>(DB_COL_ID),
                Rol = row.Field<int>(DB_COL_ID_ROL),
                Email = row.Field<string>(DB_COL_EMAIL),
                Password = row.Field<string>(DB_COL_PASSWORD),
                AssignedId = row.Field<string>(DB_COL_ASSIGNEDID)
            };
            return userLogin;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "GET_ALL_USERS" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}


