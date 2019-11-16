using Microsoft.EntityFrameworkCore;
using Moq;
using Pabeda_Odev.AutoMapper;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;
using System.Collections.Generic;
using Xunit;

namespace Pabeda_UnitTest
{
    public class OgretmenTest
    {
        protected DB_Context _context;
        static readonly DbContextOptionsBuilder<DB_Context> builder = new DbContextOptionsBuilder<DB_Context>();
        Okul okul = new Okul();
        OgretmenOkul ogretmenOkul = new OgretmenOkul();
        Ogrenci ogrenci = new Ogrenci();
        public OgretmenTest()
        {
            _context = new DB_Context(builder.Options);
        }
        [Fact]
        public void OgretmenOgrencileri()
        {
            var moq = new Mock<IOgretmenRepository>();
            var ogrenciler = new List<Ogrenci>
            {
                new Ogrenci {ID=1,Isim="Ali",Soyisim="Veli",TCKimlikNo=1234,OkulID=1},
                new Ogrenci {ID=2,Isim="Ali2",Soyisim="Veli2",TCKimlikNo=2134,OkulID=1},
                new Ogrenci {ID=3,Isim="Ali3",Soyisim="Veli3",TCKimlikNo=3123,OkulID=2},
            };
            moq.Setup(x => x.GetOgrenciler(1)).Returns(ogrenciler);
        }
        [Fact]
        public void OgretmenEkle()
        {
            var moq = new Mock<IRepository<Ogretmen>>();
            Ogretmen ogrnesne = new Ogretmen();
            ogrnesne.Isim = "Ayşe";
            ogrnesne.Soyisim = "Kunter";
            ogrnesne.TCKimlikNo = 1234;
            moq.Setup(x => x.Add(ogrnesne)).Returns(true);
        }
        [Fact]
        public void OgrtOkul()
        {
            var moq = new Mock<IOgretmenRepository>();
            var oonesne = new List<Ogrt_Okul>
            {
                new Ogrt_Okul { Ogrt_Isim = "Ayşe", Ogrt_Soyisim = "Kunter", Ogrt_TCKimlikNo=1234, Okul_OkulAdi = "Okul adı", Okul_Adresi = "Adres", Okul_Sehir = "İstanbul", Okul_Ilce ="Şişli"},
                new Ogrt_Okul { Ogrt_Isim = "Ayşe2", Ogrt_Soyisim = "Kunter2", Ogrt_TCKimlikNo=2341, Okul_OkulAdi = "Okul adı2", Okul_Adresi = "Adres2", Okul_Sehir = "İstanbul2", Okul_Ilce ="Şişli2"},
                new Ogrt_Okul { Ogrt_Isim = "Ayşe3", Ogrt_Soyisim = "Kunter3", Ogrt_TCKimlikNo=3412, Okul_OkulAdi = "Okul adı3", Okul_Adresi = "Adres3", Okul_Sehir = "İstanbul3", Okul_Ilce ="Şişli3"},
            };
            moq.Setup(x => x.GetOgrtOkul(1)).Returns(oonesne);
        }
    }
}
