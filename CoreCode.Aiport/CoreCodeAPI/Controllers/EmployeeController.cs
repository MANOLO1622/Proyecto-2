﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreCode.API.Core;
using CoreCode.API.Core.Helpers;
using CoreCode.API.Core.Managers;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.Helpers;
using CoreCodeAPI.Models;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();
        EmployeeManagement mng = new EmployeeManagement();

        [Route("api/getEmployee")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getEmployee", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getEmployee", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/postEmployee")]
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                var CorreoElectronico = employee.Email;
                var pass = employee.Password;
                string Mensaje = "Estimad@ " + employee.FirstName + "  " + employee.FirstLastName + " <br/><br/> " + "Su contraseña de inicio es: " + pass;
                ToolsHelper.SendMail(CorreoElectronico, "Confirmación de cuenta", Mensaje);                
                employee.Password = EncryptionHelper.Encrypt(employee.Password);
                mng.Create(employee);
                apiResp = new ApiResponse
                {
                    Message = "Action was executed"
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "postEmployee", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "postEmployee", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }
        //UPDATE
        [Route("api/updateEmployee")]
        public IHttpActionResult Put(Employee employee)
        {
            try
            {
                var mng = new EmployeeManagement();
                mng.Update(employee);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateEmployee", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateEmployee", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/Employees/delete")]
        public IHttpActionResult Delete(Employee employee)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EmployeeManager();
                mng.Delete(employee);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "Employees/delete", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "Employees/delete", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
        [Route("api/getUserByRolId")]
        public IHttpActionResult Get(int rolId)
        {
            try
            {
                var mng = new EmployeeManagement();
                var employee = new Employee
                {
                    Rol = rolId
                };

                employee = mng.RetrieveById(employee);
                apiResp = new ApiResponse();
                apiResp.Data = employee;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getUserByRolId", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getUserByRolId", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
        [Route("api/getEmployeeById")]
        public IHttpActionResult GetEmployeeById(string id)
        {
            try
            {
                var employee = new Employee
                {
                    ID = id
                };

                employee = mng.RetrieveByEmployeeId(employee);
                apiResp.Data = employee;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getEmployeeById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getEmployeeById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

    }
}