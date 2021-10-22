using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class AddToCartViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductsModel productsModel { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int Quantity { get; set; }
        public DateTime AddTime { get; set; }
    }
}
