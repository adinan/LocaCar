using Elmah.Io.AspNetCore;
using LocaCar.Api.Controllers;
using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LocaCar.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteVersaoController : BaseController
    {
        private readonly ILogger _logger;

        public TesteVersaoController(INotificador notificador,
                                     ILogger<TesteVersaoController> logger) : base(notificador)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {


            try
            {
                var i = 0;
                var result = 42 / i;
            }
            catch (DivideByZeroException e)
            {
                e.Ship(HttpContext);
            }


            throw new Exception("Teste Erro ELMAH");

        }
    }
}
