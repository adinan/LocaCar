using LocaCar.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : BaseController
    {
        public ClienteController(INotificador notificador) : base(notificador)
        {
            
        }
    }
}
