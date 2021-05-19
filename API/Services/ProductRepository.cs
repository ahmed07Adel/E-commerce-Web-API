using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using API.Data;
using API.Entities;

namespace API.Services
{
    public class ProductRepository : IProducts
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ProductsModel> CreateProduct(ProductsModel newproduct)
        {
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

        public async Task<ProductsModel> UpdateProduct(ProductsModel product)
        {
            var res = await context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (res != null)
            {
                res.Price = product.Price;
                res.ProductName = product.ProductName;
                res.Description = product.Description;

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
    }
}
