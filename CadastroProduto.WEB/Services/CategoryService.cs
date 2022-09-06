using CadastroProduto.WEB.Models;
using CadastroProduto.WEB.Services.Interface;
using System.Text;
using System.Text.Json;

namespace CadastroProduto.WEB.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel category)
        {
            HttpClient client = GetClient();
            StringContent content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

            using var response = await client.PostAsync("adicionar", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            return null;
        }

        public async Task<CategoryViewModel> UpdateCategoryAsync(CategoryViewModel category)
        {
            HttpClient client = GetClient();

            using var response = await client.PutAsJsonAsync("editar", category);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            return null;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            HttpClient client = GetClient();
            using var response = await client.DeleteAsync($"remover/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            HttpClient client = GetClient();

            using var response = await client.GetAsync(id.ToString());
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CategoryViewModel>(result, _options);
            }
            return null;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            HttpClient client = GetClient();
            using var response = await client.GetAsync("listar");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(result, _options);
            }
            return null;
        }

        private HttpClient GetClient()
        {
            return _httpClientFactory.CreateClient("CategoryApi");
        }
    }
}
