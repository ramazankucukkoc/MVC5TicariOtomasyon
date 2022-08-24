using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        public ActionResult Index()
        {
            var liste = context.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            context.Faturalars.Add(faturalar);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = context.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar faturalar)
        {
            var fatura = context.Faturalars.Find(faturalar.Faturaid);
            fatura.FaturaSeriNo = faturalar.FaturaSeriNo;
            fatura.FaturaSıraNo = faturalar.FaturaSıraNo;
            fatura.Saat = faturalar.Saat;
            fatura.Tarih = faturalar.Tarih;
            fatura.TeslimAlan = faturalar.TeslimAlan;
            fatura.TeslimEden = faturalar.TeslimEden;
            fatura.VergiDairesi = faturalar.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = context.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger1 = context.Faturalars.ToList();
            cs.deger2 = context.FaturaKalems.ToList();
            return View(cs);

        }
        public ActionResult FaturaKaydet
            (string FaturaSerino, string FaturaSırano,
            DateTime tarih,string VergiDairesi,string Saat,string TeslimEden,string TeslimAlan, string Toplam,FaturaKalem[] kalemler)
        {
            Faturalar faturalar = new Faturalar();
            faturalar.FaturaSeriNo = FaturaSerino;
            faturalar.FaturaSıraNo = FaturaSırano;
            faturalar.Tarih = tarih;
            faturalar.VergiDairesi = VergiDairesi;
            faturalar.Saat = Saat;
            faturalar.TeslimEden = TeslimEden;
            faturalar.TeslimAlan = TeslimAlan;
            faturalar.Toplam = decimal.Parse(Toplam);
            context.Faturalars.Add(faturalar);
            foreach (var item in kalemler)
            {
                FaturaKalem faturaKalem = new FaturaKalem();
                faturaKalem.Aciklama = item.Aciklama;
                faturaKalem.BirimFiyat = item.BirimFiyat;
                faturaKalem.Faturaid = item.Faturaid;
                faturaKalem.Miktar = item.Miktar;
                faturaKalem.Tutar = item.Tutar;
                context.FaturaKalems.Add(faturaKalem);
            }
            context.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}