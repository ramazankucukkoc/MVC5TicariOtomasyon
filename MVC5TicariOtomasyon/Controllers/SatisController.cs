using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                                           select new SelectListItem { Text = x.UrunAd, Value = x.Urunid.ToString() }).ToList();

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.Cariid.ToString() }).ToList();

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.Personelid.ToString() }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                                           select new SelectListItem { Text = x.UrunAd, Value = x.Urunid.ToString() }).ToList();

            List<SelectListItem> deger2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.Cariid.ToString() }).ToList();

            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                                           select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.Personelid.ToString() }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = context.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var deger = context.SatisHarekets.Find(satisHareket.Satisid);
            deger.Cariid = satisHareket.Cariid;
            deger.Adet = satisHareket.Adet;
            deger.Fiyat = satisHareket.Fiyat;
            deger.Personelid = satisHareket.Personelid;
            deger.Tarih = satisHareket.Tarih;
            deger.ToplamTutar = satisHareket.ToplamTutar;
            deger.Urunid = satisHareket.Urunid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(degerler);
        }
    }
}