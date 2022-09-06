using CadastroProduto.CategoryAPI.DTOs;

namespace CadastroProduto.CategoryAPI.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task Create(CategoryDto categoryDto);
        Task Update(CategoryDto categoryDto);
        Task Delete(int id);
    }
}
