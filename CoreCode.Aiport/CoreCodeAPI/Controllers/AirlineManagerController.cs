using CoreCode.API.Core;
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
                var CorreoElectronico = manager.Email;
                var pass = manager.Password;
                mng.Create(manager);
                string Mensaje = "Estimado " + manager.FirstName + "  " + manager.LastName + " <br/><br/> " + "Su contraseña de inicio es: " + pass;
                ToolsHelper.SendMail(CorreoElectronico, "Confirmación de cuenta", Mensaje);
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
        public IHttpActionResult Update(AirlineManager manager)
        {
            try
            {


                mng.Update(manager);

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



