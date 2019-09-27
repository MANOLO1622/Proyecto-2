using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservationController : Controller
    {

        [Route("vReservations")]
        public ActionResult vReservations()
        {
            return View("~/Views/Country/vReservations.cshtml");
        }
        [Route("CreateReservation")]
        public ActionResult CreateReservation()
        {
            return View();
        }

        [Route("ListReservations")]
        public ActionResult ListReservations()
        {
            return View();
        }


    }
}