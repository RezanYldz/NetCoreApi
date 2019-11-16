using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    [Table("OgrenciOgretmen")]
    public class OgrenciOgretmen
    {
        public int ID { get; set; }
        public int OgrenciID { get; set; }
        public int OgretmenID { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
    }
}
