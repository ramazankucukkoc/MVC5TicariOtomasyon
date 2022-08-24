using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MVC5TicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        //[Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategoriEkle)
        {
            c.Kategoris.Add(kategoriEkle);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = c.Kategoris.Find(id);

            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktg = c.Kategoris.Find(kategori.KategoriId);
            // ktg.KategoriId = kategori.KategoriId;
            ktg.KategoriAd = kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme(Kategori kategori)
        {
            Class2 cs = new Class2();
            cs.Kategoriler = new SelectList(c.Kategoris, "Kategoriid", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "Urunid", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.KategoriId equals y.KategoriId
                               where x.Kategori.KategoriId == p
                               select new { Text = x.UrunAd, Value = x.Urunid.ToString() }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }

}