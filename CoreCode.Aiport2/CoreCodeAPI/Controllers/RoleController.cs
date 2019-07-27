using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCodeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoleController : Controller
    {

        // GET api/values/5
        [Route("api/role/{id}")]
        public string Get(string id)
        {
            return id+"value";
        }
    }
}