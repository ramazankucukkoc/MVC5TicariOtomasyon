using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var kargolar = from x in context.KargoDetays select x;
            //if de koşul textbox deger boş değilse
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            int sayi1, sayi2, sayi3;
            sayi1 = random.Next(100, 1000);
            sayi2 = random.Next(10, 99);
            sayi3 = random.Next(10, 99);
            string kod = sayi1.ToString() + karakterler[k1] + sayi2 + karakterler[k2] + sayi3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {

            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}