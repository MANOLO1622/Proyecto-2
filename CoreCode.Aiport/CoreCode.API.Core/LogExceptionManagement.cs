using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;

namespace CoreCode.API.Core
{
    public class LogExceptionManagement
    {
        private readonly LogExceptionCrudFactory crudLogException;

        public LogExceptionManagement()
        {
            crudLogException = new LogExceptionCrudFactory();
        }

        public void Create(LogException exception)
        {
            crudLogException.Create(exception);
        }

        public List<LogException> RetrieveAll()
        {
            return crudLogException.RetrieveAll<LogException>();
        }

        public void RecordException(int session, string message, DateTime date, string user, string stack, string backtrace)
        {
            LogException exception = new LogException() { Session_Id = session, Message = message, Datetime = date, User = user, Stack = stack, Backtrace = backtrace };
            Create(exception);
        }
    }
}