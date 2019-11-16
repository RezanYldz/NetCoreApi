using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    [Table("Okul")]
    public class Okul
    {
        public Okul()
        {
            Ogrenci = new HashSet<Ogrenci>();
            OgretmenOkul = new HashSet<OgretmenOkul>();
        }
        public int ID { get; set; }
        public string OkulAdi { get; set; }
        public string Adresi { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
        public virtual ICollection<OgretmenOkul> OgretmenOkul { get; set; }
    }
}
