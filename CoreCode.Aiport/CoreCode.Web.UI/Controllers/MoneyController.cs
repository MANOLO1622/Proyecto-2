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
    public class MoneyController : Controller
    {

        [Route("vMoneys")]
        public ActionResult vMoneys()
        {
            return View();
        }
        [Route("vListMoneys")]
        public ActionResult vListMoneys()
        {
            return View();
        }


    }
}