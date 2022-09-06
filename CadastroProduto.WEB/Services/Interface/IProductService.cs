using CadastroProduto.WEB.Models;

namespace CadastroProduto.WEB.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<IEnumerable<ProductViewModel>> GetByCategoryId(int categoryId);
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(ProductViewModel product);
        Task<ProductViewModel> UpdateProductAsync(ProductViewModel product);
        Task<bool> DeleteProductAsync(int id);
    }
}
