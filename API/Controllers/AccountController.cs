using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using API.Entities;
using API.Services;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userservice;
        private readonly UserManager<AppUser> usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUserService userservice, UserManager<AppUser> usermanager, RoleManager<IdentityRole> _roleManager)
        {
            this.userservice = userservice;
            this.usermanager = usermanager;
            this._roleManager = _roleManager;


        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

           
            AppUser user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),

            };
            if (!await _roleManager.RoleExistsAsync(RolesModel.admin))
                await _roleManager.CreateAsync(new IdentityRole(RolesModel.admin));
            if (!await _roleManager.RoleExistsAsync(RolesModel.user))
                await _roleManager.CreateAsync(new IdentityRole(RolesModel.user));
            if (ModelState.IsValid)
            {
                var result = await userservice.RegisterUser(model);

                var res2 = await usermanager.AddToRoleAsync(user, RolesModel.user);

                if (result.IsSuccess)
                {
                    //EmailService.SendEmail("ahmedahemd123adel.007@gmail.com", "EmailConfirmation", "<a href=\"" + ConfirmationLink "\">Confirm Registration", true, User.Identity.Name);

                    return Ok(result);

                }
                if (result.IsSuccess)
                {
                    return (IActionResult)res2;

                }

                else
                {
                    return BadRequest(result);
                }
            }
            return BadRequest("some thing not valid");
        }
        [HttpPost]
        [Route("AdminRegister")]
        public async Task<IActionResult> AdminRegister([FromBody] RegisterViewModel model)
        {
            var userExist = await usermanager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "user Already Exist");
            }
            AppUser user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            
            };
            var result = await usermanager.CreateAsync(user, model.Password);
            if (!result.Succeeded)  
                return StatusCode(StatusCodes.Status500InternalServerError, "check details");
            
            if (!await _roleManager.RoleExistsAsync(RolesModel.admin))
                await _roleManager.CreateAsync(new IdentityRole(RolesModel.admin));
            if (!await _roleManager.RoleExistsAsync(RolesModel.user))
                await _roleManager.CreateAsync(new IdentityRole(RolesModel.user));

            if (await _roleManager.RoleExistsAsync(RolesModel.admin))
            {
                await usermanager.AddToRoleAsync(user, RolesModel.admin);
            }
            return Ok();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {            
                var result = await userservice.LoginUser(model);
                if (result.IsSuccess)
                {
                   
                    return Ok(result);

                }
                return BadRequest(result);
            }
            return BadRequest("some thing is wrong");
        }
    }
}
