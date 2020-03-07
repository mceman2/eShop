using EfModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DbRepositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbSet<T> _dbSet;
        protected readonly APShopContext _context;
        public Repository(APShopContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        #region IRepository<T> Members
        public abstract T GetById(int id);
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        #endregion
    }
}
