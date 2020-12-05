using LocaCar.Api.Controllers;
using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LocaCar.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteVersaoController : BaseController
    {
        public TesteVersaoController(INotificador notificador) : base(notificador)
        {
        }

        [Obsolete("Deprecated")]
        [HttpGet]
        public string Valor()
        {
            return "Sou o teste de versão V1.1";
        }

        [HttpPost]
        public string Valor2()
        {
            return "Sou o teste de versão V1.2";
        }
    }
}
