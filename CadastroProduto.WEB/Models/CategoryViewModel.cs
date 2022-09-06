using CadastroProduto.WEB.Utils.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        [DisplayName("Nome")]
        public string? Name { get; set; }
        public Status Status { get; set; }
    }
}
