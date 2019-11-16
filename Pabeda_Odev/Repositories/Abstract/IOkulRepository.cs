using Pabeda_Odev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Repositories.Abstract
{
    public interface IOkulRepository:IRepository<Okul>
    {
        IEnumerable<Ogrenci> GetOkulOgrencileri(int id);
        bool Update2(Okul entity);
    }
}
