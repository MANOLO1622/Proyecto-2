using CoreCode.API.Core;
using CoreCode.API.Core.Helpers;
using CoreCode.API.Core.Managers;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.Helpers;
using CoreCodeAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace CoreCodeAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AirportManagerController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        AirportManagerManagement mng = new AirportManagerManagement();
        UserManager usermng = new UserManager();

        [Route("api/getAirportManagers")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirportManagerManagement();
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
                var airportManager = new AirportManager
                {
                    ID = id
                };

                airportManager = mng.RetrieveById(airportManager);
                apiResp.Data = airportManager;
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

        [Route("api/postAirportManager")]
        public IHttpActionResult Post(AirportManager manager)
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
                    Rol = 2,
                    Age = string.Empty,
                    Address =string.Empty,
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
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
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
        [Route("api/updateAirportManager")]
        public IHttpActionResult Update(AirportManager airportManager)
        {
            try
            {
                var mng = new AirportManagerManagement();
                mng.Update(airportManager);

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

        [Route("api/deleteAirportManager")]
        public IHttpActionResult RemoveAirportManager(AirportManager manager)
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

        [Route("api/getAdminAirportByAirportId")]
        public IHttpActionResult GetAdminAirportByAirportId(string ID)
        {
            try
            {
                var airportManager = new AirportManager
                {
                    AirportID = ID
                };

                airportManager = mng.RetrieveAdminAirportByAirportId(airportManager);
                apiResp.Data = airportManager;
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



