using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var data = await _context.Categories.ToListAsync();

            return data;
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
