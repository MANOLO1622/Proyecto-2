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
using System.Web.Routing;
namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MoneyController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        LogExceptionManagement logException = new LogExceptionManagement();

        [Route("api/getMoneyById")]
        public IHttpActionResult GetMoneyById(string id)
        {
            try
            {
                var mng = new MoneyManagement();
                var money = new Money
                {
                    IDMoney = id
                };

                money = mng.RetrieveById(money);
                apiResp = new ApiResponse();
                apiResp.Data = money;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getMoneyById", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getMoneyById", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getMoneys")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MoneyManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getMoneys", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getMoneys", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getAvailableMoneys")]
        public IHttpActionResult GetAvailableMoneys()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MoneyManagement();
                apiResp.Data = mng.RetrieveAvailable();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getAvailableMoneys", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getAvailableMoneys", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        [Route("api/getUnavailableMoneys")]
        public IHttpActionResult GetUnavailableMoneys()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new MoneyManagement();
                apiResp.Data = mng.RetrieveUnavailable();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "getUnavailableMoneys", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "getUnavailableMoneys", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }



        // POST 
        // CREATE
        [Route("api/postMoney")]
        public IHttpActionResult Post(Money money)
        {

            try
            {
                var mng = new MoneyManagement();
                mng.Create(money);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "postMoney", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "postMoney", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // PUT
        // UPDATE
        [Route("api/updateMoney")]
        public IHttpActionResult UpdateMoney(Money money)
        {
            try
            {
                var mng = new MoneyManagement();
                mng.Update(money);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "updateMoney", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "updateMoney", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }
        }

        // DELETE ==
        [Route("api/deleteMoney")]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var money = new Money
                {
                    IDMoney = id
                };
                var mng = new MoneyManagement();
                mng.Delete(money);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                logException.RecordException(0, bex.Message, DateTime.Now, "deleteMoney", bex.StackTrace, bex.Source);
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                logException.RecordException(0, ex.Message, DateTime.Now, "deleteMoney", ex.StackTrace, ex.Source);
                return InternalServerError(new Exception(ex.Message));
            }

        }
    }
}
