using CoreCode.Web.UI.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PassengerController : Controller
    {
        // GET: Passenger
        [Route("vPassenger")]
        public ActionResult vPassenger()
        {
            return View();
        }

        // GET: Passenger
        [Route("vListTicket")]
        public ActionResult vListTicket()
        {
            return View();
        }

        [Route("vCreatePassenger")]
        public ActionResult vCreatePassenger(){
          return View();
        }

        [Route("vListFlightsPassengers")]
        public ActionResult vListFlightsPassengers()
        {
            return View();
        }




    }
}
