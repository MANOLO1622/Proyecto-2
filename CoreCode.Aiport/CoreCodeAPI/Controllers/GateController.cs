using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using CoreCodeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreCode.Exceptions;
using CoreCodeAPI.ActionFilter;
using System.Web.Http.Cors;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GateController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/getGates")]
        public IHttpActionResult Get()
        {

            try
            {
                apiResp = new ApiResponse();
                var mng = new GateManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getGates", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getGates", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
        [Route("api/getGateById")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new GateManagement();
                var gate = new Gate
                {
                    IDGate = id
                };

                gate = mng.RetrieveById(gate);
                apiResp = new ApiResponse();
                apiResp.Data = gate;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getGateById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getGateById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }




        // POST 
        // CREATE
        [Route("api/postGate")]
        public IHttpActionResult Post(Gate gate)
        {

            try
            {
                var mng = new GateManagement();
                mng.Create(gate);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "postGate", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "postGate", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // PUT

        [Route("api/updateGate")]
        public IHttpActionResult Update(Gate gate)
        {
            try
            {
                var mng = new GateManagement();
                mng.Update(gate);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateGate", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateGate", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // DELETE ==
        [Route("api/deleteGate")]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var gate = new Gate
                {
                    IDGate = id
                };
                var mng = new GateManagement();
                mng.Delete(gate);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "deleteGate", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "deleteGate", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }

    }
}
