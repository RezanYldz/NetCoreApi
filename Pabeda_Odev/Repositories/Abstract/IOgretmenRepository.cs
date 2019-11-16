using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pabeda_Odev.AutoMapper;
using Pabeda_Odev.Model;

namespace Pabeda_Odev.Repositories.Abstract
{
    public interface IOgretmenRepository:IRepository<Ogretmen>
    {
        IEnumerable<Ogrenci> GetOgrenciler(int id);
        IEnumerable<Ogretmen> GetOgretmenOkullari(int id);
        //IEnumerable<Ogrt_Ogr> GetOgretmenOgrencileri(int id);
        IEnumerable<Ogrt_Okul> GetOgrtOkul(int id);
    }
}
