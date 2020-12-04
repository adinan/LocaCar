using System;
using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.ViewModels
{
    public class LocacaoViewModel
    {
        [Key]
        public Guid VeiculoId { get; set; }
        
        [Key]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataFim { get; set; }

    }
}
