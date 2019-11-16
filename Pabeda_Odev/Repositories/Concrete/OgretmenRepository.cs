using Microsoft.EntityFrameworkCore;
using Pabeda_Odev.AutoMapper;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Repositories.Concrete
{
    public class OgretmenRepository : Repository<Ogretmen>, IOgretmenRepository
    {
        public OgretmenRepository(DB_Context context) : base(context)
        {

        }

        public IEnumerable<Ogretmen> GetOgretmenOkullari(int id)
        {
            List<int> ogretmenler = DB_Context.OgretmenOkul.Where(e => e.OkulID == id).Select(e => e.OgretmenID).ToList();
            return DB_Context.Ogretmen.Where(e => ogretmenler.Contains(e.ID)).ToList();
        }
        public IEnumerable<Ogrenci> GetOgrenciler(int id)
        {
            List<int> ogrenci_id = DB_Context.OgrenciOgretmen.Where(x => x.OgretmenID == id).Select(y => y.OgrenciID).ToList();
            return DB_Context.Ogrenci.Where(x => ogrenci_id.Contains(x.ID)).ToList();
        }
        //public IEnumerable<Ogrt_Ogr> GetOgretmenOgrencileri(int id)
        //{
        //    List<Ogrt_Ogr> ogrt_Ogr = new List<Ogrt_Ogr>();
        //    var ogrogrlist = DB_Context.OgrenciOgretmen.Where(x => x.OgretmenID == id).ToList();
        //    foreach (var item in ogrogrlist)
        //    {
        //        Ogrt_Ogr nesne = new Ogrt_Ogr();
        //        var ogrenci = DB_Context.Ogrenci.Find(item.OgrenciID);
        //        var ogretmen = DB_Context.Ogretmen.Find(item.OgretmenID);
        //        nesne.Ogrt_Isim = ogretmen.Isim;
        //        nesne.Ogrt_Soyisim = ogretmen.Soyisim;
        //        nesne.Ogrt_TCKimlikNo = ogretmen.TCKimlikNo;
        //        nesne.Ogr_Isim = ogrenci.Isim;
        //        nesne.Ogr_Soyisim = ogrenci.Soyisim;
        //        nesne.Ogr_TCKimlikNo = ogrenci.TCKimlikNo;
        //        ogrt_Ogr.Add(nesne);
        //    }
        //    return ogrt_Ogr;
        //}
        public IEnumerable<Ogrt_Okul> GetOgrtOkul(int id)
        {
            List<Ogrt_Okul> liste = new List<Ogrt_Okul>();
            var ogretmen = DB_Context.Ogretmen.Find(id);

            foreach (var item in DB_Context.OgretmenOkul.Where(x => x.OgretmenID == id).ToList())
            {
                Ogrt_Okul nesne = new Ogrt_Okul();
                var okul = DB_Context.Okul.Find(item.OkulID);
                nesne.Ogrt_Isim = ogretmen.Isim;
                nesne.Ogrt_Soyisim = ogretmen.Soyisim;
                nesne.Ogrt_TCKimlikNo = ogretmen.TCKimlikNo;
                nesne.Okul_OkulAdi = okul.OkulAdi;
                nesne.Okul_Adresi = okul.Adresi;
                nesne.Okul_Sehir = okul.Sehir;
                nesne.Okul_Ilce = okul.Ilce;
                liste.Add(nesne);
            }

            if (liste.Count() == 0)
            {
                Ogrt_Okul nesne = new Ogrt_Okul();
                nesne.Ogrt_Isim = ogretmen.Isim;
                nesne.Ogrt_Soyisim = ogretmen.Soyisim;
                nesne.Ogrt_TCKimlikNo = ogretmen.TCKimlikNo;
                liste.Add(nesne);
            }
            return liste;
        }
        public DB_Context DB_Context { get { return _context as DB_Context; } }
    }
}
