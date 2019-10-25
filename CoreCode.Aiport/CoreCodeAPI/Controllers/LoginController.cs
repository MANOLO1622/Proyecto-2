using CoreCode.API.Core;
using CoreCodeAPI.ActionFilter;
using CoreCode.Entities.POJO;
using CoreCodeAPI.Models;
using CoreCodeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using CoreCode.Exceptions;
using System.Web.Http.Cors;
using CoreCode.API.Core.Helpers;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        LoginManager mng = new LoginManager();
        ApiResponse apiResp = new ApiResponse();


        [Route("api/getUsers")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp.Data = mng.RetrieveAll();

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

        [Route("api/getUser")]
        public IHttpActionResult GetUser(string userName, string password)
        {
            try
            {
                apiResp.Data = mng.RetrieveByUserNameAndPassword(userName, password);

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

        [Route("api/checkIfUserExists")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult CheckIfUserExists(string userName)
        {
            try
            {
                var user = mng.CheckIfUserExists(userName);
                if (user != null)
                {
                    var CorreoElectronico = user.Email;
                    var pass = EncryptionHelper.GetEncryptedMd5Value(user.Password);

                    string Mensaje = "Estimad@ " + user.FirstName + "  " + user.FirstLastName + " Su contraseña actual es: <br/><br/> " + pass + "";
                    ToolsHelper.SendMail(CorreoElectronico, "Recuperación de contraseña", Mensaje);
                    apiResp.Data = "Action was executed.";

                } else {
                    apiResp.Data = null;
                }
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

        [Route("api/checkIfUserExistsByUserNameOrId")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult CheckIfUserExistsById(string userName, string id)
        {
            try
            {
                apiResp.Data = mng.CheckIfUserExistsByUserOrId(userName, id);
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

        [Route("api/updateUser")]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                mng.Update(user);
                apiResp.Message = "Executed";
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
        //MENSAJE DE REINICIO DE CONTRASEÑA
        [Route("api/recoverPassAirline")]
        public IHttpActionResult UpdatePassAirlineAdmin(User user)
        {
            try
            {
                var mng = new LoginManager();

                mng.RecoverPasswordAdminAirline(user);
                var CorreoElectronico = user.Email;
                var pass = user.Password;
                string Mensaje = "Hola" + user.FirstName + "  " + user.FirstLastName + " Su contraseña reenviada es: <br/><br/> " + pass + " Bienvenido!";
                ToolsHelper.SendMail(CorreoElectronico, "Nueva contraseña de ingreso", Mensaje);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

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

        [Route("api/recoverPassAirport")]
        public IHttpActionResult UpdatePassAirportAdmin(User user)
        {
            try
            {
                var mng = new LoginManager();

                mng.RecoverPasswordAdminAirline(user);
                var CorreoElectronico = user.Email;
                var pass = user.Password;
                string Mensaje = "Hola" + user.FirstName + " Se ha reiniciado su contraseña <br/><br/> " + pass + " es su nueva contraseña para ingresar";
                ToolsHelper.SendMail(CorreoElectronico, "Nueva contraseña de ingreso", Mensaje);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

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


        [Route("api/role")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetRoleForEmail(string email)
        {
            apiResp.Data = 1;
            return Ok(apiResp);
        }

    }
}