using CadastroProduto.CategoryAPI.DTOs;
using CadastroProduto.CategoryAPI.Entity;
using CadastroProduto.CategoryAPI.Infra.Repository.Interface;
using CadastroProduto.CategoryAPI.Services.Interface;

namespace CadastroProduto.CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CategoryDto categoryDto)
        {
            try
            {
                Category category = new Category(categoryDto.Name);
                await _repository.Create(category);
                categoryDto.Id = category.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar categoria - {ex.Message}");
            }
        }

        public async Task Update(CategoryDto categoryDto)
        {
            try
            {
                Category category = await _repository.GetById(categoryDto.Id);
                category.Update(categoryDto.Name, categoryDto.Status);
                await _repository.Update(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar categoria - {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Category category = await _repository.GetById(id);

                await _repository.Delete(category.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover categoria - {ex.Message}");
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();

                return result.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status
                });

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar categorias - {ex.Message}");
            }
        }

        public async Task<CategoryDto> GetById(int id)
        {
            try
            {
                Category category = await _repository.GetById(id);

                if (category != null)
                {
                    return new CategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Status = category.Status,
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar categoria - {ex.Message}");
            }
        }
    }
}
