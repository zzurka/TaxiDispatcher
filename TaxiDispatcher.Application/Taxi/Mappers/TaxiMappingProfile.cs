using AutoMapper;
using TaxiDispatcher.Application.DTOs;

namespace TaxiDispatcher.Application.Taxi.Mappers
{
    public class TaxiMappingProfile : Profile
    {
        public TaxiMappingProfile()
        {
            CreateMap<Domain.Entities.Taxi, TaxiDto>().ReverseMap();
            CreateMap<Domain.Entities.TaxiCompany, TaxiCompanyDto>().ReverseMap();
        }
    }
}
