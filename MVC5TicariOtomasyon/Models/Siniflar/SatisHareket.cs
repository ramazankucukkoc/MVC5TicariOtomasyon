using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Cariid { get; set; }
        public virtual Cariler Carilers { get; set; }
        public int Personelid { get; set; }
        public virtual Personel Personels { get; set; }

    }
}