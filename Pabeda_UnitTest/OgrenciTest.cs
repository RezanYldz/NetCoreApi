using Microsoft.EntityFrameworkCore;
using Moq;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;
using System.Collections.Generic;
using Xunit;

namespace Pabeda_UnitTest
{
    public class OgrenciTest
    {
        protected DB_Context _context;
        static readonly DbContextOptionsBuilder<DB_Context> builder = new DbContextOptionsBuilder<DB_Context>();
        public OgrenciTest()
        {
            _context = new DB_Context(builder.Options);
        }
        [Fact]
        public void OgrenciEkle()
        {
            Ogrenci yeni = new Ogrenci { ID = 1, Isim = "Ali", Soyisim = "Veli", TCKimlikNo = 1234, OkulID = 1 };
            var moq = new Mock<IRepository<Ogrenci>>();
            moq.Setup(x => x.Add(yeni)).Returns(true);
        }
        [Fact]
        public void OgrenciListesi()
        {
            var moq = new Mock<IRepository<Ogrenci>>();
            var ogrenciler = new List<Ogrenci>
            {
                new Ogrenci {ID=1,Isim="Ali",Soyisim="Veli",TCKimlikNo=1234,OkulID=1},
                new Ogrenci {ID=2,Isim="Ali2",Soyisim="Veli2",TCKimlikNo=2134,OkulID=1},
                new Ogrenci {ID=3,Isim="Ali3",Soyisim="Veli3",TCKimlikNo=3123,OkulID=2},
            };
            moq.Setup(x => x.GetAll()).Returns(ogrenciler);
        }
        [Fact]
        public void OgretmenEkle()
        {
            var moq = new Mock<IRepository<OgrenciOgretmen>>();
            OgrenciOgretmen oonesne = new OgrenciOgretmen();
            oonesne.OgrenciID = 1;
            oonesne.OgretmenID = 1;
            moq.Setup(x => x.Add(oonesne)).Returns(true);
        }
    }
}
