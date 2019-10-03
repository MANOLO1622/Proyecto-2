using CoreCode.API.Core;
using CoreCode.API.Core.Helpers;
using CoreCode.API.Core.Managers;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.ActionFilter;
using CoreCodeAPI.Helpers;
using CoreCodeAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AirlineManagerController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        AirlineManagerManagement mng = new AirlineManagerManagement();
        UserManager usermng = new UserManager();


        [Route("api/getAirlineManagers")]
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
        [Route("api/getAdminById")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var airlineManager = new AirlineManager
                {
                    ID = id
                };

                airlineManager = mng.RetrieveById(airlineManager);
                apiResp.Data = airlineManager;
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


        [Route("api/postAirlineManager")]
        public IHttpActionResult Post(AirlineManager manager)
        {
            try
            {
                var User = new User
                {
                    ID = manager.ID,
                    FirstName = manager.FirstName,
                    SecondName = manager.SecondName,
                    FirstLastName = manager.LastName,
                    SecondLastName = manager.SecondLastName,
                    BirthDate = manager.BirthDate.Year + "-" + ((manager.BirthDate.Month + 1) < 10 ? "0" + (manager.BirthDate.Month + 1).ToString() : (manager.BirthDate.Month + 1).ToString()) + "-" + ((manager.BirthDate.Day) < 10 ? "0" + (manager.BirthDate.Day).ToString() : (manager.BirthDate.Day).ToString()),
                    Genre = manager.Genre,
                    Email = manager.Email,
                    Password = manager.Password,
                    Phone = manager.Phone,
                    CivilStatus = manager.CivilStatus,
                    Status = manager.Status,
                    Rol = 3,
                    Age = string.Empty,
                    Address = string.Empty,
                    Nationality = string.Empty,
                    Province = string.Empty,
                    Canton = string.Empty,
                    District = string.Empty,
                    Experience = string.Empty,
                    GraduationYear = string.Empty,
                    License = string.Empty,
                    Put = string.Empty

                };
                apiResp = new ApiResponse();
                string Mensaje = "Estimado " + User.FirstName + "  " + User.FirstLastName + " Se ha registrado en nuestra plataforma como administrador de Aeropuerto <br/><br/> " + "Su contraseña de inicio es: " + User.Password;
                ToolsHelper.SendMail(User.Email, "Confirmación de cuenta", Mensaje);
                User.Password = EncryptionHelper.Encrypt(User.Password);
                usermng.Create(User);
                mng.Create(manager);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed"
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
        [Route("api/updateAirlineManager")]
        public IHttpActionResult Update(AirlineManager airlineManager)
        {
            try
            {
                var mng = new AirlineManagerManagement();
                mng.Update(airlineManager);

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

        [Route("api/updateAndSendEmailAirlineManagerAccepted")]
        public IHttpActionResult UpdateAndSendEmailAccepted(AirlineManager manager)
        {
            try
            {
                var CorreoElectronico = manager.Email;
                var pass = manager.Password;
                mng.Update(manager);
                string Mensaje = "Estimado " + manager.FirstName + "  " + manager.LastName + " su aerolínea ha sido aceptada por nuestra administración <br/><br/> " + "Su contraseña de inicio es: " + pass;
                ToolsHelper.SendMail(CorreoElectronico, "Confirmación de cuenta", Mensaje);

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

        [Route("api/updateAndSendEmailAirlineManagerRejected")]
        public IHttpActionResult UpdateAndSendEmailRejected(AirlineManager manager)
        {
            try
            {
                var CorreoElectronico = manager.Email;
                var pass = manager.Password;
                mng.Update(manager);
                string Mensaje = "Estimado " + manager.FirstName + "  " + manager.LastName + " lamentamos informarle que su aerolínea ha sido rechazada por nuestra administración";
                ToolsHelper.SendMail(CorreoElectronico, "Denegación de cuenta", Mensaje);
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


        [Route("api/deleteAirlineManager")]
        public IHttpActionResult ReomveAirlineManager(AirlineManager manager)
        {
            try
            {
                mng.Delete(manager);
                apiResp = new ApiResponse
                {
                    Message = "Action was exectued."
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


        [Route("api/getAdminAirlineByAirlineId")]
        public IHttpActionResult GetAdminAirlinetByAirlinetId(string ID)
        {
            try
            {
                var airlineManager = new AirlineManager
                {
                    AirlineID = ID
                };

                airlineManager = mng.RetrieveAdminAirlineByAirAirlineId(airlineManager);
                apiResp.Data = airlineManager;
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



