using API.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IGenderRepository
    {
        Task<IEnumerable> GenderDropDownList();
    }
}
