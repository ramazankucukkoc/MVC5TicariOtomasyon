using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler cariler)
        {
            cariler.Durum = true;
            context.Carilers.Add(cariler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = context.Carilers.Find(id);
            cr.Durum = false;
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var degerler = context.Carilers.Find(id);
            return View("CariGetir", degerler);
        }
        public ActionResult CariGuncelle(Cariler cariler)
        {
            var cari = context.Carilers.Find(cariler.Cariid);
            cari.CariAd = cariler.CariAd;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSehir = cariler.CariSehir;
            cari.CariMail = cariler.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatıs(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = context.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}