using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(int id, T entity);
        T Get(int id);
        ICollection<T> GetAll();
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void SaveChanges();
    }
}
