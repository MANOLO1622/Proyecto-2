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
    public class AirplaneController : Controller
    {

        [Route("vAirplane")]
        public ActionResult vAirplane()
        {
            return View();
        }

        [Route("CreateAirplane")]
        public ActionResult CreateAirplane()
        {
            return View();
        }

        [Route("ListAirplane")]
        public ActionResult ListAirplane()
        {
            return View();
        }

    }
}