using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaCFF.UI.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}