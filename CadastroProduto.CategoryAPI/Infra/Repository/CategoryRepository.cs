using CadastroProduto.CategoryAPI.Entity;
using CadastroProduto.CategoryAPI.Infra.Context;
using CadastroProduto.CategoryAPI.Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroProduto.CategoryAPI.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            var result = _context.Add(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            Category category = await GetById(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
