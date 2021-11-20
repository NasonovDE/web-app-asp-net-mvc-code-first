using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using KinoAfisha.Models;


namespace KinoAfisha.Controllers
{
    public class KinosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new KinoAfishaContext();
            var kino = db.Kinos.ToList();
            
               
            return View(kino);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var kino = new Kino();

            return View(kino);

        }

        [HttpPost]
        public ActionResult Create(Kino model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new KinoAfishaContext();
            model.CreateAt = DateTime.Now;


          
            db.Kinos.Add(model);
            db.SaveChanges();


            return RedirectPermanent("/Kinos/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new KinoAfishaContext();
            var kino = db.Kinos.FirstOrDefault(x => x.Id == id);
            if (kino == null)
                return RedirectPermanent("/Kinos/Index");

            db.Kinos.Remove(kino);
            db.SaveChanges();

            return RedirectPermanent("/Kinos/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new KinoAfishaContext();
            var kino =  db.Kinos.FirstOrDefault(x => x.Id == id);
            if (kino == null)
                return RedirectPermanent("/Kinos/Index");

            return View(kino);
        }

        [HttpPost]
        public ActionResult Edit(Kino model)
        {

            var db = new KinoAfishaContext();
            var kino = db.Kinos.FirstOrDefault(x => x.Id == model.Id);
            if (kino == null)
            {
                ModelState.AddModelError("Id", "кино не найдено");
            }
            if (!ModelState.IsValid)
                return View(model);

            MappingKino(model, kino, db);

            db.Entry(kino).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectPermanent("/Kinos/Index");
        }

    
        private void MappingKino(Kino sourse, Kino destination, KinoAfishaContext db)
        {
          
             

            destination.NameId = sourse.NameId;
            destination.Film = sourse.Film;
            destination.Price = sourse.Price;
            destination.NumberOfBilets = sourse.NumberOfBilets;
            destination.Cinema = sourse.Cinema;
            destination.NextArrivalDate = sourse.NextArrivalDate;
            
           
        }
    }
}
