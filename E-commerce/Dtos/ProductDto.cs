using E_commerce.Models;

namespace E_commerce.Dtos
{
    public class ProductDto : ProductDetalis
    {
        public string Description { get; set; } = "";
        public decimal Price { get; set; } = decimal.Zero;
        public IFormFile? Image { get; set; }

        public float Rate { get; set; } = float.MinValue;
        public int CategoryId { get; set; } = 0;

    }
}
