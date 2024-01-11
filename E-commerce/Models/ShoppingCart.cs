using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TotalCost { get; set; }
        
        public int UserId { get; set; }


    }
}
