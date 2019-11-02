using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.ActionFilter;
using CoreCodeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoreCodeAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RequestAirlineAirportController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/postRequestAirlineAirport")]
        public IHttpActionResult Post(RequestAirlineAirport rqaa)
        {

            try
            {
                var mng = new RequestAirlineAirportManagement();
                mng.Create(rqaa);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "postRequestAirlineAirport", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "postRequestAirlineAirport", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }



        [Route("api/updateRequestAirlineAirport")]
        public IHttpActionResult Update(RequestAirlineAirport rqaa)
        {
            try
            {
                var mng = new RequestAirlineAirportManagement();
                mng.Update(rqaa);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateRequestAirlineAirport", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateRequestAirlineAirport", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

    }
}
