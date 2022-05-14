using MapsterMapper;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.Taxis.Commands;

namespace TaxiDispatcher.Application.Taxis.Handlers
{
    public class UpdateTaxiLocationCommandHandler : IRequestHandlerWrapper<UpdateTaxiLocationCommand, bool>
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public UpdateTaxiLocationCommandHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<bool>> Handle(UpdateTaxiLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await _taxiRepository.UpdateTaxiLocation(request.Id, request.Location);

            return result 
                ? ServiceResult.Success<bool>(true) 
                : ServiceResult.Failed<bool>(ServiceError.CustomMessage("Update location failed! Taxi not found!"));
        }
    }
}
