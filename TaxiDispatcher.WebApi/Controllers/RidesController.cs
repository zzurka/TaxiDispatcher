using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Ride.Commands;
using TaxiDispatcher.Application.Ride.Queries;

namespace TaxiDispatcher.WebApi.Controllers
{
    [ApiController]
    public class RidesController : BaseApiController
    {
        public RidesController(ISender mediator) : base(mediator) { }

        /// <summary>
        /// Get Ride by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RideDto>> GetRideById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetRideByIdQuery { Id = id }, cancellationToken));
        }

        /// <summary>
        /// Request a ride
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("RequestRide")]
        public async Task<ActionResult<RideDto>> RequestRide(RequestRideCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Accept a ride
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("AcceptRide")]
        public async Task<ActionResult<RideDto>> AcceptRide(AcceptRideCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
