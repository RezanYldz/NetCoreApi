using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    [Table("Ogretmen")]
    public class Ogretmen
    {
        public Ogretmen()
        {
            OgretmenOkul = new HashSet<OgretmenOkul>();
            OgrenciOgretmen = new HashSet<OgrenciOgretmen>();
        }
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int TCKimlikNo { get; set; }
        public virtual ICollection<OgretmenOkul> OgretmenOkul { get; set; }
        public virtual ICollection<OgrenciOgretmen> OgrenciOgretmen { get; set; }
    }
}
