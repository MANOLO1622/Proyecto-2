﻿using CoreCode.Web.UI.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : Controller
    {
        // GET: User
        [Route("vUser")]
        public ActionResult vUser()
        {
            return View();
        }

        // GET: User
        [Route("vListTicket")]
        public ActionResult vListTicket()
        {
            return View();
        }

        [Route("vCreateUser")]
        public ActionResult vCreateUser(){
          return View();
        }

        [Route("vListFlightsUser")]
        public ActionResult vListFlightsUser()
        {
            return View();
        }




    }
}