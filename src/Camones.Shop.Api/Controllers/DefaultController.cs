using Microsoft.AspNetCore.Mvc;

namespace Camones.Shop.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Servicio Camones.Shop se esta ejecutando.";
        }
    }
}