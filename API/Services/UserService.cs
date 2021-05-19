using API.Entities;
using API.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<AppUser> usermanager, RoleManager<IdentityRole> _roleManager, IConfiguration configuration, IEmailService emailService)
        {
            this.configuration = configuration;
            this.usermanager = usermanager;
            this._roleManager = _roleManager;

        }
       

        public async Task<UserManagerResponse> RegisterUser(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("register model is null");



            if (model.Password != model.ConfirmPassword)
            
                return new UserManagerResponse
                {
                    Message = "password donot match",
                    IsSuccess = true
                };

                var identityuser = new AppUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await usermanager.CreateAsync(identityuser, model.Password);

                if (result.Succeeded)
                {
                    return new UserManagerResponse
                    {
                        Message = "user created successfully",
                        IsSuccess = true

                    };
                }
                return new UserManagerResponse
                {
                    Message = "user didnot created",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

        public async Task<UserManagerResponse> LoginUser(LoginViewModel model)
        {
         

            
            var user = await usermanager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return new UserManagerResponse
                {
                    Message = "there is no user with this email",
                    IsSuccess =false
                };
            }
            var result = await usermanager.CheckPasswordAsync(user, model.Password);
            if (!result)
            
                return new UserManagerResponse
                {
                    Message = "invalid password",
                    IsSuccess = false
            };

                var claims = new[]
                {
                    new Claim("Email", model.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };
                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSetting:Key"]));
                var token = new JwtSecurityToken(issuer: configuration["AuthSetting:Issuer"], audience:configuration["AuthSetting:Audience"],
                    
                   claims:claims, expires: DateTime.Now.AddDays(30), signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256));
                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };

            }

       

    }
} 

