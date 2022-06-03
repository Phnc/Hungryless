using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hungryless.Domain.Entities
{
    public class Supplies : BaseEntity
    {
        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório.")]
        public string? Name { get; set; }
        
        [DisplayName("Categoria")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório.")]
        public string? Category { get; set; }

        [DisplayName("Custo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório.")]
        public decimal Cost { get; set; }

        [DisplayName("Quantidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório.")]
        public int Quantity { get; set; }
    }
}
