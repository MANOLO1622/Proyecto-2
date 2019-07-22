using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers

{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AirlineController : Controller
    {
       
        [Route("vCreateAirline")]
        public ActionResult vCreateAirline()
        {
            return View();
        }


        [Route("vListAirlinesRequest")]
        public ActionResult vListAirlinesRequest()
        {
            return View();
        }

       
    }
}