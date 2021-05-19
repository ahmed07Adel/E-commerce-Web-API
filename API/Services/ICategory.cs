using API.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
   public interface ICategory
    {
        Task<IEnumerable> GetCategories();
        Task<Category> GetCategorieById(int id);
    }
}
