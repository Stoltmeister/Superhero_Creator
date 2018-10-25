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
            var allHeros = db.Superheros.Where(h => true);
            return View(allHeros);
        }

        public ActionResult Create()
        {
            Superhero newHero = new Superhero();
            return View(newHero);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Superheros.Where(s => s.ID == id).Single());
        }

        public ActionResult Details(int id)
        {
            return View(db.Superheros.Where(s => s.ID == id).Single());
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var heroToDelete = db.Superheros.Where(s => s.ID == id).Single();
                db.Superheros.Remove(heroToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero editedHero)
        {
            if (ModelState.IsValid)
            {
                var heroToEdit = db.Superheros.Where(s => s.ID == editedHero.ID).Single();
                heroToEdit.Name = editedHero.Name;
                heroToEdit.AlterEgoName = editedHero.AlterEgoName;
                heroToEdit.PrimaryAbility = editedHero.PrimaryAbility;
                heroToEdit.SecondaryAbility = editedHero.SecondaryAbility;
                heroToEdit.CatchPhrase = editedHero.CatchPhrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
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