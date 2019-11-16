using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        bool Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
