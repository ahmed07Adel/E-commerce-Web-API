using API.Entities;
using API.Services;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts productsRepo;       
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProductController(IProducts productsRepo, RoleManager<IdentityRole> _roleManager)
        {
            this.productsRepo = productsRepo;
            this._roleManager = _roleManager;
        }
        [HttpPost("AddToCart")]
        public async Task<ActionResult<ProductinCart>> AddToCart(AddToCartViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var DateNow = DateTime.Now;
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.UserId = userID;
                model.AddTime = DateNow;
                var entity = new ProductinCart
                {
                    UserId = model.UserId,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    AddTime = model.AddTime
                };
                var res = await productsRepo.AddToCart(entity);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
      
        [HttpPost("StarRating")]
        public async Task<ActionResult<ProductRating>> StarRating(RateProductCreation model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.UserId = userID;
                var entity = new ProductRating
                {
                    Rate = model.Rate,
                    ProductId = model.ProductId,
                    UserId = model.UserId

                };

                var res = await productsRepo.StarRatting(entity);            
                return Ok(res);
            }
            catch (Exception)
            {               
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpGet("GetClothesProducts")]
        public async Task<IActionResult> GetClothesProducts()
        {
            try
            {
                var res = await productsRepo.GetClothesProducts();
                return Ok(res);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");

            }
        }
        [HttpGet("GetElectronicsProducts")]
        public async Task<IActionResult> GetElectronicsProducts()
        {
            try
            {
                var res = await productsRepo.GetElectronicsProducts();
                return Ok(res);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");

            }
        }
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ProductsModel>>> Search(string Productname)
        {
            try
            {
                var res = await productsRepo.Search(Productname);
                if (res.Any())
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        } 


        [HttpPost("Upload"), DisableRequestSizeLimit]
        public ActionResult<string> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var foldername = Path.Combine("Resources", "Images");
                var savefolder = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString();
                    var fullpath = Path.Combine(savefolder, filename);
                    var dppath = Path.Combine(foldername, filename);

                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(dppath);           
                }
                else
                {
                    return BadRequest();
                }



            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {e}");
            }
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<ProductsModel>> CreateProduct([FromForm]ProductDto model)
        {
          
            try
            {
                if (model == null)
                    {
                        return BadRequest();
                    }
                    var foldername = Path.Combine("Resources", "Images");
                    var savefolder = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                    var dbPath = string.Empty;
                    if (model.Picture.Length > 0)
                    {
                        var filename = ContentDispositionHeaderValue.Parse(model.Picture.ContentDisposition).FileName.ToString();
                        var fullpath = Path.Combine(savefolder, filename);
                        dbPath = Path.Combine(foldername, filename);

                        using (var stream = new FileStream(fullpath, FileMode.Create))
                        {
                            model.Picture.CopyTo(stream);
                        }


                    }
                    model.ProductPic = dbPath;
                    var entity = new ProductsModel
                    {
                        ProductPic = model.ProductPic,
                        ProductName = model.ProductName,
                        Description = model.Description,
                        Price = model.Price,
                        Category = model.Category
                    };
                    var res = await productsRepo.CreateProduct(entity);
                    //if (!User.IsInRole("admin"))
                    //{
                    //    return BadRequest();
                    //}

                    return res;

               

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");

            }
        }

        [HttpGet("GetProductById/{id:int}")]
        public async Task<ActionResult<ProductsModel>> GetProductById(int id)
        {
           
            try
            {
                var res = await productsRepo.GetProductById(id);
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
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await productsRepo.GetProducts());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }

        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<ActionResult<ProductsModel>> UpdateProduct([FromBody]ProductDto productsModel)
        {
            try
            {
                var Prod = await productsRepo.GetProductById(productsModel.Id);

                if (productsModel.ProductPic == "" || productsModel.ProductPic == null)
                {
                    var foldername = Path.Combine("Resources", "Images");
                    var savefolder = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                    var dbPath = string.Empty;
                    if (productsModel.Picture.Length > 0)
                    {
                        var filename = ContentDispositionHeaderValue.Parse(productsModel.Picture.ContentDisposition).FileName.ToString();
                        var fullpath = Path.Combine(savefolder, filename);
                        dbPath = Path.Combine(foldername, filename);

                        using (var stream = new FileStream(fullpath, FileMode.Create))
                        {
                            productsModel.Picture.CopyTo(stream);
                        }


                    }
                    productsModel.ProductPic = dbPath;
                }
                if (Prod == null)
                {
                    return NotFound($"this product = {productsModel.Id} Can not found");
                }
                return await productsRepo.UpdateProduct(productsModel);
                    
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsModel>> DeleteProduct(int id)
        {          
            try
            {
               return await productsRepo.DeleteProduct(id);
            }
          
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");              
            }
        }
    }
}
