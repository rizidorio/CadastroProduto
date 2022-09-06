using CadastroProduto.ProductAPI.Entity;
using CadastroProduto.ProductAPI.Infra.Context;
using CadastroProduto.ProductAPI.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroProduto.ProductAPI.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            var result = _context.Add(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            Product product = await GetById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId.Equals(categoryId)).ToListAsync();
        }
    }
}
