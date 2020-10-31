namespace Camones.Shop.Identity.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Servicio Camones.Shop.Identity se esta ejecutando.";
        }
    }
}