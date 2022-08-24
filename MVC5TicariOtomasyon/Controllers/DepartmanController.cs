using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Departmen.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            context.Departmen.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = context.Departmen.Find(id);
            dep.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = context.Departmen.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept = context.Departmen.Find(d.Departmanid);
            dept.DepartmanAd = d.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = context.Departmen.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dgr2 = dpt; 
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.Personelid == id).ToList();
            //ViewBag.dgr2 = dpt;

            var per = context.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dgr3 = per;
            return View(degerler);
        }
    }
}