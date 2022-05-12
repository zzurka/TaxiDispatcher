using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaxiDispatcher.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController(ISender mediator)
        {
            Mediator = mediator;
        }

        protected ISender Mediator { get; }
    }
}
