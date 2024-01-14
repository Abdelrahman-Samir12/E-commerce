using E_commerce.Models;

namespace E_commerce.Interfaces
{
    public interface ICategory : IRepoistoryPattern<Category>
    {
        public List<Product> GetProductsByCategory(string categoryName);
    }
}
