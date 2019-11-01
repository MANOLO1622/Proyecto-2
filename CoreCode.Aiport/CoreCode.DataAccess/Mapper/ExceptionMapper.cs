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
    public class LogExceptionMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_EXCEPTION_ID = "EXCEPTION_ID";
        private const string DB_COL_SESSION_ID = "SESSION_ID";
        private const string DB_COL_MESSAGE = "MESSAGE";
        private const string DB_COL_DATETIME = "DATETIME";
        private const string DB_COL_USER = "USER";
        private const string DB_COL_STACK = "STACK";
        private const string DB_COL_BACKTRACE = "BACKTRACE";

        //hace una instancia del pojo de Exception
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var exception = new LogException
            {
                Exception_Id = GetIntValue(row, DB_COL_EXCEPTION_ID),
                Session_Id = GetIntValue(row, DB_COL_SESSION_ID),
                Message = GetStringValue(row, DB_COL_MESSAGE),
                Datetime = GetDateValue(row, DB_COL_DATETIME), 
                User = GetStringValue(row, DB_COL_USER),
                Stack = GetStringValue(row, DB_COL_STACK),
                Backtrace = GetStringValue(row, DB_COL_BACKTRACE)
            };

            return exception;
        } 

        public LogException BuildObjectFromDataRow(Dictionary<string, object> row)
        {
            var exception = new LogException
            {
                Exception_Id = GetIntValue(row, DB_COL_EXCEPTION_ID),
                Session_Id = GetIntValue(row, DB_COL_SESSION_ID),
                Message = GetStringValue(row, DB_COL_MESSAGE),
                Datetime = GetDateValue(row, DB_COL_DATETIME),
                User = GetStringValue(row, DB_COL_USER),
                Stack = GetStringValue(row, DB_COL_STACK),
                Backtrace = GetStringValue(row, DB_COL_BACKTRACE)
            };
            return exception;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var exception = BuildObject(row);
                lstResults.Add(exception);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_AddLogException" };
            var m = (LogException)entity;

            operation.AddIntParam(DB_COL_SESSION_ID, m.Session_Id);
            operation.AddVarcharParam(DB_COL_MESSAGE, m.Message);
            operation.AddDateParam(DB_COL_DATETIME, m.Datetime);
            operation.AddVarcharParam(DB_COL_USER, m.User);
            operation.AddVarcharParam(DB_COL_STACK, m.Stack);
            operation.AddVarcharParam(DB_COL_BACKTRACE, m.Backtrace);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetAllExceptions" };
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

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}


