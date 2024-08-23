using Apexa.Data;
using Apexa.Models;
using AutoMapper;

namespace Apexa.Business
{
    public class AdvisorAutomapperProfile : Profile
    {
        public AdvisorAutomapperProfile()
        {
            CreateMap<Advisor, AdvisorReadDto>();
            CreateMap<AdvisorCreationDto, Advisor>();
            CreateMap<AdvisorUpdateDto, Advisor>();
        }

    }
}
