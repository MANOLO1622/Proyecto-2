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
    public class CategoryController : Controller
    {

        [Route("vCountries")]
        public ActionResult vCountries()
        {
            return View("~/Views/Country/vCountries.cshtml");
        }
        

    }
}