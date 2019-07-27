using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AirlineManagerController : Controller
    {
     
        [Route("vCreateAirlineAdmin")]
        public ActionResult vCreateAirlineAdmin()
        {

            return View();
        }

        [Route("vEditAirlineAdmin")]
        public ActionResult vEditAirlineAdmin()
        {

            return View();
        }

        [Route("vRequestAdminAirlineToAirport")]
        public ActionResult vRequestAdminAirlineToAirport()
        {
            return View();
        }

    }
}