using Superhero_Creator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero_Creator.Controllers
{
    public class SuperherosController : Controller
    {
        ApplicationDbContext db;
        public SuperherosController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Superheros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Superhero newHero = new Superhero();
            return View(newHero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AlterEgo,AlterEgoName,PrimaryAbility,SecondaryAbility,CatchPhrase")] Superhero newHero)
        {
            if (ModelState.IsValid)
            {
                db.Superheros.Add(newHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }
    }
}