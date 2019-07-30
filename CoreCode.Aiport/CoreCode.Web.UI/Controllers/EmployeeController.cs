using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Route("vCreateEmployee")]
        public ActionResult vCreateEmployee()
        {
            return View();
        }

        [Route("vListEmployee")]
        public ActionResult vListEmployee()
        {
            return View();
        }

        [Route("vEmployee")]
        public ActionResult vEmployee()
        {
            return View();
        }
    }
}