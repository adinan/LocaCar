using LocaCar.Api.Controllers;
using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteVersaoController : BaseController
    {
        public TesteVersaoController(INotificador notificador) : base(notificador)
        {
        }

        [HttpGet]
        public string Valor()
        {

            return "Sou o teste de versão V2";
        }
    }
}
