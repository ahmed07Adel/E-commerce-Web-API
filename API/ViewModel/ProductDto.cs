using API.Entities;
using Microsoft.AspNetCore.Http;

namespace API.ViewModel
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ProductPic { get; set; }
        public IFormFile Picture { get; set; }
        public Category Category { get; set; }
    }
}
