using CadastroProduto.WEB.Models;
using CadastroProduto.WEB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroProduto.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var products = await _productService.GetProductsAsync();
            
            if (products != null)
            {
                var result = products.Select(x => new ProductViewModel
                {
                    CategoryName = _categoryService.GetByIdAsync(x.CategoryId).Result.Name,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Value = x.Value
                });
                return View(result);
            }
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProductAsync(productViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
            }
            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

            var result = await _productService.GetByIdAsync(id);

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProductAsync(productViewModel);
                if (result != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product is null)
                return View("Error");

            var result = new ProductViewModel
            {
                CategoryName = _categoryService.GetByIdAsync(product.CategoryId).Result.Name,
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Status = product.Status,
                Value = product.Value
            };

            return View(result);
        }

        [HttpPost(), ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
