using CadastroProduto.CategoryAPI.Utils;

namespace CadastroProduto.CategoryAPI.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Category(string? name)
        {
            Name = name;
            Status = Status.Active;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public void Update(string? name, Status status)
        {
            Name = name;
            Status = status;
            Updated = DateTime.Now;
        }
    }
}
