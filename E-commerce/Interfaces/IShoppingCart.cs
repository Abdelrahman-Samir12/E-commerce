using E_commerce.Models;

namespace E_commerce.Interfaces
{
    public interface IShoppingCart : IRepoistoryPattern<ShoppingCart>
    {
        void CreateNewShoppingCart(int userId);
        ShoppingCart AddItemToCart(int userId, Product product);
    }
}
