using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CoreCode.API.Core;
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

        [Route("api/getEmployees")]
        public IHttpActionResult Get(string userId)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EmployeeManager();
                apiResp.Data = mng.RetrieveEmployee(userId);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(msg);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/Employees/post")]
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EmployeeManager();
                mng.Create(employee);

                string Mensaje = "Estimado " + employee.FirstName + "  " + employee.FirstLastName + " Se ha registrado en nuestra plataforma <br/><br/> " + "Su contraseña de inicio es: " + employee.Password;
                ToolsHelper.SendMail(employee.Email, "Confirmación de cuenta", Mensaje);


                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(msg);
                return InternalServerError(new Exception(ex.Message));
            }
        }
        //CREATE USERS
        [Route("api/Employeess/put")]
        public IHttpActionResult Put(Employee employee)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EmployeeManager();
                mng.Update(employee);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(msg);
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

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(msg);
                return InternalServerError(new Exception(ex.Message));
            }

        }
    }
}