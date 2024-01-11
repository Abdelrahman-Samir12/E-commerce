using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(string[] includes = null)
        {
            IQueryable<T> table = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    table = table.Include(include);

            return await table.ToListAsync();
        }
        public async Task<T> GetById(int id, string[] includes = null)
        {
            var data = _context.Set<T>();
            var entity = await data.FindAsync(id);
            IQueryable<T> data1 = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data1= data1.Include(include);
                }
            }

            return data1.Single(e => e == entity);

        }

        public async Task<T> GetByName(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            IQueryable<T> data1 = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data1 = data1.Include(include);
                }
            }
            var entity = await data1.FirstOrDefaultAsync(predicate);

            return entity;

        }
    }
}
