using CadastroProduto.CategoryAPI.Utils;

namespace CadastroProduto.CategoryAPI.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Status Status { get; set; }
    }
}
