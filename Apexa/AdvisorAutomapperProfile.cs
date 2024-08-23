using Apexa.Data;
using Apexa.Models;
using AutoMapper;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Apexa.Api
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
