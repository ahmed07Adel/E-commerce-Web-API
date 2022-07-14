using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using API.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class ProductRepository : IProducts
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManage;

        public ProductRepository(AppDbContext context, UserManager<AppUser> userManage)
        {
            this.context = context;
            this.userManage = userManage;
        }
        public async Task<ProductsModel> CreateProduct(ProductsModel newproduct)
        {         
            context.Entry(newproduct.Category).State = EntityState.Unchanged;
            var res = await context.Products.AddAsync(newproduct);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<ProductsModel> GetProductById(int Productid)
        {         
            var res = await context.Products.FirstOrDefaultAsync(x => x.Id == Productid);
            return res;
        }
        public async Task<IEnumerable> GetProducts()
        {          
            var res = await context.Products.Include(a => a.Category).ToListAsync();
            return res;
        }
        public async Task<ProductsModel> UpdateProduct(ProductDto product)
        {
            var res = await context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            context.Entry(product.Category).State = EntityState.Unchanged;
            if (res != null)
            {             
                res.Price = product.Price;
                res.ProductName = product.ProductName;
                res.Description = product.Description;
                res.Category = product.Category;
                res.ProductPic = product.ProductPic;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
        public async Task<ProductsModel> DeleteProduct(int ProductId)
        {
            var res = await context.Products.FirstOrDefaultAsync(e => e.Id == ProductId);
            if (res != null)
            {
                context.Products.Remove(res);
                await context.SaveChangesAsync();
                return res;
            }   
            return null;
        }

        public async Task<IEnumerable<ProductsModel>> Search(string ProductName)
        {
            IQueryable<ProductsModel> query = context.Products;
            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(e => e.ProductName.Contains(ProductName));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable> GetElectronicsProducts()
        {
            var res = await context.Products.Where(a => a.Category.Id == 2).ToListAsync();
            return res;
        }

        public async Task<IEnumerable> GetClothesProducts()
        {
            var res = await context.Products.Where(a => a.Category.Id == 1).ToListAsync();
            return res;
        }
       

        public async Task<ProductRating> StarRatting(ProductRating model)
        {
            var res = await context.productRatings.AddAsync(model);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<ProductinCart> AddToCart(ProductinCart model)
        {
            var res = await context.Productincarts.AddAsync(model);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<IEnumerable> ListProductsinCart()
        {
            var res = await context.Productincarts.ToListAsync();
            return res;
        }
    }
}
