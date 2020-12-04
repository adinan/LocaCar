using LocaCar.Api.Extensions;
using LocaCar.Api.ViewModels;
using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Api.Controllers
{
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}")]
    public class UsuarioController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;


        public UsuarioController(INotificador notificador,
                                 SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager,
                                 IOptions<AppSettings> appSettings) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("novo-usuario")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = model.Nome,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(model.Login));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(model);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(model.Login));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(model);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(model);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string login)
        {
            var user = await _userManager.FindByNameAsync(login);
            //var user = await _u

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                //Nome = ""
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                Id = user.Id,
            };

            return response;
        }


    }
}
