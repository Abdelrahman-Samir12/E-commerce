using E_commerce.Helpers;

namespace E_commerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role Role { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
