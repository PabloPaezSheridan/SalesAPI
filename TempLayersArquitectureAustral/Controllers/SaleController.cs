using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Security.Claims;

namespace TempLayersArquitectureAustral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _service;
        private readonly ProductService _productService;
        private int _userId;
        public SaleController(SaleService service, ProductService productService)
        {
            _service = service;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost("open")]
        public IActionResult Add()
        {
            _userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Sale saleForCreation = new()
            {
                User = new User() { Id = _userId },
                DateTime = DateTime.UtcNow,
                State = Data.Models.StateEnum.Draft

            };
            return Ok();
        }

        [HttpPut("{saleId}")]
        public IActionResult Update([FromBody] List<int> idProducts, [FromRoute] int saleId)
        {
            Sale saleForUpdate = new()
            {
                Id = saleId,
                //Products = _productService.FilterAvailableProducts(idProducts)
            };
            _service.Update(saleForUpdate);
            return Ok();
        }

        [HttpPost("close")]
        public IActionResult ConfirmOrder(int idSale)
        {
            Sale? saleToClose = _service.Get(idSale);
            if (saleToClose is not null && saleToClose.User.Id == _userId)
            {
                saleToClose.State = Data.Models.StateEnum.Active;
                _service.Update(saleToClose);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}

