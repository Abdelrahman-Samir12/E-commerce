using E_commerce.Models;

namespace E_commerce.Interfaces
{
    public interface ICategory
    {
        Task<Category> GetById(int id);
        Task<Category> GetByName(string name);
        Task<IEnumerable<Category>> GetAll();

        Task<Category> Add(Category category);
    }
}
