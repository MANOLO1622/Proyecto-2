﻿using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using CoreCodeAPI.Models;
using CoreCode.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreCodeAPI.ActionFilter;
using System.Web.Http.Cors;

namespace CoreCodeAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AirplaneController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/getAirplans")]
        public IHttpActionResult GetAirplanes()
        {
            try
            {

                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                apiResp.Data = mng.RetrieveAllAirplane();

                return Ok(apiResp);
            }

            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getWaitingAirplans")]
        public IHttpActionResult GetWaitingAirplans()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                //apiResp.Data = mng.RetrieveWaitingAirplans();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getWaitingAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getWaitingAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }


        }
        [Route("api/getAcceptedAirplans")]
        public IHttpActionResult GetAcceptedAirplans()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                //apiResp.Data = mng.RetrieveAcceptedAirplans();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAcceptedAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAcceptedAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }
        [Route("api/getDeniedAirplans")]
        public IHttpActionResult GetDeniedAirplans()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                //apiResp.Data = mng.RetrieveDeniedAirplans();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getDeniedAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getDeniedAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getAvailableAirplans")]
        public IHttpActionResult GetAvailableAirplans()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                //apiResp.Data = mng.RetrieveAvailableAirplans();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAvailableAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAvailableAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getUnvailableAirplans")]
        public IHttpActionResult GetUnvailableAirplans()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirplaneManagement();
                //apiResp.Data = mng.RetrieveUnvailableAirplans();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getUnvailableAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getUnvailableAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }


        [Route("api/getAssociatedAirplans")]
        public IHttpActionResult getAssociatedAirplans(string id)
        {


            try
            {
                var mng = new AirplaneManagement();
                var airplane = new Airplane
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                //apiResp.Data = mng.RetrieveAssociatedAirplans(airplane);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAssociatedAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAssociatedAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        [Route("api/getRejectedAirplans")]
        public IHttpActionResult getRejectedAirplans(string id)
        {


            try
            {
                var mng = new AirplaneManagement();
                var airplane = new Airplane
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                //apiResp.Data = mng.RetrieveRejectedAirplans(airplane);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getRejectedAirplans", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getRejectedAirplans", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        [Route("api/getAirplansWaiting")]
        public IHttpActionResult getAirplansWaiting(string id)
        {


            try
            {
                var mng = new AirplaneManagement();
                var airplane = new Airplane
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                //apiResp.Data = mng.RetrieveWaitingAirplans(airplane);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAirplansWaiting", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAirplansWaiting", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }


        }







        [Route("api/getAirplaneById")]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var mng = new AirplaneManagement();
                var airplane = new Airplane
                {
                    Id = Id
                };

                //airplane = mng.RetrieveById(airplane);
                apiResp = new ApiResponse();
                apiResp.Data = airplane;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAirplaneById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAirplaneById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
        // POST 

        [Route("api/createAirplane")]
        public IHttpActionResult PostAirplane(Airplane airplane)
        {

            try
            {
                var mng = new AirplaneManagement(); 
                mng.Create(airplane);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "createAirplane", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "createAirplane", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // UPDATE
        [Route("api/updateAirplane")]
        public IHttpActionResult Update(Airplane airplane)
        {
            try
            {
                var mng = new AirplaneManagement();
                mng.Update(airplane);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateAirplane", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateAirplane", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // DELETE ==
        [Route("api/deleteAirplane")]
        public IHttpActionResult Delete(Airplane airplane)
        {
            try
            {
                var mng = new AirplaneManagement();
                mng.Delete(airplane);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "deleteAirplane", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "deleteAirplane", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }
        [Route("api/getAirplansByAirportId")]
        public IHttpActionResult GetAirplansByAirportId(string airportId)
        {
            try
            {
                var airplaneManagement = new AirplaneManagement();
                apiResp = new ApiResponse
                {
                   
                    Message = "Action was executed."
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAirplansByAirportId", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAirplansByAirportId", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }
    }
}
