using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using KinoAfisha.Models;



namespace KinoAfisha.Controllers
{
    public class FilmsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new KinoAfishaContext();
            var films = db.Films.ToList();

            return View(films);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var film = new Film();
            return View(film);
        }

        [HttpPost]
        public ActionResult Create(Film model)
        {
            if (!ModelState.IsValid)
                return View(model);
   
            var db = new KinoAfishaContext();


            if (model.FilmCoverFile != null)
            {
                var data = new byte[model.FilmCoverFile.ContentLength];
                model.FilmCoverFile.InputStream.Read(data, 0, model.FilmCoverFile.ContentLength);

                model.FilmCover = new FilmCover()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = model.FilmCoverFile.ContentType,
                    FileName = model.FilmCoverFile.FileName
                };
            }
           
            
            db.Films.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new KinoAfishaContext();
            var film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
                return RedirectPermanent("/Films/Index");

            db.Films.Remove(film);
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new KinoAfishaContext();
            var film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
                return RedirectPermanent("/Films/Index");

            return View(film);
        }

        [HttpPost]
        public ActionResult Edit(Film model)
        {
            var db = new KinoAfishaContext();
            var film = db.Films.FirstOrDefault(x => x.Id == model.Id);
            if (film == null)
                ModelState.AddModelError("Id", "Фильм не найден");

            if (!ModelState.IsValid)
                return View(model);

            MappingFilm(model, film, db);

            db.Entry(film).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Films/Index");
        }

        private void MappingFilm(Film sourse, Film destination, KinoAfishaContext db)
        {
          
            destination.NameFilm = sourse.NameFilm;
            destination.FilmYears = sourse.FilmYears;

            if (sourse.FilmCoverFile != null)
            {
                var image = db.FilmCovers.FirstOrDefault(x => x.Id == sourse.Id);
                if (image != null)
                    db.FilmCovers.Remove(image);

                var data = new byte[sourse.FilmCoverFile.ContentLength];
                sourse.FilmCoverFile.InputStream.Read(data, 0, sourse.FilmCoverFile.ContentLength);

                destination.FilmCover = new FilmCover()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.FilmCoverFile.ContentType,
                    FileName = sourse.FilmCoverFile.FileName
                };
            }
        }
        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var db = new KinoAfishaContext();
            var image = db.FilmCovers.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(Server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                return File(new MemoryStream(fileData), "image/jpeg");
            }

            return File(new MemoryStream(image.Data), image.ContentType);
        }
    }
}