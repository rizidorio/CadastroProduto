using CadastroProduto.ProductAPI.DTOs;
using CadastroProduto.ProductAPI.Entity;
using CadastroProduto.ProductAPI.Infra.Repositories.Interface;
using CadastroProduto.ProductAPI.Services.Interface;

namespace CadastroProduto.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ProductDto productDto)
        {
            try
            {
                Product product = new Product(productDto.Name, productDto.Description, productDto.Value, productDto.CategoryId);
                await _repository.Create(product);
                productDto.Id = product.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar produto - {ex.Message}");
            }
        }

        public async Task Update(ProductDto productDto)
        {
            try
            {
                Product product = await _repository.GetById(productDto.Id);
                product.Update(productDto.Name, productDto.Description, productDto.Value, productDto.CategoryId, productDto.Status);
                await _repository.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizado produto - {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Product product = await _repository.GetById(id);
                await _repository.Delete(product.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover produto - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();

                return result.Select(x => new ProductDto
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    Value = x.Value
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar produtos - {ex.Message}");
            }
        }

        public async Task<ProductDto> GetById(int id)
        {
            try
            {
                Product product = await _repository.GetById(id);

                if (product != null)
                {
                    return new ProductDto
                    {
                        Id = product.Id,
                        CategoryId = product.CategoryId,
                        Name = product.Name,
                        Description = product.Description,
                        Status = product.Status,
                        Value = product.Value
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar produto - {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryId(int categoryId)
        {
            try
            {
                var result = await _repository.GetByCategoryId(categoryId);

                return result.Select(x => new ProductDto
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    Value = x.Value
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar produtos - {ex.Message}");
            }
        }
    }
}
