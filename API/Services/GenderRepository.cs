using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace API.Services
{
    public class GenderRepository : IGenderRepository
    {
        private readonly AppDbContext context;

        public GenderRepository(AppDbContext context)
        {
            this.context=context;
        }
        public async Task<IEnumerable> GenderDropDownList()
        {
            return await context.UserGenders.ToListAsync();
        }
    }
}
