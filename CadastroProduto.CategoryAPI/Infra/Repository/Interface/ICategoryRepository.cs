using CadastroProduto.CategoryAPI.Entity;

namespace CadastroProduto.CategoryAPI.Infra.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}
