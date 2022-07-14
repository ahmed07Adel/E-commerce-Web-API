
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory Crepo;

        public CategoryController(ICategory Crepo)
        {
            this.Crepo = Crepo;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await Crepo.GetCategories());
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
        [HttpGet("GetCategoryByID/{id:int}")]
        public async Task<ActionResult<Category>> GetCategoryByID(int id)
        {
            try
            {
                var res = await Crepo.GetCategorieById(id);
                if (res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
    }
}
