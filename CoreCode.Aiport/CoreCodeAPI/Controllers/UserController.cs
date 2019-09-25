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
using CoreCode.API.Core.Helpers;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        UserManagement mng = new UserManagement();

        [Route("api/getUsersByRol")]
        public IHttpActionResult Get(int id_rol)
        {



            try
            {
                var mng = new UserManagement();
                var user = new User
                {
                    Rol = id_rol
                };

                user = mng.RetrieveByRol(user);
                apiResp = new ApiResponse();
                apiResp.Data = user;
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
        [Route("api/Users/post")]
        public IHttpActionResult Post(User user)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserManager();
                string Mensaje = "Estimado " + user.FirstName + "  " + user.FirstLastName + " Se ha registrado en nuestra plataforma <br/><br/> " + "Su contraseña de inicio es: " + user.Password;
                ToolsHelper.SendMail(user.Email, "Confirmación de cuenta", Mensaje);
                user.Password = EncryptionHelper.Encrypt(user.Password);
                mng.Create(user);

                


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
        
        [Route("api/updateUsers")]
        public IHttpActionResult Update(User user)
        {
            try
            {
                var mng = new UserManagement();
                mng.Update(user);

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
        [Route("api/getUserById")]
        public IHttpActionResult GetUserById(string id)
        {
            try
            {
                var user = new User
                {
                    ID = id
                };

                user = mng.RetrieveByUserId(user);
                apiResp.Data = user;
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

        [Route("api/Users/delete")]
        public IHttpActionResult Delete(User user)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserManager();
                mng.Delete(user);
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