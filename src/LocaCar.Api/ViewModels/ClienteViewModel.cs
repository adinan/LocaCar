using System;
using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Cpf { get; set; }

    }
}
