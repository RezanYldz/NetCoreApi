using Microsoft.EntityFrameworkCore;
using Moq;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;

using System.Collections.Generic;
using Xunit;

namespace Pabeda_UnitTest
{

    public class OkulTest
    {
        protected DB_Context _context;
        static readonly DbContextOptionsBuilder<DB_Context> builder = new DbContextOptionsBuilder<DB_Context>();
            Okul okul = new Okul();
            OgretmenOkul ogretmenOkul = new OgretmenOkul();
        public OkulTest()
        {
            _context = new DB_Context(builder.Options);
        }
        
        [Fact]
        public void OkulOgretmenEkle()
        {
            var moq = new Mock<IRepository<OgretmenOkul>>();
            var moq2 = new Mock<IRepository<Okul>>();
            var moq3 = new Mock<IOkulRepository>();

            ogretmenOkul.OgretmenID = 1;
            ogretmenOkul.OkulID = 3;
            moq.Setup(x => x.Add(ogretmenOkul)).Returns(true);
        }
        [Fact]
        public void OkulEkle()
        {
            var moq2 = new Mock<IRepository<Okul>>();
            okul.ID = 1;
            okul.OkulAdi = "Deneme Okulu";
            okul.Adresi = "Adres bilgisi";
            okul.Sehir = "Ýstanbul";
            okul.Ilce = "Þiþli";
            moq2.Setup(x => x.Add(okul)).Returns(true);
        }
        [Fact]
        public void OkulListesi()
        {
            var moq2 = new Mock<IRepository<Okul>>();
            var okullistesi = new List<Okul>
            {
                new Okul {ID=1,OkulAdi="User1",Adresi="User1LastName",Sehir="Ýstanbul",Ilce="Þiþli" },
                new Okul {ID=2,OkulAdi="User2",Adresi="User1LastName",Sehir="Ýstanbul",Ilce="Þiþli" },
                new Okul {ID=3,OkulAdi="User3",Adresi="User1LastName",Sehir="Ýstanbul",Ilce="Þiþli" }
            };
            moq2.Setup(x => x.GetAll()).Returns(okullistesi);
        }
        [Fact]
        public void OkulOgr()
        {
            var moq2 = new Mock<IOkulRepository>();
            var ogrenciler = new List<Ogrenci>
            {
                new Ogrenci {ID=1,Isim="Ali",Soyisim="Veli",TCKimlikNo=1234,OkulID=1},
                new Ogrenci {ID=2,Isim="Ali2",Soyisim="Veli2",TCKimlikNo=2134,OkulID=1},
                new Ogrenci {ID=3,Isim="Ali3",Soyisim="Veli3",TCKimlikNo=3123,OkulID=2},
            };
            moq2.Setup(x => x.GetOkulOgrencileri(1)).Returns(ogrenciler);
            moq2.Setup(x => x.GetOkulOgrencileri(2)).Returns(ogrenciler);
        }
        [Fact]
        public void OkulSil()
        {
            var moq2 = new Mock<IRepository<Okul>>();
            moq2.Setup(x => x.Remove(1)).Returns(true);
        }
        [Fact]
        public void OkulGuncelle()
        {
            var moq2 = new Mock<IRepository<Okul>>();
            Okul nesne = new Okul();
            nesne.OkulAdi = "Yeni okul adý";
            nesne.Adresi = "Yeni adresi";
            nesne.Sehir = "Yeni þehir";
            nesne.Ilce = "Yeni ilçe";
            moq2.Setup(x => x.Update(nesne)).Returns(true);
        }
    }
}
