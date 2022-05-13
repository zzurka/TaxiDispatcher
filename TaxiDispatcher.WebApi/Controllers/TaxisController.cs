using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Taxi.Commands;
using TaxiDispatcher.Application.Taxi.Queries;

namespace TaxiDispatcher.WebApi.Controllers
{
    [ApiController]
    public class TaxisController : BaseApiController
    {
        public TaxisController(ISender mediator) : base(mediator) { }

        /// <summary>
        /// Get taxi by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaxiDto>> GetTaxiById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTaxiByIdQuery { Id = id }, cancellationToken));
        }

        /// <summary>
        /// Get taxi by driver id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Driver/{id:int}")]
        public async Task<ActionResult<TaxiDto>> GetTaxiByDriverId(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetTaxiByDriverIdQuery { Id = id }, cancellationToken));
        }

        /// <summary>
        /// Update taxi location
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("UpdateLocation")]
        public async Task<ActionResult<bool>> UpdateTaxiLocation(UpdateTaxiLocationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get driver earnings
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Driver/{id:int}/Earnings")]
        public async Task<ActionResult<string>> GetDriverEarnings(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetDriverEarningsQuery { Id = id }, cancellationToken));
        }
    }
}
