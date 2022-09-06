using CadastroProduto.WEB.Models;

namespace CadastroProduto.WEB.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel category);
        Task<CategoryViewModel> UpdateCategoryAsync(CategoryViewModel category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
