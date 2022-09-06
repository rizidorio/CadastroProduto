using CadastroProduto.WEB.Models;
using CadastroProduto.WEB.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            var result = await _categoryService.GetCategoriesAsync();

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.CreateCategoryAsync(category);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateCategoryAsync(category);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost(), ActionName("DeleteCategory")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            if (!result)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }
    }
}
