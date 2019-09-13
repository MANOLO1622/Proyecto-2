using CoreCode.API.Core;
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
    public class AsignationController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/getAsignations")]
        public IHttpActionResult Get()
        {
            try
            {

                apiResp = new ApiResponse();
                var mng = new AsignationManagement();
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

        [Route("api/getAsignationById")]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var mng = new AsignationManagement();
                var asignation = new Asignation
                {
                    Id = Id
                };

                asignation = mng.RetrieveById(asignation);
                apiResp = new ApiResponse();
                apiResp.Data = asignation;
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

        // POST 

        [Route("api/createAsignation")]
        public IHttpActionResult PostAsignation(Asignation asignation)
        {

            try
            {
                var mng = new AsignationManagement();
                mng.Create(asignation);

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
