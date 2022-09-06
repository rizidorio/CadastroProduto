using CadastroProduto.WEB.Utils.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.WEB.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Nome")]
        public string? Name { get; set; }

        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Valor")]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [DisplayName("Categoria")]
        public string? CategoryName { get; set; }
        public Status Status { get; set; }
    }
}
