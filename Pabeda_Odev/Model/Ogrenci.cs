using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    [Table("Ogrenci")]
    public class Ogrenci
    {
        public Ogrenci()
        {
            OgrenciOgretmen = new HashSet<OgrenciOgretmen>();
        }
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int TCKimlikNo { get; set; }
        public int OkulID { get; set; }
        public virtual Okul Okul { get; set; }
        public virtual ICollection<OgrenciOgretmen> OgrenciOgretmen { get; set; }
    }
}
