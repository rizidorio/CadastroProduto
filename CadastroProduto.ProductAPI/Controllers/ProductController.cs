using CadastroProduto.ProductAPI.DTOs;
using CadastroProduto.ProductAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpPost]
        [Route("listar-por-categoria/{categoryId:int}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var products = await _service.GetByCategoryId(categoryId);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            await _service.Create(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            await _service.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete]
        [Route("remover/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetById(id);

            if (product == null)
                return NotFound();
            await _service.Delete(product.Id);
            return Ok(product);
        }
    }
}
