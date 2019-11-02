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

    public class AsignationAirlineController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/getAsignationAirlines")]
        public IHttpActionResult Get()
        {
            try
            {

                apiResp = new ApiResponse();
                var mng = new AsignationAirlineManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAsignationAirlines", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAsignationAirlines", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getAsignationById")]
        public IHttpActionResult Get(int Id)
        {
            try
            {
                var mng = new AsignationAirlineManagement();
                var asignationAirline = new AsignationAirline
                {
                    Id = Id
                };

                asignationAirline = mng.RetrieveById(asignationAirline);
                apiResp = new ApiResponse();
                apiResp.Data = asignationAirline;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAsignationById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAsignationById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        // POST 

        [Route("api/createAsignationAirline")]
        public IHttpActionResult PostAsignation(AsignationAirline asignationAirline)
        {

            try
            {
                var mng = new AsignationAirlineManagement();
                mng.Create(asignationAirline);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "createAsignationAirline", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "createAsignationAirline", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

     


        ///[Route("api/getAirlinesByAirportId")]
        ///public IHttpActionResult GetAirlinesByAirportId(string airportId)
        ///{
        /// var airlineManagement = new AirlineManagement();
        /// apiResp = new ApiResponse
        /// {
        //Data = airlineManagement.GetAirlinesByAirportId(airportId),
        // Message = "Action was executed."
        // };
        //return Ok(apiResp);

        // }
    }
}
