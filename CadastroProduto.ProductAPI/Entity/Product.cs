using CadastroProduto.ProductAPI.Utils;

namespace CadastroProduto.ProductAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Product(string? name, string? description, decimal value, int categoryId)
        {
            Name = name;
            Description = description;
            Value = value;
            CategoryId = categoryId;
            Status = Status.Active;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public void Update(string? name, string? description, decimal value, int categoryId, Status status)
        {
            Name = name;
            Description = description;
            Value = value;
            CategoryId = categoryId;
            Status = status;
            Updated = DateTime.Now;
        }
    }
}
