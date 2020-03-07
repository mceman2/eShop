using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Query(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Remove(T entity);
}
