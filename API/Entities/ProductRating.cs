using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ProductRating
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductsModel ProductsModel { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int Rate { get; set; }
    }
}
