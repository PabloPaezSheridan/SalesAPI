using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempLayersArquitectureAustral.Models;

namespace TempLayersArquitectureAustral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_service.ReadProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product? productToReturn = _service.ReadProducts(id);
            if (productToReturn is not null)
                return Ok();
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductForCreateRequest dto)
        {

            Product prodForCreate = new()
            {
                Code = dto.Code,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            return Ok(_service.CreateProduct(prodForCreate).Id);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _service.DeleteProductById(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductForUpdateDto dto)
        {
            return Ok();
        }

    }
}
