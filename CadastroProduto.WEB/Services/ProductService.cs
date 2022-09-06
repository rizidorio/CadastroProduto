using CadastroProduto.WEB.Models;
using CadastroProduto.WEB.Services.Interface;
using System.Text;
using System.Text.Json;

namespace CadastroProduto.WEB.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
        {
            HttpClient client = GetClient();
            StringContent content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            using var response = await client.PostAsync("adicionar", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ProductViewModel>(result, _options);
            }
            return null;
        }

        public async Task<ProductViewModel> UpdateProductAsync(ProductViewModel product)
        {
            HttpClient client = GetClient();

            using var response = await client.PutAsJsonAsync("editar", product);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ProductViewModel>(result, _options);
            }
            return null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            HttpClient client = GetClient();
            using var response = await client.DeleteAsync($"remover/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProductViewModel>> GetByCategoryId(int categoryId)
        {
            HttpClient client = GetClient();

            using var response = await client.GetAsync($"listar-por-categoria/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(result, _options);
            }
            return null;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            HttpClient client = GetClient();

            using var response = await client.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ProductViewModel>(result, _options);
            }
            return null;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            HttpClient client = GetClient();

            using var response = await client.GetAsync("listar");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(result, _options);
            }
            return null;
        }

        private HttpClient GetClient()
        {
            return _httpClientFactory.CreateClient("ProductApi");
        }
    }
}
