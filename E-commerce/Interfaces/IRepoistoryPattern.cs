using E_commerce.Models;
using System;
using System.Linq.Expressions;

namespace E_commerce.Interfaces
{

    public interface IRepoistoryPattern<T> where T : class
    {
        T GetById(int id, string[] includes = null);
        T GetByName(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetAll(string[] includes = null);
        T Add(T entity);
        bool DoesExist(Expression<Func<T, bool>> expression);
        T Update(T entity);
        T GetItemAsNoTracking(Expression<Func<T, bool>> expression);
    }
}
