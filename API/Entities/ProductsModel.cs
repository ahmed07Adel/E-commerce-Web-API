using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace API.Entities
{
    public class ProductsModel
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ProductPic { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductRating> rattings { get; set; }
        public ICollection<ProductinCart> ProductinCarts { get; set; }

    }
}
