using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce.Services
{
    public class RepoistoryPattern<T> : IRepoistoryPattern<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepoistoryPattern(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DoesExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(expression) != null;
        }
        
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            IQueryable<T> table = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    table = table.Include(include);

            return table.ToList();
        }
        public T GetById(int id, string[] includes = null)
        {
            var data = _context.Set<T>();
            var entity =  data.Find(id);
            IQueryable<T> data1 = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data1= data1.Include(include);
                }
            }

            return  data1.SingleOrDefault(e => e == entity);

        }

        public T GetByName(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            IQueryable<T> data1 = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data1 = data1.Include(include);
                }
            }
            var entity =  data1.FirstOrDefault(predicate);

            return entity;

        }

        public T GetItemAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
