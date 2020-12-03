using LocaCar.Api.ViewModels;
using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LocaCar.Api.Controllers
{
    [Route("api")]
    public class UsuarioController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioController(INotificador notificador,
                                 SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("novo-usuario")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                //return CustomResponse(await GerarJwt(user.Email));
                return CustomResponse(model);
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
                //_logger.LogInformation("Usuario " + model.Email + " logado com sucesso");
                //return CustomResponse(await GerarJwt(model.Email));
                return CustomResponse(model);
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(model);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(model);
        }

    }
}
