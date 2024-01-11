using E_commerce.Models;

namespace E_commerce.Interfaces
{
    public interface IProduct
    {

        Task<Product> GetById(int id);
        Task<Product> GetByName(string name);
        Task<IEnumerable<Product>> GetAll();

        Task<Product> Add(Product product);
    }
}
