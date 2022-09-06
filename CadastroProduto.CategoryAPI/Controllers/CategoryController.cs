using CadastroProduto.CategoryAPI.DTOs;
using CadastroProduto.CategoryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetById(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();

            if (categories is null)
                return NotFound();

            return Ok(categories);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto is null)
                return BadRequest();

            await _service.Create(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto is null)
                return BadRequest();

            await _service.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("remover/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDto = await _service.GetById(id);

            if (categoryDto is null)
                return NotFound();
            await _service.Delete(categoryDto.Id);
            return Ok(categoryDto);
        }
    }
}
