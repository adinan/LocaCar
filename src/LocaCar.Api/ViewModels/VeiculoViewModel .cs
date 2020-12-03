using System;
using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
