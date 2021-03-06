using kutseAppEvtina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace kutseAppEvtina.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust!" : "Tere päevast!";
            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }

        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return View("thanks", guest);
            }
            else { return View(); }

        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminetthk2@gmail.com";
                WebMail.Password = "2.kuursus tarpv20";
                WebMail.Send(guest.Email, "Vastus Kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Kutse hea";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Õige vali";

            return View();
        }
        GuestContext db = new GuestContext();
        [Authorize]
        
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }
        [Authorize]

        public ActionResult Puhkuse()
        {
            IEnumerable<Holidays> puhkuse = db.Holidays;
            return View(puhkuse);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
            return RedirectToAction("Guests");

        }
        [HttpGet]
        public ActionResult CreateH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateH(Holidays puhkuse)
        {
            db.Holidays.Add(puhkuse);
            db.SaveChanges();
            return RedirectToAction("Puhkuse");
        }
        public ActionResult Meeldetuletus(Guest guest)
        {
            guest = db.Guests.Last();
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.EnableSsl = true;
            WebMail.UserName = "programmeeriminetthk2@gmail.com";
            WebMail.Password = "2.kuursus tarpv20";
            WebMail.Send(guest.Email, "Meeldetuletus",  guest.Name + ", ara unusta.Pidu toimub 22.03.22! Sind ootavad väga!",
                    null,"mangle12369zzaa@gmail.com");
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g==null)
            {
                return HttpNotFound();
            }
            return View(g);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g==null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }
        [HttpGet]
        public ActionResult DeleteH(int id)
        {
            Holidays h = db.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [HttpPost, ActionName("DeleteH")]
        public ActionResult DeleteHConfirmed(int id)
        {
            Holidays h = db.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Holidays.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Puhkuse");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Guest g = db.Guests.Find(id);
            if (g==null)
            {
                return HttpNotFound();
            }
            return View(g);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;
            db.SaveChanges(); 
            return RedirectToAction("Guests");
        }
        [HttpGet]
        public ActionResult EditH(int? id)
        {
            Holidays h = db.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }
        [HttpPost, ActionName("EditH")]
        public ActionResult EditHConfirmed(Holidays puhkuse)
        {
            db.Entry(puhkuse).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Puhkuse");
        }
        [HttpGet]
        public ActionResult Accept()
        {
            IEnumerable<Guest> guests = db.Guests.Where(g => g.WillAttend == true);
            return View(guests);
        }
        public ActionResult Unaccept()
        {
            IEnumerable<Guest> guests = db.Guests.Where(g => g.WillAttend == false);
            return View(guests);
        }
        //DFgasashjas3252236_
    }
}
