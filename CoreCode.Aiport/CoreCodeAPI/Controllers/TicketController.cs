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
    public class TicketController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/getTickets")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new TicketManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getTickets", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getTickets", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getId")]
        public IHttpActionResult GetIds()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new IdManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getId", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getId", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getTicketById")]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var mng = new TicketManagement();
                var ticket = new Ticket
                {
                    Id = Id
                };

                ticket = mng.RetrieveById(ticket);
                apiResp = new ApiResponse();
                apiResp.Data = ticket;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getTicketById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getTicketById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
        // POST 

        [Route("api/createTicket")]
        public IHttpActionResult Post(Ticket ticket)
        {

            try
            {
                var mng = new TicketManagement();
                mng.Create(ticket);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "createTicket", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "createTicket", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // UPDATE
        [Route("api/updateTicket")]
        public IHttpActionResult Update(Ticket ticket)
        {
            try
            {
                var mng = new TicketManagement();
                mng.Update(ticket);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateTicket", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateTicket", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // DELETE ==
        [Route("api/deleteTicket")]
        public IHttpActionResult Delete(Ticket ticket)
        {
            try
            {
                var mng = new TicketManagement();
                mng.Delete(ticket);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "deleteTicket", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "deleteTicket", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getTicketOnTime")]
        public IHttpActionResult GetOnTime()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new TicketManagement();
                apiResp.Data = mng.TicketsOnTime();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getTicketOnTime", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getTicketOnTime", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        [Route("api/getTicketCanceled")]
        public IHttpActionResult GetCanceled()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new TicketManagement();
                apiResp.Data = mng.TicketsCanceled();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getTicketCanceled", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getTicketCanceled", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        [Route("api/getTicketDelay")]
        public IHttpActionResult GetDelay()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new TicketManagement();
                apiResp.Data = mng.TicketsDelay();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getTicketDelay", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getTicketDelay", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
    }
}
