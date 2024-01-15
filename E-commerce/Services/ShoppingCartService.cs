using E_commerce.Interfaces;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Services
{
    public class ShoppingCartService : RepoistoryPattern<ShoppingCart>,IShoppingCart
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ShoppingCart AddItemToCart(int userId, Product product)
        {
            var cart = _context.ShoppingCarts.Include(a => a.Products)
                .FirstOrDefault(a => a.UserId == userId);
            cart.Products.Add(product);
            cart.TotalCost += product.Price * product.Amount;
            _context.SaveChanges();
            return cart;
        }

        public void CreateNewShoppingCart(int userId)
        {
            ShoppingCart cart = new ShoppingCart
            {
                UserId = userId,
                TotalCost = 0,
               
            };
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
            var user = _context.Users.Find(userId);
            user.ShoppingCartId = cart.Id;
 
            _context.SaveChanges();
        }
    }
}
