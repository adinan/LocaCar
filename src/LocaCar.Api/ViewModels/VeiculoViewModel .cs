using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        public string Modelo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Marca { get; set; }

        [StringLength(7, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 7)]

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1000, 9999, ErrorMessage = "Tamanho do campo {0} invalido")]
        public int AnoModelo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[Range(1000, 9999, ErrorMessage = "Tamanho do campo {0} invalido")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Entre com um ano valido")]
        public int AnoFabricacao { get; set; }

        //public IEnumerable<LocacaoViewModel> Locacoes { get; set; }

    }
}
