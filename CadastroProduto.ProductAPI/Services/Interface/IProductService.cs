using CadastroProduto.ProductAPI.DTOs;

namespace CadastroProduto.ProductAPI.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<ProductDto>> GetByCategoryId(int categoryId);
        Task<ProductDto> GetById(int id);
        Task Create(ProductDto productDto);
        Task Update(ProductDto productDto);
        Task Delete(int id);
    }
}
