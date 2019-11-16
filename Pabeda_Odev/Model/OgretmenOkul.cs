using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Model
{
    [Table("OgretmenOkul")]
    public class OgretmenOkul
    {
        public int ID { get; set; }
        public int OgretmenID { get; set; }
        public int OkulID { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
        public virtual Okul Okul { get; set; }
    }
}
