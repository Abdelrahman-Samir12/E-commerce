using E_commerce.Models;
using System;
using System.Linq.Expressions;

namespace E_commerce.Interfaces
{

    public interface IRepoistoryPattern<T> where T : class
    {

        Task<T> GetById(int id, string[] includes = null);
        Task<T> GetByName(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<IEnumerable<T>> GetAll(string[] includes = null);
        Task<T> Add(T entity);
    }
}
