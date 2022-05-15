using MapsterMapper;
using System.Text;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.Taxis.Queries;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Taxis.Handlers
{
    public class GetDriverEarningsQueryHandler : IRequestHandlerWrapper<GetDriverEarningsQuery, string>
    {
        private readonly IRideRepository _rideRepository;
        private readonly IMapper _mapper;

        public GetDriverEarningsQueryHandler(IRideRepository rideRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<string>> Handle(GetDriverEarningsQuery request, CancellationToken cancellationToken)
        {
            int total = 0;
            var sb = new StringBuilder();
            
            IEnumerable<Ride> driverRides = await _rideRepository.GetRidesForDriverId(request.Id);
            IEnumerable<Ride> driverRidesList = driverRides.ToList();
            
            if (driverRidesList.Any())
            {
                foreach (Ride ride in driverRidesList.ToList())
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
            
            return ServiceResult.Success(sb.ToString());
        }
    }
}
