using E_commerce.Models;

namespace E_commerce.Dtos
{
    public class ProductDto : ProductDetalis
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }

        public float Rate { get; set; }
        public int CategoryId { get; set; }

    }
}
