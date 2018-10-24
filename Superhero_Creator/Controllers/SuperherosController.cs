using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero_Creator.Controllers
{
    public class SuperherosController : Controller
    {
        // GET: Superheros
        public ActionResult Index()
        {
            return View();
        }
    }
}