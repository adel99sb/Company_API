using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL_KooD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("Add_Product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                string message = "";
                foreach (var M in ModelState.Values)
                {
                    foreach (var m2 in M.Errors)
                    {
                        message += m2.ErrorMessage + "\n";
                    }
                }
                return BadRequest(message);
            }
            var NewProduct = new Product
            {
                Name= product.Name,
                Type=product.Type
            };
            await _repository.Create(NewProduct);           
            return Ok();
        }
    }
}
