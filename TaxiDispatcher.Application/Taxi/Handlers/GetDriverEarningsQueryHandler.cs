using System.Text;
using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Taxi.Queries;

namespace TaxiDispatcher.Application.Taxi.Handlers
{
    public class GetDriverEarningsQueryHandler : IRequestHandler<GetDriverEarningsQuery, string>
    {
        private readonly IRideRepository _rideRepository;
        private readonly IMapper _mapper;

        public GetDriverEarningsQueryHandler(IRideRepository rideRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetDriverEarningsQuery request, CancellationToken cancellationToken)
        {
            int total = 0;
            var sb = new StringBuilder();
            
            IEnumerable<Domain.Entities.Ride> driverRides = await _rideRepository.GetRidesForDriverId(request.Id);
            IEnumerable<Domain.Entities.Ride> driverRidesList = driverRides.ToList();
            
            if (driverRidesList.Any())
            {
                foreach (Domain.Entities.Ride ride in driverRidesList.ToList())
                {
                    sb.AppendLine($"Price: {ride.Price}");
                    total += ride.Price;
                }

                sb.AppendLine($"Total: {total}");
            }
            else
            {
                sb.Append("No drives for driver found!");
            }
            
            return sb.ToString();
        }
    }
}
