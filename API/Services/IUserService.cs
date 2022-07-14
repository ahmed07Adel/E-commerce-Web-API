using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
   public interface IUserService
    {
        Task<UserManagerResponse> RegisterUser(RegisterViewModel model);
        Task<UserManagerResponse> LoginUser(LoginViewModel model);
    }
}
