using Microsoft.AspNetCore.Mvc;

namespace Microservices.CalculadorDeJuros.WebApi.Controllers.Base
{
    [ApiController, Route("api/v{version:apiVersion}")]
    public abstract class BaseController : ControllerBase
    {
    }
}