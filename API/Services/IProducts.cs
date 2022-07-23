using API.Entities;
using API.ViewModel;
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
        Task<IEnumerable> GetProducts(APIJWT.Specifications.ParameterSpecification parameterSpecification);
        Task<ProductsModel> GetProductById(int Productid);
        Task<ProductsModel> UpdateProduct(ProductDto product);
        Task<ProductsModel> DeleteProduct(int ProductId);
        Task<IEnumerable<ProductsModel>> Search(string ProductName);
        Task<IEnumerable> GetElectronicsProducts();
        Task<IEnumerable> GetClothesProducts();
        Task<ProductRating> StarRatting(ProductRating model);
        Task<ProductinCart> AddToCart(ProductinCart model);
        Task<IEnumerable> ListProductsinCart();

    }
}
