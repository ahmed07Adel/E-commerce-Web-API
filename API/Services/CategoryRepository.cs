using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CategoryRepository : ICategory
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable> GetCategories()
        {
            var res = await context.Categories.ToListAsync();

            return res;
        }

        public async Task<Category> GetCategorieById(int id)
        {
            var res = await context.Categories.FirstOrDefaultAsync(x=>x.Id == id);
            return res;
        }
    }
}
