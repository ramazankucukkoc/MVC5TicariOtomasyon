using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = context.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger2 = context.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}