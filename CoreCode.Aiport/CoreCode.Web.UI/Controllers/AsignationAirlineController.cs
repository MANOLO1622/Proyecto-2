using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AsignationAirlineController : Controller
    {

        [Route("vAsignationAirline")]
        public ActionResult vAsignationAirline()
        {
            return View("~/Views/Asignation/vAsignationAirline.cshtml");
        }

        

       
    }
}