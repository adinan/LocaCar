using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.ViewModels
{

    public class RegistrarUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }


    public class LoginResponseViewModel
    {
        public string Nome { get; set; }
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public string Id { get; internal set; }
    }



}
