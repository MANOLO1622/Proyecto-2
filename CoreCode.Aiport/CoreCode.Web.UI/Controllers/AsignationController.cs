using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AsignationController : Controller
    {

        [Route("vFlightsView")]
        public ActionResult vFlightsView()
        {
            return View();
        }
        [Route("vAsignationView")]
        public ActionResult vAsignationView()
        {
            return View();
        }




    }
}