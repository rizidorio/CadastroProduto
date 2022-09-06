using CadastroProduto.ProductAPI.Entity;

namespace CadastroProduto.ProductAPI.Infra.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetByCategoryId(int categoryId);
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
