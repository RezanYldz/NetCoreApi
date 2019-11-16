using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Repositories.Concrete
{
    public class OkulRepository:Repository<Okul>,IOkulRepository
    {
        public DB_Context DB_Context { get { return _context as DB_Context; } }
        public OkulRepository(DB_Context context) :base(context)
        {
        }
        public IEnumerable<Ogrenci> GetOkulOgrencileri(int id)
        {
            return (DB_Context.Ogrenci.Where(e => e.OkulID == id).ToList());
        }

        public bool Update2(Okul entity)
        {
            var okul = DB_Context.Okul.Find(entity.ID);
            okul.Adresi = entity.Adresi;
            okul.Sehir = entity.Sehir;
            okul.Ilce = entity.Ilce;
            DB_Context.Okul.Update(okul);
            return Save();
        }
        private bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                // TODO: Log Exceptions
                return false;
            }
        }
    }
}
