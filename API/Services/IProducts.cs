using API.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
   public interface IProducts
    {
        Task<ProductsModel> CreateProduct(ProductsModel newproduct);
        Task<IEnumerable> GetProducts();
        Task<ProductsModel> GetProductById(int Productid);
        Task<ProductsModel> UpdateProduct(ProductsModel product);
        Task<ProductsModel> DeleteProduct(int ProductId); 
    }
}
