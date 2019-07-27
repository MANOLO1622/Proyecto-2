using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using CoreCode.Web.UI.ActionFilter;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FlightController : Controller
    {

        [Route("vFlight")]
        public ActionResult vFlight()
        {
            return View();
        }

        [Route("CreateFlight")]
        public ActionResult CreateFlight()
        {
            return View();
        }

        [Route("ListFLight")]
        public ActionResult ListFlight()
        {
            return View();
        }

    }
}