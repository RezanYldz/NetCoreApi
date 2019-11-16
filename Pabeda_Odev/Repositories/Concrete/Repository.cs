using Microsoft.EntityFrameworkCore;
using Pabeda_Odev.Model;
using Pabeda_Odev.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pabeda_Odev.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DB_Context _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DB_Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public bool Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return Save();
        }
        public bool Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Save();
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Remove(int id)
        {
            _dbSet.Remove(GetById(id));
            return Save();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
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
