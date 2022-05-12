using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.DTOs;
using TaxiDispatcher.Application.Taxi.Queries;

namespace TaxiDispatcher.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxisController : BaseController
    {
        public TaxisController(ISender mediator) : base(mediator) { }
        
        /// <summary>
        /// Get Taxi by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ActionResult<TaxiDto>>> GetTaxiById(Guid id)
        {
            return Ok(await Mediator.Send(new GetTaxiByIdQuery { Id = id }));
        }
    }
}
