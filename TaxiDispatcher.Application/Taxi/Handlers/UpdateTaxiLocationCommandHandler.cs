using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.Taxi.Commands;

namespace TaxiDispatcher.Application.Taxi.Handlers
{
    public class UpdateTaxiLocationCommandHandler : IRequestHandler<UpdateTaxiLocationCommand, bool>
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public UpdateTaxiLocationCommandHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateTaxiLocationCommand request, CancellationToken cancellationToken)
        {
            return await _taxiRepository.UpdateTaxiLocation(request.Id, request.Location);
        }
    }
}
